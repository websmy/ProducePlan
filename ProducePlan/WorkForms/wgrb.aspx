<%@ Page Title="完工日报" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="wgrb.aspx.cs" Inherits="WorkForms_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 align="center">
        &nbsp;<asp:Label ID="Label1" runat="server" Text="完工日报"></asp:Label>
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" 
                align="center" width="100%">
                <tr>
                    <td align="center">
                        过滤数据:
                    </td>
                    <td align="center">
                        部门<asp:DropDownList ID="DDLdept" runat="server">
                        </asp:DropDownList>
                        &nbsp;班组<asp:DropDownList ID="DropDownList3" runat="server" CausesValidation="True" 
                            ValidationGroup="G1">
                            <asp:ListItem Value="全部">全部</asp:ListItem>
                           <asp:ListItem Value="一车间成型班">一车间成型班</asp:ListItem>
                            <asp:ListItem Value="一车间附件班">一车间附件班</asp:ListItem>
                            <asp:ListItem Value="一车间焊接班">一车间焊接班</asp:ListItem>
                            <asp:ListItem>一车间喷漆班</asp:ListItem>
                            <asp:ListItem>一车间下料班</asp:ListItem>
                            <asp:ListItem Value="一车间小叶轮班">一车间小叶轮班</asp:ListItem>
                            <asp:ListItem Value="一车间装配班">一车间装配班</asp:ListItem>
                            <asp:ListItem Value="二车间大叶轮班">二车间大叶轮班</asp:ListItem>
                            <asp:ListItem>二车间机加工班</asp:ListItem>
                            <asp:ListItem>二车间喷漆班</asp:ListItem>
                            <asp:ListItem>二车间网罩班</asp:ListItem>
                            <asp:ListItem>机车成型班</asp:ListItem>
                            <asp:ListItem>机车机壳班</asp:ListItem>
                            <asp:ListItem>机车铝焊班</asp:ListItem>
                            <asp:ListItem>机车喷漆班</asp:ListItem>
                            <asp:ListItem>机车下料班</asp:ListItem>
                            <asp:ListItem>机车叶轮班</asp:ListItem>
                            <asp:ListItem>机车装配班</asp:ListItem>
                            <asp:ListItem>能源冶金GE班</asp:ListItem>
                            <asp:ListItem>能源冶金机加工班</asp:ListItem>
                            <asp:ListItem>能源冶金维修班</asp:ListItem>
                        </asp:DropDownList>
                        入库类别<asp:DropDownList ID="DropDownList2" runat="server" CausesValidation="True" 
                            ValidationGroup="G1">
                        </asp:DropDownList>
                        日期 从<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtStartDate" ForeColor="Red"></asp:CompareValidator>
                        &nbsp;到<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtEndDate" ForeColor="Red"></asp:CompareValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server"  format="yyyy-MM-dd" TargetControlID="txtEndDate">
                        </ajaxToolkit:CalendarExtender>
                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" ValidationGroup="G1" />
                       
                        <asp:Button ID="Button111" runat="server" onclick="Button111_Click" 
                            Text="导到Excel" ValidationGroup="G1" />
                       
                    </td>
                    
                    <td align="right"> 数量合计：<asp:Label ID="LabelRuKuHeJi" runat="server"></asp:Label></td>
                    <td align="right"> 产值合计：<asp:Label ID="LabelChanZhi" runat="server"></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"
                    OnDataBound="GridView1_DataBound" PageSize="30">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("modid")%>' ID="modid" />--%>
                                <%-- <asp:HiddenField runat="server" Value='<%# Eval("MDeptCode")%>' ID="MDeptCode" />
                                
                                <asp:HiddenField runat="server" Value='<%# Eval("MoId")%>' ID="MoId" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SortSeq")%>' ID="SortSeq" />--%>
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("是否缺料")%>' ID="是否缺料" />--%>
                                <%--   <asp:HiddenField runat="server" Value='<%# Eval("cInvCode")%>' ID="cInvCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cinvdefine4")%>' ID="cinvdefine4" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SoDId")%>' ID="SoDId" />--%>
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
         
                        <asp:BoundField DataField="iordercode" HeaderText="销售订单号" />
                        <asp:BoundField DataField="cmocode" HeaderText="生产订单号" />
                        <asp:BoundField DataField="ccode" HeaderText="单据号" />
                        <asp:BoundField DataField="ddate" HeaderText="日期" DataFormatString="{0:yyyy-M-d}" />
                        <asp:BoundField DataField="cDepName" HeaderText="部门" />
                        <asp:BoundField DataField="cInvCode" HeaderText="产品编码" />
                        <asp:BoundField DataField="cinvname" HeaderText="产品名称" />
                        <asp:BoundField DataField="cInvDefine14" HeaderText="工时" />                      
                        
                        <asp:BoundField DataField="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}">
                            <%-- <ItemStyle Width="20px" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="iquantity" HeaderText="入库数量" DataFormatString="{0:0.00}">
                            <%--<ItemStyle Width="20px" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="iunitcost" HeaderText="单价" />
                        <asp:BoundField DataField="totalprice" HeaderText="金额" />
                        

                        <%--<asp:BoundField DataField="startdate" HeaderText="开工期" DataFormatString="{0:yyyy-M-d}" />--%>
                        <%--<asp:BoundField DataField="Duedate" HeaderText="预计完工期" DataFormatString="{0:yyyy-M-d}" />--%>
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
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
