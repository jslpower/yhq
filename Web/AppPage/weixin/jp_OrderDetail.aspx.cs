using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_OrderDetail : System.Web.UI.Page
    {
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (userInfo == null) Response.Redirect("/AppPage/weixin/Login.aspx?rurl=/AppPage/weixin/jp_Orders.aspx");
            initOrders();

        }
        /// <summary>
        /// 初始化订单列表
        /// </summary>
        void initOrders()
        {
            var serModel = new Eyousoft_yhq.Model.MJiPiaoBaoCunSer();
            serModel.OpeatorID = userInfo.UserID;
            //获取机票订单的ordercode
            var OrderCode = Request.QueryString["ordercode"];
            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(OrderCode);
            if (model == null) return;
            StringBuilder orderListStr = new StringBuilder();

            string policyXML = new com._8222666.fxb2b.Service().XmlSubmit(
               Utils.getIdentityXMLString()
                , string.Format("<QueryOrder_1_1><OrderNo>{0}</OrderNo></QueryOrder_1_1>", OrderCode)
                , "");

            StringBuilder strLi = new StringBuilder();
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(policyXML);
            if (dom.SelectSingleNode("ErrorInfo_1_0") != null
    && !string.IsNullOrEmpty(dom.SelectSingleNode("ErrorInfo_1_0").InnerText)) Utils.RCWE("请求错误");

            XmlNodeList hangbanXX = dom.SelectSingleNode("QueryOrder_1_1").SelectSingleNode("Flights").SelectNodes("Flight");
            XmlNode codexx = dom.SelectSingleNode("QueryOrder_1_1").SelectSingleNode("OrderInfo");
            string orderPrice = dom.SelectSingleNode("QueryOrder_1_1").SelectSingleNode("PriceInfo").SelectSingleNode("Receivables").InnerText;

            lblOrderPrice.Text = Utils.GetDecimal(orderPrice).ToString("C2");

            lblOrderNO.Text = codexx.SelectSingleNode("SubsOrderNo").InnerText;

            lblCarrName.Text = hangbanXX[0].SelectSingleNode("CarrierName").InnerText;

            lblCarrNo.Text = hangbanXX[0].SelectSingleNode("Carrier").InnerText
                                        + hangbanXX[0].SelectSingleNode("FlightNo").InnerText;

            lblLeaveDate.Text = hangbanXX[0].SelectSingleNode("DepartureDate").InnerText
                                               + " " + hangbanXX[0].SelectSingleNode("DepartureTime").InnerText;

            lblLeavePoint.Text = hangbanXX[0].SelectSingleNode("BoardPointName").InnerText;

            lblArrivDate.Text = hangbanXX[0].SelectSingleNode("ArrivalDate").InnerText
                                          + " " + hangbanXX[0].SelectSingleNode("ArrivalTime").InnerText;

            lblArrivPoint.Text = hangbanXX[0].SelectSingleNode("OffPointName").InnerText;


            XmlNodeList psgers = null;
            if (model.payState == Eyousoft_yhq.Model.TickOrderPayState.已出票
                || model.payState == Eyousoft_yhq.Model.TickOrderPayState.已签收)
            {
                psgers = dom.SelectSingleNode("QueryOrder_1_1").SelectSingleNode("Tickets").SelectNodes("Ticket");
            }
            else
            {
                psgers = dom.SelectSingleNode("QueryOrder_1_1").SelectSingleNode("Passengers").SelectNodes("Passenger");

            }
            StringBuilder strYkStr = new StringBuilder();

            if (psgers != null && psgers.Count > 0)
            {
                for (int i = 0; i < psgers.Count; i++)
                {
                    if (model.payState == Eyousoft_yhq.Model.TickOrderPayState.已出票
                         || model.payState == Eyousoft_yhq.Model.TickOrderPayState.已签收)
                    {
                        strYkStr.AppendFormat("<li class=\"botline\">");
                        strYkStr.AppendFormat("<p>");
                        strYkStr.AppendFormat("姓名：{0}<br />", psgers[i].SelectSingleNode("PsgName").InnerText);
                        strYkStr.AppendFormat("类型：{0}<br />", getYKLX(psgers[i].SelectSingleNode("PsgType").InnerText));
                        strYkStr.AppendFormat("证件号：{0}<br />", psgers[i].SelectSingleNode("CardNo").InnerText);
                        strYkStr.AppendFormat("手机号码：{0}<br />", psgers[i].SelectSingleNode("MobilePhone").InnerText);
                        strYkStr.AppendFormat("票号：{0}<br />", psgers[i].SelectSingleNode("TicketNo").InnerText);
                        strYkStr.AppendFormat("行程单号：{0}", psgers[i].SelectSingleNode("SerialNo").InnerText);
                        strYkStr.AppendFormat("</p>");
                        strYkStr.AppendFormat("</li>");

                    }
                    else
                    {
                        strYkStr.AppendFormat("<li class=\"botline\">");
                        strYkStr.AppendFormat("<p>");
                        strYkStr.AppendFormat("姓名：{0}<br />", psgers[i].SelectSingleNode("Name").InnerText);
                        strYkStr.AppendFormat("类型：{0}<br />", getYKLX(psgers[i].SelectSingleNode("PsgType").InnerText));
                        strYkStr.AppendFormat("证件号：{0}<br />", psgers[i].SelectSingleNode("CardNo").InnerText);
                        strYkStr.AppendFormat("手机号码：{0}<br />", psgers[i].SelectSingleNode("MobilePhone").InnerText);
                        strYkStr.Append("票号：<br />");
                        strYkStr.Append("行程单号：");
                        strYkStr.AppendFormat("</p>");
                        strYkStr.AppendFormat("</li>");
                    }
                }
            }
            litYKs.Text = strYkStr.ToString();//游客信息
            var order = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(OrderCode);
            if (order == null) return;
            lblAddress.Text = order.JpAdress;
            lblPeople.Text = string.Format("{0}({1})", codexx.SelectSingleNode("Linker").InnerText
                                                                            , codexx.SelectSingleNode("Telephone").InnerText);


        }
        /// <summary>
        /// 返回游客身份类别文字说明
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string getYKLX(string code)
        {
            switch (code)
            {
                case "ADT":
                    return "成人";
                case "CHD":
                    return "儿童";
                case "INF":
                    return "婴儿";
                default:
                    break;
            }
            return "";
        }
    }
}
