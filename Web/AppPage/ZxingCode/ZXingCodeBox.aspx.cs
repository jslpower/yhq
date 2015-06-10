using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.AppPage.ZxingCode
{
    public partial class ZXingCodeBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = EyouSoft.Common.Utils.GetQueryStringValue("id");
            string tp = EyouSoft.Common.Utils.GetQueryStringValue("tp");
            if (tp == "1")
            {
                var order = new Eyousoft_yhq.BLL.Order().GetModel(id);
                if (order == null)
                {
                    ZXING.Text = "未找到此订单！";
                    return;
                }
                else
                {
                    string data = "order|" + order.OrderID + "|产品名称:" + order.ProductName + "|会员姓名:" + order.MemberName;
                    ZXING.Text = string.Format("<img src={0} />", EyouSoft.Common.Utils.CreateZxingCode(data));
                }
            }
            else if (tp == "2")
            {
                var order = new Eyousoft_yhq.BLL.GYSticket().GetModel(id);
                if (order == null)
                {
                    ZXING.Text = "未找到此订单！"; return;
                }
                else
                {
                    string data = "torder|" + order.ID + "|机票编号:" + order.PlaneTicket + "|客户姓名:" + order.CusName;
                    ZXING.Text = string.Format("<img src={0} />", EyouSoft.Common.Utils.CreateZxingCode(data));
                }
            }
            else
            {
                ZXING.Text = "未找到此订单！";
            }
        }
    }
}
