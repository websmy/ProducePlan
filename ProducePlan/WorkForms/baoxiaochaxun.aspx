<%@ Page Title="报销查询" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="baoxiaochaxun.aspx.cs" Inherits="WorkForms_baoxiaochaxun" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        报销查询</h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" width="100%">
                <tr>
                    <td align="center">
                        请选择年月：<asp:DropDownList ID="ddlYear" runat="server">
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList>
                        年
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
                        月
                      
                       
                        &nbsp;
                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" ValidationGroup="G1" />
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="报销合计："></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="Button111" runat="server" OnClick="Button111_Click" Text="导到Excel"
                            ValidationGroup="G1" />
                    </td>
                </tr>
                
                <tr><td align="center">请选择要要上传几月份的数据：<asp:DropDownList ID="DropDownList1" 
                        runat="server" ValidationGroup="vg1">
                            <asp:ListItem Selected="True" Value="请选择">请选择</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList>
                        年
                        <asp:DropDownList ID="DropDownList2" runat="server" ValidationGroup="vg1">
                            <asp:ListItem Value="请选择">请选择</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
                        月<asp:FileUpload ID="FileUpload1" runat="server" Height="18px" 
                        Width="333px" />
                    <asp:Button ID="Button112" runat="server" onclick="Button112_Click" 
                        Text="开始上传" ValidationGroup="vg1" />
                    </td> <td>ddd</td>  <td>eeee</td> </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("应收款")%>' ID="应收款" />--%>
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("开票日期")%>' ID="开票日期" />--%>
                                <asp:HiddenField runat="server" Value='<%# Eval("部门")%>' ID="部门" />
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
<%--                        <asp:BoundField DataField="报销人" HeaderText="报销人" />
                        <asp:BoundField DataField="报销日期" HeaderText="报销日期" DataFormatString="{0:yyyy-M-d}" />
--%>                        <asp:BoundField DataField="部门" HeaderText="部门" />
                        <%--<asp:BoundField DataField="项目" HeaderText="项目" />--%>
                        <%--<asp:BoundField DataField="事项" HeaderText="事项" />--%>
                        <asp:BoundField DataField="金额" HeaderText="金额" />
                        <asp:BoundField DataField="部门金额" HeaderText="部门金额" />
                        <asp:BoundField DataField="差值" HeaderText="差值" />
                        
                        
                        <%-- <asp:BoundField DataField="应收款" HeaderText="应收款" DataFormatString="{0:N}">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="详细">
                            <ItemTemplate>
                                 <asp:HyperLink ID="HyperLink1" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                    </PagerTemplate>
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
                <asp:Button ID="Button3" runat="server" Text="Button" Width="275px" Style="display: none" />
                <asp:Button ID="btntargetControlOfmpeFirstDialogBox" runat="Server" Text="" Style="display: none;" />
                <asp:Panel ID="pnlFirstDialogBox" runat="server" BorderStyle="Solid" BorderWidth="1"
                    Style="width: 700px; background-color: White; display: none; height: 400px;">
                    <asp:Panel ID="pnlFirstDialogBoxHeader" runat="server" Width="100%" BackColor="#006699"
                        HorizontalAlign="Right">
                        <asp:Button ID="btnCloseFirstDialogBox" runat="server" Text="关闭" />
                    </asp:Panel>
                    <asp:Panel ID="pnlFirstDialogBoxDetail" runat="server" Width="99%" HorizontalAlign="left">
                        <h1>
                            This is the first DialogBox</h1>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <table border="1">
                            <tr>
                                <td style="width: 100px">
                                    Name:
                                </td>
                                <td style="width: 128px">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Description:
                                </td>
                                <td style="width: 128px">
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 128px">
                                    <asp:Button ID="Button110" runat="server" Text="Save" />
                                    <%--<asp:Button ID="Button2" runat="server" Text="Cancel" />--%>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <%--this button opens the Second dialogbox--%>
                        <%--<asp:Button ID="btnOpenSecondDialogBox" runat="server" Text="Open Second DialogBox"
                        OnClick="btnOpenSecondDialogBox_Click" />--%>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
</asp:Content>
