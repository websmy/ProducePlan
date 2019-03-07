using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_Chart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            initChart();
        }
    }
    private double GetCount(string filterStr, bool isTotal)
    {
        string str = "";
        bool found = false;
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return 0;
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
            return 0;
        }

        string sql =
     " SELECT count(*) FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
    + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
    + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
    + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"

    + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 and Department.[cDepName] in (" + str + ")";
        sql += " and 1=1 ";
        sql +=
            " and convert(datetime,mom_morder.Duedate,110) < getdate() ";
        if (!isTotal && !filterStr.Equals("未知"))
        {
            sql += " and a.define25 like '" + filterStr + "%'";
        }
        else if (filterStr.Equals("未知"))
        {
            sql += " and a.define25 is null ";
        }

        //sql += " order by a.modid ";

        DataSet ds = SQLHelper.Query(sql);
        return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
    }
    private void initChart()
    {
        double total = GetCount("", true);
        if (total != 0.0)
        {

            string[] a = {"销售原因", "供应商原因", "生产原因", "设备原因", "质量原因", "技术原因","未知"};
            double[] yval = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                yval[i] = (GetCount(a[i], false) / total * 100D);
            }

            //double[] yval = { 20, 68, 40, 55, 30 };
            string[] xval = a;
            Chart1.ChartAreas[0].AxisY.Minimum = 0;
            //Chart1.ChartAreas[0].AxisY.Maximum = 100;
            Chart1.ChartAreas[0].AxisY.Title = "单位：" + "%";
            //Chart1.ChartAreas[0].AxisX.Title = "";
            Chart1.Series["Series1"].Points.DataBindXY(xval, yval);
            //Chart1.Series["Series1"].Label = "#VAL" + "%";
        }
    }


}