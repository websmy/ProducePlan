using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;


public partial class WorkForms_billQuerySaleDept : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            txtStartDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            BindFilter();

            Bind(true);

            //Bind();
        }
    }

    private void BindFilter()
    {

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration//DataBaseName").InnerText.Trim();


        string sql =

          "    select Customer.[cCusName],a.客户编码,a.部门,a.业务员,(isnull(a.ahe,0)- isnull(b.bhe,0)) 应收款 from                                           " +
          "   (select [客户编码],部门,业务员,(SUM(未核销金额)+sum(质保金未核销)) as ahe  from [销售发票]  where  销售发票.部门!='采购部' and 销售发票.客户编码!='' and 销售发票.部门!=''  group by 客户编码,部门,业务员)a          " +
          "   left join                                                                                                                                                         " +
          "   (select 客户编码,SUM(未核销金额) as bhe  from 收款单表  group by 客户编码) b                                               " +
          "   on a.客户编码=b.客户编码  " +
        "     left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn + "')." + vDataBaseName +
          "   .dbo.[Customer] as Customer  on  Customer.[cCusCode]= a.客户编码  ";

        sql += " where (isnull(a.ahe,0)- isnull(b.bhe,0)) != 0  " +

               "  union select Customer1.[cCusName],c.* from (select [客户编码],部门,业务员,SUM(未核销金额)*-1 应收款 from 收款单表 where 客户编码 not IN(select distinct 客户编码 from 销售发票) and 收款单表.部门!='采购部' and 收款单表.客户编码!='' and 收款单表.部门!='' group by 客户编码,部门,业务员) c" +
          "     left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn + "')." + vDataBaseName +
               ".dbo.[Customer] as Customer1  " +
               " on  Customer1.[cCusCode]= c.客户编码   where c.应收款 != 0 ";


        DataSet ds = SQLHelper1.Query(sql);


        DataTable dataTable = ds.Tables[0];

        DataView dataView = dataTable.DefaultView;

        dataView.Sort = "部门 ";
        DataTable dataTableDistinct3 = dataView.ToTable(true, "部门"); //注

        DataRow dr3 = dataTableDistinct3.NewRow();
        dr3["部门"] = "全部";
        dataTableDistinct3.Rows.InsertAt(dr3, 0);
        DropDownList3.DataSource = dataTableDistinct3;
        DropDownList3.DataValueField = "部门";
        DropDownList3.DataBind();

        dataView.Sort = "cCusName";
        DataTable dataTableDistinct4 = dataView.ToTable(true, "cCusName"); //注      
        //DataTable dtTemp = dataTableDistinct4.Copy();
        DataRow dr4 = dataTableDistinct4.NewRow();
        dr4["cCusName"] = "全部";
        dataTableDistinct4.Rows.InsertAt(dr4, 0);
        DropDownList4.DataSource = dataTableDistinct4;
        DropDownList4.DataValueField = "cCusName";
        DropDownList4.DataBind();

        dataView.Sort = "业务员 ";
        DataTable dataTableDistinct1 = dataView.ToTable(true, "业务员"); //注      
        //DataTable dtTemp = dataTableDistinct1.Copy();
        DataRow dr1 = dataTableDistinct1.NewRow();
        dr1["业务员"] = "全部";
        dataTableDistinct1.Rows.InsertAt(dr1, 0);
        DropDownList1.DataSource = dataTableDistinct1;
        DropDownList1.DataValueField = "业务员";
        DropDownList1.DataBind();

    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        Bind(true);
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            //case "Modify":
            //    List<String> SQLStringList = new List<string>();
            //    string sql = "";
            //    string AutoID = e.CommandArgument.ToString();
            //    //string strText = ((TextBox)row.FindControl("dateTxtBox")).Text;
            //    string txtPreMoDate = ((TextBox)row.FindControl("txtcDefine37")).Text;

            //    string cSOCode = row.Cells[0].Text;
            //    string iRowNo = row.Cells[1].Text;
            //    string cInvCode = row.Cells[4].Text;

            //    string iInvAdvance = ((HiddenField) row.FindControl("iInvAdvance")).Value;
            //    //if ("".Equals(strText))
            //    //{
            //    //    sql = "update SO_SODetails set cdefine37 = null where AutoID='" + AutoID + "'";
            //    //    //int ret = SQLHelper.ExecuteSql();

            //    //}
            //    //else
            //    //{
            //    //    sql = "update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + AutoID + "'";
            //    //    //int ret = SQLHelper.ExecuteSql();
            //    //}

            //    if ("".Equals(txtPreMoDate))
            //    {
            //        sql = "update SO_SODetails set cDefine37 = null where AutoID='" + AutoID + "'";
            //        //int ret = SQLHelper.ExecuteSql();

            //    }
            //    else
            //    {
            //        sql = "update SO_SODetails set cDefine37 = '" + txtPreMoDate + "' where AutoID='" + AutoID + "'";
            //        //int ret = SQLHelper.ExecuteSql();
            //    }



            //    SQLStringList.Add(sql);

            //    sql = "" +
            //          " SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],a.SoCode, mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid LEFT JOIN mom_morder ON a.modid = mom_morder.modid LEFT JOIN inventory ON a.InvCode = inventory.cInvCode LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode] LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID  LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode   " +
            //          " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3  and 1=1   " +
            //          " and a.SoCode='" + cSOCode + "' and soseq='" + iRowNo + "'  " +
            //          " order by Duedate ";

            //    DataTable dt = SQLHelper.Query(sql).Tables[0];
            //    decimal ret = 0;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        if (i == 6)
            //        {
            //        }
            //        ret = GetCount(cInvCode, dt.Rows[i]["cInvCode"].ToString(), Convert.ToDecimal(iInvAdvance));
            //        DateTime repaDate = Convert.ToDateTime(txtPreMoDate).AddDays(-Convert.ToDouble(ret));

            //        sql = "update mom_morder set DueDate = '" + repaDate + "' where MoDId='" + dt.Rows[i]["MoDId"] + "'";
            //        SQLStringList.Add(sql);
            //    }





            //    if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
            //    {
            //        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);
            //        //MessageBox.Show(this, "更新数据失败");

            //    }
            //    else
            //    {
            //        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);

            //        //MessageBox.Show(this, "成功更新数据");
            //        //return;
            //    }
            //    //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);
            //    break;

            //case "BeginProdu":

            //    //ImageButton btnEdit = sender as ImageButton;
            //    //GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
            //    //this.UpdatePanel1.Update();
            //    this.HiddenField1.Value = row.Cells[0].Text;
            //    this.TextBox1.Text = row.Cells[1].Text;
            //    this.TextBox2.Text = row.Cells[2].Text;
            //    //this.mpeFirstDialogBox.Show();

            //    //string AutoID = e.CommandArgument.ToString();
            //    //GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            //    //string strText = ((DateTextBox)row.FindControl("dateTxtBox")).Text;
            //    //if ("".Equals(strText))
            //    //{
            //    //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = null where AutoID='" + AutoID + "'");

            //    //}
            //    //else
            //    //{
            //    //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + AutoID + "'");
            //    //}
            //    break;
            //default:
            //    break;
        }

    }



    protected void Bind(bool isFirstPage)
    {
        ViewState["a"] = 0;
        ViewState["b"] = 0;

        Label5.Text = Convert.ToDouble(ViewState["a"]).ToString("n");
        Label7.Text = Convert.ToDouble(ViewState["b"]).ToString("n");

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration//DataBaseName").InnerText.Trim();

        string sql =

            "  select * from  (  select Customer.[cCusName],a.客户编码,a.部门,a.业务员,(isnull(a.ahe,0)- isnull(b.bhe,0)) 应收款 from                                           " +
          "   (select [客户编码],部门,业务员,(SUM(未核销金额)+sum(质保金未核销)) as ahe  from [销售发票]  where  销售发票.部门!='采购部' and 销售发票.客户编码!='' and 销售发票.部门!=''  group by 客户编码,部门,业务员)a          " +
            "   left join                                                                                                                                                         " +
            "   (select 客户编码,SUM(未核销金额) as bhe  from 收款单表  group by 客户编码) b                                               " +
            "   on a.客户编码=b.客户编码  " +
          "     left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn + "')." + vDataBaseName +
            "   .dbo.[Customer] as Customer  on  Customer.[cCusCode]= a.客户编码  ";

        sql += " where (isnull(a.ahe,0)- isnull(b.bhe,0)) != 0 " +

               "  union select Customer1.[cCusName],c.* from (select [客户编码],部门,业务员,SUM(未核销金额)*-1 应收款 from 收款单表 where 客户编码 not IN(select distinct 客户编码 from 销售发票)  and 收款单表.部门!='采购部' and 收款单表.客户编码!='' and 收款单表.部门!=''  group by 客户编码,部门,业务员) c" +
          "     left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn + "')." + vDataBaseName +
               ".dbo.[Customer] as Customer1  " +
               " on  Customer1.[cCusCode]= c.客户编码   where c.应收款 != 0) zuiwaimian where 1=1 ";



        if (!"全部".Equals(DropDownList1.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                sql += " and (zuiwaimian.业务员 is null or zuiwaimian.业务员='') ";
            }
            else
            {
                sql += " and zuiwaimian.业务员='" + DropDownList1.SelectedValue + "'";
            }

        }
        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList3.SelectedValue))
            {
                sql += " and (zuiwaimian.部门 is null or zuiwaimian.部门='') ";
            }
            else
            {
                sql += " and zuiwaimian.部门='" + DropDownList3.SelectedValue + "'";
            }



            //sql += " and zuiwaimian.部门='" + DropDownList3.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
            {
                sql += " and (zuiwaimian.cCusName is null  or  zuiwaimian.cCusName='')   ";
            }
            else
            {
                sql += " and zuiwaimian.cCusName='" + DropDownList4.SelectedValue + "'";
            }

            //sql += " and zuiwaimian.cCusName='" + DropDownList4.SelectedValue + "'";
        }


        //=============start
        DataSet ds11 = SQLHelper1.Query(sql);
        double d到期应收款 = 0;
        for (int i = 0; i < ds11.Tables[0].Rows.Count; i++)
        {
            string sql12 = " select  iCusCreLine,	iCusCreDate from [Customer] where [cCusCode]='" + ds11.Tables[0].Rows[i]["客户编码"] + "' ";
            DataSet ds12 = SQLHelper.Query(sql12);
            if (Convert.ToDouble(ds11.Tables[0].Rows[i]["应收款"]) < 0)
            {
                d到期应收款 = 0;
            }
            else if (ds12.Tables[0].Rows.Count == 1)
            {
                int 信用额度 = Convert.ToInt32(ds12.Tables[0].Rows[0][0]);
                int 信用期限 = Convert.ToInt32(ds12.Tables[0].Rows[0][1]);

                //label信用额度.Text = 信用额度.ToString();
                //label信用期限.Text = 信用期限.ToString();

                DateTime dt = Convert.ToDateTime(txtStartDate.Text).AddDays(-Convert.ToDouble(信用期限));
                string sql13 = " select isnull(sum(未核销金额),0) from  [销售发票] where [开票日期] <'" + dt.ToShortDateString() +
                      "' and  客户编码='" + ds11.Tables[0].Rows[i]["客户编码"] + "'";
                DataSet ds1 = SQLHelper1.Query(sql13);
                double itemp = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);
                itemp = itemp - 信用额度;
                if (itemp > 0)
                {
                    // to do strat
                    DataTable dtTemp = SQLHelper1.Query("select * from 质保金 where [客户编码] ='" + ds11.Tables[0].Rows[i]["客户编码"] + "'").Tables[0];
                    if (dtTemp.Rows.Count == 1)
                    {
                        DateTime dttemp = System.DateTime.Now.AddYears(-Convert.ToInt32(dtTemp.Rows[0]["期限"]));
                       string sql1 = " select isnull(sum(质保金未核销),0)    from  [销售发票] where [开票日期] <='" + dttemp.ToShortDateString() +
                                  "' and  客户编码='" + ds11.Tables[0].Rows[i]["客户编码"] + "'";
                        DataSet ds2 = SQLHelper1.Query(sql1);
                        double itemp2 = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                        itemp += itemp2;
                    }
                    //to do end

                    d到期应收款 = (itemp);
                }
                else
                {
                    d到期应收款 = 0;
                }

            }

            ViewState["a"] = Convert.ToDouble(ViewState["a"]) + Convert.ToDouble(ds11.Tables[0].Rows[i]["应收款"]);
            ViewState["b"] = Convert.ToDouble(ViewState["b"]) + Convert.ToDouble(d到期应收款);
        }



        Label5.Text = Convert.ToDouble(ViewState["a"]).ToString("n");
        Label7.Text = Convert.ToDouble(ViewState["b"]).ToString("n");

        //=============end



        DataSet ds = SQLHelper1.Query(sql);


        int curpage = Convert.ToInt32(this.labPage.Text); //获取当前页数

        PagedDataSource ps = new PagedDataSource();

        ps.DataSource = ds.Tables[0].DefaultView;

        //启用分页
        ps.AllowPaging = true;
        //设置每页为3条数据
        ps.PageSize = 30;

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

        //设置当前索引
        //ps.CurrentPageIndex = curpage - 1;
        //显示当前页面
        this.lnkbtnFront.Enabled = true;
        this.lnkbtnNext.Enabled = true;
        this.linkbtnLast.Enabled = true;
        this.lnkbtnFirst.Enabled = true;

        //第一页
        if (curpage == 1)
        {
            this.lnkbtnFirst.Enabled = false; //不显示第一页按钮
            this.lnkbtnFront.Enabled = false; //不显示上一页按钮
        }
        //最后一页
        if (curpage == ps.PageCount)
        {
            this.lnkbtnNext.Enabled = false; //不显示下一页按钮
            this.linkbtnLast.Enabled = false; //不显示最后一页
        }
        //总页数
        this.labBackPage.Text = Convert.ToString(ps.PageCount);
        //绑定数据源
        GridView1.DataSource = ps;
        GridView1.DataBind();

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

    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton btnEdit = sender as ImageButton;
    //    GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
    //    //this.UpdatePanel1.Update();
    //    this.HiddenField1.Value = row.Cells[0].Text;
    //    this.TextBox1.Text = row.Cells[1].Text;
    //    this.TextBox2.Text = row.Cells[2].Text;
    //    this.ModalPopupExtender1.Show();
    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            //start 2014-08-02
            Label labelsection1 = e.Row.FindControl("labelsection1") as Label;
            Label labelsection2 = e.Row.FindControl("labelsection2") as Label;
            Label labelsection3 = e.Row.FindControl("labelsection3") as Label;
            Label labelsection4 = e.Row.FindControl("labelsection4") as Label;
            Label labelsection5 = e.Row.FindControl("labelsection5") as Label;
            Label labelsection6 = e.Row.FindControl("labelsection6") as Label;
            Label labelsection7 = e.Row.FindControl("labelsection7") as Label;
            Label labelsection8 = e.Row.FindControl("labelsection8") as Label;
            //end 2014-08-02

            Label Label到期应收款 = e.Row.FindControl("Label2") as Label;
            //Label Label应收款 = e.Row.FindControl("Label2") as Label;
            Label label信用额度 = e.Row.FindControl("Label3") as Label;
            Label label信用期限 = e.Row.FindControl("Label4") as Label;
            HiddenField 客户编码 = e.Row.FindControl("客户编码") as HiddenField;
            //HiddenField 开票日期 = e.Row.FindControl("开票日期") as HiddenField;
            HiddenField 应收款 = e.Row.FindControl("应收款") as HiddenField;
            string sql = " select  iCusCreLine,	iCusCreDate from [Customer] where [cCusCode]='" + 客户编码.Value + "' ";

            DataSet ds = SQLHelper.Query(sql);

            if (ds.Tables[0].Rows.Count == 1)
            {
                int 信用额度 = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                int 信用期限 = Convert.ToInt32(ds.Tables[0].Rows[0][1]);

                label信用额度.Text = 信用额度.ToString();
                label信用期限.Text = 信用期限.ToString();

                if (Convert.ToDouble(应收款.Value) < 0)
                {
                    Label到期应收款.Text = 0.ToString("n");
                    //start 2014-08-02
                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-90) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-1) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection1.Text =Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-180) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-91) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection2.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]) .ToString("n");

                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-365) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-181) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection3.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]) .ToString("n");

                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-730) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-366) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection4.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");
                    //========================
                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-1095) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-731) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection5.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-1460) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-1096) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection6.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(sum(未核销金额),0) from 收款单表 where [单据日期]>='" + DateTime.Now.Date.AddDays(-1825) + "' and [单据日期]<='" + DateTime.Now.Date.AddDays(-1461) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection7.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select  isnull(sum(未核销金额),0) from 收款单表 where [单据日期]<='" + DateTime.Now.Date.AddDays(-1826) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection8.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");
                    //end 2014-08-02
                }
                else
                {

                    //start 2014-08-02
                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-90) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-1) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection1.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-180) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-91) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection2.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-365) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-181) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection3.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-730) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-366) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection4.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");



                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-1095) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-731) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection5.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-1460) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-1096) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection6.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期] >='" + DateTime.Now.Date.AddDays(-1825) + "' and [开票日期]<='" + DateTime.Now.Date.AddDays(-1461) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection7.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");

                    sql = " select  isnull(SUM(未核销金额),0)+isnull(sum(质保金未核销),0) from [销售发票] where (未核销金额>0 or 质保金未核销>0) and [开票日期]<='" + DateTime.Now.Date.AddDays(-1826) + "' and [客户编码]='" + 客户编码.Value + "' ";
                    labelsection8.Text = Convert.ToInt32(SQLHelper1.Query(sql).Tables[0].Rows[0][0]).ToString("n");
                    //end 2014-08-02


                    DateTime dt =Convert.ToDateTime(txtStartDate.Text) .AddDays(-Convert.ToDouble(信用期限));
                    sql = " select isnull(sum(未核销金额),0)    from  [销售发票] where [开票日期] <'" + dt.ToShortDateString() +
                          "' and  客户编码='" + 客户编码.Value + "'";
                    DataSet ds1 = SQLHelper1.Query(sql);
                    double itemp = Convert.ToDouble(ds1.Tables[0].Rows[0][0]);

                    itemp = itemp - 信用额度;
                    if (itemp > 0)
                    {
                        // to do strat
                        DataTable dtTemp = SQLHelper1.Query("select * from 质保金 where [客户编码] ='" + 客户编码.Value + "'").Tables[0];
                        if (dtTemp.Rows.Count == 1)
                        {
                            DateTime dttemp = System.DateTime.Now.AddYears(-Convert.ToInt32(dtTemp.Rows[0]["期限"]));
                          string   sql1 = " select isnull(sum(质保金未核销),0)    from  [销售发票] where [开票日期] <='" + dttemp.ToShortDateString() +
                                      "' and  客户编码='" + 客户编码.Value + "'";
                            DataSet ds2 = SQLHelper1.Query(sql1);
                            double itemp2 = Convert.ToDouble(ds2.Tables[0].Rows[0][0]);
                            itemp += itemp2;
                        }
                        //to do end

                        Label到期应收款.Text = (itemp).ToString("n");
                    }
                    else
                    {
                        Label到期应收款.Text = 0.ToString("n");
                    }
                }




            }



            //HiddenField cInvCode = e.Row.FindControl("cInvCode") as HiddenField;
            HyperLink HyperLink1 = e.Row.FindControl("HyperLink1") as HyperLink;

            //HiddenField cSOCode = e.Row.FindControl("cSOCode") as HiddenField;

            //if (SQLHelper1.Query(" select * from SetColor where cSOCode='"+cSOCode.Value+"' ").Tables[0].Rows.Count>0)
            //{
            //    e.Row.BackColor = Color.DodgerBlue;
            //}

            HyperLink1.Text = "详细";
            HyperLink1.Attributes.Add("onclick",
                                          "openwin('Mom3.aspx','Mom3','" + 客户编码.Value + "','650','600','" +
                                          "" + "','" + "" + "','" +
                                          "" + "','" +
                                          "" + "','" + "" + "','" + "" + "' )");
            HyperLink1.NavigateUrl = "javascript:void(0)";




            //string sql = " select (CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.[iSodid]=" + iSOsID.Value + " and CurrentStock.cInvCode='" + cInvCode.Value + "' and CurrentStock.iQuantity>0 ";
            //DataSet ds1 = SQLHelper.Query(sql);
            //DataTable dt1 = ds1.Tables[0];

            //if ("0000015613".Equals(cSOCode.Value))
            //{

            //}
            //if (dt1.Rows.Count == 1)
            //{
            //    Label1.Text = Convert.ToInt32(dt1.Rows[0][0]).ToString();
            //}
            //else if (dt1.Rows.Count == 0)
            //{
            //    sql = " select count(CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.cInvCode='" + cInvCode.Value + "' and [cWhCode] in ('01','02','03','04','05','06','07','11','14','18','19','20','21','22','23','25','27','35','36','37') and CurrentStock.iQuantity>0 ";
            //    ds1 = SQLHelper.Query(sql);
            //    dt1 = ds1.Tables[0];
            //    if (dt1.Rows.Count == 1)
            //    {
            //        Label1.Text = Convert.ToInt32(dt1.Rows[0][0]).ToString();
            //    }
            //}

            //e.Row.RowIndex
            //GridView1.DeleteRow();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Button111_Click(object sender, EventArgs e)
    {

        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");
        str = str + ".xls";

        //GridView1.AllowPaging = false;
        ////if (selectFlag == 0)
        ////    bind();
        ////if (selectFlag == 1)
        ////    selectBind();
        //Bind(true);

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration//DataBaseName").InnerText.Trim();

        string sql =

          "  select * from  (  select Customer.[cCusName],a.客户编码,a.部门,a.业务员,(isnull(a.ahe,0)- isnull(b.bhe,0)) 应收款 from                                           " +
          "   (select [客户编码],部门,业务员,(SUM(未核销金额)+sum(质保金未核销)) as ahe  from [销售发票]  where  销售发票.部门!='采购部' and 销售发票.客户编码!='' and 销售发票.部门!=''  group by 客户编码,部门,业务员)a          " +
          "   left join                                                                                                                                                         " +
          "   (select 客户编码,SUM(未核销金额) as bhe  from 收款单表  group by 客户编码) b                                               " +
          "   on a.客户编码=b.客户编码  " +
        "     left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn + "')." + vDataBaseName +
          "   .dbo.[Customer] as Customer  on  Customer.[cCusCode]= a.客户编码  ";

        sql += " where (isnull(a.ahe,0)- isnull(b.bhe,0)) != 0 " +

               "  union select Customer1.[cCusName],c.* from (select [客户编码],部门,业务员,SUM(未核销金额)*-1 应收款 from 收款单表 where 客户编码 not IN(select distinct 客户编码 from 销售发票)  and 收款单表.部门!='采购部' and 收款单表.客户编码!='' and 收款单表.部门!=''  group by 客户编码,部门,业务员) c" +
          "     left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn + "')." + vDataBaseName +
               ".dbo.[Customer] as Customer1  " +
               " on  Customer1.[cCusCode]= c.客户编码   where c.应收款 != 0) zuiwaimian where 1=1 ";


        if (!"全部".Equals(DropDownList1.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                sql += " and (zuiwaimian.业务员 is null or zuiwaimian.业务员='') ";
            }
            else
            {
                sql += " and zuiwaimian.业务员='" + DropDownList1.SelectedValue + "'";
            }

        }
        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList3.SelectedValue))
            {
                sql += " and (zuiwaimian.部门 is null or zuiwaimian.部门='') ";
            }
            else
            {
                sql += " and zuiwaimian.部门='" + DropDownList3.SelectedValue + "'";
            }

        }

        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
            {
                sql += " and (zuiwaimian.cCusName is null  or  zuiwaimian.cCusName='')   ";
            }
            else
            {
                sql += " and zuiwaimian.cCusName='" + DropDownList4.SelectedValue + "'";
            }

            //sql += " and zuiwaimian.cCusName='" + DropDownList4.SelectedValue + "'";
        }


        DataSet ds = SQLHelper1.Query(sql);
        GridView1.DataSource = ds;
        GridView1.DataBind();



        //GridViewToExcel(GridView1, "application/ms-excel", str);

        Method();
    }

    /// <summary>
    /// 将网格数据导出到Excel
    /// </summary>
    /// <param name="ctrl">网格名称(如GridView1)</param>
    /// <param name="FileType">要导出的文件类型(Excel:application/ms-excel)</param>
    /// <param name="FileName">要保存的文件名</param>
    public static void GridViewToExcel(GridView ctrl, string FileType, string FileName)
    {
        HttpContext.Current.Response.Charset = "GB2312";
        //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;//注意编码
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        HttpContext.Current.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
        HttpContext.Current.Response.ContentType = FileType;//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 
        ctrl.Page.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);

        //for (int i = 0; i < ctrl.Columns.Count; i++)
        //{
        //    LinkButton linkButton = ((LinkButton)(ctrl.HeaderRow.Cells[i].Controls[0]));//获取标题行第i个单元格的<a>标签(LinkButton)
        //    string value = linkButton.Text;//保存<a>标签的文本
        //    ctrl.HeaderRow.Cells[i].Controls.Clear();//把标题行第i个单元格的所有控件删除(把<a>标签删除)
        //    ctrl.HeaderRow.Cells[i].Text = value;//把<a>标签的文本赋给标题行第i个单元格的文本
        //    linkButton.Dispose();

        //    ctrl.Columns[3].Visible = false;
        //}

        ctrl.Columns[9].Visible = false;

        ctrl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }

    //DataTable dt = new DataTable();
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
                if (j == 6)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection1")).Text.Trim());
                }
                else if (j == 7)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection2")).Text.Trim());
                }
                else if (j == 8)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection3")).Text.Trim());
                }
                else if (j == 9)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection4")).Text.Trim());
                }

                else if (j == 10)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection5")).Text.Trim());
                }
                else if (j == 11)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection6")).Text.Trim());
                }
                else if (j == 12)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection7")).Text.Trim());
                }
                else if (j == 13)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection8")).Text.Trim());
                }


                else if (j == 14)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("Label2")).Text.Trim());
                }
                else if (j == 15)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("Label3")).Text.Trim());
                }
                else if (j ==16)
                {
                    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("Label4")).Text.Trim());
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
}