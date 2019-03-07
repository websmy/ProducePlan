using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using SMB.WebControls;

public partial class WorkForms_Produce : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    //private void GetData()
    //{
    //    ViewState["ds"] = ds;
    //    Bind();

    //}

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            case "Modify":
                string AutoID = e.CommandArgument.ToString();
                string strText = ((DateTextBox)row.FindControl("dateTxtBox")).Text;
                if ("".Equals(strText))
                {
                    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = null where AutoID='" + AutoID + "'");

                }
                else
                {
                    int ret = SQLHelper.ExecuteSql("update SO_SODetails set cdefine37 = '" + strText + "' where AutoID='" + AutoID + "'");
                }
                break;

            case "BeginProdu":

                //ImageButton btnEdit = sender as ImageButton;
                //GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
                //this.UpdatePanel1.Update();
                this.HiddenField1.Value = row.Cells[0].Text;
                this.TextBox1.Text = row.Cells[1].Text;
                this.TextBox2.Text = row.Cells[2].Text;
                this.mpeFirstDialogBox.Show();

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


    protected void Bind()
    {
        //string sql =
        //   "select top 50 mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate from mom_orderdetail left join mom_order on mom_orderdetail.moid=mom_order.moid left join mom_morder on mom_orderdetail.modid=mom_morder.modid left join inventory on mom_orderdetail.InvCode=inventory.cInvCode";
        //DataSet ds = SQLHelper.Query(sql);
        //Rep1.DataSource = ds.Tables[0];

        string sql =
    "select SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.iQuantity,SO_SODetails.cdefine26,SO_SODetails.cdefine37 from [SO_SODetails] left join [SO_SOMain] on [SO_SODetails].csocode=[SO_SOMain].csocode where SO_SODetails.cSCloser is null and SO_SODetails.iQuantity > ISNULL(SO_SODetails.cdefine26,0)";
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
}