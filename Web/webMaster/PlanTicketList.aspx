<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanTicketList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.PlanTicketList" %>

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
    <form action="/webMaster/PlanTicketList.aspx" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                         <%--<input type="submit" value="查询" />--%>
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
                        客户名称
                    </th>
                    <th>
                        性别
                    </th>
                    <th>
                        联系电话
                    </th>
                    <th>
                        机票编号
                    </th>
                    <th>
                        订单状态
                    </th>
                    <th>
                        支付状态
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpTicket">
                    <ItemTemplate>
                        <tr  bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>'>
                            <td align="center" height="30">                               
                                    <%# Eval("CusName")%>
                            </td>
                            <td align="center">
                                <%# Eval("CusSex")%>
                            </td>
                            <td align="center">
                                <%# Eval("CusMob")%>
                            </td>
                            <td align="center">
                                <%# Eval("PlaneTicket")%>
                            </td>
                            <td align="center">
                                <%# Eval("orderState")%>
                            </td>
                            <td align="center">
                                <%# Eval("payState")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='6'>暂无相关信息!</td></tr>"></asp:Literal>
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
