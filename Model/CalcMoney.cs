using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //报价计算接口
    public class CalcMoney
    {
        /// <summary>
        /// 下家应收款
        /// </summary>
        public decimal BalanceMoney { get; set; }
        /// <summary>
        /// 代理人利润
        /// </summary>
        public string AgentGain { get; set; }
        /// <summary>
        /// 应收合计
        /// </summary>
        public decimal  AccountMoney { get; set; }
        /// <summary>
        /// 票款合计
        /// </summary>
        public decimal PriceMoney { get; set; }
        /// <summary>
        /// 税款合计
        /// </summary>
        public decimal TaxTotal { get; set; }
        /// <summary>
        /// 保险合计
        /// </summary>
        public decimal InsMoney { get; set; }
        /// <summary>
        /// 附加费
        /// </summary>
        public decimal AffixFee { get; set; }
        /// <summary>
        /// 单类乘机人总票价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 单类乘机人人数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 单类乘机人总税款
        /// </summary>
        public decimal Tax { get; set; }

    }
}
