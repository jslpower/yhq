<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
            z-index: 1;
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
        #warp
        {
            height: 100%;
        }
        .user_main
        {
            position: absolute;
            top: 35px;
        }
    </style>

    <script type="text/javascript" src="/js/iscroll.js"></script>

    <script type="text/javascript" src="/js/jq.mobi.min.js"></script>

    <script type="text/javascript">

var myScroll;

function loaded () {

	
	myScroll = new iScroll('wrapper', { mouseWheel: true, click: true,
	 });
}

document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);
document.addEventListener('DOMContentLoaded', loaded, false);


    </script>

</head>
<body>
    <form id="userForm" runat="server">
    <div id="wrapper">
        <div id="header" class="Btitle">
            让旅游精彩人生</div>
        <div class="user_main">
            <div class="user_box">
                <ul>
                    <li></li>
                    <li></li>
                    <li>手机号码：</li>
                    <li>
                        <input type="text" class="formsize400 inputbg" name="userName" /></li>
                    <li>密码：</li>
                    <li>
                        <input type="password" class="formsize400 inputbg" name="userPwd" /></li>
                    <li></li>
                    <li></li>
                </ul>
                <div>
                    <img width="280" style="vertical-align: top" src="/images/user-boxB.png" /></div>
            </div>
            <div class="btn">
                <a href="javascript:;" id="loginBtn" onclick=" return userLogin.loginFn();">
                    <img width="200px" src="/images/login_btn.png" /></a>
                <br />
                <p>
                    &nbsp;
                </p>
                <a href="Register.aspx" id="zhuce">
                    <img width="200px" src="/images/zhuce.png" /></a>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var userLogin = {

            loginFn: function() {
                var u = $("[name=userName]").val().trim(), p = $("[name=userPwd]").val().trim();
                if (u == "") {
                    alert("请输入用户名!");
                    $("[name=userName]").focus();
                    return false;
                }
                if (p == "") {
                    alert("请输入密码");
                    $("[name=userPwd]").focus();
                    return false;
                }
                // $("#btnLogin").unbind("click").css({ "color": "#999999" });
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/AppPage/weixin/Login.aspx?login=1",
                    dataType: "json",
                    data: $("#loginBtn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            var rurl = '<%= EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>';
                            location.href = rurl == "" ? "/AppPage/weixin/OrderList.aspx" : decodeURIComponent(rurl);
                        } else {
                            alert(ret.msg);
                        }
                    }
                });
            }
        };
        $(function() {

        })
    </script>

</body>
</html>
