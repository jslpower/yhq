using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class ChongZhi : System.Web.UI.Page
    {
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userInfo == null) Response.Redirect("/AppPage/weixin/Login.aspx?rurl=/AppPage/weixin/ChongZhi.aspx");
            lblAccount.Text = userInfo.UserName;
            if (Utils.GetQueryStringValue("chongzhi") == "1") baocun();
        }
        /// <summary>
        /// 保存充值信息
        /// </summary>
        void baocun()
        {
            MChongZhi model = new MChongZhi();
            model.OrderID = Guid.NewGuid().ToString();
            model.OperatorID = userInfo.UserID;
            model.OptMoney = Utils.GetDecimal(Utils.GetFormValue("money"));
            model.PayState = PaymentState.未支付;
            model.OrderCode = "CZ" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
            int result = new Eyousoft_yhq.BLL.BChongZhi().Add(model);

            Utils.RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "正在跳转..." : "系统繁忙，稍后再试！", model.OrderID));

        }
    }
}
