using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = EyouSoft.Common.Utils.GetFormValue("t_u");
            string pwd = EyouSoft.Common.Utils.GetFormValue("t_p");

            if (string.IsNullOrEmpty(username))
            {
                this.RegisterAlertScript("请填写用户名！");
            }
            if (string.IsNullOrEmpty(pwd))
            {
                this.RegisterAlertScript("请填写密码！");
            }

            var userInfo = new Eyousoft_yhq.BLL.Login().isLoginadmin(username, pwd);


            bool isUserValid = userInfo != null ? true : false;

            if (isUserValid)
            {
                Response.Redirect("/webMaster/default.aspx");
            }
            else
            {
                this.RegisterAlertScript("用户名或密码错误!");
            }
        }

        #region private members
        /// <summary>
        /// register alert script
        /// </summary>
        /// <param name="s">msg</param>
        private void RegisterAlertScript(string s)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), string.Format("alert('{0}');", s), true);
        }
        #endregion
    }
}
