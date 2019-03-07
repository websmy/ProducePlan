using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_ChuKuDanPrint : System.Web.UI.Page
{
    //private const int rowTotal = 4;    
    //private int rowCount = 0;
    //private int ID = 0;
    //private double DHeJi = 0;
    private string ccodes;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ccodes = Request.QueryString["id"];
            if (String.IsNullOrEmpty(ccodes))
            {
                Response.Write("<script>alert('无数据');window.opener=null;window.close();</script>");
                //Response.Redirect("./Mom.aspx");
                Response.End();
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>				  ");
            stringBuilder.Append("<html xmlns='http://www.w3.org/1999/xhtml'>																																			   ");
            stringBuilder.Append("<head runat='server'>																																														");
            stringBuilder.Append("    <title>材料出库单预览</title>																																															  ");
            stringBuilder.Append("    <style type='text/css'>																																												 ");
            //stringBuilder.Append("     table {border: 1px solid #ff0000; }																																												 ");
            //stringBuilder.Append("     td { border: 1px solid #ff0000; }																																										 ");
            stringBuilder.Append("        .style1																																																	   ");
            stringBuilder.Append("        {																																																				 ");
            stringBuilder.Append("            width: 100%;																																														  ");
            stringBuilder.Append("            border: 1px;																																														  ");
            stringBuilder.Append("        }																																																				 ");
            stringBuilder.Append("    </style>																																																		");

            ////stringBuilder.Append("<script id=clientEventHandlersJS language=javascript> 																																					 ");
            ////stringBuilder.Append("function printpreview() 																																																		");
            ////stringBuilder.Append("{     																																																									");
            ////stringBuilder.Append("    WebBrowser1.ExecWB(7,1);     																																														   ");
            ////stringBuilder.Append(" window.close(); ");
            ////stringBuilder.Append("} 																																																										");
            ////stringBuilder.Append("</script> 																																																						   ");


            stringBuilder.Append("</head>																																																		  ");
            //stringBuilder.Append("<body onload='printpreview()' >																																																		   ");
            stringBuilder.Append("<body >																																																		   ");
            //stringBuilder.Append("    <OBJECT ID='WebBrowser1' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2' VIEWASTEXT></OBJECT> 				  ");

            stringBuilder.Append("    <form id='form1' runat='server'>																																								  ");
            stringBuilder.Append("    <div>																																																			 ");


            string sql =
           "select *  from RdRecord11  " +
           "left join warehouse on  warehouse.cwhcode=RdRecord11.cwhcode " +
           "left join Department on Department.cDepCode=RdRecord11.cDepCode " +
           "left join Rd_Style on Rd_Style.crdcode=RdRecord11.crdcode " +
           "where RdRecord11.ccode in (" + ccodes + ")";
            DataTable ChuKuDan = Helper.SQLHelper.Query(sql).Tables[0];
            for (int j = 0; j < ChuKuDan.Rows.Count; j++)
            {
                if (j + 1 == ChuKuDan.Rows.Count)
                {
                    stringBuilder.Append("        <table style='width: 20cm'>																																			 ");
                }
                else
                {
                    stringBuilder.Append("        <table style='width: 20cm;PAGE-BREAK-AFTER: always'>																																			 ");

                }
                //行开始=========================================
                stringBuilder.Append("            <tr>																																																	  ");
                stringBuilder.Append("                <td>																																																 ");
                stringBuilder.Append("                    <div align='center' >																																									  ");
                stringBuilder.Append("                        材料出库单</div>   																																									  ");
                stringBuilder.Append("                </td>																																																 ");
                stringBuilder.Append("            </tr>																																																	  ");
                //结束=========================================
                stringBuilder.Append("            <tr>																																																	  ");
                stringBuilder.Append("                <td>																																																 ");
                stringBuilder.Append("                    <table class='style1' cellpadding='2' cellspacing='2'>																												  ");
                stringBuilder.Append("                        <tr>																																														  ");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                出库单号																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																											");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["ccode"] + "</td>																																											");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                出库日期																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                " + Convert.ToDateTime(ChuKuDan.Rows[j]["ddate"]).ToString("yyyy-MM-dd") + "																																									   ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                仓库																																												 ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cWhName"] + "</td>																																								   ");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                生产部门																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																											");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cDepName"] + "</td>																																											");
                stringBuilder.Append("                        </tr>																																														  ");
                stringBuilder.Append("                        <tr>																																														  ");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                订单号																																											   ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																											");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cMPoCode"] + "</td>																																											");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                产品编码																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																										");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cPsPcode"] + "</td>																																											");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                出库类别																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																											");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cRdName"] + "</td>																																											");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                班组名称																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																											");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cdefine14"] + "</td>																																											");
                stringBuilder.Append("                        </tr>																																														  ");
                stringBuilder.Append("                        <tr>																																														  ");
                stringBuilder.Append("                            <td align='right'>																																								");
                stringBuilder.Append("                                备注																																												 ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                																																										");
                stringBuilder.Append("                                " + ChuKuDan.Rows[j]["cmemo"] + "</td>																																											");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                        </tr>																																														  ");
                stringBuilder.Append("                    </table>																																													   ");
                stringBuilder.Append("                </td>																																																 ");
                stringBuilder.Append("            </tr>																																																	  ");

                stringBuilder.Append("            <tr>																																																	  ");
                stringBuilder.Append("                <td>																																																 ");
                stringBuilder.Append("                    <table  class='style1' border='1' cellpadding='0' cellspacing='0'>																									");
                stringBuilder.Append("                        <tr >																																														  ");
                stringBuilder.Append("                            <td align='center' >																																						  ");
                stringBuilder.Append("                                销售订单号																																										  ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td  align='center'>																																							  ");
                stringBuilder.Append("                                材料编码																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td align='center'>																																							  ");
                stringBuilder.Append("                                材料名称																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td align='center'>																																							  ");
                stringBuilder.Append("                                规格型号																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td align='center'>																																							  ");
                stringBuilder.Append("                                主计量																																											   ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                数量																																												 ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                备注																																												 ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                        </tr>		  ");

                string sql_sub =
         "select * from RdRecords11 sub " +
                    //"left join RdRecord main on main.ID = sub.ID " +
         "left join inventory inv on inv.cinvcode=sub.cinvcode " +
         "left join ComputationUnit cunit  on cunit.cComunitCode=inv.cComUnitCode " +
         "where sub.ID = " + ChuKuDan.Rows[j]["ID"];
                DataTable ChuKuDan_Sub = Helper.SQLHelper.Query(sql_sub).Tables[0];

                
                for (int k = 0; k < ChuKuDan_Sub.Rows.Count; k++)
                {
                    DataTable ChuKuDan_Sub_1 = Helper.SQLHelper.Query("SELECT [cSOCode] FROM [SO_SODetails] where [iSOsID]='" + ChuKuDan_Sub.Rows[k]["iorderdid"] + "' ").Tables[0];
                    string temp = "";
                    if (ChuKuDan_Sub_1.Rows.Count>0)
                    {
                        temp = ChuKuDan_Sub_1.Rows[0]["cSOCode"].ToString();
                    }

                    stringBuilder.Append("                        <tr>																																														  ");
                    stringBuilder.Append("                            <td>																																													 ");
                    stringBuilder.Append("                                	&nbsp;																																									");
                    stringBuilder.Append("                                " +temp+ "</td>																																										   ");
                    stringBuilder.Append("                            <td colspan='1'>																																								   ");
                    stringBuilder.Append("                               	&nbsp;																																									");
                    stringBuilder.Append("                                " + ChuKuDan_Sub.Rows[k]["cinvcode"] + "</td>																																										   ");
                    stringBuilder.Append("                            <td>																																													 ");
                    stringBuilder.Append("                                	&nbsp;																																										");
                    stringBuilder.Append("                                " + ChuKuDan_Sub.Rows[k]["cinvname"] + "</td>																																										   ");
                    stringBuilder.Append("                            <td>																																													 ");
                    stringBuilder.Append("                                	&nbsp;																																									");
                    stringBuilder.Append("                                " + ChuKuDan_Sub.Rows[k]["cinvstd"] + "</td>																																										   ");
                    stringBuilder.Append("                            <td>																																													 ");
                    stringBuilder.Append("                               	&nbsp;																																								");
                    stringBuilder.Append("                                " + ChuKuDan_Sub.Rows[k]["cComUnitName"] + "</td>																																										   ");
                    stringBuilder.Append("                            <td>																																													 ");
                    stringBuilder.Append("                               	&nbsp;																																									");
                    stringBuilder.Append("                                " +Math.Round(Convert.ToDouble(ChuKuDan_Sub.Rows[k]["iquantity"]),2).ToString() + "</td>																																										   ");
                    stringBuilder.Append("                            <td>																																													 ");
                    stringBuilder.Append("                               	&nbsp;																																									");
                    stringBuilder.Append("                                " + ChuKuDan_Sub.Rows[k]["cdefine28"] + "</td>																																										   ");
                    stringBuilder.Append("                        </tr>																																														  ");

                }

                stringBuilder.Append("                        <tr>																																														  ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                合计：																																											   ");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                               &nbsp;																																										");
                decimal cnt = (decimal)SQLHelper.GetSingle("select sum(iquantity) from RdRecords11 where id =" + ChuKuDan.Rows[j]["ID"]);
                stringBuilder.Append("                                " + Math.Round(cnt, 2).ToString() + "</td>																																										   ");
                stringBuilder.Append("                            <td>																																													 ");
                stringBuilder.Append("                                &nbsp;																																											");
                stringBuilder.Append("                            </td>																																													 ");
                stringBuilder.Append("                        </tr>																																														  ");


                stringBuilder.Append("                    </table>																																													   ");
                stringBuilder.Append("                </td>																																																 ");
                stringBuilder.Append("            </tr>																																																	  ");

                stringBuilder.Append("<tr>												  ");
                stringBuilder.Append("     <td>											 ");
                stringBuilder.Append("         <table class='style1'>			 ");
                stringBuilder.Append("             <tr>									  ");
                stringBuilder.Append("                 <td align='right'>								 ");
                stringBuilder.Append("                     制单人						  ");
                stringBuilder.Append("                 </td>								 ");
                stringBuilder.Append("                 <td>								 ");
                stringBuilder.Append("                     &nbsp;						");
                stringBuilder.Append("                     " + ChuKuDan.Rows[j]["cmaker"] + "</td>					   ");
                stringBuilder.Append("                 <td align='right'>								 ");
                stringBuilder.Append("                     审核人						  ");
                stringBuilder.Append("                 </td>								 ");
                stringBuilder.Append("                 <td>								 ");
                stringBuilder.Append("                     &nbsp;						");
                stringBuilder.Append("                     " + ChuKuDan.Rows[j]["cHandler"] + "</td>					   ");
                stringBuilder.Append("                 <td>								 ");
                stringBuilder.Append("                     							 ");
                stringBuilder.Append("                 </td>								 ");
                stringBuilder.Append("             </tr>									 ");
                stringBuilder.Append("         </table>								   ");
                stringBuilder.Append("     </td>											 ");
                stringBuilder.Append(" </tr>												 ");

                stringBuilder.Append(" </table>												 ");

            }

            //stringBuilder.Append("</table>");

            stringBuilder.Append(" </div>");
            stringBuilder.Append(" </form>");
            stringBuilder.Append(" </body>");
            stringBuilder.Append(" </html>");

            Response.Write(stringBuilder.ToString());
          
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 