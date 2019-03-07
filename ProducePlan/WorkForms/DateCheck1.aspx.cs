using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_DateCheck1 : System.Web.UI.Page
{
    private string[] a = new string[] { "菲尔产成品库", "菲尔半成品库", "转序半成品库", "菲尔轨道风机事业部成品库", "菲尔轨道风机事业部半成品库", "菲尔离心风机事业部成品库", "菲尔离心风机事业部半成品库", "维修成品库", "技术部库" };
    private string[] b = new string[] { "产成品入库", "半成品入库", "返厂维修入库" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            this.GridView1.Attributes.Add("SortExpression", "天数");
            this.GridView1.Attributes.Add("SortDirection", "desc");

            //txtStartDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            //txtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd ");
            //BindFilter();
            Bind(true);

        }
    }

    protected void Bind(bool isFirstPage)
    {
        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];

        string sql =
            "SELECT  *                                                                              " +
            "FROM    ( SELECT    c.cCode 单据号 ,                                                   " +
            "                    c.dDate 日期 ,                                                     " +
            "                    c.cMemo 备注 ,  datediff(day,c.dDate,getdate()) as 天数      ,                                               " +
            "                    d.[cInvCode] 存货编码 ,                                            " +
            "                    inv.cInvName 存货名称 ,                                            " +
            "                    d.iQuantity 订单数量                                               " +
            "          FROM      [PU_ArrivalVouch] c                                                " +
            "                    LEFT JOIN [PU_ArrivalVouchs] d ON c.ID = d.ID                      " +
            "                    LEFT JOIN [Inventory] inv ON inv.[cInvCode] = d.[cInvCode]         " +
            "          WHERE     c.cCode NOT IN (                                                   " +
            "                    SELECT  a.cCode                                                    " +
            "                    FROM    [PU_ArrivalVouch] a                                        " +
            "                            INNER JOIN RdRecord b ON a.cCode = b.cARVCode              " +
            "                    WHERE   b.cBusType = '普通采购'                                    " +
            "                            AND b.dDate > '2017-3-1' )                                 " +
            "                    AND c.dDate > '2017-3-1'                                           " +
            "        ) AS bigTable                                                                  " +
            "                                                                                       ";


sql += " where 1=1 ";

