<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_OrderDetail.aspx.cs"
    Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_OrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <h1>
            订单详情</h1>
        <a href="#" class="returnico"></a><a href="#" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="shenhe_box dindan_ck">
            <div class="shenhe_list">
                <div class="shenhe_L">
                    订单号</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblOrderNO" runat="server" Text=""></asp:Label>
                            </p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    航空公司</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblCarrName" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    航班号</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblCarrNo" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    离港时间</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblLeaveDate" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    离港地点</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblLeavePoint" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    到港时间</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblArrivDate" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    到港地点</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblArrivPoint" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    联系人</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblPeople" runat="server" Text=""></asp:Label></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    送票地址</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                            </p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    订单金额</div>
                <div class="shenhe_R">
                    <ul>
                        <li class="botline">
                            <p>
                                <span class="price"><dfn></dfn>
                                    <asp:Label ID="lblOrderPrice" runat="server" Text=""></asp:Label></span></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="shenhe_list">
                <div class="shenhe_L">
                    乘客信息</div>
                <div class="shenhe_R">
                    <ul>
                        <asp:Literal ID="litYKs" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="mainbox" style="height: 55px;">
        <div class="pay_box">
            <div class="pay_btn">
                <a href="javascript:window.history.go(-1);" class="step_btn">返回</a></div>
        </div>
    </div>
    </form>
</body>
</html>
