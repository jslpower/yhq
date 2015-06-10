using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.ZxingCode
{
    public partial class SaoMiao : EyouSoft.Common.Page.HuiyuanPage
    {
        protected string Mark = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (model == null) return;
            Mark = model.IsAdmin;
            string id = Utils.GetQueryStringValue("id");
            string ordertype = Utils.GetQueryStringValue("ordertype");

            if (Utils.GetQueryStringValue("chk") == "1")
            {
                if (ordertype == "order")
                {
                    var order = new Eyousoft_yhq.BLL.Order().GetModel(id);
                    Response.Clear();
                    if (order == null)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("2", "未找到订单"));
                    }
                    else if (order.XiaoFei == Eyousoft_yhq.Model.XFstate.已消费 && order.AvailNum <= 0)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("1", "此订单已消费"));
                    }
                    else if (order.PayState == Eyousoft_yhq.Model.PaymentState.未支付)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("3", "此订单未支付"));
                    }
                    else if (order.XiaoFei == Eyousoft_yhq.Model.XFstate.未消费 && order.PayState == Eyousoft_yhq.Model.PaymentState.已支付)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("0", "有效订单"));
                    }
                    else if (order.XiaoFei == Eyousoft_yhq.Model.XFstate.已消费 && order.AvailNum > 0)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("0", "有效订单"));
                    }
                    else
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("999", "订单信息错误"));
                    }
                    Response.End();
                }
                else if (ordertype == "torder")
                {
                    var order = new Eyousoft_yhq.BLL.GYSticket().GetModel(id);
                    Response.Clear();
                    if (order == null)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("2", "未找到订单"));
                    }
                    else if (order.payState == Eyousoft_yhq.Model.PaymentState.未支付)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("3", "此订单未支付"));
                    }
                    else if (order.orderState == Eyousoft_yhq.Model.TickOrderState.已出票)
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("1", "此订单已出票"));
                    }
                    else
                    {
                        Response.Write(UtilsCommons.AjaxReturnJson("0", "有效订单"));
                    }
                    Response.End();
                }
                else if (ordertype == "jp")
                {
                    Eyousoft_yhq.Model.MJiPiaoBaoCun jpModel = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(id);

                    if (jpModel == null)
                    {
                        Utils.RCWE(UtilsCommons.AjaxReturnJson("2", "未找到此订单2"));
                    }
                    else if (jpModel.payState != Eyousoft_yhq.Model.TickOrderPayState.已出票)
                    {
                        Utils.RCWE(UtilsCommons.AjaxReturnJson("4", "未出票"));
                    }
                    else if (jpModel.payState == Eyousoft_yhq.Model.TickOrderPayState.已出票)
                    {
                        Utils.RCWE(UtilsCommons.AjaxReturnJson("99", "有效订单"));
                    }
                    else
                    {
                        UtilsCommons.AjaxReturnJson("99", "test");
                    }
                }

            }

        }
    }
}