sql += "  and  bigTable.天数>2 ";
                                                          

        if (!"".Equals(TextBox1.Text.Trim()))
        {
            sql += " and bigTable.单据号='" + TextBox1.Text.Trim() + "'";
        }
        //============================
        if (!"".Equals(txtStartDate.Text.Trim()))
        {
            sql += " and bigTable.日期>='" + txtStartDate.Text.Trim() + "'";
        }

        if (!"".Equals(txtEndDate.Text.Trim()))
        {
            sql += " and bigTable.日期<='" + txtEndDate.Text.Trim() + "'";
        }

        if (!"".Equals(txtStartDate.Text.Trim()) && !"".Equals(txtEndDate.Text.Trim()))
        {
            sql += " and bigTable.日期 >='" + txtStartDate.Text + "' and bigTable.日期 <='" + txtEndDate.Text + "' ";
        }
        //================================

        //sql += " order by bigTable.订单日期 desc";
        DataSet ds = SQLHelper.Query(sql);


        int curpage = Convert.ToInt32(this.labPage.Text);//获取当前页数

        PagedDataSource ps = new PagedDataSource();
       

        //================================启用排序
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            ds.Tables[0].DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }
        //DataView dv = new DataView(ds.Tables[0]);
        //if (ViewState["sortdirection"].ToString() == "ASC")
        //{
        //    dv.Sort = e.SortExpression + " DESC";
        //    ViewState["sortdirection"] = "DESC";
        //}
        //else
        //{
        //    dv.Sort = e.SortExpression + " ASC";
        //    ViewState["sortdirection"] = "ASC";
        //}
        ////===============================
        //ps.DataSource = dv;

        ps.DataSource = ds.Tables[0].DefaultView;
        //启用分页
        ps.AllowPaging = true;
        //设置每页为3条数据
        ps.PageSize = 30;
        //设置当前索引

        if (isFirstPage)
        {
            ps.CurrentPageIndex = 0;
            this.labPage.Text = "1";
            curpage = 1;
        }
        else
        {
            ps.CurrentPageIndex = curpage - 1;
        }

        //显示当前页面
        this.lnkbtnFront.Enabled = true;
        this.lnkbtnNext.Enabled = true;
        this.linkbtnLast.Enabled = true;
        this.lnkbtnFirst.Enabled = true;

        //第一页
        if (curpage == 1)
        {
            this.lnkbtnFirst.Enabled = false;//不显示第一页按钮
            this.lnkbtnFront.Enabled = false;//不显示上一页按钮
        }
        //最后一页
        if (curpage == ps.PageCount)
        {
            this.lnkbtnNext.Enabled = false;//不显示下一页按钮
            this.linkbtnLast.Enabled = false;//不显示最后一页
        }
        //总页数
        this.labBackPage.Text = Convert.ToString(ps.PageCount);
        //绑定数据源
        GridView1.DataSource = ps;
        GridView1.DataBind();

        //AspNetPager1.RecordCount = GridView1.Rows.Count;
        //ViewState["ds"] = GridView1.DataSource;
        //关闭数据源
        //con.Close();
    }
    protected void lnkbtnFirst_Click(object sender, EventArgs e)
    {
        labPage.Text = "1";
        Bind(false);
    }
    protected void lnkbtnFront_Click(object sender, EventArgs e)
    {
        labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) - 1);
        Bind(false);
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) + 1);
        Bind(false);
    }
    protected void linkbtnLast_Click(object sender, EventArgs e)
    {
        labPage.Text = this.labBackPage.Text;
        Bind(false);
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //GridViewRow row = (GridViewRow)(((WebControl)e.CommandSource).NamingContainer);

        //switch (e.CommandName)
        //{

        //    case "Modify":
        //        //string parValue = e.CommandArgument.ToString();

        //        string modid = ((HiddenField)row.FindControl("modid")).Value;
        //        string cInvCode = ((HiddenField)row.FindControl("cInvCode")).Value;
        //        string DropDownList5 = ((DropDownList)row.FindControl("DropDownList5")).SelectedValue;
        //        string dateTxtBox = ((TextBox)row.FindControl("dateTxtBox")).Text;

        //        List<String> SQLStringList = new List<string>();
        //        String sql = "";
        //        sql = "update mom_morder set DueDate='" + dateTxtBox + "' where modid='" + modid + "'";
        //        SQLStringList.Add(sql);
        //        sql = "update Inventory set [cinvdefine4]='" + DropDownList5 + "' where cInvCode='" + cInvCode + "'";
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
        //            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);

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
        Bind(true);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            //if (i == 6)
            //{

            //}
            HiddenField 分类编码 = e.Row.FindControl("分类编码") as HiddenField;
            HiddenField 计划到货日期 = e.Row.FindControl("计划到货日期") as HiddenField;
            
            //HiddenField MDeptCode = e.Row.FindControl("MDeptCode") as HiddenField;

            //HiddenField MoId = e.Row.FindControl("MoId") as HiddenField;
            //HiddenField SortSeq = e.Row.FindControl("SortSeq") as HiddenField;

            //HiddenField SoDId = e.Row.FindControl("SoDId") as HiddenField;
        }
        //    string sql =
        //        "select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
        //        "from mom_moallocate " +
        //        "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
        //        "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
        //        "left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
        //        "where mom_moallocate.modid=" + modid.Value + " order by mom_moallocate.whcode ";
        //    DataSet ds1 = SQLHelper.Query(sql);
        //    DataTable dt1 = ds1.Tables[0];


        //    if (dt1.Rows.Count == 0)
        //    {
        //        //first
        //        HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;
        //        la.Text = "无材料";

        //        //second
        //        HyperLink lingliao = e.Row.FindControl("HyperLink2") as HyperLink;
        //        lingliao.Text = "添加材料";
        //        //string url = "MomPop.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
        //        //lingliao.Target = "_blank";
        //        lingliao.ToolTip = "添加材料";
        //        lingliao.Attributes.Add("onclick",
        //                                "openwin('MomPop.aspx','MomPop','" + modid.Value + "','650','600','" +
        //                                MDeptCode.Value + "','" + e.Row.Cells[5].Text + "','" +
        //                                e.Row.Cells[4].Text + "','" +
        //                                e.Row.Cells[7].Text + "','" + MoId.Value + "','" + SoDId.Value + "' )");
        //        lingliao.NavigateUrl = "javascript:void(0)";

        //        //third
        //        HyperLink ruku = e.Row.FindControl("HyperLink3") as HyperLink;
        //        ruku.Text = "无材料";
        //    }
        //    else
        //    {


        //        for (int j = 0; j < dt1.Rows.Count; j++)
        //        {

        //            //Literal la = e.Row.FindControl("Literal1") as Literal;
        //            HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;
        //            la.Text = "否";
        //            if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) -
        //                System.Convert.ToDouble(dt1.Rows[j]["issqty"])
        //                > System.Convert.ToDouble(dt1.Rows[j]["xiancun"]))
        //            {

        //                la.Text = "是";
        //                //string url = "MomPop_Que.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
        //                //la.Target = "_blank";
        //                la.ToolTip = "显示缺料信息";
        //                //la.NavigateUrl = url;
        //                la.Attributes.Add("onclick",
        //                                  "openwin('MomPop_Que.aspx','MomPop_Que','" + modid.Value + "','650','600','" +
        //                                  MDeptCode.Value + "','" + e.Row.Cells[5].Text + "','" +
        //                                  e.Row.Cells[4].Text + "','" + e.Row.Cells[7].Text +
        //                                  "','" + MoId.Value + "','" + SoDId.Value + "'  )");
        //                la.NavigateUrl = "javascript:void(0)";
        //                break;
        //            }
        //        }


        //        bool b已经领完 = true;
        //        for (int j = 0; j < dt1.Rows.Count; j++)
        //        {
        //            HyperLink lingliao = e.Row.FindControl("HyperLink2") as HyperLink;
        //            lingliao.Text = "已经领完";

        //            if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) !=
        //                System.Convert.ToDouble(dt1.Rows[j]["issqty"])
        //                )
        //            {

        //                lingliao.Text = "领料";
        //                //string url = "MomPop.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
        //                //lingliao.Target = "_blank";
        //                lingliao.ToolTip = "开始领料";
        //                lingliao.Attributes.Add("onclick",
        //                                        "openwin('MomPop.aspx','MomPop','" + modid.Value + "','650','600','" +
        //                                        MDeptCode.Value + "','" + e.Row.Cells[5].Text + "','" +
        //                                        e.Row.Cells[4].Text + "','" +
        //                                        e.Row.Cells[7].Text + "','" + MoId.Value + "','" + SoDId.Value + "'  )");
        //                lingliao.NavigateUrl = "javascript:void(0)";
        //                b已经领完 = false;
        //                //lingliao.NavigateUrl = url;
        //                break;
        //            }
        //        }


        //        //if (d="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}" />
        //        //            <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" )

        //        HyperLink ruku = e.Row.FindControl("HyperLink3") as HyperLink;

        //        if (System.Convert.ToDouble(e.Row.Cells[7].Text) ==
        //            System.Convert.ToDouble(e.Row.Cells[8].Text))
        //        {
        //            ruku.Text = "已经入库完了";
        //        }
        //        else
        //        {
        //            if (b已经领完)
        //            {
        //                ruku.ToolTip = "开始入库";
        //                ruku.Attributes.Add("onclick",
        //                                    "openwin1('MomPop_Ruku.aspx','MomPop_Ruku','" + MDeptCode.Value +
        //                                    "','500','200','" + e.Row.Cells[1].Text + "','" +
        //                                    e.Row.Cells[2].Text + "','" + e.Row.Cells[3].Text +
        //                                    "','" + e.Row.Cells[4].Text + "','" +
        //                                    e.Row.Cells[5].Text + "'" +
        //                                    ",'" + e.Row.Cells[6].Text + "','" +
        //                                    e.Row.Cells[7].Text + "'" +
        //                                    ",'" + MoId.Value + "','" + SortSeq.Value + "'" +
        //                                    ",'" + modid.Value + "'" +
        //                                    ",'" + e.Row.Cells[8].Text + "'" +

        //                                    " )");
        //                ruku.NavigateUrl = "javascript:void(0)";
        //            }
        //            else
        //            {
        //                ruku.Text = "请先领料";
        //            }

        //        }
        //    }

        //    //sql =
        //    //    "select Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
        //    //    "from mom_orderdetail " +
        //    //    "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
        //    //    "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
        //    //    "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
        //    //    "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +
        //    //    "where mom_orderdetail.status<> 4";
        //    ////DataSet ds = SQLHelper.Query(sql);
        //    //DataTable dataTable = SQLHelper.Query(sql).Tables[0];

        //    //DataView dataView = dataTable.DefaultView;

        //    DropDownList DropDownList5 = e.Row.FindControl("DropDownList5") as DropDownList;
        //    HiddenField cinvdefine4 = e.Row.FindControl("cinvdefine4") as HiddenField;
        //    //DataTable dataTableDistinct4 = dataView.ToTable(true, "cinvdefine4"); //注
        //    //DataRow dr4 = dataTableDistinct4.NewRow();
        //    //dr4["cinvdefine4"] = "全部";
        //    //dataTableDistinct4.Rows.InsertAt(dr4, 0);
        //    DropDownList5.DataSource = ViewState["dataTableDistinct4"];
        //    DropDownList5.DataValueField = "cinvdefine4";
        //    DropDownList5.DataBind();

        //    DropDownList5.SelectedValue = cinvdefine4.Value;
        //}
    }

    protected void Button111_Click(object sender, EventArgs e)
    {

        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");
        str = str + ".xls";

        string sql =
              "SELECT  *                                                                              " +
              "FROM    ( SELECT    c.cCode 单据号 ,                                                   " +
              "                    c.dDate 日期 ,                                                     " +
              "                    c.cMemo 备注 ,  datediff(day,c.dDate,getdate()) as 天数      ,                                               " +
              "                    d.[cInvCode] 存货编码 ,                                            " +
              "                    inv.cInvName 存货名称 ,                                            " +
              "                    d.iQuantity 订单数量                                               " +
              "          FROM      [PU_ArrivalVouch] c                                                " +
              "                    LEFT JOIN [PU_ArrivalVouchs] d ON c.ID = d.ID                      " +
              "                    LEFT JOIN [Inventory] inv ON inv.[cInvCode] = d.[cInvCode]         " +
              "          WHERE     c.cCode NOT IN (                                                   " +
              "                    SELECT  a.cCode                                                    " +
              "                    FROM    [PU_ArrivalVouch] a                                        " +
              "                            INNER JOIN RdRecord b ON a.cCode = b.cARVCode              " +
              "                    WHERE   b.cBusType = '普通采购'                                    " +
              "                            AND b.dDate > '2017-3-1' )                                 " +
              "                    AND c.dDate > '2017-3-1'                                           " +
              "        ) AS bigTable                                                                  " +
              "                                                                                       ";


        sql += " where 1=1 ";

        sql += "  and  bigTable.天数>2 ";


        if (!"".Equals(TextBox1.Text.Trim()))
        {
            sql += " and bigTable.单据号='" + TextBox1.Text.Trim() + "'";
        }
        //============================
        if (!"".Equals(txtStartDate.Text.Trim()))
        {
            sql += " and bigTable.日期>='" + txtStartDate.Text.Trim() + "'";
        }

        if (!"".Equals(txtEndDate.Text.Trim()))
        {
            sql += " and bigTable.日期<='" + txtEndDate.Text.Trim() + "'";
        }

        if (!"".Equals(txtStartDate.Text.Trim()) && !"".Equals(txtEndDate.Text.Trim()))
        {
            sql += " and bigTable.日期 >='" + txtStartDate.Text + "' and bigTable.日期 <='" + txtEndDate.Text + "' ";
        }
        //================================

        //sql += " order by bigTable.订单日期 desc";

        DataSet ds = SQLHelper.Query(sql);

        GridView1.DataSource = ds;
        GridView1.DataBind();



        Method();
    }

    private void Method()
    {
        org.in2bits.MyXls.XlsDocument doc = new org.in2bits.MyXls.XlsDocument();
        doc.FileName = DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "") + ".xls";//excel文件名称
        org.in2bits.MyXls.Worksheet sheet = doc.Workbook.Worksheets.AddNamed("sheet1");//Excel工作表名称
        org.in2bits.MyXls.Cells cells = sheet.Cells;
        int colnum = GridView1.Columns.Count; //获取gridview列数
        for (int i = 0; i < colnum; i++)
        {
            cells.Add(1, (i + 1), this.GridView1.Columns[i].HeaderText);//导出gridView列名
        }
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < colnum; j++)
            {
                //if (j == 6)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("采购订单号")).Text.Trim());
                //}
                //else if (j == 7)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("订单日期")).Text.Trim());
                //}
                //else if (j == 8)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("销售订单号")).Text.Trim());
                //}
                //else if (j == 9)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("存货编码")).Text.Trim());
                //}

                //else if (j == 10)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("存货名称")).Text.Trim());
                //}
                //else if (j == 11)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("订单数量")).Text.Trim());
                //}
                //else if (j == 12)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("累计到货数量")).Text.Trim());
                //}
                //else if (j == 13)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("计划到货日期")).Text.Trim());
                //}


                 if (j == 7)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("tianshu")).Text.Trim());
                }
              
                else
                {
                    cells.Add((i + 2), (j + 1), GridView1.Rows[i].Cells[j].Text.Trim());
                }

            }
        }
        //doc.Save(@"D:\");  //保存到指定位置
        doc.Send();//把写好的excel文件输出到客户端
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind(false);
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

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

        this.Bind(true);

    }
}