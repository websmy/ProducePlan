<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MomPop_Add.aspx.cs" Inherits="WorkForms_MomPop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>添加材料</title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="Qty" runat="server" />
        <asp:HiddenField ID="modid" runat="server" />
    <div align="center">
        <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border">
            <tr>
                <td align="center">
                    过滤数据:
                </td>
                <td align="center">
                    物料编码
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    (模糊查询)
                </td>
                <td align="center">
                    物料名称
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>(模糊查询)
                </td>
                <td><asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" /></td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"
            OnDataBound="GridView2_DataBound">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:HiddenField runat="server" ID="WhCode" Value='<%# Eval("cWhCode")%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="cWhName" HeaderText="供应仓库" />
                <asp:BoundField DataField="cinvcode" HeaderText="材料编码" />
                <asp:BoundField DataField="cinvname" HeaderText="材料名称" />
                <asp:TemplateField HeaderText="基本数量">
                    <ItemTemplate>
                        <asp:TextBox ID="xuqiuliang" runat="server" DataFormatString="{0:0.00}" Width="50" CausesValidation="True"/>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="只能输入数字"
                            ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="G1" ControlToValidate="xuqiuliang"></asp:CompareValidator>
                            
                        <asp:TextBox ID="TextBox2" runat="server" Text="0" Width="0" BorderWidth="0" BackColor=White Height="0" />
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="不能输入零"
                            ForeColor="Red" Operator="NotEqual" Type="Double" ValidationGroup="G1" ControlToValidate="xuqiuliang" ControlToCompare="TextBox2"></asp:CompareValidator>

                    </ItemTemplate>
                </asp:TemplateField>
                
                <%-- <asp:TemplateField HeaderText="应领数量">
                    <ItemTemplate>
                        <asp:TextBox ID="QtyCheng"  ReadOnly="True" runat="server" DataFormatString="{0:0.00}" Width="50" CausesValidation="True"/>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="只能输入数字"
                            ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="G1" ControlToValidate="QtyCheng"></asp:CompareValidator>
                            
                        <asp:TextBox ID="TextBox3" runat="server" Text="0" Width="0" BorderWidth="0" BackColor=White Height="0" />
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="不能输入零"
                            ForeColor="Red" Operator="NotEqual" Type="Double" ValidationGroup="G1" ControlToValidate="QtyCheng" ControlToCompare="TextBox3"></asp:CompareValidator>

                    </ItemTemplate>
                </asp:TemplateField>--%>

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
    </div>

    <div align="center" style="background-color: #006699">
    <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" Height="28px"
            Width="113px" ValidationGroup="G1" />
            </div>
    </form>
</body>
</html>
