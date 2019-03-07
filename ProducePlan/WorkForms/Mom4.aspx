<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mom4.aspx.cs" Inherits="WorkForms_Mom4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript">
　　        function openwin1(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6, p7, MoId, SortSeq, MoDId, p8, p9) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=" + p7 + "&MoId=" + MoId + "&SortSeq=" + SortSeq + "&MoDId=" + MoDId + "&p8=" + p8 + "&p9=" + p9 + "?" + Math.random();                              //转向网页的地址;
            //              var name;                           //网页名称，可为空;
            //              var iWidth = 650;                          //弹出窗口的宽度;
            //              var iHeight = 400;                        //弹出窗口的高度;
            var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
            var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
            //              window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
            var b = window.open(url, winname, "height=" + iHeight + ", width=" + iWidth + ", top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes");  //写成一行
            //            b.location.reload();
            b.focus();
            //　　              window.location = url;
        } 
    </script>
    <script language="JavaScript">
　　        function openwin2(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6, p7, MoId, SortSeq, MoDId, p8, p9) {
            if (window.confirm("有物料没领完是否入库？")) {

                var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=" + p7 + "&MoId=" + MoId + "&SortSeq=" + SortSeq + "&MoDId=" + MoDId + "&p8=" + p8 + "&p9=" + p9 + "?" + Math.random();                              //转向网页的地址;
                var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
                var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
                var b = window.open(url, winname, "height=" + iHeight + ", width=" + iWidth + ", top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes");  //写成一行

                //                    b.location.reload();
                b.focus();
            }
            else {
                return null;
            }

        } 
    </script>
    <script language="JavaScript">
