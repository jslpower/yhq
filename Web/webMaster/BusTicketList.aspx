<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusTicketList.aspx.cs"
    Inherits="Eyousoft_yhq.Web.webMaster.BusTicketList" %>

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

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <!--tianjia----delete---star-->
</head>
<body>
    <form action="/webMaster/BusTicketList.aspx" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                        车票名称：
                        <input type="text" size="20" id="BusTicket" class="searchinput formsize100" name="BusTicket"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("BusTicket") %>" />
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
    <div class="btnbox">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a class="toolbar_add" href="javascript:;">添加</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_update" href="javascript:;">修改</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_delete" href="javascript:;">删除</a>
                    </td>
                    <td align="right" class="fred">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="Tborder">
            <tbody>
                <tr>
                    <th width="62" align="center" height="30">
                        <input type="hidden" id="hidmark" value="0" />
                        <input type="checkbox" id="chkall" name="checkbox3">
                        全选
                    </th>
                    <th width="200" align="center">
                        车票名称
                    </th>
                    <th width="200" align="center">
                        微信码
                    </th>
                    <th width="100" align="center">
                        市场价
                    </th>
                    <th width="100" align="center">
                        APP价
                    </th>
                    <th align="center">
                        上车时间段
                    </th>
                    <th align="center">
                        有效期
                    </th>
                    <th align="center">
                        剩余数量
                    </th>
                </tr>
                <asp:Repeater ID="rpt_list" runat="server">
                    <ItemTemplate>
                        <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>'>
                            <td align="center" height="30">
                                <input type="checkbox" name="chk_IDS" value="<%#Eval("ProductID")%>">
                                <%# Container.ItemIndex+1 %>
                            </td>
                            <td align="center">
                                <a class="a_Code" href="###" data-id="<%#Eval("ProductID")%>">
                                    <%#Eval("ProductName")%></a>
                            </td>
                            <td align="center">
                                <%# EyouSoft.Common.Utils.GetWXCode( Eval("FavourCode"))%>
                            </td>
                            <td align="center">
                                <%# EyouSoft.Common.UtilsCommons.GetMoneyString( Eval("MarketPrice"), "zh-cn")%>
                            </td>
                            <td align="center">
                                <%# EyouSoft.Common.UtilsCommons.GetMoneyString( Eval("AppPrice").ToString(),"zh-cn")%>
                            </td>
                            <td align="center">
                                <%#Eval("ProductSdate", "{0:d}")%>
                                至
                                <%#Eval("TourDate", "{0:d}")%>
                            </td>
                            <td align="center">
                                <%#Eval("ValidiDate", "{0:d}")%>
                            </td>
                            <td align="center">
                                <%#Eval("ControlPeople")%>
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
            },
            getChkids: function() {
                var arrayList = new Array();
                $(".tablelist").find("input[name='chk_IDS']").each(function() {
                    if ($(this).attr("checked") == true) {
                        arrayList.push($(this).val());
                    }
                });
                return arrayList;
            },
            serchModel: {
                UN: $("#userName").val(),
                CN: $("#contactName").val()
            }
        };

        $(function() {

            $(".toolbar_add").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/BusTicketAdd.aspx?dotype=add", title: "添加", width: "660px", height: "600px" });
            });
            $(".toolbar_update").click(function() {
                if (pageOpt.getChkids().length == 0) tableToolbar._showMsg("请选择一个要操作的是数据！", function() { return false; });
                if (pageOpt.getChkids().length > 1) tableToolbar._showMsg("只能操作单个数据！", function() { return false; });
                if (pageOpt.getChkids().length == 1) {
                    pageOpt.ShowBoxy({ iframeUrl: "/webMaster/BusTicketAdd.aspx?dotype=edit&id=" + pageOpt.getChkids(), title: "修改", width: "660px", height: "600px" });
                }

            });
            $(".toolbar_delete").click(function() {
                if (pageOpt.getChkids().length == 0)
                { tableToolbar._showMsg("请选择要操作的是数据！", function() { return false; }); }
                else {
                    tableToolbar.ShowConfirmMsg("确定要删除该产品?", function() { pageOpt.GoAjax("/webMaster/BusTicketList.aspx?dotype=delete&ids=" + pageOpt.getChkids()) });
                }
            });

            $("#chkall").click(function() {
                var mark = $("#hidmark").val();
                if (mark == 0) { $("[name=chk_IDS]").attr("checked", true); $("#hidmark").val("1"); }
                if (mark == 1) { $("[name=chk_IDS]").attr("checked", false); $("#hidmark").val("0"); }
            })
            $(".a_Code").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/zxingCodePrint.aspx?id=" + $(this).attr("data-id"), title: "查看产品二维码", width: "370px", height: "300px" });
            })//
        })
    </script>

</body>
</html>
