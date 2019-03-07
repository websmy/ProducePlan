<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workhours_enter.aspx.cs"
    Inherits="WorkForms_workhours_enter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>工时录入</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div>
        <h1 align="center" style="color: #FFFFFF; background-color: #006699;">
            工时录入窗口(编码名称：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>)</h1>
        <asp:HiddenField ID="totalQuantity" runat="server" />
        <asp:HiddenField ID="MoDId" runat="server" />
        <asp:HiddenField ID="cInvName" runat="server" />
        <asp:HiddenField ID="InvCode" runat="server" />
        <div>
        </div>
    </div>
    <>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False" ShowFooter="True"
            OnPreRender="GridView1_PreRender" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCreated="GridView1_RowCreated"
            Font-Size="XX-Large">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("autoid")%>'></asp:Label>
                        <asp:HiddenField ID="hidShenFlag" runat="server" Value='<%#Eval("shenFlag")%>'></asp:HiddenField>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                    </ItemTemplate>
                   </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="姓名">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" Text='<%# Bind("name") %>' Font-Size="XX-Large">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="XX-Large">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* 必选"
                            ControlToValidate="DropDownList1" InitialValue="-1" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="工序">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList19" runat="server" Text='<%# Bind("classId") %>'
                            Font-Size="XX-Large">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownList19" runat="server" Font-Size="XX-Large">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="* 必选"
                            ControlToValidate="DropDownList19" InitialValue="-1" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblclassName" runat="server" Text='<%#Eval("className")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="数量">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtiquantity" runat="server" Width="50" Text='<%#Eval("iquantity")%>' Font-Size="XX-Large"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txtiquantity" InitialValue="" ForeColor="Red" ValidationGroup="G2"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="数字"
                            ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="G2" ControlToValidate="txtiquantity"></asp:CompareValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtiquantity" runat="server" Width="50" Text='<%#Eval("iquantity")%>'
                            Font-Size="XX-Large"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txtiquantity" InitialValue="" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="数字"
                            ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="G1" ControlToValidate="txtiquantity"></asp:CompareValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbliquantity" runat="server" Text='<%#Eval("iquantity")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单件工时">
                    <EditItemTemplate>
                        <asp:Label ID="lblworkhours" runat="server" Text='<%#Eval("workhours")%>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblworkhours" runat="server" Text='<%#Eval("workhours")%>'></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblworkhours" runat="server" Text='<%#Eval("workhours")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总工时">
                    <EditItemTemplate>
                        <asp:Label ID="lbltworkhours" runat="server" Text='<%#Eval("tworkhours")%>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbltworkhours" runat="server" Text='<%#Eval("tworkhours")%>'></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbltworkhours" runat="server" Text='<%#Eval("tworkhours")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="日期">
                    <ItemTemplate>
                        <asp:Label ID="date" runat="server" Text='<%#Eval("date")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        
                        <asp:TextBox ID="txtDate" runat="server" Text='<%#Eval("date")%>' Font-Size="XX-Large" Width="200" ></asp:TextBox>
                       <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="G1" ControlToValidate="txtDate"
                            ForeColor="Red"></asp:CompareValidator>
                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                        
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtDateF" runat="server" Font-Size="XX-Large" Width="200"></asp:TextBox>

                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="G1" ControlToValidate="txtDateF"
                            ForeColor="Red"></asp:CompareValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDateF"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                    </FooterTemplate>
                    
                   
                    <HeaderStyle Width="200px" />
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
                            Text="更新" ValidationGroup="G2"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="Server" Text="添加" CommandName="Add" UseSubmitBehavior="False"
                            ValidationGroup="G1" Font-Size="XX-Large" />
                    </FooterTemplate>
                     <HeaderStyle Width="200px" />
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
   
    </form>
</body>
</html>
