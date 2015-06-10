<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftRouteInfo.ascx.cs"
    Inherits="Eyousoft_yhq.Web.userControl.LeftRouteInfo" %>
<div class="Tjpic">
    <h3>
        看过此优惠券的人也看了</h3>
    <ul>
        <asp:Repeater ID="rpList" runat="server">
            <ItemTemplate>
                <li>
                    <div class="Tjpic_img">
                        <a href="RouteInfo.aspx?id=<%# Eval("ProductID")%>">
                            <%# getImg( Eval("ProductID").ToString())%>
                        </a>
                    </div>
                    <div class="Tjpic_title">
                        <a href="RouteInfo.aspx?id=<%# Eval("ProductID")%>">
                            <%# Eval("ProductName")%></a> <span>
                                <%# Convert.ToDecimal(Eval("AppPrice")).ToString("C0")%><i><%# Convert.ToDecimal(Eval("MarketPrice")).ToString("C0")%></i></span></div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="more_youhq">
        <a href="/Index.aspx?sale=2">更多优惠卷 &gt;&gt;</a></div>
</div>
