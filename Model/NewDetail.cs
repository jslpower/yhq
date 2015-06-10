using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //新闻详细
    public class NewDetail
    {
        /// <summary>
        /// 新闻 ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 新闻类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 创建者代号
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改者代号
        /// </summary>
        public string EditBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditTime { get; set; }
        /// <summary>
        /// 新闻是否可用
        /// </summary>
        public bool MenuStatus { get; set; }
    }
}
