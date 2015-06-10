<%@ Page Title="机票管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="PlanTicketManage.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.PlanTicketManage" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <form id="form1">
        <div class="MenberSearch">
            <b>客户名称：</b>
            <input type="text" name="cusName" id="cusName" style="width: 80px;" size="10" class="txt"
                value="<%=EyouSoft.Common.Utils.GetQueryStringValue("cusName") %>" />
            <b>联系电话：</b>
            <input type="text" id="cusMob" style="width: 120px;" name="cusMob" class="txt" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("cusMob")%>" />
            <b>机票编号：</b>
            <input type="text" id="GysTicket" style="width: 120px;" name="GysTicket" class="txt"
                value="<%=EyouSoft.Common.Utils.GetQueryStringValue("GysTicket")%>" />
            <input type="submit" class="searchbtn" value="搜索">
        </div>
        </form>
        <div class="MenberSearch tj">
            <input id="btnAdd" type="button" class="searchbtn" value="添加" />
        </div>
        <table width="100%" border="0" class="tableList">
            <tbody>
                <tr>
                    <th>
                        客户名称
                    </th>
                    <th>
                        性别
                    </th>
                    <th>
                        联系电话
                    </th>
                    <th>
                        机票编号
                    </th>
                    <th>
                        订单状态
                    </th>
                    <th>
                        支付状态
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpTicket">
                    <ItemTemplate>
                        <tr data-id="<%#Eval("ID") %>">
                            <td align="center">
                                <a class="zxingBox" href="javascript:;">
                                    <%# Eval("CusName")%></a>
                            </td>
                            <td align="center">
                                <%# Eval("CusSex")%>
                            </td>
                            <td align="center">
                                <%# Eval("CusMob")%>
                            </td>
                            <td align="center">
                                <%# Eval("PlaneTicket")%>
                            </td>
                            <td align="center">
                                <%# Eval("orderState")%>
                            </td>
                            <td align="center">
                                <%# Eval("payState")%>
                            </td>
                            <td align="center">
                                <a href="javascript:;" data-id="<%# Eval("ID")%>" class="toolbar_update">修改</a>
                                | <a href="javascript:;" data-id="<%# Eval("ID")%>" class="toolbar_delete">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="NoMsg" runat="server"></asp:Literal>
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

        $(function() {
            $("#btnAdd").click(function() {
                Boxy.iframeDialog({
                    iframeUrl: "/Huiyuan/PlanTicketAdd.aspx?dotype=add",
                    title: "机票添加",
                    modal: true,
                    width: "600px",
                    height: "450px"
                });
            })


            $("a.toolbar_update").click(function() {
                Boxy.iframeDialog({
                    iframeUrl: "/Huiyuan/PlanTicketAdd.aspx?dotype=edit&id=" + $(this).attr("data-id"),
                    title: "机票修改",
                    modal: true,
                    width: "600px",
                    height: "450px"
                });
            })


            $(".zxingBox").click(function() {
                Boxy.iframeDialog({
                    iframeUrl: "/AppPage/ZxingCode/ZXingCodeBox.aspx?tp=2&id=" + $(this).closest("tr").attr("data-id"),
                    title: "查看二维码",
                    modal: true,
                    width: "250px",
                    height: "250px"
                });
            })

            $(".toolbar_delete").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("是否删除该记录？", function() {
                    $.ajax({
                        type: "post",
                        cache: false,
                        url: "/Huiyuan/PlanTicketManage.aspx?del=1&id=" + id,
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() {
                                    location.href = "/Huiyuan/PlanTicketManage.aspx";
                                });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg);
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                        }
                    });
                });
            })


        })   
    

 
    </script>

</asp:Content>
