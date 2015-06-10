<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zxingCodePrint.aspx.cs"
    Inherits="Eyousoft_yhq.Web.webMaster.zxingCodePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/print.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/jquery.easydrag.handler.beta2.js" type="text/javascript"></script>

    <style type="text/css">
        .inputtext
        {
            outline: none;
            border: solid 1px #93B7CE;
            font-size: 12px;
            padding: 1px 2px;
            height: 80px;
            transition: all 0.5s;
            -o-transition: all 0.5s;
            -moz-transition: all 0.5s;
            -ms-transition: all 0.5s;
            -webkit-transition: all 0.5s;
            border-radius: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" visible="true">
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
                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="" align="center" class="tjbtn02">
                                    <a id="btnSeal" href="javascript:;"><s class="baochun"></s>打印</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>

    <script type="text/javascript">
        $(function() {
            $("#btnSeal").click(function() {
                $(this).hide();
                window.print();
                $(this).show();
            })
        })
    </script>

</body>
</html>
