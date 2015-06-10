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

namespace Weixin.Mp.Sdk.Domain
{
    /// <summary>
    /// 被动响应消息类
    /// </summary>
    public abstract class ReplyMessage
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public long CreateTime { get; set; }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public abstract  string ToXmlString();
    }

    /// <summary>
    /// 被动响应文本消息
    /// </summary>
    public class TextReplyMessage : ReplyMessage
    {
        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示） 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public override string ToXmlString()
        {
            string s = "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>";
            s = string.Format(s,
                ToUserName ?? string.Empty,
                FromUserName ?? string.Empty,
                CreateTime.ToString(),
                "text",
                Content ?? string.Empty
                );
            return s;
        }
    }

    /// <summary>
    /// 被动响应图片消息
    /// </summary>
    public class ImageReplyMessage : ReplyMessage
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public override string ToXmlString()
        {
            string s = @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<Image>
<MediaId><![CDATA[{4}]]></MediaId>
</Image>
</xml>";
            return string.Format(s, ToUserName, FromUserName, CreateTime, "image", MediaId);
        }
    }

    /// <summary>
    /// 被动响应语音消息
    /// </summary>
    public class VoiceReplyMessage : ReplyMessage
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的id 
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public override string ToXmlString()
        {
            string s = @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<Voice>
<MediaId><![CDATA[{4}]]></MediaId>
</Voice>
</xml>";
            return string.Format(s, ToUserName, FromUserName, CreateTime, "voice", MediaId);
        }
    }

    /// <summary>
    /// 被动响应视频消息
    /// </summary>
    public class VideoReplyMessage : ReplyMessage
    {
        /// <summary>
        /// 通过上传多媒体文件，得到的id
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
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public override string ToXmlString()
        {
            string s = @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<Video>
<MediaId><![CDATA[{4}]]></MediaId>
<Title><![CDATA[{5}]]></Title>
<Description><![CDATA[{6}]]></Description>
</Video> 
</xml>";
            Logger.WriteTxtLog(string.Format(s, ToUserName, FromUserName, CreateTime, "video", MediaId, Title, Description), AppDomain.CurrentDomain.BaseDirectory + "1.txt");
            return string.Format(s, ToUserName, FromUserName, CreateTime, "video", MediaId, Title, Description);
        }
    }

    /// <summary>
    /// 被动响应音乐消息
    /// </summary>
    public class MusicReplyMessage : ReplyMessage
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
        public string MusicURL { get; set; }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐 
        /// </summary>
        public string HQMusicUrl { get; set; }

        /// <summary>
        /// 缩略图的媒体id，通过上传多媒体文件，得到的id
        /// </summary>
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public override string ToXmlString()
        {
            string s = @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<Music>
<Title><![CDATA[{4}]]></Title>
<Description><![CDATA[{5}]]></Description>
<MusicUrl><![CDATA[{6}]]></MusicUrl>
<HQMusicUrl><![CDATA[{7}]]></HQMusicUrl>
<ThumbMediaId><![CDATA[{8}]]></ThumbMediaId>
</Music>
</xml>";
            return string.Format(s, ToUserName, FromUserName, CreateTime, "music", Title, Description, MusicURL, HQMusicUrl, ThumbMediaId);
        }
    }

    /// <summary>
    /// 被动响应图文消息
    /// </summary>
    public class NewsReplyMessage : ReplyMessage
    {
        public int ArticleCount
        {
            get
            {
                return Articles == null ? 0 : Articles.Count;
            }
        }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public override string ToXmlString()
        {
            string s1 = string.Empty;
            if (Articles != null && Articles.Count > 0)
            {
                foreach (var item in Articles)
                {
                    s1 += item.ToXmlString();
                }
            }

            string s = @"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[{3}]]></MsgType>
<ArticleCount>{4}</ArticleCount>
<Articles>
{5}
</Articles>
</xml> ";
            return string.Format(s, ToUserName, FromUserName, CreateTime, "news", ArticleCount, s1);
        }

        /// <summary>
        /// 图文条目
        /// </summary>
        public List<NewsReplyMessageItem> Articles { get; set; }
    }

    public class NewsReplyMessageItem
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
        /// 图片URL
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 链接URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 将对象转化为Xml消息
        /// </summary>
        /// <returns></returns>
        public string ToXmlString()
        {
            string s = @"<item>
<Title><![CDATA[{0}]]></Title> 
<Description><![CDATA[{1}]]></Description>
<PicUrl><![CDATA[{2}]]></PicUrl>
<Url><![CDATA[{3}]]></Url>
</item>";

            return string.Format(s, Title, Description, PicUrl, Url);
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