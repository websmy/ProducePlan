<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Mom.aspx.cs" Inherits="WorkForms_Sale" %>

<%@ Register TagPrefix="cc1" Namespace="SMB.WebControls" Assembly="SMB.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
  

    <h2 align="center">
        生产车间排程 
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click"/></h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="MDeptCode" HeaderText="部门" />
                        <asp:BoundField DataField="cinvdefine4" HeaderText="班组" />
                        <asp:BoundField DataField="SoCode" HeaderText="销售订单号" />
                        <asp:BoundField DataField="mocode" HeaderText="生产订单号" />
                        <asp:BoundField DataField="InvCode" HeaderText="产品编码" />
                        <asp:BoundField DataField="cinvname" HeaderText="产品名称" />
                        <asp:BoundField DataField="Qty" HeaderText="订单数量" />
                        <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" />
                        <asp:BoundField DataField="startdate" HeaderText="开工期" DataFormatString="{0:yyyy-M-d}" />
                        <asp:BoundField DataField="Duedate" HeaderText="预计完工期" DataFormatString="{0:yyyy-M-d}" />
                        <asp:TemplateField HeaderText="是否缺料" ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Button ID="btnLack" runat="server" Text="是" CommandName="Lack" CommandArgument='' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否领料" ItemStyle-Width="50">
                            <ItemTemplate>
                                
                                <a href="javascript:showModalDialog('MomPop.aspx?id=<%#Eval("modid")%>')">是</a>

                               <%-- <asp:Button ID="btnGetMaterial" runat="server" Text="是" CommandName="GetMaterial" OnClientClick="debugger "
                                    CommandArgument='<%# Eval("modid")%>' />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否入库" ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Button ID="btnEntry" runat="server" Text="是" CommandName="Entry" CommandArgument='' />
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
                <table align="right">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnFirst" runat="server" Text="首页" OnClick="lnkbtnFirst_Click"
                                CssClass="wrapBtn"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkbtnFront" runat="server" Text="上一页" OnClick="lnkbtnFront_Click"
                                CssClass="wrapBtn"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkbtnNext" runat="server" Text="下一页" OnClick="lnkbtnNext_Click"
                                CssClass="wrapBtn"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="linkbtnLast" runat="server" Text="尾页" OnClick="linkbtnLast_Click"
                                CssClass="wrapBtn"></asp:LinkButton>&nbsp;当前页码为：<asp:Label ID="labPage" runat="server">1</asp:Label>
                            &nbsp; 总页码为：<asp:Label ID="labBackPage" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btntargetControlOfmpeFirstDialogBox" runat="Server" Text="" Style="display: none;" />
                <cc1:ModalPopupExtender ID="mpeFirstDialogBox" runat="server" TargetControlID="btntargetControlOfmpeFirstDialogBox"
                    PopupControlID="pnlFirstDialogBox" CancelControlID="btnCloseFirstDialogBox" BackgroundCssClass="ModalPoupBackgroundCssClass"
                    BehaviorID="mpeFirstDialogBox" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlFirstDialogBox" runat="server" BorderStyle="Solid" BorderWidth="1"
                    Style="width: 700px; background-color: White; display: none; height: 500px;">
                    <asp:Panel ID="pnlFirstDialogBoxHeader" runat="server" Width="100%" BackColor="#006699"
                        HorizontalAlign="Right">
                        <asp:Button ID="btnCloseFirstDialogBox" runat="server" Text="关闭" />
                    </asp:Panel>
                    <asp:Panel ID="pnlFirstDialogBoxDetail" runat="server" Width="99%" HorizontalAlign="left">
                        <h1 align="center">
                            领料表</h1>
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div id="Daochu" style="width: 700px; height: 400px; overflow-x: auto; background-color: #b5e6ff;
                            overflow-y: auto; text-align: left; float: left; position: relative; margin: 0">
                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="whcode" HeaderText="仓库" />
                                    <asp:BoundField DataField="invcode" HeaderText="材料编码" />
                                    <asp:BoundField DataField="cinvname" HeaderText="材料名称" />
                                    <asp:BoundField DataField="qty" HeaderText="数量" />
                                    <asp:BoundField DataField="issqty" HeaderText="已领数量" />
                                    <asp:BoundField DataField="xiancun" HeaderText="现存量" />
                                    
                                    <asp:TemplateField HeaderText="本次领料数">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text = '<%# Eval("yaoling")%>'></asp:TextBox>
                                        </ItemTemplate>
<%--
                                          <EditItemTemplate>
                                        <asp:TextBox ID="TBPrice" Text='<%# Eval("price") %>' runat="server" Width="90px" />
                                    </EditItemTemplate>--%>

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
                        </div>
                        <div align="right">
                        <asp:Button ID="Button1" runat="server" Text="领料" OnClick="Button1_Click"/>
                        </div>
                        <br />
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
