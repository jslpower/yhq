<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownApp.aspx.cs" Inherits="Eyousoft_yhq.Web.DownApp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=Ititle %></title>
    <meta name="Keywords" content="<%=KeyWords %>" />
    <meta name="Description" content="<%=Description %>" />
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script language="javascript" src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="down_head">
            <div class="down_headbox">
                <img src="images/logo2.gif" /></div>
        </div>
        <div class="downbg">
            <div class="down_mainbg">
                <div class="down_box">
                    <div class="downbtn">
                        <a href="javascript:;">
                            <img src="images/a_downbtn.png" /></a></div>
                    <dl class="down_msg">
                        <dt>短信下载：</dt>
                        <dd>
                            <input name="" type="text" class="down_input" id="TEL" />
                            <input type="button" value="点击获取" class="huoqu_btn" id="btnCode" />
                        </dd>
                        <dd class="tip">
                            输入手机号码，在手机上直接下载。（短信免费）</dd>
                    </dl>
                    <dl class="down_code">
                        <dt>二维码下载：</dt>
                        <dd>
                            <img src="images/h_pic.jpg" /></dd>
                    </dl>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            configSecond: 60,
            GetNumber: function() {
                $("#btnCode").attr("disabled", "disabled");
                $("#btnCode").val(pageOpt.configSecond + "秒后可再获取")
                pageOpt.configSecond--;
                if (pageOpt.configSecond >= 0) {
                    setTimeout(pageOpt.GetNumber, 1000);
                }
                else {
                    $("#btnCode").removeAttr("disabled");
                    pageOpt.configSecond = 60;
                    $("#btnCode").val("点击获取");
                }
            }
        };
        $(function() {
            $("#btnCode").click(function() {
                if (!(/^(13|15|18|14)\d{9}$/.test($.trim($("#TEL").val())))) {
                    tableToolbar._showMsg("手机号码格式错误");
                    return false;
                };
                pageOpt.GetNumber();
                $.ajax({
                    type: "get",
                    url: "/CommonPage/ajaxSendMSG.aspx?SendAppMark=1&Tel=" + $("#TEL").val(),
                    success: function(result) {

                        tableToolbar._showMsg(result);

                    }
                }); //发送下载地址
            })
        });
    </script>

</body>
</html>
