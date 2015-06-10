<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LvYouGuWen.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.LvYouGuWen" MasterPageFile="~/MP/HuiYuanWeiXin.Master" %>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <div class="warp">
    <form>
    <div class="guwen_search" style=" height:96px">
                <ul class="clearfix">
                    <li style="width:75%;">
                        <div class="select">
                            <select id="MemberOption" name="MemberOption">
                             <%=BindOption(EyouSoft.Common.Utils.GetQueryStringValue("MemberOption"))%>
                        </select>
                        </div>                    
                    </li>
                    <input id="Level" name="Level" value="<%= Level%>" type="hidden" />
                    <li style="width:25%;"><input name="" type="submit" class="guwen_sbtn" value="搜索"></li>

                    <li style="width:25%;">
                        <div class="select">
                            <select id="MyProvice" name="MyProvice">
                             <%=BindProvice(ProviceId.ToString())%>
                        </select>
                        </div>                    
                    </li>

                    <li style="width:25%;">
                        <div class="select">
                            <select id="MyCity" name="MyCity">
                             <%=BindCity(CityId.ToString(), ProviceId.ToString())%>
                        </select>
                        </div>                    
                    </li>

                    <li style="width:25%;">
                        <div class="select">
                            <select id="MyArea" name="MyArea">
                             <%=BindArea(AreaId.ToString(), CityId.ToString())%>
                        </select>
                        </div>                    
                    </li>

                    <li style="width:25%;">
                        <div class="select">
                            <select id="MyStreet" name="MyStreet">
                             <%=BindStreet(StreetId.ToString(), AreaId.ToString())%>
                        </select>
                        </div>                    
                    </li>

                </ul>
                

       </div></form>
        <div class="guwen_list" style="margin-top:96px;">
            <%--<asp:Literal ID="LtlList" runat="server"></asp:Literal>--%>
            <ul>
                <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                <li data-huiyuanid="<%#Eval("UserId") %>" data-mingpianid="<%#Eval("MingPianId") %>">
                    <div class="guwen_head">
                        <div class="guwen_touxian radius">
                            <a href="javascript:void(0)" data-class="mingpian"><img src="<%#GetTuXiang(Eval("TuXiangFilepath")) %>"></a></div>
                        <div class="guwen_name">
                            旅游顾问：<%#Eval("ContactName") %></div>
                        <div class="font12">
                            <span class="floatR"><a href="javascript:void(0)" data-class="dianzan">赞(<%#Eval("ZanJiShu") %>)</a> <a href="javascript:void(0)" data-class="woyaoliuyan">评论(<%#Eval("LiuYanJiShu")%>)</a></span>认证日期：<%#Eval("LvYouGuWenRenZhengTime","{0:yyyy-MM-dd}") %>
                        </div>
                    </div>
                    <div class="guwen_txt">
                        <a href="javascript:void(0)" class="btn" data-class="woyaoliuyan">我要留言</a>
                        <div>
                            电话：<a href='tel:<%#Eval("ShouJi") %>'><%#Eval("ShouJi") %></a></div>
                        <div>
                            公司：<%#Eval("GongSiName") %></div>
                        <div>
                            地址：<%#Eval("DiZhi") %></div>
                    </div>
                </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            SelectInit: function() {
                $("#MyProvice").change(function() {
                location.href = "/HuiYuanWeiXin/LvYouGuWen.aspx?Level=1&MyProvice=" + $("#MyProvice").val() + "&MyCity=" + $("#MyCity").val() + "&MyArea=" + $("#MyArea").val() + "&MyStreet=" + $("#MyStreet").val() + "&MemberOption=" + $("#MemberOption").val();
                });
                $("#MyCity").change(function() {
                location.href = "/HuiYuanWeiXin/LvYouGuWen.aspx?Level=2&MyProvice=" + $("#MyProvice").val() + "&MyCity=" + $("#MyCity").val() + "&MyArea=" + $("#MyArea").val() + "&MyStreet=" + $("#MyStreet").val() + "&MemberOption=" + $("#MemberOption").val();
                });
                $("#MyArea").change(function() {
                location.href = "/HuiYuanWeiXin/LvYouGuWen.aspx?Level=3&MyProvice=" + $("#MyProvice").val() + "&MyCity=" + $("#MyCity").val() + "&MyArea=" + $("#MyArea").val() + "&MyStreet=" + $("#MyStreet").val() + "&MemberOption=" + $("#MemberOption").val();
            });
            $("#MyStreet").change(function() {
            location.href = "/HuiYuanWeiXin/LvYouGuWen.aspx?Level=4&MyProvice=" + $("#MyProvice").val() + "&MyCity=" + $("#MyCity").val() + "&MyArea=" + $("#MyArea").val() + "&MyStreet=" + $("#MyStreet").val() + "&MemberOption=" + $("#MemberOption").val();
            });
            },
            woYaoLiuYan: function(obj) {
                var _$li = $(obj).closest("li");
                window.location.href = "/huiyuanweixin/liuyan.aspx?huiyuanid2=" + _$li.attr("data-huiyuanid");
            },
            dianZan: function(obj) {
                var _$li = $(obj).closest("li");
                window.location.href = "/huiyuanweixin/dianzan.aspx?huiyuanid2=" + _$li.attr("data-huiyuanid");
            },
            mingPian: function(obj) {
                var _$li = $(obj).closest("li");
                window.location.href = "/huiyuanweixin/mingpian.aspx?mingpianid=" + _$li.attr("data-mingpianid");
            }
        };

        $(document).ready(function() {
            $('a[data-class="woyaoliuyan"]').click(function() { iPage.woYaoLiuYan(this); });
            $('a[data-class="dianzan"]').click(function() { iPage.dianZan(this); });
            $('a[data-class="mingpian"]').click(function() { iPage.mingPian(this); });
        });
        $(function() {
        iPage.SelectInit();
        });    
    </script>
</asp:Content>
