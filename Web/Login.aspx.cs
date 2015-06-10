using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
namespace Eyousoft_yhq.Web
{
    public partial class Login : System.Web.UI.Page
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
            string un = Utils.GetFormValue(txtUserName.UniqueID);
            string pw = Utils.GetFormValue(txtPassWord.UniqueID);

            if (string.IsNullOrEmpty(un))
            {
                return UtilsCommons.AjaxReturnJson("0", "请填写用户名！");
            }
            if (string.IsNullOrEmpty(pw))
            {
                return UtilsCommons.AjaxReturnJson("0", "请填写密码！");
            }
            Eyousoft_yhq.BLL.MemberLogin MLogin = new Eyousoft_yhq.BLL.MemberLogin();
            EyouSoft.Model.SSOStructure.MUserInfo Muser = MLogin.isLogin(un, pw);

            bool isUserValid = Muser != null ? true : false;

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
