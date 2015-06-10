<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.Login"
    MasterPageFile="~/MP/HuiYuanWeiXin.Master" Title="会员登录" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/user.css" type="text/css" media="screen" />
    <style type="text/css">
        body
        {
            background: #fff;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <div class="warp">
        <div class="basic_t cent">
            会员登录</div>
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
            <input name="" type="button" class="y_btn" value="登录" id="btn_login" />
        </div>
        <div class="padd cent paddB mt20">
            <input name="" type="button" class="y_btn" value="注册" id="btn_register" />
        </div>

        <script type="text/javascript">
            var iPage = {
                redirect: function(data) {
                    var _rurl = "<%=RURL %>";
                    var _rt = "<%=RT %>";

                    if (_rt == "1") {
                        if ($.trim(data).length == 0) {
                            window.location.href = "/weidian/shenqing.aspx";
                            return false;
                        }
                        window.location.href = "/weidian/default.aspx?weidianid=" + data;
                        return false;
                    }

                    if (_rt == "0") {
                        window.location.href = "/huiyuanweixin/mingpian.aspx";
                        return false;
                    }

                    if (_rurl.length > 0) {
                        window.location.href = _rurl;
                    } else {
                        window.location.href = "/huiyuanweixin/mingpian.aspx";
                    }

                    return false;
                },
                login: function(obj) {
                    var _data = { txt_u: $.trim($("#txtYongHuMing").val()), txt_p: $.trim($("#txtMiMia").val()) };
                    if (_data.txt_u.length <= 0) { alert("请输入登录账号"); return false; }
                    if (_data.txt_p.length <= 0) { alert("请输入登录密码"); return false; }

                    $(obj).unbind("click").css({ "color": "#999999" });
                    var _self = this;

                    function __callback(response) {
                        if (response.result == "1") _self.redirect(response.obj);
                        else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.login(obj); }).css({ "color": "" });
                        }
                    }

                    $.ajax({ type: "POST", url: "/huiyuanweixin/login.aspx?rt=<%=RT %>&doType=login", data: _data, cache: false, dataType: "json", async: false,
                        success: function(response) {
                            __callback(response);
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.login(obj); }).css({ "color": "" });
                        }
                    });
                }
            };

            $(document).ready(function() {
                $("#btn_login").click(function() { iPage.login(this); });
                $("#btn_register").click(function() { window.location.href = "/AppPage/weixin/Register.aspx?rurl=" + encodeURIComponent(window.location.href) })
            });
        </script>
</asp:Content>
