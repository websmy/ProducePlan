<%@ page title="销售业绩查询" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_销售业绩查询, App_Web_ygebp2ua" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 116px;
            height: 91px;
        }
        .style4
        {
            text-align: right;
            width: 102px;
        }
        .style5
        {
            width: 102px;
            text-align: right;
        }
        .style6
        {
            height: 91px;
        }
        .style7
        {
            text-align: left;
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
        &nbsp;<asp:Label ID="Label1" runat="server" Text="销售业绩查询"></asp:Label>
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border">
                <tr>
                    <td align="center" class="style3">
                        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="生成图表" 
                            ValidationGroup="G2" style="height: 21px" />
                    </td>
                    <td align="center" class="style6">
                        

                        <table cellpadding="0" cellspacing="0" class="style1" border="1">
                            <tr>
                                <td class="style4">
                                    部门</td>
                                <td class="style7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    业务员</td>
                                <td class="style7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    基准年月</td>
                                <td class="style7">
                                    <asp:DropDownList ID="ddlYear" runat="server" 
                                        onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem>请选择</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="ddlYear" ErrorMessage="*" ForeColor="Red" InitialValue="请选择" 
                                        ValidationGroup="G1"></asp:RequiredFieldValidator>
                                    年<asp:DropDownList ID="ddlMonth" runat="server">
                                        <asp:ListItem>请选择</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                    月<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="ddlMonth" ErrorMessage="*" ForeColor="Red" InitialValue="请选择" 
                                        ValidationGroup="G1"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlUPDown" runat="server">
                                        <asp:ListItem>请选择</asp:ListItem>
                                        <asp:ListItem Value="&gt;">上升</asp:ListItem>
                                        <asp:ListItem Value="&lt;">下降</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="ddlUPDown" ErrorMessage="*" ForeColor="Red" 
                                        InitialValue="请选择" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    查询的月度区间</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
                                    个月<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txtCount" ErrorMessage="*" ForeColor="Red" 
                                        ValidationGroup="G1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    客户</td>
                                <td class="style7">
                                    <asp:DropDownList ID="ddlCustomer" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="ddlCustomer" ErrorMessage="*" InitialValue="请选择" 
                                        ValidationGroup="G1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" ValidationGroup="G1" 
                                        onclick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="style6">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        
        <div align="center">
            <asp:Chart runat="server" Height="316px" Width="850px" ID="Chart1" 
                Visible="False">
                <series>
                    <asp:Series Name="2013年" Legend="Legend1" ToolTip="#SERIESNAME#VAL" 
                        ChartType="Line" BorderWidth="10"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" 
                        Name="2014年" ToolTip="#SERIESNAME#VAL" ChartType="Line" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2015年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2016年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                </series>
                <chartareas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="金额（单位：元）">
                    </AxisY>
                    <AxisX Title="月份" IsLabelAutoFit="False">
                    </AxisX>
                    </asp:ChartArea></chartareas>
                <Legends>
                    <asp:Legend Docking="Top" Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 10pt" Name="Title1" Text="销售订单">
                    </asp:Title>
                </Titles>
            </asp:Chart>
       </div>
    <div align="center">
            <asp:Chart runat="server" Height="316px" Width="850px" ID="Chart2" 
                Visible="False">
                <series>
                    <asp:Series Name="2013年" Legend="Legend1" ToolTip="#SERIESNAME#VAL" 
                        ChartType="Line" BorderWidth="10"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" 
                        Name="2014年" ToolTip="#SERIESNAME#VAL" ChartType="Line" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2015年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2016年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                </series>
                <chartareas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="金额（单位：元）">
                    </AxisY>
                    <AxisX Title="月份" IsLabelAutoFit="False">
                    </AxisX>
                    </asp:ChartArea></chartareas>
                <Legends>
                    <asp:Legend Docking="Top" Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 10pt" Name="Title1" Text="销售发货单">
                    </asp:Title>
                </Titles>
            </asp:Chart>
       </div>
           <div align="center">
            <asp:Chart runat="server" Height="316px" Width="850px" ID="Chart3" 
                Visible="False">
                <series>
                    <asp:Series Name="2013年" Legend="Legend1" ToolTip="#SERIESNAME#VAL" 
                        ChartType="Line" BorderWidth="10"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" 
                        Name="2014年" ToolTip="#SERIESNAME#VAL" ChartType="Line" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2015年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2016年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                </series>
                <chartareas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="金额（单位：元）">
                    </AxisY>
                    <AxisX Title="月份" IsLabelAutoFit="False">
                    </AxisX>
                    </asp:ChartArea></chartareas>
                <Legends>
                    <asp:Legend Docking="Top" Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 10pt" Name="Title1" Text="销售发票">
                    </asp:Title>
                </Titles>
            </asp:Chart>
       </div>
       
           <div align="center">
            <asp:Chart runat="server" Height="316px" Width="850px" ID="Chart4" 
                Visible="False">
                <series>
                    <asp:Series Name="2013年" Legend="Legend1" ToolTip="#SERIESNAME#VAL" 
                        ChartType="Line" BorderWidth="10"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" 
                        Name="2014年" ToolTip="#SERIESNAME#VAL" ChartType="Line" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2015年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                        Name="2016年" ToolTip="#SERIESNAME#VAL" BorderWidth="10">
                    </asp:Series>
                </series>
                <chartareas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="金额（单位：元）">
                    </AxisY>
                    <AxisX Title="月份" IsLabelAutoFit="False">
                    </AxisX>
                    </asp:ChartArea></chartareas>
                <Legends>
                    <asp:Legend Docking="Top" Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 10pt" Name="Title1" Text="收款单">
                    </asp:Title>
                </Titles>
            </asp:Chart>
       </div>
       
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"
                    OnDataBound="GridView1_DataBound" PageSize="30" Width="100%">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                             
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
                       
                      

                   <%--     <asp:BoundField DataField="年" HeaderText="年" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="月" HeaderText="月" >
                   
                        </asp:BoundField>
                        <asp:BoundField DataField="客户名称" HeaderText="客户名称" >
                     
                        </asp:BoundField>
                        <asp:BoundField DataField="金额" HeaderText="金额" >

                        </asp:BoundField>--%>
                        
                        <%--<asp:BoundField DataField="金额" HeaderText="金额" />--%>
                 

                    </Columns>
                  
                    <EmptyDataTemplate>
                        没有数据
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                        />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </asp:Content>
