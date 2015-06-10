<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouJiAdd.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.YouJiAdd" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link href="/css/weixin/basic.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/minpian.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/youji.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

</head>
<body>
    <form id="form1">
    <div class="warp">
        <div class="youji_main">
            <div class="youji_fabu_titleone">
                <span>标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：</span><input type="text" id="txtTitle" class="u-input" value="" name="txtTitle"></div>
            <div class="youji_fabu_titleone">
                <span>微信码：H</span><input type="text" id="txtHma" class="u-input" value="" name="txtHma" maxlength="5"></div>
            <div class="youji_fabu_box">
                <%--<div class="del_icon">
                </div>--%>
                <ul>
                    <input type="hidden" id="txtTuXiangMediaId1" name="txtTuXiangMediaId" />
                    <li id="test">图片：<a href="javascript:void(0)" class="uplode_img">上传图片</a><em id="TuPianTiShi"></em></li>
                    <li class="txt"><span>文字：</span>
                        <textarea name="MiaoShu" class="u-input"></textarea>
                    </li>
                </ul>
            </div>
            <div class="cent add_more mt10">
                <span><i class="add_icon"></i>添加一组</span></div>
        </div>
    </div>
    <input id="TuPianId" type="hidden" />
    <input id="TuPianTiShiId" type="hidden" />
    <div class="bot">
        <div class="bot_box">
            <a href="javascript:void(0)" class="y_btn">分享 我为自己代言</a>
        </div>
    </div>
    </form>
</body>

<script type="text/javascript">
    var iPage = {
        reload: function() {
            window.location.href = window.location.href;
        },
        redirectWoDeMingPian: function() {
            window.location.href = "/huiyuanweixin/mingpian.aspx";
            return false;
        },
        yanZhengForm: function() {
            if ($("#txtTitle").val() == "") {
                alert("请填写游记标题！");
                return false;
            }
            return true;
        },
        bcF3: function(obj) {
            if (!this.yanZhengForm()) return false;
            var _self = this;
            _self.bcF1();
            var _self = this;
            function __callback(response) {
                alert(response.msg);
                _self.redirectWoDeMingPian();
            }
            $.ajax({ type: "POST", url: "YouJiAdd.aspx?doType=baocun", data: $("#form1").serialize(), cache: false, dataType: "json", async: false,
                success: function(response) {
                    __callback(response);
                },
                error: function() {
                    _self.bcF2();
                }
            });
        },
        wxReady: function() {
            var _self = this;
            /*try {
            wx.checkJsApi({
            jsApiList: wx_jsapi_config.jsApiList
            , success: function(response) {
            var _checkResult = response.checkResult;
            if (response.errMsg == "checkJsApi:ok" && _checkResult.uploadImage && _checkResult.downloadImage && _checkResult.chooseImage) {
            _self.sctxF3();
            } else {
            _self.sctxF2();
            }
            }
            , fail: function() {
            _self.sctxF2();
            }
            });
            } catch (e) {
            _self.sctxF2();
            }*/

            _self.sctxF3();
        },
        sctxF0: function() {
            //$("#i_tuxiang_shangchuan").unbind("click");
            this.sctxF2();
            alert("您当前的微信客户端不能使用该功能，请升级微信客户端后再操作。");
        },
        //上传图像-事件-初始化
        sctxF1: function() {
            $(".uplode_img").unbind("click").click(function() { alert("请稍候，正在检查您的微信客户端版本。") });
        },
        //上传图像-事件-微信版本过低提示
        sctxF2: function() {
            $(".uplode_img").unbind("click").click(function() { alert("您当前的微信客户端不能使用该功能，请升级微信客户端后再操作。") }); ;
        },
        //上传图像-事件-选择图片
        sctxF3: function() {
            $(".uplode_img").unbind("click").click(function() {
                var tupianid = $(this).closest(".youji_fabu_box").find("input[name=txtTuXiangMediaId]").attr("id");
                var tupiantsid = $(this).closest(".youji_fabu_box").find("em").attr("id");
                $("#TuPianId").val(tupianid);
                $("#TuPianTiShiId").val(tupiantsid);
                iPage.sctxF4();
            });
        },
        //上传图像-选择图片
        sctxF4: function() {
            var _self = this;
            wx.chooseImage({
                success: function(res) {
                    var localIds = res.localIds;
                    if (localIds.length > 1) { alert("只能选择一张图像"); return false; }
                    //                        $("#div_tuxiang_shangchuan").html('<span>头像 <em class="font_hui paddL">点击+号可上传图像</em></span> <i class="touxian_ok radius" style="border-radius:50%"><img src="' + localIds[0] + '" id="img_tuxiang"></i> <i class="touxian_upload radius" id="i_tuxiang_shangchuan"></i>');
                    _self.sctxF3();
                    setTimeout(function() { _self.sctxF5(localIds[0]); }, 10);
                },
                fail: function() {
                    _self.sctxF0();
                }
            });
        },
        //上传图像-上传图片
        sctxF5: function(localIds) {
            //alert("F5")
            var _self = this;
            _self.bcF1();
            wx.uploadImage({
                localId: localIds,
                isShowProgressTips: 1,
                success: function(res) {
                    var serverId = res.serverId;
                    var tupianid = $("#TuPianId").val();
                    var tupiantsid = $("#TuPianTiShiId").val();
                    $("#" + tupianid).val(serverId);
                    $("#" + tupiantsid).addClass("ok");
                    _self.bcF2();
                    //setTimeout(function() { _self.sctxF6(serverId); }, 10);
                },
                fail: function(res) {
                    alert("上传图像失败，请重新操作");
                    _self.bcF2();
                }
            });
        },
        //上传图像-保存图片
        sctxF6: function(serverId) {
            //alert("F6")
            var _data = { media_id: serverId };
            var _self = this;
            $.ajax({ type: "POST", url: "/weixin/get_media.aspx", data: _data, cache: false, dataType: "json", async: false,
                success: function(response) {
                    if (response.result == "1") {
                        var tupianid = $("#TuPianId").val();
                        $("#" + tupianid).val(response.obj);
                        //alert("上传图像成功");
                    } else {
                        alert("上传图像失败，请重新操作");
                    }
                    _self.bcF2();
                },
                error: function() {
                    alert("上传图像失败，请重新操作");
                    _self.bcF2();
                }
            });
        },
        //保存按钮停用
        bcF1: function() {
            $(".y_btn").unbind("click").css({ "color": "#999999" });
        },
        //保存按钮启用
        bcF2: function() {
            $(".y_btn").bind("click", function() { iPage.bcF3(this); }).css({ "color": "" });
        }
    };

    $(document).ready(function() {
        iPage.bcF2();
        iPage.sctxF1();
        $(".cent").click(function() {

            var html = $("div[class=youji_fabu_box]").eq(0).clone(true);
            var mudicount = $(".youji_fabu_box").length + 1;
            html.find("input[name=txtTuXiangMediaId]").attr("id", "txtTuXiangMediaId" + mudicount);
            html.find("em").attr("id", "TuPianTiShi" + mudicount);
            html.find("input[name=txtTuXiangMediaId]").val("");
            html.find("textarea[name=MiaoShu]").val("");
            $(this).closest(".cent").before($(html));
        });
    });

    wx.ready(function() {
        iPage.wxReady();
    });

    wx.error(function(res) {

    });
</script>

</html>
