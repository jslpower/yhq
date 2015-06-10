<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderEdit.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.OrderEdit" %>

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
                        线路名称：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
                        <input id="InOrderId" runat="server" type="hidden" />
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
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="lbType" runat="server"></asp:Label>
                    </td>
                    <th height="30" align="right">
                        订单金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="lblOrderPrice" runat="server"  CssClass="searchinput formsize100"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        优惠码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                    </td>
                    <th height="30" align="right">
                        确认码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="lblConfirmCode" runat="server" Text=""></asp:Label>
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
                    <th height="30" align="right">
                        合同类型：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:Label ID="lbContact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        游客信息：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tbl_Customer_AutoAdd">
                            <tbody>
                                <tr class="odd">
                                    <th>
                                        姓名
                                    </th>
                                    <th>
                                        性别
                                    </th>
                                    <th>
                                        联系电话
                                    </th>
                                </tr>
                                <tr bgcolor="#E3F1FC">
                                    <td align="center">
                                        <asp:Label ID="lblPname" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblPsex" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblPtel" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td align="center">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        出团通知单：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <uc1:UploadControl ID="UploadControl1" runat="server" FileTypes="*.pdf" IsUploadSelf="true" />
                        <asp:Label ID="lblpdfile" runat="server" Text=""></asp:Label>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                            <input id="savePdf" type="button" onclick="return pageOpt.SavePdf(1);" value="通知单保存" />
                        </asp:PlaceHolder>
                    </td>
                </tr>
                <asp:PlaceHolder ID="DDZF" runat="server" Visible="false">
                    <tr class="odd">
                        <th height="30" align="right">
                            支付状态：
                        </th>
                        <td bgcolor="#E3F1FC" colspan="3">
                            <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="Table2">
                                <tbody>
                                    <tr class="odd">
                                        <th colspan="2">
                                            <asp:Label ID="lblPaystate" runat="server" Text=""></asp:Label>
                                        </th>
                                        <td align="center" width="150px">
                                            <input id="savaPaystate" type="button" onclick="return false;" value="确认已支付" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="FYZF" runat="server" Visible="false">
                    <tr class="odd">
                        <th height="30" align="right">
                            返佣金额：
                        </th>
                        <td bgcolor="#E3F1FC"  colspan="3">
                            <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="Table3">
                                <tbody>
                                    <tr class="odd">
                                        <th colspan="2">
                                            <asp:TextBox ID="txt_ReMoney" runat="server" CssClass="searchinput formsize100"></asp:TextBox>
                                           应支付返佣金额： <asp:Label ID="lblFYJE"
                                                runat="server" Text=""></asp:Label>
                                        </th>
                                        <td align="center" width="150px">
                                            <input id="saveRecordMoney" type="button" onclick="return false"
                                                value="确认支付返佣" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr class="odd">
                    <th height="30" align="right">
                        特殊要求说明：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <textarea name="txtSpecialMark" class=" formsize450 " rows="3" id="txtSpecialMark"
                            type="text" runat="server"></textarea>
                    </td>
                </tr>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                    <tr class="odd">
                        <th height="30" align="right">
                            寄送信息：
                        </th>
                        <td bgcolor="#E3F1FC" colspan="3">
                            <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="Table1">
                                <tbody>
                                    <tr class="odd">
                                        <th width="100px">
                                            收货人姓名
                                        </th>
                                        <td colspan="2">
                                            <asp:Label ID="lbladdressName" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="odd">
                                        <th>
                                            收货地址
                                        </th>
                                        <td colspan="2">
                                            <asp:Label ID="lbladdressinfo" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="odd">
                                        <th>
                                            邮政编码：
                                        </th>
                                        <td colspan="2">
                                            <asp:Label ID="lbladdressZPcode" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="odd">
                                        <th>
                                            手机号码
                                        </th>
                                        <td colspan="2">
                                            <asp:Label ID="lbladdressmob" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="odd">
                                        <th>
                                            固定电话：
                                        </th>
                                        <td colspan="2">
                                            <asp:Label ID="lbladdresstel" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </asp:PlaceHolder>
            </tbody>
        </table>
    </div>
    <asp:PlaceHolder runat="server" ID="phCaoZuo">
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
                                        <asp:PlaceHolder ID="place_a" runat="server"><a href="javascript:;" onclick="return pageOpt.Save();"
                                            id="btnSave"><s class="baochun"></s>保 存</a></asp:PlaceHolder>
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
    </asp:PlaceHolder>
    </form>

    <script type="text/javascript">
        var pageOpt = {
            Params: {
                orderid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("orderid") %>'
            },
            //删除附件
            RemoveFile: function(obj) {
                $(obj).parent().remove();
            },
            UnBindBtn: function() {
                $("#btnSave").unbind("click").addClass("alertbox-btn_a_active").html("<s class=\"baochun\"></s> 提交中...");
            },
            //按钮绑定事件
            BindBtn: function(obj) {
                if (obj == "1") {
                    $("#savePdf").attr("class", "").val("通知单保存");
                    $("#savePdf").click(function() {
                        pageOpt.SavePdf();
                        return false;
                    });
                }
                else {
                    $("#btnSave").attr("class", "").html("<s class=\"baochun\"></s>保 存");
                    $("#btnSave").click(function() {
                        pageOpt.Save();
                        return false;
                    });
                }

            },
            FormCheck: function() {

                this.Form = $("#btnSave").closest("form").get(0)
                FV_onBlur.initValid(this.Form);
                return ValiDatorForm.validator(this.Form, "parent");

            },
            savePayed: function() {

                $("#savaPaystate").unbind("click").val("正在保存...");
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/OrderEdit.aspx?saveType=1&" + $.param(pageOpt.Params),
                    data: $("#savePdf").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { location.reload(true); });
                        } else {
                            parent.tableToolbar._showMsg(ret.msg);
                        }
                        $("#savaPaystate").attr("class", "").html("<s class=\"baochun\"></s>确认支付返佣");
                        $("#savaPaystate").click(function() {
                            pageOpt.savePayed();
                            return false;
                        });
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(ret.msg);
                        $("#savaPaystate").attr("class", "").html("<s class=\"baochun\"></s>确认支付返佣");
                        $("#savaPaystate").click(function() {
                            pageOpt.savePayed();
                            return false;
                        });
                    }
                });


            },

            saveRecMoney: function() {

                $("#saveRecordMoney").unbind("click").val("正在保存...");
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/OrderEdit.aspx?saveType=2&" + $.param(pageOpt.Params),
                    data: $("#savePdf").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { location.reload(true); });
                        } else {
                            parent.tableToolbar._showMsg(ret.msg);
                        }
                        $("#saveRecordMoney").attr("class", "").html("<s class=\"baochun\"></s>");
                        $("#saveRecordMoney").click(function() {
                            pageOpt.saveRecMoney();
                            return false;
                        });
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(ret.msg);
                        $("#saveRecordMoney").attr("class", "").html("<s class=\"baochun\"></s>确认已支付");
                        $("#saveRecordMoney").click(function() {
                            pageOpt.savePayed();
                            return false;
                        });
                    }
                });


            },

            SavePdf: function(obj) {
                $("#savePdf").unbind("click").val("正在保存...");
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/OrderEdit.aspx?save=savepdf&" + $.param(pageOpt.Params),
                    data: $("#savePdf").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            parent.tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        } else {
                            parent.tableToolbar._showMsg(ret.msg);
                        }
                        pageOpt.BindBtn(obj);
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(ret.msg);
                        pageOpt.BindBtn(obj);
                    }
                });
            },
            Save: function() {
                if (this.FormCheck()) {
                    pageOpt.UnBindBtn();
                    var AddressId = $("#ddl_orderState").val();

                    if (AddressId == '<%=(int)Eyousoft_yhq.Model.OrderState.待付款 %>') {
                        if (!confirm("订单状态为：待付款，确认之后用户将可以进行支付")) {
                            $("#btnSave").attr("class", "").html("<s class=\"baochun\"></s>保 存");
                            return false;
                        }
                    }
                    else if (AddressId == '<%=(int)Eyousoft_yhq.Model.OrderState.已取消 %>') {
                        if (!confirm("订单状态为：已取消，确认之后订单取消掉用户将不可以进行支付")) {
                            $("#btnSave").attr("class", "").html("<s class=\"baochun\"></s>保 存");
                            return false;
                        }
                    }
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/webMaster/OrderEdit.aspx?save=save&" + $.param(pageOpt.Params),
                        data: $("#btnSave").closest("form").serialize(),
                        dataType: "json",
                        success: function(ret) {
                            //ajax回发提示
                            if (ret.result == "1") {
                                parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/webMaster/OrderList.aspx"; });
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
            $("#savaPaystate").click(function() {
                tableToolbar.ShowConfirmMsg("确定要把此订单设置为已支付?", function() { pageOpt.savePayed() });
            });
            $("#saveRecordMoney").click(function() {
            tableToolbar.ShowConfirmMsg("确定要支付返佣金额为" + $("#<%=txt_ReMoney.ClientID %>").val() + "?", function() { pageOpt.saveRecMoney() });
            });
        })
    </script>

</body>
</html>
