<%@ Page Language="C#" Title="订单中心" MasterPageFile="~/masterPage/HuiYuan.Master"
    AutoEventWireup="true" CodeBehind="orderlist.aspx.cs" Inherits="Eyousoft_yhq.Web.orderlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <input id="pageindex" type="hidden" value="<%=pageIndex %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dindanList" style="margin: 0px auto;">
        <h3>
            <a id="PayOn" href="/AppPage/orderlist.aspx?OrderType=<%=(int)Eyousoft_yhq.Model.PaymentState.已支付 %>">
                已付款</a><a id="PayOut" href="/AppPage/orderlist.aspx?OrderType=<%=(int)Eyousoft_yhq.Model.PaymentState.未支付 %>">待付款</a></h3>
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
                                                <%#   Convert.ToDecimal(Eval("OrderPrice")).ToString("C0")%></span><span class="daifu"><%# BindZhiFuBao(Eval( "OrderId").ToString(), Eval("OrderState"), Eval( "PayState"), Eval( "XiaoFei"))%></span></p>
                                    </div>
                                </div>
                                <div id="LM<%# Container.ItemIndex+1 %>" class="load" style="display: none;">
                                    <%#DownFile(Eval("SendFile"))%><a href="/AppPage/ZxingCode/CodeBox.aspx?id=<%# Eval( "OrderId") %>">[查看二维码]</a></div>
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

    <script type="text/javascript">
        var PageIn = {
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

</asp:Content>
