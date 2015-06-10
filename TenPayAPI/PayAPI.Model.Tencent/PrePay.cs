using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayAPI.Model.Tencent
{
    public class PrePay
    {
        /// <summary>
        /// 请求状态
        /// </summary>
        public bool ReqState
        {
            get;
            set;
        }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg
        { get; set; }

        /// <summary>
        /// 业务状态
        /// </summary>
        public bool IsSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// 预支付ID
        /// </summary>
        public string PrepayId
        {
            get;
            set;
        }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr
        {
            get;
            set;
        }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign
        {
            get;
            set;
        }
        /// <summary>
        /// 时间截
        /// </summary>
        public string TimeStamp
        {
            get;
            set;
        }
    }
}
