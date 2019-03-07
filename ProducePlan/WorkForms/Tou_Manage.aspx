<%@ Page Title="投标管理页面" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Tou_Manage.aspx.cs" Inherits="WorkForms_Tou_Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>

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
    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px"
        CellPadding="3" OnPageIndexChanging="GridView3_PageIndexChanging" OnPreRender="GridView3_PreRender"
        OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowCommand="GridView3_RowCommand"
        OnRowDataBound="GridView3_RowDataBound" OnRowDeleting="GridView3_RowDeleting"
        OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" ShowFooter="True"
        Width="100%" onrowcreated="GridView3_RowCreated">
        <AlternatingRowStyle BackColor="#F2F2F2" />
        <Columns>

                 <asp:TemplateField HeaderText="cannotsee" FooterStyle-CssClass="hidden1" HeaderStyle-CssClass="hidden1"
                            ItemStyle-CssClass="hidden1">                                            
                              <ItemTemplate>
                                <asp:HiddenField ID="autoid" runat="server" Value='<%# Eval("autoid") %>'></asp:HiddenField>
                             </ItemTemplate>

<FooterStyle CssClass="hidden1"></FooterStyle>

<HeaderStyle CssClass="hidden1"></HeaderStyle>

<ItemStyle CssClass="hidden1"></ItemStyle>
                         </asp:TemplateField>

            <asp:TemplateField HeaderText="年度">
                <ItemTemplate>
                    <asp:Label ID="label年度" runat="server" Text='<%# Eval("年度").GetType()==typeof(DBNull)?"":Eval("年度").ToString()%> '></asp:Label>
                      <asp:Label ID="Label22" runat="server" Text="年度"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" Text='<%# Eval("年度") %>'>                                            
                    </asp:DropDownList>
                     <asp:Label ID="Label23" runat="server" Text="年度"></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                     <asp:Label ID="Label24" runat="server" Text="年度"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            
                 <asp:TemplateField HeaderText="季度">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="第"></asp:Label>
                    <asp:Label ID="label季度" runat="server" Text='<%# Eval("季度").GetType()==typeof(DBNull)?"":Eval("季度").ToString()%> '></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="季度"></asp:Label>

                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="第"></asp:Label>
                    
                    <asp:DropDownList ID="DropDownList2" runat="server" Text=' <%# Eval("季度") %>'>
                    </asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" Text="季度"></asp:Label>

                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="Label1" runat="server" Text="第"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                      <asp:Label ID="Label2" runat="server" Text="季度"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>

            

            <asp:TemplateField HeaderText="铝板 元">
                <ItemTemplate>
                    <asp:Label ID="label废铁处理基价" runat="server" Text='<%# Eval("废铁处理基价").GetType()==typeof(DBNull)?"":Eval("废铁处理基价").ToString()%> '></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt废铁处理基价" runat="server" Text='<%#Eval("废铁处理基价")%>' ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt废铁处理基价F" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            
                <asp:TemplateField HeaderText="碳钢 元">
                <ItemTemplate>
                    <asp:Label ID="label铝型材处理基价" runat="server" Text='<%# Eval("铝型材处理基价").GetType()==typeof(DBNull)?"":Eval("铝型材处理基价").ToString()%> '></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt铝型材处理基价" runat="server" Text='<%#Eval("铝型材处理基价")%>' ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt铝型材处理基价F" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            
                <asp:TemplateField HeaderText="不锈钢 元">
                <ItemTemplate>
                    <asp:Label ID="label不锈钢处理基价" runat="server" Text='<%# Eval("不锈钢处理基价").GetType()==typeof(DBNull)?"":Eval("不锈钢处理基价").ToString()%> '></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt不锈钢处理基价" runat="server" Text='<%#Eval("不锈钢处理基价")%>' ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txt不锈钢处理基价F" runat="server" ></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="是否使用此价格">
                <ItemTemplate>
                    <asp:Label ID="label是否在投标中" runat="server"   
                        Text='<%# Eval("是否在投标中").ToString()=="1"?"是":"否"%>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<asp:TextBox ID="txt截止时间" runat="server" Text='<%# Bind("截止时间","{0:yyyy-MM-dd}") %>' ></asp:TextBox>--%>
                    
                    <asp:DropDownList ID="DropDownList3" runat="server" 
                        Text=' <%# Eval("是否在投标中") %>'>
                    </asp:DropDownList>

                </EditItemTemplate>
                <FooterTemplate>
<%--                    <asp:TextBox ID="txt截止时间F" runat="server" ></asp:TextBox>
                      <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txt截止时间F"  format="yyyy-MM-dd hh:mm" 
                            runat="server">
                       </ajaxToolkit:CalendarExtender>--%>
                   
                </FooterTemplate>
            </asp:TemplateField>
            

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" CommandName="Update"
                        Text="更新" ValidationGroup="G3"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="Server" CommandName="Add" Text="添加" UseSubmitBehavior="False"
                        ValidationGroup="G4" />
                </FooterTemplate>
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
            <asp:TextBox ID="txtNewPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>"
                Width="20px" />
            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                CommandName="Page" Text="GO" />
            &nbsp;&nbsp; 当前页码为：
            <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
            &nbsp; 总页码为：
            <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
        </PagerTemplate>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
</asp:Content>
