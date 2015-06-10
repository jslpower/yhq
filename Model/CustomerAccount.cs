using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class CustomerAccount
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNo { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 是否已冻结
        /// </summary>

        public bool IsFreeze { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 信用额度
        /// </summary>
        public decimal Credit { get; set; }
    
    }
}
