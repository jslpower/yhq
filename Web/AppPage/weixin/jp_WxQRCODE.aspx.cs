using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_WxQRCODE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderCode = Utils.GetQueryStringValue("code");
            ZXING.Text = string.Format(" <img src={0} />", EyouSoft.Common.Utils.CreateZxingCode("jp|" + orderCode));

        }
    }
}
