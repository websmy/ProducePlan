<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register TagPrefix="cc1" Namespace="SMB.WebControls" Assembly="SMB.WebControls" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        销售订单排产</h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="cSOCode" HeaderText="订单号" />
                        <asp:BoundField DataField="cCusName" HeaderText="客户" />
                        <asp:BoundField DataField="dDate" HeaderText="订单日期" DataFormatString="{0:yyyy-M-d}" />
                        <asp:BoundField DataField="cInvCode" HeaderText="产品编码" />
                        <asp:BoundField DataField="cInvName" HeaderText="产品名称" />
                        <asp:BoundField HeaderText="规格型号" />
                        <asp:BoundField DataField="iQuantity" HeaderText="数量" />
                        <asp:BoundField DataField="dPreMoDate" HeaderText="预计完工期" DataFormatString="{0:yyyy-M-d}" />
                        <asp:TemplateField HeaderText="是否下达生产" ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Button ID="asp_btnBegin" runat="server" Text="是" CommandName="BeginProdu" CommandArgument='<%# Eval("AutoID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="是否插单" />
                        <asp:TemplateField HeaderText="评审完工期">
                            <ItemTemplate>
                                <%--<cc1:DateTextBox ID="DateTextBox1" Width="100" Text='<%# String.Format("{0:yyyy-MM-dd}",Eval("cdefine37")) %>>' runat="server"></cc1:DateTextBox>--%>
                                <cc1:DateTextBox ID="dateTxtBox" Width="100" Text='<%# Bind("cdefine37","{0:yyyy-MM-dd}") %>'
                                    runat="server"></cc1:DateTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:Button ID="asp_btnUpdate" runat="server" Text="更新" CommandName="Modify" CommandArgument='<%# Eval("AutoID")%>'
                                    CssClass="btnOneLine" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:Button ID="Button3" runat="server" Text="Button" Width="275px" Style="display: none" />
                <%--<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button3"
                    PopupControlID="Panel1" Drag="true" BackgroundCssClass="ModalPoupBackgroundCssClass">
                </cc1:ModalPopupExtender>
                &nbsp;
                <asp:Panel ID="Panel1" runat="server" CssClass="" Style="display: none;"
                    Height="96px" Width="347px">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <table  border="1">
                        <tr>
                            <td style="width: 100px">
                                Name:
                            </td>
                            <td style="width: 128px">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                Description:
                            </td>
                            <td style="width: 128px">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 128px">
                                <asp:Button ID="Button1" runat="server" Text="Save" />
                                <asp:Button ID="Button2" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>--%>
                
                 <asp:Button ID="btntargetControlOfmpeFirstDialogBox" runat="Server" Text="" Style="display: none;" />
            <cc1:ModalPopupExtender ID="mpeFirstDialogBox" runat="server" TargetControlID="btntargetControlOfmpeFirstDialogBox"
                PopupControlID="pnlFirstDialogBox" CancelControlID="btnCloseFirstDialogBox" BackgroundCssClass="ModalPoupBackgroundCssClass"
                BehaviorID="mpeFirstDialogBox">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlFirstDialogBox" runat="server" BorderStyle="Solid" BorderWidth="1" Style="width: 700px; background-color: White; 
                display: none; height: 400px;">
                <asp:Panel ID="pnlFirstDialogBoxHeader" runat="server" Width="100%" BackColor="#006699"
                    HorizontalAlign="Right">
                    <asp:Button ID="btnCloseFirstDialogBox" runat="server" Text="关闭" />
                </asp:Panel>
                <asp:Panel ID="pnlFirstDialogBoxDetail" runat="server" Width="99%" HorizontalAlign="left">
                    <h1>
                        This is the first DialogBox</h1>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                         <table  border="1">
                        <tr>
                            <td style="width: 100px">
                                Name:
                            </td>
                            <td style="width: 128px">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                Description:
                            </td>
                            <td style="width: 128px">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 128px">
                                <asp:Button ID="Button110" runat="server" Text="Save" />
                                <%--<asp:Button ID="Button2" runat="server" Text="Cancel" />--%>
                            </td>
                        </tr>
                    </table>

                    <br />
                    <%--this button opens the Second dialogbox--%>
                    <%--<asp:Button ID="btnOpenSecondDialogBox" runat="server" Text="Open Second DialogBox"
                        OnClick="btnOpenSecondDialogBox_Click" />--%>
                </asp:Panel>
            </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
</asp:Content>
