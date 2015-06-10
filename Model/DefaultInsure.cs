using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //默认保险
    public class DefaultInsure
    {
        /// <summary>
        /// 保险的ID
        /// </summary>
        public string InsuranceId { get; set; }
        /// <summary>
        /// 应收款
        /// </summary>
        public decimal ShouldGath { get; set; }
        /// <summary>
        /// 应付款
        /// </summary>
        public decimal ShouldPay { get; set; }
        /// <summary>
        /// 返钱
        /// </summary>
        public decimal RetMoney { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public decimal Gain { get; set; }
    }
}
