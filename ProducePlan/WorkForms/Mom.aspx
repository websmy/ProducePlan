<%@ Page Title="生产车间排程" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Mom.aspx.cs" Inherits="WorkForms_Mom" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
　　        function openwin(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=1?" + Math.random();                              //转向网页的地址;
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
　　          function openwin20140610(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6, p7, SortSeq,soseq) {
              var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=" + p7 + "&SortSeq=" + SortSeq + "&soseq=" + soseq + "&p8=1?" + Math.random();                              //转向网页的地址;
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
　　        function openwin1(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6, p7, MoId, SortSeq, MoDId, p8, soseq,p9) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=" + p7 + "&MoId=" + MoId + "&SortSeq=" + SortSeq + "&MoDId=" + MoDId + "&p8=" + p8 +"&soseq=" + soseq + "&p9=" + p9 + "?" + Math.random();                              //转向网页的地址;
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
　　        function openwin2(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6, p7, MoId, SortSeq, MoDId, p8, soseq,p9) {
            if (window.confirm("有物料没领完是否入库？")) {

                var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=" + p7 + "&MoId=" + MoId + "&SortSeq=" + SortSeq + "&MoDId=" + MoDId + "&p8=" + p8 +"&soseq=" + soseq+ "&p9="  + "?" + Math.random();                              //转向网页的地址;
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
        &nbsp;<asp:Label ID="Label1" runat="server" Text="生产车间排程"></asp:Label>
    </h2>
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
                        逾期原因
                        <asp:DropDownList ID="DropDownList逾期原因" runat="server">
                          <asp:ListItem Selected="True">全部</asp:ListItem>
                                     <asp:ListItem>销售原因</asp:ListItem>        
                                     <asp:ListItem >供应商原因</asp:ListItem>
                                     <asp:ListItem>生产原因</asp:ListItem> 
                                     <asp:ListItem>设备原因</asp:ListItem> 
                                     <asp:ListItem>质量原因</asp:ListItem> 
                                     <asp:ListItem>技术原因</asp:ListItem> 
                          </asp:DropDownList>
                      
                          
                                                  制单日期 从<asp:TextBox ID="txtStartDate" runat="server" Width="100"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtStartDate" ForeColor="Red"></asp:CompareValidator>
                        &nbsp;到<asp:TextBox ID="txtEndDate" runat="server" Width="100"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtEndDate" ForeColor="Red"></asp:CompareValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server"  format="yyyy-MM-dd" TargetControlID="txtEndDate">
                        </ajaxToolkit:CalendarExtender>
                        
                        
                        
                        
                         开始日期<asp:TextBox ID="txtDate" runat="server" ControlToValidate="txtDate" 
                            Width="100px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtDate" ForeColor="Red"></asp:CompareValidator>
                       
                       <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                        
                           结束日期<asp:TextBox ID="txtDate1" runat="server" Width="100px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtDate1" ForeColor="Red"></asp:CompareValidator>
                            

                       <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="txtDate1"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>

                        
                        
                        

                        <asp:Button ID="btnFilter" runat="server" Text="过滤数据" OnClick="btnFilter_Click"   ValidationGroup="G1"/>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" 
                            NavigateUrl="~/WorkForms/Chart.aspx" Target="_blank">查看逾期原因图表</asp:HyperLink></td>
                            <Td>
                                <asp:Button ID="btnExcelExport" runat="server" onclick="btnExcelExport_Click" 
                                    Text="导出Excel" />
                    </Td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
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
                                <asp:HiddenField runat="server" Value='<%# Eval("soseq")%>' ID="soseq" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SortSeq")%>' ID="SortSeq" />
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("是否缺料")%>' ID="是否缺料" />--%>
                                <asp:HiddenField runat="server" Value='<%# Eval("cInvCCode")%>' ID="cInvCCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cInvCode")%>' ID="cInvCode" />
                                <asp:HiddenField runat="server" Value='<%# Eval("cinvdefine4")%>' ID="cinvdefine4" />
                                <asp:HiddenField runat="server" Value='<%# Eval("SoDId")%>' ID="SoDId" />
                                 <asp:HiddenField runat="server" Value='<%# Eval("ordercode")%>' ID="SoCode" />
                                
                                  <asp:HiddenField runat="server" Value='<%# Eval("qian")%>' ID="qian" />
                                   <asp:HiddenField runat="server" Value='<%# Eval("hou")%>' ID="hou" />
                                <%--<asp:HiddenField runat="server" Value='<%# Eval("iunitcost")%>' ID="iunitcost" />--%>
                            </ItemTemplate>
                            <FooterStyle CssClass="hidden1" />
                            <HeaderStyle CssClass="hidden1" />
                            <ItemStyle Width="0px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cCusName" HeaderText="客户名称" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">

                        </asp:BoundField>
                        <%--<asp:BoundField DataField="cinvdefine4" HeaderText="班组" />--%>
                        <asp:TemplateField HeaderText="班组">
                            <ItemTemplate>
                                
                                  <asp:DropDownList ID="DropDownList5" runat="server">
                                                </asp:DropDownList>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("cinvdefine4") %>'></asp:Label>

                               
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:BoundField DataField="ordercode" HeaderText="销售订单号" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="orderseq" HeaderText="销售订单行号" >
                   
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
                            <%-- <ItemStyle Width="20px" />--%>
                        
                        </asp:BoundField>
                        <asp:BoundField DataField="QualifiedInQty" HeaderText="入库数量" DataFormatString="{0:0.00}" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1" ControlStyle-CssClass="hidden1">
                            <%--<ItemStyle Width="20px" />--%>
                     
                        <ControlStyle CssClass="hidden1" />
                        <FooterStyle CssClass="hidden1" />
                        <HeaderStyle CssClass="hidden1" />
                        <ItemStyle CssClass="hidden1" />
                     
                        </asp:BoundField>
  
                        <%--<asp:BoundField DataField="Duedate" HeaderText="预计完工期" DataFormatString="{0:yyyy-M-d}" />--%>
                        <asp:TemplateField HeaderText="预计完工期">
                            <ItemTemplate>
                                                                                <asp:Label ID="label2" runat="server" Text='<%# Bind("Duedate","{0:yyyy-MM-dd}") %>'></asp:Label>
<%--
 <cc1:DateTextBox ID="dateTxtBox" Width="100" Text='<%# Bind("Duedate","{0:yyyy-MM-dd}") %>'
                                                    runat="server"></cc1:DateTextBox>--%>
                                                    
                                                    <asp:TextBox ID="dateTxtBox" runat="server" Text='<%# Bind("Duedate","{0:yyyy-MM-dd}") %>' Width="80px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="dateTxtBox" ForeColor="Red"></asp:CompareValidator>
                              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="dateTxtBox"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                               <%-- <asp:LoginView ID="LoginView2" runat="server">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="Manager">
                                            <ContentTemplate>
                                            </ContentTemplate>
                                        </asp:RoleGroup>
                                        <asp:RoleGroup Roles="Worker">
                                            <ContentTemplate>
                                               
                                            </ContentTemplate>
                                        </asp:RoleGroup>
                                    </RoleGroups>
                                </asp:LoginView>--%>
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="逾期原因">
                            <ItemTemplate>
                                
                                  <asp:Label ID="label1" runat="server" Text='<%# Bind("qian") %>'></asp:Label>

                                                            <%--<asp:Label ID="label1" runat="server" Text='<%# Eval("define25").GetType()==typeof(DBNull)?"":Eval("define25").ToString().Equals("")?"":Eval("define25").ToString().Split(',')[0]%> '></asp:Label>--%>

                                <asp:DropDownList ID="txt逾期原因" runat="server" Text='<%# Bind("qian") %> '>
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                     <asp:ListItem>销售原因</asp:ListItem>            
                                     <asp:ListItem >供应商原因</asp:ListItem>
                                     <asp:ListItem>生产原因</asp:ListItem> 
                                     <asp:ListItem>设备原因</asp:ListItem> 
                                     <asp:ListItem>质量原因</asp:ListItem> 
                                     <asp:ListItem>技术原因</asp:ListItem> 
                                </asp:DropDownList>

                              <%--  <asp:LoginView ID="LoginView3" runat="server">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="Manager">
                                            <ContentTemplate>
                                            </ContentTemplate>
                                        </asp:RoleGroup>
                                        <asp:RoleGroup Roles="Worker">
                                            <ContentTemplate>
                                            </ContentTemplate>
                                        </asp:RoleGroup>
                                    </RoleGroups>
                                </asp:LoginView>--%>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="逾期原因详细">
                            <ItemTemplate>
                                  <asp:Label ID="label逾期原因详细" runat="server" Text='<%# Bind("hou") %>'></asp:Label>
                                <asp:TextBox ID="txt逾期原因详细" runat="server"  Text='<%# Bind("hou") %>'></asp:TextBox>
                              </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否缺料">
                            <ItemTemplate>
                               
                               <asp:HyperLink ID="HyperLink1" runat="server" Text="无权限" />

                                <%--<asp:Literal ID="Literal1" runat="server" Text=""></asp:Literal>--%>
                                <%--<asp:Label runat="server" Text='<%# Eval("是否缺料")%>'></asp:Label>--%>
                                <%--<asp:Button ID="btnLack" runat="server" Text="是" CommandName="Lack" CommandArgument='' />--%>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否领料">
                            <ItemTemplate>
                                <%--<a href="javascript:showModalDialog('MomPop.aspx?id=<%# Eval("modid")%>',window,'dialogWidth:650px;status:no;dialogHeight:400px')">是</a>--%>
                                <%--<a href="#" onclick="openwin('<%# Eval("modid")%>',650,600,'<%# Eval("MDeptCode")%>','<%# Eval("InvCode")%>','<%# Eval("mocode")%>','<%# Eval("Qty")%>' )">
                                    领料 </a>--%>
                                <asp:HyperLink ID="HyperLink2" runat="server" Text="无权限" />
                                <%--<a href="javascript:window.open('MomPop.aspx?id=<%# Eval("modid")%>','newwindow','height=400, width=650, top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no')">是</a>--%>
                                <%-- <asp:Button ID="btnGetMaterial" runat="server" Text="是" CommandName="GetMaterial" OnClientClick="debugger "
                                    CommandArgument='<%# Eval("modid")%>' />--%>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否入库">
                            <ItemTemplate>
                                <%--<asp:Button ID="btnEntry" runat="server" Text="是" CommandName="Entry" CommandArgument='' />--%>
                                <asp:HyperLink ID="HyperLink3" runat="server" Text="无权限" />
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:Button ID="asp_btnUpdate" runat="server" Text="更新" CommandName="Modify" CommandArgument=''
                                    CssClass="btnOneLine" ValidationGroup="G1" />
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                    </Columns>
                    <%-- <PagerTemplate>
                        <div align="right">
                            第
                            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"
                                ForeColor="red"></asp:Label>
                            /
                            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                            页
                            <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                            转到第
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="30px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'
                                onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"
                                Style="text-align: right" MaxLength="12" />页
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                                CommandName="Page" Text="GO" />
                            共
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            条记录 每页显示
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:DropDownList>
                            条记录
                        </div>
                    </PagerTemplate>--%>
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
