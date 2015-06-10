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
    public class webmasterPage : System.Web.UI.Page
    {
        #region attributes
        protected MWebmasterInfo HuiYuanInfo = null;
        /// <summary>
        /// login page file path
        /// </summary>
        public const string LoginFilePath = "/webmaster/login.aspx";
        #endregion
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

        #region protected override members
        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            MWebmasterInfo m = null;
            bool isLogin = IsLogin(out m);

            if (!isLogin)
            {
                Response.Redirect("/webMaster/login.aspx");
            }

            HuiYuanInfo = m;
        }

        protected bool login(string UN, string PW)
        {
            var userModel = new Eyousoft_yhq.BLL.Login().isLoginadmin(UN, PW);

            return userModel == null ? false : true;
        }


        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <returns></returns>
        public static MWebmasterInfo GetUserInfo()
        {
            MWebmasterInfo info = null;
            string userId = GetCookie(LoginCookieUserId);
            string username = GetCookie(LoginCookieUsername);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
            {
                return null;
            }

            new Eyousoft_yhq.BLL.Login().autoLogin(userId, username, out info);
 
            return info;
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <returns></returns>
        public static bool IsLogin(out MWebmasterInfo info)
        {
            info = GetUserInfo();

            if (info == null) return false;

            return true;
        }

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
            response.AppendCookie(cookie);
        }

        /// <summary>
        /// 移除登录用户Cookie
        /// </summary>
        public static void RemoveCookies()
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


        /// <summary>
        /// 判断当前用户是否有权限
        /// </summary>
        /// <param name="permissionId">权限ID</param>
        /// <returns></returns>
        public bool CheckGrantMenu2(Eyousoft_yhq.Model.Privs menu)
        {
            if (HuiYuanInfo == null) return false;
            return HuiYuanInfo.Privs.Contains(((int)menu).ToString());
        }

        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <returns></returns>
        public void ToUrl(string url)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(
                string.Format("<script type=\"text/javascript\">top.location.href='{0}';</script>", url));
            HttpContext.Current.Response.End();
        }

        protected void RCWE(string s)
        {
            Response.Clear();
            Response.Write(s);
            Response.End();
        }

    }
}
