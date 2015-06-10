using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.printPage
{
    public partial class OrderPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var order = new Eyousoft_yhq.BLL.Order().GetModel(EyouSoft.Common.Utils.GetQueryStringValue("id"));
            if (order == null) return;
            lblVcode.Text = order.ConfirmCode;
            var product = new Eyousoft_yhq.BLL.Product().GetModel(order.ProductID);
            if (product == null) return;
            lblName.Text = product.ProductName;
            lblVdate.Text = string.Format("{0}", product.ValidiDate.ToString("yyyy年MM月dd日"));
            string data = string.Format("{0}|{1}|{2}|{3}|{4}", "order", order.OrderID, product.ProductName, order.MemberName, order.ConfirmCode);            
            lblCodeImg.Text = string.Format(" <img src={0} />", EyouSoft.Common.Utils.CreateZxingCode(data));
        }
    }
}
