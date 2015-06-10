using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    public class SendMSG
    {
        public SendMSG()
        { }
        #region Model
        private int _msgId;
        private string _sendNum;
        private string _sendText;
        private DateTime _issuetime;
        private string _productid;
        private string _favourcode;
        /// <summary>
        /// 发送编号
        /// </summary>
        public int MsgID { get; set; }
        /// <summary>
        /// 发送号码
        /// </summary>
        public string SendNum { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string SendText { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 发送条数
        /// </summary>
        public int minusNum { get; set; }
        /// <summary>
        /// 优惠码
        /// </summary>
        public string FavourCode { get; set; }
        #endregion Model

    }

    public class serSendMSG
    {
        public serSendMSG()
        { }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID { get; set; }

    }
}
