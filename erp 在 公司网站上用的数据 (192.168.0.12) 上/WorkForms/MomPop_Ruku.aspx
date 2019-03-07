<%@ page language="C#" autoeventwireup="true" inherits="WorkForms_MomPop, App_Web_sqons5qh" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>入库表</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div>
        <h3 align="center" style="color: #FFFFFF; background-color: #006699;">
            销售订单号&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            入库</h3>
        <asp:HiddenField ID="ID" runat="server" />
        <asp:HiddenField ID="部门" runat="server" />
        <asp:HiddenField ID="班组" runat="server" />
        <asp:HiddenField ID="销售订单号" runat="server" />
        <asp:HiddenField ID="生产订单号" runat="server" />
        <asp:HiddenField ID="产品编码" runat="server" />
        <asp:HiddenField ID="sodid" runat="server" />
        <asp:HiddenField ID="订单数量" runat="server" />
        <asp:HiddenField ID="MoId" runat="server" />
        <asp:HiddenField ID="MoDId" runat="server" />
        <%--<asp:HiddenField ID="入库数量" runat="server" />--%>
        <asp:HiddenField ID="SortSeq" runat="server" />

        <div>
            <table class="style1">
                <tr>
                    <td align="right" class="style2">
                        班组：
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownList3" runat="server" CausesValidation="True" ValidationGroup="G1">
                            <%--<asp:ListItem Value="-1">请选择</asp:ListItem>--%>
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
                            <asp:ListItem>能源冶金维修班</asp:ListItem>--%>
                          <%--    <asp:ListItem> 玻璃钢拉挤班                 </asp:ListItem>
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
                                <asp:ListItem>一车间装配班                  </asp:ListItem>        --%>                   
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* 必选"
                            ControlToValidate="DropDownList3" InitialValue="请选择" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        仓库：
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="True" ValidationGroup="G1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* 必选"
                            ControlToValidate="DropDownList1" InitialValue="-1" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style2">
                        入库类别：
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="DropDownList2" runat="server" CausesValidation="True" ValidationGroup="G1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* 必选"
                            ControlToValidate="DropDownList2" InitialValue="-1" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        数量：
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True" ValidationGroup="G1"
                            Width="68px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* 必须输入值"
                            ControlToValidate="TextBox1" ForeColor="Red" ValidationGroup="G1"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="只能输入数字"
                            ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="G1" ControlToValidate="TextBox1"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox1"
                            ControlToCompare="订单数量Hidden" Type="Double" Operator="LessThanEqual" Display="dynamic"
                            SetFocusOnError="True" ErrorMessage="大于订单数量" ValidationGroup="G1" ForeColor="Red"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox1"
                            ControlToCompare="订单数量Hidden1" Type="Double" Operator="NotEqual" Display="dynamic"
                            SetFocusOnError="True" ErrorMessage="数量为0" ValidationGroup="G1" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        入库日期：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="请输入正确日期格式!"
                            Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="G1" ControlToValidate="TextBox2"
                            ForeColor="Red"></asp:CompareValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="TextBox2" runat="server"  format="yyyy-MM-dd" >
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="订单数量Hidden" Width="0" Height="0" BorderStyle="None" BorderColor=""
                            runat="server" CausesValidation="True" BackColor="" />
                        <asp:TextBox ID="订单数量Hidden1" Width="0" Height="0" BorderStyle="None" BorderColor=""
                            Text="0" runat="server" CausesValidation="True" BackColor="" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div align="center" style="background-color: #006699">
            <asp:Button ID="Button1" runat="server" Text="入库" Height="29px" Width="101px" ValidationGroup="G1"
                OnClick="Button1_Click" />
        </div>
    </div>
    </form>
</body>
</html>
