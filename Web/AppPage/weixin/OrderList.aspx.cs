using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class OrderList : System.Web.UI.Page
    {

        #region  页面参数
        protected int pageIndex = 1, pageSize = 5, recordCount = 0;
        #endregion
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userInfo != null)
            {
                string OrderType = Utils.GetQueryStringValue("OrderType");
                if (Utils.GetQueryStringValue("zf") == "1") setZF();
                InitOrders(OrderType);
            }
            else
            {
                Response.Redirect("/AppPage/weixin/Login.aspx");
            }


        }

        protected void InitOrders(string Type)
        {

            Eyousoft_yhq.BLL.Order bll = new Eyousoft_yhq.BLL.Order();

            Eyousoft_yhq.Model.MSearchOrder serchModel = new Eyousoft_yhq.Model.MSearchOrder();
            serchModel.PaymentState = (Eyousoft_yhq.Model.PaymentState?)Utils.GetEnumValueNull(typeof(Eyousoft_yhq.Model.PaymentState), Utils.GetQueryStringValue("OrderType"), (int)Eyousoft_yhq.Model.PaymentState.未支付);
            serchModel.MemberID = userInfo.UserID;

            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_orders.DataSource = list;
                rpt_orders.DataBind();
                litMsg.Visible = false;
            }
            else
            {
                PlaceHolder1.Visible = false;
                litMsg.Visible = true;
            }

        }



        #region 出团通知单下载
        protected string DownFile(object FileXML, string orderid)
        {


            IList<Eyousoft_yhq.Model.Attach> Attach = (IList<Eyousoft_yhq.Model.Attach>)FileXML;
            if (Attach != null)
            {
                return string.Format("<a    href=\"{0}\"><img src=\"/images/icon1.gif\"> 出团通知单下载</a>  ", "http://" + HttpContext.Current.Request.Url.Host + "/AppPage/weixin/DownNotice.aspx?orderid=" + orderid);
            }


            return "<a>暂无出团通知单</a>";
        }
        #endregion

        #region  产品图片
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getProImg(string id)
        {
            var img = new Eyousoft_yhq.BLL.Product().GetModel(id).AttachList;
            if (img != null && img.Count > 0)
            {
                for (int i = 0; i < img.Count; i++)
                {
                    if (img[i].IsWebImage && !string.IsNullOrEmpty(img[i].FilePath)) return img[i].FilePath;
                }
            }
            return "/images/list_img.gif";
        }

        #endregion

        #region  支付宝
        /// <summary>
        /// 支付宝绑定
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string BindZhiFuBao(string orderId, object status, object zhifu, object xiafei)
        {
            System.Text.StringBuilder zhifubao = new System.Text.StringBuilder();

            Eyousoft_yhq.Model.OrderState OrderStatus = (Eyousoft_yhq.Model.OrderState)status;

            Eyousoft_yhq.Model.PaymentState PayStatus = (Eyousoft_yhq.Model.PaymentState)zhifu;

            Eyousoft_yhq.Model.ConSumState ConSumState = (Eyousoft_yhq.Model.ConSumState)xiafei;

            if (Eyousoft_yhq.Model.OrderState.待付款 == OrderStatus || Eyousoft_yhq.Model.OrderState.已成交 == OrderStatus)
            {
                if (PayStatus == Eyousoft_yhq.Model.PaymentState.已支付)
                {
                    zhifubao.Append("<span class=\"yifu\">" + ConSumState.ToString() + "</span>");
                }
                else
                {
                    zhifubao.AppendFormat("<a data-id=\"{0}\" class=\"yueZF\" href=\"javascript:;\"><span class=\"daifu\">账户支付</span></a>", orderId);
                    zhifubao.AppendFormat("<a href=\"http://{1}/AppPage/weixin/GoPay.aspx?OrderId={0}\"><span class=\"daifu\">支付宝支付</span></a>", orderId, HttpContext.Current.Request.Url.Host);
                }
            }
            else
            {
                zhifubao.AppendFormat("<span class=\"daifu\">{0}</span>", OrderStatus.ToString());
            }

            return zhifubao.ToString();
        }

        #endregion

        /// <summary>
        /// 支付
        /// </summary>
        void setZF()
        {
            var order = new Eyousoft_yhq.BLL.Order().GetModel(Utils.GetQueryStringValue("id"));
            if (order == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请刷新页面"));
            order.PayState = Eyousoft_yhq.Model.PaymentState.已支付;
            int i = new Eyousoft_yhq.BLL.Order().XiaoFei(order, userInfo.UserID);
            if (i == 1)
            {
                Eyousoft_yhq.Model.MConDetaile model = new Eyousoft_yhq.Model.MConDetaile();
                model.HuiYuanID = userInfo.UserID;
                model.XFway = Eyousoft_yhq.Model.XFfangshi.消费;
                Random rn = new Random();
                model.DingDanBianHao = order.OrderCode;
                model.JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiShiJian = DateTime.Now;
                model.DDCarrtes = Eyousoft_yhq.Model.DDleibie.旅游订单;
                model.JinE = order.OrderPrice;
                new Eyousoft_yhq.BLL.BConDetaile().Add(model);
            }
            if (i == -99) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "已支付"));
            if (i == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "余额不足"));
            if (i == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "支付失败"));
            if (i == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "支付成功"));
        }

    }
}
