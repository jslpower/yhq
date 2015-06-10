using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Domain;
using EyouSoft.Common;
using System.Web.Script.Serialization;

namespace Eyousoft_yhq.Web.WeiXin
{
    /// <summary>
    /// 同步微信用户
    /// </summary>
    public partial class sync_weixin_yonghu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string weixin_appid = "";
            string weixin_secret = "";
            weixin_appid = Utils.GetConfigString("", "YHQAppId").Trim();
            weixin_secret = Utils.GetConfigString("", "YHQAppSecret").Trim();

            if (Utils.GetQueryStringValue("sync") != "1") Utils.RCWE("");

            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = weixin_appid, AppSecret = weixin_secret }
            };

            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Utils.RCWE("获取令牌环失败..");
            }

            GetAttentionsRequest request2 = new GetAttentionsRequest()
            {
                AccessToken = response.AccessToken.AccessToken
            };

            var response2 = mpClient.Execute(request2);
            if (response2.IsError)
            {
                Utils.RCWE("获取关注者列表失败，错误信息为：" + response2.ErrInfo.ErrCode + "-" + response2.ErrInfo.ErrMsg);
            }

            foreach (var item in response2.Attentions.data.openid)
            {
                var info1 = Eyousoft_yhq.Web.BsendMsg.WeiXin.GetUserInfo(item);

                var info = new Eyousoft_yhq.Model.MWeiXinYongHuInfo();
                info.city = info1.City;
                info.country = info1.Country;
                info.createtime = DateTime.Now;
                info.headimgurl = info1.HeadImgUrl;
                info.language = info1.Language;
                info.latesttime = DateTime.Now;
                info.nickname = info1.NickName;
                info.openid = info1.OpenId;
                info.province = info1.Province;
                info.sex = info1.Sex;
                info.subscribe = info1.SubScribe;
                info.subscribe_time = info1.SubscribeTime;
                info.unionid = string.Empty;
                info.YongHuId = Guid.NewGuid().ToString();

                new Eyousoft_yhq.BLL.BWeiXin().YongHu_C(info);
            }

            Utils.RCWE("获取关注者列表成功");
        }
    }
}
