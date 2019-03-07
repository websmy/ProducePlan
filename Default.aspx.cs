using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using SMB.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData();
        }
    }

    private void GetData()
    {
        string sql =
            "select SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.iQuantity,SO_SODetails.cdefine26,SO_SODetails.cdefine37 from [SO_SODetails] left join [SO_SOMain] on [SO_SODetails].csocode=[SO_SOMain].csocode where SO_SODetails.cSCloser is null and SO_SODetails.iQuantity > ISNULL(SO_SODetails.cdefine26,0)";
        DataSet ds = SQLHelper.Query(sql);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

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
