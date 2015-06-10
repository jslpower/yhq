<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxTuWenFenXiang.aspx.cs"
    Inherits="Eyousoft_yhq.Web.CommonPage.ajaxTuWenFenXiang" %>

<asp:repeater id="RepList" runat="server">
                     <ItemTemplate>
                                    <li>
                                        <div class="youji_title" data-yjid="<%# Eval("YouJiId")%>">
                                            <%# Eval("YouJiTitle")%></div>
                                        <div class="guwen_head">
                                            <div class="guwen_touxian radius">
                                                <img src="<%# getMemberName(Eval("HuiYuanId").ToString(),2)%>"></div>
                                            <div class="guwen_name">
                                                <%# getMemberName(Eval("HuiYuanId").ToString(),1)%></div>
                                            <div class="font12">
                                                <%#  Eval("IssueTime","{0:yyyy-MM-dd}") %>
                                            </div>
                                        </div>
                                    </li>
                                </ItemTemplate>
                </asp:repeater>
