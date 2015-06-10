<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelArticleEdit.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TravelArticleEdit" ValidateRequest="false" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>旅游咨询</title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/JS/swfupload/swfupload.js" type="text/javascript"></script>

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

    <script src="/JS/jquery.bigcolorpicker.js" type="text/javascript"></script>

    <style type="text/css">
        .bigpicker
        {
            width: 227px;
            height: 163px;
            position: absolute;
            z-index: 9999;
            background-color: #F0F0F0;
            padding: 2px 0 1px 5px;
            border-left: solid 1px #CCCCCC;
            border-top: solid 1px #CCCCCC;
            border-right: solid 1px #565656;
            border-bottom: solid 1px #565656;
            display: none;
        }
        .bigpicker .nocolor
        {
            display: block;
            width: 17px;
            height: 17px;
            margin: 2px 0 0;
            background: url(/images/nocolor.png) no-repeat;
            cursor: pointer;
        }
        .bigpicker-sections-color
        {
            margin: 0;
            padding: 0;
        }
        .bigpicker-sections-color ul
        {
            margin: 0;
            padding: 0;
            float: left;
        }
        .bigpicker-sections-color ul li
        {
            list-style: none outside none;
            margin: 0;
            padding: 0;
            border-top: solid 1px #000000;
            border-left: solid 1px #000000;
            width: 10px;
            height: 10px;
            overflow: hidden;
            line-height: 0px;
            font-size: 0px;
        }
        .bigpicker .biglayout
        {
            width: 10px;
            height: 10px;
            border: solid 1px #FFFFFF;
            position: absolute;
            z-index: 10000;
            display: none;
            line-height: 10px;
            overflow: hidden;
            cursor: default;
        }
        .bigpicker-bgview-text
        {
            margin: 0;
            padding: 0;
            height: 24px;
        }
        .bigpicker-bgview-text li
        {
            padding: 0 5px 0 0;
            list-style: none outside none;
            float: left;
            line-height: 18px;
        }
        .bigpicker-bgview-text li div
        {
            margin: 0;
            padding: 0;
            height: 20px;
            width: 55px;
            background-color: #000000;
            border-left: solid 1px #CCCCCC;
            border-top: solid 1px #CCCCCC;
            border-right: solid 1px #2B2B2B;
            border-bottom: solid 1px #2B2B2B;
        }
        .bigpicker-bgview-text li input
        {
            margin: 0;
            padding: 0;
            height: 17px;
            width: 55px;
        }
        .bigpicker-bgimage
        {
            background-image: url(../images/big_bgcolor.jpg);
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="970" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;">
        <tr class="odd">
            <th width="95" height="30" align="center">
                <span style="color: red">*</span>标题：
            </th>
            <td width="330" align="left">
                <asp:TextBox ID="txtArticleTitle" runat="server" Width="200px" CssClass="inputtext"
                    valid="required" errmsg="标题不能为空"></asp:TextBox>
                <%--       <input id="bn" type="button" value="选色" />
                <input type="hidden" id="hdTitleColor" runat="server" />--%>
            </td>
            <th width="80" align="center">
                <span style="color: red">*</span>类别：
            </th>
            <td width="330" align="left">
                <asp:DropDownList ID="ddlClassId" runat="server" CssClass="inputselect" valid="required"
                    errmsg="请选择类别">
                </asp:DropDownList>
            </td>
        </tr>
        <%--        <tr class="even">
            <th>
                关键字：
            </th>
            <td align="left">
                <asp:TextBox ID="txtKeyWords" runat="server" Width="200px" CssClass="inputtext"></asp:TextBox>
            </td>
            <th width="95" height="30" align="center">
                标签：
            </th>
            <td align="left">
                <asp:TextBox ID="txtArticleTag" runat="server" CssClass="inputtext formsize260"></asp:TextBox>
            </td>
        </tr>--%>
        <tr class="odd">
            <th width="95" height="30" align="center">
                附件：
            </th>
            <td align="left" colspan="3">
                <uc1:UploadControl runat="server" ID="upload1" IsUploadSelf="true" />
            </td>
        </tr>
        <%--<tr class="even">
            <th width="95" height="30" align="center">
                描述：
            </th>
            <td colspan="3">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Columns="45"
                    Rows="5" CssClass="inputarea formsize600"></asp:TextBox>
            </td>
        </tr>--%>
        <tr class="odd">
            <th align="center">
                内容：
            </th>
            <td colspan="3">
                <asp:TextBox ID="txtArticleText" runat="server" TextMode="MultiLine" Columns="45"
                    Rows="5" CssClass="inputarea formsize600"></asp:TextBox>
            </td>
        </tr>
        <%--        <tr class="even">
            <th width="95" height="30" align="center">
                来源：
            </th>
            <td align="left" colspan="3">
                <asp:TextBox runat="server" ID="txtASource" CssClass="inputtext formsize260"></asp:TextBox>
            </td>
        </tr>
        <tr class="odd">
            <th height="30" align="center">
                链接地址：
            </th>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtLinkUrl" CssClass="inputtext formsize260" valid="isUrl"
                    errmsg="URL地址不正确"></asp:TextBox>
            </td>
        </tr>
        <tr class="even">
            <th align="center">
                是否首页显示：
            </th>
            <td colspan="3" align="left">
                <asp:DropDownList ID="ddlIsFrontPage" runat="server" CssClass="inputselect">
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="odd">
            <th height="30" align="center">
                是否头条：
            </th>
            <td colspan="3" align="left">
                <asp:DropDownList ID="ddlIsHot" runat="server" CssClass="inputselect">
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="even">
            <th height="30" align="center">
                排序规则：
            </th>
            <td colspan="3">
                <asp:DropDownList runat="server" ID="ddlSort" CssClass="inputselect">
                    <asp:ListItem Text="-请选择-" Value="0"></asp:ListItem>
                    <asp:ListItem Text="低" Value="1"></asp:ListItem>
                    <asp:ListItem Text="常规" Value="2" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="高" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
        <asp:PlaceHolder runat="server" ID="phClicks" Visible="false">
            <tr class="odd">
                <th align="center">
                    点击量：
                </th>
                <td colspan="3">
                    <asp:Literal runat="server" ID="ltClicks"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
    </table>
    <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
            </td>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" class="save" id="btn" runat="server">保存</a>
            </td>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">
                    关闭</a>
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">

        var TravelArticle = {
            PageInit: function() {
                //初始化编辑器
                KEditer.init("<%=this.txtArticleText.ClientID%>", {
                    resizeMode: 0,
                    items: keSimple,
                    height: "200px",
                    width: "680px"
                });




                $("#<%=btn.ClientID %>").click(function() {
                    if (!TravelArticle.CheckForm()) {
                        return false;
                    }
                    //编辑器
                    KEditer.sync();


                    var url = "/WebMaster/TravelArticleEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    TravelArticle.GoAjax(url);


                });
            },
            GoAjax: function(url) {
                TravelArticle.UnBind();
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
                            parent.tableToolbar._showMsg(ret.msg);
                            TravelArticle.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        TravelArticle.Bind();
                    }
                });
            },
            CheckForm: function() {
                return ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "parent");
            },
            Bind: function() {
                var _selfs = $("#<%=this.btn.ClientID %>");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (!TravelArticle.CheckForm()) {
                        return false;
                    }
                    var url = "/WebMaster/TravelArticleEdit.aspx?dotype=" + '<%=Request.QueryString["dotype"]%>' + "&type=save&tid=" + '<%=Request.QueryString["tid"]%>';
                    TravelArticle.GoAjax(url);
                    return false;
                });
            },
            UnBind: function() {
                $("#<%=this.btn.ClientID %>").html("提交中...");
                $("#<%=this.btn.ClientID %>").unbind("click");
            }
        };

        $(function() {


            $("#bn").bigColorpicker(function(el, color) {
                $("#<%=txtArticleTitle.ClientID %>").css("color", color);
            });


            TravelArticle.PageInit();
        });
    
    </script>

</body>
</html>
