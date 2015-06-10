<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterCZ.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.MasterCZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="/js/jquery.js"></script>

    <script language="javascript" src="/js/jquery.boxy.js"></script>

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

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
                        输入帐号：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="ContactName" id="ContactName" class="formsize140" type="text" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        重新输入：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="SureContactName" id="SureContactName" class="formsize140" type="text" />
                        <span class="errmsg">*</span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        输入转帐金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="money" id="money" class="formsize140" id="Text1" type="text" />
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
                                        </s>充值</a>
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
                if($("#ContactName").val()!=$("#SureContactName").val())
                {
                parent.tableToolbar._showMsg("两次帐户输入不一致！");
                 return false;
                }
                 var account = $("#ContactName").val();
                  var accountMoney = tableToolbar.getFloat($("#money").val());
                   if (!/^(13|15|18|14)\d{9}$/.test(account)) {
                    tableToolbar._showMsg('请核对账户格式！', function() { return false; });
                }
                if (!/^\d+(\.\d+)?$/.test(accountMoney)) {
                    tableToolbar._showMsg('请核对转账金额！', function() { return false; });
                }
                if (this.FormCheck()) {
               
                 $.ajax({
                    url: '/WebMaster/MasterCZ.aspx?chk=1&a=' + account+'&m=' + accountMoney,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {

                            tableToolbar.ShowConfirmMsg("确认转入名称为[" + ret.obj + "]的账户[" + accountMoney + "]元?", function() {
                                $.ajax({
                                    url: '/WebMaster/MasterCZ.aspx?zz=1',
                                    dataType: "json",
                                    data: { a: account, m: accountMoney },
                                    success: function(ret) {
                                        if (ret.result == "1") {
                                            tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = parent.window.location.href });
                                        }
                                        else {
                                            tableToolbar._showMsg(ret.msg, function() { return false; });
                                        }
                                    },
                                    error: function() {
                                        tableToolbar._showMsg(tableToolbar.errorMsg);
                                    }
                                })
                            });

                        } else {
                            tableToolbar._showMsg(ret.msg);
                        }

                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })
                }
            }
        };
    </script>

</body>
</html>
