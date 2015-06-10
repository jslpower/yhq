<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/HuiYuan.Master" AutoEventWireup="true"
    CodeBehind="CodeError.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.ZxingCode.CodeError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>网络错误</title>

    <script type="text/javascript" src="/js/cordova.js"></script>

    <script type="text/javascript" src="/js/cordova_plugins.js"></script>

    <script type="text/javascript" src="/js/jquery-1.10.2.js"></script>

    <script type="text/javascript" src="/js/eyou.core.js"></script>

    <style type="text/css">
        body
        {
            font-size: 12px;
            line-height: 24px;
        }
        ul
        {
            margin: 0px;
        }
        .fs14
        {
            font-size: 14px;
        }
        .fwb
        {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fs14 fwb">
        哎呀，出错了！</div>
    <div class="fs14 fwb">
        可能原因：</div>
    <div>
        <ul>
            <li>网络不稳定</li>
            <li>尚未接入互联网</li>
            <li>安全软件禁止访问网络</li>
        </ul>
    </div>
    <div class="fs14 fwb">
        你可以：</div>
    <div>
        <ul>
            <li><a href="javascript:void(0)" id="i_a_openwifi">点此开启您的wifi网络</a></li>
            <li>去系统设置中开启您的移动网络</li>
        </ul>
    </div>
    <div class="fs14 fwb">
        请检查网络后点击下面的刷新按钮重试</div>
    <div>
        <a href="SaoMiao.aspx" id="">
            <img src="/images/refresh.png" style="width: 40px; height: 40px;" alt="reload" /></a>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            window.eYou.ready({});
            $("#i_a_reload").click(function() { window.eYou.reload(); });
            $("#i_a_openwifi").click(function() { $("#i_a_openwifi").text("正在开启您的wifi网络，请稍候"); window.eYou.wifi({ state: true, callback: function(winParam) { window.eYou.alert({ message: 'WIFI连接已打开', title: '消息', callback: function() { }, btnName: '确定' }); $("#i_a_openwifi").text("您的wifi网络已成功开启"); } }); });
        });
    </script>

</asp:Content>
