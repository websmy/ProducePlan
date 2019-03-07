<%@ page title="调拨单生成" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_DiaoBoDan, App_Web_ygebp2ua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 61px;
        }
        .style3
        {
            height: 61px;
        }
        .style4
        {
            height: 61px;
            width: 483px;
        }
        .style5
        {
            height: 61px;
            width: 149px;
        }
        #File1
        {
            width: 431px;
        }
        .style6
        {
            height: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1" border="1">
        <tr>
            <td class="style6" align="center" bgcolor="Silver" colspan="4" 
                style="font-size: xx-large">
                调拨单生成工具</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="请打开EXCEL文件"></asp:Label>
                </td>
            <td class="style4">
                <asp:FileUpload ID="FileUpload_Excel" runat="server" Width="456px" />
            </td>
            <td class="style5">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="开始导入数据" />
            </td>
            <td class="style3">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/file/调拨单模板.xls" 
                    Target="_blank">调拨单模板下载</asp:HyperLink>
            </td>
        </tr>
        </table>
</asp:Content>

