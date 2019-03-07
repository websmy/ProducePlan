using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_工时录入 : System.Web.UI.Page
{
    private DataSet _dsBind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //_dsBind = SQLHelper1.Query("select  * from 工时录入 ");
            //BindData3();
            //_dsBind = new DataSet();
            //string sql = "";
            //if (String.IsNullOrEmpty(cInvcode))
            //{
            //    sql = "select  * from 工时录入";
            //}
            //else
            //{
            //    sql = "select  * from 工时录入 where 产品编码='" + cInvcode + "'";
            //}


        }
    }

    private bool CheckData()
    {
        
        bool ret = false;

        bool b工人编码 = false;
        //bool b产品编码 = false;
        if (!string.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            string txt = TextBox1.Text.Trim();
            DataTable dt1 = SQLHelper1.Query("select 工人姓名 from [workhours_manage_worker] where [工人编码]='" + txt + "'").Tables[0];
            if (dt1.Rows.Count != 0)
            {
                b工人编码 = true;
                //val = dt1.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show(this, "此工人编编码不存在！");
                
            }
        }

        //if (!string.IsNullOrEmpty(TextBox2.Text.Trim()))
        //{
        //    string txt = TextBox2.Text.Trim();
        //    DataTable dt1 = SQLHelper.Query("select cInvName from [Inventory] where [cInvCode]='" + txt + "'").Tables[0];
        //    if (dt1.Rows.Count != 0)
        //    {
        //        b产品编码 = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show(this, "此产品编码不存在！");
        //    }
        //}

        if (b工人编码)
        {



            string sql =
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
            sql += " and 1=1 ";

            sql += " and mocode='" + TextBox4.Text.Trim() + "'";
            sql += " and sortseq='" + TextBox3.Text.Trim() + "'";
            //sql += " and InvCode='" + TextBox2.Text.Trim() + "'";

            DataSet ds = SQLHelper.Query(sql);

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 1)
            {
                hModid.Value = dt.Rows[0]["modid"].ToString();
                hQty.Value = dt.Rows[0]["Qty"].ToString();
                hCinvCode.Value = dt.Rows[0]["InvCode"].ToString();
                
                ret = true;
            }
            else
            {
                hModid.Value = "";
                hQty.Value = "";
                hCinvCode.Value = "";
                Label2.Text = "";
                MessageBox.Show(this, "数据输入错误！请重新输入。");
                //ret = false;
            }
        }
        return ret;
    }

    public void BindData3()
    {
        if (CheckData())
        {
            _dsBind = new DataSet();

            string sql = "";
            sql += "select  b.autoid,*, a.工时*b.数量 as 总工时,CONVERT(varchar(100), b.ddate, 23) as 录入日期 from 工时录入 b  left join  [workhours_manage] a  on a.产品编码=b.产品编码  and b.工序autoid=a.autoid where 1=1 ";
            if (!String.IsNullOrEmpty(TextBox1.Text.Trim()))
            {
                sql += " and b.工人编码='" + TextBox1.Text.Trim() + "'";
            }

            //if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
            //{
            //    sql += " and 产品编码 like '%" + TextBox2.Text.Trim()+ "%'";
            //}
            //if (!String.IsNullOrEmpty(TextBox2.Text.Trim()))
            //{
            sql += " and b.生产订单号='" + TextBox4.Text.Trim() + "'";
            //}
            if (!String.IsNullOrEmpty(TextBox3.Text.Trim()))
            {
                sql += " and b.行号='" + TextBox3.Text.Trim() + "'";
            }

            //if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
            //{
            //    _dsBind = SQLHelper1.Query("select  * from 工时录入");
            //}
            //else
            //{
            //    _dsBind = SQLHelper1.Query("select  * from 工时录入 where 产品编码='" + TextBox1.Text.Trim().Trim() + "'");
            //}

            _dsBind = SQLHelper1.Query(sql);
            GridView3.DataSource = _dsBind;
            GridView3.DataBind();
           
        }

    }

    public static void renderEmptyGridView(GridView EmptyGridView, string FieldNames)
    {
        //将GridView变成只有Header和Footer列，以及被隐藏的空白资料列     
        DataTable dTable = new DataTable();
        char[] delimiterChars = { ',' };
        string[] colName = FieldNames.Split(delimiterChars);
        foreach (string myCol in colName)
        {
            DataColumn dColumn = new DataColumn(myCol.Trim());
            dTable.Columns.Add(dColumn);
        }
        DataRow dRow = dTable.NewRow();
        foreach (string myCol in colName)
        {
            dRow[myCol.Trim()] = DBNull.Value;
        }
        dTable.Rows.Add(dRow);
        //EmptyGridView.ShowFooter = false;
        EmptyGridView.DataSourceID = null;
        EmptyGridView.DataSource = dTable;
        EmptyGridView.DataBind();
        EmptyGridView.Rows[0].Visible = false;
       
    }

    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //string 工时录入 = "";
        //string 产品编码 = "";
        string 工序 = "";
        string 数量 = "";
        string h数量 = "";
        decimal d数量 = 0;
        //string 板材编码 = "";
        //string 下料尺寸 = "";
        //string 板厚 = "";
        //string 材质 = "";
        //string 设备 = "";
        //string 加工说明 = "";
        GridViewRow _row = GridView3.Rows[e.RowIndex];

        //产品编码 = (_row.FindControl("txt产品编码") as TextBox).Text.Trim();
        工序 = (_row.FindControl("ddl工序") as DropDownList).SelectedValue.Trim();
        数量 = (_row.FindControl("txt数量") as TextBox).Text.Trim();
        h数量 = (_row.FindControl("h数量") as HiddenField).Value;
        
        //工序 = (_row.FindControl("txt工序") as TextBox).Text.Trim();
        //工时 = (_row.FindControl("txt工时") as TextBox).Text.Trim();
        //板材编码 = (_row.FindControl("txt板材编码") as TextBox).Text.Trim();
        //下料尺寸 = (_row.FindControl("txt下料尺寸") as TextBox).Text.Trim();
        //板厚 = (_row.FindControl("txt板厚") as TextBox).Text.Trim();
        //材质 = (_row.FindControl("txt材质") as TextBox).Text.Trim();
        //设备 = (_row.FindControl("txt设备") as TextBox).Text.Trim();
        //加工说明 = (_row.FindControl("txt加工说明") as TextBox).Text.Trim();


        Label autoid = (Label)_row.FindControl("autoid");

        string sql =
            "update  [工时录入] set 工序autoid='" + 工序 + "', 数量='" + 数量 + "' " +
            //",工时='" + 工时 + "'" +
            //",板材编码='" + 板材编码 + "'" +
            //",下料尺寸='" + 下料尺寸 + "'" +
            //",板厚='" + 板厚 + "'" +
            //",材质='" + 材质 + "'" +
            //",设备='" + 设备 + "'" +
            //",加工说明='" + 加工说明 + "'" +

            " where autoid=" + autoid.Text.Trim();


        decimal dCnt = 0;
        try
        {
            dCnt = Convert.ToDecimal(SQLHelper1.Query("select sum(数量) from 工时录入 where 工序autoid='" + 工序 + "' ").Tables[0].Rows[0][0]);
            d数量 = Convert.ToDecimal(h数量);
        }
        catch (Exception)
        {
            dCnt = 0;
            d数量 = 0;
        }

        if (dCnt - d数量 + (Convert.ToDecimal(数量)) > Convert.ToDecimal(hQty.Value))
        {
            MessageBox.Show(this, "输入的数量超出订单数量！");
        }
        else
        {
            SQLHelper1.ExecuteSql(sql);
            GridView3.EditIndex = -1;
            BindData3();
        }

     
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
        string 数量 = "";
        string 工序 = "";
        if (e.CommandName == "Add" && CheckData())
        {
            string 工时录入 = "";
           

            if (GridView3.Rows.Count > 0)
            {

                string 产品编码 = "";
                
               
                //string 板材编码 = "";
                //string 下料尺寸 = "";
                //string 板厚 = "";
                //string 材质 = "";
                //string 设备 = "";
                //string 加工说明 = "";


                //int maxid = SQLHelper1.GetMaxID("val", "工时录入");
                //产品编码 = (GridView3.FooterRow.FindControl("txt产品编码F") as TextBox).Text.Trim();
                工序 = (GridView3.FooterRow.FindControl("ddl工序F") as DropDownList).SelectedValue.Trim();
                数量 = (GridView3.FooterRow.FindControl("txt数量F") as TextBox).Text.Trim();
                //板材编码 = (GridView3.FooterRow.FindControl("txt板材编码F") as TextBox).Text.Trim();
                //下料尺寸 = (GridView3.FooterRow.FindControl("txt下料尺寸F") as TextBox).Text.Trim();
                //板厚 = (GridView3.FooterRow.FindControl("txt板厚F") as TextBox).Text.Trim();
                //材质 = (GridView3.FooterRow.FindControl("txt材质F") as TextBox).Text.Trim();
                //设备 = (GridView3.FooterRow.FindControl("txt设备F") as TextBox).Text.Trim();
                //加工说明 = (GridView3.FooterRow.FindControl("txt加工说明F") as TextBox).Text.Trim();

              

                strsql = " INSERT INTO [工时录入]" +
                         " ([工人编码]          " +
                         " ,[生产订单号]          " +
                         " ,[产品编码]          " +
                    " ,[行号]          " +
                    " ,[工序autoid]          " +
                    " ,[数量]                 " +
                    " ,[ddate]                 " +
                    //" ,[设备]                 " +
                         ")         " +
                         "     VALUES          " +
                         "      ('" + TextBox1.Text.Trim()+ "'     " +
                         " ,'" + TextBox4.Text.Trim() + "'          " +
                         " ,'" + hCinvCode.Value.Trim() + "'          " +
                         " ,'" + TextBox3.Text.Trim() + "'          " +
                    " ,'" + 工序 + "'          " +
                    " ,'" + 数量 + "'          " +
                    " ,'" + DateTime.Now.ToString("yyyy-MM-dd") + "'                 " +
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
            decimal dCnt = 0;
            try
            {
                dCnt = Convert.ToDecimal(SQLHelper1.Query("select sum(数量) from 工时录入 where 工序autoid='" + 工序 + "'  and 生产订单号='" + TextBox4.Text.Trim() + "'  and 行号='" + TextBox3.Text.Trim() + "'  ").Tables[0].Rows[0][0]);

            }
            catch (Exception)
            {
                dCnt = 0;
                
            }
 
            if ((Convert.ToDecimal(数量) + dCnt) > Convert.ToDecimal(hQty.Value))
            {
                MessageBox.Show(this, "输入的数量超出订单数量！");
            }
            else
            {
                SQLHelper1.ExecuteSql(strsql);
                BindData3();
            }
           
          
            //BindData();

        }
    }


    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        if (GridView3.Rows.Count == 0)
        {
            renderEmptyGridView(GridView3, " autoid,工序,数量,工时,总工时,工序autoid,录入日期");
        }
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
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList ddl工序F = (DropDownList)e.Row.FindControl("ddl工序F");
            //dropTemp = (DropDownList) e.Row.FindControl("DropDownList19");
            if (ddl工序F != null)
            {

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("请选择", "请选择");

                DataTable dt =
                    SQLHelper1.Query("select  autoid,工序 from [workhours_manage] where 产品编码='" + hCinvCode.Value.Trim() + "'").
                        Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string temp0 = dt.Rows[i][0].ToString();
                    string temp1 = dt.Rows[i][1].ToString();
;                    dic.Add(temp0,temp1);
                }     

                ddl工序F.DataSource = dic;
                ddl工序F.DataTextField = "Value";
                ddl工序F.DataValueField = "Key";
                ddl工序F.DataBind();
            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                //Label label产品编码 = (Label)e.Row.FindControl("label工序");
                //((LinkButton)e.Row.Cells[5].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + label产品编码.Text.Trim() + "\"吗?')");
            }
        }
            if (e.Row.RowType == DataControlRowType.DataRow)
        {
           if (e.Row.RowState == DataControlRowState.Edit || ((int)(e.Row.RowState & DataControlRowState.Edit)) != 0)
            {
            
                DropDownList ddl工序 = (DropDownList)e.Row.FindControl("ddl工序");
                Label 工序autoid = (Label)e.Row.FindControl("工序autoid");
                
                //dropTemp = (DropDownList) e.Row.FindControl("DropDownList19");
                if (ddl工序 != null)
                {

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //dic.Add("请选择", "请选择");

                    DataTable dt =
                        SQLHelper1.Query("select  autoid,工序 from [workhours_manage] where 产品编码='" + hCinvCode.Value.Trim() + "'").
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
        GridView3.ShowFooter = true;
        BindData3();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        hQty.Value = "0";
        hCinvCode.Value = "";
        renderEmptyGridView(GridView3, " autoid,工序,数量,工时,总工时,工序autoid,录入日期");
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

       
        //h工人编码.Value = TextBox1.Text.Trim();

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        //TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        Label1.Text = "";
        Label2.Text = "";

        hModid.Value = "";
        hQty.Value = "0";
        hCinvCode.Value = "";
        renderEmptyGridView(GridView3, " autoid,工序,数量,工时,总工时,工序autoid,录入日期");

        //int r = GridView3.Rows.Count;
        //ddl工序F.DataSource = "";
            

    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        hQty.Value = "0";
        hCinvCode.Value = "";
        renderEmptyGridView(GridView3, " autoid,工序,数量,工时,总工时,工序autoid,录入日期");

        if (!String.IsNullOrEmpty(TextBox4.Text))
        {
            TextBox4.Text = (System.Convert.ToInt32(TextBox4.Text)).ToString().PadLeft(10, '0');
        }

      
    }
    protected void  TextBox3_TextChanged(object sender, EventArgs e)
{
     hQty.Value = "0";
     hCinvCode.Value = "";

     renderEmptyGridView(GridView3, " autoid,工序,数量,工时,总工时,工序autoid,录入日期");
    string val = "";
    string sql =
          "SELECT   "
          +
          " a.InvCode"
          + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
          + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
          + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
          + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
          + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID  "
          + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "
          + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 ";
    sql += " and 1=1 ";

    sql += " and mocode='" + TextBox4.Text.Trim() + "'";
    sql += " and sortseq='" + TextBox3.Text.Trim() + "'";
    //sql += " and mocode='" + TextBox2.Text.Trim() + "'";
    DataTable dataTable = SQLHelper.Query(sql).Tables[0];
        if (dataTable.Rows.Count==1)
        {
            string txtCode = dataTable.Rows[0][0].ToString();
           
            if (!string.IsNullOrEmpty(txtCode))
            {
                string txt = txtCode.Trim();
                DataTable dt = SQLHelper.Query("select cInvName from [inventory] where [cInvCode]='" + txt + "'").Tables[0];
                if (dt.Rows.Count ==1)
                {
                    val = dt.Rows[0][0].ToString();
                    hCinvCode.Value = txt;
                }
                else
                {
                    MessageBox.Show(this, "此产品编码不存在！");
                }
            }
            Label2.Text = val;
           
        }
        else
        {
            Label2.Text = "";
            MessageBox.Show(this, "数据有错误！");
        }



    //h产品编码.Value = TextBox2.Text.Trim();

    }
}

