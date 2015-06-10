<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MingPian.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.MingPian"
    MasterPageFile="~/MP/HuiYuanWeiXin.Master" Title="名片" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/minpian.css?v=0001" type="text/css" media="screen" />

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

</asp:Content>
<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <form id="form1" name="form1">
    <div class="warp">
        <div class="user_header">
            <div class="user_01">
                <div class="user_touxian radius">
                    <img src="<%=TuXiangFilepath %>"></div>
                <div class="leftside">
                    <div class="code_small">
                        <a href="javascript:void(0)" id="a_chakan_mingpian_erweima">
                            <img src="<%=MingPianErWeiMaFilepath %>"></a></div>
                    <div>
                        手机：<asp:Literal runat="server" ID="ltrShouJi"></asp:Literal></div>
                    <div>
                        微信：<asp:Literal runat="server" ID="ltrWeiXinHao"></asp:Literal></div>
                </div>
                <div class="rightside">
                    <asp:PlaceHolder runat="server" ID="phSheZhi" Visible="false">
                        <div class="shezhi" onclick="location.href='mingpianedit.aspx'">
                            设置</div>
                    </asp:PlaceHolder>
                </div>
            </div>
            <div class="user_name">
                <asp:Literal runat="server" ID="ltrXingMing"></asp:Literal></div>
            <div class="user_job">
                <asp:Literal runat="server" ID="ltrZhiWei"></asp:Literal><br>
                <asp:Literal runat="server" ID="ltrGongSiName"></asp:Literal></div>
            <div class="user_nav">
                <ul>
                    <li id="li_dianzan"><span class="zan">赞<asp:Literal ID="dianzanxiaoxi" runat="server"></asp:Literal></span>
                        <p>
                            <asp:Literal runat="server" ID="ltrZanJiShu"></asp:Literal></p>
                    </li>
                    <li id="li_guanzhu"><span>关注<asp:Literal ID="guanzhuxiaoxi" runat="server"></asp:Literal></span>
                        <p>
                            <asp:Literal runat="server" ID="ltrGuanZhuJiShu"></asp:Literal></p>
                    </li>
                    <li id="li_liuyan"><span>留言<asp:Literal ID="liuyanxiaoxi" runat="server"></asp:Literal></span>
                        <p>
                            <asp:Literal runat="server" ID="ltrLiuYanJiShu"></asp:Literal></p>
                    </li>
                    <li id="li_youji"><span>分享</span>
                        <p>
                            <asp:Literal runat="server" ID="ltrYouJiJiShu"></asp:Literal></p>
                    </li>
                </ul>
            </div>
        </div>
        <div class="font18 cent font_gray" style="padding-top: 30px;">
            赶快分享名片给好友吧</div>
        <asp:PlaceHolder runat="server" ID="phWeiDian" Visible="false">
            <div class="font18 cent">
                <a href="javascript:void(0)" class="font_blue" id="a_jinruweidian">进入微店</a></div>
        </asp:PlaceHolder>
        <div class="cent mt20">
            <a href="choujiang.aspx?huiyuanid=<%=MingPianHuiYuanId %>">
                <img src="/images/fx-img.png"></a></div>
        <asp:PlaceHolder ID="plaHongBao" runat="server" Visible="false">
            <div class="cent mt10">
                <div class="cent mt20 paddB">
                    <a>红包余额:<asp:Literal ID="ltrHongBaoJinE" runat="server">0</asp:Literal>元</a>
                </div>
                <div class="money_input radius4">
                    <input id="JINE" name="JINE" type="text" placeholder="注入红包金额" />元</div>
                <div class="cent mt20 paddB">
                    <a id="save" href="javascript:;" class="chj_btn">确认</a></div>
            </div>
        </asp:PlaceHolder>
    </div>
    <div class="user-mask" style="display: none;" id="div_mingpian_erweima_zezhao">
        <div class="user-mask-cnt" id="div_mingpian_erweima_neirong">
            <div class="font18 font_gray cent">
                扫描收藏我的微名片</div>
            <div class="cent code_big" id="div_mingpian_erweima_tupian">
                <img src="<%=MingPianErWeiMaFilepath %>"></div>
            <div class="cent font_gray">
                长按二维码保存到手机<br>
                可印在纸质名片和宣传单上</div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var iPage = {
            _erWeiMaFlag: false,
            BaoCun: function() {

                var isMoney = /^\d+(\.\d+)?$/.test($("#JINE").val());

                if (isMoney) {
                    if (Math.floor($("#JINE").val()) < 50) {
                        alert("注入金额不可小于50");
                        return false;
                    }
                }
                $.ajax({
                    type: "post",
                    url: "MingPian.aspx?t=1",
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        if (ret.result == "-99") {
                            if (confirm("账户不足，是否充值？")) {
                                location.href = '/AppPage/weixin/ChongZhi.aspx';
                            }
                        } else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("未知错误");
                    }
                })

            },
            chaKanErWeiMa: function() {
                var _self = this;
                $("#div_mingpian_erweima_zezhao").slideDown("normal", function() { _self._erWeiMaFlag = true; });
            },
            _guanBiErWeiMa: function() {
                var _self = this;
                $("#div_mingpian_erweima_zezhao").slideUp("normal", function() { _self._erWeiMaFlag = false; });
            },
            documentClick: function(e) {
                if (!this._erWeiMaFlag) return;
                if (document.all) e = event;
                var _ele = e.target == undefined ? event.srcElement : e.target;
                if ($(_ele).attr("id") == "div_mingpian_erweima_neirong") return;
                if ($(_ele).closest("div.user-mask-cnt").length > 0) return;
                this._guanBiErWeiMa();
            },
            wxFenXiang: function() {
                //分享到朋友圈
                wx.onMenuShareTimeline({
                    title: '<%=FenXiangBiaoTi %>',
                    link: '<%=FenXiangLianJie %>',
                    imgUrl: '<%=FenXiangTuPianFilepath %>'
                });
                //分享给朋友
                wx.onMenuShareAppMessage({
                    title: '<%=FenXiangBiaoTi %>',
                    desc: '<%=FenXiangMiaoShu %>',
                    link: '<%=FenXiangLianJie %>',
                    imgUrl: '<%=FenXiangTuPianFilepath %>',
                    type: 'link',
                    dataUrl: ''
                });
                //分享到QQ
                wx.onMenuShareQQ({
                    title: '<%=FenXiangBiaoTi %>',
                    desc: '<%=FenXiangMiaoShu %>',
                    link: '<%=FenXiangLianJie %>',
                    imgUrl: '<%=FenXiangTuPianFilepath %>'
                });
            },
            wxReady: function() {
                var _self = this;
                _self.wxFenXiang();
            },
            dianZan: function() {
                window.location.href = "dianzan.aspx?huiyuanid2=<%=MingPianHuiYuanId %>";
                return false;
            },
            guanZhu: function() {
                window.location.href = "guanzhu.aspx?huiyuanid2=<%=MingPianHuiYuanId %>";
                return false;
            },
            liuYan: function() {
                window.location.href = "liuyan.aspx?huiyuanid2=<%=MingPianHuiYuanId %>";
                return false;
            },
            youJi: function() {
                window.location.href = "YouJiList.aspx?huiyuanid2=<%=MingPianHuiYuanId %>";
                return false;
            },
            redirectWeiDian: function() {
                window.location.href = "/weidian/default.aspx?weidianid=<%=WeiDianId %>";
            }

        };

        $(document).ready(function() {
            $("#a_chakan_mingpian_erweima").click(function() { iPage.chaKanErWeiMa(); });
            $("#div_mingpian_erweima_tupian").click(function() { iPage._guanBiErWeiMa(); });
            $(document).click(function(e) { iPage.documentClick(e); });

            $("#li_dianzan").click(function() { iPage.dianZan(); });
            $("#li_guanzhu").click(function() { iPage.guanZhu(); });
            $("#li_liuyan").click(function() { iPage.liuYan(); });
            $("#li_youji").click(function() { iPage.youJi(); });

            $("#a_jinruweidian").click(function() { iPage.redirectWeiDian(); })
            $("#save").click(function() { if (confirm("确认操作?")) { iPage.BaoCun() } });
        });

        wx.ready(function() {
            iPage.wxReady();
        });
        
    </script>

</asp:Content>
