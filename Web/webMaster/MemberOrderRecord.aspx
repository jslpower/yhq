<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberOrderRecord.aspx.cs"
    Inherits="Eyousoft_yhq.Web.webMaster.OrderRecord" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="/js/jquery.js"></script>

    <script language="javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <!--tianjia----delete---star-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tablelist" style="width: 100%">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="60" height="30" align="center">
                            序号
                        </th>
                        <th align="center">
                            订单号
                        </th>
                        <th align="center">
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
            <asp:PlaceHolder ID="plaHJ" runat="server">
                <table width="100%" cellspacing="1" cellpadding="0" border="0" id="Table1">
                    <tbody>
                        <tr>
                            <th width="60" height="30" align="center">
                                合计
                            </th>
                            <th align="center">
                                &nbsp;
                            </th>
                            <th align="center">
                                &nbsp;
                            </th>
                            <th align="center">
                                &nbsp;
                            </th>
                            <th align="center">
                                &nbsp;
                            </th>
                            <th align="center">
                                &nbsp;
                            </th>
                            <th align="center">
                                &nbsp;
                            </th>
                            <th align="center" width="12%">
                                <asp:Label ID="lblPayED" runat="server" Text=""></asp:Label>
                            </th>
                            <th align="center" width="12%">
                                <asp:Label ID="lblBacK" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                    </tbody>
                </table>
            </asp:PlaceHolder>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" align="right" class="pageup" colspan="13">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
