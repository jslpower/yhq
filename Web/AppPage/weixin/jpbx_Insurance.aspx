<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jpbx_Insurance.aspx.cs"
    Inherits="Eyousoft_yhq.Web.AppPage.weixin.jpbx_Insurance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>无标题文档</title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <h1>
            保单填写</h1>
        <a href="#" class="returnico"></a><a href="#" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <h3>
            投保个人信息</h3>
        <div class="search_form">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th align="left">
                        出发日期
                    </th>
                    <td>
                        <div class="input_sytle">
                            <input onclick="javascript:window.open('jp_RiLi.aspx')" name="txtstartTime" id="txtstartTime"
                                type="text" value="" /></div>
                    </td>
                    <td width="20" align="center" class="font_red">
                        *
                    </td>
                </tr>
                <tr>
                    <th align="left">
                        电子邮箱
                    </th>
                    <td>
                        <div class="input_sytle">
                            <input name="txtMail" type="text" id="txtMail" value="" /></div>
                    </td>
                    <td width="20" align="center" class="font_red">
                        *
                    </td>
                </tr>
                <tr>
                    <th align="left">
                        通讯地址
                    </th>
                    <td>
                        <div class="input_sytle">
                            <input name="txtAddress" type="text" id="txtAddress" value="" /></div>
                    </td>
                    <td width="20" align="center" class="font_red">
                        *
                    </td>
                </tr>
                <tr>
                    <th align="left">
                        邮政编码
                    </th>
                    <td>
                        <div class="input_sytle">
                            <input name="txtZipCode" type="text" id="txtZipCode" value="" /></div>
                    </td>
                    <td width="20" align="center" class="font_red">
                        *
                    </td>
                </tr>
            </table>
            <p class="mt15">
                <input id="btn_save" type="button" class="chaxun" value="确认并提交" /></p>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            validatorPage: function() {
                $("#btn_save").click(function() {
                    var msg = "";
                    if (!/^\d{4}-\d{1,2}-\d{1,2}$/.test($("#txtstartTime").val())) {
                        msg += "日期格式错误 \n";
                    }
                    if (!/([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)/.test($("#txtMail").val())) {
                        msg += "邮箱格式错误 \n";
                    }
                    if (!/^[\s\S]+$/.test($("#txtAddress").val())) {
                        msg += "通讯地址不可为空 \n";
                    }
                    if (!/^[1-9]\d{5}$/.test($("#txtZipCode").val())) {
                        msg += "邮政编码错误 \n";
                    }
                    if (msg == "") {
                        //提交订单
                    }
                    else {
                        alert(msg);
                        return false;
                    }
                })
            }

        };
        $(function() {
            pageOpt.validatorPage();
        })
    </script>

</body>
</html>
