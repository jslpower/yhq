<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HongBao.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.HongBao" %>

<%@ Register Assembly="ControlLibrary" Namespace="ControlLibrary" TagPrefix="cc2" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

</head>
<body>
    <form action="HongBao.aspx" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
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
                    <th width="62" align="center" height="30">
                        序号
                    </th>
                    <th align="center">
                        会员账户
                    </th>
                    <th align="center">
                        会员姓名
                    </th>
                    <th align="center">
                        红包金额
                    </th>
                </tr>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>'   '>
                            <td align="center" height="30">
                                <%# Container.ItemIndex+1 %>
                            </td>
                            <td align="center">
                                <%#Eval("UserName")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactName")%>
                            </td>
                            <td align="center">
                                <%#Eval("hongbaojine","{0:F2}")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='4'>暂无相关信息!</td></tr>"></asp:Literal>
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
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tbody>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
