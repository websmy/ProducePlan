using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_Mom1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFilter();
            Bind(true);

            //txtStartDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            txtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd ");

        }
    }


    //private void SqlAppend(ref string sql)
    //{

    //    if (CheckBox是否缺料具体查询类别.Checked)
    //    {
    //               }

    //}

    //private void SqlAppendLinliao(ref string sql)
    //{

    //    if (CheckBox是否缺料具体查询类别.Checked)
    //    {
    //        sql += " and (LEFT(c33.cInvCCode, 4) = '0103' or LEFT(c33.cInvCCode, 6) = '020201' or LEFT(c33.cInvCCode, 6) = '020202' or LEFT(c33.cInvCCode, 8) = '02020302' or LEFT(c33.cInvCCode, 8) = '02020307') ";
    //    }

    //}

    protected void Bind(bool isFirstPage)
    {

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration1//DataBaseName").InnerText.Trim();

        string sql =
            "SELECT  pn.datetime, a.modid, SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,a.ordercode,a.orderseq,'' as 是否缺料,"
            +
            " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
            + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
            + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            + " LEFT JOIN SO_SOMain ON a.ordercode = SO_SOMain.cSOCode  "
            + " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode  AND a.OrderSeq=SO_SODetails.iRowNo"
            + " left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn on  a.MoDId= pn.MoDId  "

            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

            + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 ";
        //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

        //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
        sql += " and 1=1 ";
        sql += " and exists( select '1' from  opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn where pn.modid = a.modid   ) ";

        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList是否是产成品.SelectedValue))
        {
            if ("是".Equals(DropDownList是否是产成品.SelectedValue))
            {
                sql += " and ( LEFT(inventory.cInvCCode,2)='03') ";
            }
            else
            {
                sql += " and ( LEFT(inventory.cInvCCode,2)!='03') ";
            }

        }

        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
            {
                sql += " and cinvdefine4 is null ";
            }
            else
            {
                sql += " and cinvdefine4='" + DropDownList4.SelectedValue + "'";
            }

        }
        if (!"".Equals(TextBox1.Text))
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                //sql += " and mom_orderdetail.SoCode is null ";
                //sql += " and mom_orderdetail.SoCode is null ";
            }
            else
            {
                sql += " and ordercode='" + TextBox1.Text.Trim() + "'";
            }
        }
        if (!"".Equals(TextBox2.Text))
        {
            if (string.IsNullOrEmpty(TextBox2.Text))
            {

            }
            else
            {
                sql += " and mocode='" + TextBox2.Text.Trim() + "'";
            }
        }


        if (CheckBox是否缺料具体查询类别.Checked)
        {
            sql +=
                 " and not exists (SELECT '1' FROM mom_moallocate c1 "
                 + "  JOIN mom_orderdetail  c2 ON c1.modid = c2.modid"
                 + "  JOIN inventory c3  ON c1.invcode = c3.cinvcode";

            sql +=
                "  left JOIN CurrentStock c4 ON c4.cWhCode = c3.cDefWareHouse AND c4.cInvCode = c1.InvCode"
                +
                " WHERE  c1.modid = a.modid AND c1.qty - c1.issqty > Isnull(c4.iQuantity - c4.fOutQuantity, 0)";

            sql += " and (LEFT(c3.cInvCCode, 4) = '0103' or LEFT(c3.cInvCCode, 6) = '020201' or LEFT(c3.cInvCCode, 6) = '020202' or LEFT(c3.cInvCCode, 8) = '02020302' or LEFT(c3.cInvCCode, 8) = '02020307') )";
        }

        else
        {

            if (!"全部".Equals(DropDownList是否缺料.SelectedValue))
            {

                if ("是".Equals(DropDownList是否缺料.SelectedValue))
                {

                    sql +=
                           " and exists (SELECT '1' FROM mom_moallocate c1 "
                           + "  JOIN mom_orderdetail  c2 ON c1.modid = c2.modid"
                           + "  JOIN inventory c3  ON c1.invcode = c3.cinvcode";

                    //SqlAppend(ref sql);

                    sql +=
                        " left JOIN CurrentStock c4 ON c4.cWhCode = c3.cDefWareHouse AND c4.cInvCode = c1.InvCode"
                        +
                        " WHERE  c1.modid = a.modid AND c1.qty - c1.issqty > Isnull(c4.iQuantity - c4.fOutQuantity, 0) ";


                    sql += " ) ";

                }

                else
                {
                    sql +=
                        " and not exists (SELECT '1' FROM mom_moallocate c1 "
                        + "  JOIN mom_orderdetail  c2 ON c1.modid = c2.modid"
                        + "  JOIN inventory c3  ON c1.invcode = c3.cinvcode";


                    //SqlAppend(ref sql);

                    sql +=
                        "  left JOIN CurrentStock c4 ON c4.cWhCode = c3.cDefWareHouse AND c4.cInvCode = c1.InvCode"
                        +
                        " WHERE  c1.modid = a.modid AND c1.qty - c1.issqty > Isnull(c4.iQuantity - c4.fOutQuantity, 0)) ";
                }
            }
        }



        if (!"全部".Equals(DropDownList是否领料完成.SelectedValue))
        {
            if ("是".Equals(DropDownList是否领料完成.SelectedValue))
            {
                sql +=
                   " and not exists (SELECT c11.qty ,c11.issqty FROM mom_moallocate c11 "
                   + "  JOIN mom_orderdetail  c22 ON c11.modid = c22.modid"
                   + "  JOIN inventory c33  ON c11.invcode = c33.cinvcode ";

                sql +=
                    //+ "  JOIN CurrentStock c44 ON c44.cWhCode = c33.cDefWareHouse AND c44.cInvCode = c11.InvCode "
                    " left JOIN CurrentStock c44 ON c44.cWhCode = c11.whcode AND c44.cInvCode = c11.InvCode "
                   + " WHERE  c11.modid = a.modid AND c11.qty >0  and c11.qty > c11.issqty ) ";


                sql +=
             " and (SELECT count(c12.qty) FROM mom_moallocate c12 WHERE  c12.modid = a.modid) >0  ";
  


            }
            else
            {
                sql +=
        " and  exists (SELECT  c11.qty ,c11.issqty FROM mom_moallocate c11 "
        + "  JOIN mom_orderdetail  c22 ON c11.modid = c22.modid"
        + "  JOIN inventory c33  ON c11.invcode = c33.cinvcode ";
                sql +=
         //+ "  JOIN CurrentStock c44 ON c44.cWhCode = c33.cDefWareHouse AND c44.cInvCode = c11.InvCode "
         "  left JOIN CurrentStock c44 ON c44.cWhCode = c11.whcode AND c44.cInvCode = c11.InvCode "
        + " WHERE  c11.modid = a.modid  and c11.qty > c11.issqty ) ";

                sql +=
         " and (SELECT count(c12.qty) FROM mom_moallocate c12 WHERE  c12.modid = a.modid) >0  ";
            }

        }

        if (!"".Equals(txtStartDate.Text))
        {
            sql += "  and mom_order.CreateDate >= '" + txtStartDate.Text + "' ";
        }

        if (!"".Equals(txtEndDate.Text))
        {
            sql += "  and mom_order.CreateDate <= '" + txtEndDate.Text + "' ";
        }


        if (!"".Equals(txtDate.Text))
        {
            sql += "  and mom_morder.StartDate >= '" + txtDate.Text + "' ";
        }

        if (!"".Equals(txtDate1.Text))
        {
            sql += "  and mom_morder.DueDate <= '" + txtDate1.Text + "' ";
        }



        //sql += " order by a.modid ";
        sql += " order by Duedate ";


        DataSet ds = SQLHelper.Query(sql);

        DataTable dt = ds.Tables[0];

        //Session["MyTable"] = null;
        //Session["MyTable"] = ds;


        int curpage = Convert.ToInt32(this.labPage.Text); //获取当前页数

        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dt.DefaultView;

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

    private void BindFilter()
    {
        //string str = "";
        //bool found = false;
        //Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        //if (dic == null)
        //    return;
        //foreach (KeyValuePair<string, string> kv in dic)
        //{
        //    if (kv.Key.Equals(User.Identity.Name))
        //    {
        //        found = true;
        //        str = kv.Value;
        //        break;
        //    }
        //}

        //if (!found)
        //{
        //    return;
        //}

        //string sql =
        //    "select Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
        //    "from mom_orderdetail " +
        //    "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
        //    "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
        //    "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
        //    "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +
        //    "where mom_orderdetail.status<> 4 and mom_orderdetail.Qty <> mom_orderdetail.QualifiedInQty and mom_orderdetail.Status = 3 and Department.[cDepName] in (" +
        //    str + ")";

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration1//DataBaseName").InnerText.Trim();

        string sql =
            "SELECT  pn.datetime, a.modid, SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,a.ordercode,a.orderseq,'' as 是否缺料,"
            +
            " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
            + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
            + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            + " LEFT JOIN SO_SOMain ON a.ordercode = SO_SOMain.cSOCode  "
            + " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode  AND a.OrderSeq=SO_SODetails.iRowNo"
            + " left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn on  a.MoDId= pn.MoDId  "

            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

            + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 ";
        //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

        //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
        sql += " and 1=1 ";
        sql += " and exists( select '1' from  opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn where pn.modid = a.modid   ) ";

        //string sql = "select * from aViewName where 1=1 ";
        DataSet ds = SQLHelper.Query(sql);


        DataTable dataTable = ds.Tables[0];
        ;
        DataView dataView = dataTable.DefaultView;
        //DataView dataView1 = dataTable.DefaultView;

        DataTable dataTableDistinct3 = dataView.ToTable(true, "cDepName"); //注

        DataTable dtTempTpf = dataTableDistinct3.Copy();
        DataView dvTPF = dtTempTpf.DefaultView;
        dvTPF.Sort = "cDepName";
        dtTempTpf = dvTPF.ToTable();

        DataRow dr3 = dtTempTpf.NewRow();
        dr3["cDepName"] = "全部";
        dtTempTpf.Rows.InsertAt(dr3, 0);
        DropDownList3.DataSource = dtTempTpf;
        DropDownList3.DataValueField = "cDepName";
        DropDownList3.DataBind();

        DataTable dataTableDistinct4 = dataView.ToTable(true, "cinvdefine4"); //注      
        DataTable dtTemp = dataTableDistinct4.Copy();
        DataTable dtTemp1 = dtTemp.Copy();
        dtTemp1.Rows.Clear();

        for (int i = 0; i < dtTemp.Rows.Count; i++)
        {
            int cnt = 0;
            if (String.IsNullOrEmpty(dtTemp.Rows[i]["cinvdefine4"].ToString()))
            {
                cnt++;
            }

            if (cnt >= 2)
            {
                //dtTemp.Rows[i].Delete();
            }
            else
            {
                dtTemp1.ImportRow(dtTemp.Rows[i]);
            }
        }

        ViewState["dataTableDistinct4"] = dtTemp1;

        DataTable dtTemp2 = dtTemp1.Copy();
        DataView dv = dtTemp2.DefaultView;
        dv.Sort = "cinvdefine4";
        dtTemp2 = dv.ToTable();

        //DataTable dtTemp2 = dtTemp1.Copy();
        DataRow dr4 = dtTemp2.NewRow();
        dr4["cinvdefine4"] = "全部";
        dtTemp2.Rows.InsertAt(dr4, 0);
        DropDownList4.DataSource = dtTemp2;
        DropDownList4.DataValueField = "cinvdefine4";
        DropDownList4.DataBind();

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        GridViewRow row = (GridViewRow)(((WebControl)e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            case "Modify":
                //string parValue = e.CommandArgument.ToString();

                string qian = ((HiddenField)row.FindControl("qian")).Value.Trim();
                string hou = ((HiddenField)row.FindControl("hou")).Value.Trim();

                string modid = ((HiddenField)row.FindControl("modid")).Value;
                string cInvCode = ((HiddenField)row.FindControl("cInvCode")).Value;
                string ordercode = ((HiddenField)row.FindControl("ordercode")).Value;

                //LoginView loginView1 = ((LoginView)row.FindControl("LoginView1"));
                string DropDownList5 = ((DropDownList)row.FindControl("DropDownList5")).SelectedValue;

                //LoginView loginView2 = ((LoginView)row.FindControl("LoginView2"));
                string dateTxtBox = ((TextBox)row.FindControl("dateTxtBox")).Text;

                //LoginView loginView3 = ((LoginView)row.FindControl("LoginView3"));
                string txt逾期原因 = ((DropDownList)row.FindControl("txt逾期原因")).Text.Trim();
                string txt逾期原因详细 = ((TextBox)row.FindControl("txt逾期原因详细")).Text.Trim();
                string txtCombine = txt逾期原因 + txt逾期原因;
                List<String> SQLStringList = new List<string>();
                String sql = "";
                sql = "update mom_morder set DueDate='" + dateTxtBox + "' where modid='" + modid + "'";
                SQLStringList.Add(sql);
                sql = "update Inventory set [cinvdefine4]='" + DropDownList5 + "' where cInvCode='" + cInvCode + "'";
                SQLStringList.Add(sql);

                sql = "update mom_orderdetail set define25='" + txt逾期原因 + "," + txt逾期原因详细 + "' where modid='" + modid +
                      "'";
                SQLStringList.Add(sql);
                if (!(qian + hou).Equals(txtCombine))
                {
                    sql = " insert into SetColor(Cordercode) values('" + ordercode + "')";
                    SQLHelper1.ExecuteSql(sql);
                }

                if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                {
                    //Response.Write("<script>alert('生成报表失败');</script>");

                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);
                    //MessageBox.Show(this, "更新数据失败");
                    //Response.Write();
                    //return;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);

                    //MessageBox.Show(this, "成功更新数据");
                    //return;
                }
                

                break;


            default:

                break;
        }

    }





    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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
        Bind(true);

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {


            Button asp_btnUpdate = e.Row.FindControl("asp_btnUpdate") as Button;
            Label Label1 = e.Row.FindControl("Label1") as Label;
            Label label逾期原因详细 = e.Row.FindControl("label逾期原因详细") as Label;
            Label Label2 = e.Row.FindControl("Label2") as Label;
            Label Label3 = e.Row.FindControl("Label3") as Label;
            TextBox dateTxtBox = e.Row.FindControl("dateTxtBox") as TextBox;
            DropDownList DropDownList5 = e.Row.FindControl("DropDownList5") as DropDownList;
            DropDownList txt逾期原因 = e.Row.FindControl("txt逾期原因") as DropDownList;
            TextBox txt逾期原因详细 = e.Row.FindControl("txt逾期原因详细") as TextBox;

            HiddenField cinvdefine4 = e.Row.FindControl("cinvdefine4") as HiddenField;
            HiddenField cInvCCode = e.Row.FindControl("cInvCCode") as HiddenField;

            HiddenField modid = e.Row.FindControl("modid") as HiddenField;
            HiddenField MDeptCode = e.Row.FindControl("MDeptCode") as HiddenField;

            HiddenField MoId = e.Row.FindControl("MoId") as HiddenField;
            HiddenField SortSeq = e.Row.FindControl("SortSeq") as HiddenField;
            HiddenField soseq = e.Row.FindControl("soseq") as HiddenField;

            HiddenField SoDId = e.Row.FindControl("SoDId") as HiddenField;
            //HiddenField iunitcost = e.Row.FindControl("iunitcost") as HiddenField;

            if (modid.Value.Equals("1000299555"))
            {

            }

            string sql =
                "select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
                "from mom_moallocate " +
                "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
                "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
                "left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
                "where mom_moallocate.modid=" + modid.Value + " order by mom_moallocate.whcode ";
            DataSet ds1 = SQLHelper.Query(sql);
            DataTable dt1 = ds1.Tables[0];


            DataTable dtemp = null;
            DataTable dtempPartial = null;
            if (true)
            {
                if (modid.Value.Equals("191507"))
                {

                }
                sql = "";
                sql +=
                    "select inventory.cDefWareHouse AS whcode,mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, '' as  xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
                    "from mom_moallocate " +
                    "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
                    "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
                    //"left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
                    "where mom_moallocate.modid=" + modid.Value;
                //if (MDeptCode.Value.Equals("1301") && cInvCCode.Value.StartsWith("03"))
                //{
                //    sql += " and (inventory.[cInvCCode] like '0103%'  or inventory.[cInvCCode] like '02%')  ";
                //}

                sql += "order by mom_moallocate.whcode ";
                ds1 = SQLHelper.Query(sql);
                dtemp = ds1.Tables[0];


                string sqlPartial = "select inventory.cDefWareHouse AS whcode,mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, '' as xiancun,mom_moallocate.qty - mom_moallocate.issqty yaoling " +
                    "from mom_moallocate " +
                    "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
                    "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +

                    "  " +

                //"left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
                "where mom_moallocate.modid=" + modid.Value + "  and (LEFT(Inventory.cInvCCode, 4) = '0103' or LEFT(Inventory.cInvCCode, 6) = '020201' or LEFT(Inventory.cInvCCode, 6) = '020202' or LEFT(Inventory.cInvCCode, 8) = '02020302' or LEFT(Inventory.cInvCCode, 8) = '02020307') ";

                dtempPartial = SQLHelper.Query(sqlPartial).Tables[0];
                if (dtemp.Rows.Count == 0)
                {
                    HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;
                    la.Text = "否";
                }


            }
            else
            {
                dtemp = dt1;
            }

            if (Roles.IsUserInRole("Worker"))
            {

                asp_btnUpdate.Enabled = true;
                Label1.Visible = false;
                label逾期原因详细.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                dateTxtBox.Visible = true;
                DropDownList5.Visible = true;
                txt逾期原因.Visible = true;




                if (dt1.Rows.Count == 0)
                {
                    //first
                    //LoginView loginView4 = e.Row.FindControl("LoginView4") as LoginView;
                    //HyperLink la = loginView4.FindControl("HyperLink1") as HyperLink;
                    HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;

                    la.Text = "无材料";

                    //second
                    HyperLink lingliao = e.Row.FindControl("HyperLink2") as HyperLink;
                    lingliao.Text = "添加材料";
                    //string url = "MomPop.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
                    //lingliao.Target = "_blank";
                    lingliao.ToolTip = "添加材料";
                    lingliao.Attributes.Add("onclick",
                                            "openwin('MomPop.aspx','MomPop','" + modid.Value + "','650','600','" +
                                            MDeptCode.Value + "','" + e.Row.Cells[7].Text + "','" +
                                            e.Row.Cells[5].Text + "','" +
                                            e.Row.Cells[9].Text + "','" + MoId.Value + "','" + SoDId.Value + "' )");
                    lingliao.NavigateUrl = "javascript:void(0)";

                    //third
                    HyperLink ruku = e.Row.FindControl("HyperLink3") as HyperLink;
                    ruku.Text = "无材料";
                }
                else
                {



                    for (int j = 0; j < dtemp.Rows.Count; j++)
                    {

                        //Literal la = e.Row.FindControl("Literal1") as Literal;
                        HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;
                        //LoginView loginView4 = e.Row.FindControl("LoginView4") as LoginView;
                        //HyperLink la = loginView4.FindControl("HyperLink1") as HyperLink;
                        la.Text = "否";

                        //if (MDeptCode.Value.Equals("1301") && cInvCCode.Value.StartsWith("03"))
                        if (true)
                        {
                            string strSql =
                                " select  isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode = '" +
                                dtemp.Rows[j]["invcode"] + "' and CurrentStock.cWhCode='" + dtemp.Rows[j]["whcode"] + "'  ";
                            dtemp.Rows[j]["xiancun"] = SQLHelper.Query(strSql).Tables[0].Rows[0][0].ToString();

                            if (String.IsNullOrEmpty(dtemp.Rows[j]["xiancun"].ToString()))
                            {
                                dtemp.Rows[j]["xiancun"] = "0";
                            }
                        }
                        //if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) -
                        //    System.Convert.ToDouble(dt1.Rows[j]["issqty"])>0)
                        //{
                        if (System.Convert.ToDouble(dtemp.Rows[j]["qty"]) -
                            System.Convert.ToDouble(dtemp.Rows[j]["issqty"])
                            > System.Convert.ToDouble(dtemp.Rows[j]["xiancun"]))
                        {

                            la.Text = "是";
                            //string url = "MomPop_Que.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
                            //la.Target = "_blank";
                            la.ToolTip = "显示缺料信息";
                            //la.NavigateUrl = url;
                            la.Attributes.Add("onclick",
                                              "openwin('MomPop_QueN.aspx','MomPop_QueN','" + modid.Value +
                                              "','650','600','" +
                                              MDeptCode.Value + "','" + e.Row.Cells[7].Text + "','" +
                                              e.Row.Cells[5].Text + "','" + e.Row.Cells[9].Text +
                                              "','" + MoId.Value + "','" + cInvCCode.Value + "'  )");
                            la.NavigateUrl = "javascript:void(0)";
                            break;
                        }
                        //}

                    }


                    HyperLink laPartial = e.Row.FindControl("HyperLink4") as HyperLink;

                    laPartial.Text = "否";

                    for (int j = 0; j < dtempPartial.Rows.Count; j++)
                    {

                        HyperLink la = e.Row.FindControl("HyperLink4") as HyperLink;

                        la.Text = "否";

                        if (true)
                        {
                            string strSql =
                                " select  isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode = '" +
                                dtempPartial.Rows[j]["invcode"] + "' and CurrentStock.cWhCode='" + dtempPartial.Rows[j]["whcode"] + "'  ";
                            dtempPartial.Rows[j]["xiancun"] = SQLHelper.Query(strSql).Tables[0].Rows[0][0].ToString();

                            if (String.IsNullOrEmpty(dtempPartial.Rows[j]["xiancun"].ToString()))
                            {
                                dtempPartial.Rows[j]["xiancun"] = "0";
                            }
                        }

                        if (System.Convert.ToDouble(dtempPartial.Rows[j]["qty"]) -
                            System.Convert.ToDouble(dtempPartial.Rows[j]["issqty"])
                            > System.Convert.ToDouble(dtempPartial.Rows[j]["xiancun"]))
                        {

                            la.Text = "是";
                            //string url = "MomPop_Que.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
                            //la.Target = "_blank";
                            la.ToolTip = "显示缺料信息";
                            //la.NavigateUrl = url;
                            la.Attributes.Add("onclick",
                                              "openwin('MomPop_QueN1.aspx','MomPop_QueN','" + modid.Value +
                                              "','650','600','" +
                                              MDeptCode.Value + "','" + e.Row.Cells[7].Text + "','" +
                                              e.Row.Cells[5].Text + "','" + e.Row.Cells[9].Text +
                                              "','" + MoId.Value + "','" + cInvCCode.Value + "'  )");
                            la.NavigateUrl = "javascript:void(0)";
                            break;
                        }
                        //}

                    }


                    bool b已经领完 = true;
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        HyperLink lingliao = e.Row.FindControl("HyperLink2") as HyperLink;
                        lingliao.Text = "领完";

                        if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) >
                            System.Convert.ToDouble(dt1.Rows[j]["issqty"])
                            )
                        {

                            lingliao.Text = "领料";
                            //string url = "MomPop.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
                            //lingliao.Target = "_blank";
                            lingliao.ToolTip = "开始领料";
                            lingliao.Attributes.Add("onclick",
                                                    "openwin20140610('MomPop.aspx','MomPop','" + modid.Value + "','650','600','" +
                                                    MDeptCode.Value + "','" + e.Row.Cells[7].Text + "','" +
                                                    e.Row.Cells[5].Text + "','" +
                                                    e.Row.Cells[9].Text + "','" +
                                                    MoId.Value + "','" +
                                                    SoDId.Value + "' ,'" + cinvdefine4.Value + "' " +
                                                    ",'" + SortSeq.Value + "' " +
                                                    ",'" + soseq.Value + "' " +

                                                    ")");
                            lingliao.NavigateUrl = "javascript:void(0)";
                            b已经领完 = false;
                            //lingliao.NavigateUrl = url;
                            break;
                        }
                    }


                    //if (d="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}" />
                    //            <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" )

                    HyperLink ruku = e.Row.FindControl("HyperLink3") as HyperLink;

                    if (System.Convert.ToDouble(e.Row.Cells[9].Text) ==
                        System.Convert.ToDouble(e.Row.Cells[10].Text))
                    {
                        ruku.Text = "已经入库完了";
                    }
                    else
                    {
                        if (b已经领完)
                        {
                            ruku.Text = "入库";
                            ruku.ToolTip = "开始入库";
                            ruku.Attributes.Add("onclick",
                                                "openwin1('MomPop_Ruku.aspx','MomPop_Ruku','" + MDeptCode.Value +
                                                "','700','400','" + e.Row.Cells[1].Text + "','" +
                                                e.Row.Cells[2].Text + "','" + e.Row.Cells[3].Text +
                                                "','" + e.Row.Cells[5].Text + "','" +
                                                e.Row.Cells[7].Text + "'" +
                                                ",'" + SoDId.Value + "','" +
                                                e.Row.Cells[9].Text + "'" +
                                                ",'" + MoId.Value + "','" + SortSeq.Value + "'" +
                                                ",'" + modid.Value + "'" +
                                                ",'" + e.Row.Cells[10].Text + "'" +
                                                ",'" + soseq.Value + "'" +
                                                  ",'" + "" + "'" +
                                                " )");
                            ruku.NavigateUrl = "javascript:void(0)";
                        }
                        else
                        {
                            //ruku.Text = "请先领料";
                            ruku.Text = "入库";
                            ruku.ToolTip = "开始入库";
                            ruku.Attributes.Add("onclick",
                                                "openwin2('MomPop_Ruku.aspx','MomPop_Ruku','" + MDeptCode.Value +
                                                "','700','400','" + e.Row.Cells[1].Text + "','" +
                                                e.Row.Cells[2].Text + "','" + e.Row.Cells[3].Text +
                                                "','" + e.Row.Cells[5].Text + "','" +
                                                e.Row.Cells[7].Text + "'" +
                                                ",'" + SoDId.Value + "','" +
                                                e.Row.Cells[9].Text + "'" +
                                                ",'" + MoId.Value + "','" + SortSeq.Value + "'" +
                                                ",'" + modid.Value + "'" +
                                                ",'" + e.Row.Cells[10].Text + "'" +
                                                ",'" + soseq.Value + "'" +
                                                ",'" + "" + "'" +

                                                " )");
                            ruku.NavigateUrl = "javascript:void(0)";

                        }

                    }
                }


                if (DropDownList5 != null)
                {
                    DropDownList5.DataSource = ViewState["dataTableDistinct4"];
                    DropDownList5.DataValueField = "cinvdefine4";
                    DropDownList5.DataBind();

                    DropDownList5.SelectedValue = cinvdefine4.Value;
                }
            }
            else if (Roles.IsUserInRole("ruku"))
            {


                bool b已经领完 = true;
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    //HyperLink lingliao = e.Row.FindControl("HyperLink2") as HyperLink;
                    //lingliao.Text = "已经领完";

                    if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) >
                        System.Convert.ToDouble(dt1.Rows[j]["issqty"])
                        )
                    {


                        b已经领完 = false;
                        //lingliao.NavigateUrl = url;
                        break;
                    }
                }


                //if (d="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}" />
                //            <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" )

                HyperLink ruku = e.Row.FindControl("HyperLink3") as HyperLink;

                if (System.Convert.ToDouble(e.Row.Cells[9].Text) ==
                    System.Convert.ToDouble(e.Row.Cells[10].Text))
                {
                    ruku.Text = "已经入库完了";
                }
                else
                {
                    if (b已经领完)
                    {
                        ruku.Text = "入库";
                        ruku.ToolTip = "开始入库";
                        ruku.Attributes.Add("onclick",
                                            "openwin1('MomPop_Ruku.aspx','MomPop_Ruku','" + MDeptCode.Value +
                                            "','700','400','" + e.Row.Cells[1].Text + "','" +
                                            e.Row.Cells[2].Text + "','" + e.Row.Cells[3].Text +
                                            "','" + e.Row.Cells[5].Text + "','" +
                                            e.Row.Cells[7].Text + "'" +
                                            ",'" + SoDId.Value + "','" +
                                            e.Row.Cells[9].Text + "'" +
                                            ",'" + MoId.Value + "','" + SortSeq.Value + "'" +
                                            ",'" + modid.Value + "'" +
                                            ",'" + e.Row.Cells[10].Text + "'" +
                                            ",'" + soseq.Value + "'" +

                                            " )");
                        ruku.NavigateUrl = "javascript:void(0)";
                    }
                    else
                    {
                        //ruku.Text = "请先领料";
                        ruku.Text = "入库";
                        ruku.ToolTip = "开始入库";
                        ruku.Attributes.Add("onclick",
                                            "openwin2('MomPop_Ruku.aspx','MomPop_Ruku','" + MDeptCode.Value +
                                            "','700','400','" + e.Row.Cells[1].Text + "','" +
                                            e.Row.Cells[2].Text + "','" + e.Row.Cells[3].Text +
                                            "','" + e.Row.Cells[5].Text + "','" +
                                            e.Row.Cells[7].Text + "'" +
                                            ",'" + SoDId.Value + "','" +
                                            e.Row.Cells[9].Text + "'" +
                                            ",'" + MoId.Value + "','" + SortSeq.Value + "'" +
                                            ",'" + modid.Value + "'" +
                                            ",'" + e.Row.Cells[10].Text + "'" +
                                            ",'" + soseq.Value + "'" +

                                            " )");
                        ruku.NavigateUrl = "javascript:void(0)";

                    }

                }


                asp_btnUpdate.Enabled = false;

                Label1.Visible = true;
                label逾期原因详细.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;

                dateTxtBox.Visible = false;
                DropDownList5.Visible = false;
                txt逾期原因.Visible = false;
                txt逾期原因详细.Visible = false;
            }
            else //manager 
            {
                //2015-05-27 add start
                for (int j = 0; j < dtemp.Rows.Count; j++)
                {

                    //Literal la = e.Row.FindControl("Literal1") as Literal;
                    HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;
                    //LoginView loginView4 = e.Row.FindControl("LoginView4") as LoginView;
                    //HyperLink la = loginView4.FindControl("HyperLink1") as HyperLink;
                    la.Text = "否";

                    //if (MDeptCode.Value.Equals("1301") && cInvCCode.Value.StartsWith("03"))
                    if (true)
                    {
                        string strSql =
                            " select  isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode = '" +
                        //dtemp.Rows[j]["invcode"] + "'";
                        dtemp.Rows[j]["invcode"] + "' and CurrentStock.cWhCode='" + dtemp.Rows[j]["whcode"] + "'  ";

                        dtemp.Rows[j]["xiancun"] = SQLHelper.Query(strSql).Tables[0].Rows[0][0].ToString();

                        if (String.IsNullOrEmpty(dtemp.Rows[j]["xiancun"].ToString()))
                        {
                            dtemp.Rows[j]["xiancun"] = "0";
                        }
                    }
                    //if (System.Convert.ToDouble(dt1.Rows[j]["qty"]) -
                    //    System.Convert.ToDouble(dt1.Rows[j]["issqty"])>0)
                    //{
                    if (System.Convert.ToDouble(dtemp.Rows[j]["qty"]) -
                        System.Convert.ToDouble(dtemp.Rows[j]["issqty"])
                        > System.Convert.ToDouble(dtemp.Rows[j]["xiancun"]))
                    {

                        la.Text = "是";
                        //string url = "MomPop_Que.aspx?id=" + modid.Value + "&p1=" + MDeptCode.Value + "&p2=" + e.Row.Cells[5].Text + "&p3=" + e.Row.Cells[4].Text + "&p4=" + e.Row.Cells[7].Text;                              //转向网页的地址;
                        //la.Target = "_blank";
                        la.ToolTip = "显示缺料信息";
                        //la.NavigateUrl = url;
                        la.Attributes.Add("onclick",
                                          "openwin('MomPop_QueN.aspx','MomPop_QueN','" + modid.Value +
                                          "','650','600','" +
                                          MDeptCode.Value + "','" + e.Row.Cells[7].Text + "','" +
                                          e.Row.Cells[5].Text + "','" + e.Row.Cells[9].Text +
                                          "','" + MoId.Value + "','" + cInvCCode.Value + "'  )");
                        la.NavigateUrl = "javascript:void(0)";
                        break;
                    }
                    //}

                }
                //2015-05-27 add end
                asp_btnUpdate.Enabled = false;

                Label1.Visible = true;
                label逾期原因详细.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;

                dateTxtBox.Visible = false;
                DropDownList5.Visible = false;
                txt逾期原因.Visible = false;
                txt逾期原因详细.Visible = false;
            }
            //if (i == 6)
            //{

            //}


        }
    }

    protected void btnExcelExport_Click(object sender, EventArgs e)
    {

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration1//DataBaseName").InnerText.Trim();

        string sql =
            "SELECT  pn.datetime, a.modid, SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,a.ordercode,a.orderseq,'' as 是否缺料,"
            +
            " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
            + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
            + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            + " LEFT JOIN SO_SOMain ON a.ordercode = SO_SOMain.cSOCode  "
            + " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode  AND a.OrderSeq=SO_SODetails.iRowNo"
            + " left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn on  a.MoDId= pn.MoDId  "

            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

            + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 ";
        //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

        //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
        sql += " and 1=1 ";
        sql += " and exists( select '1' from  opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn where pn.modid = a.modid   ) ";


        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList是否是产成品.SelectedValue))
        {
            if ("是".Equals(DropDownList是否是产成品.SelectedValue))
            {
                sql += " and ( LEFT(inventory.cInvCCode,2)='03') ";
            }
            else
            {
                sql += " and ( LEFT(inventory.cInvCCode,2)!='03') ";
            }

        }

        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
            {
                sql += " and cinvdefine4 is null ";
            }
            else
            {
                sql += " and cinvdefine4='" + DropDownList4.SelectedValue + "'";
            }

        }
        if (!"".Equals(TextBox1.Text))
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                //sql += " and mom_orderdetail.SoCode is null ";
                //sql += " and mom_orderdetail.SoCode is null ";
            }
            else
            {
                sql += " and ordercode='" + TextBox1.Text.Trim() + "'";
            }
        }
        if (!"".Equals(TextBox2.Text))
        {
            if (string.IsNullOrEmpty(TextBox2.Text))
            {

            }
            else
            {
                sql += " and mocode='" + TextBox2.Text.Trim() + "'";
            }
        }


        if (CheckBox是否缺料具体查询类别.Checked)
        {
            sql +=
                 " and not exists (SELECT '1' FROM mom_moallocate c1 "
                 + "  JOIN mom_orderdetail  c2 ON c1.modid = c2.modid"
                 + "  JOIN inventory c3  ON c1.invcode = c3.cinvcode";

            sql +=
                "  left JOIN CurrentStock c4 ON c4.cWhCode = c3.cDefWareHouse AND c4.cInvCode = c1.InvCode"
                +
                " WHERE  c1.modid = a.modid AND c1.qty - c1.issqty > Isnull(c4.iQuantity - c4.fOutQuantity, 0)";

            sql += " and (LEFT(c3.cInvCCode, 4) = '0103' or LEFT(c3.cInvCCode, 6) = '020201' or LEFT(c3.cInvCCode, 6) = '020202' or LEFT(c3.cInvCCode, 8) = '02020302' or LEFT(c3.cInvCCode, 8) = '02020307') )";
        }

        else
        {

            if (!"全部".Equals(DropDownList是否缺料.SelectedValue))
            {

                if ("是".Equals(DropDownList是否缺料.SelectedValue))
                {

                    sql +=
                           " and exists (SELECT '1' FROM mom_moallocate c1 "
                           + "  JOIN mom_orderdetail  c2 ON c1.modid = c2.modid"
                           + "  JOIN inventory c3  ON c1.invcode = c3.cinvcode";

                    //SqlAppend(ref sql);

                    sql +=
                        " left JOIN CurrentStock c4 ON c4.cWhCode = c3.cDefWareHouse AND c4.cInvCode = c1.InvCode"
                        +
                        " WHERE  c1.modid = a.modid AND c1.qty - c1.issqty > Isnull(c4.iQuantity - c4.fOutQuantity, 0) ";


                    sql += " ) ";

                }

                else
                {
                    sql +=
                        " and not exists (SELECT '1' FROM mom_moallocate c1 "
                        + "  JOIN mom_orderdetail  c2 ON c1.modid = c2.modid"
                        + "  JOIN inventory c3  ON c1.invcode = c3.cinvcode";


                    //SqlAppend(ref sql);

                    sql +=
                        "  left JOIN CurrentStock c4 ON c4.cWhCode = c3.cDefWareHouse AND c4.cInvCode = c1.InvCode"
                        +
                        " WHERE  c1.modid = a.modid AND c1.qty - c1.issqty > Isnull(c4.iQuantity - c4.fOutQuantity, 0)) ";
                }
            }
        }



        if (!"全部".Equals(DropDownList是否领料完成.SelectedValue))
        {
            if ("是".Equals(DropDownList是否领料完成.SelectedValue))
            {
                sql +=
                   " and not exists (SELECT c11.qty ,c11.issqty FROM mom_moallocate c11 "
                   + "  JOIN mom_orderdetail  c22 ON c11.modid = c22.modid"
                   + "  JOIN inventory c33  ON c11.invcode = c33.cinvcode ";

                sql +=
                    //+ "  JOIN CurrentStock c44 ON c44.cWhCode = c33.cDefWareHouse AND c44.cInvCode = c11.InvCode "
                    " left JOIN CurrentStock c44 ON c44.cWhCode = c11.whcode AND c44.cInvCode = c11.InvCode "
                   + " WHERE  c11.modid = a.modid AND c11.qty >0  and c11.qty > c11.issqty ) ";


                sql +=
             " and (SELECT count(c12.qty) FROM mom_moallocate c12 WHERE  c12.modid = a.modid) >0  ";



            }
            else
            {
                sql +=
        " and  exists (SELECT  c11.qty ,c11.issqty FROM mom_moallocate c11 "
        + "  JOIN mom_orderdetail  c22 ON c11.modid = c22.modid"
        + "  JOIN inventory c33  ON c11.invcode = c33.cinvcode ";
                sql +=
         //+ "  JOIN CurrentStock c44 ON c44.cWhCode = c33.cDefWareHouse AND c44.cInvCode = c11.InvCode "
         "  left JOIN CurrentStock c44 ON c44.cWhCode = c11.whcode AND c44.cInvCode = c11.InvCode "
        + " WHERE  c11.modid = a.modid  and c11.qty > c11.issqty ) ";

                sql +=
         " and (SELECT count(c12.qty) FROM mom_moallocate c12 WHERE  c12.modid = a.modid) >0  ";
            }

        }

        if (!"".Equals(txtStartDate.Text))
        {
            sql += "  and mom_order.CreateDate >= '" + txtStartDate.Text + "' ";
        }

        if (!"".Equals(txtEndDate.Text))
        {
            sql += "  and mom_order.CreateDate <= '" + txtEndDate.Text + "' ";
        }


        if (!"".Equals(txtDate.Text))
        {
            sql += "  and mom_morder.StartDate >= '" + txtDate.Text + "' ";
        }

        if (!"".Equals(txtDate1.Text))
        {
            sql += "  and mom_morder.DueDate <= '" + txtDate1.Text + "' ";
        }



        //sql += " order by a.modid ";
        sql += " order by Duedate ";


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
                if (j == 2)
                {
                    cells.Add((i + 2), (j + 1), ((DropDownList)GridView1.Rows[i].FindControl("DropDownList5")).SelectedValue.Trim());
                }
                else if (j == 11)
                {
                    cells.Add((i + 2), (j + 1), ((TextBox)GridView1.Rows[i].FindControl("dateTxtBox")).Text.Trim());
                }
                else if (j == 12)
                {
                    cells.Add((i + 2), (j + 1), ((DropDownList)GridView1.Rows[i].FindControl("txt逾期原因")).SelectedValue.Trim());
                }
                else if (j == 13)
                {
                    cells.Add((i + 2), (j + 1), ((TextBox)GridView1.Rows[i].FindControl("txt逾期原因详细")).Text.Trim());
                }
                else if (j == 14)
                {
                    cells.Add((i + 2), (j + 1), ((HyperLink)GridView1.Rows[i].FindControl("HyperLink1")).Text.Trim());
                }

                else if (j == 15)
                {
                    cells.Add((i + 2), (j + 1), ((HyperLink)GridView1.Rows[i].FindControl("HyperLink4")).Text.Trim());
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


    protected void Button112_Click(object sender, EventArgs e)
    {
        //string sql = "";
        Session["needprint"] = "";
        bool ischecked = false;
        List<String> lst_cSOCode = new List<String>();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = GridView1.Rows[i].FindControl("cbItem") as CheckBox;
            if (cb.Checked)
            {

                HiddenField modid = GridView1.Rows[i].FindControl("modid") as HiddenField;

                lst_cSOCode.Add(modid.Value);
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "openwin", "alert('没有选择任何项!')", true);
            return;
        }

        string strConnected = string.Join("','", lst_cSOCode.ToArray());
        Session["needprint"] = strConnected;

        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "openwin('Mom1Print.aspx','Mom1Print','" + "" + "','650','600','" +
                              "" + "','" + "" + "','" +
                              "" + "','" +
                              "" + "','" + "" + "','" + "" + "' )", true);
    }





}