<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JpOrderdtail.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.JpOrderdtail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />
    <link href="/css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="/js/jquery.js"></script>

    <script language="javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/js/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <style type="text/css">
        .first th, .first td
        {
            line-height: 30px;
            border: #E3F1FC solid 1px;
            padding-left: 10px;
        }
    </style>
    <!--tianjia----delete---star-->
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 10px">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" class="first">
            <tbody>
                <tr class="odd">
                    <th width="80">
                        订单号
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtOrderNO" runat="server" CssClass="searchinput formsize100" disabled="disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        航空公司
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblCarrName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        航班号
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblCarrNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        离港时间
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblLeaveDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        离港地点
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblLeavePoint" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        到港时间
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblArrivDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        到港地点
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblArrivPoint" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        联系人
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblPeople" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        乘客信息
                    </th>
                    <td align="left" style="padding: 0px" bgcolor="#E3F1FC">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" class="first">
                            <tbody>
                                <tr class="odd">
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
                <tr class="odd">
                    <th>
                        送票地址
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th>
                        订单金额
                    </th>
                    <td align="left" bgcolor="#E3F1FC">
                        <asp:Label ID="lblOrderPrice" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                    <tr class="odd">
                        <th>
                            订单状态
                        </th>
                        <td align="left" bgcolor="#E3F1FC">
                            <asp:DropDownList ID="ddl_orderState" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:PlaceHolder>
            </tbody>
        </table>
        <table style="margin: 10px auto;" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tbody>
                <tr class="odd">
                    <td colspan="14" height="40" bgcolor="#E3F1FC">
                        <table align="center" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
                                        <td class="tjbtn02" align="center" width="80">
                                            <a id="save" href="javascript:;">保 存</a>
                                        </td>
                                    </asp:PlaceHolder>
                                    <td class="tjbtn02" align="center" width="80">
                                        <a href="javascript:;" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide(); return false;">
                                            关 闭</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            code: '<%= EyouSoft.Common.Utils.GetQueryStringValue("orderid") %>',
            pageSave: function() {
                $("#save").unbind("click");
                $.ajax({
                    type: "post",
                    url: "/webMaster/JpOrderdtail.aspx?opt=save&code=" + pageOpt.code,
                    data: $("#save").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = parent.window.location.href; });
                        } else {
                            parent.tableToolbar._showMsg(ret.msg);
                        }
                        $("#save").bind("click", function() { pageOpt.pageSave(); })
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(ret.msg);
                        $("#save").bind("click", function() { pageOpt.pageSave(); })
                    }
                });
            }
        };
        $(function() {
            $("#save").click(function() {
                pageOpt.pageSave();
            })
            $("#<%=ddl_orderState.ClientID %>").change(function() {
                if ($(this).val() != "2") {
                    $("#<%=txtOrderNO.ClientID %>").attr("disabled", "disabled");
                }
                else {
                    $("#<%=txtOrderNO.ClientID %>").removeAttr("disabled");
                }
            })
        })
    </script>

</body>
</html>
