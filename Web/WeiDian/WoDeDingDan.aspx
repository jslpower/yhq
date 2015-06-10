<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoDeDingDan.aspx.cs" Inherits="Eyousoft_yhq.Web.WeiDian.WoDeDingDan" MasterPageFile="~/MP/WeiDian.Master" Title="我的微店订单" %>

<%@ MasterType VirtualPath="~/MP/WeiDian.Master" %>
<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link href="/css/style.css?v=0.0.0.5" type="text/css" rel="stylesheet" />
    <style type="text/css">

html {
	-ms-touch-action: none;
}

body,ul,li {
	padding: 0;
	margin: 0;
	border: 0;
}

body {
	overflow: hidden; /* this is important to prevent the whole page to bounce */
}


#scroller {
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



#header {
	position: absolute;
	z-index: 2;
	top: 0;
	left: 0;
	width: 100%;
	height: 35px;
	
	background: #65AB40;
}

#footer {
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

#wrapper {
	position: absolute;
	z-index: 1;
	top: 82px;
	bottom: 48px;
	left: 0;
	width: 100%;
	overflow: hidden;
}


/**
 *
 * Pull down styles
 *
 */
#pullDown, #pullUp {
	background:#fff;
	height:40px;
	line-height:40px;
	padding:5px 10px;
	border-bottom:1px solid #ccc;
	font-weight:bold;
	font-size:14px;
	color:#888;
}
#pullDown .pullDownIcon, #pullUp .pullUpIcon  {
	display:block; float:left;
	width:40px; height:40px;
	background:url(pull-icon@2x.png) 0 0 no-repeat;
	-webkit-background-size:40px 80px; background-size:40px 80px;
	-webkit-transition-property:-webkit-transform;
	-webkit-transition-duration:250ms;	
}
#pullDown .pullDownIcon {
	-webkit-transform:rotate(0deg) translateZ(0);
}
#pullUp .pullUpIcon  {
	-webkit-transform:rotate(-180deg) translateZ(0);
}

#pullDown.flip .pullDownIcon {
	-webkit-transform:rotate(-180deg) translateZ(0);
}

#pullUp.flip .pullUpIcon {
	-webkit-transform:rotate(0deg) translateZ(0);
}

#pullDown.loading .pullDownIcon, #pullUp.loading .pullUpIcon {
	background-position:0 100%;
	-webkit-transform:rotate(0deg) translateZ(0);
	-webkit-transition-duration:0ms;

	-webkit-animation-name:loading;
	-webkit-animation-duration:2s;
	-webkit-animation-iteration-count:infinite;
	-webkit-animation-timing-function:linear;
}

@-webkit-keyframes loading {
	from { -webkit-transform:rotate(0deg) translateZ(0); }
	to { -webkit-transform:rotate(360deg) translateZ(0); }
}
</style>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <script type="text/javascript" src="/js/jq.mobi.min.js"></script>

    <script type="text/javascript" src="/js/utilsUri.js"></script>

    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset, pullUpEl, pullUpOffset, generatedCount = 0;

        function pullDownAction() {
            
        }

        function pullUpAction() {
            $("#pullUp").show();
            var _params = utilsUri.getUrlParams(["page", "jiazaigengduo"]);
            _params["page"] = parseInt($("#txtPageIndex").val()) + 1;
            _params["jiazaigengduo"] = "1";
            $("#txtPageIndex").val(_params["page"]);

            function __callback(response) {
                if (response.result != "1") {
                    var _pullUpEl = document.getElementById('pullUp');
                    _pullUpEl.className = '';
                    _pullUpEl.querySelector('.pullUpLabel').innerHTML = '已经没有更多了...';
                    $("#txtPageIndex").val(_params["page"]-1);
                    return;
                }

                $("#ul_dingdan").append(response.obj.html);
            }

            $.ajax({ type: "get", url: "wodedingdan.aspx?" + $.param(_params), cache: false, dataType: "json", async: true,
                success: function(response) {
                    __callback(response);
                },
                error: function() { }
            });
        }

        function loaded() {
            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight;

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
    </script>

</asp:Content>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <input id="txtPageIndex" type="hidden" value="1" />
    <div class="warp">
        <div id="header" class="Btitle">
            我的微店订单</div>
        
        <div id="wrapper" style="bottom:0px;top:40px;">
            <div id="scroller">
                <div id="a1">
                    <ul class="linelist" id="ul_dingdan">
                        <asp:Repeater runat="server" ID="rpt">
                            <ItemTemplate>
                                <li data-class="li_dingdan_item" data-chanpinid="<%#Eval("ChanPinId") %>" data-dingdanid="<%#Eval("DingDanId") %>" style="border-bottom: 1px dashed #bebebe">
                                    <div class="item">
                                        <div class="imgArea">
                                            <a href="/apppage/weixin/productinfo.aspx?id=<%#Eval("ChanPinId") %>&weidianid=<%#WeiDianId %>">
                                                <img src="<%#GetTuPianFilepath(Eval("ChanPinTuPianFilepath")) %>" /></a><div class="new">
                                                </div>
                                        </div>
                                        <dl>
                                            <dt><a href="/apppage/weixin/productinfo.aspx?id=<%#Eval("ChanPinId") %>&weidianid=<%#WeiDianId %>">
                                                <%#Eval("ChanPinName") %></a></dt>
                                            <dd>
                                                <span class="price" style="width: 100%; font-size:16px; line-height:35px;">订单金额：<font>¥</font><%#Eval("JinE","{0:F2}") %></span>
                                            </dd>
                                            <dd class="font_pl" style="font-size:16px; font-weight:bold;">
                                                <%#GetDingDanStatus(Eval("ShenHeStatus"),Eval("DingDanStatus"),Eval("ZhiFuStatus"),Eval("XiaoFeiStatus"))%>    
                                            </dd>
                                        </dl>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                            <li style="height: 96px; line-height: 40px; font-size: 14px; color: #666;">你的微店暂无订单哦</li>
                        </asp:PlaceHolder>
                    </ul>
                    <asp:PlaceHolder runat="server" ID="phShangLaJiaZai">
                        <div id="pullUp">
                            <span class="pullUpIcon"></span><span class="pullUpLabel">上拉加载更多...</span>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            }
        };

        $(document).ready(function() {
        
        })
    </script>

</asp:Content>
