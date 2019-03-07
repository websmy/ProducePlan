﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workhours_manage.aspx.cs"
    Inherits="WorkForms_workhours_manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div>
        <h3 align="center" style="color: #FFFFFF; background-color: #006699;">
            管理工时数据</h3>
    </div>
    <div>
        <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" width="100%"
            bgcolor="White">
            <tr>
                <td align="center">
                    过滤数据:
                </td>
                <td align="center">
                    产品编码：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False" ShowFooter="True"
            OnPreRender="GridView3_PreRender" OnRowCancelingEdit="GridView3_RowCancelingEdit"
            OnRowCommand="GridView3_RowCommand" OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
            OnRowUpdating="GridView3_RowUpdating" OnRowDataBound="GridView3_RowDataBound"
            AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView3_PageIndexChanging">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
              
                        <asp:Label ID="autoid" runat="server" Text='<%#Bind("autoid")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="产品编码">
                    <ItemTemplate>
                        <asp:Label ID="label产品编码" runat="server" Text='<%# Eval("产品编码").GetType()==typeof(DBNull)?"":Eval("产品编码").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt产品编码" runat="server" Text='<%#Eval("产品编码")%>' Width="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt产品编码" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt产品编码F" runat="server" Text='<%#Eval("产品编码")%>' Width="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt产品编码F" InitialValue="" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="工序">
                    <ItemTemplate>
                        <asp:Label ID="label工序" runat="server" Text='<%# Eval("工序").GetType()==typeof(DBNull)?"":Eval("工序").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt工序" runat="server" Text='<%#Eval("工序")%>' Width="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工序" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt工序F" runat="server" Text='<%#Eval("工序")%>' Width="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工序F" InitialValue="" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="工时">
                    <ItemTemplate>
                        <asp:Label ID="label工时" runat="server" Text='<%# Eval("工时").GetType()==typeof(DBNull)?"":Eval("工时").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt工时" runat="server" Text='<%#Eval("工时")%>' Width="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工时" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt工时F" runat="server" Text='<%#Eval("工时")%>' Width="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工时F" InitialValue="" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                
                   <asp:TemplateField HeaderText="车间名称">
                    <ItemTemplate>
                        <asp:Label ID="label车间名称" runat="server" Text='<%# Eval("车间名称").GetType()==typeof(DBNull)?"":Eval("车间名称").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        
                     <asp:Label ID="label车间名称" runat="server" Text='<%# Eval("车间名称").GetType()==typeof(DBNull)?"":Eval("车间名称").ToString()%> '></asp:Label>

                          <%--<asp:DropDownList ID="ddl车间名称" runat="server" >
                        </asp:DropDownList>
                     --%>
                </EditItemTemplate>
                  
                    <FooterTemplate>
                        <asp:DropDownList ID="ddl车间名称F" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="ddl车间名称F" InitialValue="-1" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>

                </asp:TemplateField>

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="编辑"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="更新" ValidationGroup="G3"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="Server" Text="添加" CommandName="Add" UseSubmitBehavior="False"
                            ValidationGroup="G4" />
                    </FooterTemplate>
                </asp:TemplateField>
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
                &nbsp&nbsp 当前页码为：
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
