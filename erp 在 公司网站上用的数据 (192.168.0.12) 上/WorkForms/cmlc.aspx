<%@ page title="车间下料" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_cmlc, App_Web_ygebp2ua" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="JavaScript">
　　        function openwin(name, winname, id) {
            var url = name + "?id=" + id + "&p7=1?" + Math.random();                              //转向网页的地址;
            var iTop = window.screen.availHeight - 30;       //获得窗口的垂直位置;
            var iLeft = window.screen.availWidth - 10;           //获得窗口的水平位置;
            var a = window.open(url, winname, "height=" + iTop + ", width=" + iLeft + ", top=" + 0 + ",left=" + 0 + ",toolbar=no, menubar=yes, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes");  //写成一行
            a.focus();
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
    <h2 align="center">
        &nbsp;<asp:Label ID="Label1" runat="server" Text="出门流程"></asp:Label>
        -其它单据</h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border">
                <tr>
                    <td align="center">
                        过滤数据:
                    </td>
                    <td align="center">
                        单号<asp:TextBox ID="TextBox2" runat="server" Width="80px"></asp:TextBox>
                        当前节点：<asp:DropDownList ID="DropDownList4" runat="server">
                            <asp:ListItem Selected="True">全部</asp:ListItem>
                            <asp:ListItem Value="1">1:财务部</asp:ListItem>
                            <asp:ListItem Value="2">2:用车主管</asp:ListItem>
                            <asp:ListItem Value="3">3:门卫北</asp:ListItem>
                            <asp:ListItem Value="4">4:门卫南</asp:ListItem>
                            <asp:ListItem Value="5">5:用车主管实际结算</asp:ListItem>
                            <asp:ListItem Value="6">6:财务审单</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"
                    OnDataBound="GridView1_DataBound" PageSize="30" Width="100%">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" Value='<%# Eval("单号autoid")%>' ID="单号autoid" />
                                <asp:HiddenField runat="server" Value='<%# Eval("status")%>' ID="status" />
                                <asp:HiddenField runat="server" Value='<%# Eval("autoid")%>' ID="autoid" />
                                
                                <asp:HiddenField runat="server" Value='<%# Eval("id")%>' ID="id" />

                                <%--  <asp:HiddenField runat="server" Value='<%# Eval("MDeptCode")%>' ID="MDeptCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("MoId")%>' ID="MoId" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SortSeq")%>' ID="SortSeq" />
             
                                <asp:HiddenField runat="server" Value='<%# Eval("cInvCode")%>' ID="cInvCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cinvdefine4")%>' ID="cinvdefine4" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SoDId")%>' ID="SoDId" />
                                 <asp:HiddenField runat="server" Value='<%# Eval("SoCode")%>' ID="SoCode" />
                                 
                                  <asp:HiddenField runat="server" Value='<%# Eval("qian")%>' ID="qian" />
                                   <asp:HiddenField runat="server" Value='<%# Eval("hou")%>' ID="hou" />--%>
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="单据类型" HeaderText="单据类型" />
                        <asp:BoundField DataField="单号" HeaderText="单号" />
                        <asp:BoundField DataField="发货日期" HeaderText="发货日期" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="客户" HeaderText="客户" />
                        <asp:BoundField DataField="存货名称" HeaderText="存货名称" />
                        <asp:BoundField DataField="备注" HeaderText="备注" />
                        <asp:BoundField DataField="数量" HeaderText="数量" />
                        <asp:BoundField DataField="金额" HeaderText="金额" />
                        <asp:BoundField DataField="cMaker" HeaderText="制单人" />
                        <asp:TemplateField HeaderText="承运商">
                            <ItemTemplate>
                                
                                <asp:DropDownList runat="server" ID="承运商"  Enabled="False"/>
                                
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="承运商" InitialValue="-1" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                                
                                <%--<asp:TextBox ID="承运商" runat="server" Text='<%# Bind("承运商") %>' ReadOnly="True"></asp:TextBox>--%>
  <%--                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 必添"
                                    ControlToValidate="承运商" InitialValue="" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
  --%>                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="运费">
                            <ItemTemplate>
                                <asp:TextBox ID="运费" runat="server" Text='<%# Bind("运费") %>' ReadOnly="True" Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 必添"
                                    ControlToValidate="运费" InitialValue="" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="门卫">
                            <ItemTemplate>
                                  <asp:Label ID="Label3" runat="server" Text='<%# Bind("门卫") %>'></asp:Label>
                                
                                <asp:DropDownList ID="门卫" runat="server" Visible="False" >
                                    <asp:ListItem Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem>门卫北</asp:ListItem>
                                    <asp:ListItem>门卫南</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* 必添"
                                    ControlToValidate="门卫" InitialValue="请选择" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="当前节点">
                            <ItemTemplate>
                                  <asp:Label ID="Label当前节点" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:Button ID="asp_btnUpdate" runat="server" Text="确定" CommandName="Modify" CommandArgument=''
                                    CssClass="btnOneLine"  Enabled="False" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="班组">
                            <ItemTemplate>
                                
                                 
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("cinvdefine4") %>'></asp:Label>

                               
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:BoundField DataField="SoCode" HeaderText="销售订单号" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="soseq" HeaderText="销售订单行号" >
                   
                        </asp:BoundField>
                        <asp:BoundField DataField="mocode" HeaderText="生产订单号" >
                     
                        </asp:BoundField>
                        <asp:BoundField DataField="sortseq" HeaderText="生产订单行号" >

                        </asp:BoundField>
                        <asp:BoundField DataField="InvCode" HeaderText="产品编码" >
                    
                        </asp:BoundField>
                        <asp:BoundField DataField="cinvname" HeaderText="产品名称" >
                    
                        </asp:BoundField>
                        <asp:BoundField DataField="Qty" HeaderText="订单数量" DataFormatString="{0:0.00}">
                        
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="DueDate" HeaderText="完成时间" DataFormatString="{0:yyyy-MM-dd}">
                        
                        </asp:BoundField>
                        
                     
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                
                                 
                                
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                               
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
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
