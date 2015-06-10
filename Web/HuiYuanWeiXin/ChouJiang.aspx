<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChouJiang.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.ChouJiang" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <meta name="format-detection" content="telephone=no" />
    <title>抽奖</title>
    <link rel="stylesheet" href="/css/weixin/basic.css" type="text/css" media="screen">
    <link rel="stylesheet" href="/css/weixin/choujiang.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1">
    <div class="choujiang_box">
        <div class="cent paddT">
            <img src="/images/chj-01.png"></div>
        <div class="cent choujin_w" id="defaultBox">
            <p>
                <asp:Literal ID="ltrChouJiang" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:Literal ID="ltrZhongJiang" runat="server"></asp:Literal>
            </p>
        </div>
        <div class="paddT choujin_y" style="display: none; font-size: 22px;" id="resultBox">
            200微点</div>
        <!------抽奖点击后显示------->
        <div class="paddT chj_gz">
            抽奖规则：分享获得一次抽奖机会，中奖红包点数可转入自己的微点中。</div>
        <div class="cent">
            <div class="chj_touxian radius">
                <a id="fxImg" href="javascript:;">
                    <img src="<%=TuXiangFilepath %>" /></a></div>
            <div class="font18" style="color: #fff;">
                <%=XingMing %></div>
        </div>
        <div class="paddT cent font16">
            <a href="ChouJiangs.aspx" style="color: #fff;">查看中奖记录</a></div>
        <div class="cent mt20 paddB">
            <a href="javascript:;" class="chj_btn" id="fenxiang">立即分享</a></div>
        <div class="cent" style="color: #fff;">
            每天第一次分享有固定奖励</div>
    </div>
    <div class="choujiang_bg">
        <img src="/images/chj-bg.png" /></div>
    <div id="floatDiv" style="z-index: 2999; position: fixed; top: 0px; left: 0px; width: 100%;
        height: 100%; background: none repeat scroll 0% 0% rgba(34, 34, 34, 0.9); text-align: right;
        display: none">
        <div style="display: inline-block; margin: 0 10px; padding: 20px 75px 0 0; text-align: left;
            font: 14px/1.8 Microsoft YaHei, SimHei, helvetica, arial, verdana, tahoma, sans-serif;
            color: #fff; background: url(/images/share_weixin_guide.png) no-repeat right 5px;
            -webkit-background-size: 126px 90px; -moz-background-size: 126px 90px; -o-background-size: 126px 90px;
            background-size: 126px 90px;" id="shareSendTxt">
            <span style="font-size: 18px;">分享到微信，请点击右上角</span><br>
            <span>再选择【发送给朋友】</span><br>
            <span>或【分享到朋友圈】</span></div>
    </div>

    <script type="text/javascript">
        $(function() {
            $("#defaultBox").click(function() {
                var that = this;
                $.ajax({
                    type: "post",
                    url: "ChouJiang.aspx?choujiang=1&huiyuanid=<%=MingPianHuiYuanId %>",
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        alert(ret.msg);
                        if (ret.msg == "未登录") {
                            location.href = "login.aspx?rurl=" + encodeURIComponent(window.location.href);
                        }
                        if (ret.result == "1") {
                            $(that).hide();
                            $("#resultBox").html(ret.obj + "微点");
                            $("#resultBox").show();
                        }
                        $("#isDefault").val("1");
                    }
                })

            })
        })
    </script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        iPage = {
            mpUrl: "/huiyuanweixin/mingpian.aspx?mingpianid=<%=MingPianId %>",
            ZengZhi: function() {
                $.ajax({
                    url: "ChouJiang.aspx?t=1&huiyuanid=<%=MingPianHuiYuanId %>",
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            window.location.href = iPage.mpUrl;
                        } else if (ret.result == "-99") {

                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("未知错误");
                    }
                })
            }
        }
        $(function() {
            $("#fenxiang").click(function() {
                $("#floatDiv").show();
            })
            $("#floatDiv").click(function() {
                $(this).hide();
            });
            $("#fxImg").click(function() {
                location.href = iPage.mpUrl;
            })
        })
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                link: '<%=FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                success: function() {
                    iPage.ZengZhi();
                }
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%=FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link',
                dataUrl: '',
                success: function() {
                    iPage.ZengZhi();
                }
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%=FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                success: function() {
                    iPage.ZengZhi();
                }
            });
        });
    </script>

    </form>
</body>
</html>
