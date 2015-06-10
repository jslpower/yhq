<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="InsOrders.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.InsOrders" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <form id="form1">
        <div class="MenberSearch">
        </div>
        </form>
        <table width="100%" border="0" class="tableList">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        序号
                    </th>
                    <th align="center">
                        订单号
                    </th>
                    <th align="center">
                        保险单号
                    </th>
                    <th align="center">
                        保险名称
                    </th>
                    <th align="center">
                        下单人
                    </th>
                    <th align="center">
                        订单状态
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpOrder">
                    <ItemTemplate>
                        <tr>
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <%#Eval("OrderCode") %>
                            </td>
                            <td align="center">
                                <%#Eval("InsNO")%>
                            </td>
                            <td align="center">
                                <%#Eval("InsName")%>
                            </td>
                            <td align="center">
                                <%#Eval("OperatorName")%>
                            </td>
                            <td align="center">
                                <%#Eval("State")%>
                            </td>
                            <td align="center">
                                <a href="javascript:;">修改</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right">
                    <cc2:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
