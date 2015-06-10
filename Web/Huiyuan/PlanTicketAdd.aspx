<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanTicketAdd.aspx.cs"
    Inherits="Eyousoft_yhq.Web.Huiyuan.PlanTicketAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/js/ajaxpagecontrols.js" type="text/javascript"></script>

</head>
<body>
    <form runat="server" id="form1">
    <ul class="addr_form">
        <li>
            <label>
                客户姓名：</label><p>
                    <input name="contactname" type="text" class="formsize200 inputbg" runat="server"
                        id="contactname" valid="required" errmsg="客户姓名不能为空！" /><span class="star">*</span></p>
        </li>
        <li>
            <label>
                性别：</label><p>
                    <asp:DropDownList ID="dl_sex" runat="server">
                    </asp:DropDownList>
        </li>
        <li>
            <label>
                手机号码：</label><p>
                    <input name="contactmob" type="text" class="formsize200 inputbg" runat="server" id="contactmob"
                        valid="required|isMobile" errmsg="手机号码不能为空！|手机号码格式不正确！" /><span class="star">*</span></p>
        </li>
        <li>
            <label>
                机票订单号：</label><p>
                    <input name="contacticket" type="text" class="formsize200 inputbg" runat="server"
                        id="contacticket" valid="required" errmsg="机票订单号不能为空！" /><span class="star">*</span></p>
        </li>
        <li style="height: auto">
            <label>
                备注：</label><p>
                    <textarea style="width: 380px; height: 140px;" class="inputbg" name="remark" id="remark"
                        runat="server"></textarea></p>
        </li>
        <li>
            <p style="margin-left: 10em;">
                <button class="baocunbtn" id="btnsave" onclick="return false">
                    保 存</button></p>
        </li>
    </ul>
    </form>

    <script type="text/javascript">

        var pageOpt = {
            parm: {
                id: '<%=Request.QueryString["id"] %>',
                dotype: '<%=Request.QueryString["dotype"] %>'
            },
            pageSave: function() {
                $("#btnsave").val("提交中").unbind("click").css({ "color": "#999999" });

                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/Huiyuan/PlanTicketAdd.aspx?save=save&" + $.param(pageOpt.parm),
                    dataType: "json",
                    data: $("#btnsave").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/Huiyuan/PlanTicketManage.aspx"; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg);
                            pageOpt.bindBtn();
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(tableToolbar.errorMsg);
                        pageOpt.bindBtn();
                    }
                });
            },
            bindBtn: function() {
                $("#btnsave").val("提交注册").bind("click", function() {
                    $(this).css({ "color": "" });
                    return false;
                });
            }
        };

        $(function() {
            $("#btnsave").click(function() {

                if (ValiDatorForm.validator($("#btnsave").closest("form").get(0), "parent")) {
                    pageOpt.pageSave();
                }
            })
        })
    </script>

</body>
</html>
