<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_Schedule.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_Schedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <h1>
            订单核对</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="#" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="shenhe_box">
            <div class="shenhe_list">
                <div class="shenhe_L">
                    航班信息</div>
                <div class="shenhe_R">
                    <ul>
                        <li>
                            <div class="flight_binfo">
                                <div class="flight_binfo_end">
                                    <p>
                                        09-10 周五</p>
                                    <p class="flight_time">
                                        12:20</p>
                                </div>
                                <div class="flight_binfo_from">
                                    <p>
                                        09-10 周五</p>
                                    <p class="flight_time">
                                        10:25</p>
                                </div>
                                <div class="flight_binfo_direction">
                                    <span>飞行时长：2小时05分</span>
                                </div>
                            </div>
                        </li>
                        <li class="botline">南方航空CZ6412</li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    订单信息</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline pt6">
                            <p>
                                乘客数量：2 人<br />
                                票价：￥236<br />
                                机/油：￥170<br />
                                保险：40<br />
                                快递：20<br />
                                总计：<span class="price"><dfn>¥</dfn>827</span></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    乘机人</div>
                <div class="shenhe_R">
                    <ul>
                    <asp:Literal ID="litPassger" runat="server"></asp:Literal>
                        <li class="botline pt6">
                            <p>
                                姓名：王冰<br />
                                身份证：330124198902112496</p>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <p class="mt15 padd">
            <input id="" type="button" class="chaxun" value="提交订单" /></p>
    </div>
    </form>
</body>
</html>
