

<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_工时录入, App_Web_2h3v2kfy" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>工时录入</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 223px;
        }
        .style3
        {
            width: 586px;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div>      
        <table cellpadding="0" cellspacing="0" class="style1" bgcolor="White" style="font-size: xx-large">
            <tr>
                <td class="style2">
                    工人编码：</td>
                <td class="style3">
                    <asp:TextBox 
                        ID="TextBox1" runat="server" Width="78px" AutoPostBack="True" 
                        ontextchanged="TextBox1_TextChanged" Font-Size="XX-Large"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ErrorMessage="*" ControlToValidate="TextBox1" ForeColor="Red" 
                        ValidationGroup="S1"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                            
                      </td>
                <td>
                    <asp:HyperLink ID="HyperLink3" runat="server" 
                        NavigateUrl="~/WorkForms/GongShiChaXun.aspx" Target="_blank" 
                        Font-Size="XX-Large">工时查询</asp:HyperLink></td>
            </tr>
            <tr>
                <td class="style2">
                                            
                      生产订单号：</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox4" runat="server" 
                        ontextchanged="TextBox4_TextChanged" AutoPostBack="True" 
                        Font-Size="XX-Large" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ErrorMessage="*" ControlToValidate="TextBox4" ForeColor="Red" 
                        ValidationGroup="S1"></asp:RequiredFieldValidator>
                        
                          </td>
                <td>
                 
                    <asp:HyperLink 
                        ID="HyperLink1" runat="server" NavigateUrl="~/WorkForms/workhours_manage.aspx" 
                        Target="_blank" >工序管理</asp:HyperLink>
                            </td>
            </tr>
            <tr>
                <td class="style2">
                        
                          行号：</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox3" runat="server"  
                        ontextchanged="TextBox3_TextChanged" AutoPostBack="True" 
                        Font-Size="XX-Large" Width="33px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ErrorMessage="*" ControlToValidate="TextBox3" ForeColor="Red" 
                        ValidationGroup="S1"></asp:RequiredFieldValidator>    

                   
                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                                 
                    </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl="~/WorkForms/workhours_manage_worker.aspx" Target="_blank">工人管理</asp:HyperLink>
                            </td>
            </tr>
            <tr>
                <td class="style2">
                                 
                    <asp:HiddenField ID="hQty" runat="server" />
                    <asp:HiddenField ID="hCinvCode" runat="server" />
                    <asp:HiddenField ID="hModid" runat="server" />
                   </td>
                <td class="style3">
                   <asp:Button ID="btnFilter" runat="server" Text="开始录入" OnClick="btnFilter_Click" 
                        ValidationGroup="S1" Font-Size="XX-Large" />
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="数据清空" 
                        Font-Size="XX-Large" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>

    </div>
    <div>
        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False"
            OnPreRender="GridView3_PreRender" OnRowCancelingEdit="GridView3_RowCancelingEdit"
            OnRowCommand="GridView3_RowCommand" OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
            OnRowUpdating="GridView3_RowUpdating" OnRowDataBound="GridView3_RowDataBound"
            AllowPaging="True" AllowSorting="True" 
            OnPageIndexChanging="GridView3_PageIndexChanging" Font-Size="XX-Large">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="工序autoid" runat="server" Text='<%#Bind("工序autoid")%>'></asp:Label>
                        <asp:HiddenField ID="h数量" runat="server" Value='<%#Bind("数量")%>'></asp:HiddenField>
                        <asp:Label ID="autoid" runat="server" Text='<%#Bind("autoid")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField HeaderText="工序">
                    <ItemTemplate>
                        <asp:Label ID="label工序" runat="server" Text='<%# Eval("工序").GetType()==typeof(DBNull)?"":Eval("工序").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        
                         <asp:DropDownList ID="ddl工序" runat="server" Font-Size="XX-Large">
                        </asp:DropDownList>

                        <%--<asp:TextBox ID="txt工序" runat="server" Text='<%#Eval("工序")%>' Width="100"></asp:TextBox>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="ddl工序" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                          <asp:DropDownList ID="ddl工序F" runat="server" Font-Size="XX-Large">
                        </asp:DropDownList>

                        <%--<asp:TextBox ID="txt工序F" runat="server" Text='<%#Eval("工序")%>' Width="100"></asp:TextBox>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="ddl工序F" InitialValue="请选择" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <asp:Label ID="label数量" runat="server" Text='<%# Eval("数量").GetType()==typeof(DBNull)?"":Eval("数量").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt数量" runat="server" Text='<%#Eval("数量")%>' Width="200" Font-Size="XX-Large" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt数量" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate >
                        <asp:TextBox ID="txt数量F" runat="server" Text='<%#Eval("数量")%>' Width="200" Font-Size="XX-Large" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt数量F" InitialValue="" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="工时">
                    <ItemTemplate>
                        <asp:Label ID="label工时" runat="server" Text='<%# Eval("工时").GetType()==typeof(DBNull)?"":Eval("工时").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="txt工时" runat="server" Text='<%#Eval("工时")%>' Width="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工时" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt工时F" runat="server" Text='<%#Eval("工时")%>' Width="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工时F" InitialValue="" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="总工时">
                    <ItemTemplate>
                        <asp:Label ID="label总工时" runat="server" Text='<%# Eval("总工时").GetType()==typeof(DBNull)?"":Eval("总工时").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="txt工时" runat="server" Text='<%#Eval("工时")%>' Width="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工时" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt工时F" runat="server" Text='<%#Eval("工时")%>' Width="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt工时F" InitialValue="" ForeColor="Red" ValidationGroup="G4"></asp:RequiredFieldValidator>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="录入日期">
                    <ItemTemplate>
                        <asp:Label ID="label录入日期" runat="server" Text='<%# Eval("录入日期").GetType()==typeof(DBNull)?"":Eval("录入日期").ToString()%> '  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ShowHeader="False">
                    <%--<ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="编辑" Visible="True" Enabled="True"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" Visible="True"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="更新" ValidationGroup="G3"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="取消"></asp:LinkButton>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="Server" Text="保存" CommandName="Add" UseSubmitBehavior="False"
                            ValidationGroup="G4" Font-Size="XX-Large" />
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
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" Font-Size="XX-Large" />
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
