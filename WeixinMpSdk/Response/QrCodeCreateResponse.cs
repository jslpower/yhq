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

namespace Weixin.Mp.Sdk.Response
{
    /// <summary>
    /// 创建二维码回应信息
    /// </summary>
    public class QrCodeCreateResponse : MpResponse
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。 
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 二维码的有效时间，以秒为单位。最大不超过1800
        /// </summary>
        public int ExpireSeconds { get; set; }

        /// <summary>
        /// 二维码链接Url
        /// </summary>
        public string QrCodeUrl
        {
            get
            {
                if (string.IsNullOrEmpty(Ticket))
                {
                    return string.Empty;
                }
                else
                {
                    return "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + Ticket;
                }
            }
        }

        /// <summary>
        /// 二维码本地存储目录（如果请求中设置了本地存储目录的话，则会生成本地文件路径）
        /// </summary>
        public string LocalFilePath
        {
            get;
            set;
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
