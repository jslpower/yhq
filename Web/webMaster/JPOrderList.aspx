<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JPOrderList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.JPOrderList" %>

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
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" method="get">
                    <div class="searchbox">
                        下单日期：
                        <input type="text" onfocus="WdatePicker()" name="StartTime" value='<%=Request.QueryString["StartTime"] %>'
                            id="txtStartTime" size="10" class="searchinput formsize100" />
                        -
                        <input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})"
                            value='<%=Request.QueryString["EndTime"] %>' class="searchinput formsize100"
                            name="EndTime" id="txtEndTime" size="10" />
                        <input type="submit" value="查询" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="tablelist">
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
                        起飞日期
                    </th>
                    <th align="center">
                        乘机人名称
                    </th>
                    <th align="center">
                        航空公司代码
                    </th>
                    <th align="center">
                        保险费用
                    </th>
                    <th align="center">
                        操作员名称
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rpt_orders" runat="server">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-id='<%#Eval("SubsOrderNo") %>'>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="detail">
                                    <%#Eval("SubsOrderNo")%></a>
                            </td>
                            <td align="center">
                                <%# Eval("AirLine")%>
                            </td>
                            <td align="center">
                                <%# Eval("Linkman")%>
                            </td>
                            <td align="center">
                                <%# Eval("CreateDt", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td align="center">
                                <%# Eval("FltDateTime", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td align="center">
                                <%# Eval("PsrNames")%>
                            </td>
                            <td align="center">
                                <%#Eval("CarrierCode")%>
                            </td>
                            <td align="center">
                                <%# Eval("InsMoney")%>
                            </td>
                            <td align="center">
                                <%# Eval("UserName")%>
                            </td>
                            <td align="center">
                                <%# getOrderOpt(Eval("SubsOrderNo").ToString())%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='9'>暂无相关信息!</td></tr>"
                    Visible="false"></asp:Literal>
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
            },
            //Ajax请求
            GoAjax: function(url) {
                $.ajax({
                    type: "get",
                    cache: false,
                    url: url,
                    async: false,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        };

        $(function() {
            $("a.upState").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/JpOrderEdit.aspx?id=" + $(this).attr("data-id"), title: "修改", width: "350", height: "170" });
            });
            $("a[class=detail]").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/JpOrderdtail.aspx?dotype=edit&orderid=" + $(this).closest("tr").attr("data-id"), title: "查看", width: "600px", height: "500px" });
            });
            $("a[class=thTicket]").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/JpOrderdtail.aspx?dotype=tuipiao&orderid=" + $(this).closest("tr").attr("data-id"), title: "退票", width: "600px", height: "500px" });
            });

            $("a.cpTicket").click(function() {
                $.ajax({
                    type: "get",
                    cache: false,
                    url: "/webMaster/JPOrderList.aspx?sq=1&ordercode=" + $(this).attr("data-id"),
                    dataType: "json",
                    success: function(ret) {
                        tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            });
        })
    </script>

</body>
</html>
