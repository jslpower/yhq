<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiDian.aspx.cs" Inherits="Eyousoft_yhq.Web.webMaster.WeiDian" MasterPageFile="~/webMaster/NeiYe.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="YeMianBody" ID="YeMianBody1" runat="server">
    <form action="" method="get" name="form1" id="form1">
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif">
                </td>
                <td>
                    <div class="searchbox">
                        微店名称：
                        <input type="text" id="txtMingCheng" class="searchinput formsize100" name="txtMingCheng" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtMingCheng") %>" />
                        微店状态：
                        <select id="txtStatus" name="txtStatus">
                            <option value="">-请选择-</option>
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(Eyousoft_yhq.Model.WeiDianStatus)), "")%>
                        </select>
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
    
    <div class="btnbox">
    
    </div>
    
    <div class="tablelist">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="Tborder">
            <tr>
                <th width="62" align="center" height="30">
                    序号
                </th>
                <th width="200" align="center">
                    微店名称
                </th>
                <th width="150" align="center">
                    会员账号
                </th>
                <th width="150" align="center">
                    会员姓名
                </th>
                <th width="150" align="center">
                    申请时间
                </th>
                <th width="150" align="center">
                    审核时间
                </th>
                <th width="150" align="center">
                    微店状态
                </th>
                <th align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
            <tr bgcolor='<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>' data-weidianid="<%#Eval("WeiDianId") %>">
                <td width="62" align="center" height="30">
                    <%# Container.ItemIndex + 1+( this.PageIndex - 1) * this.PageSize%>
                </td>
                <td width="200" align="center">
                    <%#Eval("MingCheng") %>
                </td>
                <td width="200" align="center">
                    <%#Eval("YongHuMing") %>
                </td>
                <td width="100" align="center">
                    <%#Eval("HuiYuanName") %>
                </td>
                <td width="100" align="center">
                    <%#Eval("ShenQingTime","{0:yyyy-MM-dd HH:mm}") %>
                </td>
                <td align="center">
                    <%#GetShenHeTime(Eval("ShenHeTime"),Eval("Status")) %>
                </td>
                <td align="center">
                    <%#Eval("Status") %>
                </td>
                <td align="center">
                    <%#GetCaoZuo(Eval("Status")) %>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
            <tr>
                <td style="height: 30px;" colspan="20" bgcolor="#e3f1fc">暂无微店申请信息</td>
            </tr>
            </asp:PlaceHolder>
        </table>
        
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right" height="40">
                        <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            shenHe: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtWeiDianId: _$tr.attr("data-weidianid") };
                var _self = this;
                if (!confirm("开通微店操作暂不可逆，你确定要开通吗？")) return false;

                $.ajax({ type: "POST", url: "weidian.aspx?doType=shenhe", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        _self.reload();
                    },
                    error: function() { }
                });
            },
            chaKan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { weidianid: _$tr.attr("data-weidianid") };
                Boxy.iframeDialog({ title: "微店信息", iframeUrl: "weidianedit.aspx", width: "670px", height: "340px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            $(".chakan").click(function() { iPage.chaKan(this); });
            $(".shenhe").click(function() { iPage.shenHe(this); });

            $("#txtStatus").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStatus") %>');
        });
    </script>
</asp:Content>