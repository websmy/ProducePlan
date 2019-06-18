using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class Mom1Print : System.Web.UI.Page
{
    private DataSet _dsBind = null;
	private string ccodes = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Label1.Text = System.DateTime.Now.ToString("yyyy-MM-dd ");
            try
            {
                ccodes = Session["needprint"].ToString();
            }
            catch (Exception)
            {

                //throw;
            }
             
            if (String.IsNullOrEmpty(ccodes))
            {
                Response.Write("<script>window.close();</script>");
                Response.Redirect("./Mom1.aspx");
                Response.End();
            }
			
            //_dsBind = SQLHelper1.Query("select  * from xialiao ");
            BindData3();
            //_dsBind = new DataSet();
            //string sql = "";
            //if (String.IsNullOrEmpty(cInvcode))
            //{
            //    sql = "select  * from xialiao";
            //}
            //else
            //{
            //    sql = "select  * from xialiao where 产品编码='" + cInvcode + "'";
            //}

            
        }
    }

    public void BindData3()
    {
        _dsBind = new DataSet();


        string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
        string vDataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration1//DataBaseName").InnerText.Trim();

        string sql =
            "SELECT  a.Define31 chuli, '' baozhuang , pn.datetime, a.modid, SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],Department.[cDepCode],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],inventory.cInvCCode,a.SoCode,a.ordercode,a.orderseq,'' as 是否缺料,"
            +
            " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
            + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
            + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
            + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
            + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
            + " LEFT JOIN SO_SOMain ON a.ordercode = SO_SOMain.cSOCode  "
            + " LEFT JOIN SO_SODetails ON SO_SODetails.cSOCode = SO_SOMain.cSOCode  AND a.OrderSeq=SO_SODetails.iRowNo"
            + " left join opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn on  a.MoDId= pn.MoDId  "

            //+ " LEFT JOIN SO_SODetails ON a.socode = SO_SODetails.csocode and a.invcode=SO_SODetails.cinvcode"

            + " WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3 ";
        //+" WHERE a.status <> 4 and a.Qty <> a.QualifiedInQty and a.Status = 3 ";

        //sql = "SELECT TOP " + pageSize + " * FROM aViewName WHERE (modid > (SELECT MAX(modid) FROM (SELECT TOP (" + pageSize * (curpage - 1) + ") modid FROM aViewName  ORDER BY modid) AS T)) ";                                                   
        sql += " and 1=1 ";
        sql += " and exists( select '1' from  opendatasource ('SQLOLEDB','" + GetConnectionString.iGetConn1 + "')." + vDataBaseName + ".dbo.[日装配计划]  pn where pn.modid = a.modid   ) ";
        sql += " and a.modid in('" + Session["needprint"].ToString() + "') ";
        


//        string sqlString = "SELECT isnull(s1.cDefine37,s1.dPreMoDate) cDefine37,s1.dPreMoDate,s2.*,s3.invcode s3code ,s3.cinvname s3name ,s3.qty s3yaoling,s3.xiancun  s3xiancun" +
//"    FROM" +
//"    (SELECT '' AS xiancun,SO_SODetails.iNatSum,SO_SODetails.iSOsID,SO_SODetails.iFHQuantity,SO_SODetails.iKPQuantity,SO_SOMain.[cMaker],Person.[cPersonName],inventory.iInvAdvance,SO_SODetails.iRowNo,SO_SODetails.AutoID,SO_SOMain.cSOCode,SO_SOMain.cCusName,SO_SOMain.dDate,SO_SODetails.cInvCode,SO_SODetails.cInvName,SO_SODetails.iQuantity,SO_SODetails.dPreMoDate,SO_SODetails.cSCloser,SO_SODetails.cdefine26,SO_SODetails.cdefine37" +
//"    FROM [SO_SODetails]" +
//"    LEFT JOIN [SO_SOMain]" +
//"        ON [SO_SODetails].csocode=[SO_SOMain].csocode" +
//"    LEFT JOIN [inventory]" +
//"        ON SO_SODetails.cInvCode=[inventory].cInvCode" +
//"    LEFT JOIN [Department]" +
//"        ON SO_SOMain.cDepCode=[Department].cDepCode" +
//"    LEFT JOIN [Person]" +
//"        ON Person.[cPersonCode]=[SO_SOMain].[cPersonCode]" +
//"    WHERE" +
//"        (SELECT count(*)" +
//"        FROM mom_orderdetail" +
//"        WHERE mom_orderdetail.sodid=SO_SODetails.iSOsID" +
//"                AND mom_orderdetail.InvCode= SO_SODetails.cInvCode" +
//"                AND SO_SODetails.iQuantity=mom_orderdetail.QualifiedInQty )=0" +
//"                AND SO_SODetails.cSCloser is null" +
//"                AND SO_SODetails.iQuantity > ISNULL(SO_SODetails.iFHQuantity,0)" +
//"                AND 1=1 ) s1," +
//"        (SELECT SO_SOMain.cCusName," +
//"         a.soseq," +
//"" +
//"            CASE" +
//"            WHEN CHARINDEX(',',a.define25)>0 THEN" +
//"            substring(a.define25,1,CHARINDEX(',',a.define25)-1 )" +
//"            WHEN CHARINDEX(',',a.define25)<=0 THEN" +
//"            ''" +
//"            END AS qian,case" +
//"            WHEN CHARINDEX(',',a.define25)>0 THEN" +
//"            substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 THEN" +
//"            ''end AS hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],a.SoCode, mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate" +
//"        FROM mom_orderdetail a" +
//"        LEFT JOIN mom_order" +
//"            ON a.moid = mom_order.moid" +
//"        LEFT JOIN mom_morder" +
//"            ON a.modid = mom_morder.modid" +
//"        LEFT JOIN inventory" +
//"            ON a.InvCode = inventory.cInvCode" +
//"        LEFT JOIN [Department]" +
//"            ON a.MDeptCode = [Department].[cDepCode]" +
//"        LEFT JOIN SO_SODetails" +
//"            ON a.sodid=SO_SODetails.iSOsID" +
//"        LEFT JOIN SO_SOMain" +
//"            ON SO_SODetails.cSOCode=SO_SOMain.cSOCode" +
//"        WHERE 1=1 ) s2," +
//"        (SELECT mom_moallocate.[AllocateId]," +
//"         mom_moallocate.[MoDId]," +
//"         mom_moallocate.[SortSeq]," +
//"         mom_orderdetail.MDeptCode," +
//"         Warehouse.[cWhName]," +
//"         mom_moallocate.invcode," +
//"         inventory.cinvname," +
//"         mom_moallocate.qty," +
//"         mom_moallocate.issqty,mom_moallocate.SoSeq, " +
//"" +
//"            (SELECT Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity)," +
//"         0)" +
//"            FROM CurrentStock" +
//"            WHERE CurrentStock.cInvCode =mom_moallocate.invcode and CurrentStock.cWhCode not in('08','09','15','24','26','31','34','42')) AS xiancun, mom_moallocate.qty-mom_moallocate.issqty yaoling" +
//"            FROM mom_moallocate" +
//"            LEFT JOIN mom_orderdetail" +
//"                ON mom_moallocate.modid = mom_orderdetail.modid" +
//"            LEFT JOIN inventory" +
//"                ON mom_moallocate.invcode = inventory.cinvcode" +
//"            LEFT JOIN Warehouse" +
//"                ON Warehouse.cWhCode = mom_moallocate.whcode" +
//"            WHERE (mom_moallocate.qty - mom_moallocate.issqty)>" +
//"                (SELECT Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity)," +
//"         0)" +
//"                FROM CurrentStock" +
//"                WHERE CurrentStock.cInvCode =mom_moallocate.invcode and CurrentStock.cWhCode not in('08','09','15','24','26','31','34','42')) ) s3" +
//"            WHERE s1.cSOCode=s2.SoCode" +
//"                AND s2.modid=s3.MoDId   AND s2.sodid = s1.iSOsID " +
//"            " +
//"            and  s2.sodid in('" + Session["strConnected"].ToString() + "')";




        _dsBind = SQLHelper.Query(sql);

        DataTable dt = _dsBind.Tables[0];
        //dt.Select()
        //DataView dv = dt.DefaultView;
        //dv.
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //string sql2 = @"select inv.cInvCCode from v_mom_moallocate_rpt va left join inventory inv on va.invcode = inv.cinvcode  where va.modid='1000336522' " + dt.Rows[i]["modid"].ToString() + "' and LEFT(inv.cInvCCode,4) ='0115'";

            string sql2 = @" SELECT inv.cInvName
FROM   v_mom_moallocate_rpt va
       LEFT JOIN inventory inv
              ON va.invcode = inv.cinvcode
WHERE  va.modid = '"+ dt.Rows[i]["modid"].ToString() + "'AND LEFT(inv.cInvCCode, 4) = '0115' ";

            DataTable dt2 = SQLHelper.Query(sql2).Tables[0];

            if (dt2.Rows.Count > 0)
            {
                dt.Rows[i]["baozhuang"] = dt2.Rows[0][0].ToString();
            }

        }
        //DataRow[] drArr = dt.Select("(qty - issqty)>xiancun");
        //DataTable dtNew = dt.Clone();
        //for (int i = 0; i < drArr.Length; i++)
        //{
        //    dtNew.ImportRow(drArr[i]);

        //}

        //dt.Clear();
        //dt = dtNew;





        GridView3.DataSource = dt;
        GridView3.DataBind();
    }

    //public static void renderEmptyGridView(GridView EmptyGridView, string FieldNames)
    //{
    //    //将GridView变成只有Header和Footer列，以及被隐藏的空白资料列     
    //    DataTable dTable = new DataTable();
    //    char[] delimiterChars = { ',' };
    //    string[] colName = FieldNames.Split(delimiterChars);
    //    foreach (string myCol in colName)
    //    {
    //        DataColumn dColumn = new DataColumn(myCol.Trim());
    //        dTable.Columns.Add(dColumn);
    //    }
    //    DataRow dRow = dTable.NewRow();
    //    foreach (string myCol in colName)
    //    {
    //        dRow[myCol.Trim()] = DBNull.Value;
    //    }
    //    dTable.Rows.Add(dRow);
    //    EmptyGridView.DataSourceID = null;
    //    EmptyGridView.DataSource = dTable;
    //    EmptyGridView.DataBind();
    //    EmptyGridView.Rows[0].Visible = false;
    //}



    //protected void GridView3_PreRender(object sender, EventArgs e)
    //{
    //    if (GridView3.Rows.Count == 0)
    //    {
    //        renderEmptyGridView(GridView3, " socode,cinvcode,cinvname,qty,s3code,s3name,s3qyt");
    //    }
    //}


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;
            if (null != pagerRow)
            {
                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
            }
            if (null != txtNewPageIndex)
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        { newPageIndex = e.NewPageIndex; }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        BindData3();
    }

}