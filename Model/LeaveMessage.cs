using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class LeaveMessage
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 留言状态
        /// </summary>
        public string LeaveMessageStauts { get; set; }
        /// <summary>
        /// 留言类型
        /// </summary>
        public string LeaveMessageType { get; set; }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime LeaveMessageDt { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string LeaveMessageContent { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime ReplyDt { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>

        public string ReplyContent { get; set; }
    }
}
