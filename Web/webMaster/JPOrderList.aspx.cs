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
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class JPOrderList : EyouSoft.Common.Page.webmasterPage
    {

        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("sq") == "1") sendTicket();
            InitOrders();
        }
        /// <summary>
        /// 初始化列表
        /// 默认查询近三个月的订单
        /// </summary>
        protected void InitOrders()
        {
            DateTime? STime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("StartTime")) == null ? DateTime.Now.AddMonths(-3) : Utils.GetDateTimeNullable(Utils.GetQueryStringValue("StartTime"));
            DateTime? ETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("EndTime")) == null ? DateTime.Now : Utils.GetDateTimeNullable(Utils.GetQueryStringValue("EndTime"));

            StringBuilder searchXML = new StringBuilder();
            searchXML.Append("<QuerySubsOrderList_1_0>");
            searchXML.AppendFormat("<StartDt>{0}</StartDt>", STime.Value);
            searchXML.AppendFormat("<EndDt>{0}</EndDt>", ETime.Value);
            searchXML.Append("</QuerySubsOrderList_1_0>");
            var list = new com._8222666.fxb2b.Service().XmlSubmit(getIdentityXMLString(), searchXML.ToString(), "");
            XmlDocument dom = new XmlDocument();
            if (string.IsNullOrEmpty(list))
            {
                return;
            }
            dom.LoadXml(list);
            List<Eyousoft_yhq.Model.JPModel> datalist = new List<Eyousoft_yhq.Model.JPModel>();
            XmlNodeList nodes = dom.SelectSingleNode("QuerySubsOrderList_1_0").SelectNodes("Ds");
            for (int i = 0; i < nodes.Count; i++)
            {

                if (nodes[i].SelectSingleNode("SubsOrderSt").InnerText == "已删除") continue;
                var model = new Eyousoft_yhq.Model.JPModel();
                model.Address = nodes[i].SelectSingleNode("Address").InnerText;
                model.Airline = nodes[i].SelectSingleNode("Airline").InnerText;
                model.ApplyReason = nodes[i].SelectSingleNode("ApplyReason").InnerText;
                model.BalanceMoney = Utils.GetDecimal(nodes[i].SelectSingleNode("BalanceMoney").InnerText);
                model.CarrierCode = nodes[i].SelectSingleNode("CarrierCode").InnerText;
                model.CreateDt = Utils.GetDateTime(nodes[i].SelectSingleNode("CreateDt").InnerText);
                model.CusName = nodes[i].SelectSingleNode("CusName").InnerText;
                model.CustomerNo = nodes[i].SelectSingleNode("CustomerNo").InnerText;
                model.CusType = nodes[i].SelectSingleNode("CusType").InnerText;
                model.DepID = nodes[i].SelectSingleNode("DepID").InnerText;
                model.DepName = nodes[i].SelectSingleNode("DepName").InnerText;
                model.DzMan = nodes[i].SelectSingleNode("DzMan").InnerText;
                model.FltDateTime = Utils.GetDateTime(nodes[i].SelectSingleNode("FltDateTime").InnerText);
                model.Gain = Utils.GetDecimal(nodes[i].SelectSingleNode("Gain").InnerText);
                model.InsMoney = Utils.GetDecimal(nodes[i].SelectSingleNode("InsMoney").InnerText);
                model.InsNetPrice = nodes[i].SelectSingleNode("InsNetPrice").InnerText;
                model.Linkman = nodes[i].SelectSingleNode("Linkman").InnerText;
                model.OpID = nodes[i].SelectSingleNode("OpID").InnerText;
                model.OrderSource = nodes[i].SelectSingleNode("OrderSource").InnerText;
                model.PayType = nodes[i].SelectSingleNode("PayType").InnerText;
                model.PNR = nodes[i].SelectSingleNode("PNR").InnerText;
                model.PointGain = Utils.GetDecimal(nodes[i].SelectSingleNode("PointGain").InnerText);
                model.PsrNames = nodes[i].SelectSingleNode("PsrNames").InnerText;
                model.SubsOrderNo = nodes[i].SelectSingleNode("SubsOrderNo").InnerText;
                model.SubsOrderSt = nodes[i].SelectSingleNode("SubsOrderSt").InnerText;
                model.TypeDisplay = nodes[i].SelectSingleNode("TypeDisplay").InnerText;
                model.UserID = nodes[i].SelectSingleNode("UserID").InnerText;
                model.UserName = nodes[i].SelectSingleNode("UserName").InnerText;
                datalist.Add(model);


            }
            //int count = nodes.Count;
            //if (count == 0)
            //{
            //    litMsg.Visible = false;
            //}
            rpt_orders.DataSource = datalist;
            rpt_orders.DataBind();




        }

        ///// <summary>
        ///// 绑定分页控件
        ///// </summary>
        //protected void BindPage()
        //{
        //    this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
        //    this.ExporPageInfoSelect1.intPageSize = pageSize;
        //    this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
        //    this.ExporPageInfoSelect1.intRecordCount = recordCount;
        //    this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        //}

        /// <summary>
        /// 获取订单操作方法
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <returns></returns>
        protected string getOrderOpt(string OrderCode)
        {
            if (string.IsNullOrEmpty(OrderCode)) return "";
            var dingdan = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(OrderCode);
            if (dingdan == null) return "";
            switch (dingdan.payState)
            {
                case Eyousoft_yhq.Model.TickOrderPayState.未支付:
                    return string.Format("<a data-id=\"{0}\"  href=\"javascript:;\" class=\"upState\">[修改支付状态]</a>", dingdan.OrderID);
                case Eyousoft_yhq.Model.TickOrderPayState.已支付:
                    return string.Format("<a data-id=\"{0}\"   href=\"javascript:;\" class=\"cpTicket\">[申请出票]</a>", OrderCode);
                case Eyousoft_yhq.Model.TickOrderPayState.出票中:
                    return string.Format("<a data-id=\"{0}\"   href=\"javascript:;\" class=\"thTicket\">[出票中]</a>", OrderCode);

                case Eyousoft_yhq.Model.TickOrderPayState.已出票:
                case Eyousoft_yhq.Model.TickOrderPayState.已签收:
                case Eyousoft_yhq.Model.TickOrderPayState.出票失败:
                    return string.Format("<span>[{0}]</span>", dingdan.payState.ToString());
                default:
                    break;
            }
            return "";
        }

        #region 申请出票
        void sendTicket()
        {
            string orderCode = Utils.GetQueryStringValue("ordercode");

            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(orderCode);
            if (model == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请重新操作"));
            StringBuilder strbu = new StringBuilder();
            strbu.Append("<?xml version=\"1.0\"?>");
            strbu.Append("<AskOrderTicket_1_1>");
            strbu.AppendFormat("<SubsOrderNo>{0}</SubsOrderNo>", orderCode);
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
                bool result = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().setState(model);
                if (result) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "申请成功"));
            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "申请失败"));

        }
        #endregion

        #region  私有方法

        /// <summary>
        /// 获取identity字符串
        /// </summary>
        /// <returns></returns>
        //string getIdentityXMLString(string username, string userPwd)
        string getIdentityXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", "18636128850", "123456");

            return sb.ToString();
        }

        #endregion
    }
}
