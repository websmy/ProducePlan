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

    private string[] a = new string[] { "菲尔产成品库", "菲尔半成品库", "转序半成品库", "菲尔轨道风机事业部成品库", "菲尔轨道风机事业部半成品库", "菲尔离心风机事业部成品库", "菲尔离心风机事业部半成品库", "维修成品库", "技术部库" };
    private string[] b = new string[] { "产成品入库", "半成品入库", "返厂维修入库", "外协加工入库" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

         
            if (ViewState["IsForm1Valid"] == null)
            {
                ViewState["IsForm1Valid"]= "true";
                ///下接初始化代码
             
            }
            else
            {
                if (ViewState["IsForm1Valid"].ToString() == "false") ;//刷新 Label1.Visible = true;  
            }

           //string a=  Request.QueryString["p7"];
            getParam();

            BindCombox();
            //Button1.Attributes.Add("onclick", "window.opener=null;window.close()");
        }

        //sb保存的是JavaScript脚本代码,点击提交按钮时执行该脚本
        StringBuilder sb = new StringBuilder();
        //保证验证函数的执行 
        sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate('G1') == false) { return false; }};");
        //点击提交按钮后设置Button的disable属性防止用户再次点击,注意这里的this是JavaScript代码
        sb.Append("this.disabled  = true;");
        //用__doPostBack来提交，保证按钮的服务器端click事件执行 
        sb.Append(this.ClientScript.GetPostBackEventReference(this.Button1, ""));
        sb.Append(";");
        //SetUIStyle()是JavaScript函数,点击提交按钮后执行,如可以显示动画效果提示后台处理进度
        //注意SetUIStyle()定义在aspx页面中
        //sb.Append("SetUIStyle();");
        //给提交按钮增加OnClick属性
        this.Button1.Attributes.Add("onclick", sb.ToString());
    }

    private void BindCombox()
    {
        Label1.Text = 销售订单号.Value;
        string sql = "SELECT [cWhName],[cWhCode] from [Warehouse]";
        DataSet ds = SQLHelper.Query(sql);

        DataTable dataTable = ds.Tables[0]; ;
        DataRow dr3 = dataTable.NewRow();
        dr3["cWhName"] = "请选择";
        dr3["cWhCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);

        for (int i = 1; i < dataTable.Rows.Count; i++)
        {
            if (!a.Contains(dataTable.Rows[i]["cWhName"].ToString().Trim()))
            {
                dataTable.Rows[i].Delete();
            }
        }

        DropDownList1.DataSource = dataTable;
        DropDownList1.DataTextField = "cWhName";
        DropDownList1.DataValueField = "cWhCode";
        DropDownList1.DataBind();

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

        DropDownList3.DataSource = dataTable;
        DropDownList3.DataValueField = "cValue";
        DropDownList3.DataValueField = "cValue";
        DropDownList3.DataBind();
    }

    private void getParam()
    {

        string parValue = Request.QueryString["id"];
        if (String.IsNullOrEmpty(parValue))
        {
            Response.Write("<script>window.close();</script>");
            Response.Redirect("./Mom.aspx");
            Response.End();
        }

        this.ID.Value = parValue;
        this.部门.Value = Request.QueryString["p1"];
        this.班组.Value = Request.QueryString["p2"];
        this.销售订单号.Value = Request.QueryString["p3"];
        this.生产订单号.Value = Request.QueryString["p4"];
        this.产品编码.Value = Request.QueryString["p5"];
        this.sodid.Value = Request.QueryString["p6"];
        this.订单数量.Value = Request.QueryString["p7"];
        订单数量Hidden.Text = (Convert.ToDouble(Request.QueryString["p7"]) -
            Convert.ToDouble(Request.QueryString["p8"])).ToString();
        this.MoId.Value = Request.QueryString["MoId"];
        this.SortSeq.Value = Request.QueryString["SortSeq"];
        this.soseq.Value = Request.QueryString["soseq"];
        this.MoDId.Value = Request.QueryString["MoDId"];

        //this.iunitcost.Value = Request.QueryString["p9"];
        TextBox1.Text = 订单数量Hidden.Text;
        TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["IsForm1Valid"].ToString() == "true")
        {

            try
            {
                double iUnitPrice = 0;
                bool hasError = false;
                string sql4 = "select iNatUnitPrice from [SO_SODetails] where isosid=" + sodid.Value + " and iRowNo='" +
                              this.soseq.Value + "'";
                DataSet ds4 = SQLHelper.Query(sql4);

                //iUnitPrice = 12345;
                if (ds4.Tables[0].Rows.Count == 1)
                {
                    try
                    {
                        iUnitPrice = Convert.ToDouble(ds4.Tables[0].Rows[0]["iNatUnitPrice"]);
                    }
                    catch (Exception)
                    {
                        hasError = true;
                        //iUnitPrice = Convert.ToDouble(ds4.Tables[0].Rows[0]["iNatUnitPrice"]);
                        //throw;
                    }

                }
                else
                {
                    hasError = true;
                }


                List<String> SQLStringList = new List<string>();
                string sql = "";
                string sql3 = "select * from SCM_Item where cInvCode='" + this.产品编码.Value + "'";
                //string sql2 = "select * from CurrentStock where isodid=" + sodid.Value;
                DataSet ds3 = SQLHelper.Query(sql3);
                int itemId = 0;
                if (ds3.Tables[0].Rows.Count == 1)
                {
                    itemId = Convert.ToInt32(ds3.Tables[0].Rows[0]["Id"]);
                }
                else
                {
                    itemId = SQLHelper.GetMaxID("Id", "SCM_Item");
                    sql = "set identity_insert [SCM_Item] ON INSERT [SCM_Item] ([cInvCode],[Id]) VALUES ('" + 产品编码.Value +
                          "'," + itemId + ") set identity_insert [SCM_Item] OFF";
                    SQLStringList.Add(sql);
                }

                DataSet ds1 = SQLHelper.Query("SELECT cSRPolicy FROM Inventory where cinvcode='" + this.产品编码.Value + "'");
                string cSRPolicy = ds1.Tables[0].Rows[0][0].ToString();


                string sql2 = "";
                if ("LP".Equals(cSRPolicy))
                {
                    sql2 = "select * from CurrentStock where cWhCode='" + DropDownList1.SelectedValue +
                           "' and cInvCode='" + this.产品编码.Value + "' and isodid=" + sodid.Value;

                }
                else if ("PE".Equals(cSRPolicy))
                {
                    sql2 = "select * from CurrentStock where cWhCode='" + DropDownList1.SelectedValue +
                           "' and cInvCode='" + this.产品编码.Value + "' and isodid=" + 0;

                }
                //string sql2 = "select * from CurrentStock where cWhCode='" + DropDownList1.SelectedValue + "' and cInvCode='" + this.产品编码.Value + "' " ;
                //string sql2 = "select * from CurrentStock where isodid=" + sodid.Value;
                DataSet ds2 = SQLHelper.Query(sql2);

                int curId = 0;
                int autoid = 0;
                int needCnt = 1;
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
                autoid = Convert.ToInt32(par[4].SqlValue.ToString()) - needCnt +1 ;


                //int curId = SQLHelper.GetMaxID("ID", "RdRecord10");
                //int autoid = SQLHelper.GetMaxID("autoID", "RdRecords10");

                //int autoid_CurrentStock = SQLHelper.GetMaxID("autoID", "CurrentStock");

                DataSet ds =
             SQLHelper.Query("  select right('0000000000' + cast((cNumber+1) as varchar(10)),10) From VoucherHistory   Where  CardNumber='0411' and cContent is NULL");

                string cCode = ds.Tables[0].Rows[0][0].ToString();
                //CONVERT(VARCHAR(10),GETDATE(),120)

                if ("27".Equals(DropDownList1.SelectedValue))
                {
                    sql =
                        "INSERT [RdRecord10] ([ID], [bRdFlag], [cVouchType], [cBusType], [cSource], [cBusCode], [cWhCode], [dDate], [cCode], [cRdCode], [cDepCode], [cMaker], [cDefine14], [VT_ID], [cMPoCode],cHandler,dVeriDate,iproorderid )" +
                        "VALUES (" + curId + ", 1, N'10', N'成品入库', N'生产订单', NULL, N'" + DropDownList1.SelectedValue +
                        "', '" + TextBox2.Text + "', '" + cCode + "', N'" + DropDownList2.SelectedValue + "', N'" +
                        ID.Value + "', N'" + User.Identity.Name + "', '" + DropDownList3.SelectedItem.Text.Trim() +
                        "', 63, '" + 生产订单号.Value + "','" + User.Identity.Name +
                        "',CONVERT(VARCHAR(10),GETDATE(),120),'" + MoId.Value + "' )";
                    SQLStringList.Add(sql);

                }
                else
                {
                    sql =
                        "INSERT [RdRecord10] ([ID], [bRdFlag], [cVouchType], [cBusType], [cSource], [cBusCode], [cWhCode], [dDate], [cCode], [cRdCode], [cDepCode], [cMaker], [cDefine14], [VT_ID], [cMPoCode],iproorderid )" +
                        "VALUES (" + curId + ", 1, N'10', N'成品入库', N'生产订单', NULL, N'" + DropDownList1.SelectedValue +
                        "', '" + TextBox2.Text + "', '" + cCode + "', N'" + DropDownList2.SelectedValue + "', N'" +
                        ID.Value + "', N'" + User.Identity.Name + "', '" + DropDownList3.SelectedItem.Text.Trim() +
                        "', 63, '" + 生产订单号.Value + "' ,'" + MoId.Value + "')";
                    SQLStringList.Add(sql);

                }

                if (hasError)
                {
                    if ("0".Equals(sodid.Value))
                    {
                        //double iprice = Convert.ToDouble(TextBox1.Text) * Convert.ToDouble(iunitcost.Value);
                        sql =
                            "INSERT [RdRecords10] ([autoid],[ID], [cInvCode], [iQuantity],iMPoIds,imoseq,isoseq,isodid,iorderdid,csocode,iordercode,cMoCode,isotype,cbaccounter,bcosting,iVMISettleNum,iVMISettleQuantity,iSOutQuantity,iSOutNum,iFNum,iFQuantity,bRelated,bVMIUsed,corufts,irowno,iorderseq,iNQuantity,iordertype) VALUES (" +
                            autoid + "," + curId + ", '" + 产品编码.Value + "', " + TextBox1.Text + ",'" + MoDId.Value +
                            "','" + SortSeq.Value + "','" + soseq.Value + "','" + sodid.Value + "','" + sodid.Value + "','" + 销售订单号.Value + "','" + 销售订单号.Value + "','" + 生产订单号.Value + "'," + 0 + ",null,1,null,null,null,null,null,null,0,null,null,'1','" + soseq.Value + "','" + TextBox1.Text + "','1' )";
                        SQLStringList.Add(sql);
                    }
                    else
                    {
                        //double iprice = Convert.ToDouble(TextBox1.Text) * Convert.ToDouble(iunitcost.Value);
                        sql =
                            "INSERT [RdRecords10] ([autoid],[ID], [cInvCode], [iQuantity],iMPoIds,imoseq,isoseq,isodid,iorderdid,csocode,iordercode,cMoCode,isotype,cbaccounter,bcosting,iVMISettleNum,iVMISettleQuantity,iSOutQuantity,iSOutNum,iFNum,iFQuantity,bRelated,bVMIUsed,corufts,irowno,iorderseq,iNQuantity,iordertype) VALUES (" +
                            autoid + "," + curId + ", '" + 产品编码.Value + "', " + TextBox1.Text + ",'" + MoDId.Value +
                            "','" + SortSeq.Value + "','" + soseq.Value + "','" + sodid.Value + "','" + sodid.Value + "','" + 销售订单号.Value + "','" + 销售订单号.Value + "','" + 生产订单号.Value + "'," + 1 + ",null,1,null,null,null,null,null,null,0,null,null,'1','" + soseq.Value + "','" + TextBox1.Text + "','1' )";
                        SQLStringList.Add(sql);
                    }
                }
                else
                {
                    if ("0".Equals(sodid.Value))
                    {
                        double iprice = Convert.ToDouble(TextBox1.Text)*iUnitPrice;
                        sql =
                            "INSERT [RdRecords10] ([autoid],[ID], [cInvCode], [iQuantity],iMPoIds,imoseq,isoseq,isodid,iorderdid,csocode,iordercode,cMoCode,iunitcost,iprice,isotype,cbaccounter,bcosting,iVMISettleNum,iVMISettleQuantity,iSOutQuantity,iSOutNum,iFNum,iFQuantity,bRelated,bVMIUsed,corufts,irowno,iorderseq,iNQuantity,iordertype) VALUES (" +
                            autoid + "," + curId + ", '" + 产品编码.Value + "', " + TextBox1.Text + ",'" + MoDId.Value +
                            "','" + SortSeq.Value + "','" + soseq.Value + "','" + sodid.Value + "','" + sodid.Value + "','" + 销售订单号.Value + "','" + 销售订单号.Value + "','" + 生产订单号.Value + "'," + iUnitPrice + "," + iprice + "," + 0 +
                            ",null,1,null,null,null,null,null,null,0,null,null,'1','" + soseq.Value + "','" + TextBox1.Text + "','1' )";
                        SQLStringList.Add(sql);
                    }
                    else
                    {
                        double iprice = Convert.ToDouble(TextBox1.Text)*iUnitPrice;
                        sql =
                            "INSERT [RdRecords10] ([autoid],[ID], [cInvCode], [iQuantity],iMPoIds,imoseq,isoseq,isodid,iorderdid,csocode,iordercode,cMoCode,iunitcost,iprice,isotype,cbaccounter,bcosting,iVMISettleNum,iVMISettleQuantity,iSOutQuantity,iSOutNum,iFNum,iFQuantity,bRelated,bVMIUsed,corufts,irowno,iorderseq,iNQuantity,iordertype) VALUES (" +
                            autoid + "," + curId + ", '" + 产品编码.Value + "', " + TextBox1.Text + ",'" + MoDId.Value +
                            "','" + SortSeq.Value + "','" + soseq.Value + "','" + sodid.Value + "','" + sodid.Value + "','" + 销售订单号.Value + "','" + 销售订单号.Value + "','" + 生产订单号.Value + "'," + iUnitPrice + "," + iprice + "," + 1 +
                            ",null,1,null,null,null,null,null,null,0,null,null,'1','" + soseq.Value + "','" + TextBox1.Text + "','1' )";
                        SQLStringList.Add(sql);
                    }
                }


                sql = "INSERT [IA_ST_UnAccountVouch10] ([IDUN], [IDSUN],[cVouTypeUN],[cBustypeUN])" +
                                        "VALUES (" + curId + "," + autoid + ", N'10', N'成品入库' )";
                SQLStringList.Add(sql);

                    sql =
                        "update  VoucherHistory  set cNumber=" + Convert.ToInt32(cCode) + "  Where  CardNumber='0411' and cContent is NULL";
                    SQLStringList.Add(sql);
                
                //try
                //{



                //}
                //catch (Exception)
                //{
                //    //double iprice = Convert.ToDouble(TextBox1.Text) * Convert.ToDouble(iunitcost.Value);
                //    //sql = "INSERT [RdRecords10] ([autoid],[ID], [cInvCode], [iQuantity],iMPoIds,isodid,isotype,cbaccounter,bcosting,iVMISettleNum,iVMISettleQuantit) VALUES (" + autoid + "," + curId + ", '" + 产品编码.Value + "', " + TextBox1.Text + ",'" + MoDId.Value + "','" + sodid.Value + "')";
                //    //SQLStringList.Add(sql);




                //    //throw;
                //}


                sql = " update mom_orderdetail set QualifiedInQty = QualifiedInQty + " + TextBox1.Text +
                      " where MoDId =" +
                      MoDId.Value + " and MoId=" + MoId.Value + " and SortSeq=" + SortSeq.Value + "";
                SQLStringList.Add(sql);


                if (订单数量Hidden.Text.Equals(TextBox1.Text.Trim()))
                {
                    sql =
                        " update mom_orderdetail set Status = 4, CloseDate=CONVERT(VARCHAR(10),GETDATE(),120), OrgClsDate=CONVERT(VARCHAR(10),GETDATE(),120),CloseUser='" +
                        User.Identity.Name + "' where MoDId =" +
                        MoDId.Value + " and MoId=" + MoId.Value + " and SortSeq=" + SortSeq.Value + "";
                    SQLStringList.Add(sql);
                }
                //cnt = 1;
                if (ds2.Tables[0].Rows.Count == 1)
                {
                    if ("27".Equals(DropDownList1.SelectedValue))
                    {
                        if ("LP".Equals(cSRPolicy))
                        {
                            sql = " update CurrentStock set iQuantity=iQuantity+" + TextBox1.Text +
                                  ",fAvaQuantity=fAvaQuantity+ " + TextBox1.Text + ",isotype=1 where cWhCode='" +
                                  DropDownList1.SelectedValue + "' and cInvCode='" + this.产品编码.Value + "' and isodid= " +
                                  sodid.Value;
                            SQLStringList.Add(sql);
                        }

                        if ("PE".Equals(cSRPolicy))
                        {
                            sql = " update CurrentStock set iQuantity=iQuantity+" + TextBox1.Text +
                                  ",fAvaQuantity=fAvaQuantity+ " + TextBox1.Text + ",isotype=0 where cWhCode='" +
                                  DropDownList1.SelectedValue + "' and cInvCode='" + this.产品编码.Value + "' and isodid= " +
                                  0;
                            SQLStringList.Add(sql);
                        }
                    }
                    else
                    {
                        if ("LP".Equals(cSRPolicy))
                        {
                            sql = " update CurrentStock set fInQuantity=fInQuantity+" + TextBox1.Text +
                                  ",fAvaQuantity=fAvaQuantity+ " + TextBox1.Text + ",isotype=1 where cWhCode='" +
                                  DropDownList1.SelectedValue + "' and cInvCode='" + this.产品编码.Value + "' and isodid= " +
                                  sodid.Value;
                            SQLStringList.Add(sql);
                        }

                        if ("PE".Equals(cSRPolicy))
                        {
                            sql = " update CurrentStock set fInQuantity=fInQuantity+" + TextBox1.Text +
                                  ",fAvaQuantity=fAvaQuantity+ " + TextBox1.Text + ",isotype=0 where cWhCode='" +
                                  DropDownList1.SelectedValue + "' and cInvCode='" + this.产品编码.Value + "' and isodid= " +
                                  0;
                            SQLStringList.Add(sql);
                        }
                    }



                }
                else
                {

                    if ("27".Equals(DropDownList1.SelectedValue))
                    {
                        if ("LP".Equals(cSRPolicy))
                        {
                            sql =
                                "INSERT [CurrentStock] ([cWhCode], [cInvCode], [iQuantity],fAvaQuantity,isodid,isotype,ItemId) VALUES ('" +
                                DropDownList1.SelectedValue + "', '" + 产品编码.Value + "'," + TextBox1.Text + " ," +
                                TextBox1.Text + "," + sodid.Value + ",1," + itemId + ")";
                            SQLStringList.Add(sql);
                        }

                        if ("PE".Equals(cSRPolicy))
                        {
                            sql =
                                "INSERT [CurrentStock] ([cWhCode], [cInvCode], [iQuantity],fAvaQuantity,isodid,isotype,ItemId) VALUES ('" +
                                DropDownList1.SelectedValue + "', '" + 产品编码.Value + "', " + TextBox1.Text + "," +
                                TextBox1.Text + "," + "0" + ",0," + itemId + ")";
                            SQLStringList.Add(sql);
                        }
                    }
                    else
                    {
                        if ("LP".Equals(cSRPolicy))
                        {
                            sql =
                                "INSERT [CurrentStock] ([cWhCode], [cInvCode], [fInQuantity],fAvaQuantity,isodid,isotype,ItemId) VALUES ('" +
                                DropDownList1.SelectedValue + "', '" + 产品编码.Value + "'," + TextBox1.Text + " ," +
                                TextBox1.Text + "," + sodid.Value + ",1," + itemId + ")";
                            SQLStringList.Add(sql);
                        }

                        if ("PE".Equals(cSRPolicy))
                        {
                            sql =
                                "INSERT [CurrentStock] ([cWhCode], [cInvCode], [fInQuantity],fAvaQuantity,isodid,isotype,ItemId) VALUES ('" +
                                DropDownList1.SelectedValue + "', '" + 产品编码.Value + "', " + TextBox1.Text + "," +
                                TextBox1.Text + "," + "0" + ",0," + itemId + ")";
                            SQLStringList.Add(sql);
                        }
                    }




                    if ("LP".Equals(cSRPolicy))
                    {
                    }

                    if ("PE".Equals(cSRPolicy))
                    {

                    }


                    //sql = "INSERT [CurrentStock] ([autoid],[cWhCode], [cInvCode], [iQuantity],isodid) VALUES (" + autoid_CurrentStock + "," + DropDownList1.SelectedValue + ", '" + 产品编码.Value + "', " + TextBox1.Text + ",'" + sodid.Value + "')";

                    //sql = " INSERT INTO [CurrentStock] ([],[]) [] CurrentStock set iQuantity=iQuantity+" + TextBox1.Text + ",fInQuantity = fInQuantity + " +
                    //     TextBox1.Text + ",isotype=1,isodid=" + sodid.Value + " where cWhCode='" + DropDownList1.SelectedValue + "' and cInvCode='" + this.产品编码.Value + "' ";
                    //SQLStringList.Add(sql);
                }

                if (SQLStringList.Count == 0)
                {
                    MessageBox.Show(this, "没有任何数据");
                    return;
                }

                //string strXmlFile = HttpContext.Current.Server.MapPath("~/config/conn.config");
                //string DataBaseName =
                //    XMLHelper.GetXmlNodeByXpath(strXmlFile, "//conn_configuration//DataBaseName").InnerText.Trim();
                //string[] a = DataBaseName.Split('_');

                //sql = " update [UFSystem].[dbo].[UA_Identity] set [iFatherId]='" + curId + "', [iChildId]='" + autoid +
                      //"' where [cAcc_Id]=" + a[1] + " and cvouchType='rd' ";
                //SQLStringList.Add(sql);
               
                if (SQLHelper.ExecuteSqlTran(SQLStringList) == 0)
                {
                    //Response.Write("<script>alert('生成报表失败');</script>");
                    MessageBox.Show(this, "生成报表失败");
                    return;
                }



                MessageBox.ShowAndRefreshMainTable(this, "单据号：" + cCode + " 成功生成报表");
                //Response.Write("<script>window.close();</script>");// 会弹出询问是否关闭
                //Response.Write("<script>window.opener=null;window.close();</script>");// 不会弹出询问


            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                MessageBox.Show(this, ex.Message);
            }

            ViewState["IsForm1Valid"] = "false";
        }
       
    }

}
