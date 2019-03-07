using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;


public partial class WorkForms_SO : System.Web.UI.Page
{
    //private  List<string> cinvcodeList = new List<string>(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFilter();

            Bind(true);

            //Bind();
        }
    }

    private void BindFilter()
    {
        string sql =
            "select SO_SOMain.[cMaker],Person.[cPersonName], [Department].[cDepName],inventory.iInvAdvance,SO_SODetails.iRowNo,SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.iQuantity,SO_SODetails.cdefine26,SO_SODetails.cdefine37 " +
            "from [SO_SODetails] " +
            "left join [SO_SOMain] on [SO_SODetails].csocode=[SO_SOMain].csocode " +
            "left join [inventory] on SO_SODetails.cInvCode=[inventory].cInvCode " +
            "left join [Department]  on SO_SOMain.cDepCode=[Department].cDepCode " +
            "left join [Person]  on Person.[cPersonCode]=[SO_SOMain].[cPersonCode] " +

            "where SO_SODetails.cSCloser is null and SO_SODetails.iQuantity > ISNULL(SO_SODetails.iFHQuantity,0)  " +
            " ";

        DataSet ds = SQLHelper.Query(sql);


        DataTable dataTable = ds.Tables[0];
        ;
        DataView dataView = dataTable.DefaultView;
        //dataView.Sort = "cDepName ";
        DataTable dataTableDistinct3 = dataView.ToTable(true, "cDepName"); //注

        DataRow dr3 = dataTableDistinct3.NewRow();
        dr3["cDepName"] = "全部";
        dataTableDistinct3.Rows.InsertAt(dr3, 0);
        DropDownList3.DataSource = dataTableDistinct3;
        DropDownList3.DataValueField = "cDepName";
        DropDownList3.DataBind();

        dataView.Sort = "cCusName ";
        DataTable dataTableDistinct4 = dataView.ToTable(true, "cCusName"); //注      
        //DataTable dtTemp = dataTableDistinct4.Copy();
        DataRow dr4 = dataTableDistinct4.NewRow();
        dr4["cCusName"] = "全部";
        dataTableDistinct4.Rows.InsertAt(dr4, 0);
        DropDownList4.DataSource = dataTableDistinct4;
        DropDownList4.DataValueField = "cCusName";
        DropDownList4.DataBind();

        dataView.Sort = "cPersonName ";
        DataTable dataTableDistinct1 = dataView.ToTable(true, "cPersonName"); //注      
        //DataTable dtTemp = dataTableDistinct1.Copy();
        DataRow dr1 = dataTableDistinct1.NewRow();
        dr1["cPersonName"] = "全部";
        dataTableDistinct1.Rows.InsertAt(dr1, 0);
        DropDownList1.DataSource = dataTableDistinct1;
        DropDownList1.DataValueField = "cPersonName";
        DropDownList1.DataBind();

        dataView.Sort = "cMaker ";       
        DataTable dataTableDistinct2 = dataView.ToTable(true, "cMaker"); //注      
        //DataTable dtTemp = dataTableDistinct2.Copy();
        DataRow dr2 = dataTableDistinct2.NewRow();
        dr2["cMaker"] = "全部";
        dataTableDistinct2.Rows.InsertAt(dr2, 0);
        DropDownList2.DataSource = dataTableDistinct2;
        DropDownList2.DataValueField = "cMaker";
        DropDownList2.DataBind();

        //DataTable dtTemp1 = dtTemp.Copy();
        //dtTemp1.Rows.Clear();
        //int cnt = 0;
        //for (int i = 0; i < dtTemp.Rows.Count; i++)
        //{
        //    if (String.IsNullOrEmpty(dtTemp.Rows[i]["cinvdefine4"].ToString()))
        //    {
        //        cnt++;
        //    }

        //    if (cnt >= 2)
        //    {
        //        //dtTemp.Rows[i].Delete();
        //    }
        //    else
        //    {
        //        dtTemp1.ImportRow(dtTemp.Rows[i]);
        //    }
        //}

        //ViewState["dataTableDistinct4"] = dtTemp1;

        //DataTable dtTemp2 = dtTemp1.Copy();
        //DataRow dr4 = dtTemp2.NewRow();
        //dr4["cinvdefine4"] = "全部";
        //dtTemp2.Rows.InsertAt(dr4, 0);
        //DropDownList4.DataSource = dtTemp2;
        //DropDownList4.DataValueField = "cinvdefine4";
        //DropDownList4.DataBind();


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

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        //GridView1.DataSource = null;
        Bind(true);

    }

    private decimal GetCount(string cinvcode, string searchcinvcode, decimal chaValue)
    {
        decimal cnt = 0;
        //cinvcodeList.Add(cinvcode);
        if (cinvcode.Equals(searchcinvcode))
        {
            return cnt;
        }
        //string[] connString = DB.getConnString();
        //string conStr = "Data Source=" + connString[0] + ";Initial Catalog=" + connString[3] + ";uid =" + connString[1] + ";pwd=" + connString[2] + ";MultipleActiveResultSets=True";
        ////DataTable dt = new DataTable();
        try
        {
            string sql = "" +
                         "SELECT f.cInvCode,f.cInvName,d.BaseQtyN,d.BaseQtyD,f.cInvCCode,f.iInvAdvance  " +
                         "FROM [Inventory]  a " +
                         "inner join  bas_part  b on b.InvCode=a.cInvCode " +
                         "inner join bom_parent c on c.ParentId=b.PartId " +
                         "left join bom_opcomponent d on d.BomId=c.BomId " +
                         "inner join bas_part e on e.PartId=d.ComponentId " +
                         "inner join [Inventory] f on f.cInvCode=e.InvCode " +
                         "where a.cinvcode='" + cinvcode + "' " +
                         "order by d.SortSeq ";
            DataTable dt = SQLHelper.Query(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["cInvCode"].ToString().Equals(searchcinvcode))
                    {
                        return chaValue;
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal temp = GetCount(dt.Rows[i]["cInvCode"].ToString(), searchcinvcode,
                                            Convert.ToDecimal(dt.Rows[i]["iInvAdvance"]));
                    if (temp > 0)
                    {
                        cnt = chaValue + temp;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
            //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {

        }
        return cnt;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow) (((Button) e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            case "Modify":
                List<String> SQLStringList = new List<string>();
                string sql = "";
                string AutoID = e.CommandArgument.ToString();
                //string strText = ((TextBox)row.FindControl("dateTxtBox")).Text;
                string txtPreMoDate = ((TextBox)row.FindControl("txtcDefine37")).Text;

                string cSOCode = row.Cells[0].Text;
                string iRowNo = row.Cells[1].Text;
                string cInvCode = row.Cells[4].Text;

                string iInvAdvance = ((HiddenField) row.FindControl("iInvAdvance")).Value;
                //if ("".Equals(strText))
                //{
                //    sql = "update SO_SODetails set cdefine37 = null where AutoID='" + AutoID + "'";
                //    //int ret = SQLHelper.ExecuteSql();

                //}
                //else
                //{
                //    sql = "update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + AutoID + "'";
                //    //int ret = SQLHelper.ExecuteSql();
                //}

                if ("".Equals(txtPreMoDate))
                {
                    sql = "update SO_SODetails set cDefine37 = null where AutoID='" + AutoID + "'";
                    //int ret = SQLHelper.ExecuteSql();

                }
                else
                {
                    sql = "update SO_SODetails set cDefine37 = '" + txtPreMoDate + "' where AutoID='" + AutoID + "'";
                    //int ret = SQLHelper.ExecuteSql();
                }



                SQLStringList.Add(sql);

                sql = "" +
                      " SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],a.SoCode, mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid LEFT JOIN mom_morder ON a.modid = mom_morder.modid LEFT JOIN inventory ON a.InvCode = inventory.cInvCode LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode] LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID  LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode   " +
                      " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3  and 1=1   " +
                      " and a.SoCode='" + cSOCode + "' and soseq='" + iRowNo + "'  " +
                      " order by Duedate ";

                DataTable dt = SQLHelper.Query(sql).Tables[0];
                decimal ret = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 6)
                    {
                    }
                    ret = GetCount(cInvCode, dt.Rows[i]["cInvCode"].ToString(), Convert.ToDecimal(iInvAdvance));
                    DateTime repaDate = Convert.ToDateTime(txtPreMoDate).AddDays(-Convert.ToDouble(ret));

                    sql = "update mom_morder set DueDate = '" + repaDate + "' where MoDId='" + dt.Rows[i]["MoDId"] + "'";
                    SQLStringList.Add(sql);
                }





                if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);
                    //MessageBox.Show(this, "更新数据失败");

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);

                    //MessageBox.Show(this, "成功更新数据");
                    //return;
                }
                //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);
                break;

            case "BeginProdu":

                //ImageButton btnEdit = sender as ImageButton;
                //GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
                //this.UpdatePanel1.Update();
                this.HiddenField1.Value = row.Cells[0].Text;
                this.TextBox1.Text = row.Cells[1].Text;
                this.TextBox2.Text = row.Cells[2].Text;
                //this.mpeFirstDialogBox.Show();

                //string AutoID = e.CommandArgument.ToString();
                //GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //string strText = ((DateTextBox)row.FindControl("dateTxtBox")).Text;
                //if ("".Equals(strText))
                //{
                //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = null where AutoID='" + AutoID + "'");

                //}
                //else
                //{
                //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + AutoID + "'");
                //}
                break;
            default:
                break;
        }

    }



    protected void Bind(bool isFirstPage)
    {

       // string sql =
       //    "select  '' as xiancun,SO_SODetails.iNatSum,SO_SODetails.iSOsID,SO_SODetails.iFHQuantity,SO_SODetails.iKPQuantity,SO_SOMain.[cMaker],Person.[cPersonName],inventory.iInvAdvance,SO_SODetails.iRowNo,SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.iQuantity,SO_SODetails.cdefine26,SO_SODetails.cdefine37 " 

       //+" FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
       // + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
       // + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
       // + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
       // + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
       // + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "
       //  + " left join [Person]  on Person.[cPersonCode]=[SO_SOMain].[cPersonCode] "
       // //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

       // + " WHERE SO_SODetails.cSCloser is null  and a.Qty <> a.QualifiedInQty " ;

       // //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

       // //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
       // sql += " and 1=1 ";


        //string sql =
        //   "select top 50 mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate from mom_orderdetail left join mom_order on mom_orderdetail.moid=mom_order.moid left join mom_morder on mom_orderdetail.modid=mom_morder.modid left join inventory on mom_orderdetail.InvCode=inventory.cInvCode";
        //DataSet ds = SQLHelper.Query(sql);
        //Rep1.DataSource = ds.Tables[0];
        //========================================2014-10-30
        string sql =
            "select  '' as xiancun,SO_SODetails.iNatSum,SO_SODetails.iSOsID,SO_SODetails.iFHQuantity,SO_SODetails.iKPQuantity,SO_SOMain.[cMaker],Person.[cPersonName],inventory.iInvAdvance,SO_SODetails.iRowNo,SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.iQuantity,SO_SODetails.cdefine26,SO_SODetails.cdefine37 " +
            "from [SO_SODetails] " +
            "left join [SO_SOMain] on [SO_SODetails].csocode=[SO_SOMain].csocode " +
            "left join [inventory] on SO_SODetails.cInvCode=[inventory].cInvCode " +
            "left join [Department]  on SO_SOMain.cDepCode=[Department].cDepCode " +
            "left join [Person]  on Person.[cPersonCode]=[SO_SOMain].[cPersonCode] " +

             //"  inner join mom_orderdetail on mom_orderdetail.sodid=SO_SODetails.iSOsID  and mom_orderdetail.InvCode= SO_SODetails.cInvCode " +

            "where  (select count(*) from  mom_orderdetail where mom_orderdetail.sodid=SO_SODetails.iSOsID  and mom_orderdetail.InvCode= SO_SODetails.cInvCode and SO_SODetails.iQuantity=mom_orderdetail.QualifiedInQty )=0  and SO_SODetails.cSCloser is null and SO_SODetails.iQuantity > ISNULL(SO_SODetails.iFHQuantity,0)  " +
            " ";
        sql += " and 1=1 ";
        //=============================================2014-10-30
        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
        }
        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            sql += " and [cCusName]='" + DropDownList4.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            sql += " and [cCusName]='" + DropDownList4.SelectedValue + "'";
        }

        if (!string.IsNullOrEmpty(TextBox3.Text))
        {
            sql += " and SO_SOMain.cSOCode='" + TextBox3.Text.Trim() + "'";
        }

        if (!"全部".Equals(DropDownList1.SelectedValue))
        {

            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                sql += " and Person.[cPersonName]='" + DropDownList1.SelectedValue + "'";
            }
            else
            {
                sql += " and Person.[cPersonName] is null";
            }

          
        }

        if (!"全部".Equals(DropDownList2.SelectedValue))
        {
            sql += " and SO_SOMain.[cMaker]='" + DropDownList2.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList5.SelectedValue))
        {
            sql +=
                "   and ((select count(*) from [CurrentStock] where  CurrentStock.[iSodid]= SO_SODetails.iSOsID and CurrentStock.cInvCode=SO_SODetails.cInvCode and CurrentStock.iQuantity>0)>0";
            sql +=
                "   or(select count(*) from [CurrentStock] where   CurrentStock.cInvCode=SO_SODetails.cInvCode and CurrentStock.iQuantity>0  and [cWhCode] in ('01','02','03','04','05','06','07','11','14','18','19','20','21','22','23','25','27','35','36','37')  )>0)";
        }



        sql += " order by dPreMoDate ";
        DataSet ds = SQLHelper.Query(sql);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{

        //    string sql2 = " select (CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.[iSodid]=" + ds.Tables[0].Rows[i]["iSOsID"] + " and CurrentStock.cInvCode='" + ds.Tables[0].Rows[i]["cInvCode"] + "'";
        //    DataSet ds1 = SQLHelper.Query(sql2);
        //    DataTable dt1 = ds1.Tables[0];

        //    if (dt1.Rows.Count == 1)
        //    {
        //      ds.Tables[0].Rows[i]["xiancun"]  = Convert.ToInt32(dt1.Rows[0][0]).ToString();
        //    }
        //    else if (dt1.Rows.Count == 0)
        //    {
        //        sql2 = " select (CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.cInvCode='" + ds.Tables[0].Rows[i]["cInvCode"] + "'";
        //        ds1 = SQLHelper.Query(sql2);
        //        dt1 = ds1.Tables[0];
        //        if (dt1.Rows.Count == 1)
        //        {
        //            ds.Tables[0].Rows[i]["xiancun"] = Convert.ToInt32(dt1.Rows[0][0]).ToString();
        //        }
        //    }

            
        //        if (!"全部".Equals(DropDownList5.SelectedValue))
        //        {
        //            try
        //            {
        //                if (Convert.ToInt32(ds.Tables[0].Rows[i]["xiancun"]) == 0)
        //                {
        //                    ds.Tables[0].Rows[i].Delete();
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                ds.Tables[0].Rows[i].Delete();
        //                //throw;
        //            }
                    
        //        } 
        //}

       



        int curpage = Convert.ToInt32(this.labPage.Text); //获取当前页数
        //连接数据源
        //SqlConnection con = new SqlConnection(Connection.connection());//调用函数获取连接字符串
        //con.Open();
        //SqlDataAdapter sda = new SqlDataAdapter("select * from student", con);
        ////DataSet ds = new DataSet();
        //sda.Fill(ds, "student");
        //生成PageDataSource对象
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
            
            Label Label1 = e.Row.FindControl("Label1") as Label;
            HiddenField iSOsID = e.Row.FindControl("iSOsID") as HiddenField;
            HiddenField cInvCode = e.Row.FindControl("cInvCode") as HiddenField;
            HyperLink HyperLink1 = e.Row.FindControl("HyperLink1") as HyperLink;

            HiddenField cSOCode = e.Row.FindControl("cSOCode") as HiddenField;

            if (SQLHelper1.Query(" select * from SetColor where cSOCode='"+cSOCode.Value+"' ").Tables[0].Rows.Count>0)
            {
                e.Row.BackColor = Color.DodgerBlue;
            }
            

            HyperLink1.Attributes.Add("onclick",
                                          "openwin('Mom2.aspx','Mom2','" + cSOCode.Value + "','650','600','" +
                                          "" + "','" + "" + "','" +
                                          "" + "','" +
                                          "" + "','" + "" + "','" + "" + "' )");
            HyperLink1.NavigateUrl = "javascript:void(0)";


            string sql = " select (CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.[iSodid]=" + iSOsID.Value + " and CurrentStock.cInvCode='" + cInvCode.Value + "' and CurrentStock.iQuantity>0 ";
            DataSet ds1 = SQLHelper.Query(sql);
            DataTable dt1 = ds1.Tables[0];

            if ("0000015613".Equals(cSOCode.Value))
            {
                
            }
            if (dt1.Rows.Count == 1)
            {
                Label1.Text = Convert.ToInt32(dt1.Rows[0][0]).ToString();
            }
            else if (dt1.Rows.Count == 0)
            {
                sql = " select count(CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.cInvCode='" + cInvCode.Value + "' and [cWhCode] in ('01','02','03','04','05','06','07','11','14','18','19','20','21','22','23','25','27','35','36','37') and CurrentStock.iQuantity>0 ";
                ds1 = SQLHelper.Query(sql);
                dt1 = ds1.Tables[0];
                if (dt1.Rows.Count == 1)
                {
                    Label1.Text = Convert.ToInt32(dt1.Rows[0][0]).ToString();
                }
            }

            //e.Row.RowIndex
            //GridView1.DeleteRow();
        }
    }




    protected void Button111_Click(object sender, EventArgs e)
    {

        //DateTime dt = System.DateTime.Now;
        //string str = dt.ToString("yyyyMMddhhmmss");
        //str = str + ".xls";

        //GridView1.AllowPaging = false;
        ////if (selectFlag == 0)
        ////    bind();
        ////if (selectFlag == 1)
        ////    selectBind();
        //Bind(true);

        //========================================2014-10-30
        string sql =
            "select  '' as xiancun,SO_SODetails.iNatSum,SO_SODetails.iSOsID,SO_SODetails.iFHQuantity,SO_SODetails.iKPQuantity,SO_SOMain.[cMaker],Person.[cPersonName],inventory.iInvAdvance,SO_SODetails.iRowNo,SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.iQuantity,SO_SODetails.cdefine26,SO_SODetails.cdefine37 " +
            "from [SO_SODetails] " +
            "left join [SO_SOMain] on [SO_SODetails].csocode=[SO_SOMain].csocode " +
            "left join [inventory] on SO_SODetails.cInvCode=[inventory].cInvCode " +
            "left join [Department]  on SO_SOMain.cDepCode=[Department].cDepCode " +
            "left join [Person]  on Person.[cPersonCode]=[SO_SOMain].[cPersonCode] " +

             //"  inner join mom_orderdetail on mom_orderdetail.sodid=SO_SODetails.iSOsID  and mom_orderdetail.InvCode= SO_SODetails.cInvCode " +

            "where  (select count(*) from  mom_orderdetail where mom_orderdetail.sodid=SO_SODetails.iSOsID  and mom_orderdetail.InvCode= SO_SODetails.cInvCode and SO_SODetails.iQuantity=mom_orderdetail.QualifiedInQty )=0  and SO_SODetails.cSCloser is null and SO_SODetails.iQuantity > ISNULL(SO_SODetails.iFHQuantity,0)  " +
            " ";
        sql += " and 1=1 ";
        //=============================================2014-10-30
        if (!"全部".Equals(DropDownList3.SelectedValue))
        {
            sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
        }
        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            sql += " and [cCusName]='" + DropDownList4.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList4.SelectedValue))
        {
            sql += " and [cCusName]='" + DropDownList4.SelectedValue + "'";
        }

        if (!string.IsNullOrEmpty(TextBox3.Text))
        {
            sql += " and SO_SOMain.cSOCode='" + TextBox3.Text.Trim() + "'";
        }

        if (!"全部".Equals(DropDownList1.SelectedValue))
        {

            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                sql += " and Person.[cPersonName]='" + DropDownList1.SelectedValue + "'";
            }
            else
            {
                sql += " and Person.[cPersonName] is null";
            }


        }

        if (!"全部".Equals(DropDownList2.SelectedValue))
        {
            sql += " and SO_SOMain.[cMaker]='" + DropDownList2.SelectedValue + "'";
        }

        if (!"全部".Equals(DropDownList5.SelectedValue))
        {
            sql +=
                "   and ((select count(*) from [CurrentStock] where  CurrentStock.[iSodid]= SO_SODetails.iSOsID and CurrentStock.cInvCode=SO_SODetails.cInvCode and CurrentStock.iQuantity>0)>0";
            sql +=
                "   or(select count(*) from [CurrentStock] where   CurrentStock.cInvCode=SO_SODetails.cInvCode and CurrentStock.iQuantity>0  and [cWhCode] in ('01','02','03','04','05','06','07','11','14','18','19','20','21','22','23','25','27','35','36','37')  )>0)";
        }



        sql += " order by dPreMoDate ";
        DataSet ds = SQLHelper.Query(sql);

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
                if (j == 14)
                {

                    string result = "";



                    HiddenField iSOsID = ((HiddenField)GridView1.Rows[i].FindControl("iSOsID"));

                    string sql = " select (CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.[iSodid]=" + iSOsID.Value + " and CurrentStock.cInvCode='" + GridView1.Rows[i].Cells[5].Text.Trim() + "' and CurrentStock.iQuantity>0 ";
                    DataSet ds1 = SQLHelper.Query(sql);
                    DataTable dt1 = ds1.Tables[0];

                   
                    if (dt1.Rows.Count == 1)
                    {
                        result = Convert.ToInt32(dt1.Rows[0][0]).ToString();
                    }
                    else if (dt1.Rows.Count == 0)
                    {
                        sql = " select count(CurrentStock.iQuantity) as xiancun from [CurrentStock] where  CurrentStock.cInvCode='" + GridView1.Rows[i].Cells[5].Text.Trim() + "' and [cWhCode] in ('01','02','03','04','05','06','07','11','14','18','19','20','21','22','23','25','27','35','36','37') and CurrentStock.iQuantity>0 ";
                        ds1 = SQLHelper.Query(sql);
                        dt1 = ds1.Tables[0];
                        if (dt1.Rows.Count == 1)
                        {
                            result = Convert.ToInt32(dt1.Rows[0][0]).ToString();
                        }
                    }

                    cells.Add((i + 2), (j + 1), result);
                }
                //else if (j == 7)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection2")).Text.Trim());
                //}
                //else if (j == 8)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection3")).Text.Trim());
                //}
                //else if (j == 9)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection4")).Text.Trim());
                //}

                //else if (j == 10)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection5")).Text.Trim());
                //}
                //else if (j == 11)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection6")).Text.Trim());
                //}
                //else if (j == 12)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection7")).Text.Trim());
                //}
                //else if (j == 13)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("labelsection8")).Text.Trim());
                //}


                //else if (j == 14)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("Label2")).Text.Trim());
                //}
                //else if (j == 15)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("Label3")).Text.Trim());
                //}
                //else if (j == 16)
                //{
                //    cells.Add((i + 2), (j + 1), ((Label)GridView1.Rows[i].FindControl("Label4")).Text.Trim());
                //}
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