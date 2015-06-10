//会员微信页面 汪奇志 2015-01-21
using System;
using System.Collections.Generic;
using System.Web;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 会员微信页面
    /// </summary>
    public class HuiYuanWeiXinYeMian : System.Web.UI.Page
    {
        #region attributes
        EyouSoft.Model.SSOStructure.MUserInfo _HuiYuanInfo = null;
        /// <summary>
        /// 当前登录会员信息
        /// </summary>
        public EyouSoft.Model.SSOStructure.MUserInfo HuiYuanInfo { get { return _HuiYuanInfo; } }
        bool _IsLogin = false;
        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin { get { return _IsLogin; } }
        /// <summary>
        /// 登录url
        /// </summary>
        public string LoginUrl { get { return "/huiyuanweixin/login.aspx"; } }

        string _HOST = string.Empty;
        /// <summary>
        /// 获取当前请求的URL的主机部分
        /// </summary>
        public string HOST { get { return _HOST; } }
        #endregion

        #region protected members
        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _IsLogin = Eyousoft_yhq.BLL.MemberLogin.IsLogin() == 1;

            if (_IsLogin)
            {
                var huiYuanInfo = Eyousoft_yhq.BLL.MemberLogin.GetLoginHuiYuanInfo();
                _HuiYuanInfo = huiYuanInfo;
            }

            _HOST = Request.Url.Host;
        }

        /// <summary>
        /// OnPreRender
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        /// <summary>
        /// 验证登录，未登录跳转至登录页面，登录后会跳转到url指定的页面，已登录不做处理
        /// </summary>
        /// <param name="url">登录成功后需要跳转的url</param>
        protected void YanZhengLogin(string url)
        {
            if (!_IsLogin)
            {
                var _rurl = Server.UrlEncode(url);
                RedirectLogin(LoginUrl + "?rurl=" + _rurl);
            }
        }

        /// <summary>
        /// 验证登录，未登录跳转至登录页面，登录后会生动跳转到该页面，已登录不做处理
        /// </summary>
        protected void YanZhengLogin()
        {
            YanZhengLogin(Request.Url.ToString());
        }

        /// <summary>
        /// 验证登录，未登录跳转至登录页面，登录后会跳转到rt指定的页面，已登录不做处理
        /// </summary>
        /// <param name="rt">rt=0 我的名片 rt=1 我的微店</param>
        protected void YanZhengLogin(int rt)
        {
            if (!_IsLogin)
            {
                string url = "";

                switch (rt)
                {
                    case 0:url = "/huiyuanweixin/mingpian.aspx";break;
                    case 1: url = "/weidian/default.aspx"; break;
                    default: url = "/huiyuanweixin/mingpian.aspx"; break;
                }
                
                var _rurl = Server.UrlEncode(url);
                RedirectLogin(LoginUrl + "?rurl=" + _rurl + "&rt=" + rt);
            }
        }

        /// <summary>
        /// 跳转到登录页面
        /// </summary>
        /// <param name="url"></param>
        protected void RedirectLogin(string url)
        {
            Response.Redirect(url);
        }
        #endregion
    }
}
