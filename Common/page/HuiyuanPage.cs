using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using EyouSoft.Model.SSOStructure;
using System.Web;

namespace EyouSoft.Common.Page
{
    /// <summary>
    /// web page base
    /// </summary>
    public class HuiyuanPage : System.Web.UI.Page
    {
        #region attributes
        protected MUserInfo HuiYuanInfo = null;
        #endregion
        #region static constants
        //static constants
        /// <summary>
        /// 登录Cookie，用户编号
        /// </summary>
        public const string LoginCookieUserId = "MSYS_TieLv_UID";
        /// <summary>
        /// 登录Cookie，用户账号
        /// </summary>
        public const string LoginCookieUsername = "MSYS_TieLv_UN";

        /// <summary>
        /// 登录Cookie，客服登录
        /// </summary>
        public const string LoginCookieKeFu = "MSYS_TieLv_KF";

        /// <summary>
        /// 登录Cookie，会话标识
        /// </summary>
        public const string LoginCookieSessionId = "MSYS_TieLv_SESSIONID";

        /// <summary>
        /// 登录Cookie
        /// 作为存储用户最后登录时间的KEY.
        /// 存储的时间格式为：year-month-day-hour-minutes-seconds.
        /// </summary>
        public const string LoginCookieLastLogTime = "Mlastlogintime";

        #endregion

        #region protected override members
        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            MUserInfo m = null;
            bool isLogin = IsLogin(out m);

            if (!isLogin)
            {
                string URL = Server.UrlEncode(Request.Url.ToString());
                if (URL.Contains("AppPage"))
                { Response.Redirect("/AppPage/App_login.aspx?rurl=" + URL); }
                else
                {
                    Response.Redirect("/login.aspx?rurl=" + URL);
                }
            }

            HuiYuanInfo = m;
        }

        protected bool login(string UN, string PW)
        {
            var userModel = new Eyousoft_yhq.BLL.MemberLogin().isLogin(UN, PW);

            return userModel == null ? false : true;
        }


        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <returns></returns>
        public static MUserInfo GetUserInfo()
        {
            MUserInfo info = null;
            string userId = GetCookie(LoginCookieUserId);
            string username = GetCookie(LoginCookieUsername);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
            {
                return null;
            }

            new Eyousoft_yhq.BLL.MemberLogin().autoLogin(userId, username, out info);

            return info;
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <returns></returns>
        public static bool IsLogin(out MUserInfo info)
        {
            info = GetUserInfo();

            if (info == null) return false;

            return true;
        }

        /// <summary>
        /// 移除登录用户Cookie
        /// </summary>
        private static void RemoveCookies()
        {
            HttpResponse response = HttpContext.Current.Response;

            response.Cookies.Remove(LoginCookieUserId);
            response.Cookies.Remove(LoginCookieUsername);
            response.Cookies.Remove(LoginCookieSessionId);
            response.Cookies.Remove(LoginCookieKeFu);

            DateTime cookiesExpiresDateTime = DateTime.Now.AddDays(-1);

            response.Cookies[LoginCookieUserId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieUsername].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieSessionId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieKeFu].Expires = cookiesExpiresDateTime;
        }

        /// <summary>
        /// 获取登录用户Cookie信息
        /// </summary>
        /// <param name="name">登录Cookie名称</param>
        /// <returns></returns>
        private static string GetCookie(string name)
        {
            HttpRequest request = HttpContext.Current.Request;

            if (request.Cookies[name] == null)
            {
                return string.Empty;
            }

            return HttpContext.Current.Server.UrlDecode(request.Cookies[name].Value);
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        public static void Logout()
        {
            string userId = GetCookie(LoginCookieUserId);
            if (!string.IsNullOrEmpty(userId))
            {
                RemoveCookies();
            }
        }
        #endregion

    }
}
