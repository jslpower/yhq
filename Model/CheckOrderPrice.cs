using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
   public class CheckOrderPrice
    {
        /// <summary>
        /// 原订单价格
        /// </summary>
       public decimal OldPrice { get; set; }
        /// <summary>
       /// 新订单价格
        /// </summary>
       public decimal NewPrice { get; set; }
        /// <summary>
       /// 是否可以提交
        /// </summary>
       public bool IsAllowCommit { get; set; }
    }
}
