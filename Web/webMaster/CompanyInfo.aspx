<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.CompanyInfo"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司信息</title>
    <link href="/Css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Js/kindeditor-4.1/kindeditor-min.js"></script>

    <style type="text/css">
        .inputtext
        {
            outline: none;
            border: solid 1px #93B7CE;
            font-size: 12px;
            padding: 1px 2px;
            height: 80px;
            transition: all 0.5s;
            -o-transition: all 0.5s;
            -moz-transition: all 0.5s;
            -ms-transition: all 0.5s;
            -webkit-transition: all 0.5s;
            border-radius: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="98%" border="1" align="center" cellpadding="3" cellspacing="0" bordercolor="#CCCCCC"
        id="tableInfo">
        <tr class="lr_hangbg">
            <td align="right">
                关于我们：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtAboutUs" class="editText"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                title：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtTitle" class="inputtext formsize800"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                keywords：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtKeys" class="inputtext formsize800"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                description：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:TextBox runat="server" ID="txtDescript" class="inputtext formsize800"></asp:TextBox>
            </td>
        </tr>
        <tr class="lr_hangbg">
            <td align="right">
                短信剩余条数：
            </td>
            <td align="left" bgcolor="#FFFFFF">
                <asp:Label ID="lbl_MsgCount" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="35" colspan="2" align="center" bgcolor="#FFFFFF">
                <table cellspacing="0" cellpadding="0" border="0" align="center">
                    <tbody>
                        <tr>
                            <td height="20" align="center" class="tjbtn02">
                                <asp:LinkButton runat="server" ID="btnSave" OnClick="btnSave_Click">保存</asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">
        var CompanyInfo = {
            InitEdit: function() {
                $("#tableInfo").find(".editText").each(function() {
                    KEditer.init($(this).attr("id"), {
                        resizeMode: 0,
                        items: keSimple,
                        height: $(this).attr("data-height") == undefined ? "160px" : $(this).attr("data-height"),
                        width: $(this).attr("data-width") == undefined ? "680px" : $(this).attr("data-width")
                    });
                });
            },
            CheckForm: function() {
                KEditer.sync();

                return true;
            }
        };

        $(document).ready(function() {

            CompanyInfo.InitEdit();

            $("#<%= btnSave.ClientID %>").click(function() {
                return CompanyInfo.CheckForm();
            });
        });
    </script>

</body>
</html>
