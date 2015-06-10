<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuYue.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.YuYue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <style type="text/css">
        .user_main
        {
            position: absolute;
        }
        .tijiao
        {
            background: url(/images/fabu_btn.gif) no-repeat;
            width: 90px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: #fff;
            font-weight: bold;
            font-size: 14px;
            display: inline-block;
            margin-left: 90px;
            float: left;
            display: inline;
        }
        .MenberSidebar02
        {
            display: inline;
            float: left;
            margin-left: 15px;
            width: 100%;
        }
        .address_box
        {
            overflow: hidden;
            padding: 10px;
        }
        .inputbg
        {
            height: 28px;
        }
        .formsize200
        {
            width: 300px;
            height: 60px;
            background-color: #fdfdfd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div class="user_main">
            <div class="address_box">
                <ul class="addr_form">
                    <li>
                        <label>
                            线路名称：</label><p>
                                <input type="text" class="inputbg" name="xianlu" runat="server" id="xianlu" /><span
                                    class="star">*</span></p>
                        <br />
                    </li>
                    <li>
                        <label>
                            预约人姓名：</label><p>
                                <input type="text" class="inputbg" name="xingming" runat="server" id="xingming" /><span
                                    class="star">*</span>
                            </p>
                        <br />
                    </li>
                    <li>
                        <label>
                            预约人手机：</label><p>
                                <input type="text" class="inputbg" name="shouji" runat="server" id="shouji" /><span
                                    class="star">*</span></p>
                        <br />
                    </li>
                    <li>
                        <label>
                            预约信息：</label><p>
                                <textarea rows="2" cols="2" name="xinxi" class="inputbg formsize200" runat="server"
                                    id="xinxi"></textarea></p>
                        <br />
                        <br />
                    </li>
                    <li>
                        <p>
                            <a class="tijiao" id="tijiao" name="tijiao" onclick=" return pageData.tijiao();">提 交</a></p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var pageData = {

            tijiao: function() {
                var u = $("[name=xianlu]").val().trim(), p = $("[name=xingming]").val().trim(), s = $("[name=shouji]").val().trim(), x = $("[name=xinxi]").val().trim();
                if (u == "") {
                    alert("请输入线路名称!");
                    $("[name=xianlu]").focus();
                    return false;
                }
                if (p == "") {
                    alert("请输入姓名");
                    $("[name=xingming]").focus();
                    return false;
                }
                if (s == "") {
                    alert("请输入手机号码");
                    $("[name=shouji]").focus();
                    return false;
                }
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/AppPage/weixin/YuYue.aspx?save=save",
                    dataType: "json",
                    data: $("#tijiao").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            location.href = location.href;
                        } else {
                            alert(ret.msg);
                        }
                    }
                });
            }
        };
    </script>

</body>
</html>
