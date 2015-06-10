<%@ Page Title="会员登录" Language="C#" MasterPageFile="~/masterPage/HuiYuan.Master"
    AutoEventWireup="true" CodeBehind="App_login.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.App_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="user_main">
        <form id="userForm" action="/login.aspx">
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
                <img width="200px" src="/images/login_btn.png" /></a></div>
    </div>
 
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
                    url: "/AppPage/App_Login.aspx?login=1",
                    dataType: "json",
                    data: $("#loginBtn").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            var rurl = '<%= EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>';
                            location.href = rurl == "" ? "/AppPage/Default.aspx" : rurl;
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

</asp:Content>
