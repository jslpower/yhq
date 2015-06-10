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

namespace Weixin.Mp.Sdk.Domain
{
    /// <summary>
    /// 发送客服信息基类
    /// </summary>
    public abstract class CustomMessage
    {
        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public abstract string ToJsonString();

        /// <summary>
        /// 普通用户openid 
        /// </summary>
        public string ToUser { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string AccessToken { get; set; }
    }

    /// <summary>
    /// 文本客服信息
    /// </summary>
    public class TextCustomMessage : CustomMessage
    {
        /// <summary>
        /// 文本消息内容 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            string s = "{\"touser\":\"" + ToUser + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + Content.Replace("\"", string.Empty) + "\"}";
            return s;
        }
    }

    /// <summary>
    /// 图片客服信息
    /// </summary>
    public class ImageCustomMessage : CustomMessage
    {
        /// <summary>
        /// 发送的图片的媒体ID
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            string s = "{ \"touser\":\"" + ToUser + "\",\"msgtype\":\"image\",\"image\":{\"media_id\":\"" + MediaId + "\"}}";
            return s;
        }
    }

    /// <summary>
    /// 语音客服信息
    /// </summary>
    public class VoiceCustomMessage : CustomMessage
    {
        /// <summary>
        /// 发送的图片的媒体ID
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            string s = "{\"touser\":\"" + ToUser + "\",\"msgtype\":\"voice\",\"voice\":{\"media_id\":\"" + MediaId + "\"}}";
            return s;
        }
    }

    /// <summary>
    /// 视频客服信息
    /// </summary>
    public class VideoCustomMessage : CustomMessage
    {
        /// <summary>
        /// 发送的视频的媒体ID 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            string s = "{\"touser\":\"" + ToUser + "\",\"msgtype\":\"video\",\"video\":{\"media_id\":\"" + MediaId + "\",\"title\":\"" + Title + "\",\"description\":\"" + Description + "\"}}";
            return s;
        }
    }

    /// <summary>
    /// 音乐客服消息
    /// </summary>
    public class MusicCustomMessage : CustomMessage
    {
        /// <summary>
        /// 音乐标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        public string MusicUrl { get; set; }

        /// <summary>
        /// 高品质音乐链接，wifi环境优先使用该链接播放音乐
        /// </summary>
        public string HqMusicUrl { get; set; }

        /// <summary>
        /// 缩略图的媒体ID
        /// </summary>
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            string s = "{\"touser\":\"" + ToUser + "\",\"msgtype\":\"music\",\"music\":{\"title\":\"" + Title + "\",\"description\":\"" + Description + "\",\"musicurl\":\"" + MusicUrl + "\",\"hqmusicurl\":\"" + HqMusicUrl + "\",\"thumb_media_id\":\"" + ThumbMediaId + "\" }}";
            return s;
        }
    }

    /// <summary>
    /// 图文客服消息
    /// </summary>
    public class NewsCustomMessage : CustomMessage
    {
        /// <summary>
        /// 消息条目
        /// </summary>
        public List<NewsCustomMessageItem> Articles { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            string s1 = string.Empty;
            if (Articles != null && Articles.Count > 0)
            {
                for (int i = 1; i <= Articles.Count; i++)
                {
                    if (i > 10)
                    {
                        break;
                    }
                    if (i > 1)
                    {
                        s1 += ",";
                    }
                    s1 += Articles[i - 1].ToJsonString();
                }
            }


            string s2 = "{\"touser\":\"" + ToUser + "\",\"msgtype\":\"news\",\"news\":{\"articles\": [" + s1 + "]}}";


            return s2;
        }
    }

    /// <summary>
    /// 图文客服消息条目
    /// </summary>
    public class NewsCustomMessageItem
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 将对象转化为Json字符串
        /// </summary>
        /// <returns></returns>
        public string ToJsonString()
        {
            string s = "{\"title\":\"" + Title.Replace("\"", string.Empty) + "\",\"description\":\"" + Description.Replace("\"", string.Empty) + "\",\"url\":\"" + Url + "\",\"picurl\":\"" + PicUrl + "\"}";

            return s;
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
