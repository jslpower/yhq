using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EyouSoft.Common;

namespace Common.page
{
    #region webmaster page base
    /// <summary>
    /// webmaster page base
    /// </summary>
    /// Author:汪奇志 2011-09-23
    public class WebmasterPageBase : System.Web.UI.Page
    {
        #region attibutes
        /// <summary>
        /// login page file path
        /// </summary>
        public const string LoginFilePath = "/webmaster/login.aspx";


        private EyouSoft.Model.SSOStructure.MWebmasterInfo _userInfo;

        /// <summary>
        /// 管理后台用户信息
        /// </summary>
        public EyouSoft.Model.SSOStructure.MWebmasterInfo UserInfo
        {
            get
            {
                return _userInfo;
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            bool isLogin = false;// EyouSoft.Security.Membership.WebmasterProvider.IsLogin(out _userInfo);

            if (!isLogin)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(
                    string.Format("<script type=\"text/javascript\">top.location.href='{0}';</script>", LoginFilePath));
                HttpContext.Current.Response.End();
            }
        }

        #region protected members
        /// <summary>
        /// register alert script
        /// </summary>
        /// <param name="s">msg</param>
        protected void RegisterAlertScript(string s)
        {
            this.RegisterScript(string.Format("alert('{0}');", s));
        }

        /// <summary>
        /// register alert and redirect script
        /// </summary>
        /// <param name="s"></param>
        /// <param name="url">IsNullOrEmpty(url)=true page reload</param>
        protected void RegisterAlertAndRedirectScript(string s, string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                this.RegisterScript(string.Format("alert('{0}');window.location.href='{1}';", s, url));
            }
            else
            {
                this.RegisterScript(string.Format("alert('{0}');window.location.href=window.location.href;", s));
            }
        }

        /// <summary>
        /// register alert and reload script
        /// </summary>
        /// <param name="s"></param>
        protected void RegisterAlertAndReloadScript(string s)
        {
            RegisterAlertAndRedirectScript(s, null);
        }

        /// <summary>
        /// register scripts
        /// </summary>
        /// <param name="script"></param>
        protected void RegisterScript(string script)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        /// <summary>
        /// 转换成货币字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string ToMoneyString(object obj)
        {
            return UtilsCommons.GetMoneyString(obj, "zh-cn");
        }

        /// <summary>
        /// 转换成日期字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string ToDateTimeString(object obj)
        {
            return UtilsCommons.GetDateString(obj, "yyyy-MM-dd");
        }

        #endregion
    }
    #endregion
}
