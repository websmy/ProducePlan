using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_MomPop : System.Web.UI.Page
{

    public Boolean displayed = false;
    private string[] b = new string[] { "半成品用材料", "产成品用材料" };
    private string SoDId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Label1.Visible = false;
            if (ViewState["IsForm1Valid"] == null)
            {
                ViewState["IsForm1Valid"] = "true";
                ///下接初始化代码

            }
            else
            {
                if (ViewState["IsForm1Valid"].ToString() == "false") ;//刷新 Label1.Visible = true;  
            }

            Bind();
            txtDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd ");

        }

        //sb保存的是JavaScript脚本代码,点击提交按钮时执行该脚本
        StringBuilder sb = new StringBuilder();
        //保证验证函数的执行 
        sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate('G1') == false) { return false; }};");
        //点击提交按钮后设置Button的disable属性防止用户再次点击,注意这里的this是JavaScript代码
        sb.Append("this.disabled  = true;");
        //用__doPostBack来提交，保证按钮的服务器端click事件执行 
        sb.Append(this.ClientScript.GetPostBackEventReference(this.btnLinLiao, ""));
        sb.Append(";");
        //SetUIStyle()是JavaScript函数,点击提交按钮后执行,如可以显示动画效果提示后台处理进度
        //注意SetUIStyle()定义在aspx页面中
        //sb.Append("SetUIStyle();");
        //给提交按钮增加OnClick属性
        this.btnLinLiao.Attributes.Add("onclick", sb.ToString());

        //btnLinLiao.Attributes.Add("onclick", this.GetPostBackEventReference(btnLinLiao) + ";this.disabled=true;");
    }

    private void Bind()
    {
        string mom_orderdetailmoDid = Request.QueryString["id"];
        SoDId = Request.QueryString["p6"];
        ViewState["SoDId"] = SoDId;

        ViewState["mom_orderdetailmoDid"] = mom_orderdetailmoDid;

        if (String.IsNullOrEmpty(SoDId))
        {
            ViewState["SoDId"] = "''";
        }


        if (String.IsNullOrEmpty(mom_orderdetailmoDid))
        {
            Response.Write("<script>window.close();</script>");
            Response.Redirect("./Mom.aspx");
            Response.End();
        }

        string sql = "";
        DataSet ds;
        DataTable dataTable;
        DataRow dr3;

        sql = "SELECT [cRdName],[cRdCode] from [Rd_Style]";
        ds = SQLHelper.Query(sql);
        dataTable = ds.Tables[0]; ;
        dr3 = dataTable.NewRow();
        dr3["cRdName"] = "请选择";
        dr3["cRdCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);

        for (int i = 1; i < dataTable.Rows.Count; i++)
        {
            if (!b.Contains(dataTable.Rows[i]["cRdName"].ToString().Trim()))
            {
                dataTable.Rows[i].Delete();
            }
        }

        DropDownList2.DataSource = dataTable;
        DropDownList2.DataTextField = "cRdName";
        DropDownList2.DataValueField = "cRdCode";
        DropDownList2.DataBind();


        //[UserDefine]
        sql = "SELECT [cValue]  from [UserDefine] where cID='39' ";
        ds = SQLHelper.Query(sql);
        dataTable = ds.Tables[0]; ;
        dr3 = dataTable.NewRow();
        dr3["cValue"] = "请选择";
        //dr3["cRdCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);

        DropDownList4.DataSource = dataTable;
        DropDownList4.DataValueField = "cValue";
        DropDownList4.DataValueField = "cValue";
        DropDownList4.DataBind();
        //        sql =
        //            "select mom_orderdetail.SoDId,mom_orderdetail.moid,CurrentStock.AutoID,mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,inventory.cDefWareHouse  as  whcode, mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun, 0.00 as xiancun1, inventory.[cInvCCode]," +

        //            "case  " +
        //"when (mom_moallocate.qty-mom_moallocate.issqty) >= isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) then isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) " +
        //"when (mom_moallocate.qty-mom_moallocate.issqty) < isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) then   case when (mom_moallocate.qty-mom_moallocate.issqty)<0 then 0 else mom_moallocate.qty-mom_moallocate.issqty end  " +
        //"end   " +
        // "as yaoling  " +


        //            "from mom_moallocate " +
        //            "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
        //            "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
        //            "left join CurrentStock on CurrentStock.cWhCode = inventory.cDefWareHouse and CurrentStock.cInvCode = mom_moallocate.InvCode  and (CurrentStock.isodid=0 or CurrentStock.isodid = '" + ViewState["SoDId"] + "') " +
        //            "where mom_moallocate.modid=" + mom_orderdetailmoDid +
        //            " and 1=1  ";


        //        sql += " and mom_moallocate.qty > mom_moallocate.issqty";


        //        sql += " order by mom_moallocate.SortSeq ";



        sql =
            " SELECT  mom_orderdetail.SoDId ,                                                                                                             " +
            "         mom_orderdetail.socode ,                                                                                                              " +
            "         mom_orderdetail.ordercode ,                                                                                                              " +
            "         mom_orderdetail.orderdid ,                                                                                                              " +
            "         mom_orderdetail.moid ,                                                                                                              " +
            "         mom_order.mocode ,                                                                                                              " +
            "         CurrentStock.AutoID ,                                                                                                               " +
            "         CurrentStock.iSoType ,                                                                                                               " +
            "         mom_moallocate.[AllocateId] ,                                                                                                       " +
            "         mom_moallocate.[MoDId] ,                                                                                                            " +
            "         mom_moallocate.[SortSeq] ,                                                                                                          " +
            "         mom_orderdetail.MDeptCode ,                                                                                                         " +
            "         inventory.cDefWareHouse AS whcode ,                                                                                                 " +
            "         mom_moallocate.invcode ,                                                                                                            " +
            "         inventory.cinvname ,                                                                                                                " +
            "         mom_moallocate.qty ,                                                                                                                " +
            "         mom_moallocate.issqty ,                                                                                                             " +

            //"         CurrentStock.iQuantity ,                                                                                                             " +
            //"         CurrentStock.fOutQuantity ,                                                                                                             " +

            "         ISNULL(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0) xiancun ,                                                             " +
            "         0.00 AS xiancun1 ,                                                                                                                  " +
            "         inventory.[cInvCCode] ,                                                                                                             " +

            "         CASE WHEN ( mom_moallocate.qty - mom_moallocate.issqty ) >= ISNULL(CurrentStock.iQuantity- CurrentStock.fOutQuantity,0)             " +
            "              THEN ISNULL(CurrentStock.iQuantity - CurrentStock.fOutQuantity, 0)                                                             " +
            "              WHEN ( mom_moallocate.qty - mom_moallocate.issqty )  < ISNULL(CurrentStock.iQuantity- CurrentStock.fOutQuantity,0)             " +
            "              THEN CASE WHEN ( mom_moallocate.qty - mom_moallocate.issqty ) < 0                                                              " +
            "                        THEN 0                                                                                                               " +
            "                        ELSE mom_moallocate.qty - mom_moallocate.issqty                                                                      " +
            "                   END                                                                                                                       " +
            "         END AS yaoling                                                                                                                      " +
            //"          0.00 AS yaoling" +
            " FROM    mom_moallocate                                                                                                                      " +
            "         LEFT JOIN mom_orderdetail ON mom_moallocate.modid = mom_orderdetail.modid                                                           " +
            "         LEFT JOIN mom_order ON mom_order.moid = mom_orderdetail.moid                                                           " +
            "         LEFT JOIN inventory ON mom_moallocate.invcode = inventory.cinvcode                                                                  " +
            "         LEFT JOIN CurrentStock ON CurrentStock.cWhCode = inventory.cDefWareHouse                                                            " +
            "                                   AND CurrentStock.cInvCode = mom_moallocate.InvCode                                                        " +
            "                                   AND (                                                                         " +
            "                                              CurrentStock.isodid =" + ViewState["SoDId"] + "                                                                                               " +
            "                                       )                                                                                                     " +
            " WHERE   mom_moallocate.modid = " + mom_orderdetailmoDid + "                                                                                                       " +
            "         AND 1 = 1                                                                                                                           " +
            "         AND mom_moallocate.qty > mom_moallocate.issqty                                                                                      " +
            " ORDER BY mom_moallocate.SortSeq ";


        ds = SQLHelper.Query(sql);

        DataTable dt = ds.Tables[0];

        if (!"0".Equals(ViewState["SoDId"]))
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 5)
                {

                }


                if (0 == Convert.ToDecimal(dt.Rows[i]["xiancun"]))
                {

                    DataSet dsxiancun = SQLHelper.Query(
                        "select Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) ,AutoID  from CurrentStock where CurrentStock.cInvCode ='" +
                        dt.Rows[i]["invcode"].ToString() + "' and CurrentStock.isodid=0 and CurrentStock.cWhCode='" +
                        dt.Rows[i]["whcode"] + "' ");

                    if (dsxiancun.Tables[0].Rows.Count != 0)
                    {
                        dt.Rows[i]["xiancun"] = dsxiancun.Tables[0].Rows[0][0];
                        dt.Rows[i]["AutoID"] = dsxiancun.Tables[0].Rows[0][1];
                        dt.Rows[i]["iSoType"] = "0";
                    }





                    //dt.Rows[i]["AutoID"] = SQLHelper.Query(
                    //"select Isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0),AutoID  from CurrentStock where CurrentStock.cInvCode ='" +

                    //"select Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) , AutoID from CurrentStock where CurrentStock.cInvCode ='" +
                    //dt.Rows[i]["invcode"].ToString() + "' and CurrentStock.isodid=0 and CurrentStock.cWhCode='" + dt.Rows[i]["whcode"] + "' ").Tables[0].Rows[0][1];

                    Decimal result = 0;

                    Decimal qty = Convert.ToDecimal(dt.Rows[i]["qty"]);
                    Decimal issqty = Convert.ToDecimal(dt.Rows[i]["issqty"]);

                    Decimal xiancun = Convert.ToDecimal(dt.Rows[i]["xiancun"]);
                    Decimal q_i = qty - issqty;

                    if (q_i >= xiancun)
                    {
                        result = xiancun;
                    }
                    else
                    {
                        if (q_i < 0)
                        {
                            result = 0;
                        }
                        else
                        {
                            result = q_i;
                        }
                    }
                    dt.Rows[i]["yaoling"] = result;
                }

            }
        }


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["xiancun1"] =
                SQLHelper.Query(
                    "select Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode ='" +
                    dt.Rows[i]["invcode"].ToString() + "'").Tables[0].Rows[0][0];
        }
        //this.HiddenField1.Value = row.Cells[0].Text;
        //this.HiddenField2.Value = row.Cells[4].Text;
        //this.HiddenField3.Value = row.Cells[3].Text;
        //this.HiddenField4.Value = row.Cells[6].Text;

        this.HiddenField1.Value = Request.QueryString["p1"];
        this.HiddenField2.Value = Request.QueryString["p2"];
        this.HiddenField3.Value = Request.QueryString["p3"];
        this.SortSeq.Value = Request.QueryString["SortSeq"];
        this.soseq.Value = Request.QueryString["soseq"];
        
        this.h生产班组.Value = Request.QueryString["p7"];


        //订单数量
        this.HiddenField4.Value = Request.QueryString["p4"];
        this.mom_orderdetailmoid.Value = Request.QueryString["p5"];
        //this.SoDId.Value = Request.QueryString["p6"];

        btnAdd.ToolTip = "添加材料";
        btnAdd.Attributes.Add("onclick", "openwin('MomPop_Add.aspx','MomPop_Add','" + mom_orderdetailmoDid + "','550','500','" + this.HiddenField4.Value + "','','','')");

        btnDel.Attributes.Add("onclick", "return confirm('" + "确定要删除所选择的项吗？" + "');");
        btnPrint.Attributes.Add("onclick", "openwin1('ChuKuDanPrint.aspx','ChuKuDan','" + Session["ccodes"] + "','0','0','" + "" + "','','','')");



        dt = ds.Tables[0];
        dt.Columns.Add("rowNum");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["rowNum"] = i;
            //      string sql1 =
            //" select isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun from CurrentStock where cWhCode ='" +
            //dt.Rows[i]["whcode"] + "' and CurrentStock.cInvCode ='" + dt.Rows[i]["invcode"] +
            //"'  and (CurrentStock.isodid=0 or CurrentStock.isodid = '" + ViewState["SoDId"] + "') ";
            //      DataTable dt1 = SQLHelper.Query(sql1).Tables[0];

            //      double iValue = 0.00;
            //      if (dt1.Rows.Count == 0)
            //      {
            //          //dvr.Cells[6].Text = "0";
            //      }
            //      else
            //      {
            //          iValue = Math.Round(Convert.ToDouble(dt1.Rows[0][0]), 2);
            //      }
            //      dt.Rows[i]["xiancun"] = iValue.ToString("0.00");

        }

        ViewState["dt"] = dt;

        GridView2.DataSource = dt;
        GridView2.DataBind();


    }


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex > -1)
        {
            DataRowView row = e.Row.DataItem as DataRowView;

            TextBox cb = e.Row.FindControl("TextBox1") as TextBox;
            if (Convert.ToDouble(row["qty"]) == Convert.ToDouble(row["issqty"]))
            {
                cb.Visible = false;
            }
            else
            {
                cb.Visible = true;
                displayed = true;
            }


            string sql = "SELECT [cWhName],[cWhCode] from [Warehouse]";

            DataTable dataTable = SQLHelper.Query(sql).Tables[0]; ;
            //DataView dataView = dataTable.DefaultView;

            DropDownList DropDownList5 = e.Row.FindControl("DropDownList5") as DropDownList;

            HiddenField whcode = e.Row.FindControl("whcode") as HiddenField;

            HiddenField cInvCCode = e.Row.FindControl("cInvCCode") as HiddenField;
            TextBox xiancunHidden = e.Row.FindControl("xiancunHidden") as TextBox;

            DropDownList5.DataSource = dataTable;
            DropDownList5.DataValueField = "cWhCode";
            DropDownList5.DataTextField = "cWhName";
            DropDownList5.DataBind();

            DropDownList5.SelectedValue = row["whcode"].ToString();
        }

    }
    protected void btnLinLiao_Click(object sender, EventArgs e)
    {

        if (ViewState["IsForm1Valid"].ToString() == "true")
        {
            ///  
            ///正常的代码位于此位置  
            ///  
            try
            {
                string cCode = "";
                List<String> lst生产订单号组 = new List<string>();
                List<String> SQLStringList = new List<string>();
                string sql = "";
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    TextBox cb = GridView2.Rows[i].FindControl("TextBox1") as TextBox;

                    HiddenField AllocateId = GridView2.Rows[i].FindControl("AllocateId") as HiddenField;
                    HiddenField MoDId = GridView2.Rows[i].FindControl("MoDId") as HiddenField;
                    HiddenField SortSeq = GridView2.Rows[i].FindControl("SortSeq") as HiddenField;
                    HiddenField AutoID = GridView2.Rows[i].FindControl("AutoID") as HiddenField;
                    //HiddenField iSoType = GridView2.Rows[i].FindControl("iSoType") as HiddenField;


                    string temp = cb.Text;
                    if (string.IsNullOrEmpty(temp) || 0 == Convert.ToDouble(temp))
                    {
                        temp = "0";
                    }

                    if (cb.Visible && !"0".Equals(temp))
                    {
                        sql = " update mom_moallocate set IssQty = IssQty + " + temp + "  where AllocateId =" +
                              AllocateId.Value + " and MoDId=" + MoDId.Value + " and SortSeq=" + SortSeq.Value + "";
                        SQLStringList.Add(sql);

                        sql = " update CurrentStock set [fOutQuantity] = [fOutQuantity] + " + temp + " where AutoID =" + AutoID.Value + "   ";
                        SQLStringList.Add(sql);

                    }

                }

                DataTable dataTable = (DataTable)ViewState["dt"];
                DataView dataView = dataTable.DefaultView;
                DataTable dataTableDistinct = dataView.ToTable(true, "whcode");//注：其中ToTable（）的第一个参数为是否DISTINCT
                string depCode = this.HiddenField1.Value;
                string cPsPcode = this.HiddenField2.Value;
                string cMPoCode = this.HiddenField3.Value;
                string iMQuantity = this.HiddenField4.Value;
                string SortSeqMomDetail = this.SortSeq.Value;
                string soseq = this.soseq.Value;


                if (dataTableDistinct.Rows.Count > 0)
                {
                 
                   


                    //DataSet ds = SQLHelper.Query("select right('0000000000' + cast((max(cCode)+1) as varchar(10)),10) from RdRecord11 where ccode not like '-%' and cbustype='领料' ");
                    DataSet ds = SQLHelper.Query("  select right('0000000000' + cast((cNumber+1) as varchar(10)),10) From VoucherHistory   Where  CardNumber='0412' and cContent is NULL");

                    cCode = ds.Tables[0].Rows[0][0].ToString();
                    for (int i = 0; i < dataTableDistinct.Rows.Count; i++)
                    {

                        int curId = 0;
                        int autoid = 0;
                      
                        DataRow[] drs = dataTable.Select("whcode = '" + dataTableDistinct.Rows[i][0] + "'");
                        int needCnt = 0;
                        foreach (DataRow dataRow in drs)
                        {
                            TextBox tb = (TextBox)GridView2.Rows[Convert.ToInt32(dataRow["rowNum"])].FindControl("TextBox1");
                            string temp = tb.Text;
                            if (string.IsNullOrEmpty(temp) || 0 == Convert.ToDouble(temp))
                            {
                                temp = "0";
                            }

                            if (!"0".Equals(temp))
                            {
                                needCnt++;
                            }
                        }

                        bool mainTableAdded = false;

                        int iRowNo = 1;
                        //SQLHelper.ExecuteSql(sql);
                        foreach (DataRow dataRow in drs)
                        {
                           
                            int isotype = 0;
                            int isodid = 0;
                            try
                            {
                                if (Convert.ToInt32(dataRow["SoDId"]) != 0)
                                {
                                    isodid = Convert.ToInt32(dataRow["SoDId"]);
                                    isotype = 1;
                                }
                            }
                            catch (Exception)
                            {
                                                             
                            }
                           

                            TextBox tb = (TextBox)GridView2.Rows[Convert.ToInt32(dataRow["rowNum"])].FindControl("TextBox1");
                            TextBox cdefine28 = (TextBox)GridView2.Rows[Convert.ToInt32(dataRow["rowNum"])].FindControl("cdefine28");
                            
                            HiddenField AllocateId = GridView2.Rows[Convert.ToInt32(dataRow["rowNum"])].FindControl("AllocateId") as HiddenField;
                            string temp = tb.Text;
                            if (string.IsNullOrEmpty(temp) || 0 == Convert.ToDouble(temp))
                            {
                                temp = "0";
                            }

                            if (!"0".Equals(temp))
                            {

                                if (!mainTableAdded)
                                {//CONVERT(VARCHAR(10),GETDATE(),120)

                                    SqlParameter[] par = new SqlParameter[5];
                                    par[0] = new SqlParameter("@iAmount", needCnt);

                                    string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
                                    string DataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration//DataBaseName").InnerText.Trim();
                                    string[] a = DataBaseName.Split('_');
                                    par[1] = new SqlParameter("@cAcc_Id", a[1]);

                                    par[2] = new SqlParameter("@cVouchType", "rd");
                                    par[3] = new SqlParameter("@iFatherId", SqlDbType.NVarChar, 30);
                                    par[4] = new SqlParameter("@iChildId", SqlDbType.NVarChar, 30);
                                    par[3].Direction = ParameterDirection.Output;
                                    par[4].Direction = ParameterDirection.Output;
                                    SQLHelper.RunProcedure("sp_GetID", par);

                                    curId = Convert.ToInt32(par[3].SqlValue.ToString());
                                    autoid = Convert.ToInt32(par[4].SqlValue.ToString()) - needCnt + 1;


                                    sql = "INSERT [RdRecord11] ([ID], [bRdFlag], [cVouchType], [cBusType], [cSource], [cBusCode], [cWhCode], [dDate], [cCode], [cRdCode],[cDepCode], [cMaker], [iMQuantity], [VT_ID],[cPsPcode], [cMPoCode],[ipurorderid],cDefine16,bOMFirst,bredvouch,[cDefine14])" +
                                           "VALUES (" + curId + ", 0, N'11', N'领料', N'生产订单', NULL, N'" + dataTableDistinct.Rows[i][0] + "', '" + txtDate.Text + "', '" + cCode + "', N'" + DropDownList2.SelectedValue + "', N'" + depCode + "', N'" + User.Identity.Name + "', " + iMQuantity + ", 65, '" + cPsPcode + "', '" + dataRow["mocode"] + "'," + ViewState["mom_orderdetailmoDid"].ToString() + ",1,0, NULL,'" + DropDownList4.SelectedItem.Text.Trim() + "' )";
                                    SQLStringList.Add(sql);
                                    mainTableAdded = true;

                                    //lst生产订单号组.Add(cCode);
                                    //cCode = (System.Convert.ToInt32(cCode) + 1).ToString().PadLeft(10, '0');
                                    //curId++;
                                }

                                sql = "INSERT [RdRecords11] ([autoid],[ID], [cInvCode], [iQuantity],[iSQuantity],[iSOutNum],[iSOutQuantity],[iFNum],[iFQuantity],iNQuantity,iMPoIds,[iSoDID],iorderdid,iordercode,csocode,isotype,cbaccounter,bcosting,iVMISettleNum,iVMISettleQuantity,corufts,cdefine28,iSNum,invcode,imoseq,iopseq,iExpiratDateCalcu,iorderseq,isoseq,iposflag,cmocode,irowno) " +
                                        "VALUES (" + autoid + "," + curId + ", '" + dataRow["invcode"] + "', " + tb.Text + ",null,null,null,null,null," + dataRow["qty"] + "," + AllocateId.Value + "," + isodid + ",'" + dataRow["orderdid"] + "','" + dataRow["ordercode"] + "','" + dataRow["socode"] + "'," + isotype + ",null,1,null,null,null,'" + cdefine28.Text + "','0.0000000000', '" + cPsPcode + "',  '" + SortSeqMomDetail + "' , '0000','0', '" + soseq + "','" + soseq + "', NULL, '" + dataRow["mocode"] + "' ,'" + iRowNo++ + "')";
                                SQLStringList.Add(sql);


                                sql = "select * from SCM_Item where cInvCode ='" + dataRow["invcode"] +"'";
                                if (SQLHelper.Query(sql).Tables[0].Rows.Count==0)
                                {
                                    sql = "INSERT [SCM_Item] ([cInvCode])  VALUES ('" + dataRow["invcode"] + "')";
                                    SQLStringList.Add(sql);
                                }

                                sql = "INSERT [IA_ST_UnAccountVouch11] ([IDUN], [IDSUN],[cVouTypeUN],[cBustypeUN])" +
                                          "VALUES (" + curId +","+ autoid + ", N'11', N'领料' )";
                                SQLStringList.Add(sql);
                                autoid++;


                                //if (mainTableAdded)
                                //{
                                //    lst生产订单号组.Add(cCode);
                                //    curId++;
                                //    cCode = (System.Convert.ToInt32(cCode) + 1).ToString().PadLeft(10, '0');
                                //}                   

                            }
                            //SQLHelper.ExecuteSql(sql);                      
                        }

                        if (mainTableAdded)
                        {
                            lst生产订单号组.Add(cCode);
                            //curId++;
                            cCode = (System.Convert.ToInt32(cCode) + 1).ToString().PadLeft(10, '0');
                        }

                    }

                    if (lst生产订单号组.Count>0)
                    {
                        sql =
                            "update  VoucherHistory  set cNumber=" + (Convert.ToInt32(cCode)-1) + "  Where  CardNumber='0412' and cContent is NULL";
                        SQLStringList.Add(sql);                 
                    }


                    if (SQLStringList.Count == 0)
                    {
                        //MessageBox.Show(this, "没有任何数据");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有任何数据!')", true);

                        return;
                    }

                    //string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
                    //string DataBaseName = XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration//DataBaseName").InnerText.Trim();
                    //string[] a = DataBaseName.Split('_');

                    //sql = " update [UFSystem].[dbo].[UA_Identity] set [iFatherId]='" + --curId + "', [iChildId]='" + --autoid + "' where [cAcc_Id]=" + a[1] + " and cvouchType='rd' ";
                    //SQLStringList.Add(sql);

                    if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                    {
                        //Response.Write("<script>alert('生成报表失败');</script>");
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('生成报表失败!')", true);

                        //MessageBox.Show(this, "生成报表失败");
                        return;
                    }

                    string tmp = "";
                    foreach (string VARIABLE in lst生产订单号组)
                    {
                        tmp += VARIABLE + ",";
                    }
                    if (tmp.EndsWith(","))
                    {
                        tmp = tmp.Substring(0, tmp.Length - 1);
                    }

                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('单据号：" + tmp + " 成功生成报表!');window.opener.__doPostBack('ctl00$MainContent$btnFilter','');window.location.reload();", true);
                    Session["ccodes"] = tmp;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有任何数据!')", true);
                }

                //MessageBox.ShowAndRefreshFather(this, "成功生成报表");
                //Response.Write("<script>window.close();</script>");// 会弹出询问是否关闭
                //Response.Write("<script>window.opener=null;window.close();</script>");// 不会弹出询问
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                //MessageBox.Show(this, ex.Message);

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('" + ex.Message + "!')", true);
            }

            ViewState["IsForm1Valid"] = "false";
            //Server.Transfer("WebForm2.aspx");
        }
        else
        {
            //Label1.Visible = true;
        }


    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        btnLinLiao.Visible = displayed;
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((WebControl)e.CommandSource).NamingContainer);

        switch (e.CommandName)
        {

            case "Modify":
                //string parValue = e.CommandArgument.ToString();

                string AllocateId = ((HiddenField)row.FindControl("AllocateId")).Value;
                //string cInvCode = ((HiddenField)row.FindControl("cInvCode")).Value;
                string DropDownList5 = ((DropDownList)row.FindControl("DropDownList5")).SelectedValue;
                //string dateTxtBox = ((TextBox)row.FindControl("dateTxtBox")).Text;

                List<String> SQLStringList = new List<string>();
                String sql = "";
                sql = "update mom_moallocate set whcode='" + DropDownList5 + "' where AllocateId=" + AllocateId + "";
                SQLStringList.Add(sql);
                //sql = "update Inventory set [cinvdefine4]='" + DropDownList5 + "' where cInvCode='" + cInvCode + "'";
                //SQLStringList.Add(sql);

                if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                {
                    //Response.Write("<script>alert('生成报表失败');</script>");
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);

                    //MessageBox.Show(this, "更新数据失败");

                    //Response.Write();
                    //return;
                }
                else
                {

                    //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功更新数据!')", true);
                    //MessageBox.Show(this, "成功更新数据");
                    Bind();
                    //return;
                }
                break;

            default:
                break;
        }

    }


    protected void btnDel_Click(object sender, EventArgs e)
    {

        string sql = "";
        bool ischecked = false;
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            CheckBox cb = GridView2.Rows[i].FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {
                ischecked = true;
            }
        }

        if (!ischecked)
        {
            //MessageBox.Show(this, "没有选择任何项");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有选择任何项!')", true);

            return;
        }

        List<String> SQLStringList = new List<string>();
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            CheckBox cb = GridView2.Rows[i].FindControl("CheckBox1") as CheckBox;

            if (cb.Checked)
            {

                //if (SQLHelper.Exists("select * from [mom_moallocate] where modid=" + modid.Value + " and InvCode='" +
                //                GridView2.Rows[i].Cells[2].Text + "'"))
                //{
                //    MessageBox.Show(this, "材料编码: " + GridView2.Rows[i].Cells[2].Text + " 已经领用部分,无法将其删除掉.");
                //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('删除材料失败!')", true);
                //    return;
                //}
                double yiling = Convert.ToDouble(GridView2.Rows[i].Cells[5].Text);
                if (yiling != 0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('材料编码: " + GridView2.Rows[i].Cells[2].Text + "已经领用部分,无法将其删除掉!')", true);
                    return;
                }
                HiddenField AllocateId = GridView2.Rows[i].FindControl("AllocateId") as HiddenField;
                sql = " delete from [mom_moallocate]  where AllocateId = " + AllocateId.Value;
                SQLStringList.Add(sql);
            }

        }

        if (SQLStringList.Count == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有任何数据!')", true);

            //MessageBox.Show(this, "没有任何数据");
            return;
        }
        if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
        {
            //Response.Write("<script>alert('生成报表失败');</script>");
            //MessageBox.Show(this, "删除材料失败");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('删除材料失败!')", true);

            return;
        }
        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('成功删除材料!')", true);

        //MessageBox.Show(this, "成功删除材料");
        Bind();
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList da = (DropDownList)sender;
        //得到DropDownList 选中的值
        string WhCode = da.SelectedValue;
        System.Web.UI.WebControls.GridViewRow row = (System.Web.UI.WebControls.GridViewRow)da.NamingContainer;
        //得到选中DropDownList 所在行的某字段值
        //string bbbc = dvr.Cells[1].Text;

        string iSoType = ((HiddenField)row.FindControl("iSoType")).Value;



        string sql =
            " select isnull(CurrentStock.iQuantity - CurrentStock.fOutQuantity,0) xiancun, CurrentStock.AutoID from CurrentStock where cWhCode ='" +
            WhCode + "' and CurrentStock.cInvCode ='" + row.Cells[2].Text +
            "'  and (CurrentStock.isodid=0 or CurrentStock.isodid = '" + ViewState["SoDId"] + "' ) ";

        if (!String.IsNullOrEmpty(iSoType))
        {
            sql += " and iSoType=" + iSoType + "   ";
        }
        DataTable dt = SQLHelper.Query(sql).Tables[0];

        double iValue = 0.00;
        DataTable dtTemp = (DataTable)ViewState["dt"];
        if (dt.Rows.Count == 0)
        {
            //dvr.Cells[6].Text = "0";
        }
        else
        {
            iValue = Math.Round(Convert.ToDouble(dt.Rows[0][0]), 2);
            dtTemp.Rows[row.RowIndex]["AutoID"] = Convert.ToInt32(dt.Rows[0][1]);

            HiddenField hdAutoID = GridView2.Rows[row.RowIndex].FindControl("AutoID") as HiddenField;
            hdAutoID.Value = Convert.ToInt32(dt.Rows[0][1]).ToString();

        }

        row.Cells[6].Text = iValue.ToString("0.00");

        dtTemp.Rows[row.RowIndex]["whcode"] = WhCode;




        ViewState["dt"] = dtTemp;
        //GridView2.DataSource = dtTemp;
        //GridView2.DataBind();

        TextBox xiancunHidden = row.FindControl("xiancunHidden") as TextBox;
        xiancunHidden.Text = iValue.ToString("0.00");

        //string invcode = ((Label)row.FindControl("invcode")).Text;
        string cInvCode = ((HiddenField)row.FindControl("cInvCode")).Value;
        string DropDownList5 = ((DropDownList)row.FindControl("DropDownList5")).SelectedValue;
        //string dateTxtBox = ((TextBox)row.FindControl("dateTxtBox")).Text;

        List<String> SQLStringList = new List<string>();
        //String sql = "";
        sql = "update Inventory set cDefWareHouse='" + DropDownList5 + "' where [cInvCode]='" + cInvCode + "'";
        SQLStringList.Add(sql);


        if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
        {
            //Response.Write("<script>alert('生成报表失败');</script>");
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('更新数据失败!')", true);

        }

    }

}