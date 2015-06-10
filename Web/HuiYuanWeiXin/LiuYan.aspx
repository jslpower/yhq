<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiuYan.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.LiuYan" MasterPageFile="~/MP/HuiYuanWeiXin.Master" Title="给我（他她）的留言" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/minpian.css?v=0001" type="text/css" media="screen" />
</asp:Content>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <div class="warp" id="div_liuyan">
        <asp:PlaceHolder runat="server" ID="ph01">
            <div style="display: block;">
                <div class="font18 cent font_gray mt20 paddB">
                    <asp:Literal runat="server" ID="ltrXX01">还没有人给你留言哦<br/>赶快把你的微名片分享给朋友吧</asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
    
        <asp:PlaceHolder runat="server" ID="ph02">
        <div class="guwen_list">
            <ul>
            <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
                <li data-liuyanid="<%#Eval("IdentityId") %>" data-huiyuanid1="<%#Eval("HuiYuanId1") %>">
                    <div class="guwen_head">
                        <div class="guwen_touxian radius">
                            <a href="mingpian.aspx?mingpianid=<%#Eval("MingPianId1") %>"><img src="<%#GetTuXiang(Eval("HuiYuanTuXiangFilepath1")) %>"></a></div>
                        <div class="guwen_name">
                            <%#Eval("HuiYuanName1") %></div>
                        <div class="font12">
                            <%#GetLiuYanTime(Eval("LiuYanTime"))%>
                        </div>
                    </div>
                    <div class="liuyan_txt">
                        <%#GetHuiFuCaoZuo(Eval("HuiFuNeiRong"))%>
                        <div class="font16">
                            <%#Eval("LiuYanNeiRong") %></div>
                    </div>
                    <div class="liuyan_huifu">
                        回复：<%#Eval("HuiFuNeiRong") %>
                    </div>
                    <div class="liuyan_huifu" style="display: none; line-height:28px;" data-class="huifu">
                        <div style="float:left;width:80%">
                        <input type="text" name="txtHuiFuNeiRong" class="liuyan_input" style="height: 28px; width: 100%" />
                        </div>
                        <div style="float:right; width:20%; text-align:right;">
                        <a href="javascript:void(0)" data-class="huifuliuyan">回复</a>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
            </asp:Repeater>
            </ul>
        </div>
        </asp:PlaceHolder>
    </div>
    
    <asp:PlaceHolder runat="server" ID="ph03">
    <div class="bot" id="div_woyaoliuyan">
        <div class="bot_box">
            <a href="javascript:void(0)" class="y_btn" data-class="woyaoliuyan">我要留言</a>
        </div>
    </div>
    </asp:PlaceHolder>

    <div class="warp" id="div_liuyan_edit" style="display:none;">
        <div class="padd mt10">
            <textarea style="height: 160px;" class="liuyan_input" rows="" cols="" name="" id="txtLiuYanNeiRong" name="txtLiuYanNeiRong"></textarea></div>
        <div class="padd mt10 cent">
            <a class="y_btn" href="javascript:void(0)" id="a_liuyan_tijiao">发表</a></div>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            shift1: function() {
                $("#div_liuyan,#div_woyaoliuyan").hide();
                $("#div_liuyan_edit").show();
            },
            shift2: function(obj) {
                var _$li = $(obj).closest("li");
                $('div[data-class="huifu"]').hide();
                $('a[data-class="huifu"]').show();
                _$li.find('div[data-class="huifu"]').show();
                $(obj).hide();
            },
            tiJiaoLiuYan: function() {
                var _data = { txtLiuYanNeiRong: $.trim($("#txtLiuYanNeiRong").val()), txtHuiYuanId2: "<%=HuiYuanId2 %>" };
                if (_data.txtLiuYanNeiRong.length < 1) { alert("请填写留言内容"); return false; }

                var _self = this;

                function __callback(response) {
                    if (response.result == "1") { alert(response.msg); _self.reload(); return false; }
                    else if (response.result == "-99") { if (confirm(response.msg)) { window.location.href = "/huiyuanweixin/login.aspx?rurl=" + encodeURIComponent(response.obj); return false; } }
                    else { alert(response.msg); _self.reload(); return false; }
                }

                var _url = window.location.href;
                if (_url.indexOf('?') > -1) _url += '&doType=tijiaoliuyan';
                else _url += "?doType=tijiaoliuyan";

                $.ajax({ type: "POST", url: _url, data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() { }
                });
            },
            huiFuLiuYan: function(obj) {
                var _$li = $(obj).closest("li")
                var _data = { txtLiuYanId: _$li.attr("data-liuyanid"), txtHuiFuNeiRong: $.trim(_$li.find("input[name='txtHuiFuNeiRong']").val()), txtHuiYuanId1: _$li.attr("data-huiyuanid1"), txtHuiYuanId2: "<%=HuiYuanId2 %>" };
                if (_data.txtHuiFuNeiRong.length < 1) { alert("请填写回复内容"); return false; }

                var _self = this;

                function __callback(response) {
                    if (response.result == "1") { alert(response.msg); _self.reload(); return false; }
                    else if (response.result == "-99") { if (confirm(response.msg)) { window.location.href = "/huiyuanweixin/login.aspx?rurl=" + encodeURIComponent(response.obj); return false; } }
                    else { alert(response.msg); _self.reload(); return false; }
                }

                var _url = window.location.href;
                if (_url.indexOf('?') > -1) _url += '&doType=huifuliuyan';
                else _url += "?doType=huifuliuyan";

                $.ajax({ type: "POST", url: _url, data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() { }
                });
            }
        };

        $(document).ready(function() {
            $('a[data-class="woyaoliuyan"]').click(function() { iPage.shift1(); });
            $("#a_liuyan_tijiao").click(function() { iPage.tiJiaoLiuYan(); });

            $("a[data-class='huifu']").click(function() { iPage.shift2(this); });
            $('a[data-class="huifuliuyan"]').click(function() { iPage.huiFuLiuYan(this); });
        });
    </script>

</asp:Content>
