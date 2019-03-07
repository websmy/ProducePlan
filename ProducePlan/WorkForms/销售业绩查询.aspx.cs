using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_销售业绩查询 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFilter();




        }
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

        string sql =
            "select Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
            "from mom_orderdetail " +
            "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
            "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
            "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
            "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +
            "where mom_orderdetail.status<> 4 and mom_orderdetail.Qty <> mom_orderdetail.QualifiedInQty and mom_orderdetail.Status = 3 and Department.[cDepName] in (" +
            str + ")";

        //string sql = "select * from aViewName where 1=1 ";
        DataSet ds = SQLHelper.Query(sql);


        DataTable dataTable = ds.Tables[0];
        ;
        DataView dataView = dataTable.DefaultView;

        //DataTable dataTableDistinct3 = dataView.ToTable(true, "cDepName"); //注

        //DataRow dr3 = dataTableDistinct3.NewRow();
        //dr3["cDepName"] = "全部";
        //dataTableDistinct3.Rows.InsertAt(dr3, 0);
        //DropDownList3.DataSource = dataTableDistinct3;
        //DropDownList3.DataValueField = "cDepName";
        //DropDownList3.DataBind();

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

        //ViewState["dataTableDistinct4"] = dtTemp1;

        //DataTable dtTemp2 = dtTemp1.Copy();
        //DataRow dr4 = dtTemp2.NewRow();
        //dr4["cinvdefine4"] = "全部";
        //dtTemp2.Rows.InsertAt(dr4, 0);
        //DropDownList4.DataSource = dtTemp2;
        //DropDownList4.DataValueField = "cinvdefine4";
        //DropDownList4.DataBind();


    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {



    }




    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {

        //string[] a = new string[] { "UFDATA_201_2013", "UFDATA_201_2014", "UFDATA_201_2015", "UFDATA_201_2016" };

        //SQLHelperAny.Query("slele", "3333");
        //Chart1.Visible = true;
        Chart1.Visible = true;
        Chart2.Visible = true;
        Chart3.Visible = true;
        Chart4.Visible = true;
        //Chart1.Series["分配工时"].Points.Clear();
        //Chart1.Series["生产订单工时"].Points.Clear();
        //Chart1.Series["2013年"].Points.Clear();
        //Chart1.Series["2014年"].Points.Clear();
        //Chart1.Series["2015年"].Points.Clear();
        //Chart1.Series["2016年"].Points.Clear();

        //Chart1
        for (int i = 0; i < Chart1.Series.Count; i++)
        {
            Chart1.Series[i].Points.Clear();
            string strYear = Chart1.Series[i].Name.Substring(0, 4);
            string strDataBase = "UFDATA_201_" + strYear;
            for (int j = 1; j <= 12; j++)
            {
                string sql =
                    "SELECT   isnull(sum(iNatMoney),0)  "

                    + " FROM SO_SOMain a  "
                    //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                    //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                    //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                    //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                    + " inner join  SO_SODetails  b on b.cSOCode=a.cSOCode "

                    //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                    + " WHERE  year(a.dDate)=" + strYear + " and (month(a.dDate)=" + j + " )";
                sql += " and 1=1 ";

                Double val = 0;
                DataTable dt = SQLHelperAny.Query(sql, strDataBase).Tables[0];
                //if (dt.Rows.Count==0)
                //{

                //}
                //else
                //{
                val = Convert.ToDouble(dt.Rows[0][0]);
                //}


                Chart1.Series[i].Points.AddXY(j, val);
            }
        }

        //Chart2
        for (int i = 0; i < Chart2.Series.Count; i++)
        {
            Chart2.Series[i].Points.Clear();
            string strYear = Chart2.Series[i].Name.Substring(0, 4);
            string strDataBase = "UFDATA_201_" + strYear;
            for (int j = 1; j <= 12; j++)
            {
                string sql =
                    "SELECT   isnull(sum(iNatMoney),0)  "

                    + " FROM DispatchList a  "
                    //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                    //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                    //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                    //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                    + " inner join  DispatchLists  b on b.DLID=a.DLID "

                    //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                    + " WHERE  year(a.dDate)=" + strYear + " and (month(a.dDate)=" + j + " )";
                sql += " and 1=1 ";
                Double val = Convert.ToDouble(SQLHelperAny.Query(sql, strDataBase).Tables[0].Rows[0][0]);

                Chart2.Series[i].Points.AddXY(j, val);
            }
        }


        //Chart3
        for (int i = 0; i < Chart3.Series.Count; i++)
        {
            Chart3.Series[i].Points.Clear();
            string strYear = Chart3.Series[i].Name.Substring(0, 4);
            string strDataBase = "UFDATA_201_" + strYear;
            for (int j = 1; j <= 12; j++)
            {
                string sql =
                    "SELECT   isnull(sum(iNatMoney),0)  "

                    + " FROM [SaleBillVouch] a  "
                    //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                    //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                    //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                    //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                    + " inner join  [SaleBillVouchs]  b on b.[SBVID]=a.[SBVID] "

                    //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                    + " WHERE  year(a.dDate)=" + strYear + " and (month(a.dDate)=" + j + " )";
                sql += " and 1=1 ";
                Double val = Convert.ToDouble(SQLHelperAny.Query(sql, strDataBase).Tables[0].Rows[0][0]);

                Chart3.Series[i].Points.AddXY(j, val);
            }
        }

        //Chart4
        for (int i = 0; i < Chart4.Series.Count; i++)
        {
            Chart4.Series[i].Points.Clear();
            string strYear = Chart4.Series[i].Name.Substring(0, 4);
            string strDataBase = "UFDATA_201_" + strYear;
            for (int j = 1; j <= 12; j++)
            {
                string sql =
                    "SELECT   isnull(sum(iAmt),0)  "

                    + " FROM Ap_CloseBill a  "
                    //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                    //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                    //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                    //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                    + " inner join  Ap_CloseBills  b on b.[iID]=a.[iID] "

                    //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                    + " WHERE  year(a.[dVouchDate])=" + strYear + " and (month(a.[dVouchDate])=" + j + " )";
                sql += " and 1=1 ";
                Double val = Convert.ToDouble(SQLHelperAny.Query(sql, strDataBase).Tables[0].Rows[0][0]);

                Chart4.Series[i].Points.AddXY(j, val);
            }
        }



        //DateTime d1 = Convert.ToDateTime(txtDate.Text);
        //DateTime d2 = Convert.ToDateTime(txtDate1.Text);
        //for (DateTime i = d1; i <= d2; i = i.AddDays(1))
        //{

        //    string x = i.Month + "." + i.Day;


        //    //计算y轴值
        //    string str = "";
        //    bool found = false;
        //    Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        //    if (dic == null)
        //        return;
        //    foreach (KeyValuePair<string, string> kv in dic)
        //    {
        //        if (kv.Key.Equals(User.Identity.Name))
        //        {
        //            found = true;
        //            str = kv.Value;
        //            break;
        //        }
        //    }

        //    if (!found)
        //    {
        //        return;
        //    }

        //    //inventory.[cInvDefine14] 制作工时  inventory.[cInvDefine5] 总工时
        //    string sql =
        //        "SELECT   [mom_morder].[StartDate], [mom_morder].[DueDate], a.Qty, inventory.[cInvDefine14] "

        //        + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
        //        + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
        //        + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
        //        + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
        //        + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
        //        + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "

        //        //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

        //        + " WHERE  Department.[cDepName] in (" +
        //        str + ")";
        //    sql += " and 1=1 ";

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


        //    //if (!"".Equals(txtDate.Text))
        //    //{
        //    sql += "  and [mom_morder].[StartDate] <= '" + i + "' ";
        //    sql += "  and [mom_morder].[DueDate]  >= '" + i + "' ";
        //    //}

        //    //if (!"".Equals(txtEndDate.Text))
        //    //{
        //    //sql += "  and mom_order.CreateDate <= '" + txtEndDate.Text + "' ";
        //    //}



        //    //sql += " order by a.modid ";
        //    sql += " order by Duedate ";


        //    DataSet ds = SQLHelper.Query(sql);

        //    DataTable dt = ds.Tables[0];
        //    double temp = 0;
        //    for (int j = 0; j < dt.Rows.Count; j++)
        //    {
        //        try
        //        {
        //            temp += (Convert.ToDouble(dt.Rows[j]["Qty"]) * Convert.ToDouble(dt.Rows[j]["cInvDefine14"])) /
        //              (Convert.ToDateTime(dt.Rows[j]["DueDate"]).Subtract(Convert.ToDateTime(dt.Rows[j]["StartDate"]))
        //                    .Days + 1);
        //        }
        //        catch (Exception)
        //        {

        //            //throw;
        //        }

        //    }


        //    //开始计算
        //    temp = 0;
        //    sql = "";
        //    sql += "select * from 工时 where 1=1";

        //    if (!"全部".Equals(DropDownList3.SelectedValue))
        //    {
        //        sql += " and [部门]='" + DropDownList3.SelectedValue + "'";
        //    }
        //    if (!"全部".Equals(DropDownList4.SelectedValue))
        //    {
        //        if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
        //        {
        //            sql += " and 班组 is null ";
        //        }
        //        else
        //        {
        //            sql += " and 班组='" + DropDownList4.SelectedValue + "'";
        //        }

        //    }
        //    sql += " and 日期='" + i + "'";

        //    ds = SQLHelper1.Query(sql);
        //    dt = ds.Tables[0];
        //    for (int j = 0; j < dt.Rows.Count; j++)
        //    {
        //        temp += (Convert.ToDouble(dt.Rows[j]["人数"]) * Convert.ToDouble(dt.Rows[j]["工时"]));
        //    }
        //    Chart1.Series["分配工时"].Points.AddXY(x, temp);

        //}

        ////开始构筑Chart2============================================


        //string a = "下料,成型,焊接,附件,小叶轮,网罩,装配";
        //string[] b = a.Split(',');
        //for (int i = 0; i < b.Length; i++)
        //{
        //    //string xVal = dr["cinvdefine4"].ToString();
        //    string xVal = "一车间" + b[i] + "班";


        //    //计算y轴值
        //    string str = "";
        //    bool found = false;
        //    Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        //    if (dic == null)
        //        return;
        //    foreach (KeyValuePair<string, string> kv in dic)
        //    {
        //        if (kv.Key.Equals(User.Identity.Name))
        //        {
        //            found = true;
        //            str = kv.Value;
        //            break;
        //        }
        //    }

        //    if (!found)
        //    {
        //        return;
        //    }

        //    //inventory.[cInvDefine14] 制作工时  inventory.[cInvDefine5] 总工时
        //    string sql =
        //        "SELECT   [mom_morder].[StartDate], [mom_morder].[DueDate], a.Qty, inventory.[cInvDefine14] "

        //        + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
        //        + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
        //        + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
        //        + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
        //        + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
        //        + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "

        //        //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

        //        + " WHERE  Department.[cDepName] in (" +
        //        str + ")";
        //    sql += " and 1=1 ";

        //    //if (!"全部".Equals(DropDownList3.SelectedValue))
        //    //{
        //    //    sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
        //    //}
        //    //if (!"全部".Equals(DropDownList4.SelectedValue))
        //    //{
        //    //    if (string.IsNullOrEmpty(DropDownList4.SelectedValue))
        //    //    {
        //    //        sql += " and cinvdefine4 is null ";
        //    //    }
        //    //    else
        //    //    {
        //    //        sql += " and cinvdefine4='" + DropDownList4.SelectedValue + "'";
        //    //    }

        //    //}


        //    //if (!"".Equals(txtDate.Text))
        //    //{
        //    //这里可能写的不正确
        //    sql += "  and [mom_morder].[StartDate] <= '" + d2 + "' ";
        //    sql += "  and [mom_morder].[DueDate]  >= '" + d1 + "' ";

        //    sql += " and cinvdefine4='" + xVal + "'";
        //    //}

        //    //if (!"".Equals(txtEndDate.Text))
        //    //{
        //    //sql += "  and mom_order.CreateDate <= '" + txtEndDate.Text + "' ";
        //    //}



        //    //sql += " order by a.modid ";
        //    sql += " order by Duedate ";


        //    DataSet ds = SQLHelper.Query(sql);
        //    DataTable dt = ds.Tables[0];
        //    double temp = 0;
        //    double perday = 0;
        //    for (int j = 0; j < dt.Rows.Count; j++)
        //    {
        //        try
        //        {
        //            DateTime startDate = Convert.ToDateTime(dt.Rows[j]["StartDate"]);
        //            DateTime endDate = Convert.ToDateTime(dt.Rows[j]["DueDate"]);

        //            perday = (Convert.ToDouble(dt.Rows[j]["Qty"]) * Convert.ToDouble(dt.Rows[j]["cInvDefine14"])) /
        //              (endDate.Subtract(startDate).Days + 1);

        //            if (startDate >= d1 && startDate <= d2 && endDate >= d2)
        //            {
        //                temp = temp + (perday * (d2.Subtract(startDate).Days + 1));
        //            }
        //            else if (startDate >= d1 && startDate <= d2 && endDate <= d2)
        //            {
        //                temp = temp + (perday * (endDate.Subtract(startDate).Days + 1));
        //            }
        //            else if (startDate <= d1 && endDate >= d2)
        //            {
        //                temp = temp + (perday * (d2.Subtract(d1).Days + 1));
        //            }
        //            else if (startDate <= d1 && endDate <= d2)
        //            {
        //                temp = temp + (perday * (endDate.Subtract(d1).Days + 1));
        //            }

        //        }
        //        catch (Exception)
        //        {

        //            //throw;
        //        }

        //    }
        //    Chart1.Series["班组工时"].Points.AddXY(xVal.Replace("一车间",""), temp);

        //    //开始计算
        //    temp = 0;
        //    sql = "";
        //    sql += "select * from 工时 where 1=1";

        //    sql += " and 班组='" + xVal + "'";
        //    sql += " and 日期 between '" + d1 + "' and '" + d2 + "'";

        //    ds = SQLHelper1.Query(sql);
        //    dt = ds.Tables[0];
        //    for (int j = 0; j < dt.Rows.Count; j++)
        //    {
        //        temp += (Convert.ToDouble(dt.Rows[j]["人数"]) * Convert.ToDouble(dt.Rows[j]["工时"]));
        //    }
        //    Chart1.Series["分配工时"].Points.AddXY(xVal.Replace("一车间", ""), temp);




        //}

        //DataTable dataTable = ViewState["dataTableDistinct4"] as DataTable;
        //foreach (DataRow dr in dataTable.Rows)
        //{
        //    if (!String.IsNullOrEmpty(dr["cinvdefine4"].ToString()) && dr["cinvdefine4"].ToString().Contains("一车间"))
        //    {



        //    }
        //}


    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strYear = ddlYear.SelectedValue.Trim();
        string strMonth = ddlMonth.SelectedValue.Trim();
        string strDataBase = "UFDATA_201_" + strYear;
        string strupdown = ddlUPDown.SelectedValue;
        Dictionary<string, string> dic = new Dictionary<string, string>();

        DataTable dt = new DataTable("Table_AX");
        dt.Columns.Add("年", System.Type.GetType("System.String"));
        dt.Columns.Add("月", System.Type.GetType("System.String"));
        dt.Columns.Add("客户名称", System.Type.GetType("System.String"));
        dt.Columns.Add("金额", System.Type.GetType("System.String"));


        DataTable dt1 = new DataTable("Table_AX");
        dt1.Columns.Add("年", System.Type.GetType("System.String"));
        dt1.Columns.Add("月", System.Type.GetType("System.String"));
        dt1.Columns.Add("客户名称", System.Type.GetType("System.String"));
        dt1.Columns.Add("金额", System.Type.GetType("System.String"));

        DataTable dtBind = new DataTable("Table_Bind");
        //dtBind.Columns.Add("年", System.Type.GetType("System.String"));

        BoundField bc = new BoundField();        
        bc.DataField = "客户名称";
        bc.HeaderText = "客户名称";
        GridView1.Columns.Add(bc); 


        int firstMonth = Convert.ToInt32(ddlMonth.SelectedValue);
        for (int i = 0; i <= Convert.ToInt32(txtCount.Text.Trim()); i++)
        {
            dtBind.Columns.Add((firstMonth + i) + "月", System.Type.GetType("System.String"));

            bc = new BoundField();
            bc.DataField = (firstMonth + i) + "月";
            bc.HeaderText = (firstMonth + i) + "月";
            GridView1.Columns.Add(bc); 
            //firstMonth++;
        }


        dtBind.Columns.Add("客户名称", System.Type.GetType("System.String"));      
        dtBind.Columns.Add("金额", System.Type.GetType("System.String"));


        string sql =
                "SELECT   c.cCusCode,c.cCusName  "

                + " FROM SO_SOMain a  "
            //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                + " inner join  SO_SODetails  b on b.cSOCode=a.cSOCode "
                + " inner join  [Customer]  c on c.cCusCode=a.[cCusCode] "

                //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                + " WHERE  year(a.dDate)=" + strYear + " ";
        sql += " and 1=1 ";

        DataSet ds = SQLHelperAny.Query(sql, strDataBase);

        DataTable dataTable = ds.Tables[0];

        DataView dataView = dataTable.DefaultView;
        dataView.Sort = "cCusName ";
        DataTable dataTableDistinct4 = dataView.ToTable(true, "cCusName"); //注      
        for (int i = 0; i < dataTableDistinct4.Rows.Count; i++)
        {
            for (int j = 1; j <= 12; j++)
            {
                string sql1 =
                    "SELECT   isnull(sum(b.iNatMoney),0) as 金额"

                    + " FROM SO_SOMain a  "
                    //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                    //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                    //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                    //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                    + " inner join  SO_SODetails  b on b.cSOCode=a.cSOCode "
                    + " inner join  [Customer]  c on c.cCusCode=a.[cCusCode] "

                    //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                    + " WHERE  year(a.dDate)=" + strYear + " and month(a.dDate)=" + j + " and  c.cCusName='" +
                    dataTableDistinct4.Rows[i][0] + "'";
                sql1 += " and 1=1  ";

                DataSet ds1 = SQLHelperAny.Query(sql1, strDataBase);

                DataTable dataTable1 = ds1.Tables[0];
                //if (dataTable1.Rows.Count == 0)
                //{
                //    DataRow dr2 = dt.NewRow();
                //    dr2["年"] = strYear;
                //    dr2["月"] = j;
                //    dr2["客户名称"] = dataTableDistinct4.Rows[i][0];
                //    dr2["金额"] = "0";
                //    dt.Rows.Add(dr2);
                //    continue;
                //}


                DataRow dr = dt.NewRow();
                dr["年"] = strYear;
                dr["月"] = j;
                dr["客户名称"] = dataTableDistinct4.Rows[i][0];
                dr["金额"] = dataTable1.Rows[0][0];
                dt.Rows.Add(dr);

            }
        }

        List<int> a = new List<int>();
        int currMonth = Convert.ToInt32(ddlMonth.SelectedValue);
        currMonth++;
        for (int i = 0; i < Convert.ToInt32(txtCount.Text); i++)
        {
            a.Add(currMonth);
            currMonth++;
        }


        DataRow[] drss = dt.Select("年 = '" + strYear + "' and 月='" + ddlMonth.SelectedValue + "' ");
        foreach (DataRow dataRow in drss)
        {

            double temp = Convert.ToDouble(dataRow["金额"]);
            for (int i = 0; i < a.Count; i++)
            {
                DataRow[] dr1 = dt.Select("年 = '" + strYear + "' and 月='" + a[i] + "' and 客户名称='" + dataRow["客户名称"] + "'   ");
                if (dr1.Length == 0) goto abc;
                double temp1 = Convert.ToDouble(dr1[0]["金额"]);
                if (">".Equals(strupdown))
                {
                    if (temp1 > temp)
                    {

                    }
                    else
                    {
                        goto abc;
                    }
                }
                else
                {
                    if (temp1 < temp)
                    {

                    }
                    else
                    {
                        goto abc;
                    }
                }
            }

            //DataRow dr = dtBind.NewRow();



            dt1.Rows.Add(dataRow.ItemArray);
            for (int i = 0; i < a.Count; i++)
            {
                DataRow[] dr1 = dt.Select("年 = '" + strYear + "' and 月='" + a[i] + "' and 客户名称='" + dataRow["客户名称"] + "'   ");
                dt1.Rows.Add(dr1[0].ItemArray);
            }
        abc:
            ;

        }

        //=================
        firstMonth = Convert.ToInt32(ddlMonth.SelectedValue);
        for (int i = 0; i < dt1.Rows.Count; )
        {
            DataRow drBind = dtBind.NewRow();
            drBind["客户名称"] = dt1.Rows[i]["客户名称"];

            for (int j = 0; j <= Convert.ToInt32(txtCount.Text.Trim()); j++)
            {
                drBind[(firstMonth + j) + "月"] = dt1.Rows[i++]["金额"];
                //dtBind.Columns.Add((firstMonth + i) + "月", System.Type.GetType("System.String"));
                //firstMonth++;

            }
            dtBind.Rows.Add(drBind);
        }


        //dr["年"] = strYear;
        //dr["年"] = strYear;
        //dr["年"] = strYear;

        //for (int i = 0; i <= Convert.ToInt32(txtCount.Text.Trim()); i++)
        //{
        //    dtBind.Columns.Add((firstMonth + i) + "月", System.Type.GetType("System.String"));
        //    //firstMonth++;
        //}


        //dtBind.Columns.Add("客户名称", System.Type.GetType("System.String"));
        //dtBind.Columns.Add("金额", System.Type.GetType("System.String"));


        GridView1.DataSource = dtBind;
        GridView1.DataBind();
        //===============



        dic.Add("请选择", "请选择");

        //for (int i = 0; i < Chart1.Series.Count; i++)
        //{
        //    Chart1.Series[i].Points.Clear();
        //    string strYear = Chart1.Series[i].Name.Substring(0, 4);
        //    string strDataBase = "UFDATA_201_" + strYear;
        //    for (int j = 1; j < 12; j++)
        //    {
        //        string sql =
        //            "SELECT   isnull(sum(iNatMoney),0)  "

        //            + " FROM SO_SOMain a  "
        //            //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
        //            //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
        //            //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
        //            //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
        //            + " inner join  SO_SODetails  b on b.cSOCode=a.cSOCode "

        //            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

        //            + " WHERE  year(a.dDate)=" + strYear + " and (month(a.dDate)=" + j + " )";
        //        sql += " and 1=1 ";
        //        Double val = Convert.ToDouble(SQLHelperAny.Query(sql, strDataBase).Tables[0].Rows[0][0]);

        //        Chart1.Series[i].Points.AddXY(j, val);
        //    }
        //}
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strYear = ddlYear.SelectedValue.Trim();
        string strDataBase = "UFDATA_201_" + strYear;

        if (!"请选择".Equals(strYear))
        {
            string sql =
                      "SELECT   c.cCusCode,c.cCusName  "

                      + " FROM SO_SOMain a  "
                //+ " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                //+ " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                //+ " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                //+ " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                      + " inner join  SO_SODetails  b on b.cSOCode=a.cSOCode "
                      + " inner join  [Customer]  c on c.cCusCode=a.[cCusCode] "

                      //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

                      + " WHERE  year(a.dDate)=" + strYear + " ";
            sql += " and 1=1 ";

            DataSet ds = SQLHelperAny.Query(sql, strDataBase);

            DataTable dataTable = ds.Tables[0];

            DataView dataView = dataTable.DefaultView;
            //dataView.Sort = "cDepName ";
            //DataTable dataTableDistinct3 = dataView.ToTable(true, "cDepName"); //注

            //DataRow dr3 = dataTableDistinct3.NewRow();
            //dr3["cDepName"] = "全部";
            //dataTableDistinct3.Rows.InsertAt(dr3, 0);
            //DropDownList3.DataSource = dataTableDistinct3;
            //DropDownList3.DataValueField = "cDepName";
            //DropDownList3.DataBind();

            dataView.Sort = "cCusName ";
            DataTable dataTableDistinct4 = dataView.ToTable(true, "cCusName"); //注      
            //DataTable dtTemp = dataTableDistinct4.Copy();
            DataRow dr4 = dataTableDistinct4.NewRow();
            dr4["cCusName"] = "全部";
            dataTableDistinct4.Rows.InsertAt(dr4, 0);
            ddlCustomer.DataSource = dataTableDistinct4;
            ddlCustomer.DataValueField = "cCusName";
            ddlCustomer.DataBind();


            //if (!"请选择".Equals(ddlYear.SelectedValue))
            //{
            //    Dictionary<string, string> dic = new Dictionary<string, string>();
            //    dic.Add("请选择", "请选择");

            //    DataTable dt =
            //        SQLHelper1.Query("select id,承运商 from [承运商] ").
            //            Tables[0];

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        string temp0 = dt.Rows[i][0].ToString().Trim();
            //        string temp1 = dt.Rows[i][1].ToString().Trim();
            //        dic.Add(temp1, temp0);
            //    }

            //    ddl承运商.DataSource = dic;
            //    ddl承运商.DataTextField = "Key";
            //    ddl承运商.DataValueField = "Value";
        }
    }


}