<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuanZhu.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.GuanZhu" MasterPageFile="~/MP/HuiYuanWeiXin.Master" Title="点赞（我他她）的人" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/minpian.css?v=0001" type="text/css" media="screen" />
</asp:Content>
<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <div class="warp">
        <asp:PlaceHolder runat="server" ID="ph01">
            <div style="display: block;">
                <div class="basic_t">
                    被关注：<%=BeiGuanZhuJiShu%>次</div>
                <div class="font18 cent font_gray mt20 paddB">
                    <asp:Literal runat="server" ID="ltrXX01">>还没有人关注你哦<b/>赶快把你的微名片分享给朋友吧</asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph02">
            <div style="display: block;">
                <div class="basic_t">
                    被关注：<%=BeiGuanZhuJiShu%>次</div>
                <div class="zan_box">
                    <h3>
                        <asp:Literal runat="server" ID="ltrXX02">关注我的人</asp:Literal></h3>
                    <ul class="zan_list">
                        <asp:Repeater runat="server" ID="rpt01">
                            <ItemTemplate>
                                <li>
                                    <div class="touxian radius">
                                        <a href="mingpian.aspx?mingpianid=<%#Eval("MingPianId1") %>"><img src="<%#GetTuXiang(Eval("HuiYuanTuXiangFilepath1")) %>" /></a></div>
                                    <div class="touxian_name">
                                        <%#Eval("HuiYuanName1")%></div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="ph03" Visible="false">
            <div style="display: block;">
                <div class="basic_t">
                    <asp:Literal runat="server" ID="ltrXX03">我关注</asp:Literal>：<%=WoGuanZhuJiShu%>次</div>
                <div class="zan_box">
                    <h3>
                        <asp:Literal runat="server" ID="ltrXX04">我关注的人</asp:Literal></h3>
                    <ul class="zan_list">
                        <asp:Repeater runat="server" ID="rpt02">
                            <ItemTemplate>
                                <li data-huiyuanid1="<%#Eval("HuiYuanId1") %>" data-huiyuanid2="<%#Eval("HuiYuanId2") %>" data-guanzhuid="<%#Eval("IdentityId") %>">
                                    <div class="touxian radius">
                                        <a href="mingpian.aspx?mingpianid=<%#Eval("MingPianId2") %>"><img src="<%#GetTuXiang(Eval("HuiYuanTuXiangFilepath2")) %>" /></a></div>
                                    <div class="touxian_name">
                                        <%#Eval("HuiYuanName2")%></div>
                                    <div class="gz_btn">
                                        <a href="javascript:void(0)" data-class="quxiaoguanzhu">取消关注</a></div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    
    <asp:PlaceHolder runat="server" ID="ph04">
        <div class="bot" id="div_woyaoliuyan">
            <div class="bot_box">
                <a href="javascript:void(0)" class="y_btn" data-class="woyaoliuyan" id="a_woyaoguanzhu">我要关注他（她）</a>
            </div>
        </div>
    </asp:PlaceHolder>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            woYaoGuanZhu: function() {
                var _self = this;
                var _data = { txtHuiYuanId2: "<%=HuiYuanId2 %>" };

                function __callback(response) {
                    if (response.result == "1") { alert(response.msg); _self.reload(); return false; }
                    else if (response.result == "-99") { if (confirm(response.msg)) { window.location.href = "/huiyuanweixin/login.aspx?rurl=" + encodeURIComponent(response.obj); return false; } }
                    else { alert(response.msg); _self.reload(); return false; }
                }

                var _url = window.location.href;
                if (_url.indexOf('?') > -1) _url += '&doType=woyaoguanzhu';
                else _url += "?doType=woyaoguanzhu";

                $.ajax({ type: "POST", url: _url, data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() { }
                });

            },
            quXiaoGuanZhu: function(obj) {
                var _self = this;
                var _$li = $(obj).closest("li");
                var _data = { txtHuiYuanId1: _$li.attr("data-huiyuanid1"), txtHuiYuanId2: _$li.attr("data-huiyuanid2"), txtGuanZhuId: _$li.attr("data-guanzhuid") };

                function __callback(response) {
                    if (response.result == "1") { alert(response.msg); _self.reload(); return false; }
                    else if (response.result == "-99") { if (confirm(response.msg)) { window.location.href = "/huiyuanweixin/login.aspx?rurl=" + encodeURIComponent(response.obj); return false; } }
                    else { alert(response.msg); _self.reload(); return false; }
                }

                var _url = window.location.href;
                if (_url.indexOf('?') > -1) _url += '&doType=quxiaoguanzhu';
                else _url += "?doType=quxiaoguanzhu";

                $.ajax({ type: "POST", url: _url, data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        __callback(response);
                    },
                    error: function() { }
                });
            }
        };

        $(document).ready(function() {
            $("#a_woyaoguanzhu").click(function() { iPage.woYaoGuanZhu(); });
            $('a[data-class="quxiaoguanzhu"]').click(function() { iPage.quXiaoGuanZhu(this); });
        });
    </script>
</asp:Content>
