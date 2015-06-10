<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JpOrderEdit.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.JpOrderEdit" %>

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

    <!--tianjia----delete---star-->
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; margin: 10px auto;">
        <table class="Tborder" align="center" border="0" cellpadding="0" cellspacing="0"
            width="98%">
            <tbody>
                <tr class="odd">
                    <th height="30" align="right">
                        客户姓名：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="searchinput formsize100"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        手机号码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="lblIphone" runat="server" CssClass="searchinput formsize100"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        订单状态：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:DropDownList ID="ddl_orderState" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="width: 100%; margin: 10px auto;">
        <table style="margin: 10px auto;" align="center" border="0" cellpadding="0" cellspacing="0"
            width="98%">
            <tbody>
                <tr class="odd">
                    <td height="40" bgcolor="#E3F1FC">
                        <table align="center" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td class="tjbtn02" align="center" width="80">
                                        <a id="savedata" href="javascript:;">保 存</a>
                                    </td>
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
            id: '<%=Request.QueryString["id"]%>'
        }
        $("#savedata").click(function() {
            $.ajax({
                type: "post",
                url: "/webMaster/JpOrderEdit.aspx?save=save&id=" + pageOpt.id,
                data: $("#savedata").closest("form").serialize(),
                dataType: "json",
                success: function(ret) {
                    //ajax回发提示
                    if (ret.result == "1") {
                        parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/webMaster/JpOrderList.aspx"; });
                    } else {
                        parent.tableToolbar._showMsg(ret.msg);
                    }

                },
                error: function() {
                    parent.tableToolbar._showMsg(ret.msg);
                }
            });


        })
       
       
    </script>

</body>
</html>
