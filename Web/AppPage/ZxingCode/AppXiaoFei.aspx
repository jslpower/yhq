<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppXiaoFei.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.ZxingCode.AppXiaoFei" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="form_box">
        <ul>
            <asp:PlaceHolder ID="xiaofei" runat="server">
                <li>
                    <label>
                        客户姓名：</label><p>
                            <input type="text" class="formsize200 input_botbk" value="" runat="server" id="cusName" />
                        </p>
                </li>
                <li>
                    <label>
                        性别：</label><p>
                            <input type="text" class="formsize120 input_botbk" value="" runat="server" id="cusSex" />
                        </p>
                </li>
                <li>
                    <label>
                        手机号码：</label><p>
                            <input type="text" class="formsize200 input_botbk" value="" runat="server" id="cusMob" />
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
                        <button type="submit" class="loginBtn" id="xiaofei" name="xiaofei">
                            确认消费</button>
                    </asp:PlaceHolder>
                    <button type="submit" class="loginBtn" id="fanhui" name="fanhui">
                        返回</button>
                </p>
            </li>
        </ul>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            Params: {
                id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>'
            }
        }
        $("#xiaofei").click(function() {
            $.newAjax({
                type: "post",
                url: "/webMaster/AdminAdd.aspx?" + $.param(pageOpt.Params),
                success: function(ret) {
                    alert(ret.msg);
                },
                error: function() {
                    alert("信息错误");
                }
            });
        })
        $("#fanhui").click(function() {

        })
        
    </script>

</body>
</html>
