<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bangding_huiyuan.aspx.cs" Inherits="Eyousoft_yhq.Web.WeiXin.bangding_huiyuan" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>绑定会员</title>    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <meta name="format-detection" content="telephone=no"/>    
    <script type="text/javascript" src="/js/jquery-1.10.2.js"></script>

    <link rel="stylesheet" href="/css/weixin/basic.css?v=1" type="text/css" media="screen" />
    <link rel="stylesheet" href="/css/weixin/user.css" type="text/css" media="screen" />
    
    <style type="text/css">
    body{ background:#fff;}
    </style>
</head>
<body>    
    <div class="warp">
        <div class="basic_t cent">
            绑定会员</div>
        <div class="login_form">
            <ul>
                <li><s class="ico_user"></s>
                    <input type="text" class="u-input" value="" name="txtYongHuMing" id="txtYongHuMing" />
                </li>
                <li><s class="ico_mima"></s>
                    <input type="password" class="u-input" value="" name="txtMiMia" id="txtMiMia" />
                </li>
            </ul>
        </div>
        <div class="padd cent paddB mt20">
            <input name="" type="button" class="y_btn" value="绑定" id="btn_bangding" />
        </div>
    
    <script type="text/javascript">
        var iPage = {
            redirect_huiyuan_weidian: function(weidianid) {
                if (weidianid.length == 0) window.location.href = "/weidian/shenqing.aspx";
                else window.location.href = "/weidian/default.aspx?weidianid=" + weidianid;
                return false;
            },
            bangDing: function(obj) {
                var _data = { txt_u: $.trim($("#txtYongHuMing").val()), txt_p: $.trim($("#txtMiMia").val()) };
                if (_data.txt_u.length <= 0) { alert("请输入您需要绑定的账号"); return false; }
                if (_data.txt_p.length <= 0) { alert("请输入账号密码"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });
                var _self = this;

                function __callback(response) {
                    if (response.result == "1") _self.redirect_huiyuan_weidian(response.obj);
                    else {
                        alert(response.msg);
                        $(obj).bind("click", function() { iPage.bangDing(obj); }).css({ "color": "" });
                    }
                }

                $.ajax({ type: "POST", url: "/weixin/bangding_huiyuan.aspx?yonghuid=<%=YongHuId %>&openid=<%=weixin_openid %>&doType=bangding", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.bangDing(obj); }).css({ "color": "" });
                    }
                });
            }
        };
        $(document).ready(function() {
            $("#btn_bangding").click(function() { iPage.bangDing(this); });
        });
    </script>
</body>
</html>
