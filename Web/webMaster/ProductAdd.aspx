<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.ProductAdd" %>

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
                        <input name="txtproductName" class="formsize140" id="txtproductName" type="text"
                            runat="server" valid="required" errmsg="产品名称不能为空" />
                    </td>
                    <th height="30" align="right">
                        是否热门：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:DropDownList ID="ddl_isHot" runat="server">
                            <asp:ListItem Value="0" Text="否"></asp:ListItem>
                            <asp:ListItem Value="1" Text="是"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        出团日期：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="txtsendDate" class="formsize140" id="txtsendDate" type="text" runat="server"
                            onfocus="WdatePicker()" />
                    </td>
                    <th height="30" align="right">
                        是否天天出团：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:CheckBox ID="chk_Isevery" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        分类：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:DropDownList ID="ddltype" runat="server" valid="required" errmsg="请选择分类">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        市场价：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input name="txtmarkPrice" class="formsize140" id="txtmarkPrice" type="text" runat="server"
                            errmsg="请输入市场价!|市场价格式不正确!" valid="required|isMoney" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        APP价：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input name="txtappPrice" class="formsize140" id="txtappPrice" type="text" runat="server"
                            errmsg="请输入优惠价!|优惠价格式不正确!" valid="required|isMoney" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        联系电话：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input name="txttel" class="formsize140" id="txttel" type="text" runat="server" valid="required"
                            errmsg="联系电话不能为空！" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        预控人数：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input name="txtPeopleNum" class="formsize140" id="txtPeopleNum" type="text" runat="server"
                            valid="required|isInt|range" errmsg="请输入人数!|请输入正确的人数!|人数必须大于0!" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        客服QQ：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input name="txttel" class="formsize140" id="txtkfqq" type="text" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        合同类型：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:DropDownList ID="ddl_contact" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        产品介绍：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <textarea name="txtdescript" class=" formsize450 " rows="3" id="txtdescript" type="text"
                            runat="server"></textarea>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        参考行程：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <textarea name="txtjoury" class="formsize450" rows="3" id="txtjoury" type="text"
                            runat="server"></textarea>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        出团需知：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <textarea name="txtsendMark" class="formsize450" rows="3" id="txtsendMark" type="text"
                            runat="server"></textarea>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        同类比较：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <textarea name="txtScompare" class="formsize450" rows="3" id="txtScompare" type="text"
                            runat="server"></textarea>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        产品类型：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:DropDownList ID="ddl_proType" runat="server">
                        </asp:DropDownList>
                    </td>
                    <th height="30" align="right">
                        二维码有效期：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="txtZxingdate" class="formsize140" id="txtZxingdate" type="text" runat="server"
                            valid="required" errmsg="二维码有效期不能为空！" onfocus="WdatePicker()" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        手机产品图片：
                        <br />
                        推荐尺寸(103*98)
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <uc1:UploadControl runat="server" ID="upload1" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                            IsUploadSelf="true" />
                        <asp:Label ID="lblfile" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        网站产品图片：
                        <br />
                        推荐尺寸(455*280)
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <uc1:UploadControl runat="server" ID="upload2" FileTypes="*.jpg;*.gif;*.jpeg;*.png;*.bmp"
                            IsUploadSelf="true" />
                        <asp:Label ID="lblfileWeb" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        有效期：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="txtValidate" class="formsize140" id="txtValidate" type="text" runat="server"
                            valid="required" errmsg="有效期不能为空！" onfocus="WdatePicker()" />
                    </td>
                    <th height="30" align="right">
                        微信码：
                    </th>
                    <td bgcolor="#E3F1FC">
                       H<input name="txtWXcode" class="formsize140" id="txtWXcode" type="text" runat="server"
                            valid="required" errmsg="微信码不能为空！" />
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
        <input type="hidden" id="isEvery" name="isEvery" value="<%=everyDay %>" />
    </div>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            Params: {
                id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                dotype: '<%=EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>'
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
                        url: "/webMaster/ProductAdd.aspx?save=save&" + $.param(pageOpt.Params),
                        data: $("#btnSave").closest("form").serialize(),
                        dataType: "json",
                        success: function(ret) {
                            //ajax回发提示
                            if (ret.result == "1") {
                                parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/webMaster/ProductList.aspx"; });
                            } else {
                                parent.tableToolbar._showMsg(ret.msg);
                            }
                            pageOpt.BindBtn();
                        },
                        error: function() {
                            parent.tableToolbar._showMsg(ret.msg);
                            pageOpt.BindBtn();
                        }
                    });
                }
            }
        };
        $(function() {
            if ($("#isEvery").val() == "1") {
                $("#txtsendDate").css("display", "none");
            }
            $('#<%=chk_Isevery.ClientID %>').click(function() {
                if ($("#isEvery").val() == "1") {
                    $("#txtsendDate").css("display", "block");
                    $("#txtsendDate").attr("valid", "required").attr("errmsg", "出团日期不能为空！");
                    $("#isEvery").val("0")
                }
                else {
                    $("#txtsendDate").css("display", "none");
                    $("#txtsendDate").removeAttr("valid").removeAttr("errmsg");
                    $("#isEvery").val("1")
                }
            });
        });
    </script>

</body>
</html>
