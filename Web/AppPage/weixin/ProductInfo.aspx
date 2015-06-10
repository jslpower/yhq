<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.ProductInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <title id="title">产品详情查看</title>
    <link href="/css/style.css?v=0.0.0.4" type="text/css" rel="stylesheet">
    <style type="text/css">
        html
        {
            -ms-touch-action: none;
        }
        body, ul, li
        {
            padding: 0;
            margin: 0;
            border: 0;
        }
        body
        {
            overflow: hidden; /* this is important to prevent the whole page to bounce */
        }
        #scroller
        {
            position: absolute;
            z-index: 1;
            -webkit-tap-highlight-color: rgba(0,0,0,0);
            width: 100%;
            -webkit-transform: translateZ(0);
            -moz-transform: translateZ(0);
            -ms-transform: translateZ(0);
            -o-transform: translateZ(0);
            transform: translateZ(0);
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            -webkit-text-size-adjust: none;
            -moz-text-size-adjust: none;
            -ms-text-size-adjust: none;
            -o-text-size-adjust: none;
            text-size-adjust: none;
        }
        #header
        {
            position: absolute;
            z-index: 2;
            top: 0;
            left: 0;
            width: 100%;
            height: 35px;
            background: #65AB40;
        }
        #footer
        {
            position: absolute;
            z-index: 2;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 70px;
            background: #444;
            padding: 0;
            border-top: 1px solid #444;
        }
        #wrapper
        {
            position: absolute;
            z-index: 1;
            top: 35px;
            bottom: 0px;
            left: 0;
            width: 100%;
            overflow: hidden;
        }
        #spanOrder #spanOrder
        {
            background: url(/Images/sub.gif) no-repeat;
            width: 50px;
            height: 25px;
            margin-top: 10px;
        }
        .tiaozheng li
        {
            width: 65px;
            margin-left: 5px;
        }
        #warp
        {
            height: 100%;
        }
        .renshu
        {
            width: 60px;
            height: 23px;
            border: 1px solid #8C8955;
            padding-left: 2px;
            margin-bottom: 5px;
        }
    </style>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <script type="text/javascript" src="/js/jq.mobi.min.js"></script>

    <script type="text/javascript">

        var myScroll;

        function loaded() {
            if (document.referrer != undefined && document.referrer.indexOf("SaoMiao.aspx", 0) > 0)
                $("#hyGoBack").css("display", "none");
            myScroll = new iScroll('wrapper', { mouseWheel: true, click: true, checkDOMChanges: true
            });

            $(".pro_content li").each(
		function(i) {
		    $(this).attr("li_index", i + 1);
		    $(this).bind("click", function(i) {
		        $(".pro_content li").removeClass("active");
		        $(i.target).addClass("active");
		        $(".contentbox div").hide();
		        $(".contentbox > div:nth-child(" + $(this).attr("li_index") + ")").show();
		        myScroll.refresh();
		    });
		}
	);
        }

        document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
        document.addEventListener('DOMContentLoaded', loaded, false);



        function content_tab() {


        }



    </script>

