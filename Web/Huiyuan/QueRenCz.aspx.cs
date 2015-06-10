using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class QueRenCz : EyouSoft.Common.Page.HuiyuanPage
    {
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            getZFinfo();
            Session["UserInfo"] = userInfo;
        }
        void getZFinfo()
        {
            var info = new Eyousoft_yhq.BLL.BChongZhi().GetModel(Utils.GetQueryStringValue("id"));
            if (info == null) Utils.RCWE("数据异常！");
            lblchongzhijine.Text = info.OptMoney.ToString("C2");
            lblzhifuURL.Text = string.Format("<a class=\"baocunbtn\"  target=\"_blank\" href=\"/Alipay/WebPay/AliPayIndex.aspx?OrderId={0}&token={1}&type=1\">确认充值</a>", info.OrderID, HuiYuanInfo.UserID);
        }
    }
}
