<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单列表</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <link href="/css/style.css" type="text/css" rel="stylesheet" />
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
            position: fixed;
            z-index: 2;
            top: 0;
            left: 0;
            width: 100%;
            height: 35px;
            background: #65AB40;
        }
        #footer
        {
            position: fixed;
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
            position: fixed;
            z-index: 2;
            top: 70px;
            bottom: 48px;
            left: 0;
            width: 100%;
            overflow: hidden;
        }
    </style>

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
                var para = { pageindex: $("#pageindex").val(), ordertype: '<%= EyouSoft.Common.Utils.GetQueryStringValue("ordertype") %>' };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxOrders.aspx?" + $.param(para),
                    cache: false,
                    success: function(result) {
                        if (result != "") {
                            $(el).append(result);
                            $('.list_msg').unbind('click');
                            $(".list_msg").bind("click", function() {
                                if ($(this).siblings().css("display") == "none") {
                                    $(".load").hide();
                                    $(this).siblings().show();
                                }
                                else {
                                    $(".load").hide();
                                }
                                myScroll.refresh();
                            });
                        }
                        else {
                            $(".pullUpLabel").html("没有更多了")
                        }
                    }
                });
                /*==============================================================*/

                //                for (i = 0; i < 8; i++) {
                //                    $(el).append("<li><a href=\"product_xx.html\"><div class=\"imgArea\"><img src=\"images/pic01.jpg\" /><div class=\"new\"></div></div><dl><dt>" + (++generatedCount) + "品江南之韵，感受水乡淳朴风情</dt><dd><span class=\"price\">&nbsp;&nbsp;<font class=\"font22\">¥</font>388</span><span class=\"price1\">&nbsp;&nbsp;¥388</span></dd><dd class=\"font_pl\"><img src=\"images/pl.gif\" />31条评论</dd></dl></a></li>")
                //                }

                myScroll.refresh(); 	// Remember to refresh when contents are loaded (ie: on ajax completion)
            }, 1000);         // <-- Simulate network congestion, remove setTimeout from production!
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

    <script type="text/javascript" src="/js/cordova-2.7.0.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <input id="pageindex" type="hidden" value="<%=pageIndex %>" />
    <div class="warp">
        <div id="header" class="Btitle">
            让旅游精彩人生</div>
        <div class="dindan_box">
            <div class="jp_nav">
                <ul class="fixed">
                    <li class="on"><a href="/AppPage/weixin/orderlist.aspx">旅游列表</a></li>
                    <li><a href="/AppPage/weixin/jp_Orders.aspx">机票列表</a></li>
                </ul>
            </div>
        </div>
        <div id="wrapper">
            <div class="dindanList" style="margin: 0px auto;">
                <h3>
                    <a id="PayOn" href="/AppPage/weixin/orderlist.aspx?OrderType=<%=(int)Eyousoft_yhq.Model.PaymentState.已支付 %>">
                        已付款</a><a id="PayOut" href="/AppPage/weixin/orderlist.aspx?OrderType=<%=(int)Eyousoft_yhq.Model.PaymentState.未支付 %>">待付款</a></h3>
                <div id="scroller">
                    <div id="a1">
                        <ul id="linelist">
                            <asp:Repeater ID="rpt_orders" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="list_msg" data-id="">
                                            <div class="dd_pic">
                                                <img src="<%# getProImg(Eval("ProductID").ToString())%>"></div>
                                            <div class="dd_right">
                                                <div class="title">
                                                    <%#  Eval("ProductName")%></div>
                                                <p>
                                                    <span class="price">
                                                        <%#   Convert.ToDecimal(Eval("OrderPrice")).ToString("C0")%></span><%# BindZhiFuBao(Eval( "OrderId").ToString(), Eval("OrderState"), Eval( "PayState"), Eval( "XiaoFei"))%></p>
                                            </div>
                                        </div>
                                        <div id="LM<%# Container.ItemIndex+1 %>" class="load" style="display: none;">
                                            <%#DownFile(Eval("SendFile"), Eval("OrderId").ToString())%><a href="/AppPage/ZxingCode/CodeBox.aspx?id=<%# Eval( "OrderId") %>">[查看二维码]</a></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <asp:Literal ID="litMsg" runat="server" Visible="false">暂无数据</asp:Literal>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                            <div id="pullUp">
                                <span class="pullUpIcon"></span><span class="pullUpLabel">上拉更新...</span>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var PageIn = {
            save: function(obj) {
                if (window.confirm("确认支付?")) {
                    $(".yueZF").unbind("click");
                    $.ajax({
                        type: "post",
                        url: "/AppPage/weixin/OrderList.aspx?zf=1&id=" + $(obj).attr("data-id"),
                        dataType: "json",
                        success: function(ret) {
                            alert(ret.msg);
                            $(".yueZF").bind("click", function() { PageIn.save() })
                        },
                        error: function() {
                            alert("未知错误！")
                            $(".yueZF").bind("click", function() { PageIn.save() })
                        }
                    });
                }
            },
            PageOnIn: function() {
                $("#PayOn").click(function() {
                    location.href = '/AppPage/orderlist.aspx?OrderType=' + '<%=(int)Eyousoft_yhq.Model.PaymentState.已支付 %>';
                });
                $("#PayOut").click(function() {
                    location.href = '/AppPage/orderlist.aspx?OrderType=' + '<%=(int)Eyousoft_yhq.Model.PaymentState.未支付 %>';
                });
            }
        };
        $(function() {

            var PayType = '<%=EyouSoft.Common.Utils.GetQueryStringValue("OrderType") %>';
            if (PayType == '<%=(int)Eyousoft_yhq.Model.PaymentState.已支付 %>') {

                $("#PayOn").addClass("on");
            }
            else {
                $("#PayOut").addClass("on");
            }
            PageIn.PageOnIn();
            $(".yueZF").click(function() {
                PageIn.save(this);
            })


            $('.list_msg').unbind('click');
            $(".list_msg").bind("click", function() {
                if ($(this).siblings().css("display") == "none") {
                    $(".load").hide();
                    $(this).siblings().show();
                }
                else {
                    $(".load").hide();
                }
                myScroll.refresh();
            });



            document.addEventListener("deviceready", onDeviceReady, false);

            last_click_time = new Date().getTime();
            document.addEventListener('click', function(e) {
                click_time = e['timeStamp'];
                if (click_time && (click_time - last_click_time) < 1000) {
                    e.stopImmediatePropagation();
                    e.preventDefault();
                    return false;
                }
                last_click_time = click_time;
            }, true);
            function onDeviceReady() {
                $(".DownLin").bind("click", function() {
                    var url = $(this).attr("data-down");
                    var ref = window.open(url, '_system', 'location=yes');
                });
            }

        });
        
    </script>

</body>
</html>
