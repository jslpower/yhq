using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class DetailBox : EyouSoft.Common.Page.HuiyuanPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") Save();
            init();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void init()
        {
            string id = Utils.GetQueryStringValue("Id");
            var order = new Eyousoft_yhq.BLL.Order().GetModel(id);
            if (order == null) return;
            lblOrderNO.Text = order.OrderCode;
            lblOrderTime.Text = order.IssueTime.ToString("yyyy-MM-dd HH:ss");
            lblProName.Text = order.ProductName;
            lblTran.Text = order.OrderPrice.ToString("C2");
        }
        /// <summary>
        /// 支付订单
        /// </summary>
        void Save()
        {
            var order = new Eyousoft_yhq.BLL.Order().GetModel(Utils.GetQueryStringValue("id"));
            if (order == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请刷新页面"));
            order.PayState = Eyousoft_yhq.Model.PaymentState.已支付;
            int i = new Eyousoft_yhq.BLL.Order().XiaoFei(order, HuiYuanInfo.UserID);
            if (i == 1)
            {
                Eyousoft_yhq.Model.MConDetaile model = new MConDetaile();
                model.HuiYuanID = HuiYuanInfo.UserID;
                model.XFway = (Model.XFfangshi)XFfangshi.消费;
                Random rn = new Random();
                model.DingDanBianHao = order.OrderCode;
                model.JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiShiJian = DateTime.Now;
                model.DDCarrtes = DDleibie.旅游订单;
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
