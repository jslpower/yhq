<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPrint.aspx.cs" Inherits="Eyousoft_yhq.Web.printPage.OrderPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="yhq_print">
        <div class="yhq_box">
            <div class="print_title">
                <img src="/images/logo2.gif" /></div>
            <div class="print_cont">
                <h5>
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></h5>
                <h3>
                    使用有效期：<asp:Label ID="lblVdate" runat="server" Text=""></asp:Label><br />
                    确认码：<asp:Label ID="lblVcode" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="">
                <asp:Label ID="lblCodeImg" runat="server" Text=""></asp:Label></div>
            <div class="print_btn">
                <a id="aprint" onclick="wprint();" href="javascript:;">打印</a></div>
        </div>
        <div class="more-msg">
            更多信息请访问 <a href="http://www.4008005216.com/">http://www.4008005216.com/</a></div>
    </div>
    </form>

    <script type="text/javascript">
        function wprint() {
            document.getElementById("aprint").style.display = "none";
            window.print();
            document.getElementById("aprint").style.display = "block";
        }
    </script>

</body>
</html>
