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
using System.Web.Security;
using Weixin.Mp.Sdk.Domain;
using System.IO;
using System.Xml;
using Weixin.Mp.Sdk.Util;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;

namespace Weixin.Mp.Sdk
{
    /// <summary>
    /// 消息处理类
    /// </summary>
    public class MessageHandler
    {
        #region 校验消息真实性

        /// <summary>
        /// 校验消息真实性
        /// </summary>
        /// <param name="token">用户在公众平台填写的token</param>
        /// <returns></returns>
        public static bool CheckSignature(string token)
        {

            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"] == null ? "" : System.Web.HttpContext.Current.Request.QueryString["signature"].Trim();
            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"] == null ? "" : System.Web.HttpContext.Current.Request.QueryString["timestamp"].Trim();
            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"] == null ? "" : System.Web.HttpContext.Current.Request.QueryString["nonce"].Trim();

            string[] arrTmp = { token, timestamp, nonce };
            Array.Sort(arrTmp);
            string tmpStr = string.Join("", arrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");//对该字符串进行sha1加密
            tmpStr = tmpStr.ToLower();//对字符串中的字母部分进行小写转换，非字母字符不作处理
            return tmpStr == signature; //开发者获得加密后的字符串可与signature对比

        }
        #endregion

        #region 第一次接入时验证

        /// <summary>
        /// 第一次接入时验证
        /// </summary>
        /// <param name="token">用户在公众平台填写的token</param>
        public static void Valid(string token)
        {
            if (System.Web.HttpContext.Current.Request.QueryString["echoStr"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("Null");
                System.Web.HttpContext.Current.Response.End();
                return;
            }
            string echoStr = System.Web.HttpContext.Current.Request.QueryString["echoStr"].ToString();
            if (CheckSignature(token))
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    System.Web.HttpContext.Current.Response.Write(echoStr);
                    System.Web.HttpContext.Current.Response.End();
                    return;
                }
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write(System.Guid.NewGuid().ToString());
                System.Web.HttpContext.Current.Response.End();
            }
        }
        #endregion



        #region 将公众平台POST过来的数据转化成实体对象

