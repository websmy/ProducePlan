<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_MomPop, App_Web_ygebp2ua" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.11119.27145, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>领料表</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <script language="JavaScript">
　　        function openwin1(name, winname, id, iWidth, iHeight, p1, p2, p3, p4) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4;                              //转向网页的地址;
            //              var name;                           //网页名称，可为空;
            //              var iWidth = 650;                          //弹出窗口的宽度;
            //              var iHeight = 400;                        //弹出窗口的高度;
            var iTop = window.screen.availHeight - 30;       //获得窗口的垂直位置;
            var iLeft = window.screen.availWidth - 10;           //获得窗口的水平位置;


            //              window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
            var b = window.open(url, winname, "height=" + iTop + ", width=" + iLeft + ", top=" + 0 + ",left=" + 0 + ",toolbar=no, menubar=yes, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes");  //写成一行


            b.focus();
            return null;
            //　　              window.location = url;

        } 
    </script>
    <script language="JavaScript">
　　        function openwin(name, winname, id, iWidth, iHeight, p1, p2, p3, p4) {
            var url = name + "?id=" + id + "&p1=" + p1 + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4;                              //转向网页的地址;
            //              var name;                           //网页名称，可为空;
            //              var iWidth = 650;                          //弹出窗口的宽度;
            //              var iHeight = 400;                        //弹出窗口的高度;
            var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
            var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;


            //              window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
            var b = window.open(url, winname, "height=" + iHeight + ", width=" + iWidth + ", top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes");  //写成一行


            b.focus();
            return null;
            //　　              window.location = url;

        } 
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <h3 align="center" style="color: #FFFFFF; background-color: #006699;">
                    领料表</h3>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <asp:HiddenField ID="HiddenField4" runat="server" />
                <asp:HiddenField ID="HiddenField5ccode" runat="server" />
                <asp:HiddenField ID="MoId" runat="server" />
                <asp:HiddenField ID="h生产班组" runat="server" />
                <table border="1" cellpadding="0" cellspacing="0" class="style1" frame="Border" bgcolor="White">
                    <tr>
                        <td align="center">
                            表头信息:
                        </td>
                        <td align="center">
                            出库类别<asp:DropDownList ID="DropDownList2" runat="server" CausesValidation="True" ValidationGroup="G1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 必选"
                                ControlToValidate="DropDownList2" InitialValue="-1" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                            &nbsp;班组名称<asp:DropDownList ID="DropDownList4" runat="server" CausesValidation="True"
                                ValidationGroup="G1">
                               <%-- <asp:ListItem Value="-1">请选择</asp:ListItem>--%>
                                <%-- <asp:ListItem Value="一车间成型班">一车间成型班</asp:ListItem>
                            <asp:ListItem Value="一车间附件班">一车间附件班</asp:ListItem>
                            <asp:ListItem Value="一车间焊接班">一车间焊接班</asp:ListItem>
                            <asp:ListItem>一车间喷漆班</asp:ListItem>
                            <asp:ListItem>一车间下料班</asp:ListItem>
                            <asp:ListItem Value="一车间小叶轮班">一车间小叶轮班</asp:ListItem>
                            <asp:ListItem Value="一车间装配班">一车间装配班</asp:ListItem>
                            <asp:ListItem Value="二车间大叶轮班">二车间大叶轮班</asp:ListItem>
                            <asp:ListItem>二车间机加工班</asp:ListItem>
                            <asp:ListItem>二车间喷漆班</asp:ListItem>
                            <asp:ListItem>二车间网罩班</asp:ListItem>
                            <asp:ListItem>机车成型班</asp:ListItem>
                            <asp:ListItem>机车机壳班</asp:ListItem>
                            <asp:ListItem>机车铝焊班</asp:ListItem>
                            <asp:ListItem>机车喷漆班</asp:ListItem>
                            <asp:ListItem>机车下料班</asp:ListItem>
                            <asp:ListItem>机车叶轮班</asp:ListItem>
                            <asp:ListItem>机车装配班</asp:ListItem>
                             <asp:ListItem>能源冶金GE班</asp:ListItem>
                            <asp:ListItem>能源冶金机加工班</asp:ListItem>
                            <asp:ListItem>能源冶金维修班</asp:ListItem>

                            <asp:ListItem>大叶轮包装班</asp:ListItem>
                            <asp:ListItem>能源冶金维修班</asp:ListItem>
                            <asp:ListItem>能源冶金维修班</asp:ListItem>
                            <asp:ListItem>能源冶金维修班</asp:ListItem>--%>
                         <%--       <asp:ListItem> 玻璃钢拉挤班                 </asp:ListItem>
                                <asp:ListItem>大叶轮包装班                  </asp:ListItem>
                                <asp:ListItem>大叶轮车间网罩班            </asp:ListItem>
                                <asp:ListItem>大叶轮机加工班               </asp:ListItem>
                                <asp:ListItem>大叶轮下料班                  </asp:ListItem>
                                <asp:ListItem>大叶轮组装班                  </asp:ListItem>
                                <asp:ListItem>机车成型班                     </asp:ListItem>
                                <asp:ListItem>机车机壳班                     </asp:ListItem>
                                <asp:ListItem>机车铝焊班                     </asp:ListItem>
                                <asp:ListItem>机车喷漆班                     </asp:ListItem>
                                <asp:ListItem>机车下料班                     </asp:ListItem>
                                <asp:ListItem>机车叶轮班                     </asp:ListItem>
                                <asp:ListItem>机车装配班                     </asp:ListItem>
                                <asp:ListItem>机电维修班                     </asp:ListItem>
                                <asp:ListItem>能源冶金GE班                 </asp:ListItem>
                                <asp:ListItem>能源冶金加工班               </asp:ListItem>
                                <asp:ListItem>能源冶金维修班               </asp:ListItem>
                                <asp:ListItem>一车间成型班                  </asp:ListItem>
                                <asp:ListItem>一车间附件班                  </asp:ListItem>
                                <asp:ListItem>一车间焊接班                  </asp:ListItem>
                                <asp:ListItem>一车间喷漆班                  </asp:ListItem>
                                <asp:ListItem>一车间下料班                  </asp:ListItem>
                                <asp:ListItem>一车间小叶轮班               </asp:ListItem>
                                <asp:ListItem>一车间装配班                  </asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 必选"
                                ControlToValidate="DropDownList4" InitialValue="请选择" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                            出库日期<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="请输入正确日期格式!"
                                Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="G1" ControlToValidate="txtDate"
                                ForeColor="Red"></asp:CompareValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" Format="yyyy-MM-dd"
                                runat="server">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
                <%-- <asp:HiddenField ID="SoDId" runat="server" />--%>
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderWidth="1px" Width="100%" CellPadding="3" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"
                    OnDataBound="GridView2_DataBound" OnRowCommand="GridView2_RowCommand">
                    <AlternatingRowStyle BackColor="#F2F2F2" />
                    <Columns>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="whcode" HeaderText="仓库" />--%>
                        <asp:TemplateField HeaderText="仓库">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="cInvCCode" Value='<%# Bind("cInvCCode")%>' />
                                <asp:HiddenField runat="server" ID="whcode" Value='<%# Bind("whcode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="invcode" HeaderText="材料编码" />
                        <asp:BoundField DataField="cinvname" HeaderText="材料名称" />
                        <asp:BoundField DataField="qty" HeaderText="数量" DataFormatString="{0:0.00}"></asp:BoundField>
                        <asp:BoundField DataField="issqty" HeaderText="已领数量" DataFormatString="{0:0.00}" />
                        <asp:BoundField DataField="xiancun" HeaderText="现存量" DataFormatString="{0:0.00}" />
                        <asp:BoundField DataField="xiancun1" HeaderText="现存量(不区分仓库)" DataFormatString="{0:0.00}" />
                        <asp:TemplateField HeaderText="本次领料数">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("yaoling","{0:0.00}") %>'
                                    CausesValidation="True"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="只能输入数字"
                                    ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="G1" ControlToValidate="TextBox1"></asp:CompareValidator>
                                <asp:TextBox ID="xiancunHidden" Width="0" Height="0" BorderStyle="None" BorderColor="White"
                                    runat="server" Text='<%# Bind("xiancun") %>' CausesValidation="False" BackColor="White" />
                                <asp:CompareValidator ID="valid1" runat="server" ControlToValidate="TextBox1" ControlToCompare="xiancunHidden"
                                    Type="Double" Operator="LessThanEqual" Display="dynamic" SetFocusOnError="True"
                                    ErrorMessage="本次领料数大于现存量" ValidationGroup="G1" ForeColor="Red"></asp:CompareValidator>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden1" Text="0"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox1"
                                    ControlToCompare="TextBox2" Type="Double" Operator="GreaterThanEqual" Display="dynamic"
                                    SetFocusOnError="True" ErrorMessage="不能为负值" ValidationGroup="G1" ForeColor="Red"></asp:CompareValidator>
                                <asp:TextBox ID="yaolingHidden" Width="0" Height="0" BorderStyle="None" BorderColor="White"
                                    runat="server" Text='<%# Bind("yaoling","{0:0.00}") %>' CausesValidation="True"
                                    BackColor="White" />
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox1"
                                    ControlToCompare="yaolingHidden" Type="Double" Operator="LessThanEqual" Display="Dynamic"
                                    SetFocusOnError="True" ErrorMessage="大于所需的数量" ValidationGroup="G2" ForeColor="Red"></asp:CompareValidator>
                                <asp:HiddenField ID="AllocateId" runat="server" Value='<%# Bind("AllocateId")%> ' />
                                <asp:HiddenField ID="MoDId" runat="server" Value='<%# Bind("MoDId")%>' />
                                <asp:HiddenField ID="SortSeq" runat="server" Value='<%# Bind("SortSeq")%>' />
                                <asp:HiddenField ID="moid" runat="server" Value='<%# Bind("moid")%>' />
                                <asp:HiddenField ID="AutoID" runat="server" Value='<%# Bind("AutoID")%>' />
                                <asp:HiddenField ID="cInvCode" runat="server" Value='<%# Bind("invcode")%>' />
                                <asp:HiddenField ID="SoDId" runat="server" Value='<%# Bind("SoDId")%>' />
                                <asp:HiddenField ID="iSoType" runat="server" Value='<%# Bind("iSoType")%>' />
                            </ItemTemplate>
                            <%--
                                          <EditItemTemplate>
                                        <asp:TextBox ID="TBPrice" Text='<%# Eval("price") %>' runat="server" Width="90px" />
                                    </EditItemTemplate>--%>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:TextBox ID="cdefine28" runat="server"></asp:TextBox>
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
                <div align="center" style="background-color: #006699">
                    <table class="style1" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:HyperLink ID="btnAdd" runat="server" Text="添加材料" NavigateUrl="javascript:void(0)"
                                    Font-Size="Large" ForeColor="White" />
                            </td>
                            <td>
                                <asp:Button ID="btnDel" runat="server" Text="删除所选项" OnClick="btnDel_Click" Height="28px"
                                    Width="113px" />
                            </td>
                            <td>
                                <asp:Button ID="btnLinLiao" runat="server" Height="28px" OnClick="btnLinLiao_Click"
                                    Text="领料" Width="113px" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Height="28px" Text="打印" Width="113px" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
