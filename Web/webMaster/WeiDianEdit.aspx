<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiDianEdit.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.WeiDianEdit" MasterPageFile="~/webMaster/NeiYe.Master" %>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <div style="width: 99%; margin: 10px auto;">
        <table class="Tborder" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr class="odd">
                <th height="30" align="right" width="100">
                    会员账号：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrYongHuMing"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    会员姓名：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrHuiYuanName"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    微店名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrMingCheng"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    微店介绍：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrJieShao"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    微店状态：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrStatus"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    申请时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShenQingTime"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    审核时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShenHeTime"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
