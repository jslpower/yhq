using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web
{
    public partial class OrderStep2 : System.Web.UI.Page
    {
        protected string ProtudId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("orderPost") == "1")
            {
                Response.Clear();
                Response.Write(AliPayOrder());
                Response.End();
            }
            if (!Page.IsPostBack)
            {
                string strpid = Utils.GetQueryStringValue("id");

                
                InitBind(strpid);
            }
        }

        protected void InitBind(string orid)
        {
            Eyousoft_yhq.BLL.Order OrderBll = new Eyousoft_yhq.BLL.Order();
            if (!string.IsNullOrEmpty(orid))
            {
                Eyousoft_yhq.Model.Order OrderModel = OrderBll.GetModel(orid);
                if (OrderModel != null)
                {
                    ProtudId = OrderModel.ProductID;
                    lbName.Text = OrderModel.ProductName;
                    lbSum.Text = OrderModel.PeopleNum.ToString();
                    lbPrice.Text = Convert.ToDecimal(OrderModel.OrderPrice / OrderModel.PeopleNum).ToString("C0");
                    lbOderPrice.Text = (OrderModel.OrderPrice).ToString("C0");
                    lbOderPrice2.Text = (OrderModel.OrderPrice).ToString("C0");
                }
            }
        }

        protected string AliPayOrder()
        {
            string id = Utils.GetQueryStringValue("ids");
            if (!string.IsNullOrEmpty(id))
            {
                Eyousoft_yhq.BLL.Order OrderBll = new Eyousoft_yhq.BLL.Order();
                Eyousoft_yhq.Model.Order OrderModel = OrderBll.GetModel(id);
                if(OrderModel!=null)
                {
                    if (OrderModel.OrderState ==Eyousoft_yhq.Model.OrderState.待付款)
                    {
                        if (OrderModel.PayState ==Eyousoft_yhq.Model.PaymentState.未支付)
                        {
                            return UtilsCommons.AjaxReturnJson("1", "支付跳转中.....");
                        }
                        else
                        {
                            return UtilsCommons.AjaxReturnJson("2", "订单已经支付无需重复支付");
                        }
                    }
                    else
                    {
                        return UtilsCommons.AjaxReturnJson("2", "订单正在审核当中或已经完成支付请到订单中心查看");
                    }
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("2", "订单不存在，请重新选择！");
                }
            }
            else
            {
               return UtilsCommons.AjaxReturnJson("2", "订单不存在，请重新选择！");
            }
        }
    }
}
