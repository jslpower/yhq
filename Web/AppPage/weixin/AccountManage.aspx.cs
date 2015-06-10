using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;
using Eyousoft_yhq.Model;
using System.Xml;


namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class AccountManage : System.Web.UI.Page
    {
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("chk") == "1") getContactName();
            if (Utils.GetQueryStringValue("zz") == "1") PayOther();

            if (userInfo == null) Response.Redirect("/AppPage/weixin/Login.aspx?rurl=/AppPage/weixin/AccountManage.aspx");
            PlaceHolder2.Visible = PlaceHolder1.Visible = userInfo.IsZZ;
            var huiyuan = new Eyousoft_yhq.BLL.Member().GetModel(userInfo.UserID);
            if (huiyuan != null) lblmoney.Text = huiyuan.YuE.ToString("F2");
        }
        /// <summary>
        /// 转账
        /// </summary>
        void PayOther()
        {
            string userTo = Utils.GetQueryStringValue("a");
            decimal moneys = Utils.GetDecimal(Utils.GetQueryStringValue("m"));
            int result = new Eyousoft_yhq.BLL.Member().UpdatePayState(userInfo.UserID, userTo, moneys);
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
                string Mobile = Utils.GetQueryStringValue("userTo");
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
        void getContactName()
        {
            string Mobile = Utils.GetQueryStringValue("userTo");
            var modelUser = new Eyousoft_yhq.BLL.Member().GetModelByName(Mobile);
            if (modelUser == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请核对账户名是否正确！"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", modelUser.ContactName));
        }

    }
}
