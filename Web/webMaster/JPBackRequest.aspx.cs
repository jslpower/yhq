using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class JPBackRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SubsOrderNo = Request.Form["SubsOrderNo"],
                OrderNo = Request.Form["OrderNo"],
                BalanceMoney = Request.Form["BalanceMoney"],
                PNR = Request.Form["PNR"],
                TktCount = Request.Form["TktCount"],
                ManCount = Request.Form["ManCount"],
                TktCreateData = Request.Form["TktCreateData"],
                remark = Request.Form["remark"];

            if (string.IsNullOrEmpty(SubsOrderNo)) return;
            var orderModel = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(SubsOrderNo);//获取订单信息
            if (orderModel == null) return;
            var huiyuanModel = new Eyousoft_yhq.BLL.Member().GetModel(orderModel.OpeatorID);//获取下单人信息
            if (huiyuanModel == null) return;
            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(SubsOrderNo);
            model.payState = Eyousoft_yhq.Model.TickOrderPayState.已出票;
            bool result = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().setState(model);

        }
    }
}
