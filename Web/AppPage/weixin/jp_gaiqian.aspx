<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_gaiqian.aspx.cs" ValidateRequest="false"
    Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_gaiqian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>航班选择</title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Literal ID="lgq" runat="server"></asp:Literal>
    </form>
</body>

<script type="text/javascript">
    $(function() {
        $(".returnico").click(function() {
            window.history.go(-1);
        })
    })

</script>

</html>
