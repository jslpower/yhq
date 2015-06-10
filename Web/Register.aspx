<%@ Page Title="注册用户" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Eyousoft_yhq.Web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $(".dropdown img.flag").addClass("flagvisibility");

            $(".dropdown dt a").click(function() {
                $(".dropdown dd ul").toggle();
            });

            $(".dropdown dd ul li a").click(function() {
                var text = $(this).html();
                if (text == '男') {
                    $("#userSex").val("1")
                }
                else if (text == '女') {
                    $("#userSex").val("0")
                }
                $(".dropdown dt a span").html(text);
                $(".dropdown dd ul").hide();

            });

            function getSelectedValue(id) {
                return $("#" + id).find("dt a span.value").html();
            }

            $(document).bind('click', function(e) {
                var $clicked = $(e.target);
                if (!$clicked.parents().hasClass("dropdown"))
                    $(".dropdown dd ul").hide();
            });


            $("#flagSwitcher").click(function() {
                $(".dropdown a.flag").toggleClass("flagvisibility");
            });
        });
    </script>

    <form id="from1">
    <div class="register">
        <h3>
            个人用户注册</h3>
        <div class="register_box">
            <div class="reglist">
                <ul class="userform" style="width: 450px;">
                    <li>
                        <label>
                            <font class="font_f60">*</font> 手机号码：</label>
                        <input id="userName" name="userName" type="text" class="inputbg formsize200" valid="required|isMobile"
                            errmsg="手机号码不可为空!|手机号码错误!" />
                        <%--<input type="button" value="点击获取短信验证码" class="msg_yz" id="btnCode" />--%>
                    </li>
                    <%--<li>
                        <label>
                            <font class="font_f60">*</font> 验证码：</label>
                        <input id="userViaCode" name="userViaCode" type="text" class="inputbg formsize200"
                            valid="required" errmsg="验证码不可为空!" />
                    </li>--%>
                    <li>
                        <label>
                            <font class="font_f60">&nbsp;</font>
                        </label>
                        <font class="font_f60">注册后需进入个人资料里验证通过 确保能收到短信通知!</font></li>
                    <li>
                        <label>
                            <font class="font_f60">*</font> 姓名：</label>
                        <input id="contactName" name="contactName" type="text" class="inputbg formsize200"
                            valid="required" errmsg="姓名不能为空" />
                    </li>
                    <li style="position: relative;">
                        <label>
                            性别：</label>
                        <dl id="sample" class="dropdown">
                            <dt><a href="javascript:;"><span>男</span></a></dt>
                            <dd>
                                <ul>
                                    <li><a href="javascript:;" class="flag">男</a></li>
                                    <li><a href="javascript:;" class="flag">女</a></li>
                                </ul>
                            </dd>
                        </dl>
                    </li>
                    <li>
                        <label>
                            <font class="font_f60">*</font> 密码：</label>
                        <input id="userPwd" name="userPwd" type="password" class="inputbg formsize200" valid="required"
                            errmsg="密码不能为空" />
                    </li>
                    <li>
                        <label>
                            <font class="font_f60">*</font> 重复密码：</label>
                        <input id="userRePwd" name="userRePwd" type="password" class="inputbg formsize200"
                            valid="required" errmsg="重复密码不能为空" />
                    </li>
                    <li>
                        <label>
                            验证码：</label>
                        <input id="ValiCode" name="ValiCode" type="text" class="inputbg formsize80" onblur="pageOpt.ckcode();" />&nbsp;
                        <img alt="点击更换验证码" title="点击更换验证码" style="cursor: pointer; margin-top: -4px;" onclick="this.src='/CommonPage/validatecode.ashx?ValidateCodeName=SYS_TieLv_VC&id='+Math.random();return false;"
                            align="middle" width="60" height="20" id="img1" src="/CommonPage/validatecode.ashx?ValidateCodeName=SYS_TieLv_VC&t=<%=DateTime.Now.ToString("HHmmssffff") %>" />
                    </li>
                    <li>
                        <label>
                            推荐码：</label>
                        <input id="userPollCode" name="userPollCode" type="text" class="inputbg formsize200"
                            value="<%= EyouSoft.Common.Utils.GetQueryStringValue("PollCode") %>" />
                    </li>
                </ul>
                <input type="hidden" id="userSex" name="userSex" value="1" />
            </div>
            <div class="reg_botline">
            </div>
            <div class="regBtn">
                <button id="btnsave" onclick="return false">
                    立即注册</button></div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            bindBtn: function() {
                $("#btnsave").val("提交注册").bind("click", function() { $(this).css({ "color": "" }); return false; });
            },
            ckcode: function() {
                var c = document.cookie, ckcode = "", tenName = "";
                var code = $.trim($("#ValiCode").val());
                for (var i = 0; i < c.split(";").length; i++) {
                    tenName = c.split(";")[i].split("=")[0];
                    ckcode = c.split(";")[i].split("=")[1];
                    if ($.trim(tenName) == "SYS_TieLv_VC") {
                        break;
                    } else {
                        ckcode = "";
                    }
                }
                if (code == "" || ckcode != code) {
                    tableToolbar._showMsg("验证码输入错误!");
                    $("#ValiCode").val("");
                    return false;
                } else {
                    return true;
                }
            },
            retise: function() {


                $("#btnSave").val("注册中").unbind("click").css({ "color": "#999999" });
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/Register.aspx?register=1",
                    dataType: "json",
                    data: $("#btnsave").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            var rurl = '<%= EyouSoft.Common.Utils.GetQueryStringValue("rurl") %>';
                            tableToolbar._showMsg(ret.msg, function() {
                                location.href = rurl == "" ? "/Index.aspx" : rurl;
                            });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                            pageOpt.bindBtn();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        pageOpt.bindBtn();
                    }
                });
            },
            configSecond: 60,
            GetNumber: function() {
                $("#btnCode").attr("disabled", "disabled");
                $("#btnCode").val(pageOpt.configSecond + "秒之后点击获取")
                pageOpt.configSecond--;
                if (pageOpt.configSecond >= 0) {
                    setTimeout(pageOpt.GetNumber, 1000);
                }
                else {
                    $("#btnCode").removeAttr("disabled");
                    pageOpt.configSecond = 60;
                    $("#btnCode").val("点击获取验证码");
                }
            }
        };

        $(function() {
            //            $("#btnCode").click(function() {
            //                if (!(/^(13|15|18|14)\d{9}$/.test($("#userName").val().trim()))) {
            //                    tableToolbar._showMsg("手机号码格式错误");
            //                    return false;
            //                };
            //                $.ajax({
            //                    type: "get",
            //                    url: "/CommonPage/ajaxRegister.aspx?userName=" + $("#userName").val().trim(),
            //                    success: function(result) {
            //                        if (result.toLowerCase() == "true") {
            //                            tableToolbar._showMsg("该手机已被注册");
            //                            return false;
            //                        }
            //                        else {
            //                            pageOpt.GetNumber();
            //                            $.ajax({
            //                                type: "get",
            //                                url: "/CommonPage/ajaxSendMSG.aspx?SendCode=1&Tel=" + $("#userName").val(),
            //                                success: function(result) {
            //                                    if (result != "成功") {
            //                                        tableToolbar._showMsg(result);
            //                                    }
            //                                }
            //                            }); //发送验证码
            //                        }
            //                    }
            //                }); //手机号码是否被注册


            //            })

            $("#btnsave").click(function() {
                if (!pageOpt.ckcode()) {
                    return false;
                }
                var form = $("#btnsave").closest("form").get(0);
                FV_onBlur.initValid(form);
                if (ValiDatorForm.validator(form, "parent")) {
                    var newpwd = $("#userPwd").val();
                    var surepwd = $("#userRePwd").val();
                    if (newpwd != surepwd) {
                        tableToolbar._showMsg("新密码和确认密码不相同");
                        $("#userRePwd").focus();
                        return false;
                    }
                    else {
                        var parmar = { userName: $("#userName").val() };
                        $.ajax({
                            type: "get",
                            url: "/CommonPage/ajaxRegister.aspx?" + $.param(parmar),
                            cache: false,
                            success: function(result) {
                                if (result.toLowerCase() == "true") {
                                    tableToolbar._showMsg("该手机已被注册");
                                }
                                else {
                                    pageOpt.retise();
                                }
                            }
                        }); //ajax提交
                    }
                }
            })//click


        })
    </script>

</asp:Content>
