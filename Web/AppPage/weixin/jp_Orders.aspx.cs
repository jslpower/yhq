using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;
using Eyousoft_yhq.Model;
using System.Xml;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_Orders : System.Web.UI.Page
    {
        protected string style1, style2;
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Utils.GetQueryStringValue("zf") == "1") setZF();
            if (userInfo == null) Response.Redirect("/AppPage/weixin/Login.aspx?rurl=/AppPage/weixin/jp_Orders.aspx");
            initCSS();
            initOrders();

        }
        /// <summary>
        /// 初始化订单列表
        /// </summary>
        void initOrders()
        {
            TickOrderPayState zfzt = TickOrderPayState.未支付;
            var serModel = new Eyousoft_yhq.Model.MJiPiaoBaoCunSer();
            serModel.OpeatorID = userInfo.UserID;
            serModel.payState = TickOrderPayState.未支付;
            if (Utils.GetQueryStringValue("Pay") == "1")
            {
                serModel.payState = TickOrderPayState.已支付;
                zfzt = TickOrderPayState.已支付;
            }
            var list = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetList(serModel);
            if (list == null || list.Count <= 0) return;
            StringBuilder orderListStr = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {

                string policyXML = new com._8222666.fxb2b.Service().XmlSubmit(
                    getIdentityXMLString()
                    , string.Format("<QuerySubsOrder_1_3><SubsOrderNo>{0}</SubsOrderNo></QuerySubsOrder_1_3>", list[i].OrderCode)
                    , "");
                orderListStr.Append(getOrderStr(policyXML, zfzt, list[i].OrderID, list[i].OrderCode, list[i].payState.ToString()));
            }
            if (zfzt == TickOrderPayState.未支付)
            {
                litNoPay.Text = orderListStr.ToString();
            }
            else
            {
                litPay.Text = orderListStr.ToString();
            }

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
        /// 返回html
        /// </summary>
        /// <param name="strXml"></param>
        /// <param name="bs">0,未支付，1,已支付</param>
        /// <returns></returns>
        string getOrderStr(string strXml, TickOrderPayState zt, string orderID, string ordercode, string paystate)
        {
            StringBuilder strLi = new StringBuilder();
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(strXml);

            if (dom.SelectSingleNode("ErrorInfo_1_0") != null
             && !string.IsNullOrEmpty(dom.SelectSingleNode("ErrorInfo_1_0").InnerText)) return string.Empty;
            XmlNodeList hangbanXX = dom.SelectSingleNode("QuerySubsOrder_1_3").SelectSingleNode("Flights").SelectNodes("Flight");
            for (int i = 0; i < hangbanXX.Count; i++)
            {

                string orderPrice = dom.SelectSingleNode("QuerySubsOrder_1_3").SelectSingleNode("PriceInfo").SelectSingleNode("Receivables").InnerText;
                if (zt == TickOrderPayState.未支付)
                {
                    strLi.AppendFormat("<li class=\"paypre\"><div class=\"dindan_R\"><p><span class=\"price\"><dfn>¥</dfn>{0}</span></p><p><a href=\"javascript:;\" class=\"fukuan_btn a_pay\" data-id=\"{8}\" data-money={0}  >付款</a></p></div><div class=\"dindan_L\"><p>{1}{2}{3} {4} {5}</p><p class=\"font_gray\">{6}-{7}</p></div><div class=\"load\"><a href=\"/AppPage/weixin/jp_OrderDetail.aspx?ordercode={9}\" style=\"margin-right:20px;\">[订单详情]</a></div></li>"
                           , Utils.GetDecimal(orderPrice).ToString("F0")
                           , hangbanXX[i].SelectSingleNode("CarrierName").InnerText
                           , hangbanXX[i].SelectSingleNode("Carrier").InnerText
                           , hangbanXX[i].SelectSingleNode("FlightNo").InnerText
                           , hangbanXX[i].SelectSingleNode("DepartureDate").InnerText
                           , Utils.ConvertWeekDayToChinese(Utils.GetDateTime(hangbanXX[i].SelectSingleNode("DepartureDate").InnerText))
                           , hangbanXX[i].SelectSingleNode("BoardPointName").InnerText
                           , hangbanXX[i].SelectSingleNode("OffPointName").InnerText
                           , orderID
                           , ordercode);
                }
                else
                {
                    strLi.AppendFormat("<li class=\"payd\"><div class=\"dindan_R\"><p><span class=\"price\"><dfn>¥</dfn>{0}</span></p><p class=\"font_green\">{9}</p></div><div class=\"dindan_L\"><p>{1}{2}{3} {4} {5}</p><p class=\"font_gray\">{6}-{7}</p></div><div class=\"load\"><a href=\"/AppPage/weixin/jp_OrderDetail.aspx?ordercode={8}\" style=\"margin-right:20px;\">[订单详情]</a><a  href=\"/AppPage/weixin/jp_WxQRCODE.aspx?code={8}\">[查看二维码]</a></div></li>"
                           , Utils.GetDecimal(orderPrice).ToString("F0")
                           , hangbanXX[i].SelectSingleNode("CarrierName").InnerText
                           , hangbanXX[i].SelectSingleNode("Carrier").InnerText
                           , hangbanXX[i].SelectSingleNode("FlightNo").InnerText
                           , hangbanXX[i].SelectSingleNode("DepartureDate").InnerText
                           , Utils.ConvertWeekDayToChinese(Utils.GetDateTime(hangbanXX[i].SelectSingleNode("DepartureDate").InnerText))
                           , hangbanXX[i].SelectSingleNode("BoardPointName").InnerText
                           , hangbanXX[i].SelectSingleNode("OffPointName").InnerText
                           , ordercode
                           , paystate == "已出票" ? "送票中" : paystate);
                }

                break;
            }

            return strLi.ToString();
        }
        /// <summary>
        /// 初始化样式
        /// </summary>
        /// <returns></returns>
        void initCSS()
        {
            bool ispay = Utils.GetQueryStringValue("pay") == "1";
            style1 = ispay ? "none" : "block";
            style2 = ispay ? "block" : "none";
            StringBuilder strCss = new StringBuilder();
            strCss.AppendFormat("<li {0}><a href=\"/AppPage/weixin/jp_Orders.aspx\">未付款</a></li>", ispay ? "class=\"normal\"" : "class=\"active\"");
            strCss.AppendFormat("<li {0}><a href=\"/AppPage/weixin/jp_Orders.aspx?pay=1\">已付款</a></li>", ispay ? "class=\"active\"" : "class=\"normal\"");
            litHead.Text = strCss.ToString();
        }
        /// <summary>
        /// 支付
        /// </summary>
        void setZF()
        {
            decimal money = Utils.GetDecimal(Utils.GetQueryStringValue("op"));
            string orderid = Utils.GetQueryStringValue("id");
            var order = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModel(orderid);
            if (order == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请重新操作"));
            int result = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().ZhiFu(new MJiPiaoBaoCun() { OpeatorID = userInfo.UserID, OrderID = orderid, payState = TickOrderPayState.已支付, OrderPrice = money });
            if (result == -99) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "账户余额不足，请联系4008005216进行充值！"));
            if (result == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "已支付！"));
            if (result == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "支付失败！"));

            if (result == 1)
            {
                Eyousoft_yhq.BLL.BConDetaile ser = new Eyousoft_yhq.BLL.BConDetaile();
                Eyousoft_yhq.Model.MConDetaile model = new MConDetaile();
                model.HuiYuanID = userInfo.UserID;
                model.XFway = (Model.XFfangshi)XFfangshi.消费;
                Random rn = new Random();
                model.DingDanBianHao = order.OrderCode;
                model.JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiShiJian = DateTime.Now;
                model.DDCarrtes = DDleibie.机票订单;
                model.JinE = money;
                new Eyousoft_yhq.BLL.BConDetaile().Add(model);


            }


            if (result == 1)
            {
                var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModel(orderid);
                if (model == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请重新操作"));
                StringBuilder strbu = new StringBuilder();
                strbu.Append("<?xml version=\"1.0\"?>");
                strbu.Append("<AskOrderTicket_1_1>");
                strbu.AppendFormat("<SubsOrderNo>{0}</SubsOrderNo>", model.OrderCode);
                strbu.AppendFormat("<ModifyTag>{0}</ModifyTag>", model.ModifyTag);
                strbu.AppendFormat("<NotifyURL>{0}</NotifyURL>", "http://www.4008005216.com/webMaster/JPBackRequest.aspx");
                strbu.AppendFormat("<NotifyType>{0}</NotifyType>", "post");
                strbu.AppendFormat("<BankCode>{0}</BankCode>", "");
                strbu.AppendFormat("<BankNo>{0}</BankNo>", "");
                strbu.AppendFormat("<BalanceDate>{0}</BalanceDate>", "");
                strbu.AppendFormat("<PayType>{0}</PayType>", "QK");
                strbu.AppendFormat("<PrintTktType>{0}</PrintTktType>", "B");

                strbu.Append("</AskOrderTicket_1_1>");
                var Result = new com._8222666.fxb2b.Service().XmlSubmit(getIdentityXMLString(), strbu.ToString(), "");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Result);
                if (doc.SelectSingleNode("AskOrderTicket_1_1") != null && doc.SelectSingleNode("AskOrderTicket_1_1").SelectSingleNode("Status").InnerText == "OK")
                {
                    model.payState = Eyousoft_yhq.Model.TickOrderPayState.出票中;
                    bool mark = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().setState(model);
                    if (mark) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "支付成功,自动出票失败！"));
                }
                else
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "支付成功,自动出票失败！"));
                }


            }


            if (result == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "支付成功，申请自动出票！"));
        }
    }
}
