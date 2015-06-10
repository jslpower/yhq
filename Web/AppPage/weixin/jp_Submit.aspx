<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_Submit.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_Submit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <div id="orderper">
        <form id="form1" action="jp_Schedule.aspx" runat="server">
        <div class="header">
            <h1>
                订单填写
            </h1>
            <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216"
                class="icon_phone"></a>
        </div>
        <div id="mainbox" class="mainbox" runat="server">
            <div class="flight_info">
                <h3>
                    航班信息</h3>
                <div class="flight_binfo botline">
                    <asp:HiddenField ID="ADT" runat="server" />
                    <asp:HiddenField ID="CHD" runat="server" />
                    <asp:HiddenField ID="INF" runat="server" />
                    <div class="flight_binfo_end">
                        <p>
                            <asp:Label ID="lblsDate" runat="server" Text=""></asp:Label>
                        </p>
                        <p class="flight_time">
                            <asp:Label ID="lblsTime" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <div class="flight_binfo_from">
                        <p>
                            <asp:Label ID="lbleDate" runat="server" Text=""></asp:Label>
                        </p>
                        <p class="flight_time">
                            <asp:Label ID="lbleTime" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <div class="flight_binfo_direction">
                    </div>
                </div>
                <div class="flight_binfo">
                    <p>
                        <asp:Label ID="lblHkNameCode" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="lblMoneyInfo" runat="server" Text=""></asp:Label>
                    </p>
                </div>
            </div>
            <div class="flight_info">
                <h3>
                    乘机人信息</h3>
                <div class="flight_preson">
                    <ul>
                        <li class="list temp">
                            <div class="flight_box">
                                <div class="del_btn">
                                </div>
                                <div class="flight_form">
                                    <ul>
                                        <li>
                                            <label>
                                                姓 名：</label><input class="ckName input-style" name="ckName" type="text" value="" /></li>
                                        <li>
                                            <label>
                                                类 型：</label>
                                            <select name="ckYKLX" class="sl">
                                                <option value="ADT">成人</option>
                                                <option value="CHD">儿童</option>
                                                <option value="INF">婴儿</option>
                                            </select>
                                            <span class="font_red">12周岁以上算成人 12周岁以下算儿童 2周岁以下算婴儿</span> </li>
                                        <li>
                                            <label>
                                                证件类型：</label>
                                            <select name="ckZJLX">
                                                <option value="NI">身份证</option>
                                                <option value="FOID">护照</option>
                                                <option value="ID">其他证件</option>
                                            </select></li>
                                        <li>
                                            <label>
                                                证件号码：</label><input class="ckCard input-style" name="ckCard" type="text" value="" />
                                        </li>
                                        <li>
                                            <label>
                                                手机号：</label><input class="ckMobile input-style" name="ckMobile" type="text" value="" /></li>
                                        <li>
                                            <label>
                                                购买保险：</label><input name="ckBaoXian" type="checkbox" value="1" style="vertical-align: -2px;" /></li>
                                    </ul>
                                </div>
                            </div>
                        </li>
                        <li id="li_box"></li>
                        <li class="list"><a href="javascript:;" class="add_btn">添加更多乘机人</a> </li>
                        <li class="list">机票：<span class="number"> <i class="num-minus"></i>
                            <input name="ck_R" id="ck_R" type="text" value="1"><i class="num-add"></i></span>
                        </li>
                        <li class="list">送票地址：<input id="jpadress" name="jpadress" type="text" class="address_input">
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="mainbox" style="height: 55px;">
            <div class="pay_box">
                <%-- <div class="pay_total">
                <i>订单总额：</i><span class="price"><dfn>¥</dfn><asp:Label ID="lblOrderSum" runat="server"
                    Text=""></asp:Label></span></div>--%>
                <div class="pay_btn">
                    <a href="javascript:;" id="next_Step" data-id="1" class="step_btn">下一步</a>
                </div>
            </div>
        </div>
        <input type="hidden" id="HBbox" name="HBbox" />
        <input type="hidden" id="JCbox" name="JCbox" />
        <input type="hidden" id="pPrice" name="pPrice" />
        <input type="hidden" id="classcode" name="classcode" value="<%=ClassCode %>" />
        </form>
        <form id="form99" action="jp_Schedule.aspx" method="post" name="form99" visible="false">
        <input type="hidden" id="HBbox1" name="HBbox" />
        <input type="hidden" id="HBbox2" name="JCbox" />
        </form>
        <div id="hidHB" style="display: none">
            <%= Request.Form["HBbox"]%>
        </div>
        <div id="hidJC" style="display: none">
            <%= Request.Form["JCbox"]%>
        </div>
    </div>
    <div id="surOrder">
        <div class="header">
            <h1>
                订单核对</h1>
            <a href="javascript:backorder();" class="returnico"></a><a href="#" class="icon_phone">
            </a>
        </div>
        <div class="mainbox">
            <div class="shenhe_box">
                <div class="shenhe_list">
                    <div class="shenhe_L">
                        航班信息
                    </div>
                    <div class="shenhe_R">
                        <ul>
                            <li>
                                <div class="flight_binfo">
                                    <div class="flight_binfo_end">
                                    </div>
                                    <div class="flight_binfo_from">
                                    </div>
                                    <div class="flight_binfo_direction">
                                        <%-- <span>飞行时长：2小时05分</span>--%>
                                    </div>
                                </div>
                            </li>
                            <li class="botline2">南方航空CZ6412</li>
                        </ul>
                    </div>
                </div>
                <div class="shenhe_list">
                    <div class="shenhe_L">
                        订单信息
                    </div>
                    <div id="pporder" class="shenhe_R">
                        <ul>
                            <li class="botline pt6"></li>
                        </ul>
                    </div>
                </div>
                <div class="shenhe_list">
                    <div class="shenhe_L">
                        乘机人
                    </div>
                    <div id="passerss" class="shenhe_R">
                        <ul>
                        </ul>
                    </div>
                </div>
            </div>
            <p class="mt15 padd">
                <input id="subOrder" type="button" class="chaxun" value="提交订单" />
            </p>
        </div>
    </div>

    <script type="text/javascript">
        var inputdata = null;
        var jpMoney=0;
        $(function() {
            $("#surOrder").hide();
            $(".flight_binfo_end").html("<p>" + $("#lblsDate").html() + "</p><p class=\"flight_time\">" + $("#lblsTime").html() + "</p>");
            $(".flight_binfo_from").html("<p>" + $("#lbleDate").html() + "</p><p class=\"flight_time\">" + $("#lbleTime").html() + "</p>");
            $(".flight_binfo_direction").html("");

        })
        var pageOpt = {
            removeLinkMan: function() {
                $(".del_btn").click(function() {
                    if ($("li.temp").length > 1) {
                        $(this).closest("li.temp").remove();
                    }
                    else {
                        alert("最少保留一位乘客信息");
                    }
                })
            },
            addLinkMan: function() {
                $(".add_btn").click(function() {
                    var strHTML = $("li.temp").eq(0).clone();
                    strHTML.find("input").val("");
                    $("#li_box").append(strHTML);
                    strHTML.find(".del_btn").bind("click", function() {
                        if ($("li.temp").length > 1) {
                            $(this).closest("li.temp").remove();
                        }
                        else {
                            alert("最少保留一位乘客信息");
                        }
                    });
                })
            },
            initSetNum: function() {
                $(".num-minus").click(function() {
                    var temp = $(this).parent().find("input").eq(0);
                    var num = parseInt(temp.val());
                    if (num > 1) {
                        temp.val(num - 1);
                    }
                })
                $(".num-add").click(function() {
                    var temp = $(this).parent().find("input").eq(0);
                    var num = parseInt(temp.val());
                    temp.val(num + 1);
                })
            },
            validaPage: function() {
                $("#next_Step").click(function() {
                    var msg = "";
                    var ckNameArr = $(".ckName");
                    $(".botline2").html($("#lblHkNameCode").html());
                    var pprice = $("#tprice").html().substring(12, $("#tprice").html().length) * $(".ckName").length;
                    $("#pPrice").val(pprice);
                    for (var i = 0; i < ckNameArr.length; i++) {
                        if (!/^[\s\S]+$/.test($(ckNameArr[i]).val())) {
                            msg += "第" + (i + 1) + "个游客姓名不可为空 \n";
                        }
                    }

                    var ckCardArr = $(".ckCard");
                    for (var j = 0; j < ckCardArr.length; j++) {
                        if (!/^[\s\S]+$/.test($(ckCardArr[j]).val())) {
                            msg += "第" + (j + 1) + "个游客身份信息不可为空 \n";
                        }
                    }
                    if (!/^[\s\S]+$/.test($("#jpadress").val())) {
                        msg += "送票地址不能为空 \n";
                    }
                    var names = $(".ckName");
                    var ckCards = $(".ckCard");
                    var ckBiaoXians = $("input[name='ckBaoXian']");

                    var carttypes = $(".ckZJLX");
                    if (names.length > 0) {
                        var ss = '';
                        var carttye = '';

                        for (j = 0; j < names.length; j++) {
                            var checkb = ckBiaoXians[j].checked;
                            var checkstr = '';
                            if (checkb)
                                checkstr = checkstr + "<input name=\"ckBaoXian\" type=\"checkbox\" checked=\"checked\" disabled=\"disabled\" value=\"1\" />";
                            else
                                checkstr = checkstr + "<input name=\"ckBaoXian\" type=\"checkbox\" disabled=\"disabled\"  value=\" \" />";
                            ss = ss + "<li class=\"botline pt6\"><p>姓名：" + names.eq(j).val() + "<br/> 身份证：" + ckCards.eq(j).val() + "<br/>保险：" + checkstr + "</p></li>";

                            $("#passerss>ul").html(ss);
                        }
                    }
                    var bb = '';

                    //var totalprice=parseInt
                    var stet = "<p>乘客数量：" + names.length + "人<br />票价：" + $("#sprice").html() + "<br />机/油：" + $("#jprice").html() + "<br />保险：0<br />快递:0<br />总计：<span class=\"price\" id=\"TPrice\"><dfn>¥</dfn></span></p>";

                    $("#pporder>ul").html(stet);
                    //计算总价
                    var moneys = 0;
                    $('.sl').each(function() {

                        var code = '#' + $(this).val();
                        moneys = moneys + parseInt($(code).val());


                    })
                    jpMoney=moneys;
                    $("#TPrice").html("<dfn>¥</dfn>" + moneys);

                    if ($('#next_Step').attr("data-id") == 1) {


                        $('#next_Step').attr("data-id", 2);
                    }
                    if (msg == "") {
                        $("#HBbox").val($("#hidHB").html());
                        $("#JCbox").val($("#hidJC").html());
                        //验证通过后显示确认页面
                        $("#surOrder").show();
                        $("#orderper").hide();
                        //处理表单
                    }
                    else {
                        alert(msg);
                        return false;
                    }
                })
            }
        }
        $(function() {
            pageOpt.removeLinkMan();
            pageOpt.addLinkMan();
            pageOpt.initSetNum();
            pageOpt.validaPage();
            $("#subOrder").one("click", function() {

                $.ajax({
                    type: "post",
                    url: "jp_Submit.aspx?save=save&jpmoney="+jpMoney+"&weidianid=<%=WeiDianId %>",
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            window.location.href = "jp_Orders.aspx";
                        }
                        else {
                            alert(ret.msg);
                        }
                    }
                });


            })
        })
        function backorder() {
            $("#surOrder").hide();
            $("#orderper").show();
        }
        
    </script>

</body>
</html>
