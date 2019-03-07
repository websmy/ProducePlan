<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="价格查询.aspx.cs" Inherits="WorkForms_价格查询" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style11
        {
        }
        .style20
        {
            width: 726px;
        }
        .style23
        {
            width: 65px;
        }
        .style27
        {
            width: 185px;
        }
        .style29
        {
            width: 157px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%">
                <ajaxToolkit:TabPanel runat="server" HeaderText="船用风机" ID="TabPanel1">
                    <ContentTemplate>
                        <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="2" 
                            Width="100%">
                            <ajaxToolkit:TabPanel ID="TabPanel1_1" runat="server" HeaderText="CBL">
                                <ContentTemplate>
                                  <table class="style4" border="1" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td bgcolor="#CCCCCC" class="style23" style="width: 80px">
                                                &nbsp;
                                            </td>
                                            <td class="style29" align="right">
                                                风机型号
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList11" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged" Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style20" style="width: 200px">
                                             
                                              
                                             
                                                </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="10" bgcolor="#CCCCCC" class="style23">
                                                电机
                                            </td>
                                            <td class="style29" align="right">
                                                电机型号
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True">801        </asp:ListItem>
                                                    <asp:ListItem>802        </asp:ListItem>
                                                    <asp:ListItem>90S        </asp:ListItem>
                                                    <asp:ListItem>90L        </asp:ListItem>
                                                    <asp:ListItem>100L      </asp:ListItem>
                                                    <asp:ListItem>112M     </asp:ListItem>
                                                    <asp:ListItem>132S1    </asp:ListItem>
                                                    <asp:ListItem>132S2    </asp:ListItem>
                                                    <asp:ListItem>160M1   </asp:ListItem>
                                                    <asp:ListItem>160M2   </asp:ListItem>
                                                    <asp:ListItem>160L      </asp:ListItem>
                                                    <asp:ListItem>180M     </asp:ListItem>
                                                    <asp:ListItem>200L1     </asp:ListItem>
                                                    <asp:ListItem>200L2     </asp:ListItem>
                                                    <asp:ListItem>225M     </asp:ListItem>
                                                    <asp:ListItem>250M     </asp:ListItem>
                                                    <asp:ListItem>280S      </asp:ListItem>
                                                    <asp:ListItem>280M     </asp:ListItem>
                                                    <asp:ListItem>315S      </asp:ListItem>
                                                    <asp:ListItem>315M     </asp:ListItem>
                                                    <asp:ListItem>315L1     </asp:ListItem>
                                                    <asp:ListItem>315L2     </asp:ListItem>
                                                    <asp:ListItem>355M1   </asp:ListItem>
                                                    <asp:ListItem>355M2   </asp:ListItem>
                                                    <asp:ListItem>355L1     </asp:ListItem>
                                                    <asp:ListItem>355L2     </asp:ListItem>
                                                    <asp:ListItem>100L1     </asp:ListItem>
                                                    <asp:ListItem>100L2     </asp:ListItem>
                                                    <asp:ListItem>132S      </asp:ListItem>
                                                    <asp:ListItem>132M     </asp:ListItem>
                                                    <asp:ListItem>160M     </asp:ListItem>
                                                    <asp:ListItem>180L      </asp:ListItem>
                                                    <asp:ListItem>200L      </asp:ListItem>
                                                    <asp:ListItem>225S      </asp:ListItem>
                                                    <asp:ListItem>132M1   </asp:ListItem>
                                                    <asp:ListItem>132M2   </asp:ListItem>
                                                    <asp:ListItem>355M3   </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="10" class="style20">
                                                价格：<asp:Label ID="电机价格" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="电机价格1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                级数
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True">2</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                功率
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 0.55</asp:ListItem>
                                                    <asp:ListItem>0.75 </asp:ListItem>
                                                    <asp:ListItem>1.1   </asp:ListItem>
                                                    <asp:ListItem>1.5   </asp:ListItem>
                                                    <asp:ListItem>2.2   </asp:ListItem>
                                                    <asp:ListItem>3     </asp:ListItem>
                                                    <asp:ListItem>4     </asp:ListItem>
                                                    <asp:ListItem>5.5   </asp:ListItem>
                                                    <asp:ListItem>7.5   </asp:ListItem>
                                                    <asp:ListItem>11    </asp:ListItem>
                                                    <asp:ListItem>15    </asp:ListItem>
                                                    <asp:ListItem>18.5 </asp:ListItem>
                                                    <asp:ListItem>22    </asp:ListItem>
                                                    <asp:ListItem>30    </asp:ListItem>
                                                    <asp:ListItem>37    </asp:ListItem>
                                                    <asp:ListItem>45    </asp:ListItem>
                                                    <asp:ListItem>55    </asp:ListItem>
                                                    <asp:ListItem>75    </asp:ListItem>
                                                    <asp:ListItem>90    </asp:ListItem>
                                                    <asp:ListItem>110  </asp:ListItem>
                                                    <asp:ListItem>132  </asp:ListItem>
                                                    <asp:ListItem>160  </asp:ListItem>
                                                    <asp:ListItem>185  </asp:ListItem>
                                                    <asp:ListItem>200  </asp:ListItem>
                                                    <asp:ListItem>220  </asp:ListItem>
                                                    <asp:ListItem>250  </asp:ListItem>
                                                    <asp:ListItem>280  </asp:ListItem>
                                                    <asp:ListItem>315  </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                防爆等级
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 无</asp:ListItem>
                                                    <asp:ListItem>BT4</asp:ListItem>
                                                    <asp:ListItem>CT4</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                绝缘等级
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> F</asp:ListItem>
                                                    <asp:ListItem>H</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                安装方式
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" 
                                                    Width="100px">
                                                    <asp:ListItem Selected="True"> 轴流安装</asp:ListItem>
                                                    <asp:ListItem>V1安装</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴头攻丝
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 外螺丝</asp:ListItem>
                                                    <asp:ListItem>B3/B35轴头丝</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                加热带
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 无</asp:ListItem>
                                                    <asp:ListItem>有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴承
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList9" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 国产</asp:ListItem>
                                                    <asp:ListItem>国外</asp:ListItem>
                                                    <asp:ListItem>SKF</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                风扇罩
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 有</asp:ListItem>
                                                    <asp:ListItem>无</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                叶轮
                                            </td>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged" Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                叶轮价格:<asp:Label ID="叶轮价格" runat="server" Text="Label"></asp:Label><asp:Label ID="叶轮价格1"
                                                    runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶轮重量" runat="server" Text="Label"></asp:Label>
                                                KG</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴盘
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="轴盘" runat="server" Text="Label"></asp:Label>
                                                &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶轮工时" runat="server" Text="Label"></asp:Label>
                                                小时</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="3" bgcolor="#CCCCCC" class="style23">
                                                机壳
                                            </td>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList13" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList13_SelectedIndexChanged" Width="100px">
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="3" class="style20">
                                                机壳价格:<asp:Label ID="机壳价格" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="机壳价格1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="机壳重量" runat="server" Text="Label"></asp:Label>KG
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="机壳工时" runat="server" Text="Label"></asp:Label>小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                进风口
                                            </td>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList14" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList14_SelectedIndexChanged" Width="100px">
                                                
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                进风口价格:<asp:Label ID="进风口价格" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="进风口价格1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进风口重量" runat="server" Text="Label"></asp:Label> KG
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                铜板
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="铜板" runat="server" Text="Label"></asp:Label>
                                                &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进风口工时" runat="server" Text="Label"></asp:Label> 小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                减震支架
                                            </td>
                                            <td class="style29" align="right">
                                                是否有减震支架
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList18" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList18_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                减震支架价格:<asp:Label ID="减震支架价格" runat="server" Text="Label"></asp:Label><asp:Label
                                                    ID="减震支架价格1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList15" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList15_SelectedIndexChanged" Width="100px">
                                                 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="减震支架" runat="server" Text="Label"></asp:Label> KG </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="减震支架工时" runat="server" Text="Label"></asp:Label>小时
                                                
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                出口法兰
                                            </td>
                                            <td class="style29" align="right">
                                                是否有出口法兰
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList19" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList19_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                出口法兰价格:<asp:Label ID="出口法兰价格" runat="server" Text="Label"></asp:Label><asp:Label
                                                    ID="出口法兰价格1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList16" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList16_SelectedIndexChanged" Width="100px">
                                                
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="出口法兰重量" runat="server" Text="Label"></asp:Label>KG
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="出口法兰工时" runat="server" Text="Label"></asp:Label>小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                进口法兰
                                            </td>
                                            <td class="style29" align="right">
                                                是否有进口法兰
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList20" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList20_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                进口法兰价格:<asp:Label ID="进口法兰价格" runat="server" Text="Label"></asp:Label><asp:Label
                                                    ID="进口法兰价格1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList17" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList17_SelectedIndexChanged" Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进口法兰重量" runat="server" Text="Label"></asp:Label>
                                                &nbsp;KG</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进口法兰工时" runat="server" Text="Label"></asp:Label>
                                                小时</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="6" bgcolor="#CCCCCC" class="style23">
                                                其它</td>
                                            <td class="style29" align="right">
                                                标准件</td>
                                            <td class="style27">
                                               <asp:Label ID="标准件核定" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                            <td rowspan="6" class="style20">
                                              总价格<asp:Label ID="其它总价格" runat="server" Text="Label"></asp:Label><asp:Label ID="其它总价格1"
                                                                runat="server" Text="Label"></asp:Label>
                                               </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                是否有减震器</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList21" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList21_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="减震器" runat="server" Text="Label"></asp:Label>
                                                            &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                               是否有填料函</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList22" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList22_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="填料函" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                               是否有包装</td>
                                            <td class="style27">
                                                  <asp:DropDownList ID="DropDownList23" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList23_SelectedIndexChanged" 
                                                      Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="包装" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                是否有防护网</td>
                                            <td class="style27">
                                                  <asp:DropDownList ID="DropDownList24" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList24_SelectedIndexChanged" 
                                                      Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="防护网" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>

                                         <tr>
                                            <td class="style29" align="right">
                                                是否有软连接</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList25" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList25_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="软连接" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr> <tr>
                                            <td class="style23">
                                                
                                            </td>
                                            <td class="style11" colspan="2">
                                                总报价:
                                                <asp:Label ID="总报价" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="style20">
                                                <asp:Button ID="Button1" runat="server" Height="22px" OnClick="Button1_Click" 
                                                    style="margin-bottom: 0px" Text="计算电机价格和总价格" Width="150px" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel1_2" runat="server" HeaderText="CLQ">
                                
                                
                                   <ContentTemplate>
                                  <table class="style4" border="1" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td bgcolor="#CCCCCC" class="style23" style="width: 80px">
                                                &nbsp;
                                            </td>
                                            <td class="style29" align="right">
                                                风机型号
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList26" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList26_SelectedIndexChanged" Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style20" style="width: 200px">
                                             
                                              
                                             
                                                </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="10" bgcolor="#CCCCCC" class="style23">
                                                电机
                                            </td>
                                            <td class="style29" align="right">
                                                电机型号
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList27" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList27_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True">801        </asp:ListItem>
                                                    <asp:ListItem>802        </asp:ListItem>
                                                    <asp:ListItem>90S        </asp:ListItem>
                                                    <asp:ListItem>90L        </asp:ListItem>
                                                    <asp:ListItem>100L      </asp:ListItem>
                                                    <asp:ListItem>112M     </asp:ListItem>
                                                    <asp:ListItem>132S1    </asp:ListItem>
                                                    <asp:ListItem>132S2    </asp:ListItem>
                                                    <asp:ListItem>160M1   </asp:ListItem>
                                                    <asp:ListItem>160M2   </asp:ListItem>
                                                    <asp:ListItem>160L      </asp:ListItem>
                                                    <asp:ListItem>180M     </asp:ListItem>
                                                    <asp:ListItem>200L1     </asp:ListItem>
                                                    <asp:ListItem>200L2     </asp:ListItem>
                                                    <asp:ListItem>225M     </asp:ListItem>
                                                    <asp:ListItem>250M     </asp:ListItem>
                                                    <asp:ListItem>280S      </asp:ListItem>
                                                    <asp:ListItem>280M     </asp:ListItem>
                                                    <asp:ListItem>315S      </asp:ListItem>
                                                    <asp:ListItem>315M     </asp:ListItem>
                                                    <asp:ListItem>315L1     </asp:ListItem>
                                                    <asp:ListItem>315L2     </asp:ListItem>
                                                    <asp:ListItem>355M1   </asp:ListItem>
                                                    <asp:ListItem>355M2   </asp:ListItem>
                                                    <asp:ListItem>355L1     </asp:ListItem>
                                                    <asp:ListItem>355L2     </asp:ListItem>
                                                    <asp:ListItem>100L1     </asp:ListItem>
                                                    <asp:ListItem>100L2     </asp:ListItem>
                                                    <asp:ListItem>132S      </asp:ListItem>
                                                    <asp:ListItem>132M     </asp:ListItem>
                                                    <asp:ListItem>160M     </asp:ListItem>
                                                    <asp:ListItem>180L      </asp:ListItem>
                                                    <asp:ListItem>200L      </asp:ListItem>
                                                    <asp:ListItem>225S      </asp:ListItem>
                                                    <asp:ListItem>132M1   </asp:ListItem>
                                                    <asp:ListItem>132M2   </asp:ListItem>
                                                    <asp:ListItem>355M3   </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="10" class="style20">
                                                价格：<asp:Label ID="Label1" runat="server" Text="ee"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                级数
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList28" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList28_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True">2</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                功率
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList29" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList29_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 0.55</asp:ListItem>
                                                    <asp:ListItem>0.75 </asp:ListItem>
                                                    <asp:ListItem>1.1   </asp:ListItem>
                                                    <asp:ListItem>1.5   </asp:ListItem>
                                                    <asp:ListItem>2.2   </asp:ListItem>
                                                    <asp:ListItem>3     </asp:ListItem>
                                                    <asp:ListItem>4     </asp:ListItem>
                                                    <asp:ListItem>5.5   </asp:ListItem>
                                                    <asp:ListItem>7.5   </asp:ListItem>
                                                    <asp:ListItem>11    </asp:ListItem>
                                                    <asp:ListItem>15    </asp:ListItem>
                                                    <asp:ListItem>18.5 </asp:ListItem>
                                                    <asp:ListItem>22    </asp:ListItem>
                                                    <asp:ListItem>30    </asp:ListItem>
                                                    <asp:ListItem>37    </asp:ListItem>
                                                    <asp:ListItem>45    </asp:ListItem>
                                                    <asp:ListItem>55    </asp:ListItem>
                                                    <asp:ListItem>75    </asp:ListItem>
                                                    <asp:ListItem>90    </asp:ListItem>
                                                    <asp:ListItem>110  </asp:ListItem>
                                                    <asp:ListItem>132  </asp:ListItem>
                                                    <asp:ListItem>160  </asp:ListItem>
                                                    <asp:ListItem>185  </asp:ListItem>
                                                    <asp:ListItem>200  </asp:ListItem>
                                                    <asp:ListItem>220  </asp:ListItem>
                                                    <asp:ListItem>250  </asp:ListItem>
                                                    <asp:ListItem>280  </asp:ListItem>
                                                    <asp:ListItem>315  </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                防爆等级
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList30" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList30_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 无</asp:ListItem>
                                                    <asp:ListItem>BT4</asp:ListItem>
                                                    <asp:ListItem>CT4</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                绝缘等级
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList31" runat="server" AutoPostBack="True" 
                                                    Width="100px" onselectedindexchanged="DropDownList31_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True"> F</asp:ListItem>
                                                    <asp:ListItem>H</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                安装方式
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList32" runat="server" AutoPostBack="True" 
                                                    Width="100px" onselectedindexchanged="DropDownList32_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True"> 轴流安装</asp:ListItem>
                                                    <asp:ListItem>V1安装</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴头攻丝
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList33" runat="server" AutoPostBack="True" 
                                                    Width="100px" onselectedindexchanged="DropDownList33_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True"> 外螺丝</asp:ListItem>
                                                    <asp:ListItem>B3/B35轴头丝</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                加热带
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList34" runat="server" AutoPostBack="True" 
                                                    Width="100px" onselectedindexchanged="DropDownList34_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True"> 无</asp:ListItem>
                                                    <asp:ListItem>有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴承
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList35" runat="server" AutoPostBack="True" 
                                                    Width="100px" onselectedindexchanged="DropDownList35_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True"> 国产</asp:ListItem>
                                                    <asp:ListItem>国外</asp:ListItem>
                                                    <asp:ListItem>SKF</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                风扇罩
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList36" runat="server" AutoPostBack="True" 
                                                    Width="100px" onselectedindexchanged="DropDownList36_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True"> 有</asp:ListItem>
                                                    <asp:ListItem>无</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                叶轮
                                            </td>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList37" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList37_SelectedIndexChanged" Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                叶轮价格:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><asp:Label ID="Label4"
                                                    runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶轮重量1" runat="server" Text="Label"></asp:Label>
                                                KG</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴盘
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="轴盘1" runat="server" Text="Label"></asp:Label>
                                                &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶轮工时1" runat="server" Text="Label"></asp:Label>
                                                小时</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="3" bgcolor="#CCCCCC" class="style23">
                                                机壳
                                            </td>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList38" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList38_SelectedIndexChanged" Width="100px">
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="3" class="style20">
                                                机壳价格:<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="机壳重量1" runat="server" Text="Label"></asp:Label>KG
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="机壳工时1" runat="server" Text="Label"></asp:Label>小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                进风口
                                            </td>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList39" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList39_SelectedIndexChanged" Width="100px">
                                                
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                进风口价格:<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进风口重量1" runat="server" Text="Label"></asp:Label> KG
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                &nbsp;</td>
                                            <td class="style27">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进风口工时1" runat="server" Text="Label"></asp:Label> 小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                减震支架
                                            </td>
                                            <td class="style29" align="right">
                                                是否有减震支架
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList40" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList40_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                减震支架价格:<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label><asp:Label
                                                    ID="Label18" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList41" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList41_SelectedIndexChanged" Width="100px">
                                                 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="减震支架1" runat="server" Text="Label"></asp:Label> KG </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="减震支架工时1" runat="server" Text="Label"></asp:Label>小时
                                                
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                出口法兰
                                            </td>
                                            <td class="style29" align="right">
                                                是否有出口法兰
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList42" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList42_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                出口法兰价格:<asp:Label ID="Label21" runat="server" Text="Label"></asp:Label><asp:Label
                                                    ID="Label22" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList43" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList43_SelectedIndexChanged" Width="100px">
                                                
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="出口法兰重量1" runat="server" Text="Label"></asp:Label>KG
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="出口法兰工时1" runat="server" Text="Label"></asp:Label>小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="4" bgcolor="#CCCCCC" class="style23">
                                                进口法兰
                                            </td>
                                            <td class="style29" align="right">
                                                是否有进口法兰
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList44" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList44_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="4" class="style20">
                                                进口法兰价格:<asp:Label ID="Label25" runat="server" Text="Label"></asp:Label><asp:Label
                                                    ID="Label26" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                材质
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList45" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList45_SelectedIndexChanged" Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进口法兰重量1" runat="server" Text="Label"></asp:Label>
                                                &nbsp;KG</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="进口法兰工时1" runat="server" Text="Label"></asp:Label>
                                                小时</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="6" bgcolor="#CCCCCC" class="style23">
                                                其它</td>
                                            <td class="style29" align="right">
                                                标准件</td>
                                            <td class="style27">
                                               <asp:Label ID="标准件核定1" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                            <td rowspan="6" class="style20">
                                              总价格<asp:Label ID="Label30" runat="server" Text="Label"></asp:Label><asp:Label ID="Label31"
                                                                runat="server" Text="Label"></asp:Label>
                                               </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                是否有减震器</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList200" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList200_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="减震器1" runat="server" Text="Label"></asp:Label>
                                                            &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                               是否有填料函</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList201" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList201_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="填料函1" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                               是否有包装</td>
                                            <td class="style27">
                                                  <asp:DropDownList ID="DropDownList203" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList203_SelectedIndexChanged" 
                                                      Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="包装1" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                是否有防护网</td>
                                            <td class="style27">
                                                  <asp:DropDownList ID="DropDownList204" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList204_SelectedIndexChanged" 
                                                      Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="防护网1" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>

                                         <tr>
                                            <td class="style29" align="right">
                                                是否有软连接</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList205" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList205_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="软连接1" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr> <tr>
                                            <td class="style23">
                                                
                                            </td>
                                            <td class="style11" colspan="2">
                                                总报价:
                                                <asp:Label ID="总报价1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="style20">
                                                <asp:Button ID="Button2" runat="server" Height="22px" OnClick="Button2_Click" 
                                                    style="margin-bottom: 0px" Text="计算电机价格和总价格" Width="150px" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>

                            </ajaxToolkit:TabPanel>
                            
                                  <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="CZ">
                                
                                
                                   <ContentTemplate>
                                  <table class="style4" border="1" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td bgcolor="#CCCCCC" class="style23" style="width: 80px">
                                                &nbsp;
                                            </td>
                                            <td class="style29" align="right">
                                                风机型号
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList46" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList307_SelectedIndexChanged" 
                                                    Width="100px">
                                                  
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style20" style="width: 200px">
                                             
                                              
                                             
                                                </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#CCCCCC" class="style23" style="width: 80px">
                                                &nbsp;</td>
                                            <td align="right" class="style29">
                                                风筒板厚</td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList307" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList307_SelectedIndexChanged" Width="100px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style20" style="width: 200px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#CCCCCC" class="style23" style="width: 80px">
                                                &nbsp;</td>
                                            <td align="right" class="style29">
                                                风机编码</td>
                                            <td class="style27">
                                                <asp:Label ID="风机编码3" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="style20" style="width: 200px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="10" bgcolor="#CCCCCC" class="style23">
                                                电机
                                            </td>
                                            <td class="style29" align="right">
                                                电机型号
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList47" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList47_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True">801        </asp:ListItem>
                                                    <asp:ListItem>802        </asp:ListItem>
                                                    <asp:ListItem>90S        </asp:ListItem>
                                                    <asp:ListItem>90L        </asp:ListItem>
                                                    <asp:ListItem>100L      </asp:ListItem>
                                                    <asp:ListItem>112M     </asp:ListItem>
                                                    <asp:ListItem>132S1    </asp:ListItem>
                                                    <asp:ListItem>132S2    </asp:ListItem>
                                                    <asp:ListItem>160M1   </asp:ListItem>
                                                    <asp:ListItem>160M2   </asp:ListItem>
                                                    <asp:ListItem>160L      </asp:ListItem>
                                                    <asp:ListItem>180M     </asp:ListItem>
                                                    <asp:ListItem>200L1     </asp:ListItem>
                                                    <asp:ListItem>200L2     </asp:ListItem>
                                                    <asp:ListItem>225M     </asp:ListItem>
                                                    <asp:ListItem>250M     </asp:ListItem>
                                                    <asp:ListItem>280S      </asp:ListItem>
                                                    <asp:ListItem>280M     </asp:ListItem>
                                                    <asp:ListItem>315S      </asp:ListItem>
                                                    <asp:ListItem>315M     </asp:ListItem>
                                                    <asp:ListItem>315L1     </asp:ListItem>
                                                    <asp:ListItem>315L2     </asp:ListItem>
                                                    <asp:ListItem>355M1   </asp:ListItem>
                                                    <asp:ListItem>355M2   </asp:ListItem>
                                                    <asp:ListItem>355L1     </asp:ListItem>
                                                    <asp:ListItem>355L2     </asp:ListItem>
                                                    <asp:ListItem>100L1     </asp:ListItem>
                                                    <asp:ListItem>100L2     </asp:ListItem>
                                                    <asp:ListItem>132S      </asp:ListItem>
                                                    <asp:ListItem>132M     </asp:ListItem>
                                                    <asp:ListItem>160M     </asp:ListItem>
                                                    <asp:ListItem>180L      </asp:ListItem>
                                                    <asp:ListItem>200L      </asp:ListItem>
                                                    <asp:ListItem>225S      </asp:ListItem>
                                                    <asp:ListItem>132M1   </asp:ListItem>
                                                    <asp:ListItem>132M2   </asp:ListItem>
                                                    <asp:ListItem>355M3   </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="10" class="style20">
                                                价格：<asp:Label ID="Label5" runat="server" Text="ee"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                级数
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList48" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList48_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True">2</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                功率
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList49" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList49_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 0.55</asp:ListItem>
                                                    <asp:ListItem>0.75 </asp:ListItem>
                                                    <asp:ListItem>1.1   </asp:ListItem>
                                                    <asp:ListItem>1.5   </asp:ListItem>
                                                    <asp:ListItem>2.2   </asp:ListItem>
                                                    <asp:ListItem>3     </asp:ListItem>
                                                    <asp:ListItem>4     </asp:ListItem>
                                                    <asp:ListItem>5.5   </asp:ListItem>
                                                    <asp:ListItem>7.5   </asp:ListItem>
                                                    <asp:ListItem>11    </asp:ListItem>
                                                    <asp:ListItem>15    </asp:ListItem>
                                                    <asp:ListItem>18.5 </asp:ListItem>
                                                    <asp:ListItem>22    </asp:ListItem>
                                                    <asp:ListItem>30    </asp:ListItem>
                                                    <asp:ListItem>37    </asp:ListItem>
                                                    <asp:ListItem>45    </asp:ListItem>
                                                    <asp:ListItem>55    </asp:ListItem>
                                                    <asp:ListItem>75    </asp:ListItem>
                                                    <asp:ListItem>90    </asp:ListItem>
                                                    <asp:ListItem>110  </asp:ListItem>
                                                    <asp:ListItem>132  </asp:ListItem>
                                                    <asp:ListItem>160  </asp:ListItem>
                                                    <asp:ListItem>185  </asp:ListItem>
                                                    <asp:ListItem>200  </asp:ListItem>
                                                    <asp:ListItem>220  </asp:ListItem>
                                                    <asp:ListItem>250  </asp:ListItem>
                                                    <asp:ListItem>280  </asp:ListItem>
                                                    <asp:ListItem>315  </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                防爆等级
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList50" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList50_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 无</asp:ListItem>
                                                    <asp:ListItem>BT4</asp:ListItem>
                                                    <asp:ListItem>CT4</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                绝缘等级
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList51" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList51_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> F</asp:ListItem>
                                                    <asp:ListItem>H</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                安装方式
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList52" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList52_SelectedIndexChanged" 
                                                    Width="100px">
                                                    <asp:ListItem Selected="True"> 轴流安装</asp:ListItem>
                                                    <asp:ListItem>V1安装</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴头攻丝
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList53" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList53_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 外螺丝</asp:ListItem>
                                                    <asp:ListItem>B3/B35轴头丝</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                加热带
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList54" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList54_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 无</asp:ListItem>
                                                    <asp:ListItem>有</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                轴承
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList55" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList55_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 国产</asp:ListItem>
                                                    <asp:ListItem>国外</asp:ListItem>
                                                    <asp:ListItem>SKF</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                风扇罩
                                            </td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList56" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList56_SelectedIndexChanged" Width="100px">
                                                    <asp:ListItem Selected="True"> 有</asp:ListItem>
                                                    <asp:ListItem>无</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="3" bgcolor="#CCCCCC" class="style23">
                                                叶轮
                                            </td>
                                            <td class="style29" align="right">
                                                叶片数
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶片数3" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td rowspan="3" class="style20">
                                                叶轮价格:<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><asp:Label ID="Label10"
                                                    runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                叶轮材料费
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶轮材料费3" runat="server" Text="Label"></asp:Label>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                叶轮工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="叶轮工时3" runat="server" Text="Label"></asp:Label>
                                                小时</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2" bgcolor="#CCCCCC" class="style23">
                                                风筒</td>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="风筒重量3" runat="server" Text="Label"></asp:Label>
                                                KG&nbsp;</td>
                                            <td rowspan="2" class="style20">
                                                风筒价格:<asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="风筒工时3" runat="server" Text="Label"></asp:Label>小时
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2" bgcolor="#CCCCCC" class="style23">
                                                配对法兰
                                            </td>
                                            <td class="style29" align="right">
                                                重量
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="配对法兰重量3" runat="server" Text="Label"></asp:Label>
                                                KG&nbsp;</td>
                                            <td rowspan="2" class="style20">
                                                配对法兰价格:<asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                工时
                                            </td>
                                            <td class="style27">
                                                <asp:Label ID="配对法兰工时3" runat="server" Text="Label"></asp:Label> 小时
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td rowspan="7" bgcolor="#CCCCCC" class="style23">
                                                其它</td>
                                            <td class="style29" align="right">
                                                标准件</td>
                                            <td class="style27">
                                               <asp:Label ID="标准件核定3" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                            <td rowspan="7" class="style20">
                                              总价格<asp:Label ID="Label45" runat="server" Text="Label"></asp:Label><asp:Label ID="Label46"
                                                                runat="server" Text="Label"></asp:Label>
                                               </td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                是否有减震器</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList300" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList300_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="减震器3" runat="server" Text="Label"></asp:Label>
                                                            &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                               是否有填料函</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList301" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList301_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="填料函3" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                               是否有包装</td>
                                            <td class="style27">
                                                  <asp:DropDownList ID="DropDownList303" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList303_SelectedIndexChanged" 
                                                      Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="包装核定3" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style29" align="right">
                                                是否有防护网</td>
                                            <td class="style27">
                                                  <asp:DropDownList ID="DropDownList304" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList304_SelectedIndexChanged" 
                                                      Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="防护网3" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr>

                                         <tr>
                                            <td class="style29" align="right">
                                                是否有接线盒</td>
                                            <td class="style27">
                                                 <asp:DropDownList ID="DropDownList305" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="DropDownList305_SelectedIndexChanged" 
                                                     Width="100px">
                                                                <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="接线盒3" runat="server" Text="Label"></asp:Label>&nbsp;元</td>
                                        </tr> 
                                        <tr>
                                            <td align="right" class="style29">
                                                是否有支撑板</td>
                                            <td class="style27">
                                                <asp:DropDownList ID="DropDownList306" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="DropDownList306_SelectedIndexChanged" 
                                                    Width="100px">
                                                    <asp:ListItem Selected="True" Value="0">无</asp:ListItem>
                                                    <asp:ListItem Value="1">有</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="支撑板3" runat="server" Text="Label"></asp:Label>
                                                &nbsp;元</td>
                                        </tr>
                                        <tr>
                                            <td class="style23">
                                                
                                            </td>
                                            <td class="style11" colspan="2">
                                                总报价:
                                                <asp:Label ID="总报价3" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="style20">
                                                <asp:Button ID="Button3" runat="server" Height="22px" OnClick="Button3_Click" 
                                                    style="margin-bottom: 0px" Text="计算电机价格和总价格" Width="150px" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>

                            </ajaxToolkit:TabPanel>

                        </ajaxToolkit:TabContainer></ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="离心风机">
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="大叶轮风机">
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
