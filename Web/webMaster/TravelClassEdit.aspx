<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelClassEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TravelClassEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>旅游资讯类别</title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="520" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="16%" height="30" align="right">
                    <font color="red">*</font>类别名称：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox CssClass="inputtext formsize260" ID="txtAreaName" runat="server"></asp:TextBox>
                    <span id="tip" class="errmsg" style="display: none"><font color="red">请填写类别名称</font></span>
                    <input id="hidIsSystme" type="hidden" runat="server" value="0" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    排序数字：
                </th>
                <td bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox ID="txtSort" runat="server" Text="0" CssClass="formsize50 inputtext"
                        name="txtSort"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" align="left" colspan="2">
                    <table width="248" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn" hidefocus="true" runat="server">保存</a>
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
        
        var RouteThemeAdd = {
            GoAjax: function(url) {
                $("#<%=btn.ClientID %>").html("提交中...");
                $("#<%=btn.ClientID %>").unbind("click");
                $("#<%=btn.ClientID %>").css({ "color": "#999999" });
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#<%=btn.ClientID %>").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                        }
                        else {
                            parent.tableToolbar._showMsg(ret.msg, function() { RouteThemeAdd.BindBtn() });
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(parent.tableToolbar.errorMsg, function() { RouteThemeAdd.BindBtn() });
                    }
                });
            },
            BindBtn: function() {
                //绑定Add事件
                $("#<%=btn.ClientID %>").click(function() {
                    if ($("#<%=txtAreaName.ClientID %>").val() == "") {
                        $("#tip").show();
                        return false;
                    }
                    var data = {
                        save: "1",
                        action: '<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>',
                        tid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("tid") %>'
                    };
                    var ajaxUrl = "/WebMaster/TravelClassEdit.aspx?" + $.param(data);
                    RouteThemeAdd.GoAjax(ajaxUrl);
                    return false;
                })
                $("#<%=txtAreaName.ClientID %>").focus(function() {
                    $("#tip").hide();
                })
                $("#<%=btn.ClientID %>").html("保存").css({ "color": "" });
            }

        }

        $(function() {
            RouteThemeAdd.BindBtn();
        })
   
    </script>

</body>
</html>
