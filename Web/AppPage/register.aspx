<%@ Page Title="注册" Language="C#" MasterPageFile="~/masterPage/HuiYuan.Master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        value="<%= EyouSoft.Common.Utils.GetQueryStringValue("PollCode") %>" /></li>
            </ul>
            <div>
                <img width="280" style="vertical-align: top" src="/images/user-boxB.png" alt="" /></div>
        </div>
        <div class="btn">
            <a href="javascript:;" id="btnsave">
                <img width="200px" src="/images/zhuce_btn.png"></a></div>
    </div>

    <script type="text/javascript">

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


        })
    </script>

</asp:Content>
