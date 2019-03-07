using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_Mom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFilter();
            Bind(true);



        }
    }

    protected void Bind(bool isFirstPage)
    {
        //GridView1.DataSource = null;
        //int pageSize = 10;
        //string sql = "select * from aViewName where 1=1 ";

        //      string sql =
        //"select inventory.[cInvCode],mom_orderdetail.moid,mom_orderdetail.SortSeq,Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
        //"from mom_orderdetail " +
        //"left join mom_order on mom_orderdetail.moid=mom_order.moid " +
        //"left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +                                                                                                                                                                               
        //"left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +                                                                                                                                                                            
        //"left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +                                                                                                                                                                  
        //"where mom_orderdetail.status<> 4 ";   
        //=======================================2012-02-20
        string str = "";
        bool found = false;
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return;
        foreach (KeyValuePair<string, string> kv in dic)
        {
            if (kv.Key.Equals(User.Identity.Name))
            {
                found = true;
                str = kv.Value;
                break;
            }
        }

        if (!found)
        {
            return;
        }
        //===============================
        //string sql = "select comment from [aspnetdb].[dbo].[aspnet_Membership] a inner join [aspnetdb].[dbo].[aspnet_Users] b on a.UserId=b.UserId where b.UserName='"+User.Identity.Name+"'";
        //DataSet ds1 = SQLHelper.Query(sql);


        //aaaa += "<Br />" + kv.Key + ":" + kv.Value; SO_SODetails.iUnitPrice as iunitcost ,

        string sql =
            "SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,a.ordercode,a.orderseq,'' as 是否缺料,"
            +
            " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
            + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
            + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            + " LEFT JOIN SO_SOMain ON a.ordercode = SO_SOMain.cSOCode  "
            + " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode  AND a.OrderSeq=SO_SODetails.iRowNo"

            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

            + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 and Department.[cDepName] in (" +
            str + ")";
        //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

        //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
        sql += " and 1=1 ";

        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
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



        if (!"全部".Equals(DropDownList6.SelectedValue))
        {
            //sql += "            and  "
            //+ "( "
            //+ "case  "
            //+
            //"when inventory.cinvdefine4='一车间装配班' then  (SELECT Count(*) FROM mom_moallocate  LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode  WHERE  mom_moallocate.modid = a.modid  and (inventory.[cInvCCode] like '0103%'  or inventory.[cInvCCode] like '02%') AND mom_moallocate.qty - mom_moallocate.issqty > Isnull( (select sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity) from CurrentStock where CurrentStock.cInvCode = mom_moallocate.InvCode), 0)) "
            //+
            //"when inventory.cinvdefine4!='一车间装配班' then (SELECT Count(*) FROM mom_moallocate  LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode LEFT JOIN CurrentStock ON CurrentStock.cWhCode = mom_moallocate.whcode AND CurrentStock.cInvCode = mom_moallocate.InvCode WHERE  mom_moallocate.modid = a.modid AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0)) "
            //+ "end  "
            //+ ") ";

            //if ("是".Equals(DropDownList6.SelectedValue))
            //{
            //    sql += ">0";
            //}
            //else
            //{
            //    sql += "=0";
            //}

            if ("是".Equals(DropDownList6.SelectedValue))
            {
                sql +=
                    " and (SELECT Count(*) FROM mom_moallocate "
                    + " LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid"
                    + " LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode"
                    +
                    " LEFT JOIN CurrentStock ON CurrentStock.cWhCode = inventory.cDefWareHouse AND CurrentStock.cInvCode = mom_moallocate.InvCode"
                    +
                    " WHERE  mom_moallocate.modid = a.modid AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0))>0";
            }
            else
            {
                sql +=
                    " and (SELECT Count(*) FROM mom_moallocate "
                    + " LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid"
                    + " LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode"
                    +
                    " LEFT JOIN CurrentStock ON CurrentStock.cWhCode = inventory.cDefWareHouse AND CurrentStock.cInvCode = mom_moallocate.InvCode"
                    +
                    " WHERE  mom_moallocate.modid = a.modid AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0))=0";
            }
        }



        if (!"全部".Equals(DropDownList逾期定单.SelectedValue))
        {
            if ("是".Equals(DropDownList逾期定单.SelectedValue))
            {
                sql +=
                    " and convert(datetime,mom_morder.Duedate,110) < getdate() ";
            }
            else
            {
                sql +=
                    "  and convert(datetime,mom_morder.Duedate,110) >= getdate() ";
            }
        }

        if (!"全部".Equals(DropDownList逾期原因.SelectedValue))
        {
            sql +=
                    "  and a.define25 like ('" + DropDownList逾期原因.SelectedValue + "%') ";          
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
        //if (!"全部".Equals(DropDownList6.SelectedValue))
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {

        //        DataSet ds1 =
        //            SQLHelper.Query(
        //                "select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,Warehouse.[cWhName],mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, 0.00 as  xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
        //                "from mom_moallocate " +
        //                "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
        //                "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
        //                "left join Warehouse on Warehouse.cWhCode = mom_moallocate.whcode  " +
        //                "where mom_moallocate.modid=" + dt.Rows[i]["modid"] + " " +
        //                "order by mom_moallocate.whcode");

        //        DataTable dt1 = ds1.Tables[0];
        //        for (int j = 0; j < dt1.Rows.Count; j++)
        //        {
        //            dt1.Rows[j]["xiancun"] =
        //                SQLHelper.Query(
        //                    "select Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode ='" +
        //                    dt1.Rows[j]["invcode"].ToString() + "'").Tables[0].Rows[0][0].ToString();
        //        }

        //        DataRow[] drArr = dt1.Select("(qty - issqty)>xiancun");
        //        if (drArr.Length > 0)
        //        {
        //            dt.Rows[i]["是否缺料"] = "是";
        //        }
        //        else
        //        {
        //            dt.Rows[i]["是否缺料"] = "否";
        //        }

        //    }
        //}
        //if (!"全部".Equals(DropDownList6.SelectedValue))
        //{          
        //    if ("是".Equals(DropDownList6.SelectedValue))
        //    {
        //        DataRow[] drArr = dt.Select("是否缺料='是'");
        //        DataTable dtNew = dt.Clone();
        //        for (int i = 0; i < drArr.Length; i++)
        //        {
        //            dtNew.ImportRow(drArr[i]);
        //        }

        //        dt.Clear();
        //        dt = dtNew;            
        //    }
        //    else
        //    {
        //        DataRow[] drArr = dt.Select("是否缺料='否'");
        //        DataTable dtNew = dt.Clone();
        //        for (int i = 0; i < drArr.Length; i++)
        //        {
        //            dtNew.ImportRow(drArr[i]);
        //        }

        //        dt.Clear();
        //        dt = dtNew;
              
        //    }
        //}
       




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
        string str = "";
        bool found = false;
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return;
        foreach (KeyValuePair<string, string> kv in dic)
        {
            if (kv.Key.Equals(User.Identity.Name))
            {
                found = true;
                str = kv.Value;
                break;
            }
        }

        if (!found)
        {
            return;
        }

        //string sql =
        //    "select Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
        //    "from mom_orderdetail " +
        //    "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
        //    "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
        //    "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
        //    "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +
        //    "where mom_orderdetail.status<> 4 and mom_orderdetail.Qty <> mom_orderdetail.QualifiedInQty and mom_orderdetail.Status = 3 and Department.[cDepName] in (" +
        //    str + ")";

        string sql =
        "SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,'' as 是否缺料,"
        +
        " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
        + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
        + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
        + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
        + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
        + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
        + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode AND a.OrderSeq=SO_SODetails.iRowNo "
        + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 and Department.[cDepName] in (" +
        str + ")";


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


        //DataTable dataTableDistinct5 = dataView.ToTable(true, "SoCode");//注
        //DataRow dr5 = dataTableDistinct5.NewRow();
        //dr5["SoCode"] = "全部";
        //dataTableDistinct5.Rows.InsertAt(dr5, 0);
        //DropDownList5.DataSource = dataTableDistinct5;
        //DropDownList5.DataValueField = "SoCode";
        //DropDownList5.DataBind();

        //DataTable dataTableDistinct6 = dataView.ToTable(true, "cDepName");//注
        //DropDownList3.DataSource = dataTableDistinct6;
        //DropDownList3.DataValueField = "cDepName";
        //DropDownList3.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //try
        //{

        //}
        //catch (Exception)
        //{

        //    throw;
        //}
        GridViewRow row = (GridViewRow) (((WebControl) e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            case "Modify":
                //string parValue = e.CommandArgument.ToString();

                string qian = ((HiddenField)row.FindControl("qian")).Value.Trim();
                string hou = ((HiddenField)row.FindControl("hou")).Value.Trim();

                string modid = ((HiddenField) row.FindControl("modid")).Value;
                string cInvCode = ((HiddenField) row.FindControl("cInvCode")).Value;
                string ordercode = ((HiddenField)row.FindControl("ordercode")).Value;
                
                //LoginView loginView1 = ((LoginView)row.FindControl("LoginView1"));
                string DropDownList5 = ((DropDownList) row.FindControl("DropDownList5")).SelectedValue;

                //LoginView loginView2 = ((LoginView)row.FindControl("LoginView2"));
                string dateTxtBox = ((TextBox) row.FindControl("dateTxtBox")).Text;

                //LoginView loginView3 = ((LoginView)row.FindControl("LoginView3"));
                string txt逾期原因 = ((DropDownList) row.FindControl("txt逾期原因")).Text.Trim();
                string txt逾期原因详细 = ((TextBox) row.FindControl("txt逾期原因详细")).Text.Trim();
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
                if (!(qian+hou).Equals(txtCombine))
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
                //Response.Write("<script>alert('删除成功!')</script>");
                //return;
                //if ("".Equals(strText))
                //{
                //DataSet ds = SQLHelper.Query("select mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty,CurrentStock.iQuantity - CurrentStock.fOutQuantity xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling from mom_moallocate left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid left join inventory on mom_moallocate.invcode = inventory.cinvcode left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode where mom_moallocate.modid=" + parValue);
                //}
                //else
                //{
                //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + parValue + "'");
                //}

                //this.HiddenField1.Value = row.Cells[0].Text;
                //this.HiddenField2.Value = row.Cells[4].Text;
                //this.HiddenField3.Value = row.Cells[3].Text;
                //this.HiddenField4.Value = row.Cells[6].Text;
                //DataTable dt = ds.Tables[0];
                //dt.Columns.Add("rowNum");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dt.Rows[i]["rowNum"] = i;
                //}

                //GridView2.DataSource = dt;
                //GridView2.DataBind();

                //ViewState["dt"] = dt;

                //this.mpeFirstDialogBox.Show();

                break;


            default:

                break;
        }

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

            if (modid.Value.Equals("191507"))
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
                if (dtemp.Rows.Count==0)
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
        string str = "";
        bool found = false;
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return;
        foreach (KeyValuePair<string, string> kv in dic)
        {
            if (kv.Key.Equals(User.Identity.Name))
            {
                found = true;
                str = kv.Value;
                break;
            }
        }

        if (!found)
        {
            return;
        }
        //===============================
        //string sql = "select comment from [aspnetdb].[dbo].[aspnet_Membership] a inner join [aspnetdb].[dbo].[aspnet_Users] b on a.UserId=b.UserId where b.UserName='"+User.Identity.Name+"'";
        //DataSet ds1 = SQLHelper.Query(sql);


        //aaaa += "<Br />" + kv.Key + ":" + kv.Value; SO_SODetails.iUnitPrice as iunitcost ,

        string sql =
            "SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,a.ordercode,a.orderseq,'' as 是否缺料,"
            +
            " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
            + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
            + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            + " LEFT JOIN SO_SOMain ON a.ordercode = SO_SOMain.cSOCode  "
            //+ " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode "

            + " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode  AND a.OrderSeq=SO_SODetails.iRowNo "

            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

            + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 and Department.[cDepName] in (" +
            str + ")";
        //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

        //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
        sql += " and 1=1 ";

        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
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

        //if (!"全部".Equals(DropDownList6.SelectedValue))
        //{
        //    //sql += "            and  "
        //    //+ "( "
        //    //+ "case  "
        //    //+
        //    //"when inventory.cinvdefine4='一车间装配班' then  (SELECT Count(*) FROM mom_moallocate  LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode  WHERE  mom_moallocate.modid = a.modid  and (inventory.[cInvCCode] like '0103%'  or inventory.[cInvCCode] like '02%') AND mom_moallocate.qty - mom_moallocate.issqty > Isnull( (select sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity) from CurrentStock where CurrentStock.cInvCode = mom_moallocate.InvCode), 0)) "
        //    //+
        //    //"when inventory.cinvdefine4!='一车间装配班' then (SELECT Count(*) FROM mom_moallocate  LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode LEFT JOIN CurrentStock ON CurrentStock.cWhCode = mom_moallocate.whcode AND CurrentStock.cInvCode = mom_moallocate.InvCode WHERE  mom_moallocate.modid = a.modid AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0)) "
        //    //+ "end  "
        //    //+ ") ";

        //    //if ("是".Equals(DropDownList6.SelectedValue))
        //    //{
        //    //    sql += ">0";
        //    //}
        //    //else
        //    //{
        //    //    sql += "=0";
        //    //}

        //    if ("是".Equals(DropDownList6.SelectedValue))
        //    {
        //        sql +=
        //            " and (SELECT Count(*) FROM mom_moallocate "
        //            + " LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid"
        //            + " LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode"
        //            +
        //            " LEFT JOIN CurrentStock ON CurrentStock.cWhCode = mom_moallocate.whcode AND CurrentStock.cInvCode = mom_moallocate.InvCode"
        //            +
        //            " WHERE  mom_moallocate.modid = a.modid AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0))>0";
        //    }
        //    else
        //    {
        //        sql +=
        //            " and (SELECT Count(*) FROM mom_moallocate "
        //            + " LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid"
        //            + " LEFT JOIN inventory  ON mom_moallocate.invcode = inventory.cinvcode"
        //            +
        //            " LEFT JOIN CurrentStock ON CurrentStock.cWhCode = mom_moallocate.whcode AND CurrentStock.cInvCode = mom_moallocate.InvCode"
        //            +
        //            " WHERE  mom_moallocate.modid = a.modid AND mom_moallocate.qty - mom_moallocate.issqty > Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0))=0";
        //    }
        //}



        if (!"全部".Equals(DropDownList逾期定单.SelectedValue))
        {
            if ("是".Equals(DropDownList逾期定单.SelectedValue))
            {
                sql +=
                    " and convert(datetime,mom_morder.Duedate,110) < getdate() ";
            }
            else
            {
                sql +=
                    "  and convert(datetime,mom_morder.Duedate,110) >= getdate() ";
            }
        }

        if (!"全部".Equals(DropDownList逾期原因.SelectedValue))
        {
            sql +=
                    "  and a.define25 like ('" + DropDownList逾期原因.SelectedValue + "%') ";
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
                if (j ==2)
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