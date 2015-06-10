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
    /// 上传多媒体文件回应信息
    /// </summary>
    public class UploadMediaResponse : MpResponse
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb，主要用于视频与音乐格式的缩略图） 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 媒体文件上传后，获取时的唯一标识 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 媒体文件上传时间戳
        /// </summary>
        public string CreatedAt { get; set; }

       // {"type":"image","media_id":"RuYGs6yryePCLvsS3NSvR0BnHmNjBBPg91oa4PNZ1xjpUZvYV71UmRvkDg0uDlMh","created_at":1390135096}
    }
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
