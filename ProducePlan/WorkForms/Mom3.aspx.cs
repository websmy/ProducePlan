using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_Mom3 : System.Web.UI.Page
{

    private string 客户编码 = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            客户编码 = Request.QueryString["id"];
            ViewState["客户编码"] = 客户编码;
            //BindFilter();

            this.GridView1.Attributes.Add("SortExpression", "开票日期");
            this.GridView1.Attributes.Add("SortDirection", "ASC");

            Bind();

            //SQLHelper1.ExecuteSql("delete from SetColor where cSOCode='" + mocode + "' ");

        }
    }

    protected void Bind()
    {


        // 获取GridView排序数据列及排序方向 
        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];

        string sql =
          "SELECT * from 销售发票  where [客户编码]='" + ViewState["客户编码"] + "' ";

        DataSet ds = SQLHelper1.Query(sql);     

        // 调用业务数据获取方法 
        //DataTable dtBind = this.getDB();

        // 根据GridView排序数据列及排序方向设置显示的默认数据视图 
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            ds.Tables[0].DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }

        // GridView绑定并显示数据 
        this.GridView1.DataSource = ds.Tables[0];
        this.GridView1.DataBind();

    }

   

  

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //GridViewRow row = (GridViewRow) (((WebControl) e.CommandSource).NamingContainer);

        //switch (e.CommandName)
        //{

        //    case "Modify":
        //        //string parValue = e.CommandArgument.ToString();

        //        string modid = ((HiddenField) row.FindControl("modid")).Value;
        //        string cInvCode = ((HiddenField) row.FindControl("cInvCode")).Value;


        //        //LoginView loginView1 = ((LoginView)row.FindControl("LoginView1"));
        //        string DropDownList5 = ((DropDownList) row.FindControl("DropDownList5")).SelectedValue;

        //        //LoginView loginView2 = ((LoginView)row.FindControl("LoginView2"));
        //        string dateTxtBox = ((TextBox) row.FindControl("dateTxtBox")).Text;

        //        //LoginView loginView3 = ((LoginView)row.FindControl("LoginView3"));
        //        string txt逾期原因 = ((DropDownList) row.FindControl("txt逾期原因")).Text;
        //        string txt逾期原因详细 = ((TextBox) row.FindControl("txt逾期原因详细")).Text;
        //        List<String> SQLStringList = new List<string>();
        //        String sql = "";
        //        sql = "update mom_morder set DueDate='" + dateTxtBox + "' where modid='" + modid + "'";
        //        SQLStringList.Add(sql);
        //        sql = "update Inventory set [cinvdefine4]='" + DropDownList5 + "' where cInvCode='" + cInvCode + "'";
        //        SQLStringList.Add(sql);

        //        sql = "update mom_orderdetail set define25='" + txt逾期原因 + "," + txt逾期原因详细 + "' where modid='" + modid +
        //              "'";
        //        SQLStringList.Add(sql);

        //        if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
        //        {
        //            //Response.Write("<script>alert('生成报表失败');</script>");

        //            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);
        //            //MessageBox.Show(this, "更新数据失败");
        //            //Response.Write();
        //            //return;
        //        }
        //        else
        //        {
        //            //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);

        //            //MessageBox.Show(this, "成功更新数据");
        //            //return;
        //        }
        //        //Response.Write("<script>alert('删除成功!')</script>");
        //        //return;
        //        //if ("".Equals(strText))
        //        //{
        //        //DataSet ds = SQLHelper.Query("select mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty,CurrentStock.iQuantity - CurrentStock.fOutQuantity xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling from mom_moallocate left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid left join inventory on mom_moallocate.invcode = inventory.cinvcode left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode where mom_moallocate.modid=" + parValue);
        //        //}
        //        //else
        //        //{
        //        //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + parValue + "'");
        //        //}

        //        //this.HiddenField1.Value = row.Cells[0].Text;
        //        //this.HiddenField2.Value = row.Cells[4].Text;
        //        //this.HiddenField3.Value = row.Cells[3].Text;
        //        //this.HiddenField4.Value = row.Cells[6].Text;
        //        //DataTable dt = ds.Tables[0];
        //        //dt.Columns.Add("rowNum");
        //        //for (int i = 0; i < dt.Rows.Count; i++)
        //        //{
        //        //    dt.Rows[i]["rowNum"] = i;
        //        //}

        //        //GridView2.DataSource = dt;
        //        //GridView2.DataBind();

        //        //ViewState["dt"] = dt;

        //        //this.mpeFirstDialogBox.Show();

        //        break;


        //    default:

        //        break;
        //}

    }


    //protected void BindDel()
    //{



    //    //string sql =
    //    //   "select mom_orderdetail.moid,mom_orderdetail.SortSeq,Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate from " +
    //    //   " mom_orderdetail " +
    //    //   "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
    //    //   "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
    //    //   "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
    //    //   "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode]" +


    //    //   " where mom_orderdetail.status<> 4";


    //    //string sql =
    //    //    "select a.moid,a.SortSeq,Department.[cDepName] ,a.modid,a.MDeptCode,inventory.cinvdefine4,a.SoCode,mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty,a.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate, " +
    //    //    "是否缺料=" +
    //    //    "(select case when ( " +
    //    //    "select count(*) from mom_moallocate left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid left join inventory on mom_moallocate.invcode = inventory.cinvcode left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
    //    //    "where mom_moallocate.modid=a.modid " +
    //    //    "and mom_moallocate.qty-mom_moallocate.issqty> isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0)" +
    //    //    ")>0 then '是' else '否' end ) " +

    //    //    "from mom_orderdetail a " +
    //    //    "left join mom_order on a.moid=mom_order.moid left join mom_morder on a.modid=mom_morder.modid left join inventory on a.InvCode=inventory.cInvCode " +
    //    //    "left join [Department] on a.MDeptCode=[Department].[cDepCode] where a.status<> 4";

    //    string sql = "select * from aViewName where 1=1 ";
    //    sql += " and 1=1 ";

    //    //if (!"全部".Equals(DropDownList3.SelectedValue))
    //    //{
    //    //    sql += " and Department.[cDepName]='" + DropDownList3.SelectedValue + "'";
    //    //}
    //    //if (!"全部".Equals(DropDownList4.SelectedValue))
    //    //{
    //    //    if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
    //    //    {
    //    //        sql += " and inventory.cinvdefine4 is null ";
    //    //    }
    //    //    else
    //    //    {
    //    //        sql += " and inventory.cinvdefine4='" + DropDownList4.SelectedValue + "'";
    //    //    }

    //    //}
    //    //if (!"".Equals(TextBox1.Text))
    //    //{
    //    //    if (string.IsNullOrEmpty(TextBox1.Text))
    //    //    {
    //    //        //sql += " and mom_orderdetail.SoCode is null ";
    //    //        //sql += " and mom_orderdetail.SoCode is null ";
    //    //    }
    //    //    else
    //    //    {
    //    //        sql += " and mom_orderdetail.SoCode='" + TextBox1.Text.Trim() + "'";
    //    //    }
    //    //}


    //    if (!"全部".Equals(DropDownList3.SelectedValue))
    //    {
    //        sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
    //    }
    //    if (!"全部".Equals(DropDownList4.SelectedValue))
    //    {
    //        if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
    //        {
    //            sql += " and cinvdefine4 is null ";
    //        }
    //        else
    //        {
    //            sql += " and cinvdefine4='" + DropDownList4.SelectedValue + "'";
    //        }

    //    }
    //    if (!"".Equals(TextBox1.Text))
    //    {
    //        if (string.IsNullOrEmpty(TextBox1.Text))
    //        {
    //            //sql += " and mom_orderdetail.SoCode is null ";
    //            //sql += " and mom_orderdetail.SoCode is null ";
    //        }
    //        else
    //        {
    //            sql += " and SoCode='" + TextBox1.Text.Trim() + "'";
    //        }
    //    }


    //    if (!"全部".Equals(DropDownList6.SelectedValue))
    //    {
    //        if ("是".Equals(DropDownList6.SelectedValue))
    //        {
    //            sql += " and 是否缺料 ='是'";
    //        }
    //        else
    //        {
    //            sql += " and 是否缺料 ='否'";
    //        }
    //    }
    //    sql += " order by modid ";

    //    DataSet ds = SQLHelper.Query(sql);
    //    //DataTable dt = ds.Tables[0];

    //    //dt.Columns.Add("是否缺料");

    //    //for (int i = 0; i < dt.Rows.Count; i++)
    //    //{
    //    //    DataSet ds1 = SQLHelper.Query("select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling from mom_moallocate left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid left join inventory on mom_moallocate.invcode = inventory.cinvcode left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode where mom_moallocate.modid=" + dt.Rows[i]["modid"] + " order by mom_moallocate.whcode");
    //    //    DataTable dt1 = ds1.Tables[0];

    //    //    for (int j = 0; j < dt1.Rows.Count; j++)
    //    //    {
    //    //        dt.Rows[i]["是否缺料"] = "否";
    //    //        if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) -
    //    //            System.Convert.ToDouble(dt1.Rows[j]["issqty"])
    //    //            > System.Convert.ToDouble(dt1.Rows[j]["xiancun"]))
    //    //        {
    //    //            dt.Rows[i]["是否缺料"] = "是";
    //    //            break;
    //    //        }
    //    //    }

    //    //    if (!"全部".Equals(DropDownList6.SelectedValue))
    //    //    {
    //    //        if (!dt.Rows[i]["是否缺料"].Equals(DropDownList6.SelectedValue))
    //    //        {
    //    //            dt.Rows[i].Delete();
    //    //        }
    //    //    }
    //    //}


    //    //dt.Columns.Add("是否缺料");
    //    //for (int i = 0; i < dt.Rows.Count; i++)
    //    //{
    //    //    dt.Rows[i]["是否缺料"] = "否";
    //    //    DataSet ds1 = SQLHelper.Query("select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling from mom_moallocate left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid left join inventory on mom_moallocate.invcode = inventory.cinvcode left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode where mom_moallocate.modid=" + dt.Rows[i]["modid"] + " order by mom_moallocate.whcode");
    //    //    DataTable dt1 = ds1.Tables[0];

    //    //    for (int j = 0; j < dt1.Rows.Count; j++)
    //    //    {
    //    //       if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) - 
    //    //           System.Convert.ToDouble(dt1.Rows[j]["issqty"])
    //    //           > System.Convert.ToDouble(dt1.Rows[j]["xiancun"]))
    //    //        {
    //    //           dt.Rows[i]["是否缺料"] = "是";
    //    //           break;
    //    //        }
    //    //    }           
    //    //}

    //    GridView1.PageSize = Convert.ToInt32(XMLHelper.PageSize);


    //    //int curpage = Convert.ToInt32(this.labPage.Text);//获取当前页数
    //    ////连接数据源
    //    ////SqlConnection con = new SqlConnection(Connection.connection());//调用函数获取连接字符串
    //    ////con.Open();
    //    ////SqlDataAdapter sda = new SqlDataAdapter("select * from student", con);
    //    //////DataSet ds = new DataSet();
    //    ////sda.Fill(ds, "student");
    //    ////生成PageDataSource对象
    //    //PagedDataSource ps = new PagedDataSource();
    //    //ps.DataSource = ds.Tables[0].DefaultView;

    //    ////启用分页
    //    //ps.AllowPaging = true;
    //    ////设置每页为3条数据
    //    //ps.PageSize = 3;
    //    ////设置当前索引
    //    //ps.CurrentPageIndex = curpage - 1;
    //    ////显示当前页面
    //    //this.lnkbtnFront.Enabled = true;
    //    //this.lnkbtnNext.Enabled = true;
    //    //this.linkbtnLast.Enabled = true;
    //    //this.lnkbtnFirst.Enabled = true;

    //    ////第一页
    //    //if (curpage == 1)
    //    //{
    //    //    this.lnkbtnFirst.Enabled = false;//不显示第一页按钮
    //    //    this.lnkbtnFront.Enabled = false;//不显示上一页按钮
    //    //}
    //    ////最后一页
    //    //if (curpage == ps.PageCount)
    //    //{
    //    //    this.lnkbtnNext.Enabled = false;//不显示下一页按钮
    //    //    this.linkbtnLast.Enabled = false;//不显示最后一页
    //    //}
    //    ////总页数
    //    //this.labBackPage.Text = Convert.ToString(ps.PageCount);
    //    ////绑定数据源
    //    /// 

    //    ViewState["ds"] = ds;
    //    GridView1.DataSource = ds;
    //    GridView1.DataBind();



    //    GridViewRow pagerRow1 = GridView1.BottomPagerRow;
    //    Label la = pagerRow1.FindControl("Label1") as Label;
    //    la.Text = ds.Tables[0].Rows.Count.ToString();

    //    DropDownList downList = pagerRow1.FindControl("DropDownList2") as DropDownList;
    //    downList.SelectedValue = GridView1.PageSize.ToString();

    //    //关闭数据源
    //    //con.Close();
    //}


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //// 得到该控件
        //GridView theGrid = sender as GridView;
        //int newPageIndex = 0;
        //if (e.NewPageIndex == -3)
        //{
        //    //点击了Go按钮
        //    TextBox txtNewPageIndex = null;

        //    //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
        //    GridViewRow pagerRow = theGrid.BottomPagerRow;

        //    if (pagerRow != null)
        //    {
        //        //得到text控件
        //        txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
        //    }
        //    if (txtNewPageIndex != null)
        //    {
        //        //得到索引
        //        newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
        //    }
        //}
        //else
        //{
        //    //点击了其他的按钮
        //    newPageIndex = e.NewPageIndex;
        //}
        ////防止新索引溢出
        //newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        //newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

        ////得到新的值
        //theGrid.PageIndex = newPageIndex;

        ////重新绑定
        ////bingDesignatioonName();

        //Bind();
        ////gvProject.PageIndex = e.NewPageIndex;
        ////this.BindProjectList();
        //GridView theGrid = sender as GridView; // refer to the GridView
        //int newPageIndex = 0;
        //if (-2 == e.NewPageIndex)
        //{ // when click the "GO" Button
        //    TextBox txtNewPageIndex = null;
        //    //GridViewRow pagerRow = theGrid.Controls[0].Controls[theGrid.Controls[0].Controls.Count - 1] as GridViewRow; // refer to PagerTemplate
        //    GridViewRow pagerRow = theGrid.BottomPagerRow; //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
        //    //updated at 2006年月日:15:33
        //    if (null != pagerRow)
        //    {
        //        txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;   // refer to the TextBox with the NewPageIndex value
        //    }
        //    if (null != txtNewPageIndex)
        //    {
        //        newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
        //    }
        //}
        //else
        //{ // when click the first, last, previous and next Button
        //    newPageIndex = e.NewPageIndex;
        //}
        //// check to prevent form the NewPageIndex out of the range
        //newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        //newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        //// specify the NewPageIndex
        //theGrid.PageIndex = newPageIndex;
        //// rebind the control
        //// in this case of retrieving the data using the xxxDataSoucr control,
        //// just do nothing, because the asp.net
        //this.BindProjectList();//数据绑定的方法
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList dropDownList = sender as DropDownList;
        ////GridView1.PageSize = Convert.ToInt32(dropDownList.SelectedValue);
        //XMLHelper.PageSize = dropDownList.SelectedValue;
        //Bind();
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
        //DataTable dt = (DataTable)ViewState["dt"] ;
        //DataSet ds = (DataSet)ViewState["ds"];
        //DataTable dt = new DataTable();
        //if (ds == null)
        //{

        //}
        //else
        //{
        //    dt = ds.Tables[0];
        //}




        for (int i = 0; i < GridView1.Rows.Count; i++)
        {





        }

        //GridView1.DataSource = dt;
        //GridView1.DataBind();
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        //GridView1.DataSource = null;
        

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        MessageBox.Show(this,"未实现");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                string label发票号 = ((HiddenField)e.Row.FindControl("发票号")).Value;
                ((LinkButton)e.Row.Cells[12].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + label发票号 + "\"吗?')");
            }
        }

             









        if (e.Row.RowIndex > -1)
        {



            
        }
    }
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
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
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        { newPageIndex = e.NewPageIndex; }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        Bind();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列 
        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序” 
        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改 
        if (sortExpression == this.GridView1.Attributes["SortExpression"])
        {
            //获得下一次的排序状态 
            sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }

        // 重新设定GridView排序数据列及排序方向 
        this.GridView1.Attributes["SortExpression"] = sortExpression;
        this.GridView1.Attributes["SortDirection"] = sortDirection;

        this.Bind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //string xialiao = "";
        string 发票金额 = "";
        string 核销金额 = "";
        string 未核销金额 = "";

        string 质保金金额 = "";
        string 质保金核销 = "";
        string 质保金未核销 = "";
        //string 板材编码 = "";
        //string 下料尺寸 = "";
        //string 板厚 = "";
        //string 材质 = "";
        //string 设备 = "";
        //string 加工说明 = "";
        GridViewRow _row = GridView1.Rows[e.RowIndex];

        发票金额 = (_row.FindControl("txt发票金额") as TextBox).Text;
        核销金额 = (_row.FindControl("txt核销金额") as TextBox).Text;
        未核销金额 = (_row.FindControl("txt未核销金额") as TextBox).Text;

        质保金金额 = (_row.FindControl("txt质保金金额") as TextBox).Text;
        质保金核销 = (_row.FindControl("txt质保金核销") as TextBox).Text;
        质保金未核销 = (_row.FindControl("txt质保金未核销") as TextBox).Text;

        //板材编码 = (_row.FindControl("txt板材编码") as TextBox).Text;
        //下料尺寸 = (_row.FindControl("txt下料尺寸") as TextBox).Text;
        //板厚 = (_row.FindControl("txt板厚") as TextBox).Text;
        //材质 = (_row.FindControl("txt材质") as TextBox).Text;
        //设备 = (_row.FindControl("txt设备") as TextBox).Text;
        //加工说明 = (_row.FindControl("txt加工说明") as TextBox).Text;


        string  autoid = ((HiddenField)_row.FindControl("autoid")).Value;

        string sql =
            "update  [销售发票] set 发票金额=" + 发票金额 + ", 核销金额=" + 核销金额 + " " +
            ",未核销金额=" + 未核销金额 +
            ",质保金金额=" + 质保金金额 +
            ",质保金核销=" + 质保金核销 +
            ",质保金未核销=" + 质保金未核销 + 

            " where autoid=" + autoid;

        SQLHelper1.ExecuteSql(sql);
        GridView1.EditIndex = -1;
        Bind();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
}