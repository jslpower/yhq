using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 游记
    /// </summary>
    public class MYouJi
    {
        #region Model
        private string _youjiid;
        private string _huiyuanid;
        private string _youjititle;
        private string _youjicontent;
        private DateTime? _issuetime;
        /// <summary>
        /// 游记主ID
        /// </summary>
        public string YouJiId
        {
            set { _youjiid = value; }
            get { return _youjiid; }
        }
        /// <summary>
        /// 会员Id
        /// </summary>
        public string HuiYuanId
        {
            set { _huiyuanid = value; }
            get { return _huiyuanid; }
        }
        /// <summary>
        /// 游记标题
        /// </summary>
        public string YouJiTitle
        {
            set { _youjititle = value; }
            get { return _youjititle; }
        }
        /// <summary>
        /// 游记内容
        /// </summary>
        public IList<XingCheng> YouJiContent { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 游记类型
        /// </summary>
        public YouJiLeiXing YouJiType { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string ShiPinLink { get; set; }
        /// <summary>
        /// 微信码
        /// </summary>
        public string WeiXinMa { get; set; }
        #endregion Model
    }
    /// <summary>
    /// 游记行程
    /// </summary>
    public class XingCheng
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgFile { get; set; }
        /// <summary>
        /// 行程内容
        /// </summary>
        public string XingChengContent { get; set; }
    }

    /// <summary>
    /// 游记查询类
    /// </summary>
    public class MYouJiSer
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 游记类型
        /// </summary>
        public YouJiLeiXing? YouJiType { get; set; }
    }
}
