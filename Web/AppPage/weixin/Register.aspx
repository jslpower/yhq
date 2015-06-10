<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.Register" %>

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
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="header" class="Btitle">
            让旅游精彩人生</div>
        <div class="user_main">
            <div class="user_box">
                <ul>
                    <li>手机号码：</li>
                    <li>
                        <input type="text" class="formsize400 inputbg" name="userName" id="userName" /></li>
                    <li>姓名：</li>
                    <li>
                        <input type="text" class="formsize400 inputbg" name="contactName" id="contactName" /></li>
                    <li>性别：</li>
                    <li>
                        <asp:DropDownList ID="ddl_sex" runat="server">
                            <asp:ListItem Value="1" Text="男"></asp:ListItem>
                            <asp:ListItem Value="0" Text="女"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>密码：</li>
                    <li>
                        <input type="password" class="formsize400 inputbg" name="userPwd" id="userPwd" /></li>
                    <li>推荐码：</li>
                    <li>
                        <input type="text" class="formsize400 inputbg" name="userPollCode" id="userPollCode"
                            value="<%= EyouSoft.Common.Utils.GetQueryStringValue("PollCode") %>" placeholder="没有可不填写" /></li>
                </ul>
                <div>
                    <img width="280" style="vertical-align: top" src="/images/user-boxB.png" alt="" /></div>
            </div>
            <div class="btn">
                <a href="javascript:;" id="btnsave">
                    <img width="200px" src="/images/zhuce_btn.png"></a><br />
                <%--<p>&nbsp;
                </p>
                <a href="Login.aspx">已注册，去登陆</a>--%>
                <input type="hidden" id="rurl" name="rurl" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>" />
            </div>
        </div>
    </div>
    <div id="floatDiv" style="z-index: 2999; position: fixed; top: 0px; left: 0px; width: 100%;
        height: 100%; background: none repeat scroll 0% 0% rgba(34, 34, 34, 0.9); text-align: right;">
        <div style="display: inline-block; margin: 0 10px; padding: 20px 75px 0 0; text-align: left;
            font: 14px/1.8 Microsoft YaHei, SimHei, helvetica, arial, verdana, tahoma, sans-serif;
            color: #fff; background: url(/images/share_weixin_guide.png) no-repeat right 5px;
            -webkit-background-size: 126px 90px; -moz-background-size: 126px 90px; -o-background-size: 126px 90px;
            background-size: 126px 90px;" id="shareSendTxt">
            <span style="font-size: 18px;">请点击右上角...，点[查看公众号]</span><br>
            <span>关注公众号，获得更多信息服务</span><br>
            <span>&nbsp;</span>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            getCook: function(name) {

                var arr = document.cookie.split('; ');
                for (var i = 0; i < arr.length; i++) {
                    var arr2 = arr[i].split('=');
                    if (arr2[0] == name) {
                        return arr2[1];
                    }
                }
                return '';
            },
            setCook: function(name, value, iDay) {
                var oDate = new Date();
                oDate.setDate(oDate.getDate() + iDay);
                document.cookie = name + '=' + value + ';expires=' + oDate;
            },
            InitBlock: function() {
                if (pageOpt.getCook("isfirst") == "1") {
                    $("#floatDiv").hide();
                }
                else {
                    pageOpt.setCook("isfirst", 1, 365);
                }
            }
        }

        $(function() {
            $("#btnsave").click(function() {
                var msg = "";
                if (!(/^(13|15|18|14)\d{9}$/.test($("#userName").val().trim()))) {
                    msg += "手机号码格式不正确！\n";
                };
                if ($("#contactName").val() == "") {
                    msg += "姓名不能为空！\n";
                };
                if ($("#userPwd").val() == "") {
                    msg += "密码不能为空！ \n";
                };
                if (msg != "") {
                    alert(msg);
                    return false;
                }
                else {
                    var parmar = { userName: $("#userName").val() };
                    $.ajax({
                        type: "Get",
                        url: "/CommonPage/ajaxRegister.aspx?" + $.param(parmar),
                        cache: false,
                        success: function(result) {
                            if (result.toLowerCase() == "true") {
                                alert("该手机已被注册！");
                            }
                            else {
                                $("#btnsave").closest("form").get(0).submit();

                            }
                        }
                    });
                }
            })//提交
            // pageOpt.InitBlock();
            $("#floatDiv").click(function() { $(this).hide() });

        })
    </script>

</body>
</html>
