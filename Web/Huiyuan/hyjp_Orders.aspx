<%@ Page Title="机票管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="hyjp_Orders.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.hyjp_Orders" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc2" %>
<asp:Content ID="ContentPlaceHead1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.boxy.js" type="text/javascript"></script>

    <style type="text/css">
        .tj
        {
            background: none;
            border-style: none;
            text-indent: 0px;
        }
        .grey
        {
            color: #474747;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu2" runat="server" />
    <div class="MenberSidebar02">
        <table width="100%" border="0" class="tableList">
            <tbody>
                <tr>
                    <th>
                        订单号
                    </th>
                    <th>
                        下单人姓名
                    </th>
                    <th>
                        下单时间
                    </th>
                    <th>
                        机票支付状态
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpOrders">
                    <ItemTemplate>
                        <tr data-id="<%#Eval("OrderCode") %>">
                            <td align="center">
                                <a class="zxingBox" href="javascript:;">
                                    <%# Eval("OrderCode")%></a>
                            </td>
                            <td align="center">
                                <%# Eval("OpeatorName")%>
                            </td>
                            <td align="center">
                                <%# Eval("IssueTime")%>
                            </td>
                            <td align="center">
                                <%# Eval("payState")%>
                            </td>
                            <td align="center">
                                <%# GetHtml(Eval("PayState"), Eval("OrderCode").ToString(), Eval("OrderID").ToString())%>
                                <a href="javascript:;" data-id="<%# Eval("OrderCode")%>" class="toolbar_update">详情</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbMsg" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right">
                    <cc2:ExporPageInfoSelect ID="ExporPageInfoSelect2" runat="server" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">



        var pageOpt = {
            //弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            }, //
            save: function(obj) {

                if (window.confirm("确认支付?")) {
                    $(".payzf").unbind("click");
                    $.ajax({
                        type: "post",
                        cache: false,
                        url: "/Huiyuan/hyjp_Orders.aspx?zf=1&id=" + $(obj).attr("data-id") + "&op=" + $(obj).attr("data-money"),
                        dataType: "json",
                        success: function(ret) {
                            alert(ret.msg);
                            window.location = window.location;
                        },
                        error: function() {
                            alert("未知错误！")
                            $(".payzf").bind("click", function() { pageOpt.save() })
                        }
                    });
                }

            }
        }
        $(function() {
            $(".toolbar_update").click(function() {
                pageOpt.ShowBoxy({ iframeUrl: "/Huiyuan/jp_Orderdetail.aspx?ordercode=" + $(this).attr("data-id"), title: "订单详情", width: "750px", height: "500px" });
            });
        })



        $(".payzf").click(function() {
            pageOpt.save(this);
        });
      
    

 
    </script>

</asp:Content>
