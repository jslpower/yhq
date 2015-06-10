<%@ Page Title="账户管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="zhuanpay.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.zhuanpay" %>

<%@ Register Src="/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery.boxy.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <form runat="server" id="form1">
    
     
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            账户转帐</h2>
        <div class="address_box">
            <ul style="border-bottom: none 0;" class="addr_form">
                <li>
                    <p style="margin-left: 10em;">
                        余额：
                        <asp:Literal ID="Literal1" runat="server" Text="0"></asp:Literal>
                    </p>
                </li>
                <li>
                    <p style="margin-left: 10em;">
                        请输入对方转帐户名：
                        <input type="text" id="userTo" name="userTo" />
                        <input type="text" id="money" name="money" />
                    </p>
                </li>
                <li>
                    <p style="margin-left: 10em;">
                        <input type="button" id="pay" class="baocunbtn" value="转帐" /></p>
                </li>
            </ul>
        </div>
    </div>
    <input type="hidden" id="yue" />
       </form>
 

    <script type="text/javascript">

        $(function() {

            $("#save").click(function() {
                if (!ValiDatorForm.validator($("#save").closest("form").get(0), "alert"))
                { return false; }
                $.ajax({
                    type: "post",
                    cache: false,
                    url: '/Huiyuan/Account.aspx?chongzhi=1',
                    dataType: "json",
                    data: $("#save").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            Boxy.iframeDialog({ iframeUrl: '/Huiyuan/QueRenCz.aspx?id=' + ret.obj, title: '确认充值金额', modal: true, width: 300, height: 130 });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })
            })
             $("#pay").click(function() {
              var userTo= $("#userTo").val();
                            var yue= $("#yue").val();
                                          var moneys= $("#money").val();


                $.ajax({
                    type: "post",
                    cache: false,
                    url: '/Huiyuan/Account.aspx?zhuanz=1',
                    dataType: "json",
                    data: $("#pay").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                          tableToolbar._showMsg(ret.msg);
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                })
            })
        })
    </script>

</asp:Content>
