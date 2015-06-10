using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MJiPiaoBaoCun
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string OpeatorID { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string OpeatorName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 机票支付状态
        /// </summary>
        public TickOrderPayState payState { get; set; }
        /// <summary>
        /// 修改标识
        /// </summary>
        public string ModifyTag { get; set; }
        /// <summary>
        /// 传票地址
        /// </summary>
        public string JpAdress { get; set; }
        /// <summary>
        /// 保险金额
        /// </summary>
        public decimal InsPrice { get; set; }
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }

    }
    public class MJiPiaoBaoCunSer
    {
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string OpeatorID { get; set; }
        /// <summary>
        /// 机票支付状态
        /// </summary>
        public TickOrderPayState? payState { get; set; }
    }
}
