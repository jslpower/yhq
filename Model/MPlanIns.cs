using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MPlanIns
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 保险单号
        /// </summary>
        public string InsNO { get; set; }
        /// <summary>
        /// 险种编号
        /// </summary>
        public string InsName { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 机票编号
        /// </summary>
        public string PlantID { get; set; }
        /// <summary>
        /// 保险金额
        /// </summary>
        public decimal InsMoney { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 投保人-单独购买使用
        /// </summary>
        public string PolicTor { get; set; }
        /// <summary>
        /// 联系电话-单独购买保险使用
        /// </summary>
        public string LinkTel { get; set; }
        /// <summary>
        /// 投保人邮箱-独立购买使用
        /// </summary>
        public string LinkMail { get; set; }
        /// <summary>
        /// 投保人地址-独立购买使用
        /// </summary>
        public string LinkAddress { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public InsState State { get; set; }
    }
    public class MPlanInsSer
    {
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string OperatorID { get; set; }
    }
}
