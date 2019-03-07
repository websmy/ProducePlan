using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        Math.Round(3.4, 4);
        //string a =Context.User.Identity.Name;//用于获取当前用户名
        //string a = Page.User.Identity.Name;
        //return (new SqlMembershipProvider()).GetUser(userName, false).Comment;

    }
}
