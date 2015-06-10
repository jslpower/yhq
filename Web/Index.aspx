<%@ Page Title="首页" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Eyousoft_yhq.Web.Index" %>

<%@ Register Src="/userControl/MaqueeShow.ascx" TagName="MaqueeShow" TagPrefix="uc1" %>
<%@ Register Src="/userControl/AdImgList.ascx" TagName="AdImgList" TagPrefix="uc2" %>
<asp:Content ID="ContentPlaceHead1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
        <uc1:MaqueeShow ID="MaqueeShow1" runat="server" />
        <uc2:AdImgList ID="AdImgList1" runat="server" />
        <div class="tongji">
            <div class="app_down">
                <a href="/DownApp.aspx" target="_blank">
                    <img src="/images/app_down.jpg" /></a></div>
            <div class="tongji_box fixed">
                <ul>
                    <li class="Rline" style="width: 90px;">
                        <%=fuwushang %><span>旅游顾问</span></li>
                    <li class="Rline" style="width: 120px;">
                        <%=dingdanliang %><span>订单量 </span></li>
                    <li  style="width: 150px;">
                        <%=chengjiaoe %><span> 成交额</span></li>
                </ul>
                <div class="tj_btn">
                    <a href="/Register.aspx">立即加入</a><span>创业不从零开始 </span>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
    <div class="listbox">
        <div class="paixu_box">
            <ul>
                <li>排序：</li>
                <%--  <li><a id="ishot" <%=tj %> href="javascript:;">惠旅游推荐<span></span></a></li>--%>
                <li><a id="sale" <%=xl %> href="javascript:;">销量<span></span></a></li>
                <li><a id="issue" <%=zx %> href="javascript:;">最新<span></span></a></li>
                <li><a id="price" <%=jg %> href="javascript:;">价格<span></span></a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server">
            <div class="fenlei_box">
                <ul>
                    <li>分类：</li>
                    <%= Initfenlei(EyouSoft.Common.Utils.GetQueryStringValue("routype"))%>
                </ul>
                <div class="clear">
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="img_list">
            <ul>
                <asp:Repeater ID="rpt_products" runat="server">
                    <ItemTemplate>
                        <li class='<%# (Container.ItemIndex+1)%3==0?"marginR":"" %>'>
                            <dl>
                                <dt><a href="RouteInfo.aspx?id=<%# Eval("ProductID")%> ">
                                    <img style="width: 281px; height: 169px;" src="<%# getProImg(Eval("ProductID").ToString())%>" /></a></dt>
                                <dd class="name">
                                    <a href="RouteInfo.aspx?id=<%# Eval("ProductID")%>">
                                        <%# EyouSoft.Common.Utils.GetText2(Eval("ProductName").ToString(), 14, true)%>
                                    </a>
                                </dd>
                                <dd class="cont">
                                    <%# EyouSoft.Common.Utils.GetText2(Eval("ProductDis").ToString(), 30, true)%>
                                </dd>
                                <dd class="price">
                                    ¥<span><%# Convert.ToDecimal(Eval("AppPrice")).ToString("0")%></span></dd>
                                <dd class="oriprice">
                                    原价:<span><%# Convert.ToDecimal(Eval("MarketPrice")).ToString("C0")%></span></dd>
                                <dd class="chakan">
                                    <a href="RouteInfo.aspx?id= <%# Eval("ProductID")%>">
                                        <img src="/images/chakan.gif" /></a></dd>
                                <dd class="total">
                                    <div class="num">
                                        <b class="font_f60">
                                            <%# Eval("SaleNum")%></b>人已购买</div>
                                    <div class="deadline">
                                        剩余时间：<%# getOverTime( Eval("IsEveryDay").ToString() ,Eval("ValidiDate").ToString())%></div>
                                </dd>
                            </dl>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="clear">
            </div>
        </div>
        <!------page-------->
        <div class="page">
            <div id="paging" class="pagebox fixed">
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var pagingConfig = { pageSize: 20, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'paging' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("paging", pagingConfig);
        });
    </script>

    <script type="text/javascript">
        var pageOpt = {
            parm: {
                routype: '<%=Request.QueryString["routype"] %>',
                ishot: '<%=Request.QueryString["ishot"] %>',
                sale: '<%=Request.QueryString["sale"] %>',
                issue: '<%=Request.QueryString["issue"] %>',
                price: '<%=Request.QueryString["price"] %>'
            },
            GoSearch: function() {

                var url = "/Index.aspx?" + $.param(pageOpt.parm)
                location.href = url;
            }
        };
        $(function() {
            $("#ishot").click(function() {
                if (tableToolbar.getInt(pageOpt.parm.ishot) == 0) {
                    pageOpt.parm.ishot = tableToolbar.getInt(pageOpt.parm.ishot) + 1;
                    pageOpt.GoSearch();
                }
                else {
                    pageOpt.parm.ishot = 0;
                    pageOpt.GoSearch();
                }
            })//
            $("#sale").click(function() {
                if (tableToolbar.getInt(pageOpt.parm.sale) == 1) {
                    pageOpt.parm.sale = 2;
                    pageOpt.GoSearch();
                }
                else if (tableToolbar.getInt(pageOpt.parm.sale) == 2) {
                    pageOpt.parm.sale = 0;
                    pageOpt.GoSearch();
                }
                else {
                    pageOpt.parm.sale = 1;
                    pageOpt.GoSearch();
                }
            })//g
            $("#issue").click(function() {

                if (tableToolbar.getInt(pageOpt.parm.issue) == 1) {
                    pageOpt.parm.issue = 2;
                    pageOpt.GoSearch();
                }
                else if (tableToolbar.getInt(pageOpt.parm.issue) == 2) {
                    pageOpt.parm.issue = 0;
                    pageOpt.GoSearch();
                }
                else {
                    pageOpt.parm.issue = 1;
                    pageOpt.GoSearch();
                }
            })//
            $("#price").click(function() {
                if (tableToolbar.getInt(pageOpt.parm.price) == 1) {
                    pageOpt.parm.price = 2;
                    pageOpt.GoSearch();
                }
                else if (tableToolbar.getInt(pageOpt.parm.price) == 2) {
                    pageOpt.parm.price = 0;
                    pageOpt.GoSearch();
                }
                else {
                    pageOpt.parm.price = 1;
                    pageOpt.GoSearch();
                }
            })//
        })
    
    </script>

    <form id="form1" runat="server">
    </form>
</asp:Content>
