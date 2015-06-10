<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_RiLi.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_RiLi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="myform" method="post" action="jp_Search.aspx?weidianid=<%=Request.QueryString["WeiDianId"] %>">
    <div class="header">
        <h1>
            日期选择</h1>
        <a href="javascript:window.history.go(-1);" class="returnico"></a><a href="tel:4008005216" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <asp:Literal ID="litMonth" runat="server"></asp:Literal>
        <asp:Literal ID="litNextMonth" runat="server"></asp:Literal>
        
<input type="hidden" name="rili" id="rili"  value="<%= EyouSoft.Common.Utils.GetFormValue("rili") %>" />

        <input type="hidden" name="startcity" id="startcity" value="<%= EyouSoft.Common.Utils.GetFormValue("startcity") %>" />
<input type="hidden" name="endcity" id="endcity" value="<%= EyouSoft.Common.Utils.GetFormValue("endcity") %>" />
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            $("a.selectDate").click(function() {
                
                $("#rili").val($(this).attr("data-rili"));
               document.getElementById("myform").submit();
            })
        })
    </script>

</body>
</html>
