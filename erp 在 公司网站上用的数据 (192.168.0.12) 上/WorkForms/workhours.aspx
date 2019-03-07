<%@ page title="车间计工" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_workhours, App_Web_ygebp2ua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 align="center">
        &nbsp;<asp:Label ID="Label1" runat="server" Text="车间计工"></asp:Label>
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" 
                style="font-size: xx-large">
                <tr>
                    <td align="center">
                        过滤数据:
                    </td>
                    <td align="center">
                        部门<asp:DropDownList ID="DropDownList3" runat="server" Font-Size="XX-Large">
                        </asp:DropDownList>
                        &nbsp;班组<asp:DropDownList ID="DropDownList4" runat="server" 
                            Font-Size="XX-Large">
                        </asp:DropDownList>
                        销售订单号<asp:TextBox ID="TextBox1" runat="server" Font-Size="XX-Large"></asp:TextBox>
                        是否缺料<asp:DropDownList ID="DropDownList6" runat="server" Font-Size="XX-Large">
                            <asp:ListItem Selected="True">全部</asp:ListItem>
                            <asp:ListItem>是</asp:ListItem>
                            <asp:ListItem>否</asp:ListItem>
                        </asp:DropDownList>
                        是否是逾期定单<asp:DropDownList ID="DropDownList逾期定单" runat="server" 
                            Font-Size="XX-Large">
                            <asp:ListItem Selected="True">全部</asp:ListItem>
                            <asp:ListItem>是</asp:ListItem>
                            <asp:ListItem>否</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" 
                            Font-Size="XX-Large" />
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/WorkForms/workhours_manage.aspx"
                            Target="_blank">管理工时</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink5" runat="server" 
                            NavigateUrl="~/WorkForms/workhours_shenhe.aspx" Target="_blank">审核</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink6" runat="server" 
                            NavigateUrl="~/WorkForms/workhours_manage_worker.aspx" Target="_blank">管理工人</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"
                    OnDataBound="GridView1_DataBound" PageSize="30" Font-Size="XX-Large">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" Value='<%# Eval("modid")%>' ID="modid" />
                                <asp:HiddenField runat="server" Value='<%# Eval("MDeptCode")%>' ID="MDeptCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("MoId")%>' ID="MoId" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SortSeq")%>' ID="SortSeq" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cInvCode")%>' ID="cInvCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cinvdefine4")%>' ID="cinvdefine4" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SoDId")%>' ID="SoDId" />
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cCusName" HeaderText="客户名称" Visible="False" />
                        <asp:TemplateField HeaderText="班组" Visible="False">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("cinvdefine4") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SoCode" HeaderText="销售订单号" Visible="False" />
                        <asp:BoundField DataField="soseq" HeaderText="销售订单行号" Visible="False" />
                        <asp:BoundField DataField="mocode" HeaderText="生产订单号" />
                        <asp:BoundField DataField="sortseq" HeaderText="生产订单行号" />
                        <asp:BoundField DataField="InvCode" HeaderText="产品编码" />
                        <asp:BoundField DataField="cinvname" HeaderText="产品名称" />
                        <asp:BoundField DataField="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}"></asp:BoundField>
                        <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" DataFormatString="{0:0.00}">
                        </asp:BoundField>
                        <asp:BoundField DataField="startdate" HeaderText="开工期" DataFormatString="{0:yyyy-M-d}"
                            Visible="False" />
                        <asp:TemplateField HeaderText="预计完工期">
                            <ItemTemplate>
                                <asp:Label ID="label2" runat="server" Text='<%# Bind("Duedate","{0:yyyy-MM-dd}") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="逾期原因"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="label1" runat="server" ></asp:Label>
                                <asp:DropDownList ID="txt逾期原因" runat="server" >
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                    <asp:ListItem>销售原因</asp:ListItem>
                                    <asp:ListItem>供应商原因</asp:ListItem>
                                    <asp:ListItem>生产原因</asp:ListItem>
                                    <asp:ListItem>设备原因</asp:ListItem>
                                    <asp:ListItem>质量原因</asp:ListItem>
                                    <asp:ListItem>技术原因</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="工时">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text="工时录入" />
                            </ItemTemplate>
                            <ControlStyle Width="250px" />
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="工时">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server" Text="工时管理" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
                <table align="right" style="font-size: xx-large">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnFirst" runat="server" Text="首页" OnClick="lnkbtnFirst_Click"
                                CssClass="wrapBtn" Font-Size="XX-Large"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkbtnFront" runat="server" Text="上一页" OnClick="lnkbtnFront_Click"
                                CssClass="wrapBtn" Font-Size="XX-Large"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkbtnNext" runat="server" Text="下一页" OnClick="lnkbtnNext_Click"
                                CssClass="wrapBtn" Font-Size="XX-Large"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="linkbtnLast" runat="server" Text="尾页" OnClick="linkbtnLast_Click"
                                CssClass="wrapBtn" Font-Size="XX-Large"></asp:LinkButton>&nbsp;当前页码为：<asp:Label 
                                ID="labPage" runat="server" Font-Size="XX-Large">1</asp:Label>
                            &nbsp; 总页码为：<asp:Label ID="labBackPage" runat="server" Font-Size="XX-Large"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
