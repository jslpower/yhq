<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCity.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.SelectCity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>选择城市</title>
    <link href="/css/style_jp.css" rel="stylesheet" type="text/css" media="screen" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/jipiao.sanzima.js" type="text/javascript"></script>

</head>
<body>
    <form id="myform" method="post" action="jp_Search.aspx?weidianid=<%=Request.QueryString["WeiDianId"] %>">
    <div class="header">
        <h1>
            选择出发城市</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="search_city">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="s_icon">
                    </td>
                    <td class="s_input">
                        <input id="citySeachBox" name="citySeachBox" type="text" value="请输入城市拼音/中文" />
                    </td>
                    <td class="s_btn">
                        <input onclick="javascript:$('[name=citySeachBox]').val('');" type="button">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="mainbox">
        <ul class="city-itmes">
            <li><span class="city-t">热门城市</span>
                <ul id="remen" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">A</span>
                <ul id="A" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">B</span>
                <ul id="B" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">C</span>
                <ul id="C" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">D</span>
                <ul id="D" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">E</span>
                <ul id="E" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">F</span>
                <ul id="F" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">G</span>
                <ul id="G" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">H</span>
                <ul id="H" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">I</span>
                <ul id="I" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">J</span>
                <ul id="J" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">K</span>
                <ul id="K" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">L</span>
                <ul id="L" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">M</span>
                <ul id="M" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">N</span>
                <ul id="N" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">O</span>
                <ul id="O" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">P</span>
                <ul id="P" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">Q</span>
                <ul id="Q" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">R</span>
                <ul id="R" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">S</span>
                <ul id="S" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">T</span>
                <ul id="T" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">U</span>
                <ul id="U" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">V</span>
                <ul id="V" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">W</span>
                <ul id="W" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">X</span>
                <ul id="X" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">Y</span>
                <ul id="Y" class="city-name">
                </ul>
            </li>
            <li><span class="city-t">Z</span>
                <ul id="Z" class="city-name">
                </ul>
            </li>
        </ul>
        <input type="hidden" name="startcity" id="startcity" value="<%= EyouSoft.Common.Utils.GetFormValue("startcity") %>" />

<input type="hidden" name="endcity" id="endcity" value="<%= EyouSoft.Common.Utils.GetFormValue("endcity") %>" />
<input type="hidden" name="rili" id="rili"  value="<%= EyouSoft.Common.Utils.GetFormValue("rili") %>" />
    </div>
    </form>

    <script type="text/javascript">
    $(function(){
    $(".cicode").eq(0).hide();
    
    })
        var pageOpt = {
            initCityList: function(guolv) {
                var dataBox = [];
                if (guolv != "" && guolv != 'undefined' && guolv != null) {
                    for (var k = 0; k < jiPiaoSanZiMaData.length; k++) {
                        if (jiPiaoSanZiMaData[k].CityName.toUpperCase().indexOf(guolv.toUpperCase()) >= 0
                        || jiPiaoSanZiMaData[k].PY2.toUpperCase().indexOf(guolv.toUpperCase()) >= 0
                        || jiPiaoSanZiMaData[k].PY1.toUpperCase().indexOf(guolv.toUpperCase()) >= 0) {
                            dataBox.push(jiPiaoSanZiMaData[k]);
                        }
                    }
                }
                else {
                    dataBox = jiPiaoSanZiMaData;
                }
                var rm = "";
                $(".city-t").parent().find("ul").html('');
                for (var i = 0; i < 8; i++) {
                    if (jiPiaoSanZiMaData[i].IsReDian == true) {
                        rm += '<li class="ckLi" data-Code=' + jiPiaoSanZiMaData[i].Code + '>' + jiPiaoSanZiMaData[i].CityName + '<span style=\'display:none;\' class=\'cicode\'>' +'-'+ jiPiaoSanZiMaData[i].Code + '</span><li>'
                    }
                }
                $("#remen").append(rm);

                for (var j = 0; j < dataBox.length; j++) {
                    $("#" + dataBox[j].PY3.replace(/(^\s*)|(\s*$)/g, "")).append('<li  class="ckLi" data-Code=' + dataBox[j].Code + '>' + dataBox[j].CityName + '<span style=\'display:none;\' class=\'cicode\'>' +'-'+ dataBox[j].Code + '</span><li>')
                }
                $(".city-name").each(function() {
                    if ($(this).html().replace(/(^\s*)|(\s*$)/g, "") == '') {
                        $(this).parent().hide();
                    } else {
                        $(this).parent().show();
                    }
                })
                pageOpt.initClick();
            },
            
            initClick: function() {
                $("#citySeachBox").click(function() { if ($(this).val() == '请输入城市拼音/中文') $(this).val('') })
                $(".ckLi").click(function() {
                    var word = $(this).text().replace(/(^\s*)|(\s*$)/g, "");
                    
                    //var box = $(window.opener.document);
                    var type = '<%= EyouSoft.Common.Utils.GetQueryStringValue("type") %>';
                                    

                    if (type == "0") {
                        $("#startcity").val(word);
                    }
                    else {

                        $("#endcity").val(word);
                    }
                    document.getElementById("myform").submit();
                    
                })
            }

        }
        function gopage()
        {
                          document.getElementById("myform").submit();

        }
        $(function() {
            pageOpt.initCityList();
            $("#citySeachBox").keyup(function() {
                pageOpt.initCityList($(this).val().replace(/(^\s*)|(\s*$)/g, ""));
            })

        })
    </script>

</body>
</html>
