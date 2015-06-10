using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage
{
    public partial class App_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string login = Utils.GetQueryStringValue("login");
            if (!string.IsNullOrEmpty(login))
            {
                Response.Clear();
                Response.Write(this.UserLogin());
                Response.End();
            }
        }
        private string UserLogin()
        {
            string un = Utils.GetFormValue("userName");
            string pw = Utils.GetFormValue("userPwd");

            if (string.IsNullOrEmpty(un))
            {
                return UtilsCommons.AjaxReturnJson("0", "请填写用户名！");
            }
            if (string.IsNullOrEmpty(pw))
            {
                return UtilsCommons.AjaxReturnJson("0", "请填写密码！");
            }

            EyouSoft.Model.SSOStructure.MUserInfo userInfo = new Eyousoft_yhq.BLL.MemberLogin().isLogin(un, pw);


            bool isUserValid = userInfo != null ? true : false;

            if (isUserValid)
            {
                return UtilsCommons.AjaxReturnJson("1", "登陆成功");
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("0", "手机号码或者密码错误！");
            }
        }

    }
}
