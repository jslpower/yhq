<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomMsgLis.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.CustomMsgLis" %>

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

    <!--tianjia----delete---star-->
</head>
<body>
    <table width="99%"  cellspacing="0" cellpadding="0" border="0" align="center">
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
                    微信建议人
                </th>
                <th align="center">
                    建议内容
                </th>
                <th align="center" width="150">
                    建议时间
                </th>
                <th align="center" width="120">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>'>
                        <td align="center">
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td align="center">
                            <%#Eval("NickName")%>
                        </td>
                        <td align="left">
                            <%#Eval("CommendInfo")%>
                        </td>
                        <td align="center">
                            <%# Eval("IssueTime")%>
                        </td>
                        <td align="center">
                            <a class="huifu" href="javascript:;" data-openid="<%# Eval("OpenId")%>">回复</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder ID="litMsg" runat="server" Visible="false">
                <tr>
                    <td colspan="5" align="center">
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

    <script type="text/javascript">
        var pageOpt = {
            //弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            } //
        }
        $(function() {
            $(".huifu").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/CustomMsgBack.aspx?openid=" + $(this).attr("data-openid"), title: "回复", width: "450px", height: "170px" });
            });
        })
    </script>

</body>
</html>
