<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jp_Orderdetail.aspx.cs"
    Inherits="Eyousoft_yhq.Web.Huiyuan.jp_Orderdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>订单查询</title>
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen">
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.boxy.js" type="text/javascript"></script>

    <style type="text/css">
        th
        {
            background: none;
            border-style: none;
            text-indent: 0px;
        }
        .tableList
        {
            margin: auto;
        }
    </style>
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
                        航空公司
                    </th>
                    <td align="left">
                        <asp:Label ID="lblCarrName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        航班号
                    </th>
                    <td align="left">
                        <asp:Label ID="lblCarrNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        离港时间
                    </th>
                    <td align="left">
                        <asp:Label ID="lblLeaveDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        离港地点
                    </th>
                    <td align="left">
                        <asp:Label ID="lblLeavePoint" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        到港时间
                    </th>
                    <td align="left">
                        <asp:Label ID="lblArrivDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        到港地点
                    </th>
                    <td align="left">
                        <asp:Label ID="lblArrivPoint" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        联系人
                    </th>
                    <td align="left">
                        <asp:Label ID="lblPeople" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        乘客信息
                    </th>
                    <td align="left" style="padding: 0px">
                        <table width="100%" border="0">
                            <tbody>
                                <tr>
                                    <th width="80">
                                        姓名
                                    </th>
                                    <th width="50">
                                        类型
                                    </th>
                                    <th width="120">
                                        证件号
                                    </th>
                                    <th width="100">
                                        手机号码
                                    </th>
                                    <th width="120">
                                        票号
                                    </th>
                                    <th width="100">
                                        行程单号
                                    </th>
                                </tr>
                                <asp:Literal ID="litYKs" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th>
                        送票地址
                    </th>
                    <td align="left">
                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        订单金额
                    </th>
                    <td align="left">
                        <asp:Label ID="lblOrderPrice" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <p style="text-align: center; margin-top: 30px">
            <a class="baocunbtn" href="javascript:;" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide(); return false;">
                关闭</a>
        </p>
    </div>
    </form>
</body>
</html>
