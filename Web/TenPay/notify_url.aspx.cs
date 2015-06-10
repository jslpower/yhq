using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PayAPI.Tencent;
using EyouSoft.Common;

namespace Enow.TZB.Web.TenPay
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Tenpay pay = new Tenpay();
            var model = pay.GetNotifyAsync();

            if (model.IsTradeSuccess)
            {
                //Utils.WLog(model.OutTradeNo, "/log/log.txt");
                bool rv = false;
                rv = new Eyousoft_yhq.BLL.BChongZhi().SheZhiZhiFuByOrderCode(model.OutTradeNo, Eyousoft_yhq.Model.PaymentState.已支付);

                if (rv)
                {
                    bool IsUpdateState = new Eyousoft_yhq.BLL.BChongZhi().UpdateTradeNO(model.OutTradeNo, model.TradeNo);
                    Response.Clear();
                    Response.Write("<xml><return_code>SUCCESS</return_code></xml>");
                    Response.End();
                    return;
                }
                else
                {
                    //Utils.WLog("验证支付凭据支付失败!!", "/Log/Pay.txt");
                    return;
                }
            }
            else
            {
                //Utils.WLog("支付失败!!", "/Log/Pay1.txt");
                return;
            }

        }
    }
}