using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkForms_catalog_Default : System.Web.UI.Page
{
    Classes classes = new Classes();
    private string strResult = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> list1 = new List<string>();
            list1 = classes.GetAllEndChild("0");
            for (int i = 0; i < list1.Count; i++)
            {
                strResult += classes.GetRoute(list1[i].ToString()) + "<br>";
            }

            Literal1.Text = strResult;
        }
    }
}