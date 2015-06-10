using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using EyouSoft.Common;
using Eyousoft_yhq.Model;
using System.Collections;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_Submit : System.Web.UI.Page
    {
        protected string ClassCode { get; set; }
        Dictionary<string, object> hats = new Dictionary<string, object>();
        /// <summary>
        /// 机票信息
        /// </summary>
        HBModel queryJpModel = new HBModel();
        List<Eyousoft_yhq.Model.Policy> datalist_Policy = new List<Eyousoft_yhq.Model.Policy>();
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        /// <summary>
        /// 微店编号
        /// </summary>
        protected string WeiDianId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            WeiDianId = Utils.GetWeiDianId();
            string[] strNames = Utils.GetFormValues("ckName");

            if (userInfo == null) Response.Redirect("/AppPage/weixin/Login.aspx?rurl=/AppPage/weixin/jp_Search.aspx");
            if (Utils.GetQueryStringValue("next") == "1") setMoney();

            if (Utils.GetQueryStringValue("save") == "save") SaveOrder();
            initPage();

        }
        /// <summary>
        /// 初始化机舱信息
        /// </summary>
        void initPage()
        {
            ///PAT-XML
            StringBuilder querypolicyXML = new StringBuilder();
            //接收航班查询的结果信息
            string questXML = Utils.GetFormValue("HBbox");
            int questInt = Utils.GetInt(Utils.GetFormValue("JCbox"));

            queryJpModel = (HBModel)Newtonsoft.Json.JsonConvert.DeserializeObject(questXML, typeof(HBModel));

            if (queryJpModel != null)
            {
                Session["HBModel"] = queryJpModel;

            }

            if (queryJpModel != null && queryJpModel.Class != null && queryJpModel.Class.Count > 0)
            {
                for (int i = 0; i < queryJpModel.Class.Count; i++)
                {
                    if (queryJpModel.Class[i].Identity == questInt)
                    {
                        #region PAT价格信息
                        querypolicyXML.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                        querypolicyXML.Append("<QueryPolicy_2_0>");

                        querypolicyXML.Append("<Flights>");
                        querypolicyXML.Append("<Flight>");
                        querypolicyXML.AppendFormat("<BoardPoint>{0}</BoardPoint>", queryJpModel.BoardPoint);
                        querypolicyXML.AppendFormat("<OffPoint>{0}</OffPoint>", queryJpModel.OffPoint);
                        querypolicyXML.AppendFormat("<Carrier>{0}</Carrier>", queryJpModel.Carrier);
                        querypolicyXML.AppendFormat("<FlightNo>{0}</FlightNo>", queryJpModel.FlightNo);
                        querypolicyXML.AppendFormat("<ShareCarrier>{0}</ShareCarrier>", queryJpModel.ShareCarrier); ;
                        querypolicyXML.AppendFormat("<ShareFlight>{0}</ShareFlight>", queryJpModel.ShareFlight);
                        querypolicyXML.AppendFormat("<DepartureDate>{0}</DepartureDate>", queryJpModel.DepartureDate);
                        querypolicyXML.AppendFormat("<DepartureTime>{0}</DepartureTime>", queryJpModel.DepartureTime.ToString("HH:mm"));
                        querypolicyXML.AppendFormat("<ClassCode>{0}</ClassCode>", queryJpModel.Class[i].Code);
                        querypolicyXML.Append("</Flight>");
                        querypolicyXML.Append("</Flights>");

                        querypolicyXML.Append("<Price>");
                        querypolicyXML.AppendFormat("<Fare>{0}</Fare>", queryJpModel.Class[i].F);
                        querypolicyXML.AppendFormat("<Tax>{0}</Tax>", queryJpModel.AirportTax + queryJpModel.FuelSurTax);
                        querypolicyXML.AppendFormat("<FuelSurTax>{0}</FuelSurTax>", queryJpModel.FuelSurTax);
                        querypolicyXML.AppendFormat("<AirportTax>{0}</AirportTax>", queryJpModel.AirportTax);
                        querypolicyXML.AppendFormat("<Rebate>{0}</Rebate>", queryJpModel.Class[i].R);
                        querypolicyXML.AppendFormat("<Pat>{0}</Pat>", true);
                        querypolicyXML.Append("</Price>");

                        querypolicyXML.Append("</QueryPolicy_2_0>");
                        string policyXML = new com._8222666.fxb2b.Service().XmlSubmit(getIdentityXMLString(), querypolicyXML.ToString(), "");

                        #endregion

                        #region  获取PAT后的价格信息

                        XmlDocument dom = new XmlDocument();
                        dom.LoadXml(policyXML);
                        if (dom.SelectSingleNode("ErrorInfo_1_0") != null && !string.IsNullOrEmpty(dom.SelectSingleNode("ErrorInfo_1_0").InnerText))
                        {
                            mainbox.InnerHtml = "<center><a href=\"javascript:window.history.go(-1);\"  >未校验到最新价格，请返回选择其他舱位</a></center>";
                            return;
                        }
                        XmlNodeList nodes = dom.SelectSingleNode("QueryPolicy_2_0").SelectSingleNode("PriceDetails").SelectNodes("PriceDetail");



                        for (int j = 0; j < nodes.Count; j++)
                        {

                            var model = new Eyousoft_yhq.Model.Policy();

                            model.PriceID = nodes[j].SelectSingleNode("PriceID").InnerText;
                            model.PricePolicyNo = nodes[j].SelectSingleNode("PricePolicyNo").InnerText;
                            model.PriceDetailID = nodes[j].SelectSingleNode("PriceDetailID").InnerText;
                            model.ProviderCode = nodes[j].SelectSingleNode("ProviderCode").InnerText;
                            model.PNR = nodes[j].SelectSingleNode("PNR").InnerText;
                            model.CrsPnr = nodes[j].SelectSingleNode("CrsPnr").InnerText;
                            model.Carrier = nodes[j].SelectSingleNode("Carrier").InnerText;
                            model.PsgType = nodes[j].SelectSingleNode("PsgType").InnerText;
                            model.DepartureDate = Utils.GetDateTime(nodes[j].SelectSingleNode("DepartureDate").InnerText);
                            model.Airline = nodes[j].SelectSingleNode("Airline").InnerText;
                            model.PsgCount = Utils.GetInt(nodes[j].SelectSingleNode("PsgCount").InnerText);
                            model.BasePrice = Utils.GetDecimal(nodes[j].SelectSingleNode("BasePrice").InnerText);
                            model.Fare = Utils.GetDecimal(nodes[j].SelectSingleNode("Fare").InnerText);
                            model.Fare2 = Utils.GetDecimal(nodes[j].SelectSingleNode("Fare2").InnerText);
                            model.SalePrice = Utils.GetDecimal(nodes[j].SelectSingleNode("SalePrice").InnerText);
                            model.CusSalePrice = Utils.GetDecimal(nodes[j].SelectSingleNode("CusSalePrice").InnerText);
                            model.Rebate = Utils.GetDecimal(nodes[j].SelectSingleNode("Rebate").InnerText);
                            model.TaxAmount = Utils.GetDecimal(nodes[j].SelectSingleNode("TaxAmount").InnerText);
                            model.FuelSurTax = Utils.GetDecimal(nodes[j].SelectSingleNode("FuelSurTax").InnerText);
                            model.AirportTax = Utils.GetDecimal(nodes[j].SelectSingleNode("AirportTax").InnerText);
                            model.AffixFee = Utils.GetDecimal(nodes[j].SelectSingleNode("AffixFee").InnerText);
                            model.Comm = Utils.GetDecimal(nodes[j].SelectSingleNode("Comm").InnerText);
                            model.ZComm = Utils.GetDecimal(nodes[j].SelectSingleNode("ZComm").InnerText);
                            model.Money = Utils.GetDecimal(nodes[j].SelectSingleNode("Money").InnerText);
                            model.AgentComm = nodes[j].SelectSingleNode("AgentComm").InnerText;
                            model.AgentCommEx = nodes[j].SelectSingleNode("AgentCommEx").InnerText;
                            model.AgentMoney = Utils.GetDecimal(nodes[j].SelectSingleNode("AgentMoney").InnerText);
                            model.SAgentComm = nodes[j].SelectSingleNode("SAgentComm").InnerText;
                            model.EI = nodes[j].SelectSingleNode("EI").InnerText;
                            model.TC = nodes[j].SelectSingleNode("TC").InnerText;
                            model.TicketOffice = nodes[j].SelectSingleNode("TicketOffice").InnerText;
                            model.Remark = nodes[j].SelectSingleNode("Remark").InnerText;
                            model.AllowTkt = nodes[j].SelectSingleNode("AllowTkt").InnerText;
                            model.CalcTkt = nodes[j].SelectSingleNode("CalcTkt").InnerText;
                            model.UseRange = nodes[j].SelectSingleNode("UseRange").InnerText;
                            model.TktType = nodes[j].SelectSingleNode("TktType").InnerText;
                            model.UseType = nodes[j].SelectSingleNode("UseType").InnerText;
                            model.DzType = nodes[j].SelectSingleNode("DzType").InnerText;
                            model.FareBase = nodes[j].SelectSingleNode("FareBase").InnerText;
                            model.ShareOffice = nodes[j].SelectSingleNode("ShareOffice").InnerText;
                            model.BaseType = nodes[j].SelectSingleNode("BaseType").InnerText;
                            model.Pat = nodes[j].SelectSingleNode("Pat").InnerText;
                            model.Rmk = nodes[j].SelectSingleNode("Rmk").InnerText;
                            model.Fp = nodes[j].SelectSingleNode("Fp").InnerText;
                            model.Ext1 = nodes[j].SelectSingleNode("Ext1").InnerText;
                            model.TktCustomerGain = Utils.GetDecimal(nodes[j].SelectSingleNode("TktCustomerGain").InnerText);
                            model.TktCustomerGain2 = Utils.GetDecimal(nodes[j].SelectSingleNode("TktCustomerGain2").InnerText);
                            model.TktNetPrice = Utils.GetDecimal(nodes[j].SelectSingleNode("TktNetPrice").InnerText);
                            model.TktBalanceMoney = Utils.GetDecimal(nodes[j].SelectSingleNode("TktBalanceMoney").InnerText);
                            model.TktBusinessFee = Utils.GetDecimal(nodes[j].SelectSingleNode("TktBusinessFee").InnerText);
                            model.TktAgentGain = Utils.GetDecimal(nodes[j].SelectSingleNode("TktAgentGain").InnerText);
                            model.TktAgentGain2 = Utils.GetDecimal(nodes[j].SelectSingleNode("TktAgentGain2").InnerText);
                            model.TktPaymentFee = Utils.GetDecimal(nodes[j].SelectSingleNode("TktPaymentFee").InnerText);
                            model.FltDateStr = nodes[j].SelectSingleNode("FltDateStr").InnerText;
                            model.ClassCodeStr = nodes[j].SelectSingleNode("ClassCodeStr").InnerText;
                            model.TktFlightNoStr = nodes[j].SelectSingleNode("TktFlightNoStr").InnerText;

                            datalist_Policy.Add(model);
                            hats.Add(model.PsgType, model.Fare);
                            if (nodes[j].SelectSingleNode("PsgType").InnerText == "ADT")
                            {
                                this.ADT.Value = (Utils.GetDecimal(nodes[j].SelectSingleNode("Fare").InnerText) + Utils.GetDecimal(nodes[j].SelectSingleNode("FuelSurTax").InnerText) + Utils.GetDecimal(nodes[j].SelectSingleNode("AirportTax").InnerText)).ToString();
                            }
                            else if (nodes[j].SelectSingleNode("PsgType").InnerText == "CHD")
                            {
                                this.CHD.Value = (Utils.GetDecimal(nodes[j].SelectSingleNode("Fare").InnerText) + Utils.GetDecimal(nodes[j].SelectSingleNode("FuelSurTax").InnerText) + Utils.GetDecimal(nodes[j].SelectSingleNode("AirportTax").InnerText)).ToString();
                            }
                            else
                            {
                                this.INF.Value = (Utils.GetDecimal(nodes[j].SelectSingleNode("Fare").InnerText) + Utils.GetDecimal(nodes[j].SelectSingleNode("FuelSurTax").InnerText) + Utils.GetDecimal(nodes[j].SelectSingleNode("AirportTax").InnerText)).ToString();

                            }

                        }
                        hats.Add("FuelSurTax", Utils.GetDecimal(nodes[0].SelectSingleNode("FuelSurTax").InnerText));
                        hats.Add("AirportTax", Utils.GetDecimal(nodes[0].SelectSingleNode("AirportTax").InnerText));
                        hats.Add("TaxAmount", Utils.GetDecimal(nodes[0].SelectSingleNode("TaxAmount").InnerText));
                        hats.Add("SalePrice", Utils.GetDecimal(nodes[0].SelectSingleNode("SalePrice").InnerText));
                        ViewState["hats"] = hats;
                        #endregion



                        lbleDate.Text = string.Format("{0}{1}", queryJpModel.DepartureDate.ToString("MM-dd")
                              , Utils.ConvertWeekDayToChinese(queryJpModel.DepartureDate));
                        lbleTime.Text = queryJpModel.DepartureTime.ToString("HH:mm");

                        lblsDate.Text = string.Format("{0}{1}", queryJpModel.ArrivalDate.ToString("MM-dd")
                             , Utils.ConvertWeekDayToChinese(queryJpModel.ArrivalDate));
                        lblsTime.Text = queryJpModel.ArrivalTime.ToString("HH:mm");

                        lblHkNameCode.Text = string.Format("{0}{1}", queryJpModel.CarrierName, queryJpModel.FlightNo);
                        lblMoneyInfo.Text = string.Format(" {0}：<span id=\"sprice\" class=\"price\"><dfn>¥</dfn>{1}</span>机/油：<span id=\"jprice\" class=\"price\"><dfn>¥</dfn>{2}</span>总计：<span id=\"tprice\" class=\"price\"><dfn>¥</dfn>{3}</span> ", getCM(queryJpModel.Carrier, datalist_Policy[0].ClassCodeStr)
                              , datalist_Policy[0].Fare.ToString("F0")
                              , (datalist_Policy[0].AirportTax + datalist_Policy[0].FuelSurTax).ToString("F0")
                              , (datalist_Policy[0].Fare + datalist_Policy[0].AirportTax + datalist_Policy[0].FuelSurTax).ToString("F0"));
                        this.ClassCode = queryJpModel.Class[i].Code;



                        break;
                    }
                }
            }

        }

        /// <summary>
        /// 订单保存
        /// </summary>
        void SaveOrder()
        {

            string[] insArr = new string[] { };//提交订单成功后需要提交的保险XML

            queryJpModel = Session["HBModel"] != null ? (HBModel)Session["HBModel"] : queryJpModel;
            StringBuilder orderXML = new StringBuilder();
            decimal cPrice = Utils.GetDecimal(Utils.GetFormValue("pPrice"));
            string classcode = Utils.GetFormValue("classcode");
            decimal Jpmoney = Convert.ToDecimal( Utils.GetQueryStringValue("jpmoney"));
            orderXML.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            orderXML.Append("<OrderFlight_1_6>");
            orderXML.Append("<Flights><Flight>");


            orderXML.AppendFormat("<ID>{0}</ID>", "");
            orderXML.AppendFormat("<Type>{0}</Type>", "");
            orderXML.AppendFormat("<TypeCode>{0}</TypeCode>", "");

            orderXML.AppendFormat("<ActionCode>{0}</ActionCode>", "");
            orderXML.AppendFormat("<Farebasis>{0}</Farebasis>", "");
            orderXML.AppendFormat("<Carrier>{0}</Carrier>", queryJpModel.Carrier);
            orderXML.AppendFormat("<FlightNo>{0}</FlightNo>", queryJpModel.FlightNo);
            orderXML.AppendFormat("<ShareCarrier>{0}</ShareCarrier>", "");
            orderXML.AppendFormat("<ShareFlight>{0}</ShareFlight>", "");
            orderXML.AppendFormat("<FromCity>{0}</FromCity>", queryJpModel.BoardPoint);
            orderXML.AppendFormat("<ArriveCity>{0}</ArriveCity>", queryJpModel.OffPoint);
            //orderXML.AppendFormat("<Mileage>{0}</Mileage>", 1178);//测试定义
            orderXML.AppendFormat("<Mileage>{0}</Mileage>", queryJpModel.Mileage);
            //orderXML.AppendFormat("<ClassCode>{0}</ClassCode>", "Y");//测试定义
            orderXML.AppendFormat("<ClassCode>{0}</ClassCode>", classcode);
            orderXML.AppendFormat("<YPrice>{0}</YPrice>", queryJpModel.YPrice);
            //orderXML.AppendFormat("<ClassPrice>{0}</ClassPrice>", 1130);//测试定义
            orderXML.AppendFormat("<ClassPrice>{0}</ClassPrice>", cPrice);
            orderXML.AppendFormat("<BasePrice>{0}</BasePrice>", "");
            orderXML.AppendFormat("<FuelSurTax>{0}</FuelSurTax>", queryJpModel.FuelSurTax);
            orderXML.AppendFormat("<AirportTax>{0}</AirportTax>", queryJpModel.AirportTax);
            orderXML.AppendFormat("<DepartureDate>{0}</DepartureDate>", queryJpModel.DepartureDate.ToString("yyyy-MM-dd"));
            orderXML.AppendFormat("<DepartureTime>{0}</DepartureTime>", queryJpModel.DepartureTime.ToString("HH:mm"));
            orderXML.AppendFormat("<ArrivalDate>{0}</ArrivalDate>", queryJpModel.ArrivalDate.ToString("yyyy-MM-dd"));
            orderXML.AppendFormat("<ArrivalTime>{0}</ArrivalTime>", queryJpModel.ArrivalTime.ToString("HH:mm"));
            orderXML.AppendFormat("<Aircraft>{0}</Aircraft>", queryJpModel.Aircraft);
            orderXML.AppendFormat("<OverstepPriceReason>{0}</OverstepPriceReason>", "");
            orderXML.AppendFormat("<BoardPointAT>{0}</BoardPointAT>", "");
            orderXML.AppendFormat("<OffPointAT>{0}</OffPointAT>", "");
            orderXML.AppendFormat("<MinPrice>{0}</MinPrice>", "");
            orderXML.Append("</Flight>");
            orderXML.Append("</Flights>");

            //获取订单信息
            string[] strNames = Utils.GetFormValues("ckName");
            string[] strYKLXs = Utils.GetFormValues("ckYKLX");
            string[] strZJLXs = Utils.GetFormValues("ckZJLX");
            string[] strCards = Utils.GetFormValues("ckCard");
            string[] strMobiles = Utils.GetFormValues("ckMobile");
            string[] strBaoXians = Utils.GetFormValues("ckBaoXian");
            string jpAdress = Utils.GetFormValue("jpadress");

            #region 游客信息拼接
            if (strNames != null && strNames.Length > 0)
            {

                orderXML.Append("<Passengers>");
                for (int i = 0; i < strNames.Length; i++)
                {
                    orderXML.Append("<Passenger>");
                    orderXML.AppendFormat("<PsgID>{0}</PsgID>", i + 1);
                    orderXML.AppendFormat("<Name>{0}</Name>", strNames[i]);
                    //orderXML.AppendFormat("<Type>{0}</Type>", 0);
                    orderXML.AppendFormat("<PsgType>{0}</PsgType>", strYKLXs[i]);
                    orderXML.AppendFormat("<IdentityType>{0}</IdentityType>", strZJLXs[i]);
                    orderXML.AppendFormat("<CardType>{0}</CardType>", strZJLXs[i]);
                    orderXML.AppendFormat("<CardNo>{0}</CardNo>", strCards[i]);
                    if (strYKLXs[i] == "ADT")
                    {
                        orderXML.AppendFormat("<BirthDay>{0}</BirthDay>", "2001-10-10");
                    }
                    else if (strYKLXs[i] == "CHD")
                    {
                        orderXML.AppendFormat("<BirthDay>{0}</BirthDay>", "2003-10-10");
                    }
                    else
                    {
                        orderXML.AppendFormat("<BirthDay>{0}</BirthDay>", "2013-10-10");
                    }

                    orderXML.AppendFormat("<CarrierPsgID>{0}</CarrierPsgID>", "");
                    orderXML.AppendFormat("<Country>{0}</Country>", "中国");
                    orderXML.AppendFormat("<MobilePhone>{0}</MobilePhone>", strMobiles[i]);
                    if (strBaoXians.Length <= 0)
                    {
                        orderXML.AppendFormat("<InsueSum>{0}</InsueSum>", 0);
                    }
                    else
                    {
                        //orderXML.AppendFormat("<InsueSum>{0}</InsueSum>", Utils.GetInt(strBaoXians[i]));
                        orderXML.AppendFormat("<InsueSum>{0}</InsueSum>", 1);
                    }

                    orderXML.AppendFormat("<CarrierCard>{0}</CarrierCard>", "");
                    orderXML.AppendFormat("<CardVaildDate>{0}</CardVaildDate>", "");
                    orderXML.Append("</Passenger>");

                }
                orderXML.Append("</Passengers>");



            }
            #endregion

            #region 价格信息拼接
            var hats = ViewState["hats"] as Dictionary<string, object>;
            List<string> test = new List<string>(hats.Keys);
            if (strNames != null && strNames.Length > 0)
            {
                orderXML.Append("<Prices>");
                for (int i = 0; i < strNames.Length; i++)
                {
                    orderXML.Append("<Price>");
                    orderXML.AppendFormat("<PriceID>{0}</PriceID>", i + 1);
                    orderXML.AppendFormat("<TktOffice>{0}</TktOffice>", "TYN202");
                    orderXML.AppendFormat("<PsgType>{0}</PsgType>", test[i].ToString());
                    orderXML.AppendFormat("<PsgID>{0}</PsgID>", "");
                    orderXML.AppendFormat("<YPrice>{0}</YPrice>", queryJpModel.YPrice);
                    orderXML.AppendFormat("<Fare>{0}</Fare>", hats[test[i]]);
                    orderXML.AppendFormat("<TaxAmount>{0}</TaxAmount>", hats["TaxAmount"]);
                    orderXML.AppendFormat("<FuelSurTax>{0}</FuelSurTax>", hats["FuelSurTax"]);
                    orderXML.AppendFormat("<AirportTax>{0}</AirportTax>", hats["AirportTax"]);
                    orderXML.AppendFormat("<SalePrice>{0}</SalePrice>", hats["SalePrice"]);
                    orderXML.Append("</Price>");
                }
                orderXML.Append("</Prices>");

            }
            #endregion

            orderXML.Append("<OrderInfo>");//订单描述
            orderXML.AppendFormat("<Linker>{0}</Linker>", userInfo.ContactName);
            orderXML.AppendFormat("<Address>{0}</Address>", jpAdress);
            orderXML.AppendFormat("<Telephone>{0}</Telephone>", userInfo.UserName);
            orderXML.AppendFormat("<IsDomc>{0}</IsDomc>", "D");
            orderXML.AppendFormat("<TicketLimitDate>{0}</TicketLimitDate>", DateTime.Now.AddDays(5).ToString("yyyy-MM-dd"));
            orderXML.AppendFormat("<TicketLimitTime>{0}</TicketLimitTime>", DateTime.Now.AddDays(5).ToString("HH:mm"));
            orderXML.AppendFormat("<PayPlatform>{0}</PayPlatform>", 0);
            orderXML.AppendFormat("<BankCode>{0}</BankCode>", 0);
            orderXML.AppendFormat("<NotifyURL>{0}</NotifyURL>", 0);
            orderXML.AppendFormat("<NotifyType>{0}</NotifyType>", 0);
            orderXML.AppendFormat("<Remark>{0}</Remark>", "惠旅游微信端");
            orderXML.AppendFormat("<BalanceMoney>{0}</BalanceMoney>", 1000);
            orderXML.AppendFormat("<TripDays>{0}</TripDays>", 0);
            orderXML.AppendFormat("<CustomerOrderNo>{0}</CustomerOrderNo>", 0);
            orderXML.AppendFormat("<CustomerSettlementDepID>{0}</CustomerSettlementDepID>", 0);
            orderXML.AppendFormat("<CustomerNo>{0}</CustomerNo>", "");
            orderXML.Append("</OrderInfo>");

            orderXML.Append("<LinkerInfo>");//联系信息
            orderXML.AppendFormat("<IsETiket>{0}</IsETiket>", "Y");
            orderXML.AppendFormat("<PayType>{0}</PayType>", "WZ");
            orderXML.AppendFormat("<Address>{0}</Address>", 0);
            orderXML.AppendFormat("<LinkerName>{0}</LinkerName>", userInfo.ContactName);
            orderXML.AppendFormat("<Zip>{0}</Zip>", "410000");
            orderXML.AppendFormat("<Telphone>{0}</Telphone>", userInfo.UserName);
            orderXML.AppendFormat("<MobilePhone>{0}</MobilePhone>", userInfo.UserName);
            orderXML.AppendFormat("<SendTime>{0}</SendTime>", DateTime.Now.AddDays(10));
            orderXML.AppendFormat("<NeedInvoices>{0}</NeedInvoices>", "Y");
            orderXML.AppendFormat("<InvoicesSendType>{0}</InvoicesSendType>", "A");
            orderXML.AppendFormat("<SendTktsTypeCode>{0}</SendTktsTypeCode>", "ZQ");
            orderXML.AppendFormat("<IsPrintSerial>{0}</IsPrintSerial>", "");
            orderXML.AppendFormat("<SendTktDepID>{0}</SendTktDepID>", "");
            orderXML.AppendFormat("<SendTktDepName>{0}</SendTktDepName>", "");
            orderXML.AppendFormat("<LinkerEmail>{0}</LinkerEmail>", "601634540@qq.com");

            orderXML.Append("</LinkerInfo>");

            orderXML.Append("<InsuranceInfo>");//保险信息
            orderXML.AppendFormat("<InsuranceId>{0}</InsuranceId>", "CESHI");
            orderXML.AppendFormat("<ShouldGath>{0}</ShouldGath>", 100);
            orderXML.AppendFormat("<ShouldPay>{0}</ShouldPay>", 10);
            orderXML.AppendFormat("<RetMoney>{0}</RetMoney>", 10);
            orderXML.AppendFormat("<Gain>{0}</Gain>", 10);
            orderXML.AppendFormat("<InsuranceCount>{0}</InsuranceCount>", 10);
            orderXML.AppendFormat("<InsuranceSummary>{0}</InsuranceSummary>", 10);
            orderXML.Append("</InsuranceInfo>");


            orderXML.Append("</OrderFlight_1_6>");

            var list = new com._8222666.fxb2b.Service().XmlSubmit(getIdentityXMLString(), orderXML.ToString(), "");

            XmlDocument dom = new XmlDocument();
            dom.LoadXml(list);
            if (dom.SelectSingleNode("ErrorInfo_1_0") != null && !string.IsNullOrEmpty(dom.SelectSingleNode("ErrorInfo_1_0").InnerText))
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "下单失败"));
                return;
            }


            Eyousoft_yhq.BLL.BJiPiaoBaoCun BaoSevice = new Eyousoft_yhq.BLL.BJiPiaoBaoCun();
            XmlNodeList nodes = dom.SelectNodes("OrderFlight_1_6");

            for (int i = 0; i < nodes.Count; i++)
            {
                MJiPiaoBaoCun jOrder = new MJiPiaoBaoCun();
                jOrder.OpeatorName = userInfo.ContactName;
                jOrder.OpeatorID = userInfo.UserID;
                jOrder.OrderCode = nodes[i].SelectSingleNode("SubsOrderNo").InnerText;
                jOrder.ModifyTag = nodes[i].SelectSingleNode("ModifyTag").InnerText;
                DateTime Jtime;
                bool bt = DateTime.TryParse(nodes[i].SelectSingleNode("TicketLimitDt").InnerText + " " + nodes[i].SelectSingleNode("TicketLimitDt").InnerText, out Jtime);
                jOrder.IssueTime = bt ? Jtime : DateTime.Now;
                jOrder.JpAdress = jpAdress;
                //jOrder.OrderPrice = Convert.ToDecimal(nodes[i].SelectSingleNode("BalanceMoney").InnerText);
                jOrder.OrderPrice = Jpmoney;
                jOrder.WeiDianId = WeiDianId;
                // jOrder.ModifyTag=
                if (BaoSevice.Add(jOrder))
                {
                    //保存订单联系人信息
                    List<OrderPassenger> plist = new List<OrderPassenger>();
                    Eyousoft_yhq.BLL.Bpersner bll = new Eyousoft_yhq.BLL.Bpersner();

                    if (strNames != null && strNames.Length > 0)
                    {
                        //string ordercode = nodes[j].SelectSingleNode("SubsOrderNo").InnerText;
                        try
                        {
                            for (int j = 0; j < strNames.Length; j++)
                            {
                                //FormValues("ckName");
                                //string[] strYKLXs = Utils.GetFormValues("ckYKLX");
                                //string[] strZJLXs = Utils.GetFormValues("ckZJLX");
                                //string[] strCards = Utils.GetFormValues("ckCard");
                                //string[] strMobiles = Utils.GetFormValues("ckMobile");
                                //string[] strBaoXians = Utils.GetFormValues("ckBaoXian");

                                var pasner = new OrderPassenger();
                                pasner.PsrName = strNames[j];
                                pasner.IdentityType = (Eyousoft_yhq.Model.CartType)getXBySF(strZJLXs[j]);
                                pasner.IdentityCard = strCards[j];
                                pasner.PsrType = (Eyousoft_yhq.Model.PerType)getXBySF(strYKLXs[j]);
                                pasner.Mobile = strMobiles[j];
                                pasner.OrderCode = nodes[i].SelectSingleNode("SubsOrderNo").InnerText;
                                bll.Add(pasner);

                            }
                        }
                        catch (Exception)
                        {


                        }




                    }


                    Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "下单成功"));

                }
                else
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "下单失败"));

                }

            }
        }
        /// <summary>
        /// 计算总价
        /// </summary>
        void setMoney()
        {

            Utils.RCWE("0");
        }


        #region 私有方法
        /// <summary>
        /// 获取identity字符串
        /// </summary>
        /// <returns></returns>

        string getIdentityXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", "18636128850", "123456");

            return sb.ToString();
        }

        //获取机舱码
        string getCM(string carrie, string code)
        {

            if (Session["codes"] != null)
            {
                Hashtable HashCodes = Session["codes"] as Hashtable;
                return HashCodes[carrie + code].ToString();
            }
            else
            {
                return "";
            }

        }



        /// <summary>
        /// 根据身份返回pat价格下标
        /// </summary>
        /// <param name="sf"></param>
        /// <returns></returns>
        int getXBySF(string sf)
        {
            switch (sf)
            {
                case "ADT":
                    return 0;
                case "INF":
                    return 1;
                case "CHD":
                    return 2;
                case "NI":
                    return 0;
                case "FOID":
                    return 1;
                case "ID":
                    return 2;

                default:
                    break;
            }
            return 0;
        }
        #endregion



    }
}
