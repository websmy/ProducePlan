using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using Microsoft.Reporting.WebForms;

public partial class WorkForms_GongShiReport : System.Web.UI.Page
{
    private string txtStartDate = "";
    private string txtEndDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            //getParam();

            txtStartDate = Request.QueryString["p1"];
            txtEndDate = Request.QueryString["p2"];           
            FillDataToReport();
        }
    }

    public void FillDataToReport()
    {
        
        DataTable dttemp= new DataTable();
         
        string sql1 = "select * from workhours_manage_worker";     
        DataTable dt2 = SQLHelper1.Query(sql1).Tables[0];
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            string 工人编码 = dt2.Rows[i]["工人编码"].ToString();

            string sql = "";
            sql += "select  c.工人编码,c.工人姓名, sum(a.工时*b.数量) as 总工时 from 工时录入 b  left join   [workhours_manage] a  on a.产品编码=b.产品编码  and b.工序autoid=a.autoid  left join workhours_manage_worker c on c.工人编码=b.工人编码   left join 车间名称  e on  e.flag=a.flag where 1=1 ";

            if (!String.IsNullOrEmpty(txtStartDate))
            {
                sql += " and CONVERT(varchar(10), b.ddate, 120) >= '" + txtStartDate + " '";
            }

            if (!String.IsNullOrEmpty(txtEndDate))
            {
                sql += " and CONVERT(varchar(10), b.ddate, 120) <=  '" + txtEndDate+ " '";
            }
            sql += " and b.工人编码='" + 工人编码 + "'  GROUP BY c.工人编码,c.工人姓名";
        
             DataTable dt = SQLHelper1.Query(sql).Tables[0];

            if (i==0)
            {
                dttemp = dt.Copy();
            }
            else
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    DataRow dtRow = dt.Rows[j];
                    dttemp.Rows.Add(dtRow.ItemArray);
                }
            }

        }



 


        //sql =
        //    "  select                                                         " +
        //    "      [投标公司]                                                 " +
        //    "      ,convert(varchar, 时间, 111)  as  时间                                                  " +
        //    "      ,[投标人]                                                  " +
        //    "      ,[联系电话]                                                " +
        //    "      ,[价格]                                                    " +
        //    "      ,[备注]                                                    " +
        //    "      ,[序号]                                                    " +
        //    "      ,[UserName]   as 用户名                                                " +
        //    "      ,[废旧物资名称]                                            " +
        //    "                                                                 " +
        //    "      from TBody                                                 " +
        //    "      left join THeader on TBody.autoidHeader=THeader.autoid     " +
        //    "      left join CName on TBody.autoidCname=CName.autoid          " +
        //    "      left join Param on TBody.autoidParam=Param.autoid          " +
        //    "      where  Param.autoid=" + autoidF.Value;
       

        //dt.Copy()

        //sql = " select  [年度],[季度] from [Param] where autoid=" + autoidF.Value;
        //DataTable dt1 = SQLHelper1.Query(sql).Tables[0];

        //this.ReportViewer1.LocalReport.ReportPath = "Report.rdlc";  //查找要绑定的报表   
        this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dttemp));  //绑定数据源   

        //if (!"".Equals(txtStartDate))
        //{
        //    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter("ReportParameter1", txtStartDate));
        //}

        //if (!"".Equals(txtEndDate))
        //{
        //    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter("ReportParameter2", txtEndDate));
        //}
       

    }  
}