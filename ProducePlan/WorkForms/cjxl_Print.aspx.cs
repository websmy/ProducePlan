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

public partial class WorkForms_cjxl_Print : System.Web.UI.Page
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
            stringBuilder.Append(" <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            stringBuilder.Append(" <html xmlns='http://www.w3.org/1999/xhtml'>						   ");
            stringBuilder.Append(" <head>																					   ");
            stringBuilder.Append("     <title>下料单预览</title>																		  ");
            stringBuilder.Append("     <style type='text/css'>															 ");
            stringBuilder.Append("         .style1																				   ");
            stringBuilder.Append("         {																						 ");
            stringBuilder.Append("             width: 100%;																	  ");
            stringBuilder.Append("         }																						 ");
            stringBuilder.Append(" 																									 ");
            stringBuilder.Append("         .style2																				   ");
            stringBuilder.Append("         {																						 ");
            stringBuilder.Append("             text-align: right;															   ");
            stringBuilder.Append("         }																						 ");
            stringBuilder.Append(" 																									 ");
            stringBuilder.Append("     </style>																					");
            stringBuilder.Append(" </head>																					  ");
            stringBuilder.Append(" <body>																					   ");
            stringBuilder.Append(" 																									 ");
            stringBuilder.Append("     <div>																					 ");
            stringBuilder.Append("         																							 ");
            stringBuilder.Append("         <table class='style1' style='width: 21cm'>							");
            stringBuilder.Append("             <tr>																				  ");
            stringBuilder.Append("                 <td style='text-align: center'>																			 ");
            stringBuilder.Append("                     								  ");
            stringBuilder.Append("                         " +System.DateTime.Now.ToString("yyyy年MM月dd日") +"下料单							 ");
            stringBuilder.Append("                 </td>																		 ");
            stringBuilder.Append("             </tr>																			  ");

            string sql =
           "SELECT   SO_SOMain.cCusName,a.soseq, case when CHARINDEX(',',a.define25)>0 then substring(a.define25,1,CHARINDEX(',',a.define25)-1 ) when CHARINDEX(',',a.define25)<=0 then '' end as qian,case when CHARINDEX(',',a.define25)>0 then substring(a.define25,CHARINDEX(',',a.define25)+1,len(a.define25))when CHARINDEX(',',a.define25)<=0 then ''end as hou,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],a.SoCode,a.ordercode,a.orderseq,"
           +
           " mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate"
           + " FROM mom_orderdetail a LEFT JOIN mom_order ON a.moid = mom_order.moid"
           + " LEFT JOIN mom_morder ON a.modid = mom_morder.modid"
           + " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode"
           + " LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode]"
           + " LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID "
           + " LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode "


           //+ " WHERE  a.Status = 3 and a.[modid] in (" + ccodes + ")";
            +" WHERE   a.[modid] in (" + ccodes + ")";
            sql += " and 1=1 ";
            DataTable XiaLiaoDan = Helper.SQLHelper.Query(sql).Tables[0];
            for (int j = 0; j < XiaLiaoDan.Rows.Count; j++)
            {

                stringBuilder.Append("             <tr>																				  ");
                stringBuilder.Append("                 <td>																			 ");
                stringBuilder.Append("                 <table class='style1'>												  ");
                stringBuilder.Append("                     <tr>																  ");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             销售订单号</td>									  ");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             &nbsp;" + XiaLiaoDan.Rows[j]["ordercode"] +
                                     "</td>											");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             生产订单号</td>									  ");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             &nbsp;" + XiaLiaoDan.Rows[j]["mocode"] +
                                     "</td>											");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             产品编码</td>										");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             &nbsp;" + XiaLiaoDan.Rows[j]["InvCode"] +
                                     "</td>											");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             名称</td>												");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             &nbsp;" + XiaLiaoDan.Rows[j]["cinvname"] +
                                     "</td>											");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             数量</td>												");
                stringBuilder.Append("                         <td>															 ");
                stringBuilder.Append("                             &nbsp;" +
                                     String.Format("{0:0.00}", Convert.ToDouble(XiaLiaoDan.Rows[j]["Qty"])) +
                                     "</td>											");
                stringBuilder.Append("                     </tr>															 ");
                stringBuilder.Append("                 </table>																	   ");
                stringBuilder.Append("                 </td>																		 ");
                stringBuilder.Append("             </tr>																			  ");
                stringBuilder.Append("             <tr>																				  ");
                stringBuilder.Append("                 <td>																			 ");
                stringBuilder.Append("                     <table class='style1' border='1' cellspacing='0'>	 ");
                stringBuilder.Append("                         <tr>																	  ");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 零件名称</td>															");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 每台数量</td>															");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 板材编码</td>															");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 下料尺寸</td>															");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 板厚</td>																	");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 材质</td>																	");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 设备</td>																	");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 加工说明</td>															");
                stringBuilder.Append("             <td >											   ");
                stringBuilder.Append("                 完工日期</td>															");
                stringBuilder.Append("                         </tr>																  ");
                sql = "select * from xialiao where [产品编码]='" + XiaLiaoDan.Rows[j]["InvCode"] + "' ";
                DataTable XiaLiaoData = SQLHelper1.Query(sql).Tables[0];
                for (int i = 0; i < XiaLiaoData.Rows.Count; i++)
                {
                    stringBuilder.Append("         <tr>																			  ");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][2] + "</td>														  ");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][3] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][4] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][5] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][6] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][7] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][8] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + XiaLiaoData.Rows[i][9] + "</td>														");
                    stringBuilder.Append("             <td>																		 ");
                    stringBuilder.Append("                 &nbsp;" + " <input id='Text1' style='width: 70px' type='text' />" + "</td>														");

                    stringBuilder.Append("         </tr>																		 ");
                }
                stringBuilder.Append("                     </table>																   ");
                stringBuilder.Append("                 </td>																		 ");
                stringBuilder.Append("             </tr>																			  ");

                
                //stringBuilder.Append("                         <tr>																	  ");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                             <td>																 ");
                //stringBuilder.Append("                                 &nbsp;</td>												");
                //stringBuilder.Append("                         </tr>																  ");


            }

            //stringBuilder.Append("             <tr>																				  ");
            //stringBuilder.Append("                 <td>																			 ");
            //stringBuilder.Append("                     <table class='style1'>											  ");
            //stringBuilder.Append("                         <tr>																	  ");
            //stringBuilder.Append("                             <td class='style2'>											");
            //stringBuilder.Append("                                 制单人</td>												  ");
            //stringBuilder.Append("                             <td class='style2' style='width: 3cm'>			  ");
            //stringBuilder.Append("                                 &nbsp;</td>												");
            //stringBuilder.Append("                             <td class='style2' style='width: 2cm'>			  ");
            //stringBuilder.Append("                                 接收人</td>												  ");
            //stringBuilder.Append("                             <td class='style2' style='width: 3cm'>			  ");
            //stringBuilder.Append("                                 &nbsp;</td>												");
            //stringBuilder.Append("                         </tr>																  ");
            //stringBuilder.Append("                     </table>																   ");
            //stringBuilder.Append("                 </td>																		 ");
            //stringBuilder.Append("             </tr>																			  ");
            stringBuilder.Append("         </table>																			   ");
            stringBuilder.Append("         																							 ");
            stringBuilder.Append("     </div>																					 ");
            stringBuilder.Append(" </body>																					  ");
            stringBuilder.Append(" </html>																					   ");
            stringBuilder.Append(" 																									 ");

            Response.Write(stringBuilder.ToString());
        }
    }
}
