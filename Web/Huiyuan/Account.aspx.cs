using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class Account : EyouSoft.Common.Page.HuiyuanPage
    {
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Utils.GetQueryStringValue("chongzhi") == "1") baocun();
            if (Utils.GetQueryStringValue("chk") == "1") getContactName(Utils.GetQueryStringValue("a"));
            if (Utils.GetQueryStringValue("zz") == "1") PayOther();
            var memeber = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (memeber != null) litAccount.Text = memeber.YuE.ToString("C2");
            PlaceHolder1.Visible = HuiYuanInfo.IsZZ;


        }
        /// <summary>
        /// 保存充值信息
        /// </summary>
        void baocun()
        {
            MChongZhi model = new MChongZhi();
            model.OrderID = Guid.NewGuid().ToString();
            model.OperatorID = HuiYuanInfo.UserID;
            model.OptMoney = Utils.GetDecimal(Utils.GetFormValue(txtMoney.UniqueID));
            model.PayState = PaymentState.未支付;
            model.OrderCode = "CZ" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
            int result = new Eyousoft_yhq.BLL.BChongZhi().Add(model);

            Utils.RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "正在跳转..." : "系统繁忙，稍后再试！", model.OrderID));

        }
        /// <summary>
        /// 转账
        /// </summary>
        void PayOther()
        {
            string userTo = Utils.GetQueryStringValue("a");
            decimal moneys = Utils.GetDecimal(Utils.GetQueryStringValue("m"));
            int result = new Eyousoft_yhq.BLL.Member().UpdatePayState(HuiYuanInfo.UserID, userTo, moneys);
            if (result == -102) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "转账金额不能为0！"));
            if (result == -101) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "转账账户错误"));
            if (result == -100) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "登陆失败，请重新登陆！"));
            if (result == -99) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "可用余额不足！"));
            if (result == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "不能给本人转账"));
            if (result == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "转帐失败"));
            if (result == 1)
            {
                Eyousoft_yhq.BLL.BConDetaile ser = new Eyousoft_yhq.BLL.BConDetaile();
                Eyousoft_yhq.Model.MConDetaile model = new MConDetaile();
                model.HuiYuanID = userInfo.UserID;
                model.XFway = (Model.XFfangshi)XFfangshi.转帐;
                Random rn = new Random();
                model.DingDanBianHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiShiJian = DateTime.Now;
                string Mobile = Utils.GetQueryStringValue("a");
                var modelUser = new Eyousoft_yhq.BLL.Member().GetModelByName(Mobile);
                model.JiaoYiDuiXiang = modelUser.UserID;
                model.JinE = moneys;
                new Eyousoft_yhq.BLL.BConDetaile().Add(model);


            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "转帐成功"));



        }
        /// <summary>
        /// 获取联系人姓名
        /// </summary>
        /// <param name="Mobile"></param>
        void getContactName(string Mobile)
        {
            var modelUser = new Eyousoft_yhq.BLL.Member().GetModelByName(Mobile);
            if (modelUser == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请核对账户名是否正确！"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", modelUser.ContactName));
        }

    }
}
