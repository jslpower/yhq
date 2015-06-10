<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadControl.ascx.cs"
    Inherits="EyouSoft.Web.UserControl.UploadControl" %>
<asp:PlaceHolder runat="server" ID="phUpload">
    <div style="margin: 3px 0px; float: left;">
        <div>
            <input type="hidden" id="<%=this.ClientHideID %>" />
            <span runat="server" id="spanButtonPlaceholder"></span><span id="errMsg_<%=this.ClientHideID %>"
                class="errmsg"></span>
        </div>
        <div id="divFileProgressContainer" runat="server">
        </div>
        <div id="thumbnails">
        </div>
    </div>

    <script type="text/javascript">
	    var <%=this.ClientID %>;
			    <%=this.ClientID %> = new SWFUpload({
		
				    upload_url: "/CommonPage/upload.aspx",
				    file_post_name:"Filedata",
                    post_params : {
                        "ASPSESSID" : "<%=Session.SessionID %>"
                    },
				    // File Upload Settings
				    file_size_limit : "2 MB",
				    file_types : "<%=FileTypes %>",
				    file_types_description : "附件上传",
				    file_upload_limit : <%=IsUploadMore?0:1 %>,    // Zero means unlimited

				    // Event Handler Settings - these functions as defined in Handlers.js
				    //  The handlers are not part of SWFUpload but are part of my website and control how
				    //  my website reacts to the SWFUpload events.
				    swfupload_loaded_handler :function(){},
				    file_dialog_start_handler : fileDialogStart,
				    file_queued_handler : fileQueued,
				    file_queue_error_handler : fileQueueError,
				    file_dialog_complete_handler :<%=IsUploadSelf?"fileDialogComplete":"null" %> ,
				    upload_progress_handler : uploadProgress,
				    upload_error_handler : uploadError,
				    upload_success_handler : uploadSuccess,
				    upload_complete_handler : uploadComplete,
				    // Button settings
				    button_image_url : "/images/swfupload/XPButtonNoText_"+<%=Setimgwidth %>+"_"+<%=SetImgheight %>+".gif",
				    button_placeholder_id : "<%=spanButtonPlaceholder.ClientID %>",
				    button_width: <%=Setimgwidth %>,
				    button_height: <%=SetImgheight %>,
				    button_text : '<span></span>',
				    button_text_style : '',
				    button_text_top_padding: 1,
				    button_text_left_padding: 3,
				    button_cursor: SWFUpload.CURSOR.HAND, 

				    // Flash Settings
				    flash_url : "/js/swfupload/swfupload.swf",	// Relative to this file

				    custom_settings : {
					    upload_target : "<%=divFileProgressContainer.ClientID %>",
				        HidFileNameId:"<%=this.ClientHideID %>",
				        HidFileName:"<%=this.ClientHideID %>",
				        ErrMsgId:"errMsg_<%=this.ClientHideID %>",
				        UploadSucessCallback:function(){}
				    },

				    // Debug Settings
				    debug: false,
    				
				    // SWFObject settings
		            minimum_flash_version : "9.0.28",
		            swfupload_pre_load_handler : swfUploadPreLoad,
		            swfupload_load_failed_handler : swfUploadLoadFailed
			    });
			    
			    try{
			        currentSwfuploadInstances.push( <%=this.ClientID %>);
			    }
			    catch(e){}
    </script>

</asp:PlaceHolder>

<script type="text/javascript">
    function delUploadYuanFile(obj) {
        var _$li = $(obj).closest("li");
        var _$ul = _$li.parent();
        _$li.remove();
        if (_$ul.find("li").length == 0) _$ul.remove();
    }	  
</script>

<style type="text/css">
    .upload_y_ul
    {
        list-style: none;
        float: left;
        margin-left: 5px;
        height: 40px;
        line-height: 40px;
        width: 320px;
    }
    .upload_y_ul li
    {
        list-style: none;
        float: left;
        margin-left: 8px;
        line-height: 40px;
    }
    .upload_y_ul li.file
    {
    }
    .upload_y_ul li span
    {
        padding-left: 2px;
    }
    .upload_y_ul li img
    {
        margin-top: -3px;
    }
</style>
<asp:Literal runat="server" ID="ltrYuanFile"></asp:Literal>