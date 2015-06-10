<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouJiXX.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.YouJiXX" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link href="/css/weixin/basic.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/minpian.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/youji.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="warp">
        <div class="youji_main">
            <div class="user_header youji_header">
                <div class="user_01">
                    <div class="user_touxian radius">
                        <asp:Literal ID="ltrTouXiang" runat="server"></asp:Literal>
                        </div>
                        
                    <div class="user_name">
                        <asp:Literal ID="ltrMingCheng" runat="server"></asp:Literal></div>
                </div>
            </div>
            <div class="youji_box">
                <div class="title">
                    <asp:Literal ID="LtrTitle" runat="server"></asp:Literal></div>
                <asp:Literal ID="ChanPinLink" runat="server"></asp:Literal>
                <ul>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <li>
                                <p class="cent">
                                    <img alt="" class="yjimg" src="<%# Eval("ImgFile")%>" /></p>
                                <p>
                                    <%# Eval("XingChengContent")%></p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</body>

<script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

<script type="text/javascript" src="http://files.cnblogs.com/mofish/sha1.js"></script>

<script type="text/javascript">
    var tmstamp = (new Date()).valueOf();
    var signStr = 'jsapi_ticket=<%=EyouSoft.Common.Utils.get_weixin_jsapi_ticket() %>&noncestr=Wm3WZYTPz0wzccnW&timestamp=' + tmstamp + '&url=' + window.location.href
    var sha = hex_sha1(signStr);
    wx.config({
        debug: false,
        appId: 'wx935e1ca713dff84f',
        timestamp: tmstamp,
        nonceStr: 'Wm3WZYTPz0wzccnW',
        signature: sha,
        jsApiList: ['onMenuShareAppMessage', 'onMenuShareTimeline', 'onMenuShareQQ', 'onMenuShareWeibo']
    });
    var imgUrl = "http://www.4008005216.com<%= yjimg%>";
    var shareTitle = "<% =yjtitle%>";
    var lineLink = location.href;
    var descContent = "<%=EyouSoft.Common.Function.StringValidate.SafeHtmlEndcode(yjdesc)%>";
    wx.ready(function() {
        wx.onMenuShareTimeline({
            title: shareTitle,
            link: lineLink,
            imgUrl: imgUrl,
            success: function() {
            },
            cancel: function() {
            }
        });
        wx.onMenuShareAppMessage({
            title: shareTitle,
            desc: descContent,
            link: lineLink,
            imgUrl: imgUrl,
            type: 'link',
            dataUrl: '',
            success: function() {
            },
            cancel: function() {
            },
            fail: function() {
            }
        });
        //分享到QQ
        wx.onMenuShareQQ({
            title: shareTitle,
            desc: descContent,
            link: lineLink,
            imgUrl: imgUrl,
            success: function() {
            },
            cancel: function() {
            }
        });
        //分享到腾讯微博
        wx.onMenuShareWeibo({
            title: shareTitle,
            desc: descContent,
            link: lineLink,
            imgUrl: imgUrl,
            success: function() {
            },
            cancel: function() {
            }
        });
    });

    wx.error(function(res) {
        //alert(res);
    }); 
</script>

</html>
