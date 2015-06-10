<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxShiPin.aspx.cs" Inherits="Eyousoft_yhq.Web.CommonPage.ajaxShiPin" %>

<asp:repeater id="RepList" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="youji_title" data-yjid="<%# Eval("YouJiId")%>"><a href="<%# Eval("shipinlink") %>"> <%# Eval("YouJiTitle")%></a></div>
                            <div class="guwen_head">
                                <div class="guwen_touxian radius">
                                    <img src="<%=TuXiangFilepath %>"></div>
                                <div class="guwen_name">
                                    <%= XingMing%></div>
                                <div class="font12">
                                    <%# Convert.ToDateTime(Eval("IssueTime")).ToShortDateString()%>
                                </div>
                                <% if (IsMy)
                                   { %>
                                   <a href="javascript:;" class="btn2 edit">编辑</a>  <a href="javascript:void(0)" class="btn">删除</a>
                                    <%} %>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:repeater>
