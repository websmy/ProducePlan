using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class WorkForms_ChuKuDan : System.Web.UI.Page
{
    private string ccodes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ccodes = Request.QueryString["id"];
            if (String.IsNullOrEmpty(ccodes))
            {
                Response.Write("<script>window.close();</script>");
                Response.Redirect("./Mom.aspx");
                Response.End();
            }
            SetDataSource();
        }
    }

    //private string filterstring = ccodes;
    private void SetDataSource()
    {
        string sql =
            "select *  from RdRecord  " +
            "left join warehouse on  warehouse.cwhcode=RdRecord.cwhcode " +
            "left join Department on Department.cDepCode=RdRecord.cDepCode " +
            "left join Rd_Style on Rd_Style.crdcode=rdrecord.crdcode " +
            "where RdRecord.ccode in (" + ccodes + ")";
        DataTable RdRecord = Helper.SQLHelper.Query(sql).Tables[0];
        ReportDataSource rptDataScoure = new ReportDataSource("RdRecord", RdRecord);

        reportViewer1.LocalReport.DataSources.Clear();
        reportViewer1.LocalReport.DataSources.Add(rptDataScoure);
        reportViewer1.LocalReport.Refresh();
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        string sql =
            "select * from RdRecords sub " +
            "left join RdRecord main on main.ID = sub.ID " +
            "left join inventory inv on inv.cinvcode=sub.cinvcode " +
            "left join ComputationUnit cunit  on cunit.cComunitCode=inv.cComUnitCode " +
            "where main.ccode in (" + ccodes + ")";
        DataTable RdRecords = Helper.SQLHelper.Query(sql).Tables[0];
        ReportDataSource rptDataScoure1 = new ReportDataSource("RdRecords", RdRecords);

        e.DataSources.Add(rptDataScoure1);

    }
}