using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class JPModel
    {
        /// <summary>
        /// 预订单号
        /// </summary>
        public string SubsOrderNo { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNo { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string CusType { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman { get; set; }
        /// <summary>
        /// 应收款
        /// </summary>
        public decimal BalanceMoney { get; set; }
        /// <summary>
        /// 代理费
        /// </summary>
        public decimal Gain { get; set; }
        /// <summary>
        /// 下点利润
        /// </summary>
        public decimal PointGain { get; set; }
        /// <summary>
        /// 保险费
        /// </summary>
        public decimal InsMoney { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 预订单状态
        /// </summary>
        public string SubsOrderSt { get; set; }
        /// <summary>
        /// 销售员编号
        /// </summary>
        public string SalesID { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string OpID { get; set; }
        /// <summary>
        /// 预订员ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 预订单创建时间
        /// </summary>
        public DateTime CreateDt { get; set; }
        /// <summary>
        /// 出票人编号
        /// </summary>
        public string DzMan { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepID { get; set; }
        /// <summary>
        ///保险底价
        /// </summary>
        public string InsNetPrice { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 客户中文名
        /// </summary>
        public string CusName { get; set; }
        /// <summary>
        /// 预订单来源
        /// </summary>
        public string ApplyReason { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public string OrderSource { get; set; }
        /// <summary>
        /// 操作员名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepName { get; set; }
        /// <summary>
        /// PNR
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// 乘机人名称
        /// </summary>
        public string PsrNames { get; set; }
        /// <summary>
        /// 航空公司代码
        /// </summary>
        public string CarrierCode { get; set; }
        /// <summary>
        /// 航线
        /// </summary>
        public string Airline { get; set; }
        /// <summary>
        /// 起飞日期
        /// </summary>
        public DateTime FltDateTime { get; set; }
        /// <summary>
        /// 出票类型
        /// </summary>
        public string TypeDisplay { get; set; }


    }
}
