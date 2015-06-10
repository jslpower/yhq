<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxCommentList.aspx.cs"
    Inherits="Eyousoft_yhq.Web.CommonPage.ajaxCommentList" %>

<ul >
    <asp:repeater id="rpt_list" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="pl_listl">
                                                <img src="/images/userpic.gif" /><p>
                                                    <%# Eval("PeopleName")%></p>
                                            </div>
                                            <div class="pl_listr">
                                                <p>
                                                    <%#Eval("CommentText")%></p>
                                                <span>
                                                    <%#Eval("IssueTime","{0:d}")%></span></div>
                                        </li>
                                    </ItemTemplate>
                                </asp:repeater>
</ul>
<input type="hidden" id="hidCount" value="<%=shuliang %>" />
<div class="clear"></div>