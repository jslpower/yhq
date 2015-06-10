using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class MasterCZ : EyouSoft.Common.Page.webmasterPage
    {
        EyouSoft.Model.SSOStructure.MWebmasterInfo userInfo = EyouSoft.Common.Page.webmasterPage.GetUserInfo();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Utils.GetQueryStringValue("chk") == "1") getContactName(Utils.GetQueryStringValue("a"));
            if (Utils.GetQueryStringValue("zz") == "1") PayOther();
        }




        /// <summary>
        /// 获取联系人姓名
        /// </summary>
        /// <param name="Mobile"></param>
        void getContactName(string Mobile)
        {
            decimal moneys = Utils.GetDecimal(Utils.GetQueryStringValue("m"));
            if (moneys <= 0)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "输入金额有误"));
            }
            var modelUser = new Eyousoft_yhq.BLL.Member().GetModelByName(Mobile);
            if (modelUser == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请核对账户名是否正确！"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", modelUser.ContactName));
            if (modelUser.UserName == Mobile)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请核对账户名是否正确！"));

            }
        }

        /// <summary>
        /// 管理员充值
        /// </summary>
        void PayOther()
        {

            string userTo = Utils.GetQueryStringValue("a");
            decimal moneys = Utils.GetDecimal(Utils.GetQueryStringValue("m"));
            int result = new Eyousoft_yhq.BLL.Member().HuiYuangZZ(userTo, moneys);
            if (result < 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "充值失败"));
            if (result > 0)
            {
                Eyousoft_yhq.BLL.BConDetaile ser = new Eyousoft_yhq.BLL.BConDetaile();
                Eyousoft_yhq.Model.MConDetaile model = new Eyousoft_yhq.Model.MConDetaile();

                model.XFway = (Model.XFfangshi)Eyousoft_yhq.Model.XFfangshi.充值;
                Random rn = new Random();
                model.DingDanBianHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + rn.Next(10000, 99999).ToString();
                model.JiaoYiShiJian = DateTime.Now;
                string Mobile = Utils.GetQueryStringValue("a");
                var modelUser = new Eyousoft_yhq.BLL.Member().GetModelByName(Mobile);
                model.HuiYuanID = modelUser.UserID;

                model.JiaoYiDuiXiang = modelUser.UserID;
                model.JinE = moneys;
                model.DDCarrtes = Eyousoft_yhq.Model.DDleibie.充值订单;
                new Eyousoft_yhq.BLL.BConDetaile().Add(model);


            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "充值成功"));



        }


    }
}
