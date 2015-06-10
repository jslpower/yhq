<%@ Page Title="返佣记录" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="TGlist.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.TGlist" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <style type="text/css">
        #TGdiv, #TGlink
        {
            border-bottom: none;
            border-top: none;
            background-color: White;
            padding-bottom: 2px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            推广记录</h2>
        <div id="TGdiv" class="h2-addr">
            推荐码:<%=HuiYuanInfo.PromotionCode%>
            亲！推广也能赚钱喔！ <a id="getTGlink" href="javascript:;"><font class="font_f60">[点击获取推广链接]</font>
            </a>
        </div>
        <div id="TGlink" class="h2-addr">
        </div>
        <div class="address_box">
            <div style="width: 100%">
                <table class="tableList" width="100%" cellspacing="1" cellpadding="0" border="0"
                    id="liststyle">
                    <tbody>
                        <tr>
                            <th width="60" height="30" align="center">
                                序号
                            </th>
                            <th align="center">
                                注册人
                            </th>
                            <th align="center">
                                性别
                            </th>
                            <th align="center">
                                注册日期
                            </th>
                        </tr>
                        <asp:Repeater ID="rpt_list" runat="server">
                            <ItemTemplate>
                                <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                                    <td height="30" align="center">
                                        <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("ContactName")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("ContactSex")%>
                                    </td>
                                    <td align="center">
                                        <%# Eval("IssueTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='4'>暂无推广信息!</td></tr>"></asp:Literal>
                    </tbody>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" align="right" class="pageup" colspan="13">
                            <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var pageOpt = {
        pollcode: '<%=Server.UrlEncode(HuiYuanInfo.PromotionCode)%>'
        };
        $(function() {
            $("#getTGlink").click(function() {
                $("#TGlink").html("http://www.4008005216.com/Register.aspx?pollcode=" + pageOpt.pollcode);
            })
        })
    </script>

</asp:Content>
