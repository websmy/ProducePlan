<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cnfx_manage.aspx.cs" Inherits="WorkForms_cnfx_manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
            管理数据</h3>
    </div>
    <div>
        <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" width="100%"
            bgcolor="White">
            <tr>
                <td align="center">
                    过滤数据:
                </td>
                <td align="center">
                    部门<asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    &nbsp;班组<asp:DropDownList ID="DropDownList4" runat="server">
                    </asp:DropDownList>
                    <%-- 部门：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                          班组：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
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
                        <asp:HiddenField runat="server" Value='<%# Eval("部门")%>' ID="部门h" />
                        <asp:HiddenField runat="server" Value='<%# Eval("班组")%>' ID="班组h" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部门">
                    <ItemTemplate>
                        <asp:Label ID="label部门" runat="server" Text='<%# Eval("部门").GetType()==typeof(DBNull)?"":Eval("部门").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DDL部门" runat="server" >
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DDL部门F" runat="server" >
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="班组">
                    <ItemTemplate>
                        <asp:Label ID="label班组" runat="server" Text='<%# Eval("班组").GetType()==typeof(DBNull)?"":Eval("班组").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DDL班组" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DDL班组F" runat="server" >
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="人数">
                    <ItemTemplate>
                        <asp:Label ID="label人数" runat="server" Text='<%# Eval("人数").GetType()==typeof(DBNull)?"":Eval("人数").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt人数" runat="server" Text='<%#Eval("人数")%>' ></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt人数F" runat="server" Text='<%#Eval("人数")%>' ></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="工时">
                    <ItemTemplate>
                        <asp:Label ID="label工时" runat="server" Text='<%# Eval("工时").GetType()==typeof(DBNull)?"":Eval("工时").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt工时" runat="server" Text='<%#Eval("工时")%>' ></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt工时F" runat="server" Text='<%#Eval("工时")%>'></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="日期">
                    <ItemTemplate>
                        <asp:Label ID="label日期" runat="server" Text='<%# Eval("日期").GetType()==typeof(DBNull)?"":Eval("日期").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt日期" runat="server" Text='<%#Eval("日期","{0:yyyy-MM-dd}")%>'></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="G3" ControlToValidate="txt日期"
                            ForeColor="Red"></asp:CompareValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txt日期" Format="yyyy-MM-dd"
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt日期F" runat="server"  Text='<%#DateTime.Now.ToString("yyyy-MM-dd")%>' ></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="G4" ControlToValidate="txt日期F"
                            ForeColor="Red"></asp:CompareValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txt日期F" Format="yyyy-MM-dd"
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
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
