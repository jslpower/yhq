<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_Orders.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_Orders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <style type="text/css">
        .load
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <h1>
            订单查询</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216"
            class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="dindan_box">
            <div class="jp_nav">
                <ul class="fixed">
                    <li><a href="/AppPage/weixin/orderlist.aspx">旅游列表</a></li>
                    <li class="on"><a href="/AppPage/weixin/jp_Orders.aspx">机票列表</a></li>
                </ul>
            </div>
        </div>
        <div class="dindan_box" id="n4Tab">
            <div class="TabTitle">
                <ul class="fixed">
                    <asp:Literal ID="litHead" runat="server"></asp:Literal>
                </ul>
            </div>
            <div class="TabContent">
                <div id="n4Tab_Content0" class="<%=style1 %>">
                    <div class="dindan_list">
                        <ul>
                            <asp:Literal ID="litNoPay" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
                <div id="n4Tab_Content1" class="<%=style2 %>">
                    <div class="dindan_list">
                        <ul>
                            <asp:Literal ID="litPay" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            save: function(obj) {

                if (window.confirm("确认支付?")) {
                    $(".a_pay").unbind("click");
                    $.ajax({
                        type: "post",
                        cache: false,
                        url: "/AppPage/weixin/jp_Orders.aspx?zf=1&id=" + $(obj).attr("data-id") + "&op=" + $(obj).attr("data-money"),
                        dataType: "json",
                        success: function(ret) {
                            alert(ret.msg);
                            $(".a_pay").bind("click", function() { pageOpt.save() })
                        },
                        error: function() {
                            alert("未知错误！")
                            $(".a_pay").bind("click", function() { pageOpt.save() })
                        }
                    });
                }

            }
        }
        $(function() {
            $(".a_pay").click(function() {
                pageOpt.save(this);
            });


            $(".dindan_L").click(function() {
                $(".load").hide();
                $(this).parent().children(".load").show();
            })



        })
    </script>

</body>
</html>
