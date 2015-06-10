<%@ Page Title="地址管理" Language="C#" MasterPageFile="~/masterPage/WebMemberCenter.Master"
    AutoEventWireup="true" CodeBehind="AddressManage.aspx.cs" Inherits="Eyousoft_yhq.Web.Huiyuan.AddressManage" %>

<%@ Register Src="~/userControl/HuiYuanLeftMenu.ascx" TagName="HuiYuanLeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HuiYuanLeftMenu ID="HuiYuanLeftMenu1" runat="server" />
    <div class="MenberSidebar02">
        <h2 class="h2-addr">
            收货地址</h2>
        <div class="address_box">
            <h3>
                <span>新增收货地址</span>电话号码、手机号选填一项,其余均为必填项</h3>
            <form runat="server" id="form1">
            <ul class="addr_form">
                <li>
                    <label>
                        收货人姓名：</label><p>
                            <input name="contactname" type="text" class="formsize200 inputbg" runat="server"
                                id="contactname" valid="required" errmsg="收货人姓名不能为空" /><span class="star">*</span></p>
                </li>
                <li>
                    <label>
                        所在地区：</label><p>
                            <select name="ddlProvince" id="ddlProvince" valid="required" errmsg="省份不能为空">
                            </select>
                            <select name="ddlCity" id="ddlCity" valid="required" errmsg="城市不能为空">
                            </select>
                            <select name="ddlCountry" id="ddlCountry">
                            </select>
                            <span class="star">*</span></p>
                </li>
                <li>
                    <label>
                        街道地址：</label><p>
                            <input name="addressinfo" type="text" class="formsize360 inputbg" runat="server"
                                id="addressinfo" valid="required" errmsg="地址不能为空" /><span class="star">*</span><span
                                    class="error_txt">不需要重复填写省/市/区</span></p>
                </li>
                <li>
                    <label>
                        邮政编码：</label><p>
                            <input name="zpcode" type="text" class="formsize120 inputbg" runat="server" id="zpcode"
                                valid="required" errmsg="邮政编码不能为空" /><span class="star">*</span></p>
                </li>
                <li>
                    <label>
                        手机号码：</label><p>
                            <input name="mobileNum" type="text" class="formsize200 inputbg" runat="server" id="mobileNum"
                                valid="isMobile" errmsg="手机格式不正确" /><span class="error_txt">手机号码、固定电话必填一项</span></p>
                </li>
                <li>
                    <label>
                        固定电话：</label><p>
                            <input name="" type="text" class="formsize200 inputbg" runat="server" id="telNum"
                                valid="isPhone" errmsg="电话格式不正确" /></p>
                </li>
                <li>
                    <label>
                        设为常用地址：</label><p class="fuxuank">
                            <input name="isdefault" type="checkbox" value="" runat="server" id="isdefault" /></p>
                    <input type="hidden" id="hidefault" name="hidefault" value="<%=mark %>" />
                </li>
                <li>
                    <p style="margin-left: 10em;">
                        <button class="baocunbtn" id="btnsave" onclick="return false">
                            保 存</button></p>
                </li>
            </ul>
            </form>
            <div class="addr_table">
                <table cellspacing="0" cellpadding="0" class="addressList">
                    <caption>
                        已保存的有效地址</caption>
                    <tr>
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
                        <th width="80px">
                            &nbsp;
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_address" runat="server">
                        <ItemTemplate>
                            <tr>
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
                                <td>
                                    <a class="setDefault" style="display: none" href="javascript:;" data-id="<%# Eval("AddressID")%>">
                                        设为默认</a>
                                </td>
                                <td align="center">
                                    <a href="javascript:;" data-id="<%# Eval("AddressID")%>" class="toolbar_update">修改</a>
                                    | <a href="javascript:;" data-id="<%# Eval("AddressID")%>" class="toolbar_delete">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="NoMsg" runat="server"></asp:Literal>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        var pageOpt = {
            parm: {
                id: '<%=Request.QueryString["id"] %>',
                dotype: '<%=Request.QueryString["dotype"] %>'
            },
            ddlInnt: function() {
                pcToobar.init({
                    pID: "#ddlProvince",
                    cID: "#ddlCity",
                    xID: "#ddlCountry",
                    pSelect: "<%=this.xProvinceId %>",
                    cSelect: "<%=this.xCityId %>",
                    xSelect: '<%=this.xSelect %>',
                    comID: '1'
                });
            },
            pageSave: function() {
                $("#btnsave").val("注册中").unbind("click").css({ "color": "#999999" });
                if (pageOpt.parm.dotype == "") {
                    pageOpt.parm.dotype = "add";
                }
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/Huiyuan/AddressManage.aspx?save=save&" + $.param(pageOpt.parm),
                    dataType: "json",
                    data: $("#btnsave").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                                location.href = "/Huiyuan/AddressManage.aspx";
                            });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                            pageOpt.bindBtn();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        pageOpt.bindBtn();
                    }
                });
            },
            bindBtn: function() {
                $("#btnsave").val("提交注册").bind("click", function() {
                    $(this).css({ "color": "" });
                    return false;
                });
            }, //
            setDefault: function(id, mark) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/Huiyuan/AddressManage.aspx?setDefault=" + mark + "&id=" + id,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                            location.href = "/Huiyuan/AddressManage.aspx";
                            });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg);
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }

        };

        $(function() {
            pageOpt.ddlInnt();
            $("#btnsave").click(function() {
                if (ValiDatorForm.validator($("#btnsave").closest("form").get(0), "parent")) {
                    var getmobile = $("#<%=mobileNum.ClientID %>").val();
                    var getel = $("#<%=telNum.ClientID %>").val();
                    if (getel == "" && getmobile == "") {
                        tableToolbar._showMsg("手机号码、固定电话必填一项");
                        return false;
                    }
                    pageOpt.pageSave();
                }
            })//保存
            $("#<%=isdefault.ClientID %>").click(function() {
                if ($(this).attr("checked")) {
                    $("#hidefault").val("1");
                }
                else {
                    $("#hidefault").val("0");
                }
            })
            $("a.setDefault").click(function() {
                pageOpt.setDefault($(this).attr("data-id"), 1)
            })    //设置默认
            $("a.toolbar_update").click(function() {
                window.location.href = "/Huiyuan/AddressManage.aspx?dotype=edit&id=" + $(this).attr("data-id");
            })    //修改
            $(".toolbar_delete").click(function() {
                var id = $(this).attr("data-id");
                tableToolbar.ShowConfirmMsg("是否删除该记录？", function() {
                    pageOpt.setDefault(id, 3)
                });
            })    //删除
            $(".addressList tr").hover(function() { $(this).addClass("addressList_hover"); $(this).find(".setDefault").css("display", "block") }, function() { $(this).removeClass("addressList_hover"); $(this).find(".setDefault").css("display", "none") });
        })
    </script>

</asp:Content>
