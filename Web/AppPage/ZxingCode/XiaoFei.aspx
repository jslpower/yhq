<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaoFei.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.ZxingCode.XiaoFei" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="form_box">
        <ul>
            <asp:PlaceHolder ID="xiaofei" runat="server">
                <li>
                    <label>
                        下单人姓名：</label><p>
                            <input type="text" class="formsize200 input_botbk" value="" runat="server" id="cusName" />
                        </p>
                </li>
                <li>
                    <label>
                        下单人手机号：</label><p>
                            <input type="text" class="formsize200 input_botbk" value="" runat="server" id="cusMob" />
                        </p>
                </li>
                <li>
                    <label>
                        <font color=red>*</font>持码人手机：</label><p>
                            <input type="text" class="formsize200 input_botbk" value="" runat="server" id="appMob" />
                        </p>
                </li>
                <li>
                    <label>
                        产品名称：</label><p>
                            <input type="text" class="formsize200 input_botbk" value="" runat="server" id="proName" />
                        </p>
                </li>
                <%--                <li>
                    <label>
                        订单状态：</label><p>
                            <input name="" type="checkbox" value=""   />
                            已支付
                            <input name="" type="checkbox" value=""   />
                            已出票</p>
                </li>--%>
            </asp:PlaceHolder>
            <li>
                <p>
                    <asp:Label ID="lblxiaofei" runat="server" Text=""></asp:Label>
                </p>
            </li>
            <li>
                <p>
                    <asp:PlaceHolder ID="isXF" runat="server">
                        <button type="button" class="loginBtn" id="xiaofei" name="xiaofei">
                            确认消费</button>
                    </asp:PlaceHolder>
                    <button type="button" class="loginBtn" id="fanhui" name="fanhui">
                        返回</button>
                </p>
            </li>
        </ul>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            Params: {
                id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>',

                ordertype: '<%=EyouSoft.Common.Utils.GetQueryStringValue("ordertype") %>'
            }
        }
        $("#xiaofei").click(function() {
            if ($("#appMob").val() == "") {
                alert("请录入持码人手机!");
                return;
            }
            if (confirm(" 确认消费?")) {
                $.ajax({
                    type: "post",
                    url: "/AppPage/ZxingCode/XiaoFei.aspx?xiaofei=1&" + $.param(pageOpt.Params) + "&appMob=" + $("#appMob").val(),
                    dataType: "json",
                    success: function(ret) {

                        alert(ret.msg);
                        window.location.href = "/AppPage/ZxingCode/SaoMiao.aspx";

                    },
                    error: function() {
                        alert("信息错误");
                    }
                });
            }

        })
        $("#fanhui").click(function() {
            window.location.href = "SaoMiao.aspx";
        })
        
    </script>

</body>
</html>
