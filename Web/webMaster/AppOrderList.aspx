<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppOrderList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.AppOrderList" %>

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
                        订单号：
                        <input type="text" value='<%=Request.QueryString["OrderCode"] %>' name="orderCode"
                            class="searchinput formsize100" maxlength="30" size="28" />
                        确认码：
                        <input type="text" value='<%=Request.QueryString["ConfirmCode"] %>' name="ConfirmCode"
                            class="searchinput formsize100" maxlength="30" size="28" />
                        下单日期：
                        <input type="text" onfocus="WdatePicker()" name="StartTime" value='<%=Request.QueryString["StartTime"] %>'
                            id="txtStartTime" size="10" class="searchinput formsize100" />
                        -
                        <input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})"
                            value='<%=Request.QueryString["EndTime"] %>' class="searchinput formsize100"
                            name="EndTime" id="txtEndTime" size="10" />                      
                         消费操作人：
                        <input type="text" value='<%=Request.QueryString["AppUser"] %>' name="AppUser"
                            class="searchinput formsize100" maxlength="30" size="28" />
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
                        联系方式
                    </th>
                     <th align="center">
                        消费时间
                    </th>
                    <th align="center">
                        消费操作人
                    </th>
                     <th align="center">
                        持码人
                    </th>
                </tr>
                <asp:Repeater ID="rpt_orders" runat="server">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-id='<%#Eval("OrderId") %>'>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="update" data-id="<%#Eval("OrderId")%>">
                                    <%#Eval("OrderCode")%></a>
                            </td>
                            <td align="center">
                                <%# Eval("ProductName")%>
                            </td>
                            <td align="center">
                                <%# Eval("MemberName")%>
                            </td>
                            <td align="center">
                                <%# Eval("IssueTime", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td align="center">
                                <%# Eval("MemberTel")%>
                            </td>
                           <td align="center">
                                <%# Eval("AppTime", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                           <td align="center">
                                <%# Eval("AppUserName")%>
                            </td>
                            <td align="center">
                                <%# Eval("AppMobNo")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='9'>暂无相关信息!</td></tr>"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="7">
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
            $("a[class=update]").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/OrderEdit.aspx?dotype=edit&orderid=" + $(this).closest("tr").attr("data-id"), title: "查看", width: "660px", height: "500px" });
            });
        })
    </script>

</body>
</html>
