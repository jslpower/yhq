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
    /// 上传多媒体文件请求
    /// </summary>
    public class UploadMediaRequest : RequestBase<UploadMediaResponse>, IMpRequest<UploadMediaResponse>
    {
        public string Method
        {
            get
            {
                return "POST";
            }
        }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 多媒体文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
            string url = string.Format(urlFormat, AccessToken, Type);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public UploadMediaResponse ParseHtmlToResponse(string body)
        {
            UploadMediaResponse response = new UploadMediaResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                response.Type = Tools.GetJosnValue(body, "type");
                response.MediaId = Tools.GetJosnValue(body, "media_id");
                if (string.IsNullOrEmpty(response.MediaId))
                {
                    response.MediaId = Tools.GetJosnValue(body, "thumb_media_id");
                }
                response.CreatedAt = Tools.GetJosnValue(body, "created_at");
                // {"type":"image","media_id":"RuYGs6yryePCLvsS3NSvR0BnHmNjBBPg91oa4PNZ1xjpUZvYV71UmRvkDg0uDlMh","created_at":1390135096}
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
