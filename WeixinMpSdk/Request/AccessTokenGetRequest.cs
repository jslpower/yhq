/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Domain;
using Weixin.Mp.Sdk.Util;

namespace Weixin.Mp.Sdk.Request
{
    /// <summary>
    /// 获取access_token请求
    /// </summary>
    public class AccessTokenGetRequest : RequestBase<AccessTokenGetResponse>,IMpRequest<AccessTokenGetResponse>
    {

        public string Method
        {
            get
            {
                return "GET";
            }
        }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}";
            Domain.AppIdInfo info = AppIdInfo == null ? GetDefaultAppIdInfo() : AppIdInfo;
            string url = string.Format(urlFormat, "client_credential", info.AppID, info.AppSecret);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }

        public void Validate()
        {

        }

        /// <summary>
        /// 将平台返回的HTML转化成MpResponse对象
        /// </summary>
        /// <param name="body">返回的HTML</param>
        /// <returns></returns>
        public AccessTokenGetResponse ParseHtmlToResponse(string body)
        {
            AccessTokenGetResponse response = new AccessTokenGetResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                AccessTokenInfo token = new AccessTokenInfo()
                {
                    AccessToken = Tools.GetJosnValue(body, "access_token"),
                    ExpiresIn = Convert.ToInt64(Tools.GetJosnValue(body, "expires_in"))
                };
                response.AccessToken = token;
            }
            return response;
        }
    } // class end
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
