<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouJiShiPin.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.YouJiShiPin" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link href="/css/weixin/basic.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/minpian.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/youji.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #wapscroll
        {
            position: absolute;
            z-index: 1; /*  -webkit-touch-callout:none;*/
            -webkit-tap-highlight-color: rgba(0,0,0,0);
            width: 100%;
            padding: 0;
        }
        #wapscroll li
        {
            padding: 0 10px;
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
        #wrapper
        {
            position: fixed;
            z-index: 1;
            top: 48px;
            bottom: 5px;
            left: 0;
            width: 100%;
            overflow: hidden;
        }
        /**
 *
 * Pull down styles
 *
 */#pullDown, #pullUp
        {
            background: #fff;
            height: 40px;
            line-height: 40px;
            padding: 5px 10px;
            border-bottom: 1px solid #ccc;
            font-weight: bold;
            font-size: 14px;
            color: #888;
        }
        #pullDown .pullDownIcon, #pullUp .pullUpIcon
        {
            display: block;
            float: left;
            width: 40px;
            height: 40px;
            background: url(pull-icon@2x.png) 0 0 no-repeat;
            -webkit-background-size: 40px 80px;
            background-size: 40px 80px;
            -webkit-transition-property: -webkit-transform;
            -webkit-transition-duration: 250ms;
        }
        #pullDown .pullDownIcon
        {
            -webkit-transform: rotate(0deg) translateZ(0);
        }
        #pullUp .pullUpIcon
        {
            -webkit-transform: rotate(-180deg) translateZ(0);
        }
        #pullDown.flip .pullDownIcon
        {
            -webkit-transform: rotate(-180deg) translateZ(0);
        }
        #pullUp.flip .pullUpIcon
        {
            -webkit-transform: rotate(0deg) translateZ(0);
        }
        #pullDown.loading .pullDownIcon, #pullUp.loading .pullUpIcon
        {
            background-position: 0 100%;
            -webkit-transform: rotate(0deg) translateZ(0);
            -webkit-transition-duration: 0ms;
            -webkit-animation-name: loading;
            -webkit-animation-duration: 2s;
            -webkit-animation-iteration-count: infinite;
            -webkit-animation-timing-function: linear;
        }
        @-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframesloading{from{-webkit-transform:rotate(0deg)translateZ(0);}
        to
        {
            -webkit-transform: rotate(360deg) translateZ(0);
        }
        }</style>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <script type="text/javascript" src="/js/jq.mobi.min.js"></script>

    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;

        function pullDownAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                for (i = 0; i < 10; i++) {
                    $(el).append("<li>Generated row " + (++generatedCount) + "</li>")
                }

                myScroll.refresh();
            }, 1000);
        }

        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                var huiyuanid = "<%= HuiYuanId%>"
                var para = { pageindex: $("#pageindex").val(), huiyuanid2: huiyuanid };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxYouJiList.aspx?" + $.param(para),
                    cache: false,
                    success: function(result) {
                        if (result != "" && result.length > 2) {
                            $(el).append(result);
                        }
                        else {
                            pullUpEl.querySelector('.pullUpLabel').innerHTML = '已加载至最后';
                        }
                    }
                });
                myScroll.refresh();
            }, 1000);
        }

        function loaded() {

            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight

            myScroll = new iScroll('wrapper', {
                mouseWheel: true,
                click: true,
                checkDOMChanges: true,
                onRefresh: function() {
                    if (pullUpEl.className.match('loading')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                    }
                },
                onScrollMove: function() {
                    if (this.y < (this.maxScrollY - 5) && !pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'flip';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '放开刷新..';
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.className.match('flip')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                        this.maxScrollY = pullUpOffset;
                    }
                },
                onScrollEnd: function() {
                    if (pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'loading';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '正在加载...';
                        pullUpAction();
                    }
                }
            });
        }

        document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
        document.addEventListener('DOMContentLoaded', loaded, false);

        function change(i) {
            if (i == 1) {
                $("#a1").show();
                $("#a2").hide();

            }
            else {
                $("#a2").show();
                $("#a1").hide();
            }

            myScroll.scrollToPage(0, 0, 100);


        }


    </script>

</head>
<body>
    <div class="warp">
        <div class="youji_head">
            <ul>
                <li><a href="YouJiList.aspx?huiyuanid2=<%= EyouSoft.Common.Utils.GetQueryStringValue("huiyuanid2") %>">
                    图文</a></li>
                <li><a href="javascript:;" class="on">视频</a></li>
            </ul>
        </div>
        <div id="wrapper">
            <div id="scroller">
                <div id="a1">
                    <div class="guwen_list">
                        <ul class="linelist" id="linelist">
                            <asp:Repeater ID="RepList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="youji_title" data-yjid="<%# Eval("YouJiId")%>">
                                            <a href="<%# Eval("shipinlink") %>">
                                                <%# Eval("YouJiTitle")%></a></div>
                                        <div class="guwen_head">
                                            <div class="guwen_touxian radius">
                                                <img src="<%=TuXiangFilepath %>"></div>
                                            <div class="guwen_name">
                                                <%= XingMing%></div>
                                            <div class="font12">
                                                <%# Convert.ToDateTime(Eval("IssueTime")).ToShortDateString()%>
                                            </div>
                                            <% if (IsMy)
                                               { %>
                                            <a href="javascript:;" class="btn2 edit">编辑</a> <a href="javascript:void(0)" class="btn">
                                                删除</a>
                                            <%} %>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                                <li style="height: 48px; line-height: 40px; font-size: 14px; color: #666; text-align: center;">
                                    暂未发布分享</li>
                            </asp:PlaceHolder>
                        </ul>
                    </div>
                </div>
                <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <div id="pullUp">
                        <span class="pullUpIcon"></span><span class="pullUpLabel"></span>
                    </div>
                </asp:PlaceHolder>--%>
                <asp:PlaceHolder runat="server" ID="PlaceHolder1">
                    <div id="pullUp">
                        <span class="pullUpIcon"></span><span class="pullUpLabel">上拉加载更多...</span>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
    <input id="pageindex" type="hidden" value="1" />
    <div class="bot">
        <div class="bot_box">
            <a href="javascript:;" class="y_btn">分享经历 分享精彩</a>
        </div>
    </div>
</body>

<script type="text/javascript">
    $(function() {
        $(".btn").click(function() {
            var yjid = $(this).closest("li").find(".youji_title").attr("data-yjid");
            var _data = { youjid: yjid };
            if (confirm("确认删除操作？")) {
                $.ajax({ type: "POST", url: "/HuiYuanWeiXin/YouJiShiPin.aspx?doType=DelYouJi", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        location.href = window.location.href;
                    },
                    error: function() { }
                });
            }
        });
        $(".edit").click(function() {
            var yjid = $(this).closest("li").find(".youji_title").attr("data-yjid");
            var url = "/HuiYuanWeiXin/YouJiShiPinAdd.aspx?yid=" + yjid + "&huiyuanid2=" + '<%= EyouSoft.Common.Utils.GetQueryStringValue("huiyuanid2") %>';
            location.href = url;
        })
        $(".y_btn").click(function() {
            var url = "/HuiYuanWeiXin/YouJiShiPinAdd.aspx?huiyuanid2=" + '<%= EyouSoft.Common.Utils.GetQueryStringValue("huiyuanid2") %>';
            location.href = url;
        })
    })
</script>

</html>
