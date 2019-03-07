<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_ChuKuDan, App_Web_ygebp2ua" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出库单打印</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="reportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt" Width="651px" Height="314px"   
            AsyncRendering="False" SizeToReportContent="True">
            <LocalReport ReportPath="WorkForms\ChuKuDan.rdlc" 
                OnSubreportProcessing="ReportViewer1_SubreportProcessing">
            </LocalReport>
        </rsweb:ReportViewer>
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
