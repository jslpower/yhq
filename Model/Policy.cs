using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //PAT报价
    public class Policy
    {
        /// <summary>
        /// 政策ID
        /// </summary>
        public string PriceID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PricePolicyNo { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ProviderCode { get; set; }
        /// <summary>
        /// PNR
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// PNR
        /// </summary>
        public string CrsPnr { get; set; }
        /// <summary>
        /// 航空公司代码
        /// </summary>
        public string Carrier { get; set; }
        /// <summary>
        /// 乘客类型
        /// </summary>
        public string PsgType { get; set; }
        /// <summary>
        /// 离港日期
        /// </summary>
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// 航线
        /// </summary>
        public string Airline { get; set; }
        /// <summary>
        /// 乘客人数
        /// </summary>
        public int PsgCount { get; set; }
        /// <summary>
        /// 航段公布价格
        /// </summary>
        public decimal BasePrice { get; set; }
        /// <summary>
        /// 票面价
        /// </summary>
        public decimal Fare { get; set; }
        /// <summary>
        /// 后返结算价
        /// </summary>
        public decimal Fare2 { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal Rebate { get; set; }
        /// <summary>
        /// 税款合计
        /// </summary>
        public decimal TaxAmount { get; set; }
        /// <summary>
        /// 燃油费
        /// </summary>
        public decimal FuelSurTax { get; set; }
        /// <summary>
        /// 机场建设费
        /// </summary>
        public decimal AirportTax { get; set; }
        /// <summary>
        /// 附加费
        /// </summary>
        public decimal AffixFee { get; set; }
        /// <summary>
        /// 航司先返
        /// </summary>
        public decimal Comm { get; set; }
        /// <summary>
        /// 航司后返
        /// </summary>
        public decimal ZComm { get; set; }
        /// <summary>
        /// 航司返钱
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 客户先返
        /// </summary>
        public string AgentComm { get; set; }
        /// <summary>
        /// 客户后返
        /// </summary>
        public string AgentCommEx { get; set; }
        /// <summary>
        /// 客户返钱
        /// </summary>
        public decimal AgentMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EI { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TC { get; set; }
        /// <summary>
        /// 出票 Office 
        /// </summary>
        public string TicketOffice { get; set; }
        /// <summary>
        /// 适用儿童
        /// </summary>
        public string AllowTkt { get; set; }
        /// <summary>
        /// 出票计算
        /// </summary>
        public string CalcTkt { get; set; }
        /// <summary>
        /// 适用范围
        /// </summary>
        public string UseRange { get; set; }
        /// <summary>
        /// 票证类型
        /// </summary>
        public string TktType { get; set; }
        /// <summary>
        /// 适用类别
        /// </summary>
        public string UseType { get; set; }
        /// <summary>
        /// 出票类别
        /// </summary>
        public string DzType { get; set; }
        /// <summary>
        /// 运价基础
        /// </summary>
        public string FareBase { get; set; }

        /// <summary>
        /// 共享出票地
        /// </summary>
        public string ShareOffice { get; set; }
        /// <summary>
        /// 政策类型
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// 运价指令
        /// </summary>
        public string Pat { get; set; }
        /// <summary>
        /// Rmk
        /// </summary>
        public string Rmk { get; set; }
        /// <summary>
        /// FP
        /// </summary>
        public string FP { get; set; }
        /// <summary>
        /// Ext1
        /// </summary>
        public string Ext1 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 佣金
        /// </summary>
        public decimal TktCustomerGain { get; set; }
        /// <summary>
        /// 后返佣金
        /// </summary>
        public decimal TktCustomerGain2 { get; set; }
        /// <summary>
        /// 供应商结算价
        /// </summary>
        public decimal TktNetPrice { get; set; }
        /// <summary>
        /// 客户结算价
        /// </summary>
        public decimal TktBalanceMoney { get; set; }
        /// <summary>
        /// 平台交易费
        /// </summary>
        public decimal TktBusinessFee { get; set; }
        /// <summary>
        /// 客户利润
        /// </summary>
        public decimal TktAgentGain { get; set; }
        /// <summary>
        /// 客户后返利润
        /// </summary>
        public decimal TktAgentGain2 { get; set; }
        /// <summary>
        /// 支付手续费
        /// </summary>
        public decimal TktPaymentFee { get; set; }
        /// <summary>
        /// 起飞日期
        /// </summary>
        public DateTime FltDatStr { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string ClassCodeStr { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string TktFlightNoStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FltDateStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SAgentComm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CusSalePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PriceDetailID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fp { get; set; }
    }
}
