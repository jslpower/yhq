<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountManage.aspx.cs"
    Inherits="Eyousoft_yhq.Web.AppPage.weixin.AccountManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>订单查询</title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <h1>
            账户管理</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216"
            class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="dindan_box">
            <div class="jp_nav">
                <ul class="fixed">
                    <li><a href="/AppPage/weixin/updateUser.aspx">个人信息</a></li>
                    <li class="on"><a href="/AppPage/weixin/AccountManage.aspx">账户信息</a></li>
                </ul>
            </div>
        </div>
        <div class="flight_info mt15">
            <h3>
                账户资金管理</h3>
            <div class="flight_preson">
                <ul>
                    <li class="list">
                        <div class="zijin_box">
                            <div class="zijin_form">
                                <ul>
                                    <li>
                                        <label>
                                            余 额：</label><span class="price"><dfn>¥</dfn><asp:Label ID="lblmoney" runat="server"
                                                Text=""></asp:Label></span></li>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                        <li>
                                            <label>
                                                账户名：</label><input id="userTo" name="userTo" type="text" class="input-style" value="" /></li>
                                        <li>
                                            <label>
                                                转账金额：</label><input id="money" name="money" type="text" class="input-style" value="" /></li>
                                    </asp:PlaceHolder>
                                    <li>
                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"><a id="a_pay" class="step_btn"
                                            href="javascript:;">转账</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:PlaceHolder>
                                        <a id="a_recharge" class="step_btn" href="ChongZhi.aspx">充值</a></li>
                                    <li></li>
                                </ul>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">

        $(function() {
            $("#a_pay").click(function() {
                var account = $("#userTo").val();
                var accountMoney = $("#money").val();
                if (!/^(13|15|18|14)\d{9}$/.test(account)) {
                    alert('请核对账户格式！');
                    return false;
                }
                if (!/^\d+(\.\d+)?$/.test(accountMoney)) {
                    alert('请核对转账金额！');
                    return false;
                }


                $.ajax({
                    url: 'AccountManage.aspx?chk=1&',
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            if (window.confirm("确认转入名称为[" + ret.obj + "]的账户[" + accountMoney + "]元?")) {

                                $.ajax({
                                    url: '/Huiyuan/Account.aspx?zz=1',
                                    dataType: "json",
                                    data: { a: account, m: accountMoney },
                                    success: function(ret) {

                                        alert(ret.msg)
                                        window.location.href = window.location.href;

                                    },
                                    error: function() {
                                        tableToolbar._showMsg("未知错误");
                                    }
                                })
                            }

                        } else {
                            alert(ret.msg);
                        }

                    },
                    error: function() {
                        alert("账户信息错误");
                    }
                })



            })
        })
    </script>

</body>
</html>
