<%@ Page Title="用户登陆" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eyousoft_yhq.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="mainbox">
        <!------loginbox-------->
        <div class="loginbox">
            <div class="loginbar">
                <div class="loginBg">
                    <ul class="userform">
                        <li>
                            <label>
                                用户名：</label><input runat="server" type="text" class="inputbg formsize200" maxlength="16"
                                    errmsg="请填写用户名！" valid="required" id="txtUserName"></li>
                        <li>
                            <label>
                                密&nbsp;&nbsp;码：</label><input type="password" runat="server" id="txtPassWord" maxlength="16"
                                    class="inputbg formsize200" errmsg="请填写密码！" valid="required"></li>
                        <li>
                            <input name="btnLogin" value="登 录" type="button" id="btnLogin" class="loginBtn" type="submit">
                            </input><%--
                            <span class="txt">忘记密码？</span>--%></li>
                    </ul>
                    <div class="tixin_txt">
                        <img style="vertical-align: middle;" src="images/jiantR.gif">
                        还不是会员，马上<a class="f30" href="/Register.aspx">免费注册</a></div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var UserLogin = {
            checkForm: function() {
                var form = $("#btnLogin").closest("form").get(0);
                FV_onBlur.initValid(form);
                return ValiDatorForm.validator(form, "parent");
            },
            loginFn: function() {
                if (UserLogin.checkForm()) {
                    $("#btnLogin").val("登录中").unbind("click").css({ "color": "#999999" });
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/Login.aspx?login=1",
                        dataType: "json",
                        data: $("#btnLogin").closest("form").serialize(),
                        success: function(ret) {
                            if (ret.result == "1") {
                                var rurl = '<%= EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>';
                                tableToolbar._showMsg(ret.msg, function() {
                                    location.href = rurl == "" ? "/Index.aspx" : rurl;
                                });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg);
                                UserLogin.bindBtn();
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                            UserLogin.bindBtn();
                        }
                    });
                }
            },
            bindBtn: function() {
                $("#btnLogin").val("登 录").click(function() { UserLogin.loginFn(); return false; }).css({ "color": "" });
            }
        };

        $(document).ready(function() {
            $("#<%= txtUserName.ClientID %>").focus();
            UserLogin.bindBtn();
            $("#<%= txtUserName.ClientID %>,#<%= txtPassWord.ClientID %>").keypress(function(e) { if (e.keyCode == 13) { UserLogin.loginFn(); return false; } });
            $("#a_Login_Register").attr("href", '/Register.aspx?rurl=<%= Server.UrlEncode(EyouSoft.Common.Utils.GetQueryStringValue("rurl"))  %>');
        });
    </script>

</asp:Content>
