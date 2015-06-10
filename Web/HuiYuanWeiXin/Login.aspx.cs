//微店登录 汪奇志 2015-01-19
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 会员登录
    /// </summary>
    public partial class Login : HuiYuanWeiXinYeMian
    {
        #region attributes
        protected string RURL = string.Empty;
        protected string RT = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            RURL = Utils.GetQueryStringValue("rurl");
            RT = Utils.GetQueryStringValue("rt");

            if (Utils.GetQueryStringValue("dotype") == "login") Login1();
        }

        #region private members
        /// <summary>
        /// login
        /// </summary>
        void Login1()
        {
            string txt_u = Utils.GetFormValue("txt_u");
            string txt_p = Utils.GetFormValue("txt_p");

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo = null;

            var bllRetCode = Eyousoft_yhq.BLL.MemberLogin.Login(txt_u, txt_p,out huiYuanInfo);

            if (bllRetCode == 1)
            {
                if (RT == "1")
                {
                    Utils.RCWE_AJAX("1", "登录成功", huiYuanInfo.WeiDianId);
                }

                Utils.RCWE_AJAX("1", "登录成功","");
            }
            else
            {
                Utils.RCWE_AJAX("-98", "请填写正确的用户名或密码");
            }
        }
        #endregion
    }
}
