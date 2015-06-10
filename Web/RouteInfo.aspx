<%@ Page Title="线路详情" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="RouteInfo.aspx.cs" Inherits="Eyousoft_yhq.Web.RouteInfo" %>

<%@ Register Src="/userControl/LeftRouteInfo.ascx" TagName="LeftShow" TagPrefix="uc1" %>
<asp:Content ID="ContentPlaceHead1" ContentPlaceHolderID="ContentPlaceHead" runat="server">

    <script type="text/javascript">
        function setTab(name, cursel, n) {
            for (i = 1; i < n; i++) {
                 var menu = document.getElementById(name + i);
                var con = document.getElementById(name + "_" + i);
                menu.className = i == cursel ? "hover" : "";
                con.style.display = i == cursel ? "block" : "none";
            }
        }
    </script>

<style type="text/css">
.Contentbox div.box
{
	min-height:70px;
}
</style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!------lanmu_T-------->
    <div class="lanmu_T">
        您所在位置：首页 &gt;
        <%=getType %>
        &gt; <span class="font_f60">
            <asp:Label ID="lblMenuTitle" runat="server" Text=""></asp:Label></span></div>
    <!------productBox-------->
    <div class="productBox">
        <!------Msidebar-------->
        <div class="Msidebar">
            <!------productBox1-------->
            <div class="productBox1">
                <div class="product_T">
                    <h2>
                        <asp:Label ID="lblproductName" runat="server" Text=""></asp:Label>
                        <input type="hidden" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("id")%>"
                            id="hidpid" />
                    </h2>
                    <asp:Label ID="lbldescript" runat="server" Text=""></asp:Label></div>
                <div class="pro-all">
                    <form>
                    <div class="pro-all-L">
                        <dl>
                            <dt>¥ <span>
                                <asp:Label ID="lblprice" runat="server" Text=""></asp:Label></span></dt>
                            <dd class="price_zhekou">
                                <b>
                                    <asp:Label ID="lblZK" runat="server" Text="0"></asp:Label></b>折 价值<b><asp:Label ID="lblMarketPrice"
                                        runat="server" Text="0"></asp:Label></b></dd>
                            <%-- <dd class="dindan_num">
                                <a href="javascript:;" class="jian">-</a><span>数量：
                                    <input id="orderNum" name="orderNum" readonly="readonly" value="0" type="text" valid="required|isNumber"
                                        errmsg="预定人数不可为空!|预定人数不为错误!"></span><a href="javascript:;" class="jia">+</a></dd>--%>
                            <dd class="btnImg">
                                <asp:PlaceHolder ID="place_Viadate" runat="server"><a id="sendMsg" href="javascript:;"
                                    style="margin-right: 5px;">
                                    <img src="/images/linquan.gif"></a><a id="orderYD" href="javascript:;"><img src="/images/xiadan.gif"></a>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder ID="place_isViadate" runat="server" Visible="false">
                                    <dd class="dindan_num" style="padding-top: 10px;">
                                        此产品已过期！
                                    </dd>
                                </asp:PlaceHolder>
                            <dd>
                            </dd>
                            <dd class="pro_txt">
                                已有<font class="font_f60"><asp:Label ID="lblSaleCount" runat="server" Text="0"></asp:Label></font>人购买</dd>
                        </dl>
                    </div>
                    </form>
                    <div class="pro-all-R">
                        <asp:Label ID="lblImg" runat="server" Text=""></asp:Label></div>
                </div>
            </div>
            <!------productBox2-------->
            <div class="productBox2">
                <div class="tab_T">
                    <ul>
                        <li id="one1" onclick="setTab('one',1,5)" class="hover">
                            <asp:Label ID="lblType" runat="server" Text="产品介绍"></asp:Label></li>
                        <li id="one2" onclick="setTab('one',2,5)">
                            <asp:Label ID="lblKnow" runat="server" Text="出团须知"></asp:Label></li>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                            <li id="one3" onclick="setTab('one',3,5)">参考行程</li>
                            <li id="one4" onclick="setTab('one',4,5)">同类比较</li></asp:PlaceHolder>
                    </ul>
                </div>
                <div class="Contentbox">
                    <div class="code_h">
                        <img src="/CommonPage/zxingcode.aspx?code=yhq://<%=Request.Url.Host%>/AppPage/productinfo.aspx?id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>" /></div>
                    <div id="one_1" class="box">
                        <asp:Literal ID="ltrDescript" runat="server" Text=""></asp:Literal>
                    </div>
                    <div id="one_2" style="display: none" class="box">
                        <asp:Literal ID="ltrKown" runat="server" Text=""></asp:Literal>
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                        <div id="one_3" style="display: none" class="box">
                            <asp:Literal ID="ltrTour" runat="server" Text=""></asp:Literal>
                        </div>
                        <div id="one_4" style="display: none" class="box">
                            <asp:Literal ID="ltrCompair" runat="server" Text=""></asp:Literal>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </div>
            <!------pro_dianpin-------->
            <div class="pro_dianpin">
                <h3>
                    <span>点评<font style="font-size: 14px;" id="msgCount">（共<%=pinglunshu %>条）</font></span><a
                        href="#bottom"><img src="/images/dianp.png"></a></h3>
                <div class="dianp_box" id="dianpingBox">
                </div>
                <div class="fabiaopl">
                    <div class="fb_user">
                        <img src="images/userpic.gif"></div>
                    <div class="fb_bg">
                        <textarea name="" cols="" rows="" id="commsg"></textarea><span><a class="fabu_btn"
                            href="javascript:;">发表评论</a></span><span></span></div>
                </div>
            </div>
        </div>
        <div class="Rsidebar">
            <div class="qqpic">
                <asp:Label ID="lblQQ" runat="server" Text=""></asp:Label><a target="_blank" id="printRoute"
                    href="/printPage/RoutePrint.aspx?routeid=<%=EyouSoft.Common.Utils.GetQueryStringValue("id")%>">
                    <img src="/images/daochuxc.gif" /></a></div>
             <div class="qqpic1"><a href="DownApp.aspx" target=_blank><img src="/images/apppic.jpg" /></a></div>
            <uc1:LeftShow ID="LeftShow" runat="server" />
        </div>
    </div>
    <a name="bottom"></a>
    <input type="hidden" id="yhm" value="<%=yhm %>" />
    <input type="hidden" id="mark" value="<%=isLogin %>" />

    <script type="text/javascript">
        $(function() {
            $(".fabu_btn").click(function() {
                pageSR.GetAjaxData("save");
            })
        })
        var pageSR = {
            GetAjaxData: function(type) {
                if (type == "save") {
                    var isLogin = $("#mark").val();
                    if (isLogin == "0") {
                        location.href = "/Login.aspx?rurl=" + location.href;
                        return false;
                    }
                    if ($("#commsg").val().trim() == "") {
                        tableToolbar._showMsg("请填写评论内容！");
                        return false
                    }
                }
                var ajaxurl = "/CommonPage/ajaxWebCommentList.aspx?";
                //AJAX 加载数据
                $("#commlist").html("<div style='width:100%; text-align:center;'><img src='/images/loadingnew.gif' border='0' align='absmiddle'/>&nbsp;正在加载,请等待....&nbsp;</div>");
                var para = { pid: $("#hidpid").val(), context: $("#commsg").val(), dotype: type };
                var url = ajaxurl + $.param(para);
                $.ajax({
                    type: "Get",
                    url: url,
                    cache: false,
                    success: function(result) {
                        $("#dianpingBox").html(result);
                        $("#msgCount").html("（共" + $("#hidCount").val() + "条）");
                        $("#commsg").val("");
                    }
                });
            } //
        };


        $(function() {
            pageSR.GetAjaxData();
            $("#sendMsg").click(function() {
                var isLogin = $("#mark").val();
                if (isLogin == "0") {
                    location.href = "/Login.aspx?rurl=" + location.href;
                    return false;
                }
                if (confirm("领取优惠券后旅游顾问将会为您提供电话咨询，并按您的要求提供上门签约服务")) {
                    var sendMsg = { mark: 1, pid: $("#hidpid").val(), cid: $("#yhm").val() };
                    $.ajax({
                        type: "Get",
                        url: "/CommonPage/ajaxSendMSG.aspx?" + $.param(sendMsg),
                        cache: false,
                        success: function(result) {
                            if (result == "成功") {
                                tableToolbar._showMsg("你已成功领取此产品优惠券！");
                            }
                            else {
                                tableToolbar._showMsg(result);
                            }
                        }
                    });
                }
            })//领取优惠券
            $("a.jian").click(function() {
                if (tableToolbar.getInt($("#orderNum").val()) > 0) {
                    $("#orderNum").val(tableToolbar.getInt($("#orderNum").val()) - 1);
                }
                return false;
            })//
            $("a.jia").click(function() {
                $("#orderNum").val(tableToolbar.getInt($("#orderNum").val()) + 1);
            })//
            $("#orderYD").click(function() {
                var isLogin = $("#mark").val();
                if (isLogin == "0") {
                    location.href = "/Login.aspx?rurl=" + location.href;
                    return false;
                }
                else {
                    window.location.href = "/OrderStep1.aspx?id=" + $("#hidpid").val();
                }
                //                var form = $("#orderNum").closest("form").get(0);
                //                FV_onBlur.initValid(form);
                //                if (ValiDatorForm.validator($("#orderNum").closest("form").get(0), "parent")) {
                //                    if (tableToolbar.getInt($("#orderNum").val()) == 0) {
                //                        tableToolbar._showMsg("预定人数必须大于0 ! ");
                //                        return false;
                //                    }

                //}
            })//


        })
    </script>

</asp:Content>
