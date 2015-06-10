<%@ Page Title="订单管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.OrderList" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc2" %>
<asp:Content ID="ContentPlaceHead1" ContentPlaceHolderID="ContentPlaceHead" runat="server">

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <style type="text/css">
        .fukuan
        {
            margin: 2px 0px 2px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <form id="form1">
        <div class="MenberSearch">
            <b>交易时间：</b>
            <input type="text" onfocus="WdatePicker()" name="txtStartTime" id="txtStartTime"
                style="width: 80px;" size="10" class="txt" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStartTime") %>" />-<input
                    type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})" class="inputtext"
                    style="width: 80px;" name="txtEndTime" id="txtEndTime" size="10" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtEndTime") %>" />
            <b>线路名称：</b>
            <input type="text" id="txtRouteName" style="width: 120px;" name="txtRouteName" class="txt"
                value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtRouteName")%>" />
            <b>交易金额:</b>
            <input type="text" id="txtOrderPrice" style="width: 60px;" name="txtOrderPrice" class="txt"
                value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtOrderPrice")%>" />
            <input type="submit" class="searchbtn" value="搜索">
            <input type="button" class="searchbtn" value="扫码记录" runat="server" id="btnAppUser"
                visible="false" onclick="location.href='AppOrderList.aspx'">
        </div>
        </form>
        <table width="100%" border="0" class="tableList">
            <tbody>
                <tr>
                    <th height="32" align="center">
                        序号
                    </th>
                    <th align="center">
                        商品名称
                    </th>
                    <th align="center">
                        交易时间
                    </th>
                    <th align="center">
                        数量
                    </th>
                    <th align="center">
                        交易金额
                    </th>
                    <th align="center">
                        确认码
                    </th>
                    <th align="center">
                        消费状态
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpOrder">
                    <ItemTemplate>
                        <tr data-id="<%#Eval("OrderId") %>" data-contracttype="<%#Eval("ContractType") %>"
                            i_status="<%#Eval("OrderState") %>" i_fukuan="<%#Eval("PayState") %>">
                            <td height="28" bgcolor="#ffffff" align="center">
                                <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <a class="zxingBox" href="/printPage/OrderPrint.aspx?id=<%#Eval("OrderId") %>" target="_blank">
                                    <%# Eval("ProductName") %></a>&nbsp;<%# DownFile(Eval("SendFile"))%>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%# Eval("IssueTime")%>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%# Eval("PeopleNum")%>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <font class="font_f60">
                                    <%# Convert.ToDecimal(Eval("OrderPrice")).ToString("C0")%></font>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%# Eval("ConfirmCode")%>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%if (btnAppUser.Visible)
                                  { %>
                                <a href="AppOrderList.aspx?txtOrderCode=<%#Eval("OrderCode")%>">
                                    <%# Eval("XiaoFei")%></a>
                                <%}
                                  else
                                  { %>
                                <%# Eval("XiaoFei")%>
                                <%} %>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%# BindZhiFuBao(Eval("OrderID").ToString(), Eval("OrderState"), Eval("PayState"), Eval("IsealCheck"), Eval("ContractType"))%>
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

    <script type="text/javascript">
        var iPage = {
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            }
        };

        $(document).ready(function() {
            $(".hetong").bind("click", function() {
                var urlId = $(this).closest("tr").attr("data-id");
                var ContractType = encodeURI($(this).closest("tr").attr("data-Contracttype"));
                iPage.ShowBoxy({ iframeUrl: "/Huiyuan/AddressCheck.aspx?dotype=check&Id=" + urlId + "&ContractType=" + ContractType, title: "选择", width: "800px", height: "600px" });
            })
            $(".Yue").click(function() {
                var urlId = $(this).closest("tr").attr("data-id");
                iPage.ShowBoxy({ iframeUrl: "/Huiyuan/DetailBox.aspx?Id=" + urlId, title: "选择", width: "450", height: "250" });
            })
            //            $(".zxingBox").click(function() {
            //                var Id = $(this).closest("tr").attr("data-id");
            //                iPage.ShowBoxy({ iframeUrl: "/apppage/ZxingCode/ZXingCodeBox.aspx?tp=1&id=" + Id, title: "查看二维码", width: "320px", height: "240px" });
            //            })

        });
    </script>

</asp:Content>
