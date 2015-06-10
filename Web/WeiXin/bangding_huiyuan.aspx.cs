//绑定会员 汪奇志 2015-01-16
//以确定微信用户与系统会员间关系
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiXin
{
    /// <summary>
    /// 绑定会员
    /// </summary>
    public partial class bangding_huiyuan : System.Web.UI.Page
    {
        #region attributes
        /// <summary>
        /// 用户编号
        /// </summary>
        protected string YongHuId = string.Empty;
        /// <summary>
        /// 微信openid
        /// </summary>
        protected string weixin_openid = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            YongHuId = Utils.GetQueryStringValue("yonghuid");
            weixin_openid = Utils.GetQueryStringValue("openid");

            if (string.IsNullOrEmpty(YongHuId) || string.IsNullOrEmpty(weixin_openid)) Utils.RCWE("异常请求");

            var info = new Eyousoft_yhq.BLL.BWeiXin().GetInfo1(YongHuId);

            if (info == null) Utils.RCWE("异常请求");

            if (info.openid != weixin_openid) Utils.RCWE("异常请求");

            if (Utils.GetQueryStringValue("dotype") == "bangding") BangDing();

            if (!string.IsNullOrEmpty(info.HuiYuanId))
            {
                Eyousoft_yhq.BLL.BWeiDian.redirect_huiyuan_weidian(info.HuiYuanId);
            }
        }

        #region private members
        /// <summary>
        /// bangding
        /// </summary>
        void BangDing()
        {
            string txt_u = Utils.GetFormValue("txt_u");
            string txt_p = Utils.GetFormValue("txt_p");
            string huiYuanId;
            int bllRetCode = new Eyousoft_yhq.BLL.BWeiXin().BangDingHuiYuan(YongHuId, weixin_openid, txt_u, txt_p, out huiYuanId);

            if (bllRetCode == 1)
            {
                EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo = null;
                int autoLoginRetCode = Eyousoft_yhq.BLL.MemberLogin.AutoLogin(huiYuanId, out huiYuanInfo);

                if (autoLoginRetCode == 1)
                {
                    Utils.RCWE_AJAX("1", "", huiYuanInfo.WeiDianId);
                }
                else
                {
                    Utils.RCWE_AJAX("异常登录");
                }
            }
            else if (bllRetCode == -98)
            {
                Utils.RCWE_AJAX("-98", "请填写正确的用户名或密码");
            }
            else if (bllRetCode == -97)
            {
                Utils.RCWE_AJAX("-97", "你的会员账号已经绑定过，不能重复绑定。");
            }
            else
            {
                Utils.RCWE_AJAX("0", "异常登录");
            }
        }
        #endregion
    }
}
