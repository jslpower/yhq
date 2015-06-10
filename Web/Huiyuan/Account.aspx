<%@ Page Title="账户管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.Account" %>

<%@ Register Src="/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.boxy.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <form runat="server" id="form1">
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            账户资金管理</h2>
        <div class="address_box">
            <ul style="border-bottom: none 0;" class="addr_form">
                <li>
                    <p style="margin-left: 10em;">
                        余额：
                        <asp:Literal ID="litAccount" runat="server" Text="0"></asp:Literal>
                    </p>
                </li>
                <li>
                    <p style="margin-left: 10em;">
                        充值金额：
                        <asp:TextBox ID="txtMoney" runat="server" CssClass="formsize200 inputbg" valid="required|isMoney"
                            errmsg="请填写充值金额!|请填写正确的充值金额！"></asp:TextBox>
                    </p>
                </li>
                <li>
                    <p style="margin-left: 10em;">
                        <input type="button" id="save" class="baocunbtn" value="充值" />
                    </p>
                </li>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <li style="border-top: #ddd solid 1px; padding-top: 40px; margin-top: 40px;">
                        <p style="margin-left: 10em;">
                            帐 户 名：
                            <input type="text" id="userTo" name="userTo" class="formsize200 inputbg" />
                        </p>
                    </li>
                    <li>
                        <p style="margin-left: 10em;">
                            转帐金额：
                            <input type="text" id="money" name="money" class="formsize200 inputbg" /></p>
                    </li>
                    <li>
                        <p style="margin-left: 10em;">
                            <input type="button" id="pay" class="baocunbtn" value="转帐" />
                        </p>
                    </li>
                </asp:PlaceHolder>
            </ul>
        </div>
    </div>
    </form>

    <script type="text/javascript">

        $(function() {
            var showdiv = $("#show").val();
            if (showdiv == "False")
                $("#paydiv").hide();
            else
                $("#paydiv").show();
            $("#save").click(function() {
                if (!ValiDatorForm.validator($("#save").closest("form").get(0), "alert"))
                { return false; }
                $.ajax({
                    type: "post",
                    cache: false,
                    url: '/Huiyuan/Account.aspx?chongzhi=1',
                    dataType: "json",
                    data: $("#save").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            Boxy.iframeDialog({ iframeUrl: '/Huiyuan/QueRenCz.aspx?id=' + ret.obj, title: '确认充值金额', modal: true, width: 300, height: 130 });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })
            })
            $("#pay").click(function() {
                var account = $("#userTo").val();
                var accountMoney = tableToolbar.getFloat($("#money").val());
                if (!/^(13|15|18|14)\d{9}$/.test(account)) {
                    tableToolbar._showMsg('请核对账户格式！', function() { return false; });
                }
                if (!/^\d+(\.\d+)?$/.test(accountMoney)) {
                    tableToolbar._showMsg('请核对转账金额！', function() { return false; });
                }


                $.ajax({
                    url: '/Huiyuan/Account.aspx?chk=1&a=' + account,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {

                            tableToolbar.ShowConfirmMsg("确认转入名称为[" + ret.obj + "]的账户[" + accountMoney + "]元?", function() {
                                $.ajax({
                                    url: '/Huiyuan/Account.aspx?zz=1',
                                    dataType: "json",
                                    data: { a: account, m: accountMoney },
                                    success: function(ret) {
                                        if (ret.result == "1") {
                                            tableToolbar._showMsg(ret.msg, function() { window.location.href = window.location.href });
                                        }
                                        else {
                                            tableToolbar._showMsg(ret.msg, function() { return false; });
                                        }
                                    },
                                    error: function() {
                                        tableToolbar._showMsg(tableToolbar.errorMsg);
                                    }
                                })
                            });

                        } else {
                            tableToolbar._showMsg(ret.msg);
                        }

                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })



            })
        })
    </script>

</asp:Content>
