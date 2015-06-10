<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.MemberList" %>

<%@ Register Assembly="ControlLibrary" Namespace="ControlLibrary" TagPrefix="cc2" %>
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
    <form action="/webMaster/MemberList.aspx" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                        用户名：
                        <input type="text" size="20" id="userName" class="searchinput formsize100" name="userName"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("userName") %>">
                        姓名：
                        <input type="text" size="20" id="contactName" class="searchinput formsize100" name="contactName"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("contactName") %>">
                        旅游顾问：<select id="txtIsLvYouGuWen" name="txtIsLvYouGuWen">
                            <option value="">-请选择-</option>
                            <option value="0">未认证</option>
                            <option value="1">已认证</option>
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
                    <%--     <td width="90" align="center">
                        <a class="toolbar_add" href="javascript:;">添加</a>
                    </td>--%>
                    <td width="90" align="center">
                        <a class="toolbar_update" href="javascript:;">修改</a>
                    </td>
                    <td width="90" align="center">
                        <a class="toolbar_delete" href="javascript:;">删除</a>
                        
                    </td>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <td width="90" align="center">
                            <a class="toolbar_chongzi" href="javascript:;">充值</a>
                        </td>
                    </asp:PlaceHolder>
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
                    <th width="150" align="center">
                        手机号（用户名）
                    </th>
                    <th width="80" align="center">
                        姓名
                    </th>
                    <th width="80" align="center">
                        性别
                    </th>
                    <th width="80" align="center">
                        返佣记录
                    </th>
                    <th width="80" align="center">
                        账户余额
                    </th>
                    <th width="80" align="center">
                        推广记录
                    </th>
                    <th align="center">
                        备注
                    </th>
                    <th width="129" align="center">
                        旅游顾问
                    </th>
                </tr>
                <asp:Repeater ID="rpt_list" runat="server">
                    <ItemTemplate>
                        <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>' data-huiyuanid="<%#Eval("UserID") %>">
                            <td align="center" height="30">
                                <input type="checkbox" name="chk_IDS" value="<%#Eval("UserID")%>">
                                <%# Container.ItemIndex+1 %>
                            </td>
                            <td align="center">
                                <%#Eval("UserName")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactName")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactSex")%>
                            </td>
                            <td align="center">
                                <a class="boxCount" href="javascript:;" data-id="<%#  Eval("UserID") %>" data-scale="<%# Eval("CommissonScale")  %>"
                                    data-code="<%#  Eval("PromotionCode") %>">
                                    <%# getFYCS(Eval("UserID").ToString(), Eval("PromotionCode").ToString())%>
                                </a>
                            </td>
                            <td align="center">
                                <%#Eval("YuE","{0:C2}")%>
                            </td>
                            <td align="center">
                                <a class="boxPromotion" href="javascript:;" data-code="<%#  Eval("PromotionCode") %>">
                                    <%#  getTGCS (Eval("PromotionCode").ToString())%>
                                </a>
                            </td>
                            <td align="center">
                                <%#Eval("Remark")%>
                            </td>
                            <td align="center">
                                <%#GetLvYuGuWen(Eval("IsLvYouGuWen"),Eval("LvYouGuWenRenZhengTime"))%>
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
            },
            reload: function() {
                window.location.href = window.location.href;
            },
            lvYouGuWenRenZheng: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtHuiYuanId: _$tr.attr("data-huiyuanid"), txtRenZheng: $(obj).attr("data-renzhen") };

                var _self = this;
                //                if (!confirm("旅游顾问认证暂不可逆，你确定要将该会员认证为旅游顾问吗？")) return false;

                if (confirm("确认操作？")) {
                    $.ajax({ type: "POST", url: "memberlist.aspx?doType=lvyouguwenrenzheng", data: _data, cache: false, dataType: "json", async: false,
                        success: function(response) {
                            alert(response.msg);
                            _self.reload();
                        },
                        error: function() { }
                    });
                }
            }
        };

        $(function() {
            $(".boxCount").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/MemberOrderRecord.aspx?userid=" + $(this).attr("data-id") + "&scale=" + $(this).attr("data-scale") + "&Code=" + $(this).attr("data-code"), title: "交易记录", width: "660px", height: "400px" });
            });
            $(".boxPromotion").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/PromotionCodeRecord.aspx?Code=" + $(this).attr("data-Code"), title: "推广记录", width: "660px", height: "400px" });
            });


            $(".toolbar_add").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/MemberAdd.aspx?dotype=add", title: "添加", width: "660px", height: "400px" });
            });

            $(".toolbar_update").click(function() {
                if (pageOpt.getChkids().length == 0) { tableToolbar._showMsg("请选择一个要操作的数据！", function() { return false; }); }
                if (pageOpt.getChkids().length > 1) { tableToolbar._showMsg("只能操作单个数据！", function() { return false; }); }
                if (pageOpt.getChkids().length == 1) {
                    pageOpt.ShowBoxy({ iframeUrl: "/webMaster/MemberAdd.aspx?dotype=edit&id=" + pageOpt.getChkids(), title: "修改", width: "660px", height: "400px" });
                }

            });
            $(".toolbar_delete").click(function() {
                if (pageOpt.getChkids().length > 1) tableToolbar._showMsg("只能操作单个数据！", function() { return false; });
                if (pageOpt.getChkids().length == 1) {
                    tableToolbar.ShowConfirmMsg("确定要删除该账号?", function() { pageOpt.GoAjax("/webMaster/MemberList.aspx?dotype=delete&ids=" + pageOpt.getChkids()); });

                }
            });

            $(".toolbar_chongzi").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/webMaster/MasterCZ.aspx", title: "添加", width: "660px", height: "400px" });
            });

            $("#chkall").click(function() {
                var mark = $("#hidmark").val();
                if (mark == 0) { $("[name=chk_IDS]").attr("checked", true); $("#hidmark").val("1"); }
                if (mark == 1) { $("[name=chk_IDS]").attr("checked", false); $("#hidmark").val("0"); }
            })
            $("#search").click(function() {
                window.location.href = "/webMaster/MemberAdd.aspx?" + param

            })

            $("#txtIsLvYouGuWen").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtIsLvYouGuWen") %>');
            $("a[data-class='lvyouguwen_renzheng']").click(function() { pageOpt.lvYouGuWenRenZheng(this); });
        })
    </script>

</body>
</html>
