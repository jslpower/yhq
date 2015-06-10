<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuYueList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.YuYueList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/jquery.js"></script>

    <script type="text/javascript" language="javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <style type="text/css">
        </style>
    <!--tianjia----delete---star-->
</head>
<body>
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
    <div class="tablelist">
        <table width="100%" id="liststyle">
            <tr>
                <th align="center" width="60">
                    编号
                </th>
                <th align="center" width="150">
                    线路名称
                </th>
                <th align="center">
                    预约人姓名
                </th>
                <th align="center" width="150">
                    预约人手机
                </th>
                <th align="center" width="500">
                    预约信息
                </th>
                <th align="center" width="120">
                    预约时间
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>'>
                        <td align="center">
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td align="center">
                            <%#Eval("YYRoute")%>
                        </td>
                        <td align="left">
                            <%#Eval("YYName")%>
                        </td>
                        <td align="center">
                            <%# Eval("YYMobile")%>
                        </td>
                        <td align="center">
                            <%# Eval("YYInfo")%>
                        </td>
                        <td align="center">
                            <%# Eval("YYTime","{0:yyyy-MM-dd}")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder ID="litMsg" runat="server" Visible="false">
                <tr>
                    <td colspan="10" align="center">
                        暂无数据
                    </td>
                </tr>
            </asp:PlaceHolder>
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
