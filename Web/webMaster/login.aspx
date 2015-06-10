<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理登陆</title>
    <link href="/Css/manager.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="480" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 80px;">
            <tr>
                <td width="13" height="261" style="background: url(/images/login_l.gif) no-repeat;">
                </td>
                <td width="452" valign="top" background="/images/login_m.gif">
                    <table width="98%" height="148" border="0" align="center" cellpadding="0" cellspacing="0"
                        style="margin-top: 20px;">
                        <tr>
                            <td height="41" colspan="2" align="left" valign="top" class="dhc">
                                <strong>管理登录口</strong>
                            </td>
                        </tr>
                        <tr>
                            <td width="28%" height="33" align="right">
                                用户名：
                            </td>
                            <td width="72%" align="left">
                                <input type="text" name="t_u" id="t_u" style="border: 1px solid #659BC1; height: 17px;
                                    padding: 3px 0 0 3px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="32" align="right">
                                密&nbsp; 码：
                            </td>
                            <td align="left">
                                <input type="password" name="t_p" id="t_p" style="border: 1px solid #659BC1; height: 17px;
                                    padding: 3px 0 0 3px;" />
                            </td>
                        </tr>
                        <tr>
                            <td height="42">
                                &nbsp;<input type="hidden" name="vc" id="vc" />
                            </td>
                            <td align="left">
                                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text=" 登  录 " Style="cursor: pointer;
                                    background: url(/images/sub.gif); border: none; width: 75px; height: 22px; color: #093370;" />
                                <input type="submit" style="background: url(/images/sub.gif); border: none; width: 75px;
                                    height: 22px; color: #093370;" value="取  消" name="Submit2">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="14" style="background: url(/images/login_r.gif) no-repeat;">
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">

        function WebForm_OnSubmit_Validate() {
            if ($.trim($("#t_u").val()) == "") {
                alert('Please enter your login information.');
                $("#t_u").focus();
                return false;
            }
            if ($.trim($("#t_p").val()) == "") {
                alert('Please enter a password.');
                $("#t_p").focus();
                return false;
            }
            return true;
        }

        $(document).ready(function() {
            $("#t_u").focus();
            $("#<%=btnLogin.ClientID %>").bind("click", function() { return WebForm_OnSubmit_Validate(); });
        });
    </script>

</body>
</html>
