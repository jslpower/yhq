<%@ Page Title="公告列表" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="Eyousoft_yhq.Web.NoticeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="productBox">
        <!------Msidebar-------->
        <div class="Msidebar">
            <!------gonggaoBox-------->
            <div class="gonggaoBox">
                <h3 class="ggTitle">
                    公告列表</h3>
                <ul class="ggList">
                    <asp:Repeater ID="rpt_Notices" runat="server">
                        <ItemTemplate>
                            <li><a href="/NoticeInfo.aspx?NotIceId=<%# Eval("ArticleID")%>">
                                <%# Eval("ArticleTitle")%></a><span class="gg_date">
                                    <%# Eval("IssueTime", "{0:yyyy年MM月dd日}")%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <!------page-------->
                <div  class="page">
                    <div id="paging"  class="pagebox fixed">
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                var pagingConfig = { pageSize: 20, pageIndex: 1, recordCount: 0, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'paging' };
                $(function() {
                    if (pagingConfig.recordCount > 0) AjaxPageControls.replace("paging", pagingConfig);
                });
            </script>

        </div>
        <div class="Rsidebar">
            <div class="Tjpic">
                <h3>
                    惠旅游推荐</h3>
                <ul>
                    <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="Tjpic_img">
                                    <a href="RouteInfo.aspx?id=<%# Eval("ProductID")%>">
                                        <%# getImg( Eval("ProductID").ToString())%></a></div>
                                <div class="Tjpic_title">
                                    <a href="RouteInfo.aspx?id=<%# Eval("ProductID")%>">
                                        <%# Eval("ProductName")%></a> <span>
                                            <%# Convert.ToDecimal(Eval("AppPrice")).ToString("C0")%><i>
                                                <%# Convert.ToDecimal(Eval("MarketPrice")).ToString("C0")%></i></span></div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="more_youhq">
                    <a href="/Index.aspx?ishot=1">更多推荐 &gt;&gt;</a></div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
    </form>
</asp:Content>
