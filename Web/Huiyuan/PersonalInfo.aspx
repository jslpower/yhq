<%@ Page Title="资料修改" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.PersonalInfo" %>

<%@ Register Src="/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <form runat="server" id="form1">
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            会员资料修改</h2>
        <div class="address_box">
            <ul style="border-bottom: none 0;" class="addr_form">
                <li>
                    <label>
                        手机号：</label><p>
                            <asp:TextBox ID="txtPhone" runat="server" ReadOnly="true" class="formsize200 inputbg"></asp:TextBox>
                            <asp:PlaceHolder ID="Plabtn" runat="server">
                                <input type="button" value="点击获取短信验证码" class="msg_yz" id="btnCode" /></asp:PlaceHolder>
                            <asp:PlaceHolder ID="plaViaOK" runat="server" Visible="false">
                                <img alt="已经通过手机验证！" src="/images/yanzh_ok.gif" /></asp:PlaceHolder>
                        </p>
                </li>
                <li id="NoViaLi" runat="server" style="height: auto">
                    <label>
                        <font class="font_f60">&nbsp;</font>
                    </label>
                    <font class="font_f60">您的手机号尚未通过验证，无法收到系统通知，请及时验证手机号！</font>
                    <br />
                    <label>
                        <font class="font_f60">&nbsp;</font>
                    </label>
                    <font class="font_f60">(本系统采用的是语音验证码，点击后会有电话给您拨打 请接听并记录)</font> </li>
                <li id="PlaLi" runat="server" style="display: none">
                    <label>
                        验证码：</label>
                    <input id="userViaCode" name="userViaCode" type="text" class="inputbg formsize200" />
                </li>
                <li>
                    <label>
                        姓名：</label><p>
                            <asp:TextBox ID="txtName" runat="server" class="formsize200 inputbg" name=""></asp:TextBox></p>
                </li>
                <li>
                    <label>
                        性别：</label><p>
                            <asp:DropDownList ID="dl_sex" runat="server">
                            </asp:DropDownList>
                        </p>
                </li>
                <li>
                    <label>
                        服务项目：</label><p>
                            <select id="MemberOption" name="MemberOption" style=" width:150px;">
                             <%=BindOption(Option.ToString())%>
                        </select>
                        </p>
                </li>
                <li>
                    <label>
                        服务区域：</label><p>
                            <select id="MyProvice" name="MyProvice">
                             <%=BindProvice(ProviceId.ToString())%>
                        </select>
                        <select id="MyCity" name="MyCity">
                             <%=BindCity(CityId.ToString(), ProviceId.ToString())%>
                        </select>
                        <select id="MyArea" name="MyArea">
                             <%=BindArea(AreaId.ToString(), CityId.ToString())%>
                        </select>
                        <select id="MyStreet" name="MyStreet">
                             <%=BindStreet(StreetId.ToString(), AreaId.ToString())%>
                        </select>
                        </p>
                </li>
                <li>
                    <label>
                        原密码：</label><p>
                            <asp:TextBox ID="txtPassOld" TextMode="Password" runat="server" class="formsize200 inputbg"
                                name=""></asp:TextBox></p>
                </li>
                <li>
                    <label>
                        新密码：</label><p>
                            <asp:TextBox ID="txtPassNew" TextMode="Password" runat="server" class="formsize200 inputbg"
                                name=""></asp:TextBox></p>
                </li>
                <li>
                    <label>
                        确认密码：</label><p>
                            <asp:TextBox ID="txtPassSure" TextMode="Password" runat="server" class="formsize200 inputbg"
                                name=""></asp:TextBox></p>
                </li>
                <li>
                    <p style="margin-left: 10em;">
                        <input type="button" id="save" class="baocunbtn" value="修改" /></p>
                </li>
            </ul>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            UserInfo.BindBtn();
            UserInfo.SelectInit();
            $("#btnCode").click(function() {
                $("#<%=PlaLi.ClientID %>").show();
                UserInfo.GetNumber();
                $.ajax({
                    type: "post",
                    url: "/CommonPage/ajaxSendMSG.aspx?SendCode=1&Tel=" + $("#<%=txtPhone.ClientID %>").val(),
                    success: function(result) {
                        if (result != "成功") {
                            tableToolbar._showMsg(result);
                        }
                    }
                }); //发送验证码
            })
        });
        var UserInfo = {
            SelectInit: function() {
                $("#MyProvice").change(function() {
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/Huiyuan/PersonalInfo.aspx?posttype=city&selectvalue=0&proid=" + $("#MyProvice").val(),
                        dataType: "text",
                        success: function(ret) {
                            $("#MyCity").html(ret);
                        }
                    });
                });
                $("#MyCity").change(function() {
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/Huiyuan/PersonalInfo.aspx?posttype=area&selectvalue=0&cityid=" + $("#MyCity").val(),
                        dataType: "text",
                        success: function(ret) {
                            $("#MyArea").html(ret);
                        }
                    });
                });
                $("#MyArea").change(function() {
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/Huiyuan/PersonalInfo.aspx?posttype=street&selectvalue=0&areaid=" + $("#MyArea").val(),
                        dataType: "text",
                        success: function(ret) {
                            $("#MyStreet").html(ret);
                        }
                    });
                });
            },
            FormCheck: function() {
                return ValiDatorForm.validator($("#save").closest("form").get(0), "alert");
            },
            Save: function() {
                if (UserInfo.FormCheck()) {
                    var oldpwd = $("#<%=txtPassOld.ClientID %>").val();
                    var newpwd = $("#<%=txtPassNew.ClientID %>").val();
                    var surepwd = $("#<%=txtPassSure.ClientID %>").val();
                    var MemberName = $("#<%=txtName.ClientID %>").val();
                    if (oldpwd != "") {
                        if (newpwd == "" || surepwd == "") {
                            tableToolbar._showMsg("新密码和确认密码不能为空");
                            return;
                        }
                        if (newpwd != surepwd) {
                            tableToolbar._showMsg("新密码和确认密码不相同");
                            $("#<%=txtPassSure.ClientID %>").focus();
                            return;
                        }
                    } if (MemberName == "") {
                        tableToolbar._showMsg("姓名不能为空");
                        return;
                    }
                    $("#save").attr("class", "baocunbtn");
                    $("#save").val("修改中...");
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/Huiyuan/PersonalInfo.aspx?doType=AjaxPwd",
                        data: $("#save").closest("form").serialize(),
                        dataType: "json",
                        success: function(ret) {

                            if (ret.result == "0") {
                                tableToolbar._showMsg(ret.msg);
                            }
                            else {
                                tableToolbar._showMsg(ret.msg, function() { location.href = "/Huiyuan/PersonalInfo.aspx"; });
                            }

                            UserInfo.BindBtn();
                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙");
                            UserInfo.BindBtn();
                        }
                    });
                }
            }, // 
            BindBtn: function() {
                $("#save").click(function() {
                    UserInfo.Save();
                    return false;
                })
                $("#save").attr("class", "baocunbtn");
                $("#save").val("保存");

            },
            configSecond: 60,
            GetNumber: function() {
                $("#btnCode").attr("disabled", "disabled");
                $("#btnCode").val(UserInfo.configSecond + "秒之后点击获取")
                UserInfo.configSecond--;
                if (UserInfo.configSecond >= 0) {
                    setTimeout(UserInfo.GetNumber, 1000);
                }
                else {
                    $("#btnCode").removeAttr("disabled");
                    UserInfo.configSecond = 60;
                    $("#btnCode").val("点击获取验证码");
                }
            }



        }
    </script>

</asp:Content>
