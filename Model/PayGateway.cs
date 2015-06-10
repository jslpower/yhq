using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //在线支付网关
    public class PayGateways
    {
        /// <summary>
        /// 支付网关代码
        /// </summary>
        public string PayGateway { get; set; }
        /// <summary>
        /// 支持的银行代码
        /// </summary>
        public string BankCodes { get; set; }
    }
}
