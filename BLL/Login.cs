using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EyouSoft.Model.SSOStructure;

namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// webmaster login
    /// </summary>
    public class Login
    {
        Eyousoft_yhq.SQLServerDAL.DUserLogin dal = new Eyousoft_yhq.SQLServerDAL.DUserLogin();
        #region static constants
        //static constants
        /// <summary>
        /// 登录Cookie，用户编号
        /// </summary>
        public const string LoginCookieUserId = "SYS_TieLv_UID";
        /// <summary>
        /// 登录Cookie，用户账号
        /// </summary>
        public const string LoginCookieUsername = "SYS_TieLv_UN";

        /// <summary>
        /// 登录Cookie，客服登录
        /// </summary>
        public const string LoginCookieKeFu = "SYS_TieLv_KF";

        /// <summary>
        /// 登录Cookie，会话标识
        /// </summary>
        public const string LoginCookieSessionId = "SYS_TieLv_SESSIONID";

        /// <summary>
        /// 登录Cookie
        /// 作为存储用户最后登录时间的KEY.
        /// 存储的时间格式为：year-month-day-hour-minutes-seconds.
        /// </summary>
        public const string LoginCookieLastLogTime = "lastlogintime";

        #endregion
        public Login()
        { }

        public MWebmasterInfo isLogin(string un, string pwd)
        {
            if (un == "" || pwd == "") return null;
            MWebmasterInfo cookies = dal.Login(un, pwd);
            if (cookies != null)
            {
                SetCookies(cookies);
            }

            return cookies;
        }
        public MWebmasterInfo isLoginadmin(string un, string pwd)
        {
            if (un == "" || pwd == "") return null;
            MWebmasterInfo cookies = dal.Login(un, pwd);
            if (cookies != null)
            {
                SetCookies(cookies);
            }

            return cookies;
        }
        public void autoLogin(string userId, string username, out MWebmasterInfo uInfo)
        {
            uInfo = null;
            uInfo = dal.LoginById(userId);
            if (uInfo == null) return;
            if (uInfo.Username != username) { uInfo = null; return; }

        }


        /// <summary>
        /// 设置登录Cookies
        /// </summary>
        /// <param name="info">登录用户信息</param>
        private static void SetCookies(MWebmasterInfo info)
        {
            //Cookies生存周期为浏览器进程
            HttpResponse response = HttpContext.Current.Response;

            RemoveCookies();

            var cookie = new HttpCookie(LoginCookieUserId);
            cookie.Value = info.UserId.ToString();
            cookie.HttpOnly = true;
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieUsername);
            cookie.Value = HttpContext.Current.Server.UrlEncode(info.Username);
            cookie.HttpOnly = true;
            response.AppendCookie(cookie);


            cookie = new HttpCookie(LoginCookieLastLogTime);
            cookie.Value = DateTime.Now.ToString("yyyy-M-d-H-m-s");
            //cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.AppendCookie(cookie);
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

    }
}
