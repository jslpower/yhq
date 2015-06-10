using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using EyouSoft.Common;

namespace EyouSoft.Web.UserControl
{
    public partial class UploadControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 存储上传文件名称的客户端隐藏域的Id
        /// </summary>
        public string ClientHideID
        {
            get { return this.ClientID + "hidFileName"; }
        }

        private bool _isUploadMore = false;
        /// <summary>
        /// 是否可以选择多个文件，默认1个
        /// </summary>
        public bool IsUploadMore
        {
            get { return _isUploadMore; }
            set { _isUploadMore = value; }
        }

        private bool _isUploadSelf = false;
        /// <summary>
        /// 是否自动上传
        /// </summary>
        public bool IsUploadSelf
        {
            get { return _isUploadSelf; }
            set { _isUploadSelf = value; }
        }

        private string _fileTypes = "*.xls;*.xlsx;*.rar;*.zip;*.7z;*.pdf;*.doc;*.docx;*.dot;*.swf;*.jpg;*.gif;*.jpeg;*.png;*.bmp";
        /// <summary>
        /// 设置可上传文件格式 默认: *.xls;*.rar;*.pdf;*.doc;*.swf;*.jpg;*.gif;*.jpeg;*.png;
        /// </summary>
        public string FileTypes
        {
            get { return _fileTypes; }
            set { _fileTypes = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsChaKan) phUpload.Visible = false;
        }

        private string setimgheight;
        /// <summary>
        /// 上传控件图片大小(高度)参数必须匹配images/swfuplod目录下图片的高度
        /// </summary>
        public string SetImgheight
        {
            get { return setimgheight ?? "34"; }
            set { setimgheight = value; }
        }

        private string setimgwidth;
        /// <summary>
        /// 上传控件图片大小(宽度)参数必须匹配images/swfuplod目录下图片的宽度
        /// </summary>
        public string Setimgwidth
        {
            get { return setimgwidth ?? "178"; }
            set { setimgwidth = value; }
        }

        /// <summary>
        /// 原文件信息集合
        /// </summary>
        public IList<MFileInfo> YuanFiles
        {
            get { return GetYuanFiles(); }
            set { SetYuanFiles(value); }
        }
        /// <summary>
        /// 上传的文件信息集合
        /// </summary>
        public IList<MFileInfo> Files { get { return GetFiles(); } }

        string _YuanFileClassName = "upload_y_ul";
        /// <summary>
        /// 原上传文件信息样式名称
        /// </summary>
        public string YuanFileClassName
        {
            get { return _YuanFileClassName; }
            set { _YuanFileClassName = value; }
        }

        /// <summary>
        /// 原上传文件文件编号ClientName
        /// </summary>
        public string YuanFileIdClientName { get { return ClientID + "_Y_FID"; } }
        /// <summary>
        /// 原上传文件文件名称ClientName
        /// </summary>
        public string YuanFileNameClientName { get { return ClientID + "_Y_FNAME"; } }
        /// <summary>
        /// 原上传文件文件路径ClientName
        /// </summary>
        public string YuanFilePathClientName { get { return ClientID + "_Y_FPATH"; } }
        /// <summary>
        /// 是否查看 查看时隐藏上传控件
        /// </summary>
        public bool IsChaKan { get; set; }

        #region private members
        /// <summary>
        /// 获取原上传文件信息集合
        /// </summary>
        /// <returns></returns>
        IList<MFileInfo> GetYuanFiles()
        {
            IList<MFileInfo> items = new List<MFileInfo>();

            string[] fileid = Utils.GetFormValues(YuanFileIdClientName);
            string[] filename = Utils.GetFormValues(YuanFileNameClientName);
            string[] filepath = Utils.GetFormValues(YuanFilePathClientName);
            if (fileid == null || filename == null || filepath == null) return items;
            if (fileid.Length != filename.Length || fileid.Length != filepath.Length) return items;

            for (int i = 0; i < fileid.Length; i++)
            {
                var item = new MFileInfo();
                item.FileId = fileid[i];
                item.FileName = filename[i];
                item.FilePath = filepath[i];
                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// 设置原文件信息集合
        /// </summary>
        /// <param name="items"></param>
        void SetYuanFiles(IList<MFileInfo> items)
        {
            if (items == null || items.Count == 0) return;
            System.Text.StringBuilder s = new System.Text.StringBuilder();

            s.AppendFormat("<ul class=\"{0}\">", YuanFileClassName);

            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.FilePath)) continue;
                s.Append("<li class=\"file\">");
                s.AppendFormat("<input type=\"hidden\" name=\"{0}\" value=\"{1}\" />", YuanFileIdClientName, item.FileId);
                s.AppendFormat("<input type=\"hidden\" name=\"{0}\" value=\"{1}\" />", YuanFileNameClientName, item.FileName);
                s.AppendFormat("<input type=\"hidden\" name=\"{0}\" value=\"{1}\" />", YuanFilePathClientName, item.FilePath);
                s.AppendFormat("<a href=\"{0}\" target=\"_blank\">{1}</a>", item.FilePath, item.FileName);
                s.Append("<span><a href=\"javascript:void(0)\" onclick=\"delUploadYuanFile(this)\" title=\"删除\"><img src=\"/images/cha.gif\" style=\" cursor:pointer;\" alt=\"\"></a></span>");
                s.Append("</li>");
            }

            s.Append("</ul>");

            ltrYuanFile.Text = s.ToString();
        }

        /// <summary>
        /// 获取上传的文件信息
        /// </summary>
        /// <returns></returns>
        IList<MFileInfo> GetFiles()
        {
            IList<MFileInfo> items = new List<MFileInfo>();

            string[] file = Utils.GetFormValues(ClientHideID);

            if (file == null || file.Length == 0) return items;

            for (int i = 0; i < file.Length; i++)
            {
                if (string.IsNullOrEmpty(file[i])) continue;
                var s = file[i].Split('|');
                if (s.Length != 2) continue;

                var item = new MFileInfo { FileId = string.Empty, FileName = s[0], FilePath = s[1] };

                items.Add(item);
            }

            return items;
        }
        #endregion
    }

    #region 文件信息业务实体
    /// <summary>
    /// 文件信息业务实体
    /// </summary>
    public class MFileInfo
    {
        string _fielname = "查看";
        /// <summary>
        /// default constructor
        /// </summary>
        public MFileInfo() { }

        /// <summary>
        /// 文件编号
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// 文件名(显示)
        /// </summary>
        public string FileName
        {
            get { return string.IsNullOrEmpty(_fielname) ? "查看" : _fielname; }
            set { _fielname = value; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
    }
    #endregion
}