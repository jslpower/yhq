<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChouJiangs.aspx.cs" Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.ChouJiangs" %>

<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <meta name="format-detection" content="telephone=no" />
    <title>中奖纪录</title>
    <link rel="stylesheet" href="/css/basic.css" type="text/css" media="screen">
    <link rel="stylesheet" href="/css/weixin/user.css" type="text/css" media="screen">
</head>
<body>
    <div class="warp">
        <div class="basic_t cent">
            中奖记录</div>
        <div class="padd10">
            <div class="zhongj_mx">
                <div class="font16 paddB bot_line">
                    中奖记录明细：</div>
                <div class="zhongj_mx_head">
                    <ul class="clearfix">
                        <li>时间</li>
                        <li>微点</li>
                    </ul>
                </div>
                <div class="zhongj_mx_list bot_line">
                    <ul class="clearfix">
                        <asp:Repeater ID="rptlist" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%# Eval("ChouJiangShiJian","{0:yyyy-MM-dd}") %></li>
                                <li>+<%#Eval("DianShu","{0:F2}")%></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="zhongj_mx_head" style="border-bottom: none 0;">
                    <ul class="clearfix">
                        <li>总计</li>
                        <li>
                            <asp:Literal ID="ltrSumMoney" runat="server">0</asp:Literal></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
