<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productinfo.aspx.cs" Inherits="Eyousoft_yhq.Web.productinfo" %>

<!DOCTYPE html  >
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <title>产品详情查看</title>
    <link href="/css/style.css " type="text/css" rel="stylesheet">
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
            bottom: 48px;
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
        .renshu
        {
            width: 60px;
            height: 23px;
            border: 1px solid #8C8955;
            padding-left: 2px;
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
    <div class="warp">
        <div id="header" class="Btitle">
            <a href="javascript:history.go(-1)" id="hyGoBack">
                <img src="/images/fanhui.png" style="margin-top: 5px"></a> 让旅游精彩人生</div>
        <div style="overflow: hidden;" id="wrapper">
            <div style="transition-property: transform; transform-origin: 0px 0px 0px; transform: translate(0px, -72px) scale(1) translateZ(0px);"
                id="scroller">
                <div class="product_box">
                    <div class="product_xx fixed">
                        <div class="imgbox">
                            <img src="<%= getProImg(EyouSoft.Common.Utils.GetQueryStringValue("id") ) %>" alt="" />
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
                                    <input type="text" id="orderNum" name="orderNum" class="renshu" value="人数" /><br />
                                    <a id="sendOrder" href="javascript:;">
                                        <img src="/images/xiadan.png" /></a></span>
                            </dd>
                            <dd class="tel">
                                <a href="tel:<%=dianhua %>">
                                    <%=dianhua %></a></dd>
                        </dl>
                    </div>
                    <div class="icon">

                        <script type="text/javascript" charset="utf-8">
                            (function() {
                                var _w = 90, _h = 24;
                                var param = {
                                    url: location.href,
                                    type: '2',
                                    count: '',
                                    appkey: '',
                                    title: ' ',
                                    pic: '',
                                    ralateUid: '',
                                    language: 'zh_cn',
                                    dpc: 1
                                }
                                var temp = [];
                                for (var p in param) {
                                    temp.push(p + '=' + encodeURIComponent(param[p] || ''))
                                }
                                document.write('<iframe allowTransparency="true" frameborder="0" scrolling="no" src="http://service.weibo.com/staticjs/weiboshare.html?' + temp.join('&') + '" width="' + _w + '" height="' + _h + '"></iframe>')
                            })()
                        </script>

                    </div>
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
        <div class="footer" id="footer">
            <ul>
                <li>&nbsp;&nbsp;<a href="/AppPage/Default.aspx"><img src="/images/shouye.png" /></a></li>
                <li>&nbsp;&nbsp;<a href="/AppPage/register.aspx"><img src="/images/huiyuan.png" /></a></li>
            </ul>
        </div>

        <script type="text/javascript">
            var pageOpt = {
                GetAjaxData: function(type) {
                    if (type == "save") {
                        var isLogin = $("#hybh").val();
                        if (isLogin == "") {
                            alert("请先登录再操作！")
                            location.href = "/AppPage/App_login.aspx?rurl=" + location.href;
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
                        alert("请先登录再操作！")
                        location.href = "/AppPage/App_login.aspx?rurl=" + location.href;
                    }
                    var url = { type: "DownOrder", pid: $("#hidpid").val(), renshu: $("#orderNum").val() };
                    pageOpt.UnBindBtn();
                    $.ajax({
                        type: "post",
                        url: "/CommonPage/ajaxDownOrder.aspx?" + $.param(url),
                        cache: false,
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                alert(ret.msg);
                                location.href = "/AppPage/orderlist.aspx";
                            }
                            else if (ret.result == "99") {
                                alert(ret.msg);
                                location.href = "/AliPay/default.aspx?OrderId=" + ret.obj;
                            }
                            else if (ret.result = "2") {
                                alert(ret.msg);
                                location.href = "/AppPage/App_login.aspx?rurl=" + location.href;
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
                $("#sendMsg").click(function() {
                    var isLogin = $("#hybh").val();
                    if (isLogin == "") {
                        alert("请先登录再操作！")
                        location.href = "/AppPage/App_login.aspx?rurl=" + location.href;
                    }
                    var sendMsg = { mark: 1, pid: $("#hidpid").val(), cid: $("#yhm").val() };
                    $.ajax({
                        type: "Get",
                        url: "/CommonPage/ajaxSendMSG.aspx?" + $.param(sendMsg),
                        cache: false,
                        success: function(result) {
                            if (result == "成功") {
                                alert("你已成功领取此产品优惠券！")
                            }
                            else {
                                alert(result);
                            }
                        }
                    });
                })//
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

    </div>
</body>
</html>
