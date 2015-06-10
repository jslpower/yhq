<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelArticleList.aspx.cs"
    Inherits="EyouSoft.Web.WebMaster.TravelArticleList" Title="旅游咨询" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>旅游资讯</title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1" action="TravelArticleList.aspx" method="get">
                    <div class="searchbox">
                        <label>
                            标题：</label>
                        <input type="text" class="inputtext searchinput formsize100" name="txtArticleTitle"
                            value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtArticleTitle") %>" />
                        <label>
                            类别：</label>
                        <select id="ddlArticleClass" name="ddlArticleClass" class="inputselect">
                            <%=BindArticleClass(EyouSoft.Common.Utils.GetQueryStringValue("ddlArticleClass"))%>
                        </select>
                        <label>
                            发布日期：</label>
                        <input type="text" onfocus="WdatePicker()" name="txtStartTime" id="txtStartTime"
                            size="10" class="inputtext searchinput formsize70" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStartTime") %>" />-<input
                                type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}'})" class="inputtext searchinput formsize70"
                                name="txtEndTime" id="txtEndTime" size="10" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtEndTime") %>" />
                        <input type="submit" class="search-btn" value="查询" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="btnbox">
        <table width="99%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <asp:PlaceHolder runat="server" ID="phadd">
                        <td width="90" align="center">
                            <a class="toolbar_add" href="javascript:void(0)">新增</a>
                        </td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="PhUpdate">
                        <td width="90" align="center">
                            <a class="toolbar_update" href="javascript:void(0)">修改</a>
                        </td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="Phdelete">
                        <td width="90" align="center">
                            <a href="javascript:void(0)" class="toolbar_delete">删除</a>
                        </td>
                    </asp:PlaceHolder>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>
                    <th align="center">
                        标题
                    </th>
                    <th align="center">
                        简介
                    </th>
                    <th align="center">
                        类别
                    </th>
                    <th align="center">
                        发布人
                    </th>
                    <th align="center">
                        发布时间
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="RpArticle">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <td height="30" align="center">
                                <input type="checkbox" name="checkbox" value="<%#Eval("ArticleID") %>">
                            </td>
                            <td align="center">
                                <a class="show" <%#Eval("TitleColor")%> <%#!string.IsNullOrEmpty(Eval("TitleColor").ToString()) ? string.Format("style='color:{0}'", Eval("TitleColor")) : ""%>
                                    href="javascript:void(0);" data-id="<%#Eval("ArticleID") %>">
                                    <%#Eval("ArticleTitle")%></a>
                            </td>
                            <td align="center">
                                <%#  EyouSoft.Common.Utils.GetText2(Eval("ArticleText").ToString(), 30, true)%>
                            </td>
                            <td align="center">
                                <%#Eval("ClassName")%>
                            </td>
                            <td align="center">
                                <%#Eval("OperatorName")%>
                            </td>
                            <td align="center">
                                <%#Eval("IssueTime")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </tbody>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        var TravelArticleList = {
            //Ajax请求
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
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
            },
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height,
                    afterHide: function() {
                        window.location.href = window.location.href;
                        return false;
                    }
                });
            },
            GetCheckBox: function(objArr) {
                //定义数组对象
                var list = new Array();
                //遍历按钮返回数组对象
                for (var i = 0; i < objArr.length; i++) {
                    //从数组对象中找到数据所在，并保存到数组对象中
                    if (objArr[i].find("input[type='checkbox']").val() != "on") {
                        list.push(objArr[i].find("input[type='checkbox']").val());
                    }
                }
                return list.join(',');
            },
            //添加
            Add: function() {
                TravelArticleList.ShowBoxy({ iframeUrl: "/WebMaster/TravelArticleEdit.aspx?dotype=add", title: "新增公告", width: "970px", height: "400px" });
            },
            //修改(弹窗)---objsArr选中的TR对象
            Update: function(ObjsArr) {
                TravelArticleList.ShowBoxy({ iframeUrl: "/WebMaster/TravelArticleEdit.aspx?dotype=update&tid=" + ObjsArr[0].find("input[type='checkbox']").val(), title: "修改旅游资讯", width: "970px", height: "400px" });
            },
            //删除(可多行)
            DelAll: function(objArr) {
                //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                TravelArticleList.ajaxurl = "/WebMaster/TravelArticleList.aspx?dotype=delete&tid=" + TravelArticleList.GetCheckBox(objArr);
                //执行/ajax
                TravelArticleList.GoAjax(TravelArticleList.ajaxurl);

            },
            Show: function(id) {
                TravelArticleList.ShowBoxy({ iframeUrl: "/WebMaster/TravelArticleEdit.aspx?dotype=show&tid=" + id, title: "查看公告", width: "970px", height: "400px" });
            },
            PageInit: function() {

                //绑定Add事件
                $(".toolbar_add").click(function() {
                    TravelArticleList.Add();
                    return false;
                });

                $(".show").click(function() {
                    var id = $(this).attr("data-id");
                    if (id) {
                        TravelArticleList.Show(id);
                        return false;
                    }
                });


                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行", //

                    //修改-删除-取消-复制 为默认按钮，按钮class对应  toolbar_update  toolbar_delete  toolbar_cancel  toolbar_copy即可
                    updateCallBack: function(obj) {
                        //修改
                        TravelArticleList.Update(obj);
                    },
                    deleteCallBack: function(objsArr) {
                        //删除(批量)
                        TravelArticleList.DelAll(objsArr);
                    }
                });
            }
        };



        $(function() {
            TravelArticleList.PageInit();
        });
    </script>

</body>
</html>
