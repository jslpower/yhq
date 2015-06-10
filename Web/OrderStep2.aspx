<%@ Page  Title="提交订单"  Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master" AutoEventWireup="true"
    CodeBehind="OrderStep2.aspx.cs" Inherits="Eyousoft_yhq.Web.OrderStep2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <style type="text/css">
        .style1
        {
            width: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!------dindan_step2-------->
    <div class="dindan_step">
        <div class="step_T step_T2">
            <ul>
                <li>1、提交订单</li>
                <li class="default">2、确认支付</li>
                <li>3、完成购买</li>
            </ul>
        </div>
        <div class="stepBox">
            <div class="zhifufs">
                <h3 class="samll_T">
                    选择支付方式</h3>
                <dl>
                    <dt>&gt; 支付宝支付<span>(推荐有支付宝账号的用户使用)</span></dt>
                    <dd>
                        <input type="radio" checked="checked" value="" name="">
                        <img src="images/zhifb.jpg"></dd>
                </dl>
            </div>
            <div class="stepTable">
                <h3 class="samll_T">
                    确认订单</h3>
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <th>
                                项目
                            </th>
                            <th width="120">
                                单价
                            </th>
                            <th width="120">
                                数量
                            </th>
                            <th width="120">
                                总价
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbName" runat="server"></asp:Label>
                            </td>
                            <td align="center" class="dind_shu">
                                <asp:Label ID="lbPrice" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbSum" runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbOderPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <a class="font_blue" href='<%="/RouteInfo.aspx?id="+ProtudId%>'>
                                    返回重新下单</a>
                            </td>
                            <td align="right" colspan="3">
                                还需支付：
                                <div style="display: inline;" class="Bprice">
                                    <span>
                                        <asp:Label ID="lbOderPrice2" runat="server"></asp:Label></span></div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="Basic_btn">
                <button id="btnsave" name="btnsave">
                    确认订单，付款</button></div>
        </div>
    </div>

    <script type="text/javascript">
        $(function() {
            $("#btnsave").click(function() {
                var pageData = {
                    ids: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id")%>'
                }
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/OrderStep2.aspx?orderPost=1&ids=" + pageData.ids,
                    dataType: "json",
                    data: pageData,
                    async: false,
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg);
                            var url = '/Alipay/WebPay/AliPayIndex.aspx?OrderId=<%=EyouSoft.Common.Utils.GetQueryStringValue("id")%>'
                            window.open(url);
                            tableToolbar.ShowConfirmMsg("支付已完成?", function() { location.href = "/Huiyuan/OrderList.aspx"; });
                        }
                        else if (ret.result == "2") {
                            tableToolbar._showMsg(ret.msg, function() { window.location.href = "/Huiyuan/OrderList.aspx"; });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            });
        });
    </script>

</asp:Content>
