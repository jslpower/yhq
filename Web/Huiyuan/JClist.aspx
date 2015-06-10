<%@ Page Title="培训课程" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="JClist.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.JClist" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            培训课程</h2>
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
                                标题
                            </th>
                            <th align="center">
                                发布时间
                            </th>
                        </tr>
                        <asp:Repeater ID="rpt_Notices" runat="server">
                            <ItemTemplate>
                                <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                                    <td height="30" align="center">
                                        <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                                    </td>
                                    <td align="center">
                                        <a target="_blank" href="/NoticeInfo.aspx?NotIceId=<%# Eval("ArticleID")%>">
                                            <%#Eval("ArticleTitle")%></a>
                                    </td>
                                    <td align="center">
                                        <%# Eval("IssueTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="litMsg" runat="server" Text="<tr><td align='center' colspan='3'>暂无相关信息!</td></tr>"
                            Visible="false"></asp:Literal>
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
</asp:Content>