        /// <summary>
        /// 将公众平台POST过来的数据转化成实体对象
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ReceiveMessageBase ConvertMsgToObject(string token)
        {
            if (!CheckSignature(token))
            {
                return null;
            }
            string msgBody = string.Empty;
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            msgBody = Encoding.UTF8.GetString(b);

            if (string.IsNullOrEmpty(msgBody))
            {
                return null;
            }

            XmlDocument doc = null;

            MsgType msgType = MsgType.UnKnown;
            EventType eventType = EventType.UnKnown;
            ReceiveMessageBase msg = new ReceiveMessageBase();
            msg.MsgType = msgType;
            msg.MessageBody = msgBody;
            XmlNode node = null;
            XmlNode tmpNode = null;

            try
            {

                doc = new XmlDocument();
                doc.LoadXml(msgBody);//读取XML字符串
                XmlElement rootElement = doc.DocumentElement;
                XmlNode msgTypeNode = rootElement.SelectSingleNode("MsgType");//获取字符串中的消息类型

                node = rootElement.SelectSingleNode("FromUserName");
                if (node != null)
                {
                    msg.FromUserName = node.InnerText;
                }
                node = rootElement.SelectSingleNode("ToUserName");
                if (node != null)
                {
                    msg.ToUserName = node.InnerText;
                }
                node = rootElement.SelectSingleNode("CreateTime");
                if (node != null)
                {
                    msg.CreateTime = Convert.ToInt64(node.InnerText);
                }

                #region 获取具体的消息对象

                string strMsgType = msgTypeNode.InnerText;
                string msgId = string.Empty;
                string content = string.Empty;

                tmpNode = rootElement.SelectSingleNode("MsgId");
                if (tmpNode != null)
                {
                    msgId = tmpNode.InnerText.Trim();
                }

                switch (strMsgType)
                {
                    case "text":
                        msgType = MsgType.Text;

                        tmpNode = rootElement.SelectSingleNode("Content");
                        if (tmpNode != null)
                        {
                            content = tmpNode.InnerText.Trim();
                        }
                        TextReceiveMessage txtMsg = new TextReceiveMessage()
                        {
                            CreateTime = msg.CreateTime,
                            FromUserName = msg.FromUserName,
                            MessageBody = msg.MessageBody,
                            MsgType = msgType,
                            ToUserName = msg.ToUserName,
                            MsgId = Convert.ToInt64(msgId),
                            Content = content
                        };

                        return txtMsg;
                    case "image":
                        msgType = MsgType.Image;

                        ImageReceiveMessage imgMsg = new ImageReceiveMessage()
                        {
                            CreateTime = msg.CreateTime,
                            FromUserName = msg.FromUserName,
                            MessageBody = msg.MessageBody,
                            MsgId = Convert.ToInt64(msgId),
                            MsgType = msgType,
                            ToUserName = msg.ToUserName,
                            MediaId = rootElement.SelectSingleNode("MediaId").InnerText,
                            PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText
                        };

                        return imgMsg;
                    case "voice":
                        msgType = MsgType.Voice;
                        XmlNode node1 = rootElement.SelectSingleNode("Recognition");
                        if (node1 != null)
                        {
                            msgType = MsgType.VoiceResult;
                        }

                        VoiceReceiveMessage voiceMsg = new VoiceReceiveMessage()
                        {
                            CreateTime = msg.CreateTime,
                            FromUserName = msg.FromUserName,
                            ToUserName = msg.ToUserName,
                            MessageBody = msg.MessageBody,
                            MsgId = Convert.ToInt64(msgId),
                            MsgType = msgType,
                            Recognition = node1 == null ? string.Empty : node1.InnerText.Trim(),
                            Format = rootElement.SelectSingleNode("Format").InnerText,
                            MediaId = rootElement.SelectSingleNode("MediaId").InnerText
                        };

                        return voiceMsg;

                    case "video":
                        msgType = MsgType.Video;

                        VideoReceiveMessage videoMsg = new VideoReceiveMessage()
                        {
                            CreateTime = msg.CreateTime,
                            FromUserName = msg.FromUserName,
                            MediaId = rootElement.SelectSingleNode("MediaId").InnerText,
                            MessageBody = msg.MessageBody,
                            MsgId = Convert.ToInt64(msgId),
                            MsgType = msgType,
                            ToUserName = msg.ToUserName,
                            ThumbMediaId = rootElement.SelectSingleNode("ThumbMediaId").InnerText
                        };

                        return videoMsg;
                    case "location":
                        msgType = MsgType.Location;

                        LocationReceiveMessage locationMsg = new LocationReceiveMessage()
                        {
                            CreateTime = msg.CreateTime,
                            FromUserName = msg.FromUserName,
                            MessageBody = msg.MessageBody,
                            MsgId = Convert.ToInt64(msgId),
                            MsgType = msgType,
                            ToUserName = msg.ToUserName,
                            Label = rootElement.SelectSingleNode("Label").InnerText,
                            Location_X = rootElement.SelectSingleNode("Location_X").InnerText,
                            Location_Y = rootElement.SelectSingleNode("Location_Y ").InnerText,
                            Scale = rootElement.SelectSingleNode("Scale").InnerText
                        };

                        return locationMsg;
                    case "link":
                        msgType = MsgType.Link;

                        LinkReceiveMessage linkMsg = new LinkReceiveMessage()
                        {
                            CreateTime = msg.CreateTime,
                            Description = rootElement.SelectSingleNode("Description").InnerText,
                            FromUserName = msg.FromUserName,
                            MessageBody = msg.MessageBody,
                            MsgId = Convert.ToInt64(msgId),
                            MsgType = msgType,
                            Title = rootElement.SelectSingleNode("Title").InnerText,
                            ToUserName = msg.ToUserName,
                            Url = rootElement.SelectSingleNode("Url ").InnerText
                        };

                        return linkMsg;
                    case "event":
                        msgType = MsgType.Event;
                        eventType = EventType.UnKnown;
                        msg.MsgType = msgType;

                        XmlNode eventNode = rootElement.SelectSingleNode("Event");
                        if (eventNode != null)
                        {

                             switch (eventNode.InnerText)
                            {
                                case "subscribe":
                                    eventType = EventType.Subscribe;
                                    tmpNode = rootElement.SelectSingleNode("EventKey");
                                    var tmp = rootElement.SelectSingleNode("Ticket");
                                    if (tmpNode != null && !string.IsNullOrEmpty(tmpNode.InnerText))  //&& tmpNode.InnerText.StartsWith("qrscene_")
                                    {
                                        //扫描二维码关注事件
                                        ScanSubscribeEventMessage scanSubEvt = new ScanSubscribeEventMessage()
                                        {
                                            CreateTime = msg.CreateTime,
                                            EventKey = rootElement.SelectSingleNode("EventKey").InnerText,
                                            EventType = EventType.Subscribe,
                                            FromUserName = msg.FromUserName,
                                            MessageBody = msg.MessageBody,
                                            MsgType = msgType,
                                            ToUserName = msg.ToUserName,
                                            Ticket = rootElement.SelectSingleNode("Ticket").InnerText
                                        };
                                        return scanSubEvt;
                                    }
                                    else
                                    {
                                        //普通关注事件
                                        SubscribeEventMessage subEvt = new SubscribeEventMessage()
                                        {
                                            CreateTime = msg.CreateTime,
                                            EventType = EventType.Subscribe,
                                            FromUserName = msg.FromUserName,
                                            MessageBody = msg.MessageBody,
                                            MsgType = msgType,
                                            ToUserName = msg.ToUserName
                                        };
                                        return subEvt;
                                    }
                                case "unsubscribe":
                                    eventType = EventType.UnSubscribe;

                                    UnSubscribeEventMessage unSubEvt = new UnSubscribeEventMessage()
                                    {
                                        CreateTime = msg.CreateTime,
                                        EventType = eventType,
                                        FromUserName = msg.FromUserName,
                                        MessageBody = msg.MessageBody,
                                        MsgType = msgType,
                                        ToUserName = msg.ToUserName
                                    };

                                    return unSubEvt;
                                case "scan":
                                    eventType = EventType.Scan;

                                    ScanEventMessage scanEvt = new ScanEventMessage()
                                    {
                                        CreateTime = msg.CreateTime,
                                        EventKey = rootElement.SelectSingleNode("EventKey").InnerText,
                                        EventType = eventType,
                                        FromUserName = msg.FromUserName,
                                        MessageBody = msg.MessageBody,
                                        MsgType = msgType,
                                        Ticket = rootElement.SelectSingleNode("Ticket").InnerText,
                                        ToUserName = msg.ToUserName
                                    };

                                    return scanEvt;
                                case "LOCATION":
                                    eventType = EventType.Location;

                                    UploadLocationEventMessage locationEvt = new UploadLocationEventMessage()
                                    {
                                        CreateTime = msg.CreateTime,
                                        EventType = eventType,
                                        FromUserName = msg.FromUserName,
                                        Latitude = rootElement.SelectSingleNode("Latitude").InnerText,
                                        Longitude = rootElement.SelectSingleNode("Longitude").InnerText,
                                        MessageBody = msg.MessageBody,
                                        MsgType = msgType,
                                        Precision = rootElement.SelectSingleNode("Precision").InnerText,
                                        ToUserName = msg.ToUserName
                                    };

                                    return locationEvt;
                                case "CLICK":
                                    eventType = EventType.Click;

                                    MenuEventMessage menuEvt = new MenuEventMessage()
                                    {
                                        CreateTime = msg.CreateTime,
                                        EventKey = rootElement.SelectSingleNode("EventKey").InnerText,
                                        EventType = eventType,
                                        FromUserName = msg.FromUserName,
                                        MessageBody = msg.MessageBody,
                                        MsgType = msgType,
                                        ToUserName = msg.ToUserName
                                    };

                                    return menuEvt;
                                default:
                                    EventMessage evtMsg = new EventMessage()
                                    {
                                        CreateTime = msg.CreateTime,
                                        EventType = EventType.UnKnown,
                                        FromUserName = msg.FromUserName,
                                        MessageBody = msg.MessageBody,
                                        MsgType = MsgType.Event,
                                        ToUserName = msg.ToUserName
                                    };
                                    return evtMsg;
                            }
                        }

                        break;
                }
                msg.MsgType = msgType;
                #endregion
            }
            finally
            {
                if (doc != null)
                {
                    doc = null;
                }
            }

            msg.MsgType = msgType;
            return msg;
        }
        #endregion

