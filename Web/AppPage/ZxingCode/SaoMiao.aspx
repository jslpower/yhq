<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SaoMiao.aspx.cs"
    Inherits="Eyousoft_yhq.Web.AppPage.ZxingCode.SaoMiao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">

    <script type="text/javascript" src="/js/cordova.js"></script>

    <script type="text/javascript" src="/js/cordova_plugins.js"></script>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/eyou.core.js"></script>

</head>
<body>
    <div id="i_div_message">
    </div>
    <br />
    <div id="i_div_saomiao">
    </div>
    <div id="i_div_saomiaojieguo">
    </div>

    <script type="text/javascript">
        var INDEX = 1;
        function iSaoMiao() {
            var _$divsaomiaojieguo = $("#i_div_saomiaojieguo");
            var mark = '<%=Mark %>';
            var _options = {};
            _options.callback = function(winParam) {
                var qr = winParam.text; //编码内容
                var qrformat = winParam.format; //编码格式
                var cancelled = winParam.cancelled; //是否取消扫描

                if (cancelled) {
                    window.location.href = "/AppPage/Default.aspx";
                    return;
                }

                if (qr == "" || qr == undefined) {
                    return false;
                }
                if (qr.indexOf("yhq://") >= 0) {
                    window.location.href = qr.replace("yhq://", "http://");
                    return true;
                }
                var arrStr = qr.split('|');
                if (arrStr == "" || arrStr == undefined || arrStr.length == 0) {
                    alert("二维码信息有误！");
                    return false;
                }
                if (arrStr[0] == "product") {
                    window.location.href = '/AppPage/productinfo.aspx?id=' + arrStr[1];
                }
                else if ((arrStr[0] == "order" || arrStr[0] == "torder" || arrStr[0] == "jp") && mark == '1') {
                    $.ajax({
                        type: "post",
                        cache: false,
                        url: "/AppPage/ZxingCode/SaoMiao.aspx?chk=1&id=" + arrStr[1] + "&rnd=" + Math.random() + "&ordertype=" + arrStr[0],
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                alert("此订单已消费，不可重复使用！");
                                window.location.href = "/AppPage/Default.aspx";
                            }
                            else if (ret.result == "2") {
                                alert("未找到此订单！");
                                window.location.href = "/AppPage/Default.aspx";
                            }
                            else if (ret.result == "3") {
                                alert("订单尚未付款！");
                                window.location.href = "/AppPage/Default.aspx";
                            }
                            else if (ret.result == "4") {
                                alert("订单尚未出票！");
                                window.location.href = "/AppPage/Default.aspx";
                            }
                            else if (ret.result == "99") {
                                window.location.href = "/AppPage/ZxingCode/JpXiaoFei.aspx?id=" + arrStr[1] + "&ordertype=" + arrStr[0];
                            }
                            else if (ret.result == "0") {
                                window.location.href = "/AppPage/ZxingCode/XiaoFei.aspx?id=" + arrStr[1] + "&ordertype=" + arrStr[0];
                            }
                            else {
                                alert("订单信息错误！")
                                window.location.href = "/AppPage/Default.aspx";
                            }
                        }
                    });
                }
                else {
                    alert("二维码信息有误！");
                    window.location.href = "/AppPage/Default.aspx";
                }

                //_$divsaomiaojieguo.append('<p>' + INDEX + ':' + '编码类型：' + qrformat + '，内容：' + qr + '</p>');
                INDEX++;
            };

            _options.error = function(error) {
                alert('扫描异常：' + error);
            };
            _$divsaomiaojieguo.val("");
            // _$divsaomiaojieguo.append('<p>扫描开始.</p>');
            window.eYou.saoMiao(_options);
        }

        function loaded() {
            iSaoMiao();
        }

        document.addEventListener('deviceready', loaded, false);
    </script>

</body>
