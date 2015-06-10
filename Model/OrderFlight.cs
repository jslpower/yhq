using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //预订单
    public partial class OrderFlight
    {
        /// <summary>
        /// 预订单号
        /// </summary>
        public string SubsOrderNo { get; set; }
        /// <summary>
        /// 订座记录编码
        /// </summary>
        public string Pnr { get; set; }
        /// <summary>
        /// 乘机人数
        /// </summary>
        public int PassengerCount { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal BalanceMoney { get; set; }
        /// <summary>
        /// 业务状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderSt { get; set; }
        /// <summary>
        /// 订单流程状态
        /// </summary>
        public string FlowStep { get; set; }
        /// <summary>
        /// 订单当前流程状态
        /// </summary>

        public string FlowStatus { get; set; }
        /// <summary>
        /// 修改标识
        /// </summary>
        public string ModifyTag { get; set; }
        /// <summary>
        /// 出票时限日期
        /// </summary>
        public DateTime TicketLimitDt { get; set; }
        /// <summary>
        /// 出票时限时间
        /// </summary>
        public DateTime TicketLimitTime { get; set; }

        public List<Passengerr> Passengers{get;set;}

    }
}
