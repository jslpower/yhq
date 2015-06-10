<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_SearchList.aspx.cs"
    Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_SearchList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" action="jp_gaiqian.aspx" method="post">
    <div class="header">
        <h1>
            航班选择</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216"
            class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="search_T">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <asp:Literal ID="litPrev" runat="server"></asp:Literal>
                    <td class="midd">
                        <a href="javascript:;">
                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label><img src="/images/center.gif" /></a>
                    </td>
                    <asp:Literal ID="litNext" runat="server"></asp:Literal>
                </tr>
            </table>
        </div>
    </div>
    <div class="mainbox">
        <div class="jipiao_list">
            <ul>
                <asp:Literal ID="litHTML" runat="server"></asp:Literal>
            </ul>
        </div>
    </div>
    <input type="hidden" id="jpgq" name="jpgq" />
    </form>
    <form id="form99" action="jp_Submit.aspx?weidianid=<%=WeiDianId %>" method="post" name="form99" visible="false">
    <input type="hidden" id="HBbox" name="HBbox" />
    <input type="hidden" id="JCbox" name="JCbox" />
    </form>
    <input type="hidden" id="hid_login" value="<%=isLogin %>" />

    <script type="text/javascript">
        $(function() {
            $(".jp-item").click(function() {
                if ($(this).parent().find(".down") != 'undefined' && $(this).parent().find(".down").length > 0) {
                    $(this).parent().find(".jp_more").show();
                    $(this).parent().find(".down").attr("class", "up");
                }
                else {
                    $(this).parent().find(".jp_more").hide();
                    $(this).parent().find(".up").attr("class", "down");
                }
            });
            $(".selectHB").click(function() {

                if ($(this).html() == "已满")
                { return false; }
                if ($("#hid_login").val() == "0") {
                    window.location.href = '/AppPage/weixin/Login.aspx?rurl=' + encodeURIComponent(window.location.href);
                    return false;
                }

                $("#JCbox").val($(this).attr("data-Id"));
                var hbinfo = $(this).parent().find("div").eq(0).html();
                $("#HBbox").val(hbinfo);
                $("#form99").get(0).submit();
            })
        })


        function showflightinfo(item, text) {
            $("#jpgq").val(text);
            //document.form1.action="jp_gaiqian.aspx";
            document.getElementById("form1").submit();
            //   window.location="jp_gaiqian.aspx?content="+text;
            //         var c =  event.pageY + 20;
            //                var d = event.pageX + 20
            // 
            //                var _h = $("#showgz").height();
            //                var _w = $("#showgz").width();
            //                var _wh = $(window).height();
            //                var _ww = $(window).width();
            //                //移动端往下滑时的定位层位置判断
            //                if (event.pageY + _h >= _wh) {
            //                   d = event.pageX - _w - 20;
            //                      c = event.pageY - _h;
            //                }
            //                if (event.pageX + _w >= _ww) {
            //               }
            //          var objDiv = $("#showgz"); 
            //          objDiv.html(text);
            //          $(objDiv).css("display","block"); 
            //          $(objDiv).css("left", d); 
            //          $(objDiv).css("top", c);


        }

        function showhide(item, text) {
            var objDiv = $("#showgz");
            $(objDiv).css("display", "none");
        }
    </script>

    <div id="showgfz" style="position: absolute; font-size: 12px; display: none; border: 1px solid silver;
        background: silver;">
    </div>
    <div id="showgz" style="position: absolute; font-size: 12px; width: 300px; height: 200px;
        display: none; border: 1px solid silver; background: silver;">
    </div>
</body>
</html>
