<%@ Page Title="订单管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="AppOrderList.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.AppOrderList" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc2" %>
<asp:Content ID="ContentPlaceHead1" ContentPlaceHolderID="ContentPlaceHead" runat="server">

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

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
            <b>消费时间：</b>
            <input type="text" onfocus="WdatePicker()" name="txtXStartTime" id="txtXStartTime"
                style="width: 80px;" size="10" class="txt" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXStartTime") %>" />-<input
                    type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtXStartTime\')}'})" class="inputtext"
                    style="width: 80px;" name="txtXEndTime" id="txtXEndTime" size="10" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXEndTime") %>" />
            <b>订单号：</b>
            <input type="text" id="txtOrderCode" style="width: 80px;" name="txtOrderCode" class="txt"
                value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtOrderCode")%>" />            
            <input type="submit" class="searchbtn" value="搜索">
        </div>
        </form>
        <table width="100%" border="0" class="tableList">
            <tbody>
                <tr>
                    <th height="32" align="center">
                        序号
                    </th> 
                    <th align="center">
                        订单号
                    </th>
                    <th align="center">
                        商品名称
                    </th>
                    <th align="center">
                        交易时间
                    </th>
                    <th align="center">
                        消费时间
                    </th>
                    <th align="center">
                        持码人
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
                                <%# Eval("OrderCode")%>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%# Eval("ProductName") %>
                            </td>
                            <td bgcolor="#ffffff" align="center">
                                <%# Eval("IssueTime")%>
                            </td>
                             <td bgcolor="#ffffff" align="center">
                                <%# Eval("AppTime")%>
                            </td>
                           
                            <td bgcolor="#ffffff" align="center">
                                <%# Eval("AppMobNo")%>
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
            //            $(".zxingBox").click(function() {
            //                var Id = $(this).closest("tr").attr("data-id");
            //                iPage.ShowBoxy({ iframeUrl: "/apppage/ZxingCode/ZXingCodeBox.aspx?tp=1&id=" + Id, title: "查看二维码", width: "320px", height: "240px" });
            //            })

        });
    </script>

</asp:Content>
