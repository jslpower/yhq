using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //订单原因
    public class OverstepPriceReason
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNo { get; set; }
        /// <summary>
        /// 订单原因编号
        /// </summary>
        public string ReasonCode { get; set; }
        /// <summary>
        /// 订单原因
        /// </summary>
        public string Reason { get; set; }
    }
}
