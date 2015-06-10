<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eyousoft_yhq.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
        <title>主页</title>
        <link href="/css/style.css?v=4" type="text/css" rel="stylesheet" />
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
            #scroller1
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
            #scroller
            {
                width: 1600px;
                height: 100%;
                float: left;
                padding: 0;
            }
            #header
            {
                position: absolute;
                z-index: 5;
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
                position: relative; /* On older OS versions "position" and "z-index" must be defined, */
                margin: 0 auto;
                width: 320px;
                height: 160px;
                z-index: 2; /* it seems that recent webkit is less picky and works anyway. */
                top: 82px;
            }
            #wrapper1
            {
                position: fixed;
                z-index: 1;
                top: 1px;
                bottom: 32px;
                left: 0;
                width: 100%;
                overflow: hidden;
            }
            #scroller ul
            {
                list-style: none;
                display: block;
                float: left;
                width: 100%;
                height: 100%;
                padding: 0;
                margin: 0;
                text-align: left;
            }
            #scroller li
            {
                -webkit-box-sizing: border-box;
                -moz-box-sizing: border-box;
                -o-box-sizing: border-box;
                box-sizing: border-box;
                display: block;
                float: left;
                width: 320px;
                height: 160px;
                text-align: center;
                font-family: georgia;
                font-size: 18px;
                line-height: 140%;
            }
            #nav
            {
                width: 100px;
                top: 60px;
                z-index: 2;
                position: relative;
                margin: 0 auto;
            }
            #indicator, #indicator > li
            {
                display: block;
                float: left;
                list-style: none;
                padding: 0;
                margin: 0;
            }
            #indicator
            {
                width: 110px;
                padding: 12px 0 0 30px;
            }
            #indicator > li
            {
                text-indent: -9999em;
                width: 8px;
                height: 8px;
                -webkit-border-radius: 4px;
                -moz-border-radius: 4px;
                -o-border-radius: 4px;
                border-radius: 4px;
                background: #ddd;
                overflow: hidden;
                margin-right: 4px;
            }
            #indicator > li.active
            {
                background: #888;
            }
            #indicator > li:last-child
            {
                margin: 0;
            }
        </style>

        <script type="text/javascript" src="/js/iscroll.js"></script>

        <script type="text/javascript" src="/js/jq.mobi.min.js"></script>

        <script type="text/javascript">

            var myScroll;
            var myScroll1;

            function loaded() {




                myScroll1 = new iScroll('wrapper1', {
                    mouseWheel: true,
                    click: true,
                });
                
                myScroll = new iScroll('wrapper', {
                    snap: true,
                    momentum: false,
                    hScrollbar: false,
                    onScrollEnd: function() {
                        document.querySelector('#indicator > li.active').className = '';
                        document.querySelector('#indicator > li:nth-child(' + (this.currPageX + 1) + ')').className = 'active';
                    }
                });
            }

            document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
            document.addEventListener('DOMContentLoaded', loaded, false);


        </script>

    </head>
</head>
<body>
    <div style="background: none repeat scroll 0 0 #F0F1F4;" class="warp">
        <div class="Btitle" id="header">
            <a href="/AppPage/ZxingCode/SaoMiao.aspx" class="code">
                <img src="/images/code2.png" height=35></a> 让旅游精彩人生</div>
        <div class="searchbox">
            <div style="width: 300px; margin: 0 auto;">
                <select name="proType" id="proType">
                    <%=InitDropDownList()%>
                </select>
                <span class="fixed">
                    <input type="text" name="searchBox" id="searchBox"><a class="searchbtn" href="javascript:;"></a></span></div>
        </div>
        <div id="wrapper1">
            <div id="scroller1">
                <div id="wrapper" style="overflow: hidden;">
                    <div id="scroller" style="transition-property: transform; transform-origin: 0px 0px 0px;
                        transform: translate(0px, 0px) translateZ(0px);">
                        <div id="a1">
                            <%=liImg %>
                        </div>
                    </div>
                </div>
                <div id="nav">
                    <%=li %>
                </div>
                <div class="piclist">
                    <%=fenlei %>
                </div>
            </div>
        </div>
        <div id="footer" class="footer">
            <ul>
                <li>&nbsp;&nbsp;<a href="/AppPage/Default.aspx"><img src="/images/shouye.png" /></a></li>
                <li>&nbsp;&nbsp;<a href="/AppPage/register.aspx"><img src="/images/huiyuan.png" /></a></li>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        $(function() {
            $(".searchbtn").click(function() {
                window.location.href = "/AppPage/productlist.aspx?productName=" + $("#searchBox").val() + "&proType=" + $("#proType").val();
            })

        })
    </script>

</body>
</html>
