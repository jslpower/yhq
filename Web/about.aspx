<%@ Page Title="关于我们" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Eyousoft_yhq.Web.about1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <style type="text/css">
        .gonggaoBox
        {
            width: 850PX;
        }
        .gonggaoBox .gg_xxT
        {
            border-bottom: 0px dashed #CCCCCC;</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!------lanmu_T-------->
    <div class="lanmu_T">
        您所在位置：首页 &gt; <span class="font_f60">关于我们</span></div>
    <!------productBox-------->
    <div class="productBox">
        <!------Msidebar-------->
        <div class="Msidebar">
            <!------gonggaoBox-------->
            <div class="gonggaoBox">
                <div class="gg_xxT">
                    <asp:Label ID="lbl_ABOUT" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
