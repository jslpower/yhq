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
using System.Web.Script.Serialization;

namespace Weixin.Mp.Sdk.Request
{
    /// <summary>
    /// 获取关注者列表请求
    /// </summary>
    public class GetAttentionsRequest : RequestBase<GetAttentionsResponse>, IMpRequest<GetAttentionsResponse>
    {
        public string Method
        {
            get
            {
                return "GET";
            }
        }

        /// <summary>
        /// 第一个拉取的OPENID，不填默认从头开始拉取 
        /// </summary>
        public string NextOpenId { get; set; }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}";
            string url = string.Format(urlFormat, AccessToken);
            if (!string.IsNullOrEmpty(NextOpenId))
            {
                url += "&next_openid=" + NextOpenId;
            }
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public GetAttentionsResponse ParseHtmlToResponse(string body)
        {
            GetAttentionsResponse response = new GetAttentionsResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Attentions atts = jsonSerializer.Deserialize<Attentions>(body);
                response.Attentions = atts;
            }
            return response;
        }
    }
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/