　　        function openwin(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "?" + Math.random();                              //转向网页的地址;
            //              var name;                           //网页名称，可为空;
            //              var iWidth = 650;                          //弹出窗口的宽度;
            //              var iHeight = 400;                        //弹出窗口的高度;
            //            var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
            //            var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
            var iTop = window.screen.availHeight - 30;       //获得窗口的垂直位置;
            var iLeft = window.screen.availWidth - 10;           //获得窗口的水平位置;
            //              window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
            var a = window.open(url, winname, "height=" + iTop + ", width=" + iLeft + ", top=" + 0 + ",left=" + 0 + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes");  //写成一行
            //　　            a.reload();
            //　　            a.location.reload();
            a.focus();
            //　　              window.location = url;
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%">
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server">
                <table border="1" cellpadding="0" cellspacing="0" class="hidden1" frame="Border">
                    <tr>
                        <td align="center">
                            过滤数据:
                        </td>
                        <td align="center">
                            部门<asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
                            &nbsp;班组<asp:DropDownList ID="DropDownList4" runat="server">
                            </asp:DropDownList>
                            销售订单号<asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
                            生产订单号<asp:TextBox ID="TextBox2" runat="server" Width="80px"></asp:TextBox>
                            是否缺料<asp:DropDownList ID="DropDownList6" runat="server">
                                <asp:ListItem Selected="True">全部</asp:ListItem>
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem>否</asp:ListItem>
                            </asp:DropDownList>
                            是否是逾期定单<asp:DropDownList ID="DropDownList逾期定单" runat="server">
                                <asp:ListItem Selected="True">全部</asp:ListItem>
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem>否</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/WorkForms/Chart.aspx"
                                Target="_blank">查看逾期原因图表</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"
                        OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound" PageSize="30"
                        AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging1" AllowSorting="True"
                        OnSorting="GridView1_Sorting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                        AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                        <AlternatingRowStyle BackColor="#F2F2F2" />
                        <Columns>
                            <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                                ItemStyle-CssClass="hidden1">
                                <ItemTemplate>
                                  <%--  <asp:HiddenField runat="server" Value='<%# Eval("发票号")%>' ID="发票号" />
                                    <asp:HiddenField runat="server" Value='<%# Eval("autoid")%>' ID="autoid" />--%>
                                </ItemTemplate>
                                <FooterStyle CssClass="hidden1" />
                                <HeaderStyle CssClass="hidden1" />
                                <ItemStyle Width="0px" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="部门">
                                <EditItemTemplate>
                                     <asp:Label ID="Label1_1" runat="server" Text='<%# Bind("部门") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("部门") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="业务员">
                                <EditItemTemplate>
                                     <asp:Label ID="Label2_1" runat="server" Text='<%# Bind("业务员") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("业务员") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客户编码">
                                <EditItemTemplate>
                                    <asp:Label ID="Label3_1" runat="server" Text='<%# Bind("客户编码") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("客户编码") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发票号">
                                <EditItemTemplate>
                                    <asp:Label ID="Label4_1" runat="server" Text='<%# Bind("发票号") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("发票号") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="开票日期">
                                <EditItemTemplate>
                                 <asp:Label ID="Label5_1" runat="server" Text='<%# Bind("开票日期","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("开票日期","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发票金额">
                                <ItemTemplate>
                                    <asp:Label ID="label发票金额" runat="server" Text='<%# Eval("发票金额").GetType()==typeof(DBNull)?"":Eval("发票金额").ToString()%> '></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt发票金额" runat="server" Text='<%#Eval("发票金额")%>' Width="100"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="核销金额">
                                <ItemTemplate>
                                    <asp:Label ID="label核销金额" runat="server" Text='<%# Eval("核销金额").GetType()==typeof(DBNull)?"":Eval("核销金额").ToString()%> '></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt核销金额" runat="server" Text='<%#Eval("核销金额")%>' Width="100"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="未核销金额">
                                <ItemTemplate>
                                    <asp:Label ID="label未核销金额" runat="server" Text='<%# Eval("未核销金额").GetType()==typeof(DBNull)?"":Eval("未核销金额").ToString()%> '></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt未核销金额" runat="server" Text='<%#Eval("未核销金额")%>' Width="100"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                               <asp:TemplateField HeaderText="质保金金额">
                                <ItemTemplate>
                                    <asp:Label ID="label质保金金额" runat="server" Text='<%# Eval("质保金金额").GetType()==typeof(DBNull)?"":Eval("质保金金额").ToString()%> '></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt质保金金额" runat="server" Text='<%#Eval("质保金金额")%>' Width="100"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                                 <asp:TemplateField HeaderText="质保金核销">
                                <ItemTemplate>
                                    <asp:Label ID="label质保金核销" runat="server" Text='<%# Eval("质保金核销").GetType()==typeof(DBNull)?"":Eval("质保金核销").ToString()%> '></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt质保金核销" runat="server" Text='<%#Eval("质保金核销")%>' Width="100"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                                 <asp:TemplateField HeaderText="质保金未核销">
                                <ItemTemplate>
                                    <asp:Label ID="label质保金未核销" runat="server" Text='<%# Eval("质保金未核销").GetType()==typeof(DBNull)?"":Eval("质保金未核销").ToString()%> '></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt质保金未核销" runat="server" Text='<%#Eval("质保金未核销")%>' Width="100"></asp:TextBox>
                                </EditItemTemplate>
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
                            </asp:TemplateField>--%>
                            
                            
                       <asp:BoundField DataField="报销人" HeaderText="报销人" />
                       <asp:BoundField DataField="报销日期" HeaderText="报销日期" DataFormatString="{0:yyyy-M-d}" />
                      <asp:BoundField DataField="部门" HeaderText="部门" />
                        <asp:BoundField DataField="项目" HeaderText="项目" />
                        <asp:BoundField DataField="事项" HeaderText="事项" />
                        <asp:BoundField DataField="金额" HeaderText="金额" />

                        </Columns>
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
                            <asp:Label ID="Label6" runat="server" Text="当前页码为："></asp:Label>&nbsp
                            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            &nbsp <asp:Label ID="Label7" runat="server" Text="总页码为："></asp:Label>
                            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            没有数据
                        </EmptyDataTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
