using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
   public class OrderCacleMoney
    {
        /// <summary>
        /// 应收款
        /// </summary>
       public decimal BalanceMoney { get; set; }
        /// <summary>
       /// 票款
        /// </summary>
       public decimal Fare { get; set; }
        /// <summary>
       /// 客户返钱
        /// </summary>
       public decimal CustomerGain { get; set; }

    }
}
