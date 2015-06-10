using System;
using System.Collections.Generic;
using System.Web;

namespace Eyousoft_yhq.Web.BsendMsg
{
    public class CommonProcess
    {
        /// <summary>
        /// 获取短信通道信息业务实体
        /// </summary>
        /// <param name="channelIndex">通道索引</param>
        /// <returns></returns>
        public static Eyousoft_yhq.Model.SMSChannel GetSMSChannelInfo(int channelIndex)
        {
            Eyousoft_yhq.Model.SMSChannel channel = new Eyousoft_yhq.Model.SMSChannel { Index = -1, ChannelName = "未知通道", IsLong = false };

            System.Collections.Generic.IList<Eyousoft_yhq.Model.SMSChannel> channels = GetSMSChannels();

            foreach (Eyousoft_yhq.Model.SMSChannel tmp in channels)
            {
                if (tmp.Index == channelIndex)
                {
                    channel = tmp;
                }
            }

            return channel;
        }

        /// <summary>
        /// 获取短信通道信息集合
        /// </summary>
        /// <returns></returns>
        public static IList<Eyousoft_yhq.Model.SMSChannel> GetSMSChannels()
        {
            string channelConfig = Adpost.Common.ConfigModel.ConfigClass.GetConfigString("appSettings", "SMS_SMSChannel");

            if (string.IsNullOrEmpty(channelConfig))
            {
                throw new Exception("未配置短信发送的通道信息");
            }

            string[] channelArr = channelConfig.Split('|');

            if (channelArr == null || channelArr.Length == 0)
            {
                throw new Exception("未正确配置短信发送的通道信息");
            }

            System.Collections.Generic.IList<Eyousoft_yhq.Model.SMSChannel> channels = new System.Collections.Generic.List<Eyousoft_yhq.Model.SMSChannel>();

            foreach (string channel in channelArr)
            {
                string[] valArr = channel.Split(',');
                if (valArr != null && valArr.Length > 0)
                {
                    Eyousoft_yhq.Model.SMSChannel item = new Eyousoft_yhq.Model.SMSChannel();

                    item.Index = Convert.ToInt32(valArr[0].Split(':')[1]);
                    item.ChannelName = valArr[1].Split(':')[1];
                    item.UserName = valArr[2].Split(':')[1];
                    item.Pw = valArr[3].Split(':')[1];
                    item.PriceOne = Convert.ToDecimal(valArr[4].Split(':')[1]);

                    if (valArr[5].Split(':')[1] == "1")
                    {
                        item.IsLong = true;
                    }

                    channels.Add(item);
                }
            }

            return channels;
        }

        public static int SendSMS(string mobile, string s, Eyousoft_yhq.Model.SMSChannel channel, out string resultMsg)
        {
            cn.myvo.smc.Service sms = new cn.myvo.smc.Service();
            string enterpriseId = string.Empty;
            int sendTimeOutEventCode = -2147483646;
            int sendResult = 0;

            try
            {
                //发送结果返回值 返回int类型的0时成功 返回对应的负数时失败
                if (channel.Index < 2)
                {
                    sendResult = sms.SendSms(enterpriseId, mobile, s, channel.UserName, channel.Pw);
                }

                if (sendResult == 0)
                {
                    resultMsg = "成功";
                }
                else
                {

                    resultMsg = "失败";
                }
            }
            catch
            {
                sendResult = sendTimeOutEventCode;
                resultMsg = "超时";
            }

            return sendResult;
        }




        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="tel">手机号码</param>
        /// <returns></returns>
        public static string SendSMSVoice(string tel, string Content)
        {
            string DLConfig = Adpost.Common.ConfigModel.ConfigClass.GetConfigString("appSettings", "DLConfig");
            string SQMConfig = Adpost.Common.ConfigModel.ConfigClass.GetConfigString("appSettings", "SQMConfig");
            string voiceid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string pwd = GetMD5(DLConfig + SQMConfig);
            //加密结果长度必须是32位的，不足32位，前面加0不足
            if (pwd.Length < 32)
            {
                for (int i = 0; i < 32 - pwd.Length; i++)
                {
                    pwd = "0" + pwd;
                }
            }

            Eyousoft_yhq.Web.net._2office.voicesms.VoiceVerificationService sns = new Eyousoft_yhq.Web.net._2office.voicesms.VoiceVerificationService();
            string[] ReValue = null;
            string re = sns.SendVoiceCode("2521149", pwd, "", tel, Content, voiceid, "1");
            ReValue = re.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return ReValue[0].ToString() == "0" ? "成功" : ReValue[1].ToString();
        }

        public static string GetMD5(string str)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


    }
}
