<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HuiYuanLeftMenu.ascx.cs"
    Inherits="Eyousoft_yhq.Web.userControl.HuiYuanLeftMenu" %>
<div class="MenberSidebar">
    <h5>
        会员服务</h5>
    <div class="left_menu">
        <ul>
            <li><a <%=M1 %> href="/Huiyuan/PersonalInfo.aspx">个人资料</a></li>
            <li><a <%=M2 %> href="/Huiyuan/OrderList.aspx">旅游订单</a></li>
            <li><a <%=M9 %> href="/Huiyuan/hyjp_Orders.aspx">机票订单</a></li>
            <li><a <%=M10 %> href="/Huiyuan/InsOrders.aspx">保险订单</a></li>
            <li><a <%=M8 %> href="/Huiyuan/Account.aspx">账户管理</a></li>
            <li><a <%=M3 %> href="/Huiyuan/AddressManage.aspx">地址管理</a></li>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                <li><a <%=M4 %> href="/Huiyuan/TGlist.aspx">推广记录</a></li>
                <li><a <%=M5 %> href="/Huiyuan/FYlist.aspx">返佣记录</a></li>
                <li><a <%=M6 %> href="/Huiyuan/JClist.aspx">培训课程</a></li>
                <li><a <%=M7 %> href="/Huiyuan/PlanTicketManage.aspx">机票管理</a></li>
                <li><a id="RegLogin" href="/CommonPage/RegUrl.aspx?type=anget" target="_blank">机票分销</a></li>
            </asp:PlaceHolder>
        </ul>
    </div>
</div>
