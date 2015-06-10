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
    /// 消息类型
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// 未知消息类型
        /// </summary>
        UnKnown,

        /// <summary>
        /// 文本消息
        /// </summary>
        Text,

        /// <summary>
        /// 图片消息
        /// </summary>
        Image,

        /// <summary>
        /// 语音消息
        /// </summary>
        Voice,

        /// <summary>
        /// 语音识别结果消息
        /// </summary>
        VoiceResult,

        /// <summary>
        /// 视频消息
        /// </summary>
        Video,

        /// <summary>
        /// 地理位置消息
        /// </summary>
        Location,

        /// <summary>
        /// 链接消息
        /// </summary>
        Link,

        /// <summary>
        /// 事件推送消息
        /// </summary>
        Event
    }

    /// <summary>
    /// 接收到的消息基类
    /// </summary>
    public class ReceiveMessageBase
    {
        /// <summary>
        /// 消息原文
        /// </summary>
        public string MessageBody { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType MsgType { get; set; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型） 
        /// </summary>
        public long CreateTime { get; set; }

    }
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
