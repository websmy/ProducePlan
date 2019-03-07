using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_MomPop : System.Web.UI.Page
{
    //private string modid = "";

    //public Boolean displayed = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        modid.Value = Request.QueryString["id"];
        Qty.Value = Request.QueryString["p1"];
        if (String.IsNullOrEmpty(modid.Value))
        {
            Response.Write("<script>window.close();</script>");
            Response.Redirect("./Mom.aspx");
            Response.End();
        }
        GridView2.Columns[4].HeaderText = "基本数量 (生产数量为" + Qty.Value + "）";
        //string parValue = Request.QueryString["id"];
        //if (String.IsNullOrEmpty(parValue))
        //{
        //    Response.Write("<script>window.close();</script>");
        //    Response.Redirect("./Mom.aspx");
        //    Response.End();
        //}
        //DataSet ds = SQLHelper.Query("select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
        //                             "from mom_moallocate " +
        //                             "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
        //                             "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
        //                             "left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
        //                             "where mom_moallocate.modid=" + parValue + " and mom_moallocate.qty<>mom_moallocate.issqty  order by mom_moallocate.whcode ");
        ////this.HiddenField1.Value = row.Cells[0].Text;
        ////this.HiddenField2.Value = row.Cells[4].Text;
        ////this.HiddenField3.Value = row.Cells[3].Text;
        ////this.HiddenField4.Value = row.Cells[6].Text;

        ////this.HiddenField1.Value = Request.QueryString["p1"];
        ////this.HiddenField2.Value = Request.QueryString["p2"];
        ////this.HiddenField3.Value = Request.QueryString["p3"];
        ////this.HiddenField4.Value = Request.QueryString["p4"];
        //DataTable dt = ds.Tables[0];
        //dt.Columns.Add("rowNum");
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    dt.Rows[i]["rowNum"] = i;
        //}

        //GridView2.DataSource = dt;
        //GridView2.DataBind();

        //ViewState["dt"] = dt;
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {


    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex > -1)
        //{
        //    DataRowView row = e.Row.DataItem as DataRowView;
        //    TextBox cb = e.Row.FindControl("TextBox1") as TextBox;
        //    if (Convert.ToDouble(row["qty"]) == Convert.ToDouble(row["issqty"]))
        //    {
        //        cb.Visible = false;
        //    }
        //    else
        //    {
        //        cb.Visible = true;
        //        displayed = true;
        //    }

        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //鼠标经过时，行背景色变 
        //    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFFCC'");
        //    //鼠标移出时，行背景色变 
        //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        //}
    }
    //protected void btnLinLiao_Click(object sender, EventArgs e)
    //{
    //    return;
    //    try
    //    {
    //        List<String> SQLStringList = new List<string>();
    //        string sql = "";
    //        for (int i = 0; i < GridView2.Rows.Count; i++)
    //        {
    //            TextBox cb = GridView2.Rows[i].FindControl("TextBox1") as TextBox;
    //            HiddenField AllocateId = GridView2.Rows[i].FindControl("AllocateId") as HiddenField;
    //            HiddenField MoDId = GridView2.Rows[i].FindControl("MoDId") as HiddenField;
    //            HiddenField SortSeq = GridView2.Rows[i].FindControl("SortSeq") as HiddenField;

    //            string temp = cb.Text;
    //            if (string.IsNullOrEmpty(temp))
    //            {
    //                temp = "0";
    //            }

    //            if (cb.Visible && !"0".Equals(temp))
    //            {
    //                sql = " update mom_moallocate set IssQty = IssQty + " + temp + " where AllocateId =" +
    //                      AllocateId.Value + " and MoDId=" + MoDId.Value + " and SortSeq=" + SortSeq.Value + "";
    //                SQLStringList.Add(sql);
    //            }
    //        }

    //        DataTable dataTable = (DataTable)ViewState["dt"]; ;
    //        DataView dataView = dataTable.DefaultView;
    //        DataTable dataTableDistinct = dataView.ToTable(true, "whcode");//注：其中ToTable（）的第一个参数为是否DISTINCT
    //        //string depCode = this.HiddenField1.Value;
    //        //string cPsPcode = this.HiddenField2.Value;
    //        //string cMPoCode = this.HiddenField3.Value;
    //        //string iMQuantity = this.HiddenField4.Value;
    //        if (dataTableDistinct.Rows.Count > 0)
    //        {
    //            int curId = SQLHelper.GetMaxID("ID", "RdRecord");
    //            int autoid = SQLHelper.GetMaxID("autoID", "RdRecords");

    //            DataSet ds = SQLHelper.Query("select right('0000000000' + cast((max(cCode)+1) as varchar(10)),10) from RdRecord where ccode not like '-%'");
    //            string cCode = ds.Tables[0].Rows[0][0].ToString();
    //            //cCode = "0000500000";
    //            for (int i = 0; i < dataTableDistinct.Rows.Count; i++)
    //            {
    //                DataRow[] drs = dataTable.Select("whcode = '" + dataTableDistinct.Rows[i][0] + "'");

    //                bool mainTableAdded = false;
    //                //SQLHelper.ExecuteSql(sql);
    //                foreach (DataRow dataRow in drs)
    //                {

    //                    TextBox tb = (TextBox)this.GridView2.Rows[Convert.ToInt32(dataRow["rowNum"])].FindControl("TextBox1");

    //                    string temp = tb.Text;
    //                    if (string.IsNullOrEmpty(temp))
    //                    {
    //                        temp = "0";
    //                    }

    //                    if (!"0".Equals(temp))
    //                    {

    //                        if (!mainTableAdded)
    //                        {
    //                            //sql = "INSERT [RdRecord] ([ID], [bRdFlag], [cVouchType], [cBusType], [cSource], [cBusCode], [cWhCode], [dDate], [cCode], [cRdCode], [cDepCode], [cMaker], [iMQuantity], [VT_ID],[cPsPcode], [cMPoCode])" +
    //                            //       "VALUES (" + curId + ", 0, N'11', N'领料', N'生产订单', NULL, N'" + dataTableDistinct.Rows[i][0] + "', CAST(getdate() AS DateTime), '" + cCode + "', N'201', N'" + depCode + "', N'test', " + iMQuantity + ", 65, '" + cPsPcode + "', '" + cMPoCode + "' )";
    //                            //SQLStringList.Add(sql);
    //                            mainTableAdded = true;
    //                        }

    //                        sql = "INSERT [RdRecords] ([autoid],[ID], [cInvCode], [iQuantity]) " +
    //                                "VALUES (" + autoid + "," + curId + ", '" + dataRow["invcode"] + "', " + tb.Text + ")";
    //                        SQLStringList.Add(sql);
    //                        autoid++;

    //                    }
    //                    //SQLHelper.ExecuteSql(sql);                      
    //                }
    //                curId++;
    //                cCode = (System.Convert.ToInt32(cCode) + 1).ToString().PadLeft(10, '0');

    //            }

    //            if (SQLStringList.Count==0)
    //            {
    //                MessageBox.Show(this, "没有任何数据");
    //                return;
    //            }
    //            if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
    //            {
    //                //Response.Write("<script>alert('生成报表失败');</script>");
    //                MessageBox.Show(this, "生成报表失败");
    //                return;
    //            }
    //        }
    //        MessageBox.ShowAndClose(this, "成功生成报表");
    //        //Response.Write("<script>window.close();</script>");// 会弹出询问是否关闭
    //        //Response.Write("<script>window.opener=null;window.close();</script>");// 不会弹出询问

    //    }
    //    catch (Exception ex)
    //    {
    //        //Response.Write("<script>alert('" + ex.Message + "');</script>");
    //        MessageBox.Show(this, ex.Message);
    //    }
    //}

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<String> SQLStringList = new List<string>();
        string sql = "";
        bool ischecked = false;
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            CheckBox cb = GridView2.Rows[i].FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            MessageBox.Show(this, "没有选择任何数据");
            return;
        }

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            CheckBox cb = GridView2.Rows[i].FindControl("CheckBox1") as CheckBox;
            TextBox tb = GridView2.Rows[i].FindControl("xuqiuliang") as TextBox;
            if (cb.Checked && string.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show(this, "请输入材料编码: " + GridView2.Rows[i].Cells[2].Text + " 的数量");
                return;
            }
        }


        int AllocateId = SQLHelper.GetMaxID("AllocateId", "mom_moallocate");
        int SortSeq = SQLHelper.GetMaxIDFromSql(" SELECT max(SortSeq) FROM [mom_moallocate] where modid='"+modid.Value+"'");
        //SortSeq = SortSeq + 10;

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
           

            int PartId =
                Convert.ToInt32(
                    SQLHelper.Query("select PartId from bas_part where InvCode='" + GridView2.Rows[i].Cells[2].Text +
                                    "' ").Tables[0].Rows[0][0].ToString());
            CheckBox cb = GridView2.Rows[i].FindControl("CheckBox1") as CheckBox;
            TextBox tb = GridView2.Rows[i].FindControl("xuqiuliang") as TextBox;
            if (cb.Checked && !string.IsNullOrEmpty(tb.Text))
            {

               SortSeq = SortSeq + 10;
               if (SQLHelper.Exists("select * from [mom_moallocate] where modid=" + modid.Value + " and InvCode='" +
                                 GridView2.Rows[i].Cells[2].Text + "'"))
               {
                   MessageBox.Show(this, "材料编码: " + GridView2.Rows[i].Cells[2].Text + " 已经存在,请先将其删除掉.");
                   return;
               }
               HiddenField WhCode = GridView2.Rows[i].FindControl("WhCode") as HiddenField;
               sql = " INSERT INTO [mom_moallocate] (StartDemDate,EndDemDate,[AllocateId],[MoDId],[SortSeq],[invcode],[BaseQtyN],[BaseQtyD],[Qty],[WhCode],WIPType,OpSeq,ComponentId,ByproductFlag)" +
                      " VALUES (CONVERT(datetime, CONVERT(char(20),GETDATE(),110)),CONVERT(datetime, CONVERT(char(20),GETDATE(),110))," + AllocateId + "," + modid.Value + "," + SortSeq + ",'" + GridView2.Rows[i].Cells[2].Text + "'," + tb.Text + ",1," + Convert.ToDouble(tb.Text) * Convert.ToDouble(Qty.Value) + ",'" + WhCode.Value + "',3,'0000'," + PartId + ",0 )";
                SQLStringList.Add(sql);
                AllocateId++;
            }
        }

        if (SQLStringList.Count == 0)
        {
            MessageBox.Show(this, "没有任何数据");
            return;
        }
        if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
        {
            //Response.Write("<script>alert('生成报表失败');</script>");
            MessageBox.Show(this, "添加材料失败");
            return;
        }
        //MessageBox.ShowAndRefreshFather(this, "成功添加材料");
        MessageBox.RefreshFather(this);
    }

    //protected void uvalidate(object source, ServerValidateEventArgs args)
    //{

    //    try
    //    {

    //        // Test whether the value entered into the text box is even.
    //        int i = int.Parse(args.Value);
    //        args.IsValid = (i == 0);
    //    }

    //    catch (Exception ex)
    //    {
    //        args.IsValid = false;
    //    }

    //}
    protected void btnFilter_Click(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(TextBox1.Text.Trim()) && String.IsNullOrEmpty(TextBox2.Text.Trim()))
        {
            MessageBox.Show(this, "请输入过滤条件！");
            return;
        }

        string sql = "select * from inventory " +
                     "left join warehouse on inventory.cDefWareHouse = warehouse.[cWhCode]  " +
                     "where 1=1 ";

        if (!String.IsNullOrEmpty(TextBox1.Text))
        {
            sql += " and [cInvName] like '%" + TextBox1.Text + "%'";
        }
        if (!String.IsNullOrEmpty(TextBox2.Text))
        {
            sql += " and [cInvCode] like '%" + TextBox2.Text + "%'";
        }

        DataSet ds = SQLHelper.Query(sql);

        DataTable dataTable = ds.Tables[0];
        GridView2.DataSource = dataTable;
        GridView2.DataBind();

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        int t = GridView2.SelectedIndex;
    }
}