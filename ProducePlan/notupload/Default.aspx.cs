using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //MembershipCreateStatus status;
        // Create Bill

        if (!Roles.RoleExists("Manager"))
        {
            Roles.CreateRole("Manager");
        }
        // Create Worker Role
        if (!Roles.RoleExists("Worker"))
        {
            Roles.CreateRole("Worker");

        }

        //Membership.CreateUser("王文", "12345678");
        //Membership.CreateUser("张雪菲", "12345678");
        //Roles.AddUserToRole("唐明飞", "Worker");
        //Roles.AddUserToRole("唐明飞", "Manager");

        // Create Ted
        //Membership.CreateUser("Ted", "secret_", "ted@somewhere.com", "dog", "rover", true, out status);
        // Create Fred
        //Membership.CreateUser("Fred", "secret_", "fred@somewhere.com", "dog", "rover", true, out status);
        // Create Administrator Role        
        //if (!Roles.RoleExists("Administrator"))
        //{
        //    Roles.CreateRole("Administrator");
        //    Roles.AddUserToRole("Bill", "Administrator");
        //}
        // Create Manager Role

        //Membership.CreateUser("孙卫防", "12345678");
        //Membership.CreateUser("2", "12345678");
        //Roles.AddUserToRole("孙卫防", "Manager");

        //Roles.RemoveUserFromRole("王文","Manager");
        //Roles.AddUserToRole("王文", "Worker");
        //Roles.AddUserToRole("2", "Worker");
        //Roles.AddUserToRole("Bill", "Manager");
        //Roles.AddUserToRole("Ted", "Manager");
    }

    public string aaaa = string.Empty;
    protected void Button1_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return;
        foreach (KeyValuePair<string, string> kv in dic)
            aaaa += "<Br />" + kv.Key + ":" + kv.Value;
    }



}