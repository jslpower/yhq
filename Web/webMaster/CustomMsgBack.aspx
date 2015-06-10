<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomMsgBack.aspx.cs"
    Inherits="Eyousoft_yhq.Web.webMaster.CustomMsgBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <style type="text/css">
        .msgbox
        {
            border: 1px solid #B9B9B9;
            height: 68px;
            width: 100%;
            margin: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="98%" cellspacing="0" cellpadding="3" bordercolor="#CCCCCC" border="1"
        align="center" id="tableInfo">
        <tbody>
            <tr class="lr_hangbg">
                <td align="left">
                    <textarea class="msgbox" id="txtMsg" name="txtMsg"></textarea>
                </td>
            </tr>
            <tr>
                <td height="35" align="center" colspan="2">
                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td height="20" align="center" class="tjbtn02">
                                    <a href="javascript:" id="btnSave" onclick="javascript:pageOpt.Save();">发送</a>
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
        var pageOpt = {
            Params: {
                openid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("openid") %>'
            },
            UnBindBtn: function() {
                $("#btnSave").unbind("click").html(" 提交中...");
            },
            //按钮绑定事件
            BindBtn: function() {
                $("#btnSave").attr("class", "").html("发送");
                $("#btnSave").click(function() {
                    pageOpt.Save();
                    return false;
                });
            },
            FormCheck: function() {

                this.Form = $("#btnSave").closest("form").get(0)
                FV_onBlur.initValid(this.Form);
                return ValiDatorForm.validator(this.Form, "parent");

            },
            Save: function() {

                if (this.FormCheck()) {
                    pageOpt.UnBindBtn();
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/webMaster/CustomMsgBack.aspx?save=save&" + $.param(pageOpt.Params),
                        data: $("#btnSave").closest("form").serialize(),
                        dataType: "json",
                        success: function(ret) {
                            //ajax回发提示
                            if (ret.result == "1") {
                                parent.tableToolbar._showMsg(ret.msg, function() { window.location.href = window.location.href; });
                            } else {
                                parent.tableToolbar._showMsg(ret.msg);
                            }
                            pageOpt.BindBtn();
                        },
                        error: function() {
                            parent.tableToolbar._showMsg("操作失败，请稍后再试!");
                            pageOpt.BindBtn();
                        }
                    });
                }
            }
        };
    </script>

</body>
</html>
