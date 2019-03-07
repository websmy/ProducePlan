using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_cmlc : System.Web.UI.Page
{
    private const string fromthedate = "2016-08-31";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindFilter();
            SetViewState();
            Bind(true);


            //btnXiaLiao.Attributes.Add("onclick", "return confirm('" + "确定要对所选择的项进行下料吗？" + "');");
            //BtnFinish.Attributes.Add("onclick", "return confirm('" + "选择的项已经完成下料了吗？" + "');");

        }
    }

    private void SetViewState()
    {
        string str = "";
        bool found = false;
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return;
        foreach (KeyValuePair<string, string> kv in dic)
        {
            if (kv.Key.Equals(User.Identity.Name + "_cmlc"))
            {
                found = true;
                str = kv.Value;
                break;
            }
        }

        ViewState["status"] = str;


    }

    protected void Bind(bool isFirstPage)
    {
        //string str = "";
        //bool found = false;
        //Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        //if (dic == null)
        //    return;
        //foreach (KeyValuePair<string, string> kv in dic)
        //{
        //    if (kv.Key.Equals(User.Identity.Name + "_cmlc"))
        //    {
        //        found = true;
        //        str = kv.Value;
        //        break;
        //    }
        //}

        //if (!found)
        //{
        //    return;
        //}

        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration1//DataBaseName").InnerText.Trim();

        string sql = "";
        //if (!"全部".Equals(DropDownList3.SelectedValue))
        //{
        //    sql += " and [cDepName]='" + DropDownList3.SelectedValue + "'";
        //}
        if (!"全部".Equals(DropDownList4.SelectedValue) && !"1".Equals(DropDownList4.SelectedValue))
        {
            sql =
      "  SELECT *  FROM ("

      + "SELECT bb.AutoID as autoid,'计划订单发货单' AS 单据类型,aa.cDLCode AS 单号,aa.ddate as 发货日期, aa.cCusName AS 客户,                                                                                                                       "
      + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=bb.cinvCode) AS 存货名称,aa.cMemo AS 备注,bb.iQuantity AS 数量,bb.iNatSum AS 金额,aa.cMaker                                                                                   "
      + " FROM DispatchList aa inner JOIN DispatchLists bb ON aa.DLID=bb.DLID WHERE aa.ddate>= '" + fromthedate + "'  and bb.iQuantity >=0                                                                                                                                                                     "
      + "                                                                                                                                                                                                                                                                                                                                           "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "
                //+ "SELECT bb.AutoID as autoid,'计划订单退货单' AS 单据类型,aa.cDLCode AS 单号,aa.ddate as 发货日期, aa.cCusName AS 客户,                                                                                                                       "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=bb.cinvCode) AS 存货名称,aa.cMemo AS 备注,bb.iQuantity AS 数量,bb.iNatSum AS 金额,aa.cMaker                                                                                   "
                //+ " FROM DispatchList aa inner JOIN DispatchLists bb ON aa.DLID=bb.DLID WHERE aa.ddate>= '" + fromthedate + "'  and bb.iQuantity <0                                                                                                                                                                     "
                //+ "                                                                                                                                                                                                                                                                                                                                           "
      + " UNION                                                                                                                                                                                                                                                                                                                               "

      + "                                                                                                                                                                                                                                                                                                                                           "
      + " SELECT dd.AutoID as autoid,'材料出库单' AS 单据类型,cc.cCode AS 单号,cc.ddate as 发货日期, cc.cDefine1 AS 客户,                                                                                                                                                                "
      + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=dd.cinvCode) AS 存货名称,cc.cMemo AS 备注,dd.iQuantity AS 数量,dd.iPrice AS 金额,cc.cMaker                                                                                         "
      + " FROM RdRecord cc inner JOIN RdRecords dd ON cc.ID = dd.ID AND cc.cBusType='领料' AND cc.cRdCode='206'  WHERE cc.ddate>= '" + fromthedate + "'     and dd.iQuantity >=0                                                                                                           "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "

      //+ "                                                                                                                                                                                                                                                                                                                                           "
                //+ " SELECT dd.AutoID as autoid,'材料出库单退货单' AS 单据类型,cc.cCode AS 单号,cc.ddate as 发货日期, cc.cDefine1 AS 客户,                                                                                                                                                                "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=dd.cinvCode) AS 存货名称,cc.cMemo AS 备注,dd.iQuantity AS 数量,dd.iPrice AS 金额,cc.cMaker                                                                                         "
                //+ " FROM RdRecord cc inner JOIN RdRecords dd ON cc.ID = dd.ID AND cc.cBusType='领料' AND cc.cRdCode='206'  WHERE cc.ddate>= '" + fromthedate + "'     and dd.iQuantity <0                                                                                                           "
      + "                                                                                                                                                                                                                                                                                                                                           "
      + "                                                                                                                                                                                                                                                                                                                                           "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "
                //+ "                                                                                                                                                                                                                                                                                                                                           "
                //+ " SELECT ff.AutoID as autoid,'调拨单' AS 单据类型,ee.cTVCode AS 单号,ee.dtvdate as 发货日期, '' AS 客户,                                                                                                                                                                                "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=ff.cinvCode) AS 存货名称,ee.cTVMemo AS 备注,ff.iTVQuantity AS 数量,ff.iTVAPrice AS 金额,ee.cMaker                                                                               "
                //+ " FROM TransVouch ee inner JOIN TransVouchs ff ON ee.cTVCode = ff.cTVCode AND (ee.cOWhCode='09' or ee.cIWhCode='09')  WHERE ee.dtvdate>= '" + fromthedate + "' 
            + "   ) AS temp            "

    + "inner join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[cmlc] as cmlc on  temp.autoid= cmlc.单号autoid  "
    + "   left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[承运商] as 承运商 on  cmlc.承运商= 承运商.id  "

