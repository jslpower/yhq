<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WxPayList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.WxPayList" %>

<%@ Register Assembly="ControlLibrary" Namespace="ControlLibrary" TagPrefix="cc2" %>
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

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <!--tianjia----delete---star-->
</head>
<body>
    <form method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                        订单号：
                        <input type="text" size="20" id="OrderCode" class="searchinput formsize100" name="OrderCode"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("OrderCode") %>">
                        流水号 ：
                        <input type="text" size="20" id="TradeNo" class="searchinput formsize100" name="TradeNo"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("TradeNo") %>">
                        充值账号：
                        <input type="text" size="20" id="Account" class="searchinput formsize100" name="Account"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("Account") %>">
                        <input type="submit" value="查询" />
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif">
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <div class="tablelist">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="Tborder">
            <tbody>
                <tr>
                    <th>
                        订单号
                    </th>
                    <th>
                        流水号
                    </th>
                    <th>
                        充值账号
                    </th>
                    <th>
                        充值金额
                    </th>
                    <th>
                        操作人
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>'>
                            <td align="center" height="30">
                                <%# Eval("ordercode")%>
                            </td>
                            <td align="center">
                                <%# Eval("TradeNo")%>
                            </td>
                            <td align="center">
                                <%# Eval("UserName")%>
                            </td>
                            <td align="center">
                                <%#Eval("OptMoney", "{0:f2}")%>
                            </td>
                            <td align="center">
                                <%# Eval("ContactName")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='5'>暂无相关信息!</td></tr>"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right" height="40">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</body>
</html>
