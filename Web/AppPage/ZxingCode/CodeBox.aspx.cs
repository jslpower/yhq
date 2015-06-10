using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.AppPage.ZxingCode
{
    public partial class CodeBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = EyouSoft.Common.Utils.GetQueryStringValue("id");
            string tp = EyouSoft.Common.Utils.GetQueryStringValue("tp");
            var order = new Eyousoft_yhq.BLL.Order().GetModel(id);
            if (order == null)
            {
                ZXING.Text = "未找到此订单！";
                return;
            }
            else
            {
                var product = new Eyousoft_yhq.BLL.Product().GetModel(order.ProductID);
                if (product == null) return;
                string data = string.Format("{0}|{1}|{2}|{3}", "order", order.OrderID, product.ProductName, order.MemberName);
                ZXING.Text = string.Format(" <img src={0} />", EyouSoft.Common.Utils.CreateZxingCode(data));
            }

        }
    }
}
