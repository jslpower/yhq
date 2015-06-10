<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_Search.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style.css" type="text/css" media="screen">
    <link href="/css/style_jp.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="myform" name="myform" method="post">
    <div class="header">
        <h1>
            国内机票查询</h1>
        <a href="javascript:;" class="returnico"></a><a href="tel:4008005216" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="search_form">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th align="left">
                        出发城市
                    </th>
                    <td>
                        <div class="s-input" id="ccity">
                            <input readonly="readonly" class="serInput" name="startcity" type="text" id="startcity"
                                value="<%=EyouSoft.Common.Utils.GetFormValue("startcity")==""?"太原-TYN": EyouSoft.Common.Utils.GetFormValue("startcity") %>" /></div>
                    </td>
                    <td width="54" rowspan="2" align="right">
                        <a id="exChange" href="javascript:;" class="s-rbtn"></a>
                    </td>
                </tr>
                <tr>
                    <th align="left">
                        到达城市
                    </th>
                    <td>
                        <div class="s-input">
                            <input readonly="readonly" class="serInput" name="endcity" type="text" id="endcity"
                                value="<%= EyouSoft.Common.Utils.GetFormValue("endcity") %>" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="left">
                        出发日期
                    </th>
                    <td colspan="2">
                        <div class="s-input">
                            <input readonly="readonly" class="serInput" name="rili" type="text" id="rili" value="<%= EyouSoft.Common.Utils.GetFormValue("rili")==string.Empty?DateTime.Now.ToShortDateString():EyouSoft.Common.Utils.GetFormValue("rili") %>" />
                        </div>
                    </td>
                </tr>
            </table>
            <p class="mt15">
                <input type="button" class="chaxun" value="查询" />
            </p>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            turnCity: function() {
                var temp = "";
                temp = $("#startcity").val();
                $("#startcity").val($("#endcity").val());
                $("#endcity").val(temp);
            },
            initInputClick: function() {
                $("#startcity,#endcity").onclick(function() { window.open })
            }

        };
        $(function() {
            $("#exChange").click(function() { pageOpt.turnCity(); });
            $("#startcity").click(function() { document.getElementById("myform").action = "SelectCity.aspx?type=0&weidianid=<%=WeiDianId %>"; document.getElementById("myform").submit(); })
            $("#endcity").click(function() { document.getElementById("myform").action = "SelectCity.aspx?type=1&weidianid=<%=WeiDianId %>"; document.getElementById("myform").submit(); })
            $("#rili").click(function() { document.getElementById("myform").action = "jp_RiLi.aspx?weidianid=<%=WeiDianId %>"; document.getElementById("myform").submit(); })
            $(".chaxun").click(function() {
                location.href = '/AppPage/weixin/jp_SearchList.aspx?' + $.param({ s: $("#startcity").val(), d: $("#endcity").val(), t: $("#rili").val(),weidianid:"<%=WeiDianId %>" })
            })

        })
    </script>

</body>
</html>
