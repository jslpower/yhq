<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CouponsList.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.CouponsList" %>

<%@ Register Assembly="ControlLibrary" Namespace="ControlLibrary" TagPrefix="cc2" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
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

    <!--tianjia----delete--- star-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>

    <!--tianjia----delete---star-->
</head>
<body>
    <form action="/webMaster/CouponsList.aspx" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                        优惠码：
                        <input type="text" size="20" id="productName" class="searchinput formsize100" name="productName"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("productName") %>" />
                         <input type="submit" value="查询" />
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif">
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <div class="tablelist">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="Tborder">
            <tbody>
                <tr>
                    <th width="62" align="center" height="30">
                        <input type="hidden" id="hidmark" value="0" />
                        <input type="checkbox" id="chkall" name="checkbox3">
                        全选
                    </th>
                    <th width="200" align="center">
                        产品名称
                    </th>
                    <th width="100" align="center">
                        价格
                    </th>
                    <th align="center">
                        产品信息
                    </th>
                    <th width="100" align="center">
                        优惠价格
                    </th>
                    <th align="center">
                        优惠有效期
                    </th>
                </tr>
                <asp:Repeater ID="rpt_list" runat="server">
                    <ItemTemplate>
                        <tr bgcolor=<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %> >
                            <td align="center" height="30">
                                <input type="checkbox" name="chk_IDS" value="<%#Eval("ProductID")%>">
                                <%# Container.ItemIndex+1 %>
                            </td>
                            <td align="center">
                                <%#Eval("ProductName")%>
                            </td>
                            <td align="center">
                                <%# EyouSoft.Common.UtilsCommons.GetMoneyString( Eval("MarketPrice"), "zh-cn")%>
                            </td>
                            <td align="center">
                                <%# Eval("ProductDis")%>
                            </td>
                            <td align="center">
                                <%# EyouSoft.Common.UtilsCommons.GetMoneyString( Eval("AppPrice").ToString(),"zh-cn")%>
                            </td>
                            <td align="center">
                                <%#Eval("ValidiDate", "{0:d}")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='6'>暂无相关信息!</td></tr>"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right" height="40">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tbody>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        $(function() {
            $("#chkall").click(function() {
                var mark = $("#hidmark").val();
                if (mark == 0) { $("[name=chk_IDS]").attr("checked", true); $("#hidmark").val("1"); }
                if (mark == 1) { $("[name=chk_IDS]").attr("checked", false); $("#hidmark").val("0"); }
            })
        })
    </script>

</body>
</html>
