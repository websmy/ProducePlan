<%@ Page Title="到货日期预警" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DateCheck.aspx.cs" Inherits="WorkForms_DateCheck" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 align="center">
        &nbsp;<asp:Label ID="Label1" runat="server" Text="到货日期预警"></asp:Label>
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
                        采购订单号:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        订单日期 从<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
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
                       
                    </td>
                      <td>
                        <asp:Button ID="Button111" runat="server" onclick="Button111_Click" 
                            Text="导到Excel"  ValidationGroup="G1"/>
                    </td>
                  
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"
                    OnDataBound="GridView1_DataBound" PageSize="30" AllowSorting="True" 
                    onsorting="GridView1_Sorting">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("cCloser")%>' ID="cCloser" />--%>
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("分类编码")%>' ID="分类编码" />--%>
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>                       
                        <%--<asp:BoundField DataField="大分类编码" HeaderText="大分类编码" SortExpression="大分类编码"/>--%>
                        <asp:BoundField DataField="采购订单号" HeaderText="采购订单号" />
                        <asp:BoundField DataField="订单日期" HeaderText="订单日期" DataFormatString="{0:yyyy-M-d}"  SortExpression="订单日期"/>
                        <asp:BoundField DataField="销售订单号" HeaderText="销售订单号" />                      
                        <asp:BoundField DataField="存货编码" HeaderText="存货编码" SortExpression="存货编码"/>
                        <asp:BoundField DataField="存货名称" HeaderText="存货名称" />                                            
                        <asp:BoundField DataField="订单数量" HeaderText="订单数量" />                      
                        <asp:BoundField DataField="累计到货数量" HeaderText="累计到货数量" />                      
                        <asp:BoundField DataField="计划到货日期" HeaderText="计划到货日期" DataFormatString="{0:yyyy-M-d}" />                   
                        
                        <asp:TemplateField HeaderText="距离到货日期天数"  SortExpression="天数">
                            <ItemTemplate>
                                距离到货日期还有 <asp:Label ID="tianshu" runat="server" Text='<%# Eval("天数")%>' Font-Size="Large" ForeColor="Red"> </asp:Label> 天
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
              
                               
                                  <%--<div align="right">
                      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                                CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条" 
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                                ShowCustomInfoSection="Left" onpagechanged="AspNetPager1_PageChanged" PageSize="30">
                      </webdiyer:AspNetPager>
                            </div>--%>
                           
             
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
