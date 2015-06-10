<%@ Page Title="个人中心" Language="C#" MasterPageFile="~/masterPage/HuiYuan.Master" AutoEventWireup="true"
    CodeBehind="updateuser.aspx.cs" Inherits="Eyousoft_yhq.Web.updateuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="user_main">
        <div class="user_box">
            <ul>
                <li>手机号码：</li>
                <li>
                    <asp:Label ID="lblmobile" runat="server" Text=""></asp:Label></li>
                <li>姓名：</li>
                <li>
                    <input type="text" class="formsize400 inputbg" name="contactName" id="contactName"
                        runat="server" /></li>
                <li>性别：</li>
                <li>
                    <asp:DropDownList ID="ddl_sex" runat="server">
                        <asp:ListItem Value="1" Text="男"></asp:ListItem>
                        <asp:ListItem Value="0" Text="女"></asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>密码：</li>
                <li>
                    <input type="password" class="formsize400 inputbg" name="userPwd" id="userPwd" runat="server" /></li>
            </ul>
            <div>
                <img width="280" style="vertical-align: top" src="/images/user-boxB.png" alt="" /></div>
        </div>
        <div class="btn">
            <a href="javascript:;" id="btnsave">
                <img width="200px" src="/images/baocun.png"></a></div>
    </div>

    <script type="text/javascript">

        $(function() {
            $("#btnsave").click(function() {
                var msg = "";
                if ($("#<%=contactName.ClientID %>").val() == "") {
                    msg += "姓名不能为空！\n";
                }
                if ($("#<%=userPwd.ClientID %>").val() == "") {
                    msg += "密码不能为空！ \n";
                }
                if (msg != "") {
                    alert(msg);
                    return false;
                }
                else {
                    $("#btnsave").closest("form").get(0).submit();
                }
            })//提交


        })
    </script>

</asp:Content>
