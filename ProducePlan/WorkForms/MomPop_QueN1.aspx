<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MomPop_QueN1.aspx.cs" Inherits="WorkForms_MomPop_QueN1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>缺料表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3 align="center" style="color: #FFFFFF; background-color: #006699;">
            缺料表</h3>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenField6" runat="server" />
        <asp:HiddenField ID="HiddenField4" runat="server" />
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False" 
            >
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:BoundField DataField="cWhName" HeaderText="仓库" />
                <asp:BoundField DataField="invcode" HeaderText="材料编码" />
                <asp:BoundField DataField="cinvname" HeaderText="材料名称" />
                <asp:BoundField DataField="qty" HeaderText="数量" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="issqty" HeaderText="已领数量" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="xiancun" HeaderText="现存量" DataFormatString="{0:0.00}" />
            </Columns>
            <EmptyDataTemplate>
                没有数据
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <div align="center" style="background-color: #006699">
            <asp:Button ID="Button1" runat="server" Text="关闭" />
           </div>
    </div>
    </form>
</body>
</html>