+ "  ";
            //sql += " and 1=1 ";

            sql += " where cmlc.status='" + DropDownList4.SelectedValue + "'";


        }
        else if ("1".Equals(DropDownList4.SelectedValue))
        {
            sql =
   "  SELECT *  FROM (SELECT bb.AutoID as autoid,'计划订单发货单' AS 单据类型,aa.cDLCode AS 单号,aa.ddate as 发货日期, aa.cCusName AS 客户,                                                                                                                       "
   + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=bb.cinvCode) AS 存货名称,aa.cMemo AS 备注,bb.iQuantity AS 数量,bb.iNatSum AS 金额,aa.cMaker                                                                                   "
   + " FROM DispatchList aa inner JOIN DispatchLists bb ON aa.DLID=bb.DLID WHERE aa.ddate>= '" + fromthedate + "'        and bb.iQuantity >=0                                                                                                                                                                  "

      //+ " UNION                                                                                                                                                                                                                                                                                                                               "
                //+ "SELECT bb.AutoID as autoid,'计划订单退货单' AS 单据类型,aa.cDLCode AS 单号,aa.ddate as 发货日期, aa.cCusName AS 客户,                                                                                                                       "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=bb.cinvCode) AS 存货名称,aa.cMemo AS 备注,bb.iQuantity AS 数量,bb.iNatSum AS 金额,aa.cMaker                                                                                   "
                //+ " FROM DispatchList aa inner JOIN DispatchLists bb ON aa.DLID=bb.DLID WHERE aa.ddate>= '" + fromthedate + "'  and bb.iQuantity <0                                                                                                                                                                     "
                //+ "                                                                                                                                                                                                                                                                                                                                           "
   + "                                                                                                                                                                                                                                                                                                                                           "
   + " UNION                                                                                                                                                                                                                                                                                                                               "
   + "                                                                                                                                                                                                                                                                                                                                           "
   + " SELECT dd.AutoID as autoid,'材料出库单' AS 单据类型,cc.cCode AS 单号,cc.ddate as 发货日期, cc.cDefine1 AS 客户,                                                                                                                                                                "
   + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=dd.cinvCode) AS 存货名称,cc.cMemo AS 备注,dd.iQuantity AS 数量,dd.iPrice AS 金额,cc.cMaker                                                                                         "
   + " FROM RdRecord cc inner JOIN RdRecords dd ON cc.ID = dd.ID AND cc.cBusType='领料' AND cc.cRdCode='206'  WHERE cc.ddate>= '" + fromthedate + "'       and dd.iQuantity >=0                                                                                                           "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "

     // + "                                                                                                                                                                                                                                                                                                                                           "
                // + " SELECT dd.AutoID as autoid,'材料出库单退货单' AS 单据类型,cc.cCode AS 单号,cc.ddate as 发货日期, cc.cDefine1 AS 客户,                                                                                                                                                                "
                // + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=dd.cinvCode) AS 存货名称,cc.cMemo AS 备注,dd.iQuantity AS 数量,dd.iPrice AS 金额,cc.cMaker                                                                                         "
                // + " FROM RdRecord cc inner JOIN RdRecords dd ON cc.ID = dd.ID AND cc.cBusType='领料' AND cc.cRdCode='206'  WHERE cc.ddate>= '" + fromthedate + "'     and dd.iQuantity <0                                                                                                           "
                //+ "                                                                                                                                                                                                                                                                                                                                           "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "
                //+ "                                                                                                                                                                                                                                                                                                                                           "
                //+ " SELECT ff.AutoID as autoid,'调拨单' AS 单据类型,ee.cTVCode AS 单号,ee.dtvdate as 发货日期, '' AS 客户,                                                                                                                                                                                "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=ff.cinvCode) AS 存货名称,ee.cTVMemo AS 备注,ff.iTVQuantity AS 数量,ff.iTVAPrice AS 金额,ee.cMaker                                                                               "
                //+ " FROM TransVouch ee inner JOIN TransVouchs ff ON ee.cTVCode = ff.cTVCode AND (ee.cOWhCode='09' or ee.cIWhCode='09')  WHERE ee.dtvdate>= '" + fromthedate + "' " +
  + "  ) AS temp            "

 + "left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[cmlc] as cmlc on  temp.autoid= cmlc.单号autoid  "
    + "   left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[承运商] as 承运商 on  cmlc.承运商= 承运商.id  "

