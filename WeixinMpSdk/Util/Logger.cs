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
using System.Web;

namespace Weixin.Mp.Sdk.Util
{
    public class Logger
    {
        #region 写文本日志

        /// <summary>
        /// 写文本日志
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="logFilePath"></param>
        public static void WriteTxtLog(string Content, string logFilePath)
        {
            try
            {
                string fileName = logFilePath;
                string br = "\r\n";
                string content = Content;
                FileIO fIO = new FileIO();
                fIO.OpenWriteFile(fileName);
                fIO.WriteLine(content + br + br + "*******************************************************" + br);
                fIO.CloseWriteFile();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 写文本日志
        /// </summary>
        /// <param name="Content"></param>
        public static void WriteTxtLog(string Content)
        {
            try
            {
                string fileName = System.AppDomain.CurrentDomain.BaseDirectory;
                if (!fileName.EndsWith("\\"))
                {
                    fileName += "\\";
                }
                fileName += "Log\\";
                fileName += System.DateTime.Now.ToString("yyyy-MM-dd-HH") + ".txt";
                string br = "\r\n";
                string content = Content;
                FileIO fIO = new FileIO();
                fIO.OpenWriteFile(fileName);
                fIO.WriteLine(content + br + br + "*******************************************************" + br);
                fIO.CloseWriteFile();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 写文本日志
        /// </summary>
        /// <param name="Ex"></param>
        public static void WriteTxtLog(Exception Ex)
        {
            try
            {
                string fileName = System.AppDomain.CurrentDomain.BaseDirectory;
                if (!fileName.EndsWith("\\"))
                {
                    fileName += "\\";
                }
                fileName += "Log\\";
                fileName += System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                string blank = "    ";
                string br = "\r\n";
                string content = string.Empty;
                //content += "客户端IP：" + ClientIP;
                //content += br + "客户端操作系统：" + ClientPlatform;
                //content += br + "客户端浏览器：" + ClientBrowser;
                //content += br + "服务器计算机名：" + System.Net.Dns.GetHostName();
                //content += br + "发生时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //content += br + "引发页面：" + System.Web.HttpContext.Current.Request.Url.ToString();
                //content += br + "异常对象：" + Ex.Source;
                //content += br + "异常信息：" + Ex.Message;
                //content += br + "异常方法：" + Ex.TargetSite;
                //content += br + "错误详细信息：";
                content += br + blank + Ex.ToString();
                FileIO fIO = new FileIO();
                fIO.OpenWriteFile(fileName);
                fIO.WriteLine(content + br + br + "*******************************************************" + br);
                fIO.CloseWriteFile();
            }
            catch
            {
            }
        }
        #endregion

        #region 客户端IP
        /// <summary>
        /// 客户端IP
        /// </summary>
        private static string ClientIP
        {
            get
            {
                string result = String.Empty;
                result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (null == result || result == String.Empty)
                {
                    result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (null == result || result == String.Empty)
                {
                    result = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                if (null == result || result == String.Empty)
                {
                    return "0.0.0.0";
                }
                return result;
            }
        }
        #endregion

        #region 客户端使用平台的名字
        /// <summary>
        /// 客户端使用平台的名字 
        /// </summary>
        private static string ClientPlatform
        {
            get
            {
                try
                {
                    return System.Web.HttpContext.Current.Request.Browser.Platform.ToString();
                }
                catch { }
                {
                    return "";
                }
            }
        }
        #endregion

        #region 客户端浏览器
        /// <summary>
        /// 客户端浏览器
        /// </summary>
        private static string ClientBrowser
        {
            get
            {
                try
                {
                    System.Web.HttpBrowserCapabilities bc = System.Web.HttpContext.Current.Request.Browser;
                    return bc.Browser + " v." + bc.Version;
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion
    }//ClassEnd
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/