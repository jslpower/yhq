<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_WxQRCODE.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.weixin.jp_WxQRCODE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <title></title>
    <link href="/css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="">
                    <td height="40" bgcolor="" align="center">
                        <asp:Label ID="ZXING" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="">
                    <td height="40" bgcolor="" colspan="14">
                        <center>
                            <a href="javascript:history.go(-1)"><s class="baochun"></s>返回</a></center>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
