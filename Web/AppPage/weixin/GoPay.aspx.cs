using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class GoPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litURL.Text = string.Format("<a href=\"{0}/AliPay/default.aspx?OrderId={1}\">前往支付</a>", "http://" + HttpContext.Current.Request.Url.Host, Utils.GetQueryStringValue("orderid"));
        }
    }
}
