<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.ProductList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品列表</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <link href="/css/style.css?v=0.0.0.4" type="text/css" rel="stylesheet" />
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
            top: 82px;
            bottom: 0px;
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
        @-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframesloading{from{-webkit-transform:rotate(0deg)translateZ(0);}
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
            setTimeout(function() {	// <-- Simulate network congestion, remove setTimeout from production!
                var el, li, i;
                el = document.getElementById('linelist');

                for (i = 0; i < 8; i++) {
                    $(el).append("<li>Generated row " + (++generatedCount) + "</li>")
                }

                myScroll.refresh(); 	// Remember to refresh when contents are loaded (ie: on ajax completion)
            }, 1000); // <-- Simulate network congestion, remove setTimeout from production!
        }

        function pullUpAction() {
            setTimeout(function() {	// <-- Simulate network congestion, remove setTimeout from production!
                var el, li, i;
                el = document.getElementById('linelist');
                /*==============================================================*/
                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                var para = { productName: $("[name=searchbox]").val(), mark: 1, pageindex: $("#pageindex").val(), isGet: 1, proType: '<%= EyouSoft.Common.Utils.GetQueryStringValue("proType") %>', xianlu: '<%= EyouSoft.Common.Utils.GetQueryStringValue("xianlu") %>', tuijian: '<%= EyouSoft.Common.Utils.GetQueryStringValue("tuijian") %>', weidianid: "<%=WeiDianId %>" };
                
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxProduct.aspx?" + $.param(para),
                    cache: false,
                    success: function(result) {
                        if (result != "") {
                            $(el).append(result);
                        }
                    }
                });
                /*==============================================================*/

                //                for (i = 0; i < 8; i++) {
                //                    $(el).append("<li><a href=\"product_xx.html\"><div class=\"imgArea\"><img src=\"images/pic01.jpg\" /><div class=\"new\"></div></div><dl><dt>" + (++generatedCount) + "品江南之韵，感受水乡淳朴风情</dt><dd><span class=\"price\">&nbsp;&nbsp;<font class=\"font22\">¥</font>388</span><span class=\"price1\">&nbsp;&nbsp;¥388</span></dd><dd class=\"font_pl\"><img src=\"images/pl.gif\" />31条评论</dd></dl></a></li>")
                //                }

                myScroll.refresh(); 	// Remember to refresh when contents are loaded (ie: on ajax completion)
            }, 1000);       // <-- Simulate network congestion, remove setTimeout from production!
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
                        pullUpAction(); // Execute custom function (ajax call?)
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
    <form id="form1" runat="server">
    <input id="pageindex" type="hidden" value="<%=pageindex %>" />
    <div class="warp">
        <div id="header" class="Btitle">
            让旅游精彩人生</div>
        <div class="searchbox">
            <div style="width: 310px; margin: 0 auto;">
                <select name="proType" id="proType" style="width:100px">
                    <%=InitDropDownList(EyouSoft.Common.Utils.GetQueryStringValue("proType"))%>
                </select>
                <span class="fixed" style="">
                    <input name="searchbox" type="text" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("productName") %>" /><a
                        href="javascript:;" class="searchbtn"></a></span></div>
        </div>
        <div id="wrapper">
            <div id="scroller">
                <div id="a1">
                    <ul class="linelist" id="linelist">
                        <asp:Repeater ID="rpt_list" runat="server">
                            <ItemTemplate>
                                <li><a href="productinfo.aspx?id=<%#Eval("ProductID") %>&weidianid=<%#WeiDianId %>">
                                    <div class="imgArea">
                                        <img src="<%# getProImg(Eval("ProductID").ToString()) %>" alt="" /><div class="new">
                                        </div>
                                    </div>
                                    <dl>
                                        <dt>
                                            <%#Eval("ProductName") %></dt>
                                        <dd>
                                            <span class="price">&nbsp;<%#Eval("AppPrice", "{0:c0}")%></span> <span class="price1">
                                                <%#Eval("MarketPrice", "{0:c0}")%></span>
                                        </dd>
                                        <dd class="font_pl">
                                            <img src="/images/pl.gif" alt="" />
                                            <%# getCommentNum(Eval("ProductID"))%>条评论 <span class="chutuan_date">
                                                <%# getdate(Eval("TourDate"), Eval("IsEveryDay"))%>出团</span>
                                        </dd>
                                    </dl>
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <div id="pullUp">
                            <span class="pullUpIcon"></span><span class="pullUpLabel">上拉更新...</span>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            $(".searchbtn").click(function() {
                window.location.href = "productlist.aspx?productName=" + $("[name=searchbox]").val() + "&proType=" + $("#proType").val() + "&xianlu=" + '<%= EyouSoft.Common.Utils.GetQueryStringValue("xianlu") %>' + "&tuijian=" + '<%= EyouSoft.Common.Utils.GetQueryStringValue("tuijian") %>'+"&weidianid=<%=WeiDianId %>";
            })
        })
    </script>

</body>
</html>
