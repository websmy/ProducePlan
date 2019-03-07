<%@ page title="销售订单排产" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_SO, App_Web_ygebp2ua" %>
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
        销售订单排产</h2>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        

         <asp:Panel ID="Panel1" runat="server">
            <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" width="100%">
                <tr>
                    <td align="center">
                        过滤数据:
                    </td>
                    <td align="center">
                        业务员<asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList> 制单人<asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>

                        部门<asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
                        &nbsp;客户<asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                        销售订单号<asp:TextBox ID="TextBox3" runat="server" Width="80px"></asp:TextBox>
                        库存数<asp:DropDownList ID="DropDownList5" runat="server"> 
                            <asp:ListItem>全部</asp:ListItem>
                            <asp:ListItem>大于0</asp:ListItem>
                        </asp:DropDownList>
                       
                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click" />
                    </td>
                   
                </tr>
            </table>
        </asp:Panel>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" 
                    OnRowCommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound">
                    <Columns>
                       <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" Value='<%# Eval("iSOsID")%>' ID="iSOsID" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cInvCode")%>' ID="cInvCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cSOCode")%>' ID="cSOCode" />
                            

                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>

                       

                        <asp:BoundField DataField="cSOCode" HeaderText="订单号" />

                        <asp:BoundField DataField="iRowNo" HeaderText="订单行号" />
                        <asp:BoundField DataField="cCusName" HeaderText="客户" />
                        <asp:BoundField DataField="dDate" HeaderText="订单日期" DataFormatString="{0:yyyy-M-d}" />
                        <asp:BoundField DataField="cInvCode" HeaderText="产品编码" />
                        <asp:BoundField DataField="cInvName" HeaderText="产品名称" />
                       
                        <asp:BoundField DataField="iQuantity" HeaderText="订单数量" />
                        <%--<asp:BoundField DataField="dPreMoDate" HeaderText="预计完工期" DataFormatString="{0:yyyy-M-d}" />--%>
                        <asp:BoundField DataField="iNatSum" HeaderText="价税合计" DataFormatString = "{0:F}"/>

                         <asp:TemplateField HeaderText="预完工日期">
                            <ItemTemplate>
                               
                               <asp:Label ID="label2" runat="server" Text='<%# Bind("dPreMoDate","{0:yyyy-MM-dd}") %>'></asp:Label>

                                                    
                                                    <%--<asp:TextBox ID="txtPreMoDate" runat="server" Text='<%# Bind("dPreMoDate","{0:yyyy-MM-dd}") %>' Width="80px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtPreMoDate" ForeColor="Red"></asp:CompareValidator>
                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtPreMoDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>--%>

                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="评审交期">
                            <ItemTemplate>
                                 <asp:HiddenField runat="server" Value='<%# Eval("iInvAdvance")%>' ID="iInvAdvance" />
                           <asp:TextBox ID="txtcDefine37" runat="server" Text='<%# Bind("cDefine37","{0:yyyy-MM-dd}") %>' Width="80px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtcDefine37" ForeColor="Red"></asp:CompareValidator>
                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtcDefine37"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>

                            </ItemTemplate>
                          
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:Button ID="asp_btnUpdate" runat="server" Text="更新" CommandName="Modify" CommandArgument='<%# Eval("AutoID")%>'
                                    CssClass="btnOneLine" ValidationGroup="G1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                         
                         <asp:BoundField DataField="iFHQuantity" HeaderText="发货数量"/>
                        <asp:BoundField DataField="iKPQuantity" HeaderText="开票数量"/>
                        <%--<asp:BoundField DataField="xiancun" HeaderText="库存数"/>--%>
                        
                         <asp:TemplateField HeaderText="库存数">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="车间排产">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server">查看</asp:HyperLink>
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
                
                <table align="right">
            <tr>
                <td>
                    <asp:LinkButton ID="lnkbtnFirst" runat="server" Text="首页" OnClick="lnkbtnFirst_Click" CssClass="wrapBtn"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkbtnFront" runat="server" Text="上一页" OnClick="lnkbtnFront_Click" CssClass="wrapBtn"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkbtnNext" runat="server" Text="下一页" OnClick="lnkbtnNext_Click" CssClass="wrapBtn"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="linkbtnLast" runat="server" Text="尾页" OnClick="linkbtnLast_Click" CssClass="wrapBtn"></asp:LinkButton>&nbsp;当前页码为：<asp:Label
                        ID="labPage" runat="server">1</asp:Label>
                    &nbsp; 总页码为：<asp:Label ID="labBackPage" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
        </table>

                <asp:Button ID="Button3" runat="server" Text="Button" Width="275px" Style="display: none" />
               
                
            <asp:Button ID="btntargetControlOfmpeFirstDialogBox" runat="Server" Text="" Style="display: none;" />

            <asp:Panel ID="pnlFirstDialogBox" runat="server" BorderStyle="Solid" BorderWidth="1" Style="width: 700px; background-color: White; 
                display: none; height: 400px;">
                <asp:Panel ID="pnlFirstDialogBoxHeader" runat="server" Width="100%" BackColor="#006699"
                    HorizontalAlign="Right">
                    <asp:Button ID="btnCloseFirstDialogBox" runat="server" Text="关闭" />
                </asp:Panel>
                <asp:Panel ID="pnlFirstDialogBoxDetail" runat="server" Width="99%" HorizontalAlign="left">
                    <h1>
                        This is the first DialogBox</h1>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                         <table  border="1">
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

