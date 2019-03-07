<%@ Page Language="C#" AutoEventWireup="true" CodeFile="body.aspx.cs" Inherits="WorkForms_catalog_body" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理界面</title>
     <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript">
        <asp:Literal ID="ltlJs" runat="server"></asp:Literal>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    <table cellspacing="1"  cellpadding="2" >
         <tr >
            <td colspan="2">
                <asp:Label ID="lblTitle" runat="server" Text="未选择"></asp:Label></td>
         </tr>
         <tr  >
            <td>
                工序名称：
            </td>
            <td> 
                <asp:TextBox ID="txtName" runat="server" Width="148px" MaxLength="30"></asp:TextBox>
                *<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="必填" ValidationGroup="add"></asp:RequiredFieldValidator>
           </td>
        </tr>
         <tr>
            <td>
                工序工时(单位：小时)</td>
            <td> 
                <asp:TextBox ID="txtNeedHours" runat="server" Width="148px" MaxLength="30">0</asp:TextBox>
                *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNeedHours"
                    ErrorMessage="必填" ValidationGroup="add"></asp:RequiredFieldValidator>
                </td>
        </tr>
      
         <tr>
            <td>
                描　　述：</td>
            <td> 
                <asp:TextBox ID="txtdescr" runat="server" Width="148px" MaxLength="30" Height="45px" TextMode="MultiLine"></asp:TextBox>
                </td>
        </tr>
      
         <tr >
            <td colspan="2"  align="center">
                <asp:Button ID="btAdd" runat="server" Text=" 添加 " ValidationGroup="add" CssClass="btnAction" OnClick="btAdd_Click" />&nbsp;
                <input id="btnCancel" type="reset" value=" 重置 " class="btnAction" />
            </td>
        </tr> 
    </table>
    </div>
    </form>
</body>
</html>
