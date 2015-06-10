<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouJiShiPinAdd.aspx.cs"
    Inherits="Eyousoft_yhq.Web.HuiYuanWeiXin.YouJiShiPinAdd" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>视频游记</title>
    <link href="/css/weixin/basic.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/minpian.css" rel="stylesheet" type="text/css" />
    <link href="/css/weixin/youji.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="warp">
        <div class="youji_main">
            <div class="youji_fabu_title">
                <span>标题：</span><asp:TextBox ID="txttitle" CssClass="u-input" runat="server"></asp:TextBox></div>
            <div class="youji_fabu_box" style="background-color: #F4F4F4;">
                <ul>
                    <li class="txt"><span>链接：</span>
                        <asp:TextBox ID="txtlink" CssClass="u-input" runat="server" placeholder="例如:http://http://www.4008005216.com/"></asp:TextBox>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <input id="yid" name="yid" type="hidden" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("yid") %>" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
        <div class="bot">
            <div class="bot_box">
                <a href="javascript:void(0)" class="y_btn">分享 我为自己代言</a>
            </div>
        </div>
    </asp:PlaceHolder>
    </form>

    <script type="text/javascript">
        $(function() {
            $(".y_btn").click(function() {
                if ($("#<%=txttitle.ClientID %>").val() == "" || $("#<%=txtlink.ClientID %>").val() == "") {
                    alert("填写标题和视频地址");
                    return false;
                }
                var rex = /^http[s]?:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
                if (!rex.test($("#<%=txtlink.ClientID %>").val())) {
                    alert("视频地址格式不正确")
                    return false;
                }
                $.ajax({ type: "POST", url: "YouJiShiPinAdd.aspx?dotype=baocun", data: $(this).closest("form").serialize(), dataType: "json",
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            window.location.href = "/huiyuanweixin/mingpian.aspx";
                        }
                    },
                    error: function() {
                        alert("未知错误");
                    }
                });
            })
        })
    </script>

</body>
</html>
