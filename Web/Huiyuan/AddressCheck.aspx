<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressCheck.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.AddressCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地址</title>
    <link href="/css/webCss/style.css" rel="stylesheet" type="text/css" />

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>

    <script language="javascript" src="/js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            收货地址</h2>
        <div class="address_box">
            <div class="addr_table">
                <table cellspacing="0" cellpadding="0" class="addressList">
                    <tr>
                        <th width="30">
                        </th>
                        <th width="60">
                            收货人
                        </th>
                        <th width="160">
                            所在地区
                        </th>
                        <th width="130">
                            街道地址
                        </th>
                        <th width="60">
                            邮编
                        </th>
                        <th width="160">
                            电话/手机
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_address" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# IsCheck(Eval("IsDefault"), Eval("AddressID"))%>
                                </td>
                                <td align="center">
                                    <%# Eval("ContactName")%>
                                </td>
                                <td>
                                    <%# Eval("AddressProvinceName")%>
                                    <%# Eval("AddressCityName")%>
                                    <%# Eval("AddressCountryName")%>
                                </td>
                                <td>
                                    <%# Eval("AddressInfo")%>
                                </td>
                                <td align="center">
                                    <%# Eval("ZpCode")%>
                                </td>
                                <td align="center">
                                    <%# Eval("MobileNum")%>/
                                    <%# Eval("TelNum")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="NoMsg" runat="server"></asp:Literal>
                </table>
                <br />
                <div style="text-align: center">
                    <input class="baocunbtn" type="button" id="Adresstj" value="确定" />
                    <input class="baocunbtn" type="button" id="HTYL" value="合同预览" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var PageInit = {
            GetAjaxAdress: function(Send) {
                $.ajax({
                    type: "GET",
                    url: "/Huiyuan/AddressCheck.aspx?dotype=save&" + $.param(Send),
                    cache: false,
                    success: function(res) {
                        if (res.result == "1") {
                            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide();
                            return false;
                        }
                        else {
                            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide();
                            return false;
                        }
                    }
                });
             }
        };

        $(function() {
            $("#HTYL").click(function() {
                var Type = decodeURI('<%=EyouSoft.Common.Utils.GetQueryStringValue("ContractType")%>');
                var orderId = '<%=EyouSoft.Common.Utils.GetQueryStringValue("Id")%>';
                if (Type != "" && orderId != "") {
                    if (Type == '<%=Eyousoft_yhq.Model.ContractType.国外合同 %>') {
                        window.open("/printPage/AbroadContract.aspx?Id=" + orderId);
                    }
                    else if (Type == '<%=Eyousoft_yhq.Model.ContractType.国内合同 %>') {
                        window.open("/printPage/ChyardContract.aspx?Id=" + orderId);
                    }

                }
                else {
                    tableToolbar._showMsg("重新选择订单合同", function() { parent.window.location.href = "/Huiyuan/OrderList.aspx"; });
                }

            });
            /*------------------------------------------------------*/

            $("#Adresstj").click(function() {
                var Type = '<%=EyouSoft.Common.Utils.GetQueryStringValue("ContractType")%>';
                var AddressId = $('input[name="Adressradio"]:checked').val();
                var orderId = '<%=EyouSoft.Common.Utils.GetQueryStringValue("Id")%>';
                if (Type != "" && orderId != "") {
                    if (AddressId != null) {
                        if (Type == '<%=Eyousoft_yhq.Model.ContractType.国外合同 %>') {
                            var send = { OrderId: orderId, AdId: AddressId };
                            PageInit.GetAjaxAdress(send);
                            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"]%>').hide();

                        }
                        else if (Type == '<%=Eyousoft_yhq.Model.ContractType.国内合同 %>') {
                            var send = { OrderId: orderId, AdId: AddressId };
                            PageInit.GetAjaxAdress(send);

                        }
                    }
                    else {
                        tableToolbar._showMsg("请选择合同寄送地址");
                    }
                }
                else {
                    tableToolbar._showMsg("重新选择订单合同", function() { parent.window.location.href = "/Huiyuan/OrderList.aspx"; });
                }

            });
        });
    </script>

    </form>
</body>
</html>
