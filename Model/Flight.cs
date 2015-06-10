using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class Flight
    {

        public string ID { set; get; }//  航段序号
        public string Type { set; get; }// 航段类型
        public string TypeCode { set; get; }//  航信系统航段类型代码

        public string ActionCode { set; get; }//  行动代码(反映航段状态)

        public decimal Farebasis { set; get; }//  运价基础  字符  N/A  N
        public string Carrier { set; get; }//  航空公司代码  字符  2  Y
        public string FlightNo { set; get; }//  航班号  字符  N/A  Y
        public string ShareCarrier { set; get; }//  共享航空公司代码 字符  2  N
        public string ShareFlight { set; get; }//  共享航班号  字符  N/A  N
        public string FromCityc { set; get; }//  离港城市代码  字符  3  Y
        public string ArriveCity { set; get; }//  到港城市代码  字符  3  Y
        public double Mileage { set; get; }//  公里数（决定燃油价，不传


        public string ClassCode { set; get; }//  舱位代码  字符  N/A  Y
        public decimal YPrice { set; get; }//  公布航价格(Y 舱价格)  货币  N/A  Y
        public decimal ClassPrice { set; get; }//  舱位价格 货币  N/A  Y
        public decimal BasePrice { set; get; }//  公布价格(FD 价格)  货币  N/A  N
        public decimal FuelSurTax { set; get; }//  燃油费  货币  N/A  Y
        public decimal AirportTax { set; get; }//  机场建设费  货币  N/A  Y
        public DateTime DepartureDate { set; get; }//  离港日期  日期  N/A Y
        public DateTime DepartureTime { set; get; }//  离港时间  字符  N/A Y
        public DateTime ArrivalDate { set; get; }//  到港日期  日期  N/A Y
        public DateTime ArrivalTime { set; get; }//  到港时间  字符  N/A Y
        public string Aircraft { set; get; }//  机型代码  字符  N/A Y
        public string OverstepPriceReason { set; get; }//  订单原因 ID  字符  N/A  N
        public string BoardPointAT { set; get; }//  出发航站楼  字符  N/A  N
        public string OffPointAT { set; get; }//  到达航站楼  字符  N/A  N
        public decimal MinPrice { set; get; }//

        public List<Passengerr> Passengers { get; set; }

        public List<Price> Prices { get; set; }
        public List<LinkerInfo> LinkerInfos { get; set; }

        public List<InsuranceInfo> InsuranceInfos { get; set; }


    }

    public class Passengerr
    {
        public string PsgID { set; get; }//  旅客序号(婴儿的旅客序号

        public string Name { set; get; }//  旅客姓名 如：中文(张三)  字符  N/A Y

        public string Type { set; get; }//  （不推荐使用的参数，用PsgType 代替）


        public string PsgType { set; get; }//  旅客类型

        public string IdentityType { set; get; }//  证件类型  字符  N/A Y
        public string CardType { set; get; }//  航信系统证件类型 NI 身

        public string CardNo { set; get; }//  证件号  字符  N/A Y
        public DateTime BirthDay { set; get; }//  出生日期(成人没有)  日期  N/A Y
        public string CarrierPsgID { set; get; }//  跟随的成人  字符  N/A N
        public string Country { set; get; }//  国籍  字符  N/A Y
        public string MobilePhone { set; get; }//  移动电话(主要用于发送短

        public int InsueSum { set; get; }//  保险份数(如没有则传值为

        public string CarrierCard { set; get; }//  航空公司里程卡号  字符  N/A N
        public DateTime CardVaildDate { set; get; }//  


    }

    public class Price
    {
        public string PriceID { set; get; }//  政策编号  数字  N/A  Y
        public string TktOffice { set; get; }//  出票 OFFICE  字符  N/A  Y
        public string PsgType { set; get; }//  乘客类型 ADT 成人 INF婴儿 CHD 儿童
        public string PsgID { set; get; }//  乘客序号
        public decimal YPrice { set; get; }//  经济舱价格(Y 舱价格)  货币  N/A  Y
        public decimal Fare { set; get; }//  票面价  货币  N/A  Y
        public decimal TaxAmount { set; get; }//  税款合计  货币  N/A  Y
        public decimal FuelSurTax { set; get; }//  燃油费  货币  N/A  Y
        public decimal AirportTax { set; get; }//  机场建设费  货币  N/A  Y
        public decimal SalePrice { set; get; }//  机场建设费  货币  N/A  Y

    }
    public class LinkerInfo
    {

        public bool IsETiket { set; get; }//  是否电子机票 Y/N  字符  N/A Y
        public string PayType { set; get; }//  支付方式 ZH 帐户 WZ 网支  字符  2 Y
        public string Address { set; get; }//  地址  字符  N/A N
        public string LinkerName { set; get; }//  联系人  字符  N/A Y
        public string Zip { set; get; }//  邮编  字符  N/A Y
        public string Telphone { set; get; }//  电话  字符  N/A Y
        public string MobilePhone { set; get; }//  手机  字符  N/A Y
        public DateTime SendTime { set; get; }//  送票时间  日期  N/A Y
        public bool NeedInvoices { set; get; }//  是否需要发票 Y/N  字符  N/A Y
        public string InvoicesSendType { set; get; }//  发票发送方式 A邮寄 B配送  字符  N/A Y
        public string SendTktsTypeCode { set; get; }//  订单配送方式（By：不配送ZQ:自取 SP:送票 YJ:邮寄

        public bool IsPrintSerial { set; get; }//  是否打印行程单（Y/N）  字符  N/A  N
        public string SendTktDepID { set; get; }//  配送营业点 ID  字符  N/A  N
        public string SendTktDepName { set; get; }//  配送营业点名称  字符  N/A  N
    }


    public class InsuranceInfo
    {
        public string InsuranceId { set; get; }//  保险编号  字符  N/A Y
        public decimal ShouldGath { set; get; }//  应收金额  字符  N/A  Y
        public decimal ShouldPay { set; get; }//  应付金额  字符  N/A  Y
        public decimal RetMoney { set; get; }//  返钱  字符  N/A  Y
        public decimal Gain { set; get; }//  利润  字符  N/A  Y
        public int InsuranceCount { set; get; }//  保险分数  字符  N/A  Y
        public string InsuranceSummary { set; get; }//  保险说明  字符  N/A  Y
    }


}
