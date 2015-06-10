<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eyousoft_yhq.Web.WeiDian.Default"
    MasterPageFile="~/MP/WeiDian.Master" Title="微店首页" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" href="/css/weixin/home.css?v=0.0.0.2" type="text/css" media="screen" />
    <style type="text/css">
        .home_head
        {
            height: 60px;
            padding: 10px 30px 10px 66px;
            position: relative;
        }
        .home_touxian
        {
            width: 56px;
            height: 56px;
            overflow: hidden;
            position: absolute;
            left: 5px;
            top: 10px;
        }
        .home_touxian img
        {
            width: 56px;
            height: 56px;
        }
        .home_name
        {
            height: 21px;
            padding-bottom: 3px;
            padding-left: 15px;
        }
        .btn
        {
            width: 70px;
            height: 26px;
            line-height: 26px;
            text-align: center;
            display: inline-block;
            color: #fff;
            background: #fe6d14;
            position: absolute;
            right: 10px;
            top: 16px;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <h1 class="cent" style="padding-top: 20px;">
        <asp:Literal runat="server" ID="ltrWeiDianName"></asp:Literal></h1>
    <h3 class="cent">
        <asp:Literal runat="server" ID="ltrWeiDianDianHua"></asp:Literal></h3>
    <div class="warp">
        <div class="home_img">
            <!--<img src="<%=WeiDianLogoFilepath %>" /></div>-->
            <div class="home_head">
                <div class="home_touxian radius">
                    <a data-class="mingpian" href="/HuiYuanWeiXin/MingPian.aspx">
                        <img runat="server" id="imgHead" /></a></div>
                <div class="home_name">
                    <asp:Literal runat="server" ID="ltrWeiDianJieShao"></asp:Literal></div>
            </div>
        </div>
        <nav id="nav">
          <ul class="nav_list">
              <li class="wid6" id="li_guoneiyou">
                 <div class="nav_gn">
                   <h2>国内游</h2>
                 </div>
              </li>

              <li class="wid4" id="li_guojiyou">
                 <div class="nav_gj">
                   <h2>国际游</h2>
                 </div>
              </li>

              <li class="wid4" id="li_chanpintuijian">
                 <div class="nav_cp">
                   <h2>产品推荐</h2>
                 </div>
              </li>

              <li class="wid6" id="li_guoneijipiao">
                 <div class="nav_fly">
                   <h2>国内机票</h2>
                 </div>
              </li>
              
          </ul>
       </nav>
        <asp:PlaceHolder runat="server" ID="phGL" Visible="true">
            <div class="nav2">
                <ul>
                    <li id="li_chanpinguanli"><a href="/weidian/wodechanpin.aspx">产品管理</a></li>
                    <li id="li_dingdanguanli"><a href="/weidian/wodedingdan.aspx">订单管理</a></li>
                </ul>
            </div>
        </asp:PlaceHolder>

        <script type="text/javascript">
            var iPage = {
                redirectGuoNeiYou: function() {
                    window.location.href = "/apppage/weixin/productlist.aspx?xianlu=0&weidianid=<%=WeiDianId %>";
                },
                redirectGuoJiYou: function() {
                    window.location.href = "/apppage/weixin/productlist.aspx?xianlu=1&weidianid=<%=WeiDianId %>";
                },
                redirectChanPinTuiJian: function() {
                    window.location.href = "/apppage/weixin/productlist.aspx";
                },
                redirectGuoNeiJiPiao: function() {
                    window.location.href = "/apppage/weixin/jp_search.aspx?weidianid=<%=WeiDianId %>";
                },
                redirectChanPinGuanLi: function() {
                    window.location.href = "/weidian/wodechanpin.aspx?weidianid=<%=WeiDianId %>";
                },
                redirectDingDanGuanLi: function() {
                    window.location.href = "/weidian/wodedingdan.aspx?weidianid=<%=WeiDianId %>";
                }
            };
            $(document).ready(function() {
                $("#li_guoneiyou").click(function() { iPage.redirectGuoNeiYou(); });
                $("#li_guojiyou").click(function() { iPage.redirectGuoJiYou(); });
                $("#li_chanpintuijian").click(function() { iPage.redirectChanPinTuiJian(); });
                $("#li_guoneijipiao").click(function() { iPage.redirectGuoNeiJiPiao(); });
                $("#li_chanpinguanli").click(function() { iPage.redirectChanPinGuanLi(); });
                $("#li_dingdanguanli").click(function() { iPage.redirectDingDanGuanLi(); });

            });
        </script>
</asp:Content>
