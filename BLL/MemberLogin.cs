using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EyouSoft.Model.SSOStructure;

namespace Eyousoft_yhq.BLL
{
    public class MemberLogin
    {
        Eyousoft_yhq.SQLServerDAL.DMemberLogin dal = new Eyousoft_yhq.SQLServerDAL.DMemberLogin();

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

        #region private members
        /// <summary>
        /// 设置登录Cookies
        /// </summary>
        /// <param name="info">登录用户信息</param>
        private static void SetCookies(MUserInfo info)
        {
            //Cookies生存周期为浏览器进程
            HttpResponse response = HttpContext.Current.Response;

            RemoveCookies();

            var cookie = new HttpCookie(LoginCookieUserId);
            cookie.Value = info.UserID.ToString();
            cookie.HttpOnly = true;
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieUsername);
            cookie.Value = HttpContext.Current.Server.UrlEncode(info.UserName);
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
        #endregion

        #region public members
        public MemberLogin() { }

        public MUserInfo isLogin(string un, string pwd)
        {
            if (un == "" || pwd == "") return null;
            MUserInfo cookies = dal.Login(un, pwd);
            if (cookies != null)
            {
                SetCookies(cookies);
            }

            return cookies;
        }

        public void autoLogin(string userId, string username, out MUserInfo uInfo)
        {
            uInfo = null;
            uInfo = dal.LoginById(userId);
            if (uInfo == null) return;
            if (uInfo.UserName != username) { uInfo = null; return; }

        }

        /// <summary>
        /// 自动登录，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public static int AutoLogin(string huiYuanId)
        {
            MUserInfo info = null;

            return AutoLogin(huiYuanId, out info);
        }

        /// <summary>
        /// 自动登录，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="info">out</param>
        /// <returns></returns>
        public static int AutoLogin(string huiYuanId, out MUserInfo info)
        {
            var _dal = new Eyousoft_yhq.SQLServerDAL.DMemberLogin();
            info = null;

            info = _dal.LoginById(huiYuanId);
            if (info == null) return 0;

            SetCookies(info);

            return 1;
        }

        /// <summary>
        /// 判断会员是否登录，返回1已登录，返回其它未登录
        /// </summary>
        /// <returns></returns>
        public static int IsLogin()
        {
            if (GetLoginHuiYuanInfo() == null) return 0;

            return 1;
        }

        /// <summary>
        /// 获取已登录会员信息
        /// </summary>
        /// <returns></returns>
        public static MUserInfo GetLoginHuiYuanInfo()
        {
            var _dal = new Eyousoft_yhq.SQLServerDAL.DMemberLogin();

            MUserInfo info = null;
            string huiYuanId = GetCookie(LoginCookieUserId);
            string yongHuMing = GetCookie(LoginCookieUsername);

            if (string.IsNullOrEmpty(huiYuanId) || string.IsNullOrEmpty(yongHuMing))
            {
                return info;
            }

            info = _dal.LoginById(huiYuanId);            

            return info;
        }

        /// <summary>
        /// 会员登录，返回1成功，其它失败
        /// </summary>
        /// <param name="u">用户名</param>
        /// <param name="p">密码</param>
        /// <param name="info">OUT 会员信息</param>
        /// <returns></returns>
        public static int Login(string u, string p, out MUserInfo info)
        {
            info = null;
            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p)) return 0;

            var _dal = new Eyousoft_yhq.SQLServerDAL.DMemberLogin();

            info = _dal.Login(u, p);

            if (info == null) return -1;

            SetCookies(info);

            return 1;
        }
        #endregion       
    }
}
