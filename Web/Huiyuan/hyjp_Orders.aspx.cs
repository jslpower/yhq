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

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class hyjp_Orders : EyouSoft.Common.Page.HuiyuanPage
    {
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();


        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("zf") == "1") setZF();
            initOrders();

        }

        void initOrders()
        {
            if (userInfo != null)
            {
                pageIndex = UtilsCommons.GetPagingIndex("Page");
                var list = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModeList(pageSize, pageIndex, ref recordCount, userInfo.UserID);
                if (list != null && list.Count > 0)
                {
                    rpOrders.DataSource = list;
                    rpOrders.DataBind();
                    BindPage();
                    lbMsg.Visible = false;

                }
                else
                {
                    rpOrders.Visible = false;
                }
            }




        }

        /// <summary>
        /// 获取identity字符串
        /// </summary>
        /// <returns></returns>
        // string getIdentityXMLString(string username, string userPwd)
        string getIdentityXMLString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", "18636128850", "123456");

            return sb.ToString();
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect2.intPageSize = pageSize;
            this.ExporPageInfoSelect2.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect2.intRecordCount = recordCount;
        }
        #endregion

        /// <summary>
        /// 获取操作按钮
        /// </summary>
        /// <param name="paystate">订单状态</param>
        /// <param name="ordercode">订单号</param>
        /// <param name="orderid">订单编号</param>
        /// <returns></returns>
        protected string GetHtml(object paystate, string ordercode, string orderid)
        {
            Eyousoft_yhq.Model.TickOrderPayState state = (Eyousoft_yhq.Model.TickOrderPayState)paystate;
            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(ordercode);
            if (model == null) return null;
            //从数据库中取订单价格
            Decimal money = model.OrderPrice;

            switch (state)
            {
                case Eyousoft_yhq.Model.TickOrderPayState.未支付:
                    return string.Format(" <a href=\"javascript:; \" class=\"payzf\" data-id={0} data-money={1}>付款</a> | ", orderid, money);
                case Eyousoft_yhq.Model.TickOrderPayState.已支付:
                    return "<span class=\"grey\">已支付<span> | ";
                case Eyousoft_yhq.Model.TickOrderPayState.已出票:
                    return "<span class=\"grey\">已出票<span> | ";
                case Eyousoft_yhq.Model.TickOrderPayState.已签收:
                    return "<span class=\"grey\">已签收<span> | ";
                case Eyousoft_yhq.Model.TickOrderPayState.出票中:
                    return "<span class=\"grey\">出票中<span> | ";
                default:
                    break;
            }
            return "";
        }



        /// <summary>
        /// 支付
        /// </summary>
        void setZF()
        {
            decimal money = Convert.ToDecimal(Utils.GetQueryStringValue("op"));
            string orderid = Utils.GetQueryStringValue("id");
            var order = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModel(orderid);
            if (order == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请重新操作"));
            int result = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().ZhiFu(new Eyousoft_yhq.Model.MJiPiaoBaoCun() { OpeatorID = userInfo.UserID, OrderID = orderid, payState = Eyousoft_yhq.Model.TickOrderPayState.已支付, OrderPrice = money });
            if (result == -99) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "账户余额不足，请联系4008005216进行充值！"));
            if (result == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "已支付！"));
            if (result == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "支付失败！"));

            if (result == 1)
            {
                Eyousoft_yhq.BLL.BConDetaile ser = new Eyousoft_yhq.BLL.BConDetaile();
                Eyousoft_yhq.Model.MConDetaile model = new Eyousoft_yhq.Model.MConDetaile();
                model.HuiYuanID = userInfo.UserID;
                model.XFway = (Model.XFfangshi)Eyousoft_yhq.Model.XFfangshi.消费;
                Random rn = new Random();
                model.DingDanBianHao = order.OrderCode;
                model.JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiShiJian = DateTime.Now;
                model.DDCarrtes = Eyousoft_yhq.Model.DDleibie.机票订单;
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
                    if (mark) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "支付成功,已提交自动出票！"));
                }
                else
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "支付成功,自动出票失败！"));
                }


            }

            if (result == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "支付成功！"));
        }
    }
}
