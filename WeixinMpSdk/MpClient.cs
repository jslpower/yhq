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
using Weixin.Mp.Sdk.Util;
using Weixin.Mp.Sdk.Request;

namespace Weixin.Mp.Sdk
{
    /// <summary>
    /// 微信公众平台客户端
    /// </summary>
    public class MpClient : IMpClient
    {
        private WebUtils webUtils;

        /// <summary>
        /// 执行微信公众平台API请求
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的微信公众平台请求</param>
        /// <returns>领域对象</returns>
        public T Execute<T>(IMpRequest<T> request) where T : MpResponse
        {
            request.Validate();
            string body;
            webUtils = new WebUtils();
            string url = request.GetReqUrl();

            if (request.Method.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
            {
                if (request.GetType().ToString() == "Weixin.Mp.Sdk.Request.DownloadMediaRequest")
                {
                    body = string.Empty;

                    string fileName = string.Empty;
                    string errHtml = string.Empty;
                    bool isSuc = webUtils.DownloadFile(url, (request as DownloadMediaRequest).SaveDir, out fileName, out errHtml);

                    if (isSuc)
                    {
                        body = fileName;
                    }
                    else
                    {
                        body = errHtml;
                    }
                }
                else
                {
                    body = webUtils.DoGet(url, null);
                }
            }
            else
            {
                //上传接口
                if (request.GetType().ToString() == "Weixin.Mp.Sdk.Request.UploadMediaRequest")
                {
                    Dictionary<string, FileItem> files = new Dictionary<string, FileItem>();
                    FileItem fileItem = new FileItem((request as UploadMediaRequest).FileName);
                    files.Add(System.Guid.NewGuid().ToString(), fileItem);
                    body = webUtils.DoPost(url, request.GetParameters(), files);
                }
                else
                {
                    body = webUtils.DoPost(url, request.SendData);
                }
            }

            if (string.IsNullOrEmpty(body))
            {
                return null;
            }

            T response = request.ParseHtmlToResponse(body);

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
