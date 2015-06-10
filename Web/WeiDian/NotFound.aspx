<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="Eyousoft_yhq.Web.WeiDian.NotFound" MasterPageFile="~/MP/WeiDian.Master" Title="你查看的微店不存在或已关闭" %>

<asp:Content ContentPlaceHolderID="YeMianHead" ID="YeMianHead1" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/weixin/notfound.css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">    
    <div class="page_msg">
        <div class="inner">
            <span class="msg_icon_wrp"><i class="icon80_smile"></i></span>
            <div class="msg_content">
                <h4><%=XiaoXi %></h4>
            </div>
        </div>
    </div>
</asp:Content>
