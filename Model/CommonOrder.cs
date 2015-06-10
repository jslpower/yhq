using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //通用订单
   public class CommonOrder
    {
        /// <summary>
        /// 订单号
        /// </summary>
       public string SubsOrderNo { get; set; }
        /// <summary>
       /// 订单金额
        /// </summary>
       public decimal BalanceMoney { get; set; }
        /// <summary>
       /// 流程状态
        /// </summary>
       public string FlowStep { get; set; }
        /// <summary>
       /// 订单状态
        /// </summary>
       public string FlowStatus { get; set; }

       public string ModifyTag { get; set; }
    }
}
