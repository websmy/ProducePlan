using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_GongShiChaXun : System.Web.UI.Page
{
    private DataSet _dsBind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //_dsBind = SQLHelper1.Query("select  * from workhours_manage ");
            //BindData3();
            //_dsBind = new DataSet();
            //string sql = "";
            //if (String.IsNullOrEmpty(cInvcode))
            //{
            //    sql = "select  * from workhours_manage";
            //}
            //else
            //{
            //    sql = "select  * from workhours_manage where 产品编码='" + cInvcode + "'";
            //}

            //HyperLink1.Text = "生成报表";
            ////string url = "MomPop.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
            ////lingliao.Target = "_blank";
            //HyperLink1.ToolTip = "生成报表";
            //HyperLink1.Attributes.Add("onclick",
            //                        "openwin20140610('GongShiReport.aspx','GongShiReport','" + modid.Value + "','650','600','" +
            //                        MDeptCode.Value + "','" + e.Row.Cells[7].Text + "','" +
            //                        e.Row.Cells[5].Text + "','" +
            //                        e.Row.Cells[9].Text + "','" + MoId.Value + "','" + SoDId.Value +
            //                        "' ,'" + cinvdefine4.Value + "' )");
            //HyperLink1.NavigateUrl = "javascript:void(0)";
            //b已经领完 = false;
        }
    }

    public void BindData3()
    {
        _dsBind = new DataSet();
        string sql = "";
        sql += "select  b.autoid,*, CONVERT(varchar(10), b.ddate, 120) as 录入日期,a.工时*b.数量 as 总工时 from 工时录入 b  left join   [workhours_manage] a  on a.产品编码=b.产品编码  and b.工序autoid=a.autoid  left join workhours_manage_worker c on c.工人编码=b.工人编码   left join 车间名称  e on  e.flag=a.flag where 1=1 ";

        if (!String.IsNullOrEmpty(txtStartDate.Text.Trim()))
        {
            sql += " and CONVERT(varchar(10), b.ddate, 120) >= '" + txtStartDate.Text.Trim() + " '";
        }

        if (!String.IsNullOrEmpty(txtEndDate.Text.Trim()))
        {
            sql += " and CONVERT(varchar(10), b.ddate, 120) <=  '" + txtEndDate.Text.Trim() + " '";
        }
        
        if (!String.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            sql += " and b.工人编码='" + TextBox1.Text.Trim() + "'";
        }

        //if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
        //{
        //    sql += " and 产品编码 like '%" + TextBox2.Text.Trim()+ "%'";
        //}
        if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
        {
            sql += " and b.生产订单号='" + TextBox2.Text.Trim() + "'";
        }
        if (!String.IsNullOrEmpty(TextBox3.Text.Trim()))
        {
            sql += " and b.行号='" + TextBox3.Text.Trim() + "'";
        }

        _dsBind = SQLHelper1.Query(sql);

        decimal HeJi = 0;

        for (int i = 0; i < _dsBind.Tables[0].Rows.Count; i++)
        {
            try
            {
                HeJi += Convert.ToDecimal(_dsBind.Tables[0].Rows[i]["总工时"]);

            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                //RuKuHeJi += Convert.ToDouble(ds.Tables[0].Rows[i]["iquantity"]);
            }
        }
        //LabelChanZhi.Text = ChanZhi.ToString();
        Label2.Text = HeJi.ToString();

        GridView3.DataSource = _dsBind;
        GridView3.DataBind();
    }

  

    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //string workhours_manage = "";
        string 工序autoid = "";
        string 数量 = "";
        string h数量 = "";
        //string 工时 = "";
        //string 板材编码 = "";
        //string 下料尺寸 = "";
        //string 板厚 = "";
        //string 材质 = "";
        //string 设备 = "";
        //string 加工说明 = "";
        GridViewRow _row = GridView3.Rows[e.RowIndex];

        工序autoid = (_row.FindControl("ddl工序") as DropDownList).SelectedValue.Trim();
        数量 = (_row.FindControl("txt数量") as TextBox).Text.Trim();
        h数量 = (_row.FindControl("h数量") as HiddenField).Value;

        //工时 = (_row.FindControl("txt工时") as TextBox).Text.Trim();
        //板材编码 = (_row.FindControl("txt板材编码") as TextBox).Text.Trim();
        //下料尺寸 = (_row.FindControl("txt下料尺寸") as TextBox).Text.Trim();
        //板厚 = (_row.FindControl("txt板厚") as TextBox).Text.Trim();
        //材质 = (_row.FindControl("txt材质") as TextBox).Text.Trim();
        //设备 = (_row.FindControl("txt设备") as TextBox).Text.Trim();
        //加工说明 = (_row.FindControl("txt加工说明") as TextBox).Text.Trim();


        Label autoid = (Label)_row.FindControl("autoid");

        string sql =
            "update  [工时录入] set 工序autoid='" + 工序autoid + "', 数量='" + 数量 + "' " +
            //",工时='" + 工时 + "'" +
            //",板材编码='" + 板材编码 + "'" +
            //",下料尺寸='" + 下料尺寸 + "'" +
            //",板厚='" + 板厚 + "'" +
            //",材质='" + 材质 + "'" +
            //",设备='" + 设备 + "'" +
            //",加工说明='" + 加工说明 + "'" +

            " where autoid=" + autoid.Text.Trim();


        decimal d数量 = 0;
        decimal dCnt = 0;
        try
        {
            dCnt = Convert.ToDecimal(SQLHelper1.Query("select sum(数量) from 工时录入 where 工序autoid='" + 工序autoid + "' ").Tables[0].Rows[0][0]);
            d数量 = Convert.ToDecimal(h数量);
        }
        catch (Exception)
        {
            dCnt = 0;
            d数量 = 0;
        }


        string sql1 =
           "SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,'' as 是否缺料,"
           +
           " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
           + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
           + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
           + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
           + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
           + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID  "
           + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "
           + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 ";
        sql1 += " and 1=1 ";

        sql1 += " and mocode='" + (_row.FindControl("label生产订单号") as Label).Text.Trim() + "'";
        sql1 += " and sortseq='" + (_row.FindControl("label行号") as Label).Text.Trim() + "'";
        //sql += " and InvCode='" + TextBox2.Text.Trim() + "'";

        DataSet ds = SQLHelper.Query(sql1);

        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count == 1)
        {
   
        }
        else
        {
 
            MessageBox.Show(this, "数据输入错误！请重新输入。");
            //ret = false;
        }

        if (dCnt - d数量 + (Convert.ToDecimal(数量)) > Convert.ToDecimal(dt.Rows[0]["Qty"].ToString()))
        {
            MessageBox.Show(this, "输入的数量超出订单数量！");
        }
        else
        {
            SQLHelper1.ExecuteSql(sql);
            GridView3.EditIndex = -1;
            BindData3();
        }


        //SQLHelper1.ExecuteSql(sql);
        //GridView3.EditIndex = -1;
        //BindData3();
        //BindData();

    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow _row = GridView3.Rows[e.RowIndex];
        Label autoid = (Label)_row.FindControl("autoid");

        string sql = " delete from [工时录入] where autoid=" + autoid.Text.Trim();
        SQLHelper1.ExecuteSql(sql);
        GridView3.EditIndex = -1;
        BindData3();
        //BindData();

    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strsql = "";
        if (e.CommandName == "Add")
        {
            string workhours_manage = "";


            if (GridView3.Rows.Count > 0)
            {


                string 产品编码 = "";
                string 工序 = "";
                string 工时 = "";
                //string 板材编码 = "";
                //string 下料尺寸 = "";
                //string 板厚 = "";
                //string 材质 = "";
                //string 设备 = "";
                //string 加工说明 = "";


                //int maxid = SQLHelper1.GetMaxID("val", "workhours_manage");
                产品编码 = (GridView3.FooterRow.FindControl("txt产品编码F") as TextBox).Text.Trim();
                工序 = (GridView3.FooterRow.FindControl("txt工序F") as TextBox).Text.Trim();
                工时 = (GridView3.FooterRow.FindControl("txt工时F") as TextBox).Text.Trim();
                //板材编码 = (GridView3.FooterRow.FindControl("txt板材编码F") as TextBox).Text.Trim();
                //下料尺寸 = (GridView3.FooterRow.FindControl("txt下料尺寸F") as TextBox).Text.Trim();
                //板厚 = (GridView3.FooterRow.FindControl("txt板厚F") as TextBox).Text.Trim();
                //材质 = (GridView3.FooterRow.FindControl("txt材质F") as TextBox).Text.Trim();
                //设备 = (GridView3.FooterRow.FindControl("txt设备F") as TextBox).Text.Trim();
                //加工说明 = (GridView3.FooterRow.FindControl("txt加工说明F") as TextBox).Text.Trim();

                strsql = " INSERT INTO [workhours_manage]" +
                         " ([产品编码]          " +
                         " ,[工序]          " +
                         " ,[工时]          " +
                         //" ,[板材编码]          " +
                         //" ,[下料尺寸]          " +
                         //" ,[板厚]                 " +
                         //" ,[材质]                 " +
                         //" ,[设备]                 " +
                         ")         " +
                         "     VALUES          " +
                         "      ('" + 产品编码 + "'     " +
                         " ,'" + 工序 + "'          " +
                         " ,'" + 工时 + "'          " +
                         //" ,'" + 板材编码 + "'          " +
                         //" ,'" + 下料尺寸 + "'          " +
                         //" ,'" + 板厚 + "'                 " +
                         //" ,'" + 材质 + "'                 " +
                         //" ,'" + 设备 + "'                 " +
                         " )";
            }
            else
            {
            }

        }

        if (!string.IsNullOrEmpty(strsql))
        {
            SQLHelper1.ExecuteSql(strsql);
            BindData3();
            //BindData();

        }
    }


    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        //if (GridView3.Rows.Count == 0)
        //{
        //    renderEmptyGridView(GridView3, " autoid,产品编码,工序,工时");
        //}
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        BindData3();
        //BindData();
    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        BindData3();
        //BindData();
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex > -1)
        {
            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
             if (User.IsInRole("工时编辑"))
             {
                 LinkButton1.Visible = true;
                 LinkButton2.Visible = true;
             }
             else
             {
                 LinkButton1.Visible = false;
                 LinkButton2.Visible = false;
             }
        }
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label label工人编码 = (Label)e.Row.FindControl("label工人编码");
                ((LinkButton)e.Row.Cells[12].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + label工人编码.Text.Trim() + "\"吗?')");
            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Edit || ((int) (e.Row.RowState & DataControlRowState.Edit)) != 0)
            {

                DropDownList ddl工序 = (DropDownList) e.Row.FindControl("ddl工序");
                Label 工序autoid = (Label) e.Row.FindControl("工序autoid");
                Label 产品编码 = (Label)e.Row.FindControl("label产品编码");

                //dropTemp = (DropDownList) e.Row.FindControl("DropDownList19");
                if (ddl工序 != null)
                {

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //dic.Add("请选择", "请选择");

                    DataTable dt =
                        SQLHelper1.Query("select  autoid,工序 from [workhours_manage] where 产品编码='" + 产品编码.Text.Trim() +
                                         "'").
                            Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string temp0 = dt.Rows[i][0].ToString();
                        string temp1 = dt.Rows[i][1].ToString();
                        dic.Add(temp0, temp1);
                    }

                    ddl工序.DataSource = dic;
                    ddl工序.DataTextField = "Value";
                    ddl工序.DataValueField = "Key";

                    ddl工序.SelectedValue = 工序autoid.Text;
                    ddl工序.DataBind();
                }
            }
        }
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;
            if (null != pagerRow)
            {
                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
            }
            if (null != txtNewPageIndex)
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text.Trim()) - 1; // get the NewPageIndex
            }
        }
        else
        { newPageIndex = e.NewPageIndex; }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        BindData3();
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        
       
        BindData3();
    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string val = "";
        if (!string.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            string txt = TextBox1.Text.Trim();
            DataTable dt = SQLHelper1.Query("select 工人姓名 from [workhours_manage_worker] where [工人编码]='" + txt + "'").Tables[0];
            if (dt.Rows.Count != 0)
            {
                val = dt.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show(this, "此工人编编码不存在！");
            }
        }
        Label1.Text = val;
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
        {
            TextBox2.Text = (System.Convert.ToInt32(TextBox2.Text)).ToString().PadLeft(10, '0');
        }
       
    }

    private DataTable dataTable;
    protected void Button111_Click(object sender, EventArgs e)
    {
        //DateTime dt = System.DateTime.Now;
        //string str = dt.ToString("yyyyMMddhhmmss");
        //str = str + ".xls";

        dataTable = new DataTable();
        string sql = "";
        sql += "select  b.autoid,*, CONVERT(varchar(10), b.ddate, 120) as 录入日期,a.工时*b.数量 as 总工时 from 工时录入 b  left join   [workhours_manage] a  on a.产品编码=b.产品编码  and b.工序autoid=a.autoid  left join workhours_manage_worker c on c.工人编码=b.工人编码   left join 车间名称  e on  e.flag=a.flag where 1=1  ";
        if (!String.IsNullOrEmpty(txtStartDate.Text.Trim()))
        {
            sql += " and CONVERT(varchar(10), b.ddate, 120) >= '" + txtStartDate.Text.Trim() + " '";
        }

        if (!String.IsNullOrEmpty(txtEndDate.Text.Trim()))
        {
            sql += " and CONVERT(varchar(10), b.ddate, 120) <=  '" + txtEndDate.Text.Trim() + " '";
        }
        //if (!String.IsNullOrEmpty(TextBox1.Text.Trim()))
        //{
        //    sql += " and b.工人编码='" + TextBox1.Text.Trim() + "'";
        //}

        //if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
        //{
        //    sql += " and 产品编码 like '%" + TextBox2.Text.Trim()+ "%'";
        //}
        //if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
        //{
        //    sql += " and b.生产订单号='" + TextBox2.Text.Trim() + "'";
        //}
        //if (!String.IsNullOrEmpty(TextBox3.Text.Trim()))
        //{
        //    sql += " and b.行号='" + TextBox3.Text.Trim() + "'";
        //}

        dataTable = SQLHelper1.Query(sql).Tables[0];

        //decimal HeJi = 0;

        //for (int i = 0; i < _dsBind.Tables[0].Rows.Count; i++)
        //{
        //    try
        //    {
        //        HeJi += Convert.ToDecimal(_dsBind.Tables[0].Rows[i]["总工时"]);

        //    }
        //    catch (Exception)
        //    {

        //        //throw;
        //    }
        //    finally
        //    {
        //        //RuKuHeJi += Convert.ToDouble(ds.Tables[0].Rows[i]["iquantity"]);
        //    }
        //}
        //LabelChanZhi.Text = ChanZhi.ToString();
        //Label2.Text = HeJi.ToString();

        //GridView3.DataSource = dsDataSet;
        //GridView3.DataBind();


        Method();
    }

    private void Method()
    {
        org.in2bits.MyXls.XlsDocument doc = new org.in2bits.MyXls.XlsDocument();
        doc.FileName = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "") + ".xls";//excel文件名称
        org.in2bits.MyXls.Worksheet sheet = doc.Workbook.Worksheets.AddNamed("sheet1");//Excel工作表名称
        org.in2bits.MyXls.Cells cells = sheet.Cells;
        int colnum = GridView3.Columns.Count; //获取gridview列数
        for (int i = 0; i < colnum; i++)
        {
            cells.Add(1, (i + 1), this.GridView3.Columns[i].HeaderText);//导出gridView列名
        }
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            for (int j = 0; j < colnum; j++)
            {
                if (j == 1)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["工人编码"]);
                }
                else if (j == 2)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["工人姓名"]);
                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label")).Text.Trim());
                }
                else if (j == 3)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["生产订单号"]);

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label生产订单号")).Text.Trim());
                }
                else if (j == 4)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["行号"]);

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label行号")).Text.Trim());
                }

                else if (j == 5)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["产品编码"]);

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label产品编码")).Text.Trim());
                }
                else if (j == 6)
                {

                    try
                    {
                        cells.Add((i + 2), (j + 1), dataTable.Rows[i]["工序"]);
                    }
                    catch (Exception)
                    {
                        
                        //throw;
                    }
                   

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label工序")).Text.Trim());
                }
                else if (j == 7)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["数量"]);

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label数量")).Text.Trim());
                }
                else if (j == 8)
                {
                    try
                    {
                        cells.Add((i + 2), (j + 1), dataTable.Rows[i]["工时"]);
                    }
                    catch (Exception)
                    {
                        
                        //throw;
                    }
                    

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label工时")).Text.Trim());
                }


                else if (j == 9)
                {
                    try
                    {
                        cells.Add((i + 2), (j + 1), dataTable.Rows[i]["总工时"]);
                    }
                    catch (Exception)
                    {
                        
                        //throw;
                    }
                   

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label总工时")).Text.Trim());
                }
                else if (j == 10)
                {
                    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["录入日期"]);

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label录入日期")).Text.Trim());
                }
                else if (j == 11)
                {
                    try
                    {
                        cells.Add((i + 2), (j + 1), dataTable.Rows[i]["车间名称"]);
                    }
                    catch (Exception)
                    {
                        
                        //throw;
                    }
                    

                    //cells.Add((i + 2), (j + 1), ((Label)GridView3.Rows[i].FindControl("label车间名称")).Text.Trim());
                }
                else
                {
                //    cells.Add((i + 2), (j + 1), dataTable.Rows[i]["工人姓名"]);

                //cells.Add((i + 2), (j + 1), GridView3.Rows[i].Cells[j].Text.Trim());
                }

            }
        }
        //doc.Save(@"D:\");  //保存到指定位置
        doc.Send();//把写好的excel文件输出到客户端
    }

    protected void Button112_Click(object sender, EventArgs e)
    {
        string url = "GongShiReport.aspx?p1=" + txtStartDate.Text.Trim()+"&p2="+txtEndDate.Text.Trim()+"";
        Response.Write("<script language='javascript'>window.open('" + url + "');</script>");
    }
}