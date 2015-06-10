namespace PayAPI.Tencent.Core
{
    using Common.Config;
    using System;
    using System.Web;

    /// <summary>
    /// 财付通系统信息
    /// </summary>
    public class TenPaySystem
    {

        /// <summary>
        /// 平台商户ID，商户号
        /// </summary>
        public static string BargainorId
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "bargainor_id");
            }
        }

        /// <summary>
        /// 参数编码字符集(gb2312,utf-8)
        /// </summary>
        public static string Inputcharset
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "input_charset");
            }
        }

        /// <summary>
        /// 安全检验码
        /// </summary>
        public static string Key
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "key");
            }
        }

        /// <summary>
        /// 支付完成后异步调用通知的URL、http://开头的完整地址
        /// </summary>
        public static string NotifyUrl
        {
            get
            {
                string configString = ConfigModel.GetConfigString("Tenpay", "notify_url");
                if (string.IsNullOrEmpty(configString) || (configString.IndexOf("http://") != -1))
                {
                    return configString;
                }
                string str2 = "";
                if (configString[0] != '/')
                {
                    str2 = "/";
                }
                return ("http://" + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + str2 + configString);
            }
        }

        /// <summary>
        /// 默认的支付方式，目前仅支持默认显示到按财付通余额支付
        /// </summary>
        public static string Paymethod
        {
            get
            {
                return "1";
            }
        }


        public static string appid
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "appid");
            }
        }


        public static string appkey
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "appkey");
            }
        }

        /// <summary>
        /// 证书地址
        /// </summary>
        public static string PfxPath
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "pfxPath");
            }
        }

        /// <summary>
        /// 证书密码
        /// </summary>
        public static string PfxPwd
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "pfxPwd");
            }
        }

        /// <summary>
        /// 支付完成后，同步重定向，自动跳转回该指定网址(若为空，支付完成后页面不进行跳转)，http://开头的完整地址
        /// </summary>
        public static string ReturnUrl
        {
            get
            {
                string configString = ConfigModel.GetConfigString("Tenpay", "return_url");
                if (string.IsNullOrEmpty(configString) || (configString.IndexOf("http://") != -1))
                {
                    return configString;
                }
                string str2 = "";
                if (configString[0] != '/')
                {
                    str2 = "/";
                }
                return ("http://" + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + str2 + configString);
            }
        }

        /// <summary>
        /// 签名方式如DSA、RSA、MD5。默认为MD5.
        /// </summary>
        public static string SignType
        {
            get
            {
                return ConfigModel.GetConfigString("Tenpay", "sign_type");
            }
        }

    }
}