+ "  ";
            //sql += " and 1=1 ";

            sql += " where cmlc.status is null ";
        }
        else
        {
            sql =
      "  SELECT *  FROM (SELECT bb.AutoID as autoid,'计划订单发货单' AS 单据类型,aa.cDLCode AS 单号,aa.ddate as 发货日期, aa.cCusName AS 客户,                                                                                                                       "
      + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=bb.cinvCode) AS 存货名称,aa.cMemo AS 备注,bb.iQuantity AS 数量,bb.iNatSum AS 金额,aa.cMaker                                                                                   "
      + " FROM DispatchList aa inner JOIN DispatchLists bb ON aa.DLID=bb.DLID WHERE aa.ddate>= '" + fromthedate + "'      and bb.iQuantity >=0                                                                                                                                                                    "

      //+ " UNION                                                                                                                                                                                                                                                                                                                               "
                //+ "SELECT bb.AutoID as autoid,'计划订单退货单' AS 单据类型,aa.cDLCode AS 单号,aa.ddate as 发货日期, aa.cCusName AS 客户,                                                                                                                       "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=bb.cinvCode) AS 存货名称,aa.cMemo AS 备注,bb.iQuantity AS 数量,bb.iNatSum AS 金额,aa.cMaker                                                                                   "
                //+ " FROM DispatchList aa inner JOIN DispatchLists bb ON aa.DLID=bb.DLID WHERE aa.ddate>= '" + fromthedate + "'  and bb.iQuantity <0                                                                                                                                                                     "
      + "                                                                                                                                                                                                                                                                                                                                           "
      + "                                                                                                                                                                                                                                                                                                                                           "
      + " UNION                                                                                                                                                                                                                                                                                                                               "
      + "                                                                                                                                                                                                                                                                                                                                           "
      + " SELECT dd.AutoID as autoid,'材料出库单' AS 单据类型,cc.cCode AS 单号,cc.ddate as 发货日期, cc.cDefine1 AS 客户,                                                                                                                                                                "
      + " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=dd.cinvCode) AS 存货名称,cc.cMemo AS 备注,dd.iQuantity AS 数量,dd.iPrice AS 金额,cc.cMaker                                                                                         "
      + " FROM RdRecord cc inner JOIN RdRecords dd ON cc.ID = dd.ID AND cc.cBusType='领料' AND cc.cRdCode='206'  WHERE cc.ddate>= '" + fromthedate + "'        and dd.iQuantity >=0                                                                                                          "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "

      //+ "                                                                                                                                                                                                                                                                                                                                           "
                //+ " SELECT dd.AutoID as autoid,'材料出库单退货单' AS 单据类型,cc.cCode AS 单号,cc.ddate as 发货日期, cc.cDefine1 AS 客户,                                                                                                                                                                "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=dd.cinvCode) AS 存货名称,cc.cMemo AS 备注,dd.iQuantity AS 数量,dd.iPrice AS 金额,cc.cMaker                                                                                         "
                //+ " FROM RdRecord cc inner JOIN RdRecords dd ON cc.ID = dd.ID AND cc.cBusType='领料' AND cc.cRdCode='206'  WHERE cc.ddate>= '" + fromthedate + "'     and dd.iQuantity <0                                                                                                           "
     + "                                                                                                                                                                                                                                                                                                                                           "
                //+ " UNION                                                                                                                                                                                                                                                                                                                               "
                //+ "                                                                                                                                                                                                                                                                                                                                           "
                //+ " SELECT ff.AutoID as autoid,'调拨单' AS 单据类型,ee.cTVCode AS 单号,ee.dtvdate as 发货日期, '' AS 客户,                                                                                                                                                                                "
                //+ " (SELECT Inventory.cInvName FROM Inventory WHERE cInvCode=ff.cinvCode) AS 存货名称,ee.cTVMemo AS 备注,ff.iTVQuantity AS 数量,ff.iTVAPrice AS 金额,ee.cMaker                                                                               "
                //+ " FROM TransVouch ee inner JOIN TransVouchs ff ON ee.cTVCode = ff.cTVCode AND (ee.cOWhCode='09' or ee.cIWhCode='09')  WHERE ee.dtvdate>= '" + fromthedate + "' " +
      + "  ) AS temp            "

//string sql =
                //    "SELECT  distinct invcode,  mom_morder.DueDate,SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],a.SoCode,"
                //    +
                //    " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
                //    + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
                //    + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
                //    + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
                //    + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
                //    + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
                //    + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "

    + "left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[cmlc] as cmlc on  temp.autoid= cmlc.单号autoid  "
    + "   left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[承运商] as 承运商 on  cmlc.承运商= 承运商.id  "

    //+ " WHERE   Department.[cDepName] in (" + str + ")  and [cinvdefine4] in ('一车间成型班','一车间附件班','一车间网罩班','一车间小叶轮班','一车间焊接班')";
