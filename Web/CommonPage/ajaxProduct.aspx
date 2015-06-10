<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxProduct.aspx.cs" Inherits="Eyousoft_yhq.Web.CommonPage.ajaxProduct" %>
<asp:repeater id="rpt_list" runat="server">
                            <ItemTemplate>
                                <li><a href="productinfo.aspx?id=<%#Eval("ProductID") %>">
                                    <div class="imgArea">
                                        <img src="<%# getProImg(Eval("ProductID").ToString()) %>" alt="" /><div class="new">
                                        </div>
                                    </div>
                                    <dl>
                                        <dt>
                                            <%#Eval("ProductName") %></dt>
                                        <dd>
                                            <span class="price">&nbsp;&nbsp;<font class="font22">￥</font><%# EyouSoft.Common.Utils.GetDecimal( Eval("AppPrice").ToString()).ToString("0")%></span>
                                            <span class="price1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("MarketPrice", "{0:c0}")%></span>
                                        </dd>
                                        <dd class="font_pl">
                                            <img src="/images/pl.gif" alt="" />
                                            <%# getCommentNum(Eval("ProductID"))%>条评论</dd>
                                    </dl>
                                </a></li>
                            </ItemTemplate>
                        </asp:repeater>