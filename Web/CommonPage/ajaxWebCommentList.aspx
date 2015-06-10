<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxWebCommentList.aspx.cs"
    Inherits="Eyousoft_yhq.Web.CommonPage.ajaxWebCommentList" %>

<ul>
    <asp:repeater id="rpt_list" runat="server">
                                    <ItemTemplate>
                     <li>
            <div class="pl_listl">
                <img src="images/userpic.gif"></div>
            <div class="pl_listr">
                <div class="userName">
                    <%# Eval("PeopleName")%>  <%#Eval("IssueTime","{0:d}")%></div>
                <div class="dianpCont"> <%#Eval("CommentText")%></div>
            </div>
        </li>                   
                                    
                                    </ItemTemplate></asp:repeater>
</ul>
<input type="hidden" id="hidCount" value="<%=shuliang %>" />