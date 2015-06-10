using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MsgLog
    {

        public MsgLog() { }

        /// <summary>
        /// 主键编号
        /// </summary>
        public int msgid { get; set; }
        /// <summary>
        /// 发送号码
        /// </summary>
        public string TelCode { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string MsgText { get; set; }
        /// <summary>
        /// 发送结果（成功，失败）
        /// </summary>
        public string ReResult { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime Issuetime { get; set; }
    }

    public class serMsgLog
    {

        public serMsgLog() { }
        /// <summary>
        /// 发送号码
        /// </summary>
        public string TelCode { get; set; }

    }
}
