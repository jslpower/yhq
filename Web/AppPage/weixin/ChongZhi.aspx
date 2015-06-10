<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChongZhi.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.ChongZhi" %>

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
            账户充值</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216"
            class="icon_phone"></a>
    </div>
    <div class="mainbox">
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
                                            账 户：</label><span class="price"><dfn></dfn><asp:Label ID="lblAccount" runat="server"
                                                Text=""></asp:Label></span></li>
                                    <li>
                                        <label>
                                            充值金额：</label><input id="money" name="money" type="text" class="input-style" value="" /></li>
                                    <li><a id="a_recharge" class="step_btn" href="javascript:;">充值</a></li>
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
            $("#a_recharge").click(function() {
                var accountMoney = $("#money").val();
                if (!/^\d+(\.\d+)?$/.test(accountMoney)) {
                    alert('请核对转账金额！');
                    return false;
                }
                $.ajax({
                    url: 'ChongZhi.aspx?chongzhi=1&',
                    type: "post",
                    dataType: "json",
                    data: $("#a_recharge").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            window.location.href = "/TenPay/P.aspx?id=" + ret.obj;
                        }
                        else {
                            alert(ret.msg);
                            return false;
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
