<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="Mom1Print.aspx.cs" Inherits="Mom1Print" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>打印列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div>
        <h2 align="center">
            <asp:Label ID="Label1" runat="server"   Text="Label"></asp:Label>装配计划</h2>
        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False" ShowFooter="false"
                                  
            AllowPaging="True" 
            onpageindexchanging="GridView3_PageIndexChanging" PageSize="300">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>

                  <asp:BoundField DataField="cCusName" HeaderText="客户名称" >

                        </asp:BoundField>
<%--                        <asp:TemplateField HeaderText="班组">
                            <ItemTemplate>
                                
                                  <asp:DropDownList ID="DropDownList5" runat="server">
                                                </asp:DropDownList>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("cinvdefine4") %>'></asp:Label>

                               
                            </ItemTemplate>
                         
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="ordercode" HeaderText="销售订单号" >
                       
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="orderseq" HeaderText="销售订单行号" >
                   
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="mocode" HeaderText="生产订单号" >
                     
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="sortseq" HeaderText="生产订单行号" >

                        </asp:BoundField>--%>
                        <asp:BoundField DataField="InvCode" HeaderText="产品编码" >
                    
                        </asp:BoundField>
                        <asp:BoundField DataField="cinvname" HeaderText="产品名称" >
                    
                        </asp:BoundField>
                        <asp:BoundField DataField="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}">
                            <%-- <ItemStyle Width="20px" />--%>
                        
                        </asp:BoundField>

                <asp:BoundField DataField="chuli" HeaderText="表面处理" >
                    
                        </asp:BoundField>
                <asp:BoundField DataField="baozhuang" HeaderText="包装要求" >
                    
                        </asp:BoundField>

                        <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" DataFormatString="{0:0.00}" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1" ControlStyle-CssClass="hidden1">
                            <%--<ItemStyle Width="20px" />--%>
                     
                        <ControlStyle CssClass="hidden1" />
                        <FooterStyle CssClass="hidden1" />
                        <HeaderStyle CssClass="hidden1" />
                        <ItemStyle CssClass="hidden1" />
                     
                        </asp:BoundField>

            </Columns>
            <EmptyDataTemplate>
                没有数据
            </EmptyDataTemplate>

            <PagerTemplate>
               
                <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                    Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">首页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                    CommandName="Page" Visible="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                    Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">下一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                    Visible="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">尾页</asp:LinkButton>
                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />
                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                    CommandName="Page" Text="GO" />
                    &nbsp&nbsp
                     当前页码为：
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                &nbsp 总页码为：
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                
            </PagerTemplate>

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
