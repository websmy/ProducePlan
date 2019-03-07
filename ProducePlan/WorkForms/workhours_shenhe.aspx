<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workhours_shenhe.aspx.cs"
    Inherits="workhours_shenhe" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
</head>
<body>
    <form id="form1" runat="server">
    <h2 align="center">
        &nbsp;<asp:Label ID="Label1" runat="server" Text="车间计工审核"></asp:Label>
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border">
            <tr>
                <td align="center">
                    过滤数据:
                </td>
                <td align="center">
                    销售订单号<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    部门<asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    班组<asp:DropDownList ID="DropDownList4" runat="server">
                    </asp:DropDownList>
                    姓名&nbsp;<asp:DropDownList ID="DropDownList6" runat="server">
                    </asp:DropDownList>
                    产品编码<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" />
                </td>
                <td>
                       
                        <asp:Button ID="Button111" runat="server" onclick="Button111_Click" 
                            Text="导到Excel" ValidationGroup="G1" />
                       
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
            OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"
            OnDataBound="GridView1_DataBound" PageSize="30">
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
                        <asp:HiddenField runat="server" Value='<%# Eval("autoid")%>' ID="autoid" />
                        <asp:HiddenField runat="server" Value='<%# Eval("classId")%>' ID="hclassId" />
                        <asp:HiddenField runat="server" Value='<%# Eval("shenFlag")%>' ID="hidShenFlag" />
                        <asp:HiddenField runat="server" Value='<%# Eval("SoDId")%>' ID="SoDId" />
                    </ItemTemplate>
                    <FooterStyle CssClass="hidden1" />
                    <HeaderStyle CssClass="hidden1" />
                    <ItemStyle Width="0px" />
                </asp:TemplateField>
                <%-- <asp:BoundField DataField="cCusName" HeaderText="客户名称" Visible="False" />
                        <asp:TemplateField HeaderText="班组" Visible="False">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("cinvdefine4") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                <asp:BoundField DataField="SoCode" HeaderText="销售订单号" Visible="False" />
                <asp:BoundField DataField="soseq" HeaderText="销售订单行号" Visible="False" />
                <asp:BoundField DataField="mocode" HeaderText="生产订单号" />
                <asp:BoundField DataField="sortseq" HeaderText="生产订单行号" />
                <asp:BoundField DataField="InvCode" HeaderText="产品编码" />
                <asp:BoundField DataField="cinvname" HeaderText="产品名称" />
                <asp:BoundField DataField="name" HeaderText="姓名" />
                <asp:TemplateField HeaderText="工序名称">
                    <ItemTemplate>
                        <asp:Label ID="lblclassId" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="iquantity" HeaderText="数量" />
                <asp:TemplateField HeaderText="单件工时">
                    <ItemTemplate>
                        <asp:Label ID="lblworkhours" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="tworkhours" HeaderText="总工时" />
                <asp:BoundField DataField="date" HeaderText="日期" DataFormatString="{0:yyyy-M-d}" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="btnShenHe" runat="server" Text="审核" CommandName="shenhe" CommandArgument=''
                            CssClass="btnOneLine" Font-Size="X-Large" ForeColor="#FF3300" />
                        <asp:Button ID="btnQishen" runat="server" Text="弃审" CommandName="qishen" CommandArgument=''
                            CssClass="btnOneLine" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:BoundField DataField="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}"></asp:BoundField>
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
                        </asp:TemplateField>--%>
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
    </form>
</body>