</head>
<body>
    <input type="hidden" id="yhm" value="<%=yhm %>" />
    <input type="hidden" id="hybh" value="<%=hybh %>" />
    <div class="warp" id="warp">
        <div id="header" class="Btitle">
            让旅游精彩人生</div>
        <div style="overflow: hidden;" id="wrapper">
            <div style="transition-property: transform; transform-origin: 0px 0px 0px; transform: translate(0px, -72px) scale(1) translateZ(0px);"
                id="scroller">
                <div class="product_box">
                    <div class="product_xx fixed">
                        <div class="imgbox">
                            <img id="shareImg" src="<%=getProImg(EyouSoft.Common.Utils.GetQueryStringValue("id") ) %>"
                                alt="" />
                        </div>
                        <dl>
                            <dt>
                                <asp:Label ID="lbl_ProName" runat="server" Text=""></asp:Label>
                                <input type="hidden" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("id")%>"
                                    id="hidpid" />
                            </dt>
                            <dd>
                                <p>
                                    市场价: <font style="text-decoration: line-through">
                                        <%=shichangjia %></font><br>
                                    APP价: <font class="fontprice">
                                        <%=appjia %></font></p>
                                <span id="spanResult" runat="server">
                                    <input type="text" id="orderNum" name="orderNum" class="renshu" value="录入数量" />
                                    <br />
                                    <a id="sendOrder" href="javascript:;">
                                        <img src="/images/xiadan.png" /></a></span>
                            </dd>
                            <dd class="tel">
                                <a href="tel:<%=dianhua %>">
                                    <%=dianhua %></a></dd>
                        </dl>
                    </div>
                    <asp:PlaceHolder runat="server" ID="phTianJiaDaoWeiDian" Visible="false">
                        <div class="div_wd">
                            <asp:Literal runat="server" ID="ltrTianJiaDaoWeiDian"><a class="wd_btn" href="javascript:void(0)" id="a_tianjiadaoweidian">添加到微店</a></asp:Literal></div>
                    </asp:PlaceHolder>
                    <asp:Literal ID="lit_Menu" runat="server"></asp:Literal>
                    <div class="pro_dianpin">
                        <h3>
                            <span>点评<font style="font-size: 12px;" id="msgCount">（共<%=pinglunshu %>条）</font></span><a><img
                                src="/images/dianp.png" width="80" onclick='$(".fabiaopl").show();myScroll.refresh();	'></a></h3>
                        <div style="display: none;" class="fabiaopl" id="1">
                            <div class="fb_user">
                                <img src="/images/userpic.gif" width="45"></div>
                            <div class="fb_bg">
                                <textarea cols="2" rows="2" id="commsg" name></textarea>
                                <div>
                                    <a onclick='pageOpt.GetAjaxData("save");'></a>
                                </div>
                            </div>
                        </div>
                        <div id="commlist" class="dianp_box">
                        </div>
                        <div>
                            <img src="/images/pro_b.png" width="300" /></div>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            var pageOpt = {
                GetAjaxData: function(type) {
                    if (type == "save") {
                        var isLogin = $("#hybh").val();
                        if (isLogin == "") {
                            alert("请先登录再操作！")
                            location.href = "/AppPage/weixin/Login.aspx?rurl=" + location.href;
                        }
                        if ($("#commsg").val().trim() == "") {
                            alert("请填写评论内容！");
                            return false
                        }
                    }
                    var ajaxurl = "/CommonPage/ajaxCommentList.aspx?";
                    //AJAX 加载数据
                    $("#commlist").html("<div style='width:100%; text-align:center;'><img src='/images/loadingnew.gif' border='0' align='absmiddle'/>&nbsp;正在加载,请等待....&nbsp;</div>");

                    var para = { pid: $("#hidpid").val(), context: $("#commsg").val(), dotype: type };
                    var url = ajaxurl + $.param(para);
                    $.ajax({
                        type: "Get",
                        url: url,
                        cache: false,
                        success: function(result) {
                            $("#commlist").html(result);
                            $("#msgCount").html("（共" + $("#hidCount").val() + "条）");
                            $("#commsg").val("");
                        }
                    });
                }, //
                UnBindBtn: function() {
                    $("#sendOrder").unbind("click");
                },
                //按钮绑定事件
                BindBtn: function() {
                    $("#sendOrder").click(function() {
                        pageOpt.DownOrder();
                        return false;
                    });
                },
                DownOrder: function() {
                    var isLogin = $("#hybh").val();
                    if (isLogin == "") {
                        alert("请先登陆再操作！")
                        location.href = "/AppPage/weixin/Login.aspx?rurl=" + location.href;
                    }
                    var url = { type: "DownOrder", pid: $("#hidpid").val(), renshu: $("#orderNum").val(), weidianid: "<%=WeiDianId %>" };
                    pageOpt.UnBindBtn();
                    $.ajax({
                        type: "post",
                        url: "/CommonPage/ajaxDownOrder.aspx?" + $.param(url),
                        cache: false,
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                alert(ret.msg);
                                location.href = "/AppPage/weixin/orderlist.aspx";
                            }
                            else if (ret.result == "99") {
                                alert(ret.msg);
                                location.href = "/AppPage/weixin/GoPay.aspx?OrderId=" + ret.obj;
                            }
                            else if (ret.result = "2") {
                                alert(ret.msg);
                                location.href = "/AppPage/weixin/Login.aspx?rurl=" + location.href;
                            }
                            else {
                                alert(ret.msg);
                            }
                            pageOpt.BindBtn();
                        }
                    });
                }
            };
            $(function() {
                $("#fabiaopl").css("display", "none");
                pageOpt.GetAjaxData();
                $("#sendOrder").click(function() {
                    if ((/^[-\+]?\d+$/.test($("#orderNum").val().trim())) && $("#orderNum").val() != "") {
                        pageOpt.DownOrder();
                    }
                    else {
                        alert("订单人数格式错误或者为空请核对后提交!");
                        return false;
                    }
                })//
                $("#orderNum").click(function() {
                    $(this).val("");
                })//
            })
        </script>

        <script type="text/javascript">
