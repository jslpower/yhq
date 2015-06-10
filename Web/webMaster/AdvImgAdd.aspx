<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvImgAdd.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.AdvImgAdd" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
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
    <div style="width: 640px; margin: 10px auto;">
        <table class="Tborder" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tbody>
                <tr class="odd">
                    <th height="30" align="right">
                        产品名称：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="ddlPname" valid="required" errmsg="请选择产品！">
                            <%=BindPro(EyouSoft.Common.Utils.GetQueryStringValue("pid"))%>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        手机图片：
                        <br />
                        推荐尺寸(320*160)
                    </th>
                    <td bgcolor="#E3F1FC">
                        <uc1:UploadControl runat="server" ID="upload1" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                            IsUploadSelf="true" />
                        <asp:Label ID="lblfile" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        网站图片：
                        <br />
                        推荐尺寸(960*160)
                    </th>
                    <td bgcolor="#E3F1FC">
                        <uc1:UploadControl runat="server" ID="upload2" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                            IsUploadSelf="true" />
                        <asp:Label ID="lblwebfile" runat="server" Text=""></asp:Label>
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
              Params:{
              id:"<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>",
              dotype:"<%=EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>"
            },
              //删除附件
            RemoveFile: function(obj) {
                $(obj).parent().remove();
            },
            UnBindBtn: function() {
               $("#btnSave").unbind("click").addClass("alertbox-btn_a_active").html("<s class=\"baochun\"></s> 提交中...");
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
                if (this.FormCheck()) {
                pageOpt.UnBindBtn();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/AdvImgAdd.aspx?save=save&" + $.param(pageOpt.Params),
                    data: $("#btnSave").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                        parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/webMaster/AdvImgList.aspx"; });
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
