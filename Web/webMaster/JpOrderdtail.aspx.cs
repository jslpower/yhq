using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class JpOrderdtail : System.Web.UI.Page
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");

            string id = Utils.GetQueryStringValue("orderid");
            if (dotype == "tuipiao")
            {
                PlaceHolder1.Visible = PlaceHolder2.Visible = true;
            }
            if (Utils.GetQueryStringValue("opt") == "save") BaoCun();
            initPage();

        }


        /// <summary>
        /// 初始化订单列表
        /// </summary>
        void initPage()
        {


            #region 初始化订单状态
            var OrderStateList = EnumObj.GetList(typeof(Eyousoft_yhq.Model.TickOrderPayState)); ;
            ddl_orderState.DataSource = OrderStateList;
            ddl_orderState.DataTextField = "Text";
            ddl_orderState.DataValueField = "Value";
            ddl_orderState.DataBind();
            #endregion


            var serModel = new Eyousoft_yhq.Model.MJiPiaoBaoCunSer();

            //获取机票订单的ordercode
            var OrderCode = Request.QueryString["orderid"];
            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(OrderCode);
            if (model == null) return;
            if (ddl_orderState.Items.FindByValue(((int)model.payState).ToString()) != null)
                ddl_orderState.Items.FindByValue(((int)model.payState).ToString()).Selected = true;
            StringBuilder orderListStr = new StringBuilder();

            string policyXML = new com._8222666.fxb2b.Service().XmlSubmit(
                getIdentityXMLString()
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

            txtOrderNO.Text = codexx.SelectSingleNode("SubsOrderNo").InnerText;

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
                        strYkStr.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>"
                                                                 , psgers[i].SelectSingleNode("PsgName").InnerText
                                                                 , getYKLX(psgers[i].SelectSingleNode("PsgType").InnerText)
                                                                 , psgers[i].SelectSingleNode("CardNo").InnerText
                                                                 , psgers[i].SelectSingleNode("MobilePhone").InnerText
                                                                 , psgers[i].SelectSingleNode("TicketNo").InnerText
                                                                 , psgers[i].SelectSingleNode("SerialNo").InnerText);
                    }
                    else
                    {
                        strYkStr.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td></td><td></td></tr>"
                                                   , psgers[i].SelectSingleNode("Name").InnerText
                                                   , getYKLX(psgers[i].SelectSingleNode("PsgType").InnerText)
                                                   , psgers[i].SelectSingleNode("CardNo").InnerText
                                                   , psgers[i].SelectSingleNode("MobilePhone").InnerText);
                    }
                }
            }
            litYKs.Text = strYkStr.ToString();//游客信息游客信息
            var order = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(OrderCode);
            if (order == null) return;
            lblAddress.Text = order.JpAdress;
            lblPeople.Text = string.Format("{0}({1})", codexx.SelectSingleNode("Linker").InnerText
                                                                            , codexx.SelectSingleNode("Telephone").InnerText);


        }
        /// <summary>
        /// 获取identity字符串
        /// </summary>
        /// <returns></returns>
        // string getIdentityXMLString(string username, string userPwd)
        string getIdentityXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", "18636128850", "123456");

            return sb.ToString();
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
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(Utils.GetQueryStringValue("code"));
            if (model == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "修改失败！"));
            model.payState = (Eyousoft_yhq.Model.TickOrderPayState)Utils.GetInt(Utils.GetFormValue(this.ddl_orderState.UniqueID));
            model.OrderCode = Utils.GetFormValue(this.txtOrderNO.UniqueID);
            bool result = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().setStateAndCodeByOrderID(model);
            if (result)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "修改成功！"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "修改失败！"));
            }
        }

    }
}