        #region 发送被动响应消息

        /// <summary>
        /// 发送被动响应消息(根据传递的参数是对应不同的子类发送不同的子类消息)
        /// </summary>
        /// <param name="msg">发送的消息内容</param>
        /// <returns>是否成功</returns>
        public static void SendReplyMessage(ReplyMessage msg)
        {
            System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
        }

        /// <summary>
        /// 发送被动响应文本消息
        /// </summary>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="content">文本内容</param>
        public static void SendTextReplyMessage(string fromUserName, string toUserName, string content)
        {
            TextReplyMessage msg = new TextReplyMessage()
            {
                CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                FromUserName = fromUserName,
                ToUserName = toUserName,
                Content = content
            };
            System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
        }

        /// <summary>
        /// 发送被动响应图片信息，图片上传失败，则返回失败
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="imgPath">图片绝对路径(最大128K，目前只支持jpg格式)</param>
        /// <returns>是否成功</returns>
        public static bool SendImageReplyMessage(string accessToken, string fromUserName, string toUserName, string imgPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "image",
                FileName = imgPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                ImageReplyMessage msg = new ImageReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    MediaId = response.MediaId
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        /// <summary>
        /// 发送被动响应语音消息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="voicePath">语音文件路径(支持AMR\MP3,最大256K，播放长度不超过60s)</param>
        /// <returns>是否成功</returns>
        public static bool SendVoiceReplyMessage(string accessToken, string fromUserName, string toUserName, string voicePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "voice",
                FileName = voicePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                VoiceReplyMessage msg = new VoiceReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    MediaId = response.MediaId
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        /// <summary>
        /// 发送被动响应视频消息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="videoPath">视频文件路径(1MB，支持MP4格式)</param>
        /// <returns>是否成功</returns>
        public static bool SendVideoReplyMessage(string accessToken, string fromUserName, string toUserName, string title, string description, string videoPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "video",
                FileName = videoPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                VideoReplyMessage msg = new VideoReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    MediaId = response.MediaId,
                    Description = description,
                    Title = title
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        /// <summary>
        /// 发送被动响应音乐消息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="fromUserName">发送方</param>
        /// <param name="toUserName">接收方</param>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="musicUrl">音乐链接</param>
        /// <param name="hqMusicUrl">高质量音乐链接</param>
        /// <param name="thumbMediaFilePath">缩略图文件路径(64KB，支持JPG格式 )</param>
        /// <returns>是否成功</returns>
        public static bool SendMusicReplyMessage(string accessToken, string fromUserName, string toUserName, string title, string description, string musicUrl, string hqMusicUrl, string thumbMediaFilePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "thumb",
                FileName = thumbMediaFilePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                MusicReplyMessage msg = new MusicReplyMessage()
                {
                    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                    FromUserName = fromUserName,
                    ToUserName = toUserName,
                    Description = description,
                    Title = title,
                    ThumbMediaId = response.MediaId,
                    HQMusicUrl = hqMusicUrl,
                    MusicURL = musicUrl
                };
                System.Web.HttpContext.Current.Response.Write(msg.ToXmlString());
                return true;
            }
        }

        #endregion

        #region 发送客服信息

        /// <summary>
        /// 发送客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="msg">客服消息</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendCustomMessage(string accessToken, CustomMessage msg)
        {
            IMpClient mpClient = new MpClient();
            SendCustomMessageRequest request = new SendCustomMessageRequest()
            {
                AccessToken = accessToken,
                SendData = msg.ToJsonString()
            };
            SendCustomMessageResponse response = mpClient.Execute(request);
            return response;
        }

        /// <summary>
        /// 发送文本客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="content">信息内容</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendTextCustomMessage(string accessToken, string toUser, string content)
        {
            TextCustomMessage msg = new TextCustomMessage()
            {
                AccessToken = accessToken,
                ToUser = toUser,
                Content = content,
                MsgType = "text"
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送图片客服消息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="imgPath">图片路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendImageCustomMessage(string accessToken, string toUser, string imgPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "image",
                FileName = imgPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            ImageCustomMessage msg = new ImageCustomMessage()
            {
                AccessToken = accessToken,
                MediaId = response.MediaId,
                MsgType = "image",
                ToUser = toUser
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送语音客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="voicePath">语音文件路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendVoiceCustomMessage(string accessToken, string toUser, string voicePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "voice",
                FileName = voicePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            VoiceCustomMessage msg = new VoiceCustomMessage()
            {
                AccessToken = accessToken,
                MediaId = response.MediaId,
                MsgType = "voice",
                ToUser = toUser
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送视频客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="title">视频标题</param>
        /// <param name="description">视频描述</param>
        /// <param name="videoPath">视频文件路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendVideoCustomMessage(string accessToken, string toUser, string title, string description, string videoPath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "video",
                FileName = videoPath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            VideoCustomMessage msg = new VideoCustomMessage()
            {
                AccessToken = accessToken,
                MediaId = response.MediaId,
                MsgType = "video",
                ToUser = toUser,
                Description = description,
                Title = title
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送音乐客服信息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="toUser">接收方</param>
        /// <param name="title">音乐标题</param>
        /// <param name="description">音乐描述</param>
        /// <param name="musicUrl">音乐地址</param>
        /// <param name="hqMusicUrl">高质量音乐地址</param>
        /// <param name="thumbMediaFilePath">音乐缩略图路径</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendMusicCustomMessage(string accessToken, string toUser, string title, string description, string musicUrl, string hqMusicUrl, string thumbMediaFilePath)
        {
            IMpClient mpClient = new MpClient();
            UploadMediaRequest request = new UploadMediaRequest()
            {
                AccessToken = accessToken,
                Type = "thumb",
                FileName = thumbMediaFilePath
            };

            UploadMediaResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                SendCustomMessageResponse response2 = new SendCustomMessageResponse()
                {
                    Body = response.Body,
                    ErrInfo = response.ErrInfo,
                    ReqUrl = response.ReqUrl
                };
                return response2;
            }
            MusicCustomMessage msg = new MusicCustomMessage()
            {
                AccessToken = accessToken,
                ThumbMediaId = response.MediaId,
                HqMusicUrl = hqMusicUrl,
                MusicUrl = musicUrl,
                MsgType = "music",
                ToUser = toUser,
                Description = description,
                Title = title
            };
            return SendCustomMessage(accessToken, msg);
        }

        /// <summary>
        /// 发送图文客服消息
        /// </summary>
        /// <param name="accessToken">调用凭据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static SendCustomMessageResponse SendNewsCustomMessage(string accessToken, NewsCustomMessage msg)
        {
            msg.AccessToken = accessToken;
            return SendCustomMessage(accessToken, msg);
        }
        #endregion
    } // class end
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
