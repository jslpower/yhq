<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberAdd.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.MemberAdd" %>

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
                        用户名：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="userName" class="formsize140" id="userName" type="text" runat="server"
                            readonly="readonly" />
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
                        性别：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:DropDownList ID="ddl_sex" runat="server">
                            <asp:ListItem Value="0" Text="女"></asp:ListItem>
                            <asp:ListItem Value="1" Text="男"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        密码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="userPwd" class="formsize140" id="userPwd" type="password" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        确认密码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="reuserPwd" class="formsize140" id="reuserPwd" type="password" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        服务项目：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select id="MemberOption" name="MemberOption" style=" width:150px;">
                             <%=BindOption(Option.ToString())%>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        服务区域：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select id="MyProvice" name="MyProvice">
                             <%=BindProvice(ProviceId.ToString())%>
                        </select>
                        <select id="MyCity" name="MyCity">
                             <%=BindCity(CityId.ToString(), ProviceId.ToString())%>
                        </select>
                        <select id="MyArea" name="MyArea">
                             <%=BindArea(AreaId.ToString(), CityId.ToString())%>
                        </select>
                        <select id="MyStreet" name="MyStreet">
                             <%=BindStreet(StreetId.ToString(), AreaId.ToString())%>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        推广码：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="userPromotionCode" class="formsize140" id="userPromotionCode" type="text"
                            runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        返佣比例：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="fydecimal" class="formsize140" id="fydecimal" type="text" runat="server"
                            errmsg="必须是数字!" valid="isNumber" />%
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        备注：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input name="remark" class=" formsize450" id="remark" type="text" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        账户余额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input  name="zhYuE" class="formsize140" id="zhYuE" type="text"
                            runat="server" errmsg="必须是数字!" valid="isNumber" /><input type="checkbox" value="1"
                                name="chk_zf" id="chk_zf" runat="server" />
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
    $(function() {
            pageOpt.SelectInit();
        });    
        var pageOpt = {
        SelectInit: function(){
        $("#MyProvice").change(function(){
           $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/MemberAdd.aspx?posttype=city&selectvalue=0&proid="+$("#MyProvice").val(),
                    dataType: "text",
                    success: function(ret) {
                         $("#MyCity").html(ret);
                    }
                });
        });
        $("#MyCity").change(function(){
           $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/MemberAdd.aspx?posttype=area&selectvalue=0&cityid="+$("#MyCity").val(),
                    dataType: "text",
                    success: function(ret) {
                         $("#MyArea").html(ret);
                    }
                });
        });
        $("#MyArea").change(function(){
           $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/MemberAdd.aspx?posttype=street&selectvalue=0&areaid="+$("#MyArea").val(),
                    dataType: "text",
                    success: function(ret) {
                         $("#MyStreet").html(ret);
                    }
                });
        });
        },
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
                if($("#userPwd").val()!=$("#reuserPwd").val())
                {
                parent.tableToolbar._showMsg("两次密码输入不一致！");
                 return false;
                }
                if (this.FormCheck()) {
                pageOpt.UnBindBtn();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/webMaster/MemberAdd.aspx?save=save&" + $.param(pageOpt.Params),
                    data: $("#btnSave").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                        parent.tableToolbar._showMsg(ret.msg, function() { parent.window.location.href = "/webMaster/MemberList.aspx"; });
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
