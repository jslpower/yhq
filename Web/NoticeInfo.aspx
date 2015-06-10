<%@ Page Title="公告" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="NoticeInfo.aspx.cs" Inherits="Eyousoft_yhq.Web.NoticeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!------lanmu_T-------->
    <div class="lanmu_T">
        您所在位置：首页 &gt; 公告信息 &gt; <span class="font_f60">
            <asp:Label ID="lbl_menu" runat="server" Text=""></asp:Label></span></div>
    <!------productBox-------->
    <div class="productBox">
        <!------Msidebar-------->
        <div class="Msidebar">
            <!------gonggaoBox-------->
            <div class="gonggaoBox">
                <div class="gg_xxT">
                    <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label><span><asp:Label ID="lbl_time"
                        runat="server" Text=""></asp:Label></span></div>
                <div class="gg_Cont">
                    <asp:Literal ID="lit_text" runat="server"></asp:Literal>
                </div>
                <div class="gg_xxT">
                </div>
                <div class="gg_Cont">
                    <asp:Literal ID="lit_file" runat="server"></asp:Literal>
                </div>
            </div>
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
</asp:Content>
