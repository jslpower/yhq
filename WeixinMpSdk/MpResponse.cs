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
using Weixin.Mp.Sdk.Domain;
using Weixin.Mp.Sdk.Util;

namespace Weixin.Mp.Sdk
{
    [Serializable]
    public abstract class MpResponse
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrInfo ErrInfo { get; set; }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public string ReqUrl { get; set; }

        /// <summary>
        /// 响应结果是否错误
        /// </summary>
        public bool IsError
        {
            get
            {
                if (ErrInfo == null)
                {
                    return false;
                }
                 return true;
            }
        }

        /// <summary>
        /// 判断是否返回了错误信息
        /// </summary>
        /// <returns></returns>
        internal bool HasError()
        {
            if (string.IsNullOrEmpty(Body))
            {
                return false;
            }
            string html = Body.Trim().ToLower();
            
            if (html.StartsWith("{\"errcode\"", StringComparison.InvariantCultureIgnoreCase))
            {
                if (Convert.ToInt64(Tools.GetJosnValue(Body, "errcode")) == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取错误代码和错误信息
        /// </summary>
        /// <returns></returns>
        internal ErrInfo GetErrInfo()
        {
           // {"errcode":40013,"errmsg":"invalid appid"}
            Domain.ErrInfo err = new ErrInfo()
            {
                ErrCode = Convert.ToInt64(Tools.GetJosnValue(Body, "errcode")),
                ErrMsg = Tools.GetJosnValue(Body, "errmsg")
            };
            return err;
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
