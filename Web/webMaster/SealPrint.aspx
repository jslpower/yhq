<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SealPrint.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.SealPrint"
    ValidateRequest="false" %>

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
    <asp:Literal ID="contractHTML" runat="server"></asp:Literal>
    </form>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="">
                    <td height="40" bgcolor="" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" align="center" class="tjbtn02">
                                        <form id="form2">
                                        <input type="hidden" id="saveHTML" name="saveHTML" />
                                        <input type="hidden" id="isCheck" name="isCheck" value="0" />
                                        <a id="btnSave" href="javascript:;"><s class="baochun"></s>保存合同</a>
                                        </form>
                                    </td>
                                    <td width="80" align="center" class="tjbtn02">
                                        <a id="btnSeal" href="javascript:;"><s class="baochun"></s>盖章</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="">
                    <td height="40" bgcolor="" colspan="14" align="center">
                        该订单还未签订合同！
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:PlaceHolder>

    <script type="text/javascript">
        $(function() {
            $("#form1").append('<%=SealImg %>')
            $("input[type=text],textarea").change(function() {
                $(this).attr("data-text", $(this).val())
            })
            $("input[type=text],textarea").each(function() {
                $(this).val($(this).attr("data-text"));
            })
            $("#Gimg").easydrag();
            $("#btnSeal").click(function() {
                if ($("#Gimg").attr("src") == "") {
                    alert("您还未上传公章,请上传后执行此操作！");
                    return false;
                }
                var X = tableToolbar.getInt($("#inputImg").offset().left);
                var Y = tableToolbar.getInt($("#inputImg").offset().top);

                if ($("#isCheck").val() == "0") {
                    $("#Gimg").css({ display: "block", position: "absolute", left: X, top: Y });
                    $("#isCheck").val("1")
                }
                else {
                    $("#Gimg").css({ display: "none", position: "absolute", left: X, top: Y });
                    $("#isCheck").val("0")
                }
            })
            $("#btnSave").click(function() {
                var dataForm = $("#btnSave").closest("form");
                $(this).remove();
                $("#btnSeal").remove();
                $("#saveHTML").val($("#form1").html());
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/SealPrint.aspx?save=save&id=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                    data: dataForm.serialize(),
                    dataType: "json",
                    success: function(ret) {
                        tableToolbar._showMsg(ret.msg, function() { window.location.reload(); });
                    },
                    error: function() {
                        tableToolbar._showMsg("服务器繁忙，请稍后再试！");
                    }
                });
            })

        })
    </script>

</body>
</html>
