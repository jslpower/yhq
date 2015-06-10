<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShenQing.aspx.cs" Inherits="Eyousoft_yhq.Web.WeiDian.ShenQing" MasterPageFile="~/MP/WeiDian.Master" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/user.css?v=0.0.0.3" type="text/css" media="screen"/>
    <style type="text/css">
    body{ background:#ffffff;}
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <div class="warp">
        <div class="basic_t cent">
            微店申请</div>
        <div class="login_form  shenq_form">
            <ul>
                <li><span class="label_name">会员账号:</span> <span class="font_hui">
                    <asp:Literal runat="server" ID="ltrYongHuMing"></asp:Literal></span> </li>
                <li><span class="label_name">会员姓名:</span> <span class="font_hui">
                    <asp:Literal runat="server" ID="ltrXingMing"></asp:Literal></span> </li>
                <li><span class="label_name">微店名称:</span>
                    <input class="u-input" type="text" name="txtMingCheng" id="txtMingCheng" />                
                </li>
                <li><span class="label_name">联系电话:</span>
                    <input class="u-input" type="text" name="txtDianHua" id="txtDianHua" />
                </li>
                <li class="txt"><span class="label_name">微店介绍:</span>
                    <textarea class="u-input" id="txtJieShao" name="txtJieShao"></textarea>
                </li>
            </ul>
        </div>
        <div class="padd cent paddB mt20">
            <input name="" type="button" class="y_btn" value="申请开通" id="btn_shenqing" />
        </div>
    </div>   

    <script type="text/javascript">
        var iPage = {
            redirect_huiyuan_weidian: function(weidianid) {
                if (weidianid.length == 0) window.location.href = "/weidian/shenqing.aspx";
                else window.location.href = "/weidian/default.aspx?weidianid=" + weidianid;
                return false;
            },
            redirect_weidian_login: function() {
                window.location.href = "/weidian/login.aspx";
            },
            shenQing: function(obj) {
                var _data = { txtMingCheng: $.trim($("#txtMingCheng").val()), txtJieShao: $.trim($("#txtJieShao").val()),txtDianHua:$.trim($("#txtDianHua").val()) };
                if (_data.txtMingCheng.length <= 0) { alert("请输入微店名称"); return false; }
                if (_data.txtDianHua.length <= 0) { alert("请输入微店联系电话"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });
                var _self = this;

                function __callback(response) {
                    alert(response.msg);
                    if (response.result == "1") _self.redirect_huiyuan_weidian(response.obj);
                    else if (response.result == "-1") _self.redirect_weidian_login();
                    else if (response.result == "-2") _self.redirect_huiyuan_weidian(response.obj);
                    else {
                        $(obj).bind("click", function() { iPage.shenQing(obj); }).css({ "color": "" });
                    }
                }

                $.ajax({ type: "POST", url: "?doType=shenqing", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shenQing(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            if ("<%=WeiDianId %>".length > 0) iPage.redirect_huiyuan_weidian("<%=WeiDianId %>");
            $("#btn_shenqing").click(function() { iPage.shenQing(this); });
        });
    </script>
</asp:Content>
