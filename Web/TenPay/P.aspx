<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P.aspx.cs" Inherits="Enow.TZB.Web.TenPay.P" %>

<!DOCTYPE html>
<html>
<head>
    <title>微信安全支付</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script type="text/javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js"></script>

    <script src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js" type="text/javascript"></script>

    <meta id="viewport" name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1; user-scalable=no;" />

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
     var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script language="javascript" type="text/javascript">

        $(function() {
            jQuery('a#getBrandWCPayRequest').click(function() {
                wx.chooseWXPay({
                    timestamp: '<%= _TenPayTradeModel.TimeStamp %>', // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                    nonceStr: '<%= _TenPayTradeModel.NonceStr %>', // 支付签名随机串，不长于 32 位
                    package: 'prepay_id=<%= _TenPayTradeModel.PrepayId %>', // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                    signType: 'MD5', // 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
                    paySign: '<%= _TenPayTradeModel.Sign %>', // 支付签名
                    success: function(res) {
                        // 支付成功后的回调函数
                    }
                });
            })
        })
    </script>

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
                                            充值金额：</label><span class="price"><asp:Label ID="lblAccount" runat="server" Text=""></asp:Label></span></li>
                                    <li>
                                        <label>
                                            应付金额：</label><asp:Label ID="lblCope" runat="server" Text=""></asp:Label></li>
                                    <li><a id="getBrandWCPayRequest" class="step_btn" href="javascript:;">支付</a></li>
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
</body>
</html>
