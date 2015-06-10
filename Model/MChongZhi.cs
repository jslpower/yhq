using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MChongZhi
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 充值人编号
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal OptMoney { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime Issuetime { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PaymentState PayState { get; set; }
        /// <summary>
        /// 充值编号
        /// </summary>
        public string TradeNo { get; set; }

        #region 扩展
        /// <summary>
        /// 充值人账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 充值人姓名
        /// </summary>
        public string ContactName { get; set; }


        #endregion

    }
    public class MChongZhiSer
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 充值账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 充值人编号
        /// </summary>
        public string OperatorID { get; set; }

    }
}
