<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdImgList.ascx.cs" Inherits="Eyousoft_yhq.Web.userControl.AdImgList" %>

<script type="text/javascript">
    $(function() {
        $('#newsSlider').loopedSlider({
            autoStart: 3000
        });
        $('.validate_Slider').loopedSlider({
            autoStart: 3000
        });
    });
</script>

<div class="banner">
    <div id="newsSlider" class="piclist">
        <ul class="slides" style="width: 2880px; left: -960px;">
            <%=liImg%>
        </ul>
        <div class="validate_Slider">
        </div>
        <ul class="pagination">
            <%=li %>
        </ul>
    </div>
</div>
