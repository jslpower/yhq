<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MingPianEdit.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.MingPianEdit" MasterPageFile="~/MP/HuiYuanWeiXin.Master" Title="名片编辑" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/minpian.css" type="text/css" media="screen" />
    
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <form id="form1">
    <input type="hidden" id="txtTuXiangFilepath" runat="server" />
    <input type="hidden" id="txtTuXiangMediaId" name="txtTuXiangMediaId" />
    <div class="warp">
        <div class="basic_t">
            必填项</div>
        <div class="shezhi_tx" id="div_tuxiang_shangchuan">
            <span>头像 <em class="font_hui paddL">点击+号可上传图像</em></span> <i class="touxian_ok radius" style="border-radius:50%">
                <img src="<%=TuXiangFilepath %>" id="img_tuxiang"></i> <i class="touxian_upload radius" id="i_tuxiang_shangchuan"></i>
        </div>
        <div class="form_list">
            <ul>
                <li><span class="label_name">微信号</span> 
                    <input type="text" class="u-input font_hei" value="" name="txtWeiXinHao" id="txtWeiXinHao" runat="server"/> </li>
                <li><span class="label_name">姓名</span>
                    <input type="text" class="u-input font_hei" value="" name="txtXingMing" id="txtXingMing" runat="server"/>
                </li>
                <li><span class="label_name">公司</span>
                    <input type="text" class="u-input font_hui" value="" name="txtGongSiName" id="txtGongSiName" runat="server"/>
                </li>
                <li><span class="label_name">职位</span>
                    <input type="text" class="u-input font_hei" value="" name="txtZhiWei" id="txtZhiWei" runat="server"/>
                </li>
                <li><span class="label_name">手机</span>
                    <input type="text" class="u-input font_hei" value="" name="txtShouJi" id="txtShouJi" runat="server"/>
                </li>
            </ul>
        </div>
        <div class="basic_t mt10">
            选填项</div>
        <div class="form_list">
            <ul>
                <li><span class="label_name">QQ</span>
                    <input type="text" class="u-input font_hui" value="" name="txtQQ" id="txtQQ" runat="server"/>
                </li>
                <li><span class="label_name">邮箱</span>
                    <input type="text" class="u-input font_hui" value="" name="txtYouXiang" id="txtYouXiang" runat="server"/>
                </li>
                <li><span class="label_name">地址</span>
                    <input type="text" class="u-input font_hui" value="" name="txtDiZhi" id="txtDiZhi" runat="server"/>
                </li>
            </ul>
        </div>
    </div>
    </form>
    <div class="bot mt10">
        <div class="bot_box">
            <input name="" type="button" class="y_btn" value="完成" id="btn_baocun">
        </div>
    </div>
    

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
                if ($.trim($("#<%=txtWeiXinHao.ClientID %>").val()).length == 0) {
                    alert("请填写微信号");
                    return false;
                }
                if ($.trim($("#<%=txtXingMing.ClientID %>").val()).length == 0) {
                    alert("请填写姓名");
                    return false;
                }
                if ($.trim($("#<%=txtGongSiName.ClientID %>").val()).length == 0) {
                    alert("请填写公司名称");
                    return false;
                }
                if ($.trim($("#<%=txtZhiWei.ClientID %>").val()).length == 0) {
                    alert("请填写职位");
                    return false;
                }
                if ($.trim($("#<%=txtShouJi.ClientID %>").val()).length == 0) {
                    alert("请填写手机");
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

                $.ajax({ type: "POST", url: "mingpianedit.aspx?doType=baocun", data: $("#form1").serialize(), cache: false, dataType: "json", async: false,
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
                $("#i_tuxiang_shangchuan").unbind("click").click(function() { alert("请稍候，正在检查您的微信客户端版本。") });
            },
            //上传图像-事件-微信版本过低提示
            sctxF2: function() {
                $("#i_tuxiang_shangchuan").unbind("click").click(function() { alert("您当前的微信客户端不能使用该功能，请升级微信客户端后再操作。") }); ;
            },
            //上传图像-事件-选择图片
            sctxF3: function() {
                $("#i_tuxiang_shangchuan").unbind("click").click(function() { iPage.sctxF4(); });
            },
            //上传图像-选择图片
            sctxF4: function() {
                var _self = this;
                wx.chooseImage({
                    success: function(res) {
                        var localIds = res.localIds;
                        if (localIds.length > 1) { alert("只能选择一张图像"); return false; }
                        $("#div_tuxiang_shangchuan").html('<span>头像 <em class="font_hui paddL">点击+号可上传图像</em></span> <i class="touxian_ok radius" style="border-radius:50%"><img src="' + localIds[0] + '" id="img_tuxiang"></i> <i class="touxian_upload radius" id="i_tuxiang_shangchuan"></i>');
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
                        $("#txtTuXiangMediaId").val(serverId);
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
                            $("#<%=txtTuXiangFilepath.ClientID %>").val(response.obj);
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
                $("#btn_baocun").unbind("click").css({ "color": "#999999" });
            },
            //保存按钮启用
            bcF2: function() {
                $("#btn_baocun").bind("click", function() { iPage.bcF3(this); }).css({ "color": "" });
            }
        };

        $(document).ready(function() {
            iPage.bcF2();
            iPage.sctxF1();
        });

        wx.ready(function() {
            iPage.wxReady();
        });

        wx.error(function(res) {
            
        });
    </script>
</asp:Content>