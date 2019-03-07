<%@ page title="产能分析" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_cnfx, App_Web_2h3v2kfy" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

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
        &nbsp;<asp:Label ID="Label1" runat="server" Text="产能分析"></asp:Label>
    </h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border">
                <tr>
                    <td align="center">
                        条件:
                    </td>
                    <td align="center">
                        
                        部门<asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="*" ForeColor="red" ValidationGroup="G1" 
                            ControlToValidate="DropDownList3" InitialValue="全部"></asp:RequiredFieldValidator>

                        &nbsp;班组<asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                       
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="*" ForeColor="red" ValidationGroup="G1" 
                            ControlToValidate="DropDownList4" InitialValue="全部"></asp:RequiredFieldValidator>

                           开始日期<asp:TextBox ID="txtDate" runat="server" ControlToValidate="txtDate"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtDate" ForeColor="Red"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="*" ForeColor="red" ValidationGroup="G1" 
                            ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                        
                           结束日期<asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtDate1" ForeColor="Red"></asp:CompareValidator>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="*" ForeColor="red" ValidationGroup="G1" 
                            ControlToValidate="txtDate1"></asp:RequiredFieldValidator>

                       <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDate1"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>


                        <asp:Button ID="btnFilter" runat="server" Text="生成图表" OnClick="btnFilter_Click" ValidationGroup="G1" />
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/WorkForms/cnfx_manage.aspx"
                            Target="_blank">管理</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <div align="center">
            <asp:Chart runat="server" Height="316px" Width="850px" ID="Chart2" 
                Visible="False">
                <series><asp:Series Name="班组工时" Legend="Legend1" ToolTip="#VAL"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" 
                        Name="分配工时" ToolTip="#VAL">
                    </asp:Series>
                </series>
                <chartareas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="工时（单位：小时）">
                    </AxisY>
                    <AxisX Title="班组" IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                    </AxisX>
                    </asp:ChartArea></chartareas>
                <Legends>
                    <asp:Legend Docking="Top" Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 10pt" Name="Title1" Text="产能分析图表（按班组分类）">
                    </asp:Title>
                </Titles>
            </asp:Chart>
       </div>
    <div align="center">
            <asp:Chart runat="server" Height="316px" Width="850px" ID="Chart1" 
                Visible="False">
                <series><asp:Series Name="生产订单工时" Legend="Legend1" ToolTip="#VAL"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Legend="Legend1" 
                        Name="分配工时" ToolTip="#VAL">
                    </asp:Series>
                </series>
                <chartareas><asp:ChartArea Name="ChartArea1">
                    <AxisY Title="工时（单位：小时）">
                    </AxisY>
                    <AxisX Title="日期" IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                    </AxisX>
                    </asp:ChartArea></chartareas>
                <Legends>
                    <asp:Legend Docking="Top" Name="Legend1">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 10pt" Name="Title1" Text="产能分析图表">
                    </asp:Title>
                </Titles>
            </asp:Chart>
       </div>
       
</asp:Content>
