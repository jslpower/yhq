<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.ProductList" %>

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
    <form action="/webMaster/ProductList.aspx" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                        产品名称：
                        <input type="text" size="20" id="productName" class="searchinput formsize100" name="productName"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("productName") %>" />
                        微信码：
                        <input type="text" size="20" id="FavourCode" class="searchinput formsize100" name="FavourCode"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("FavourCode") %>" />
                        产品状态：
                        <select name="pstate">
                            <option value="2">全部</option>
                            <option value="1">下架</option>
                            <option value="0">正常</option>
                        </select>
                        有效期：
                        <input type="text" size="20" id="stime" class="searchinput formsize100" name="stime"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("stime") %>" onfocus="WdatePicker()" />-
                        <input type="text" size="20" id="etime" class="searchinput formsize100" name="etime"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("etime") %>" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'stime\')}'})" />
                        是否热门：
                        <select name="isHot">
                            <option>请选择</option>
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select><br />
                        产品类别：
                        <select name="ptype">
                            <%=strBU %>
                        </select>
                        审核状态：
                        <select name="txtShenHeStatus">
                            <option value="">-请选择-</option>                           
                            <option value="<%=(int)Eyousoft_yhq.Model.ChanPinShenHeStatus.未审核 %>">未审核</option>
                            <option value="<%=(int)Eyousoft_yhq.Model.ChanPinShenHeStatus.已审核 %>">已审核</option>
                        </select>
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
                    <td width="90" align="center">
                        <a class="toolbar_xiajia" href="javascript:;">下架</a>
                    </td>
                    <asp:PlaceHolder runat="server" ID="phShenHe">
                    <td width="90" align="center">
                        <a href="javascript:void(0);" id="a_shenhe">审核</a>
                    </td>
                    </asp:PlaceHolder>
                    <td align="right" class="fred">
                        
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
                        产品名称
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
                    <th width="100" align="center">
                        领取次数
                    </th>
                    <th align="center">
                        有效期
                    </th>
                    <th align="center">
                        联系电话
                    </th>
                    <th align="center">
                        产品状态
                    </th>
                    <th align="center">
                        是否热门
                    </th>
                    <th align="center">
                        审核状态
                    </th>
                    <th align="center">
                        发布人
                    </th>
                </tr>
                <asp:Repeater ID="rpt_list" runat="server">
                    <ItemTemplate>
                        <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>' data-chanpinid="<%#Eval("ProductID") %>" data-shenhestatus="<%#(int)Eval("ShenHeStatus") %>">
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
                                <a class="boxCount" href="javascript:;">
                                    <%# getProductCount(Eval("ProductID").ToString())%></a>
                            </td>
                            <td align="center">
                                <%#Eval("ValidiDate", "{0:d}")%>
                            </td>
                            <td align="center">
                                <%#Eval("LinkTel")%>
                            </td>
                            <td align="center">
                                <%#Eval("ProductState").ToString()=="1"?"下架":"正常"%>
                            </td>
                            <td align="center">
                                <%#Eval("IsHot").ToString()=="1"?"热门":"常规"%>
                            </td>
                            <td align="center">
                                <%#GetShenHeStatus(Eval("ShenHeStatus"))%>
                            </td>
                            <td align="center">
                                <%#Eval("FaBuRenName")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='8'>暂无相关信息!</td></tr>"></asp:Literal>
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
            },
            reload: function() {
                window.location.href = window.location.href;
            },
            shenHe: function() {
                var _self = this;
                var _data = { txtChanPinId: [] };

                $("input[name='chk_IDS']:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    if (_$tr.attr("data-shenhestatus") == "<%=(int)Eyousoft_yhq.Model.ChanPinShenHeStatus.已审核 %>") {
                        $(this).removeAttr("checked");
                        return;
                    }
                    _data.txtChanPinId.push(_$tr.attr("data-chanpinid"));
                });

                if (_data.txtChanPinId.length < 1) { alert("请选择需要审核的产品"); return false; }

                function __callback(response) {
                    alert(response.msg);
                    _self.reload();
                }

                $.ajax({ type: "POST", url: "productlist.aspx?doType=shenhe", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() { }
                });

            }
        };

        $(function() {
            $(".boxCount").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/CouponsDraw.aspx?id=" + $(this).closest("tr").find("[name=chk_IDS]").val(), title: "领取记录", width: "660px", height: "400px" });
            });
            $(".toolbar_add").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/ProductAdd.aspx?dotype=add", title: "添加", width: "660px", height: "600px" });
            });
            $(".toolbar_update").click(function() {
                if (pageOpt.getChkids().length == 0) tableToolbar._showMsg("请选择一个要操作的是数据！", function() { return false; });
                if (pageOpt.getChkids().length > 1) tableToolbar._showMsg("只能操作单个数据！", function() { return false; });
                if (pageOpt.getChkids().length == 1) {
                    pageOpt.ShowBoxy({ iframeUrl: "/webMaster/ProductAdd.aspx?dotype=edit&id=" + pageOpt.getChkids(), title: "修改", width: "660px", height: "600px" });
                }

            });
            $(".toolbar_delete").click(function() {
                if (pageOpt.getChkids().length == 0)
                { tableToolbar._showMsg("请选择要操作的是数据！", function() { return false; }); }
                else {
                    tableToolbar.ShowConfirmMsg("确定要删除该产品?", function() { pageOpt.GoAjax("/webMaster/ProductList.aspx?dotype=delete&ids=" + pageOpt.getChkids()) });
                }
            });
            $(".toolbar_xiajia").click(function() {
                if (pageOpt.getChkids().length == 0) {
                    tableToolbar._showMsg("请选择要操作的是数据！", function() { return false; });
                }
                else {
                    tableToolbar.ShowConfirmMsg("确定要下架该产品?", function() { pageOpt.GoAjax("/webMaster/ProductList.aspx?dotype=xiajia&ids=" + pageOpt.getChkids()); })
                }
            });
            $("#chkall").click(function() {
                var mark = $("#hidmark").val();
                if (mark == 0) { $("[name=chk_IDS]").attr("checked", true); $("#hidmark").val("1"); }
                if (mark == 1) { $("[name=chk_IDS]").attr("checked", false); $("#hidmark").val("0"); }
            })
            $(".a_Code").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/zxingCodePrint.aspx?id=" + $(this).attr("data-id"), title: "查看产品二维码", width: "370px", height: "300px" });
            })

            $("#a_shenhe").click(function() { pageOpt.shenHe(); });
        })
    </script>

</body>
</html>
