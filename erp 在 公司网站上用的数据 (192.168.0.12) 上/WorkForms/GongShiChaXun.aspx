<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_GongShiChaXun, App_Web_2h3v2kfy" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>管理</title>
    
    <script language="JavaScript">
　　        function openwin20140610(name, winname, id, iWidth, iHeight, p1, p2, p3, p4, p5, p6, p7) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 + "&p7=" + p7 + "&p8=1?" + Math.random();                              //转向网页的地址;
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
    <form id="form1" runat="server" >
        
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div>
        <h3 align="center" style="color: #FFFFFF; background-color: #006699;">
            工时查询</h3>
    </div>
    <div>
        <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" width="100%"
            bgcolor="White" style="font-size: xx-large">
            <tr>
                <td align="center">
                    过滤数据:
                </td>
                <td align="center">
                    工人编码：<asp:TextBox 
                        ID="TextBox1" runat="server" Width="72px" AutoPostBack="True" 
                        OnTextChanged="TextBox1_TextChanged" Font-Size="XX-Large"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    生产订单号：<asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" 
                        ontextchanged="TextBox2_TextChanged" Font-Size="XX-Large"></asp:TextBox>
                    行号：<asp:TextBox ID="TextBox3" runat="server" Width="79px" AutoPostBack="True" 
                        Font-Size="XX-Large"></asp:TextBox>
                        
                        日期 从<asp:TextBox ID="txtStartDate" runat="server" Font-Size="XX-Large" 
                        Width="213px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtStartDate" ForeColor="Red"></asp:CompareValidator>
                        &nbsp;到<asp:TextBox ID="txtEndDate" runat="server" Font-Size="XX-Large" 
                        Width="217px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" 
                            ValidationGroup="G1" ControlToValidate="txtEndDate" ForeColor="Red"></asp:CompareValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate"  format="yyyy-MM-dd" 
                            runat="server">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server"  format="yyyy-MM-dd" TargetControlID="txtEndDate">
                        </ajaxToolkit:CalendarExtender>
 

                    <asp:Button ID="btnFilter" runat="server" Text="查询" OnClick="btnFilter_Click" 
                        Font-Size="XX-Large" />
                </td>
                <td>
                    &nbsp; 总工时
                 
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                       
                        <asp:Button ID="Button111" runat="server" onclick="Button111_Click" 
                            Text="导到Excel" ValidationGroup="G1" style="height: 21px" />
                       
                    <br />
                       
                        <asp:Button ID="Button112" runat="server" onclick="Button112_Click" 
                            Text="生成报表" />
                       
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False"
            OnPreRender="GridView3_PreRender" OnRowCancelingEdit="GridView3_RowCancelingEdit"
            OnRowCommand="GridView3_RowCommand" OnRowDeleting="GridView3_RowDeleting" OnRowEditing="GridView3_RowEditing"
            OnRowUpdating="GridView3_RowUpdating" OnRowDataBound="GridView3_RowDataBound"
            AllowPaging="True" AllowSorting="True" 
            OnPageIndexChanging="GridView3_PageIndexChanging" PageSize="15" 
            Font-Size="X-Large">
            <AlternatingRowStyle BackColor="#F2F2F2" />
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="autoid" runat="server" Text='<%#Bind("autoid")%>'></asp:Label>
                        <asp:Label ID="工序autoid" runat="server" Text='<%#Bind("工序autoid")%>'></asp:Label>
                            <asp:HiddenField ID="h数量" runat="server" Value='<%#Bind("数量")%>'></asp:HiddenField>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="工人编码">
                    <ItemTemplate>
                        <asp:Label ID="label工人编码" runat="server" Text='<%# Eval("工人编码").GetType()==typeof(DBNull)?"":Eval("工人编码").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:Label ID="label工人编码" runat="server" Text='<%# Eval("工人编码").GetType()==typeof(DBNull)?"":Eval("工人编码").ToString()%> '></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="工人姓名">
                    <ItemTemplate>
                        <asp:Label ID="label工人姓名" runat="server" Text='<%# Eval("工人姓名").GetType()==typeof(DBNull)?"":Eval("工人姓名").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:Label ID="label工人姓名" runat="server" Text='<%# Eval("工人姓名").GetType()==typeof(DBNull)?"":Eval("工人姓名").ToString()%> '></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生产订单号">
                    <ItemTemplate>
                        <asp:Label ID="label生产订单号" runat="server" Text='<%# Eval("生产订单号").GetType()==typeof(DBNull)?"":Eval("生产订单号").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                           <asp:Label ID="label生产订单号" runat="server" Text='<%# Eval("生产订单号").GetType()==typeof(DBNull)?"":Eval("生产订单号").ToString()%> '></asp:Label>
                  </EditItemTemplate>
                </asp:TemplateField>
            
              <asp:TemplateField HeaderText="行号">
                    <ItemTemplate>
                        <asp:Label ID="label行号" runat="server" Text='<%# Eval("行号").GetType()==typeof(DBNull)?"":Eval("行号").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:Label ID="label行号" runat="server" Text='<%# Eval("行号").GetType()==typeof(DBNull)?"":Eval("行号").ToString()%> '></asp:Label>
                    </EditItemTemplate>
                  
                </asp:TemplateField>
                
                
                  <asp:TemplateField HeaderText="产品编码">
                    <ItemTemplate>
                        <asp:Label ID="label产品编码" runat="server" Text='<%# Eval("产品编码").GetType()==typeof(DBNull)?"":Eval("产品编码").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                          <asp:Label ID="label产品编码" runat="server" Text='<%# Eval("产品编码").GetType()==typeof(DBNull)?"":Eval("产品编码").ToString()%> '></asp:Label>
                    </EditItemTemplate>
                  
                </asp:TemplateField>

                <asp:TemplateField HeaderText="工序">
                    <ItemTemplate>
                        <asp:Label ID="label工序" runat="server" Text='<%# Eval("工序").GetType()==typeof(DBNull)?"":Eval("工序").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        
                          <asp:DropDownList ID="ddl工序" runat="server"  Font-Size="XX-Large">
                        </asp:DropDownList>
                     
                </EditItemTemplate>
                  
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <asp:Label ID="label数量" runat="server" Text='<%# Eval("数量").GetType()==typeof(DBNull)?"":Eval("数量").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt数量" runat="server" Text='<%#Eval("数量")%>' Width="50" Font-Size="XX-Large"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* 必添"
                            ControlToValidate="txt数量" InitialValue="" ForeColor="Red" ValidationGroup="G3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
              
                </asp:TemplateField>
                

                <asp:TemplateField HeaderText="工时">
                    <ItemTemplate>
                        <asp:Label ID="label工时" runat="server" Text='<%# Eval("工时").GetType()==typeof(DBNull)?"":Eval("工时").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:Label ID="label工时" runat="server" Text='<%# Eval("工时").GetType()==typeof(DBNull)?"":Eval("工时").ToString()%> '></asp:Label>
                    </EditItemTemplate>
              
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="总工时">
                    <ItemTemplate>
                        <asp:Label ID="label总工时" runat="server" Text='<%# Eval("总工时").GetType()==typeof(DBNull)?"":Eval("总工时").ToString()%> '></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:Label ID="label总工时" runat="server" Text='<%# Eval("总工时").GetType()==typeof(DBNull)?"":Eval("总工时").ToString()%> '></asp:Label>
                    </EditItemTemplate>
                 
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="录入日期">
                    <ItemTemplate>
                        <asp:Label ID="label录入日期" runat="server" Text='<%# Eval("录入日期").GetType()==typeof(DBNull)?"":Eval("录入日期").ToString()%> '  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="车间名称">
                    <ItemTemplate>
                        <asp:Label ID="label车间名称" runat="server" Text='<%# Eval("车间名称").GetType()==typeof(DBNull)?"":Eval("车间名称").ToString()%> ' ></asp:Label>
                    </ItemTemplate>
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
                   
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                没有数据
            </EmptyDataTemplate>
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
                &nbsp&nbsp 当前页码为：
                <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                &nbsp 总页码为：
                <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
            </PagerTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" Font-Size="XX-Large" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