function report(link, fakeid, action_type){
        return;
}
function htmlDecode(str){
    return str
          .replace(/&#39;/g, '\'')
          .replace(/<br\s*(\/)?\s*>/g, '\n')
          .replace(/&nbsp;/g, ' ')
          .replace(/&lt;/g, '<')
          .replace(/&gt;/g, '>')
          .replace(/&quot;/g, '"')
          .replace(/&amp;/g, '&');
}

(function(){

  function onBridgeReady() {

      var appId  = '',
        imgUrl = "http://www.4008005216.com<%= getProImg(EyouSoft.Common.Utils.GetQueryStringValue("id") ) %>",
        link   = "<%=Request.Url%>&from=groupmessage&isappinstalled=0#mp.weixin.qq.com",
        title  = htmlDecode("<% =lbl_ProName.Text%>"),
        desc   = htmlDecode("<%=EyouSoft.Common.Function.StringValidate.SafeHtmlEndcode(descript)%>"),
        fakeid = "";
        desc   = desc || link;
      if( "1" == "0" ){
          WeixinJSBridge.call("hideOptionMenu");  
      }

        // 发送给好友; 
        WeixinJSBridge.on('menu:share:appmessage', function(argv){
                    WeixinJSBridge.invoke('sendAppMessage',{
                                          "appid"      : appId,
                                          "img_url"    : imgUrl,
                                          "img_width"  : "640",
                                          "img_height" : "640",
                                          "link"       : link,
                                          "desc"       : desc,
                                          "title"      : title
                    }, function(res) {
                    });
        });
        // 分享到朋友圈;
        WeixinJSBridge.on('menu:share:timeline', function(argv){
                    report(link, fakeid, 2);
                    WeixinJSBridge.invoke('shareTimeline',{
                                          "img_url"    : imgUrl,
                                          "img_width"  : "640",
                                          "img_height" : "640",
                                          "link"       : link,
                                          "desc"       : desc,
                                          "title"      : title
                    }, function(res) {
                    });
        });
		
        // get network type
		var nettype_map = {
			"network_type:fail" : "fail",
			"network_type:edge": "2g",
			"network_type:wwan": "3g",
			"network_type:wifi": "wifi"
		};
		if (typeof WeixinJSBridge != "undefined" && WeixinJSBridge.invoke){
			WeixinJSBridge.invoke('getNetworkType',{}, function(res) {
				networkType = nettype_map[res.err_msg];
				initpicReport();
			});
		} }

    if (typeof WeixinJSBridge == "undefined"){
        if( document.addEventListener ){
            document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
        }else if (document.attachEvent){
            document.attachEvent('WeixinJSBridgeReady', onBridgeReady); 
            document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
        }
    }else{
        onBridgeReady();
    }
    
})();

        </script>

        <script type="text/javascript">
            $(document).ready(function() {
                $("#a_tianjiadaoweidian").click(function() {
                    var _data = { txtChanPinId: "<%=ChanPinId %>" };

                    function __callback(response) {
                        alert(response.msg);
                        window.location.href = window.location.href;
                    }

                    $.ajax({ type: "POST", url: window.location.href + "&doType=tianjiadaoweidian", data: _data, cache: false, dataType: "json", async: false,
                        success: function(response) {
                            __callback(response);
                        },
                        error: function() { }
                    });
                });

                $("#a_tianjiadaoweidian_yitianjia").click(function() {
                    alert("你已经添加该产品到微店");
                });

            });

    
    
        </script>

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
            var imgUrl = "http://www.4008005216.com" + $("#shareImg").attr("src");
            var shareTitle = "<% =lbl_ProName.Text%>";
            var lineLink = location.href;
            var descContent = "<%=EyouSoft.Common.Function.StringValidate.SafeHtmlEndcode(descript)%>";
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

    </div>
</body>
</html>
