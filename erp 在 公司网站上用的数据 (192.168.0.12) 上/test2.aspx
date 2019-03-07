<%@ page language="C#" autoeventwireup="true" inherits="test2, App_Web_hx4jwvo4" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:GridView ID="GV_Title" runat="server" Width="100%"
     CellPadding="3" PageSize="20" Style="text-align: center" BorderColor="#e1e1e1"
     ShowFooter="true" OnRowCommand="GV_Title_RowCommand" OnRowEditing="GV_Title_RowEditing"
     OnRowUpdating="GV_Title_RowUpdating" OnRowCancelingEdit="GV_Title_RowCancelingEdit">
         <HeaderStyle CssClass="listTableTitle" />
             <Columns>
                 <asp:TemplateField Visible="false">
                    <ItemTemplate>
                          <%--<asp:Label ID="laID" runat="server" Text='<%# eval_r("ID") %>'></asp:Label>--%>
                    </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="考核条目名称" HeaderStyle-Width="70%">
                       <ItemTemplate>
                           <%--<asp:Label ID="MC" runat="server" Text='<%# eval_r("TitleName") %>'></asp:Label>--%>
                       </ItemTemplate>
                       <EditItemTemplate>
                             <%--<asp:TextBox ID="Text_TitleNameE" runat="server" Text='<%# eval_r("TitleName") %>' class="editTextLine"  Width="250px"></asp:TextBox>--%>
                       </EditItemTemplate>
                       <FooterTemplate>
                              <asp:TextBox ID="Text_TitleNameA" runat="server" class="editTextLine"  Width="250px"></asp:TextBox>
                       </FooterTemplate>
                       </asp:TemplateField>                         
                        <asp:TemplateField HeaderText="操作">
                                <%--<ItemTemplate>
                                    <asp:Button ID="But_Edit" runat="server" Text="编辑" CausesValidation="False" Width="40px" Height="21px" class="editButton" CommandName="Edit" CommandArgument='<%#eval_r("ID") %>' />
                                    <asp:Button ID="But_Del" runat="server" Text="删除" CausesValidation="False" Width="40px"  Height="21px" class="editButton" CommandName="Del" CommandArgument='<%#eval_r("ID") %>' OnClientClick="return confirm('确认删除？')" />
                                </ItemTemplate>--%>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LB_Edit" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LB_QX" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Add" ImageUrl="~/Images/add.jpg" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table width="100%">
                                <tr class="listTableTitle">
                                    <td width="95%" style="font-weight: bold;" align="center">
                                        考核条目名称
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #FF0000;">无符合条件的纪录！</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Text_TitleNameAdd" runat="server" class="editTextLine"  Width="250px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImgAdd" CommandName="Add" runat="server" ImageUrl="~/Images/add.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
      <asp:DataList ID="DataList1" runat="server">
      </asp:DataList>
      <asp:Chart ID="Chart1" runat="server" AlternateText="22" BackColor="DarkRed" 
          BackGradientStyle="DiagonalLeft" BackHatchStyle="DarkHorizontal" 
          BorderlineColor="DarkRed" BorderlineDashStyle="Dot" BorderlineWidth="30" 
          Palette="Berry" Width="625px">
          <Series>
              <asp:Series Color="DarkMagenta" Legend="Legend1" Name="Series1">
                  <Points>
                      <asp:DataPoint XValue="1" YValues="2" />
                      <asp:DataPoint XValue="2" YValues="2" />
                  </Points>
              </asp:Series>
          </Series>
          <ChartAreas>
              <asp:ChartArea BackColor="192, 192, 0" BackSecondaryColor="Olive" 
                  BorderColor="Fuchsia" BorderDashStyle="DashDot" BorderWidth="10" 
                  Name="ChartArea1">
              </asp:ChartArea>
          </ChartAreas>
          <Legends>
              <asp:Legend Name="Legend1">
              </asp:Legend>
          </Legends>
          <Annotations>
              <asp:LineAnnotation Name="LineAnnotation1">
              </asp:LineAnnotation>
          </Annotations>
          <BorderSkin BackColor="DarkRed" BackGradientStyle="Center" 
              BackHatchStyle="BackwardDiagonal" BorderDashStyle="Dot" BorderWidth="13" 
              PageColor="Maroon" SkinStyle="FrameTitle5" />
      </asp:Chart>
    </form>
</body>
</html>
