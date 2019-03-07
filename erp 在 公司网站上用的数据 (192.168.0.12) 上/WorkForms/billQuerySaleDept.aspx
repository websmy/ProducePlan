<%@ page title="应收款查询" language="C#" enableeventvalidation="false" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_billQuerySaleDept, App_Web_ygebp2ua" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
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
        应收款查询</h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" width="100%">
                <tr>
                    
                    <td align="center">
                        业务员<asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                        部门<asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
                        &nbsp;客户<asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                        <asp:Label ID="Label8" runat="server" Text="日期"></asp:Label>
                        <asp:TextBox ID="txtStartDate" runat="server" Width="90" 
                            ToolTip="从哪个日期往前推，到期应收款计算用"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtStartDate" ForeColor="Red"></asp:CompareValidator>
                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>

                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" ValidationGroup="G1"  />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="应收款合计："></asp:Label>
                        <asp:Label ID="Label5"
                            runat="server" Text="Label" Font-Bold="True"></asp:Label>
                      
                    </td>
                    <td>  <asp:Label ID="Label6" runat="server" Text="到期应收款合计："></asp:Label>
                        <asp:Label
                                ID="Label7" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
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
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" Value='<%# Eval("应收款")%>' ID="应收款" />
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("开票日期")%>' ID="开票日期" />--%>
                                <asp:HiddenField runat="server" Value='<%# Eval("客户编码")%>' ID="客户编码" />
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="客户编码" HeaderText="客户编码" />
                        <asp:BoundField DataField="cCusName" HeaderText="客户名称" />
                        <asp:BoundField DataField="部门" HeaderText="部门" />
                        <asp:BoundField DataField="业务员" HeaderText="业务员" />
                        <asp:BoundField DataField="应收款" HeaderText="应收款" DataFormatString="{0:N}">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        
                          <asp:TemplateField HeaderText="1-90" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection1" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="91-180" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection2" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="181-365" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection3" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="366-730" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection4" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                           <asp:TemplateField HeaderText="731-1095" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection5" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="1096-1460" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection6" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="1461-1825" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection7" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="1826以上" >
                            <ItemTemplate>
                                <asp:Label ID="labelsection8" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>


                        

                        <asp:TemplateField HeaderText="到期应收款" >
                            <ItemTemplate>
                                <asp:Label ID="label2" runat="server" Text='' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="信用额度">
                            <ItemTemplate>
                                <asp:Label ID="label3" runat="server" Text=''></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="信用期限">
                            <ItemTemplate>
                                <asp:Label ID="label4" runat="server" Text=''></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
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
