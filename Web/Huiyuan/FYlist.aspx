<%@ Page Title="返佣记录" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="FYlist.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.GYlist" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            返佣记录</h2>
        <div class="address_box">
            <div style="width: 100%">
                <table class="tableList" width="100%" cellspacing="1" cellpadding="0" border="0"
                    id="liststyle">
                    <tbody>
                        <tr>
                            <th width="40" height="30" align="center">
                                序号
                            </th>
                            <th align="center">
                                订单号
                            </th>
                            <th align="center" width="160px">
                                产品名称
                            </th>
                            <th align="center">
                                下单人
                            </th>
                            <th align="center">
                                下单日期
                            </th>
                            <th align="center">
                                联系方式
                            </th>
                            <th align="center">
                                订单状态
                            </th>
                            <th align="center">
                                已结算金额
                            </th>
                            <th align="center">
                                待结算金额
                            </th>
                        </tr>
                        <asp:Repeater ID="rpt_orders" runat="server">
                            <ItemTemplate>
                                <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-id='<%#Eval("OrderId") %>'>
                                    <td height="30" align="center">
                                        <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("OrderCode")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("MemberName")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("IssueTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("MemberTel")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("OrderState")%>
                                    </td>
                                          <td align="center">
                                    <%#  EyouSoft.Common.Utils.GetMoneyString(Eval("RebackMoney"), "zh-cn")%>
                                </td>
                                <td align="center">
                                    <%# EyouSoft.Common.Utils.GetMoneyString(Eval("backMoney"), "zh-cn")%>
                                </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='9'>暂无相关信息!</td></tr>"></asp:Literal>
                    </tbody>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" align="right" class="pageup" colspan="13">
                            <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
