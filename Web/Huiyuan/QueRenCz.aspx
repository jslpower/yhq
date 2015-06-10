<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueRenCz.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.QueRenCz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="font14"
        style="margin: 15px auto;">
        <tr>
            <th height="40" align="center" class="boder_bot">
                充值金额：
            </th>
            <th height="40" align="left" class="boder_bot">
                <asp:Label ID="lblchongzhijine" runat="server" Text=""></asp:Label>
            </th>
        </tr>
    </table>
    <table width="90%" border="0" style="margin: 15px auto;">
        <tr>
            <td align="center" class="tjbtn02">
                <asp:Label ID="lblzhifuURL" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
