using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class HBModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 航班编号
        /// </summary>
        public string FlightID { get; set; }
        /// <summary>
        ///序号 
        /// </summary>
        public string ElementNo { get; set; }
        /// <summary>
        /// 承运人代码如：FM
        /// </summary>
        public string Carrier { get; set; }
        /// <summary>
        /// 承运人名称如：上航
        /// </summary>
        public string CarrierName { get; set; }
        /// <summary>
        /// 航班号如：9110
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 共享承运人代码如：FM
        /// </summary>
        public string ShareCarrier { get; set; }
        /// <summary>
        /// 共享承运人名称如：上航
        /// </summary>
        public string ShareCarrierName { get; set; }
        /// <summary>
        /// 共享航班号如：9110
        /// </summary>
        public string ShareFlight { get; set; }
        /// <summary>
        /// 起飞城市代码如：PEK
        /// </summary>
        public string BoardPoint { get; set; }
        /// <summary>
        /// 起飞城市名称如：北京
        /// </summary>
        public string BoardPointName { get; set; }
        /// <summary>
        /// 目的城市代码如：PVG
        /// </summary>
        public string OffPoint { get; set; }
        /// <summary>
        /// 目的城市名称如：上海浦东
        /// </summary>
        public string OffPointName { get; set; }
        /// <summary>
        /// 航班起飞日期如：2009-06-01
        /// </summary>
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// 航班起飞时间如：09:30
        /// </summary>
        public DateTime DepartureTime { get; set; }
        /// <summary>
        /// 航班到达日期如：2009-06-01
        /// </summary>
        public DateTime ArrivalDate { get; set; }
        /// <summary>
        /// 航班到达时间如：09:30
        /// </summary>
        public DateTime ArrivalTime { get; set; }
        /// <summary>
        /// 机型代码如：321
        /// </summary>
        public string Aircraft { get; set; }
        /// <summary>
        /// 机型名称如：A321
        /// </summary>
        public string AircraftName { get; set; }
        /// <summary>
        /// 餐食代码
        /// </summary>
        public string Meal { get; set; }
        /// <summary>
        /// 餐食名称，推荐显示有，无
        /// </summary>
        public string MealName { get; set; }
        /// <summary>
        /// 经停点 (0：无经停，1：一次经停)
        /// </summary>
        public int ViaPort { get; set; }
        /// <summary>
        /// 电子票标识  (E)
        /// </summary>
        public string ETicket { get; set; }
        /// <summary>
        /// 是否允许机上座位预订
        /// </summary>
        public string ASR { get; set; }
        /// <summary>
        /// 连接级别
        /// </summary>
        public string LinkLevel { get; set; }
        /// <summary>
        /// 机建费
        /// </summary>
        public decimal AirportTax { get; set; }
        /// <summary>
        /// 燃油费
        /// </summary>
        public decimal FuelSurTax { get; set; }
        /// <summary>
        /// 里程数 
        /// </summary>
        public int Mileage { get; set; }
        /// <summary>
        /// 航班显示航班描述如：国航
        /// </summary>
        public string Flightx { get; set; }
        /// <summary>
        /// 起飞描述 如：07:20 PEK
        /// </summary>
        public string BoardTimex { get; set; }
        /// <summary>
        /// 到达描述 如：09:30 PVG 
        /// </summary>
        public string OffTimex { get; set; }
        /// <summary>
        /// 起始城市航站楼号 如：北京 T3 
        /// </summary>
        public string BoardPointAT { get; set; }
        /// <summary>
        /// 目的城市航站楼号 如：上海浦东 T2
        /// </summary>
        public string OffPointAT { get; set; }
        /// <summary>
        /// Y 舱价格
        /// </summary>
        public decimal YPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<webFlightInfo> Class { get; set; }

    }
    /// <summary>
    /// 航班价格信息
    /// </summary>
    public class webFlightInfo
    {
        public int Identity { get; set; }
        public string Seat { get; set; }
        public string Code { get; set; }
        public string TradeId { get; set; }
        public int TRID { get; set; }
        public string Type_class { get; set; }
        public decimal F { get; set; }
        public decimal R { get; set; }
        public decimal X { get; set; }
        public decimal A { get; set; }
        public decimal C { get; set; }
        public decimal M { get; set; }
        public decimal S { get; set; }
        public decimal PriceSource { get; set; }
        /// <summary>
        ///子节点名称 用来记录折扣和机舱等级
        /// </summary>
        public string XmlNodeName { get; set; }



    }
}
