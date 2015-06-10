using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class QueryRefund
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 退票业务单号
        /// </summary>
        public string RefundNo { get; set; }
        /// <summary>
        /// 订座记录
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNo { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string RefundSt { get; set; }
        /// <summary>
        /// 全部航段
        /// </summary>
        public string CompleteRouting { get; set; }
        /// <summary>
        /// 原付金额
        /// </summary>
        public string AmountPaid { get; set; }
        /// <summary>
        /// 票款合计
        /// </summary>

        public string PriceMoney { get; set; }
        /// <summary>
        /// 税款合计
        /// </summary>
        public string TaxAmount { get; set; }
        /// <summary>
        /// 已使用票款
        /// </summary>
        public string AmountUsed { get; set; }
        /// <summary>
        /// 已使用税款
        /// </summary>
        public string TaxUsed { get; set; }
        /// <summary>
        /// 退票费率
        /// </summary>

        public string RefundRate { get; set; }
        /// <summary>
        /// 退票费
        /// </summary>
        public string ServiceCharge { get; set; }
        /// <summary>
        /// 应扣佣金
        /// </summary>
        public string DeductComm { get; set; }
        /// <summary>
        /// 应退金额
        /// </summary>
        public string ShouldRefund { get; set; }
        /// <summary>
        /// 实退金额
        /// </summary>
        public string AmountRefunded { get; set; }
        /// <summary>
        /// 退改签规定
        /// </summary>

        public string RefundRule { get; set; }
        /// <summary>
        /// 其他要求
        /// </summary>
        public string Requst { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string Reasons { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateDt { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditingSt { get; set; }
        /// <summary>
        /// 复核状态
        /// </summary>
        public string CheckSt { get; set; }
        /// <summary>
        /// 收款状态
        /// </summary>

        public string GathingSt { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string ProviderCustomer { get; set; }
        /// <summary>
        /// 推广商
        /// </summary>
        public string BelongCustomer { get; set; }

    }
}
