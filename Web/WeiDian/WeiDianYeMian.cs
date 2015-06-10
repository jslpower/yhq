//微店页面 汪奇志 2015-01-19
using System;
using System.Collections.Generic;
using System.Web;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiDian
{
    /// <summary>
    /// 微店页面
    /// </summary>
    public class WeiDianYeMian : System.Web.UI.Page
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
        public string LoginUrl { get { return "/huiyuanweixin/login.aspx?rt=1"; } }
        string _WeiDianId = string.Empty;
        /// <summary>
        /// 微店编号（取值优先级：url参数→cookies→当前登录用户） 
        /// </summary>
        public string WeiDianId { get { return _WeiDianId; } }
        bool _SFZZ = false;
        /// <summary>
        /// 是否是自己的微店
        /// </summary>
        public bool SFZZ { get { return _SFZZ; } }
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

            _WeiDianId = Utils.GetWeiDianId();
            _SFZZ = Utils.SFZZWeiDian();

            if (!(Request.Url.ToString().ToLower().IndexOf("/weidian/shenqing.aspx") > -1))
            {
                if (string.IsNullOrEmpty(_WeiDianId))
                {
                    Response.Redirect("NotFound.aspx");
                }

                var weiDianInfo = new Eyousoft_yhq.BLL.BWeiDian().GetInfo(_WeiDianId);
                if (weiDianInfo == null)
                {
                    Response.Redirect("NotFound.aspx");
                }

                if (weiDianInfo.Status == Eyousoft_yhq.Model.WeiDianStatus.申请中)
                {
                    Response.Redirect("NotFound.aspx?xxlx=1");
                }
            }
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
        /// 验证登录，未登录跳转至登录页面，已登录不做处理
        /// </summary>
        protected void YanZhengLogin()
        {
            if (!_IsLogin) Response.Redirect(LoginUrl);
        }
        #endregion
    }
}
