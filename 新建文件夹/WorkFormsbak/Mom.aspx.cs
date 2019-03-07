using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using SMB.WebControls;

public partial class WorkForms_Sale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            case "GetMaterial":
                string parValue = e.CommandArgument.ToString();
                //string strText = ((DateTextBox)row.FindControl("dateTxtBox")).Text;

                //if ("".Equals(strText))
                //{
                DataSet ds = SQLHelper.Query("select mom_orderdetail.MDeptCode,mom_moallocate.whcode,mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty,CurrentStock.iQuantity - CurrentStock.fOutQuantity xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling from mom_moallocate left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid left join inventory on mom_moallocate.invcode = inventory.cinvcode left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode where mom_moallocate.modid=" + parValue);
                //}
                //else
                //{
                //    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + parValue + "'");
                //}

                this.HiddenField1.Value = row.Cells[0].Text;
                this.HiddenField2.Value = row.Cells[4].Text;
                this.HiddenField3.Value = row.Cells[3].Text;
                this.HiddenField4.Value = row.Cells[6].Text;
                DataTable dt = ds.Tables[0];
                dt.Columns.Add("rowNum");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["rowNum"] = i;
                }

                GridView2.DataSource = dt;
                GridView2.DataBind();

                ViewState["dt"] = dt;

                this.mpeFirstDialogBox.Show();

                break;


            default:
                break;
        }

    }


    protected void Bind()
    {
        //string sql =
        //   "select top 50 mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate from mom_orderdetail left join mom_order on mom_orderdetail.moid=mom_order.moid left join mom_morder on mom_orderdetail.modid=mom_morder.modid left join inventory on mom_orderdetail.InvCode=inventory.cInvCode";
        //DataSet ds = SQLHelper.Query(sql);
        //Rep1.DataSource = ds.Tables[0];


        string sql =
           "select mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate from mom_orderdetail left join mom_order on mom_orderdetail.moid=mom_order.moid left join mom_morder on mom_orderdetail.modid=mom_morder.modid left join inventory on mom_orderdetail.InvCode=inventory.cInvCode where mom_orderdetail.status<> 4";
        DataSet ds = SQLHelper.Query(sql);

        int curpage = Convert.ToInt32(this.labPage.Text);//获取当前页数
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
        ps.PageSize = 3;
        //设置当前索引
        ps.CurrentPageIndex = curpage - 1;
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

        //关闭数据源
        //con.Close();
    }
    protected void lnkbtnFirst_Click(object sender, EventArgs e)
    {
        labPage.Text = "1";
        Bind();
    }
    protected void lnkbtnFront_Click(object sender, EventArgs e)
    {
        labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) - 1);
        Bind();
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) + 1);
        Bind();
    }
    protected void linkbtnLast_Click(object sender, EventArgs e)
    {
        labPage.Text = this.labBackPage.Text;
        Bind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('生成报表失败');</script>");
        //this.ClientScript.RegisterStartupScript(this.GetType(), "message", "<script language='javascript'>alert('" + "生成报表失败".ToString() + "');</script>");
        try
        {
            DataTable dataTable = (DataTable)ViewState["dt"]; ;
            DataView dataView = dataTable.DefaultView;
            DataTable dataTableDistinct = dataView.ToTable(true, "whcode");//注：其中ToTable（）的第一个参数为是否DISTINCT
            string depCode = this.HiddenField1.Value;
            string cPsPcode = this.HiddenField2.Value;
            string cMPoCode = this.HiddenField3.Value;
            string iMQuantity = this.HiddenField4.Value;
            if (dataTableDistinct.Rows.Count > 0)
            {
                List<String> SQLStringList = new List<string>();
                int curId = SQLHelper.GetMaxID("ID", "RdRecord") + 1;

                DataSet ds = SQLHelper.Query("select right('0000000000' + cast((max(cCode)+1) as varchar(10)),10) from RdRecord");
                string cCode = ds.Tables[0].Rows[0][0].ToString();

                for (int i = 0; i < dataTableDistinct.Rows.Count; i++)
                {
                    DataRow[] drs = dataTable.Select("whcode = '" + dataTableDistinct.Rows[i][0] + "'");
                    string sql = "INSERT [RdRecord] ([ID], [bRdFlag], [cVouchType], [cBusType], [cSource], [cBusCode], [cWhCode], [dDate], [cCode], [cRdCode], [cDepCode], [cMaker], [iMQuantity], [VT_ID],[cPsPcode], [cMPoCode],iMQuantity)" +
                                  "VALUES (" + curId + ", 0, N'11', N'领料', N'生产订单', NULL, N'" + dataTableDistinct.Rows[i][0] + "', CAST(getdate() AS DateTime), '" + cCode + "', N'201', N'" + depCode + "', N'test', 3, 65, '" + cPsPcode + "', '" + cMPoCode + "', " + iMQuantity + " )";
                    SQLStringList.Add(sql);
                    //SQLHelper.ExecuteSql(sql);
                    foreach (DataRow dataRow in drs)
                    {
                        TextBox tb = (TextBox)this.GridView2.Rows[Convert.ToInt32(dataRow["rowNum"])].FindControl("TextBox1");

                        sql = "INSERT [RdRecords] ([ID], [cInvCode], [iQuantity]) " +
                              "VALUES (" + curId + ", '" + dataRow["invcode"] + "', " + tb.Text + ")";
                        SQLStringList.Add(sql);
                        //SQLHelper.ExecuteSql(sql);                      
                    }
                    curId++;
                    cCode = (System.Convert.ToInt32(cCode) + 1).ToString().PadLeft(10, '0');

                }

                if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                {
                    Response.Write("<script>alert('生成报表失败');</script>");
                    return;
                }
            }
            //MessageBox.Show(this, "生成报表失败");

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");  
        }

       
    }
}