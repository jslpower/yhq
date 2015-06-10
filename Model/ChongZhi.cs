using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 充值实体类
    /// </summary>
    public class ChongZhi
    {
        public int ID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal JINE { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime ChongZhiShiJian { get; set; }
        /// <summary>
        /// 充值方式
        /// </summary>
        public PayWay ChongZhiFangShi { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PaymentState DingDanZhuangTai { get; set; }
        /// <summary>
        /// 订单描述
        /// </summary>
        public string MiaoShu { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string TradeNo { get; set; }
    }
}
