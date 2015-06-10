<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxOrders.aspx.cs" Inherits="Eyousoft_yhq.Web.CommonPage.ajaxOrders" %>

<asp:repeater id="rpt_orders" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="list_msg" data-id="">
                                            <div class="dd_pic">
                                                <img src="<%# getProImg(Eval("ProductID").ToString())%>"></div>
                                            <div class="dd_right">
                                                <div class="title">
                                                    <%#  Eval("ProductName")%></div>
                                                <p>
                                                    <span class="price">
                                                        <%#   Convert.ToDecimal(Eval("OrderPrice")).ToString("C0")%></span><%# BindZhiFuBao(Eval( "OrderId").ToString(), Eval("OrderState"), Eval( "PayState"), Eval( "XiaoFei"))%></p>
                                            </div>
                                        </div>
                                        <div id="LM<%# Container.ItemIndex+1 %>" class="load" style="display: none;">
                                            <%#DownFile(Eval("SendFile"), Eval("OrderId").ToString())%><a href="/AppPage/ZxingCode/CodeBox.aspx?id=<%# Eval( "OrderId") %>">[查看二维码]</a></div>
                                    </li>
                                </ItemTemplate>
                            </asp:repeater>
