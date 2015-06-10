<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.AdminAdd" %>

<%@ Register Src="../userControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
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

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <!--tianjia----delete---star-->
    
    <style type="text/css">
    .c001 {vertical-align: middle; font-family: verdana;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 640px; margin: 10px auto;">
        <table class="Tborder" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tbody>
                <tr class="odd">
                    <th height="30" align="right">
                        用户名：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="userName" class="formsize140" id="userName" type="text" runat="server"
                            valid="required" errmsg="用户名不能为空！" />
                        <span class="errmsg">*</span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        姓名：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="ContactName" class="formsize140" id="ContactName" type="text" runat="server"
                            valid="required" errmsg="姓名不能为空！" />
                        <span class="errmsg">*</span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        密码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="userPwd" class="formsize140" id="userPwd" type="password" runat="server"
                            valid="required" errmsg="密码不能为空！" />
                        <span class="errmsg">*</span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        确认密码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="reuserPwd" class="formsize140" id="reuserPwd" type="password" runat="server"
                            valid="required" errmsg="确认密码不能为空！" />
                        <span class="errmsg">*</span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        手机号码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="tel" class="formsize140" id="tel" type="text" runat="server" valid="required|isMobile"
                            errmsg="手机号码不可为空!|手机号码错误!" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        备注：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="remark" class="formsize450" id="remark" type="text" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        公章：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <uc1:UploadControl ID="UploadSeal" runat="server" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                            IsUploadSelf="true" />
                        <asp:Label ID="lblsealimg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        账号类型：
                    </th>
                    <td bgcolor="#E3F1FC" style="line-height:30px;">
                        <input type="radio" id="txtLeiXing0" name="txtLeiXing" value="0" class="c001" /><label for="txtLeiXing0" class="c001">系统</label> 
                        <input type="radio" id="txtLeiXing1" name="txtLeiXing" value="1" class="c001" /><label for="txtLeiXing1" class="c001">供应商</label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="50" align="right">
                        说明：
                    </th>
                    <td bgcolor="#E3F1FC" style="line-height:25px; color:#333;">
                        1.供应商账号仅包含自有产品及订单的管理功能。<br />
                        2.供应商账号发布的产品需要审核后才会在平台展示。
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="width: 640px; margin: 10px auto;">
        <table style="margin: 10px auto;" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tbody>
                <tr class="odd">
                    <td colspan="14" height="40" bgcolor="#E3F1FC">
                        <table align="center" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td class="tjbtn02" align="center" width="80">
                                        <a href="javascript:;" onclick="return pageOpt.Save();" id="btnSave"><s class="baochun">
                                        </s>保 存</a>
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
            Params: {
                id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                dotype: '<%=EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>'
            },
            UnBindBtn: function() {
                $("#btnSave").unbind("click").addClass("alertbox-btn_a_active").html("<s class=\"baochun\"></s> 提交中...");
            },
            //删除附件
            RemoveFile: function(obj) {
                $(obj).parent().remove();
            },
            //按钮绑定事件
            BindBtn: function() {
                $("#btnSave").attr("class", "").html("<s class=\"baochun\"></s>保 存");
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
                if ($("#userPwd").val() != $("#reuserPwd").val()) {
                    parent.tableToolbar._showMsg("两次密码输入不一致！");
                    return false;
                }
                if (this.FormCheck()) {
                    pageOpt.UnBindBtn();
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/webMaster/AdminAdd.aspx?save=save&" + $.param(pageOpt.Params),
                        data: $("#btnSave").closest("form").serialize(),
                        dataType: "json",
                        success: function(ret) {
                            //ajax回发提示
                            if (ret.result == "1") {
                                parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/webMaster/AdminList.aspx"; });
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

        $(document).ready(function() {
            $("#txtLeiXing<%=LeiXing %>").attr("checked", "checked");
        });
    </script>

</body>
</html>
