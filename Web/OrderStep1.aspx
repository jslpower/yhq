<%@ Page Title="提交订单" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="OrderStep1.aspx.cs" Inherits="Eyousoft_yhq.Web.OrderStep1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dindan_step">
        <div class="step_T step_T1">
            <ul>
                <li class="default">1、提交订单</li>
                <li>2、确认支付</li>
                <li>3、完成购买</li>
            </ul>
        </div>
        <div class="stepBox">
            <form id="form1">
            <div class="stepTable">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            项目
                        </th>
                        <th width="120">
                            数量
                        </th>
                        <th width="120">
                            单价
                        </th>
                        <th width="120">
                            总价
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Pname" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="center" class="dind_shu">
                            <a href="javascript:;" class="jian">-</a><input id="orderNum" name="orderNum" value="1"
                                type="text" readonly="readonly" /><a href="javascript:;" class="jia">+</a>
                        </td>
                        <td align="center">
                            <asp:Label ID="lbl_Price" runat="server" Text=""></asp:Label>
                            <input type="hidden" runat="server" id="singlePirce" name="singlePirce" />
                        </td>
                        <td align="center">
                            <asp:Label ID="lbl_SumPrice" runat="server" Text=""></asp:Label>
                            <input type="hidden" runat="server" id="sumPirce" name="sumPirce" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="right">
                            应付金额：<div class="Bprice" style="display: inline;">
                                ¥ <span>
                                    <asp:Label ID="lbl_orderPrice" runat="server" Text=""></asp:Label>
                                </span>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="qupiao_msg">
                <h3>
                    取票人信息：</h3>
                <ul>
                    <li>
                        <label>
                            <font class="font_f60">*</font>取票人：</label><input id="receiveName" name="receiveName"
                                value="<%=Gname %>" type="text" class="inputbg formsize200" valid="required"
                                errmsg="预定人数不可为空!" /></li>
                    <li>
                        <label>
                            <font class="font_f60">*</font>手机号码：</label><input id="receiveMobile" name="receiveMobile"
                                value="<%=Gmobile %>" type="text" class="inputbg formsize200" valid="required|isMobile"
                                errmsg="手机号码不可为空!|手机号码错误!" /><span class="error_txt">(免费接收订单确认短信)</span></li>
                </ul>
            </div>
            <div class="Basic_btn">
                <button id="btnsave" onclick="return false">
                    提交订单</button></div>
            </form>
        </div>
    </div>

    <script type="text/javascript">
        $(function() {
            $("a.jian").click(function() {
                if (tableToolbar.getInt($("#orderNum").val()) > 0) {
                    $("#orderNum").val(tableToolbar.getInt($("#orderNum").val()) - 1);
                    var sumPrice = tableToolbar.getInt($("#ctl00_ContentPlaceHolder1_singlePirce").val()) * tableToolbar.getInt($("#orderNum").val());
                    $("#ctl00_ContentPlaceHolder1_lbl_orderPrice").html(sumPrice);
                    // **
                    var tempstr = "";
                    if (Math.abs(sumPrice) < 100000000) {
                        while (sumPrice > 1000) {
                            tempstr = "," + (sumPrice % 1000) + tempstr;
                            sumPrice = Math.floor(sumPrice / 1000);
                        }
                        tempstr = "￥" + sumPrice + tempstr;
                        $("#ctl00_ContentPlaceHolder1_lbl_SumPrice").html(tempstr);
                    }
                    //**
                }
                return false;
            })//
            $("a.jia").click(function() {
                $("#orderNum").val(tableToolbar.getInt($("#orderNum").val()) + 1);
                var sumPrice = tableToolbar.getInt($("#ctl00_ContentPlaceHolder1_singlePirce").val()) * tableToolbar.getInt($("#orderNum").val());
                $("#ctl00_ContentPlaceHolder1_lbl_orderPrice").html(sumPrice);
                // **
                var tempstr = "";
                if (Math.abs(sumPrice) < 100000000) {
                    while (sumPrice > 1000) {
                        tempstr = "," + (sumPrice % 1000) + tempstr;
                        sumPrice = Math.floor(sumPrice / 1000);
                    }
                    tempstr = "￥" + sumPrice + tempstr;
                    $("#ctl00_ContentPlaceHolder1_lbl_SumPrice").html(tempstr);
                }
                //**
            })//
            $("#btnsave").click(function() {
                var form = $("#btnsave").closest("form").get(0);
                FV_onBlur.initValid(form);
                if (ValiDatorForm.validator(form, "parent")) {
                    if (tableToolbar.getInt($("#orderNum").val()) == 0) {
                        tableToolbar._showMsg("预定人数必须大于0 ! ");
                        return false;
                    }
                    $("#btnsave").val("操作中!").unbind("click").css({ "color": "#999999" });
                    var pageData = {
                        id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id")%>',
                        orderNum: $("#orderNum").val(),
                        receiveName: $("#receiveName").val(),
                        receiveMobile: $("#receiveMobile").val()
                    }
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/OrderStep1.aspx?orderReceive=1",
                        dataType: "json",
                        data: pageData,
                        async: false,
                        success: function(ret) {
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() { window.location.href = "OrderStep2.aspx?id=" + ret.obj; });
                            }
                            if (ret.result == "2") {
                                tableToolbar._showMsg(ret.msg, function() { window.location.href = "/Huiyuan/OrderList.aspx"; });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg);
                                $("#btnsave").val("提交订单").bind("click", function() { $(this).css({ "color": "" }); return false; });
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                            $("#btnsave").val("提交订单").bind("click", function() { $(this).css({ "color": "" }); return false; });
                        }
                    });

                }
            })//

        })
    </script>

</asp:Content>
