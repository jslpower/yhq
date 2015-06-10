<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailBox.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.DetailBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.boxy.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 10px">
        <table width="95%" border="0" class="tableList">
            <tbody>
                <tr>
                    <th width="80">
                        订单号
                    </th>
                    <td align="left">
                        <asp:Label ID="lblOrderNO" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        产品名称
                    </th>
                    <td align="left">
                        <asp:Label ID="lblProName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        交易金额
                    </th>
                    <td align="left">
                        <asp:Label ID="lblTran" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        下单时间
                    </th>
                    <td align="left">
                        <asp:Label ID="lblOrderTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <p style="text-align: center; margin-top: 30px">
            <a id="a_Pay" class="baocunbtn" href="javascript:;">保存</a> <a class="baocunbtn" href="javascript:;"
                onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide(); return false;">
                关闭</a>
        </p>
    </div>
    </form>

    <script type="text/javascript">
        var iPage = {
            id: '<%=Request.QueryString["Id"]%>',
            save: function() {
                $("#a_Pay").unbind("click");
                $.ajax({
                    url: '/Huiyuan/DetailBox.aspx?save=save&id=' + iPage.id,
                    dataType: "json",
                    success: function(ret) { parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = parent.window.location.href }); },
                    error: function() { parent.tableToolbar._showMsg("操作失败，请稍后再试!"); }
                })
                $("#a_Pay").bind("click", function() { iPage.save() });
            }

        }
        $(function() {
            $("#a_Pay").click(function() {
                iPage.save();
            })
        })
    </script>

</body>
</html>
