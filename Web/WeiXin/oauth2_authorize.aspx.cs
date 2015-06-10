//微信网页授权 汪奇志 2014-01-15
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiXin
{
    /// <summary>
    /// 微信网页授权
    /// </summary>
    public partial class oauth2_authorize : System.Web.UI.Page
    {
        string weixin_appid = "";
        string weixin_secret = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            weixin_appid = Utils.GetConfigString("", "YHQAppId").Trim();
            weixin_secret = Utils.GetConfigString("", "YHQAppSecret").Trim();

            string code = Utils.GetQueryStringValue("code");
            string state = Utils.GetQueryStringValue("state");

            if (string.IsNullOrEmpty(state)) Utils.RCWE("异常请求");
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(state)) Utils.RCWE("异常请求");

            if (string.IsNullOrEmpty(code) && state == "weidian_snsapi_base") redirect_weixin_snsapi_userinfo();

            Response.Write("code:" + code+"<br/>");
            Response.Write("state:" + state+"<br/>");

            var access_token_info = get_weixin_oauth2_access_token_info(code);

            if (access_token_info == null) Utils.RCWE("get weixin_oauth2_access_token_info is null<br/>");

            Response.Write("openid:" + access_token_info.openid+"<br/>");

            var info = new Eyousoft_yhq.BLL.BWeiXin().GetInfo2(access_token_info.openid);

            if (info == null && state == "weidian_snsapi_userinfo")
            {
                var snsapi_userinfo = get_weixin_oauth2_snsapi_userinfo(access_token_info.access_token, access_token_info.openid);
                info = handler_oauth2_snsapi_userinfo(snsapi_userinfo);
            }

            if (info == null)
            {
                Response.Write("微信授权失败<br/>");
            }

            Response.Write("nickname:" + info.nickname+"<br/>");

            Response.Write("huiyuanid:" + info.HuiYuanId + "<br/>");

            if (string.IsNullOrEmpty(info.HuiYuanId))
            {
                redirect_bangding_huiyuan(info.YongHuId, info.openid);
            }

            Eyousoft_yhq.BLL.BWeiDian.redirect_huiyuan_weidian(info.HuiYuanId, info.openid);
        }

        #region private members
        /// <summary>
        /// get weixin oauth2 access_token info
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        weixin_oauth2_access_token_info get_weixin_oauth2_access_token_info(string code)
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            url = string.Format(url, weixin_appid, weixin_secret, code);

            string cookies = string.Empty;
            var weixin_oauth2_access_token_json = EyouSoft.Toolkit.request.create(url, "", EyouSoft.Toolkit.Method.GET, "", ref cookies, false);
            if (string.IsNullOrEmpty(weixin_oauth2_access_token_json)) return null;

            var error = Newtonsoft.Json.JsonConvert.DeserializeObject<weixin_oauth2_error_info>(weixin_oauth2_access_token_json);

            if (error.errcode != 0) return null;

            var info = Newtonsoft.Json.JsonConvert.DeserializeObject<weixin_oauth2_access_token_info>(weixin_oauth2_access_token_json);

            return info;
        }

        /// <summary>
        /// get weixin oauth2 refresh_token info
        /// </summary>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        weixin_oauth2_refresh_token_info get_weixin_oauth2_refresh_token_info(string refresh_token)
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}";
            url = string.Format(url, weixin_appid, refresh_token);

            string cookies = string.Empty;
            var weixin_oauth2_refresh_token_json = EyouSoft.Toolkit.request.create(url, "", EyouSoft.Toolkit.Method.GET, "", ref cookies, false);
            if (string.IsNullOrEmpty(weixin_oauth2_refresh_token_json)) return null;

            var error = Newtonsoft.Json.JsonConvert.DeserializeObject<weixin_oauth2_error_info>(weixin_oauth2_refresh_token_json);

            if (error.errcode != 0) return null;

            var info = Newtonsoft.Json.JsonConvert.DeserializeObject<weixin_oauth2_refresh_token_info>(weixin_oauth2_refresh_token_json);

            return info;
        }

        /// <summary>
        /// redirect weixin snsapi_userinfo
        /// </summary>
        void redirect_weixin_snsapi_userinfo()
        {
            string _url = "https://open.weixin.qq.com/connect/oauth2/authorize?";
            _url += "appid=" + weixin_appid;
            _url += "&redirect_uri=http://www.4008005216.com/WeiXin/oauth2_authorize.aspx";
            _url += "&response_type=code";
            _url += "&scope=snsapi_base";
            _url += "&state=weidian_snsapi_userinfo";
            _url += "#wechat_redirect";

            Response.Redirect(_url);
        }

        /// <summary>
        /// get weixin oauth2 snsapi_userinfo
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        weixin_oauth2_snsapi_userinfo get_weixin_oauth2_snsapi_userinfo(string access_token,string openid)
        {
            string url = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";
            url = string.Format(url, access_token,openid);

            string cookies = string.Empty;
            var weixin_oauth2_snsapi_userinfo_json = EyouSoft.Toolkit.request.create(url, "", EyouSoft.Toolkit.Method.GET, "", ref cookies, false);
            if (string.IsNullOrEmpty(weixin_oauth2_snsapi_userinfo_json)) return null;

            var error = Newtonsoft.Json.JsonConvert.DeserializeObject<weixin_oauth2_error_info>(weixin_oauth2_snsapi_userinfo_json);

            if (error.errcode != 0) return null;

            var info = Newtonsoft.Json.JsonConvert.DeserializeObject<weixin_oauth2_snsapi_userinfo>(weixin_oauth2_snsapi_userinfo_json);

            return info;
        }

        /// <summary>
        /// handler oauth2 snsapi_userinfo
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Eyousoft_yhq.Model.MWeiXinYongHuInfo handler_oauth2_snsapi_userinfo(weixin_oauth2_snsapi_userinfo info)
        {
            var info1 = new Eyousoft_yhq.Model.MWeiXinYongHuInfo();

            info1.city = info.city;
            info1.country = info.country;
            info1.createtime = DateTime.Now;
            info1.headimgurl = info.headimgurl;
            info1.language = "zh_CN";
            info1.latesttime = DateTime.Now;
            info1.nickname = info.nickname;
            info1.openid = info.openid;
            info1.province = info.province;
            info1.sex = info.sex;
            info1.subscribe = "0";
            info1.subscribe_time = "";
            info1.unionid = string.Empty;
            info1.YongHuId = Guid.NewGuid().ToString();
            info1.LeiXing = 1;

            new Eyousoft_yhq.BLL.BWeiXin().YongHu_C(info1);

            return info1;
        }

        /// <summary>
        /// redirect bangding huiyuan
        /// </summary>
        /// <param name="yongHuId"></param>
        /// <param name="openid"></param>
        void redirect_bangding_huiyuan(string yongHuId,string openid)
        {
            string url = string.Format("/weixin/bangding_huiyuan.aspx?yonghuid={0}&openid={1}",yongHuId,openid);
            Response.Clear();
            Server.Transfer(url);
            Response.End();
            //Response.Redirect(url);
        }
        #endregion
    }

    #region weixin oauth2 access_token info
    /// <summary>
    /// weixin oauth2 access_token info
    /// </summary>
    public class weixin_oauth2_access_token_info
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }
    #endregion
    
    #region weixin oauth2 refresh_token info
    /// <summary>
    /// weixin oauth2 refresh_token info
    /// </summary>
    public class weixin_oauth2_refresh_token_info
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }
    #endregion

    #region weixin oauth2 snsapi_userinfo
    /// <summary>
    /// weixin oauth2 snsapi_userinfo
    /// </summary>
    public class weixin_oauth2_snsapi_userinfo
    {
        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string privilege { get; set; }
        public string unionid { get; set; }
    }
    #endregion

    #region weixin oauth2 error info
    /// <summary>
    /// weixin oauth2 error info
    /// </summary>
    public class weixin_oauth2_error_info
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
    #endregion
}

/*
https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx935e1ca713dff84f&redirect_uri=http://www.4008005216.com/WeiXin/oauth2_authorize.aspx&response_type=code&scope=snsapi_base&state=weidian_snsapi_base#wechat_redirect
https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx935e1ca713dff84f&redirect_uri=http://www.4008005216.com/WeiXin/oauth2_authorize.aspx&response_type=code&scope=snsapi_base&state=weidian_snsapi_userinfo#wechat_redirect
 */
