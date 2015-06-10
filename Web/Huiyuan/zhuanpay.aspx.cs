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

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class zhuanpay : EyouSoft.Common.Page.HuiyuanPage
    {


        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Utils.GetQueryStringValue("zhuanz") == "1") PayOther();
            var memeber = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (memeber != null)
            {

            }

        }
        void PayOther()
        {
            string userTo = Utils.GetFormValue("userTo");
            decimal moneys = Convert.ToDecimal(Utils.GetFormValue("money"));
            int result = new Eyousoft_yhq.BLL.Member().UpdatePayState(userInfo.UserName, userTo, 500);
            if (result == 1)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "转帐成功"));

            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "转帐失败"));
            }

        }

    }
}