+ "  ";
            sql += " where 1=1 ";

        }
        //if (!"".Equals(TextBox1.Text))
        //{
        //    if (string.IsNullOrEmpty(TextBox1.Text))
        //    {
        //        //sql += " and mom_orderdetail.SoCode is null ";
        //        //sql += " and mom_orderdetail.SoCode is null ";
        //    }
        //    else
        //    {
        //        sql += " and SoCode='" + TextBox1.Text.Trim() + "'";
        //    }
        //}
        if (!"".Equals(TextBox2.Text))
        {
            if (string.IsNullOrEmpty(TextBox2.Text))
            {

            }
            else
            {
                sql += " and temp.单号='" + TextBox2.Text.Trim() + "'";
            }
        }

        if (!string.IsNullOrEmpty(txtStartDate.Text.Trim()))
        {
            sql += " and temp.发货日期 >='" + txtStartDate.Text.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(txtEndDate.Text.Trim()))
        {
            sql += " and temp.发货日期 <='" + txtEndDate.Text.Trim() + "'";
        }

        //sql += " and rdrecord.ddate >='" + txtStartDate.Text + "' and rdrecord.ddate <='" + txtEndDate.Text + "'

        //btnXiaLiao.Visible = true;
        //btnReXiaLiao.Visible = false;
        //if (!"全部".Equals(DropDownList6.SelectedValue))
        //{
        //if ("未下料".Equals(DropDownList6.SelectedValue))
        //{
        //    sql += "and xl.MoDId is  null and a.Status = 3 ";
        //    btnXiaLiao.Visible = true;
        //    btnReXiaLiao.Visible = false;
        //    BtnFinish.Visible = false;
        //}
        //else if ("正下料".Equals(DropDownList6.SelectedValue))
        //{
        //    sql += "and xl.MoDId is  not null  and  xl.flag=1 and (a.Status = 3 or a.Status = 4)";
        //    btnXiaLiao.Visible = false;
        //    btnReXiaLiao.Visible = true;
        //    BtnFinish.Visible = true;

        //}
        //else if ("已下料".Equals(DropDownList6.SelectedValue))
        //{
        //    sql += "and xl.MoDId is  not null and  xl.flag=2 and (a.Status = 3 or a.Status = 4)";
        //    btnXiaLiao.Visible = false;
        //    btnReXiaLiao.Visible = false;
        //    BtnFinish.Visible = false;

        //}
        //else if ("不下料".Equals(DropDownList6.SelectedValue))
        //{
        //    sql += "and xl.MoDId is  not null and  xl.flag=3 and (a.Status = 3 or a.Status = 4)";
        //    btnXiaLiao.Visible = false;
        //    btnReXiaLiao.Visible = false;
        //    BtnFinish.Visible = false;

        //}

        //if (User.Identity.Name.Equals("销售部"))
        //{
        //    btnXiaLiao.Visible = false;
        //    btnReXiaLiao.Visible = false;
        //    BtnFinish.Visible = false;
        //    btnNoXiaLiao.Visible = false;
        //    HyperLink1.Visible = false;
        //}
        //}

        sql += " ORDER BY temp.发货日期, temp.单号 ";


        DataSet ds = SQLHelper.Query(sql);

        int curpage = Convert.ToInt32(this.labPage.Text); //获取当前页数

        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = ds.Tables[0].DefaultView;

        //启用分页
        ps.AllowPaging = true;
        //设置每页为3条数据
        ps.PageSize = 30;
        //设置当前索引

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
        //ViewState["ds"] = GridView1.DataSource;
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

    //private void BindFilter()
    //{
    //    string str = "";
    //    bool found = false;
    //    Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
    //    if (dic == null)
    //        return;
    //    foreach (KeyValuePair<string, string> kv in dic)
    //    {
    //        if (kv.Key.Equals(User.Identity.Name + "_xialiao"))
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
    //    string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
    //    string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration1//DataBaseName").InnerText.Trim();

    //    string sql =
    //        "select Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
    //        "from mom_orderdetail " +
    //        "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
    //        "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
    //        "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
    //        "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +

    //        "left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[xialiao_flag] as xl on  mom_orderdetail.MoDId= xl.MoDId  " +

    //        "where  mom_orderdetail.Status = 3 and Department.[cDepName] in (" +
    //        str + ") and [cinvdefine4] in ('一车间成型班','一车间附件班','一车间网罩班','一车间小叶轮班','一车间焊接班')";

    //    //string sql = "select * from aViewName where 1=1 ";
    //    DataSet ds = SQLHelper.Query(sql);


    //    DataTable dataTable = ds.Tables[0];

    //    DataView dataView = dataTable.DefaultView;

    //    DataTable dataTableDistinct3 = dataView.ToTable(true, "cDepName"); //注

    //    DataTable dtTempTpf = dataTableDistinct3.Copy();
    //    DataView dvTPF = dtTempTpf.DefaultView;
    //    dvTPF.Sort = "cDepName";
    //    dtTempTpf = dvTPF.ToTable();

    //    DataRow dr3 = dtTempTpf.NewRow();
    //    dr3["cDepName"] = "全部";
    //    dtTempTpf.Rows.InsertAt(dr3, 0);
    //    DropDownList3.DataSource = dtTempTpf;
    //    DropDownList3.DataValueField = "cDepName";
    //    DropDownList3.DataBind();



    //    DataTable dataTableDistinct4 = dataView.ToTable(true, "cinvdefine4"); //注      
    //    DataTable dtTemp = dataTableDistinct4.Copy();
    //    DataTable dtTemp1 = dtTemp.Copy();
    //    dtTemp1.Rows.Clear();

    //    for (int i = 0; i < dtTemp.Rows.Count; i++)
    //    {
    //        int cnt = 0;
    //        if (String.IsNullOrEmpty(dtTemp.Rows[i]["cinvdefine4"].ToString()))
    //        {
    //            cnt++;
    //        }

    //        if (cnt >= 2)
    //        {
    //            //dtTemp.Rows[i].Delete();
    //        }
    //        else
    //        {
    //            dtTemp1.ImportRow(dtTemp.Rows[i]);
    //        }
    //    }

    //    ViewState["dataTableDistinct4"] = dtTemp1;

    //    DataTable dtTemp2 = dtTemp1.Copy();
    //    DataView dv = dtTemp2.DefaultView;
    //    dv.Sort = "cinvdefine4";
    //    dtTemp2 = dv.ToTable();

    //    DataRow dr4 = dtTemp2.NewRow();
    //    dr4["cinvdefine4"] = "全部";
    //    dtTemp2.Rows.InsertAt(dr4, 0);
    //    DropDownList4.DataSource = dtTemp2;
    //    DropDownList4.DataValueField = "cinvdefine4";
    //    DropDownList4.DataBind();

    //}

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        GridViewRow row = (GridViewRow)(((WebControl)e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {
            case "Modify":
                //string parValue = e.CommandArgument.ToString();
                string currentStatus = "";
                HiddenField status = (HiddenField)row.FindControl("status");
                HiddenField autoid = (HiddenField)row.FindControl("autoid");

                DropDownList 承运商 = (DropDownList)row.FindControl("承运商");
                TextBox 运费 = (TextBox)row.FindControl("运费");
                DropDownList 门卫 = (DropDownList)row.FindControl("门卫");



                if (String.IsNullOrEmpty(status.Value))
                {
                    currentStatus = "1";
                }
                else
                {
                    currentStatus = status.Value.Trim();
                }

                String sql = "";


                if ("1".Equals(currentStatus))
                {
                    sql = " insert into cmlc(单号autoid,status) values('" + autoid.Value + "','2')";

                }
                else if ("2".Equals(currentStatus))
                {
                    sql = "update cmlc set status='3' where 单号autoid='" + autoid.Value + "'";
                    //sql = " insert into cmlc(单号autoid,status) values('" + autoid.Value + "','3')";

                }
                else if ("3".Equals(currentStatus))
                {
                    if ("门卫北".Equals(门卫.SelectedValue.Trim()))
                    {
                        sql = "update cmlc set [承运商]='" + 承运商.SelectedValue + "' , 门卫='" + 门卫.SelectedValue + "' ,status='4' where 单号autoid='" + autoid.Value + "'";
                    }
                    else
                    {
                        sql = "update cmlc set [承运商]='" + 承运商.SelectedValue + "' , 门卫='" + 门卫.SelectedValue + "' ,status='5' where 单号autoid='" + autoid.Value + "'";

                    }
                }
                //门卫
                else if ("4".Equals(currentStatus) || "5".Equals(currentStatus))
                {

                    sql = "update cmlc set status='6' where 单号autoid='" + autoid.Value + "'";

                }

                    //物流实际结算运费
                else if ("6".Equals(currentStatus))
                {
                    sql = "update cmlc set status='7' , 运费='" + 运费.Text + "'  where 单号autoid='" + autoid.Value + "'";
                }
                else if ("7".Equals(currentStatus))
                {
                    sql = "update cmlc set status='8' where 单号autoid='" + autoid.Value + "'";
                }

                SQLHelper1.ExecuteSql(sql);
                Bind(false);

                //string hou = ((HiddenField)row.FindControl("hou")).Value.Trim();

                //string modid = ((HiddenField)row.FindControl("modid")).Value;
                //string cInvCode = ((HiddenField)row.FindControl("cInvCode")).Value;
                //string SoCode = ((HiddenField)row.FindControl("SoCode")).Value;

                ////LoginView loginView1 = ((LoginView)row.FindControl("LoginView1"));
                //string DropDownList5 = ((DropDownList)row.FindControl("DropDownList5")).SelectedValue;

                ////LoginView loginView2 = ((LoginView)row.FindControl("LoginView2"));
                //string dateTxtBox = ((TextBox)row.FindControl("dateTxtBox")).Text;

                ////LoginView loginView3 = ((LoginView)row.FindControl("LoginView3"));
                //string txt逾期原因 = ((DropDownList)row.FindControl("txt逾期原因")).Text.Trim();
                //string txt逾期原因详细 = ((TextBox)row.FindControl("txt逾期原因详细")).Text.Trim();
                //string txtCombine = txt逾期原因 + txt逾期原因;
                //List<String> SQLStringList = new List<string>();

                //sql = "update mom_morder set DueDate='" + dateTxtBox + "' where modid='" + modid + "'";
                //SQLStringList.Add(sql);
                //sql = "update Inventory set [cinvdefine4]='" + DropDownList5 + "' where cInvCode='" + cInvCode + "'";
                //SQLStringList.Add(sql);

                //sql = "update mom_orderdetail set define25='" + txt逾期原因 + "," + txt逾期原因详细 + "' where modid='" + modid +
                //      "'";
                //SQLStringList.Add(sql);
                //if (!(qian + hou).Equals(txtCombine))
                //{
                //    sql = " insert into SetColor(Csocode) values('" + SoCode + "')";
                //    SQLHelper1.ExecuteSql(sql);
                //}

                //if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                //{
                //    //Response.Write("<script>alert('生成报表失败');</script>");

                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);
                //    //MessageBox.Show(this, "更新数据失败");
                //    //Response.Write();
                //    //return;
                //}
                //else
                //{
                //    //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);

                //    //MessageBox.Show(this, "成功更新数据");
                //    //return;
                //}


                break;


            default:

                break;
        }

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
        //GridView1.DataSource = null;
        Bind(true);

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    private string[] Cut(string cid, Char cut)
    {
        string[] sArray = cid.Split(cut);
        return sArray;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex > -1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal ||
                    e.Row.RowState == DataControlRowState.Alternate)
                {
                    {
                        DropDownList ddl承运商 = (DropDownList)e.Row.FindControl("承运商");

                        HiddenField id = (HiddenField)e.Row.FindControl("id");

                        //Label 车间名称autoid = (Label) e.Row.FindControl("车间名称autoid");
                        //Label 产品编码 = (Label) e.Row.FindControl("label产品编码");

                        //dropTemp = (DropDownList) e.Row.FindControl("DropDownList19");
                        if (ddl承运商 != null)
                        {

                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("请选择", "-1");

                            DataTable dt =
                                SQLHelper1.Query("select id,承运商 from [承运商] ").
                                    Tables[0];

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string temp0 = dt.Rows[i][0].ToString().Trim();
                                string temp1 = dt.Rows[i][1].ToString().Trim();
                                dic.Add(temp1, temp0);
                            }

                            ddl承运商.DataSource = dic;
                            ddl承运商.DataTextField = "Key";
                            ddl承运商.DataValueField = "Value";

                            if (String.IsNullOrEmpty(id.Value))
                            {
                                ddl承运商.SelectedValue = "-1";
                            }
                            else
                            {
                                ddl承运商.SelectedValue = id.Value.Trim();
                            }

                            ddl承运商.DataBind();
                        }
                    }






                    string currentStatus = "";
                    string personStatus = ViewState["status"].ToString();

                    HiddenField autoid = (HiddenField)e.Row.FindControl("autoid");

                    HiddenField 单号autoid = (HiddenField)e.Row.FindControl("单号autoid");
                    HiddenField status = (HiddenField)e.Row.FindControl("status");
                    DropDownList 承运商 = (DropDownList)e.Row.FindControl("承运商");
                    TextBox 运费 = (TextBox)e.Row.FindControl("运费");
                    DropDownList 门卫 = (DropDownList)e.Row.FindControl("门卫");
                    Button asp_btnUpdate = (Button)e.Row.FindControl("asp_btnUpdate");

                    Label Label当前节点 = (Label)e.Row.FindControl("Label当前节点");


                    RequiredFieldValidator RequiredFieldValidator1 = (RequiredFieldValidator)e.Row.FindControl("RequiredFieldValidator1");
                    RequiredFieldValidator RequiredFieldValidator2 = (RequiredFieldValidator)e.Row.FindControl("RequiredFieldValidator2");
                    RequiredFieldValidator RequiredFieldValidator3 = (RequiredFieldValidator)e.Row.FindControl("RequiredFieldValidator3");


                    //===========================
                    if (String.IsNullOrEmpty(status.Value))
                    {
                        currentStatus = "1";
                    }
                    else
                    {
                        currentStatus = status.Value.Trim();
                    }
                    //==========================

                    if ("1".Equals(currentStatus))
                    {
                        Label当前节点.Text = "1:销售部";
                    }
                    else if ("2".Equals(currentStatus))
                    {
                        Label当前节点.Text = "2:财务部";
                    }
                    else if ("3".Equals(currentStatus))
                    {
                        Label当前节点.Text = "3:用车主管";
                    }
                    else if ("4".Equals(currentStatus))
                    {
                        Label当前节点.Text = "4:门卫北";
                    }
                    else if ("5".Equals(currentStatus))
                    {
                        Label当前节点.Text = "5:门卫南";
                    }
                    else if ("6".Equals(currentStatus))
                    {
                        RequiredFieldValidator2.Enabled = true;
                        RequiredFieldValidator2.ValidationGroup = "G1" + autoid.Value.Trim();
                        运费.ReadOnly = false;
                        asp_btnUpdate.ValidationGroup = "G1" + autoid.Value.Trim();

                        Label当前节点.Text = "6:用车主管实际结算";
                    }
                    else if ("7".Equals(currentStatus))
                    {
                        Label当前节点.Text = "7:财务审单";
                    }
                    else if ("8".Equals(currentStatus))
                    {
                        Label当前节点.Text = "已经结束";
                    }

                    string[] a = Cut(personStatus, ',');
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i].Equals(currentStatus))
                        {
                            if ("1".Equals(currentStatus))
                            {
                                asp_btnUpdate.Enabled = true;
                            }
                            else if ("2".Equals(currentStatus))
                            {
                                asp_btnUpdate.Enabled = true;

                            }
                            else if ("3".Equals(currentStatus))
                            {

                                承运商.Enabled = true;
                                运费.ReadOnly = true;
                                门卫.Visible = true;
                                asp_btnUpdate.Enabled = true;
                                RequiredFieldValidator1.Enabled = true;
                                RequiredFieldValidator2.Enabled = false;
                                RequiredFieldValidator3.Enabled = true;
                                RequiredFieldValidator1.ValidationGroup = "G1" + autoid.Value.Trim();
                                //RequiredFieldValidator2.ValidationGroup = "G1" + autoid.Value.Trim();
                                RequiredFieldValidator3.ValidationGroup = "G1" + autoid.Value.Trim();
                                asp_btnUpdate.ValidationGroup = "G1" + autoid.Value.Trim();

                                //承运商.ReadOnly = false;
                                //运费.ReadOnly = false;
                                //门卫.Visible = true;
                                //asp_btnUpdate.Enabled = true;
                                //RequiredFieldValidator1.Enabled = true;
                                //RequiredFieldValidator2.Enabled = true;
                                //RequiredFieldValidator3.Enabled = true;
                                //RequiredFieldValidator1.ValidationGroup = "G1" + autoid.Value.Trim();
                                //RequiredFieldValidator2.ValidationGroup = "G1" + autoid.Value.Trim();
                                //RequiredFieldValidator3.ValidationGroup = "G1" + autoid.Value.Trim();
                                //asp_btnUpdate.ValidationGroup = "G1" + autoid.Value.Trim();
                            }

                            else if ("4".Equals(currentStatus) || "5".Equals(currentStatus))
                            {
                                asp_btnUpdate.Enabled = true;
                            }

                            else if ("6".Equals(currentStatus))
                            {
                                asp_btnUpdate.Enabled = true;
                            }
                            else if ("7".Equals(currentStatus))
                            {
                                asp_btnUpdate.Enabled = true;
                            }
                        }
                    }








                    //CheckBox checkBox1 = (CheckBox)e.Row.FindControl("CheckBox1");

                    //DataTable dt =
                    //    SQLHelper1.Query("select MoDId,[flag] from xialiao_flag where modid=" + modid.Value).Tables[0];
                    //if (dt.Rows.Count == 1)
                    //{
                    //    if (Convert.ToInt32(dt.Rows[0][1].ToString()) == 1)
                    //    {
                    //        checkBox1.Enabled = true;
                    //    }
                    //    else
                    //    {
                    //        checkBox1.Enabled = false;
                    //    }
                    //}


                }
            }

        }
    }

    protected void btnNoXiaLiao_Click(object sender, EventArgs e)
    {
        string sql = "";
        bool ischecked = false;
        List<String> lst_modid = new List<string>();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {

                HiddenField modid = GridView1.Rows[i].FindControl("modid") as HiddenField;
                HiddenField cInvCode = GridView1.Rows[i].FindControl("cInvCode") as HiddenField;
                //DataSet ds = SQLHelper1.Query(" select * from xialiao where 产品编码='" + cInvCode.Value + "' ");
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('编码[" + cInvCode.Value + "]没有下料数据,请修改！')", true);
                //    return;
                //}

                lst_modid.Add(modid.Value);
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            //MessageBox.Show(this, "没有选择任何项");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有选择任何项!')", true);

            return;
        }

        //string tmp = "";
        List<String> SQLStringList = new List<string>();
        foreach (string VARIABLE in lst_modid)
        {
            sql = " insert into xialiao_flag([MoDId],flag   ) values('" + VARIABLE + "',3)";
            SQLStringList.Add(sql);
            //tmp += VARIABLE + ",";
        }
        //if (tmp.EndsWith(","))
        //{
        //    tmp = tmp.Substring(0, tmp.Length - 1);
        //}

        if (SQLHelper1.ExecuteSqlTran(SQLStringList) == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!请联系管理员！')", true);
            return;
        }
        else
        {
            //Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script>openwin('cjxl_Print.aspx','cjxl_Print','" + tmp + "');__doPostBack('ctl00$MainContent$btnFilter',''); </script>");
            //btnFilter.
        }

    }


    protected void btnXiaLiao_Click(object sender, EventArgs e)
    {
        string sql = "";
        bool ischecked = false;
        List<String> lst_modid = new List<string>();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {

                HiddenField modid = GridView1.Rows[i].FindControl("modid") as HiddenField;
                HiddenField cInvCode = GridView1.Rows[i].FindControl("cInvCode") as HiddenField;
                DataSet ds = SQLHelper1.Query(" select * from xialiao where 产品编码='" + cInvCode.Value + "' ");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('编码[" + cInvCode.Value + "]没有下料数据,请修改！')", true);
                    return;
                }

                lst_modid.Add(modid.Value);
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            //MessageBox.Show(this, "没有选择任何项");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有选择任何项!')", true);

            return;
        }

        string tmp = "";
        List<String> SQLStringList = new List<string>();
        foreach (string VARIABLE in lst_modid)
        {
            sql = " insert into xialiao_flag([MoDId]) values('" + VARIABLE + "')";
            SQLStringList.Add(sql);
            tmp += VARIABLE + ",";
        }
        if (tmp.EndsWith(","))
        {
            tmp = tmp.Substring(0, tmp.Length - 1);
        }

        if (SQLHelper1.ExecuteSqlTran(SQLStringList) == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!请联系管理员！')", true);
            return;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script>openwin('cjxl_Print.aspx','cjxl_Print','" + tmp + "');__doPostBack('ctl00$MainContent$btnFilter',''); </script>");
            //btnFilter.
        }

    }
    protected void btnReXiaLiao_Click(object sender, EventArgs e)
    {
        string sql = "";
        bool ischecked = false;
        List<String> lst_modid = new List<string>();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {

                HiddenField modid = GridView1.Rows[i].FindControl("modid") as HiddenField;
                HiddenField cInvCode = GridView1.Rows[i].FindControl("cInvCode") as HiddenField;
                DataSet ds = SQLHelper1.Query(" select * from xialiao where 产品编码='" + cInvCode.Value + "' ");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('编码[" + cInvCode.Value + "]没有下料数据,请修改！')", true);
                    return;
                }

                lst_modid.Add(modid.Value);
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            //MessageBox.Show(this, "没有选择任何项");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有选择任何项!')", true);

            return;
        }

        string tmp = "";
        //List<String> SQLStringList = new List<string>();
        foreach (string VARIABLE in lst_modid)
        {
            //sql = " insert into xialiao_flag([MoDId]) values('" + VARIABLE + "')";
            //SQLStringList.Add(sql);
            tmp += VARIABLE + ",";
        }
        if (tmp.EndsWith(","))
        {
            tmp = tmp.Substring(0, tmp.Length - 1);
        }
        Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script>openwin('cjxl_Print.aspx','cjxl_Print','" + tmp + "');__doPostBack('ctl00$MainContent$btnFilter',''); </script>");
    }
    protected void BtnFinish_Click(object sender, EventArgs e)
    {
        string sql = "";
        bool ischecked = false;
        List<String> lst_modid = new List<string>();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {
                HiddenField modid = GridView1.Rows[i].FindControl("modid") as HiddenField;
                HiddenField cInvCode = GridView1.Rows[i].FindControl("cInvCode") as HiddenField;
                //DataSet ds = SQLHelper1.Query(" select * from xialiao where 产品编码='" + cInvCode.Value + "' ");
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('编码[" + cInvCode.Value + "]没有下料数据,请修改！')", true);
                //    return;
                //}

                lst_modid.Add(modid.Value);
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            //MessageBox.Show(this, "没有选择任何项");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有选择任何项!')", true);

            return;
        }

        string tmp = "";
        foreach (string VARIABLE in lst_modid)
        {
            tmp += "'" + VARIABLE + "'" + ",";
        }
        if (tmp.EndsWith(","))
        {
            tmp = tmp.Substring(0, tmp.Length - 1);
        }

        if (SQLHelper1.ExecuteSql(" update [xialiao_flag] set flag=2  where modid in (" + tmp + ") ") == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('有错误发生!请联系管理员')", true);

            return;
        }

        Page.ClientScript.RegisterStartupScript(typeof(Page), "", "<script>__doPostBack('ctl00$MainContent$btnFilter',''); </script>");

    }
}