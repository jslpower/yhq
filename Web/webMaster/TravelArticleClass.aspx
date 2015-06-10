<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelArticleClass.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TravelArticleClass" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>旅游资讯类别</title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script type="text/javascript" src="/js/jquery.boxy.js"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/table-toolbar.js"></script>

    <link rel="stylesheet" type="text/css" href="/css/webmaster/boxy.css" />
</head>
<body>
    <div class="btnbox">
        <table cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:;" id="add_bar">新 增</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <th width="36" bgcolor="#BDDCF4" align="center">
                        序号
                    </th>
                    <th bgcolor="#BDDCF4" align="center">
                        名称
                    </th>
                    <th bgcolor="#BDDCF4" align="center">
                        排序
                    </th>
                    <th width="17%" bgcolor="#bddcf4" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" data-id='<%#Eval("ClassId") %>'
                            data-is='<%#(int)Enum.Parse(typeof(Eyousoft_yhq.Model.ArticleType), Eval("IsSystem").ToString())%>'>
                            <td align="center">
                                <%# GetIndex(Container.ItemIndex)%>
                            </td>
                            <td align="center">
                                <font <%#(int)Enum.Parse(typeof(Eyousoft_yhq.Model.ArticleType), Eval("IsSystem").ToString()) == 0 ? "" : "style='color:Red'"%>>
                                    <%#Eval("ClassName")%>
                                </font>
                            </td>
                            <td align="center">
                                <%#Eval("SortRule")%>
                            </td>
                            <td align="center">
                                <%#(int)Enum.Parse(typeof(Eyousoft_yhq.Model.ArticleType), Eval("IsSystem").ToString()) == 0 
                                    ? "<a href=\"javascript:;\" class=\"update_bar\">修改 </a>|<a href=\"javascript:;\" class=\"delete_bar\">删除</a>"
                                   : " "
                                %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                <tr>
                    <td height="30" align="right" class="pageup" colspan="4">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        $(function() {
            RouteTheme.BindBtn();
        })
        var RouteTheme = {
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            BindBtn: function() {
                $("#add_bar").click(function() {
                    RouteTheme.ShowBoxy({ iframeUrl: "/WebMaster/TravelClassEdit.aspx?action=add", title: "新增公告类别", width: "550px", height: "180px" });
                    return false;
                })
                $(".update_bar").click(function() {
                    var tid = $(this).closest("tr").attr("data-id");
                    RouteTheme.ShowBoxy({ iframeUrl: "/WebMaster/TravelClassEdit.aspx?action=edit&tid=" + tid, title: "修改公告类别", width: "550px", height: "180px" });
                    return false;
                })
                $(".delete_bar").click(function() {
                    var tid = $(this).closest("tr").attr("data-id");
                    var tis = $(this).closest("tr").attr("data-is");
                    if (tis == "0") {
                        var url = "/WebMaster/TravelArticleClass.aspx?dotype=delete&tid=" + tid + "&tis=" + tis;
                        tableToolbar.ShowConfirmMsg("您确定要删除此类别吗？", function() {
                            RouteTheme.GoAjax(url);
                        });
                    }
                    else {
                        tableToolbar._showMsg("不能删除！");
                    }
                    return false;
                })
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        }
    </script>

</body>
</html>
