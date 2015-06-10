using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace EyouSoft.Toolkit
{
    public class request
    {
        #region private members
        /// <summary>
        /// 微信多媒体文件保存
        /// </summary>
        /// <param name="response"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        static bool weixin_media_xiazai_baocunfile(WebResponse response, string filepath)
        {
            bool baoCunRetCode = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(filepath))File.Delete(filepath);
                Stream outStream = System.IO.File.Create(filepath);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch
            {
                baoCunRetCode = false;
            }

            return baoCunRetCode;
        }
        #endregion

        public static string create(string requestUriString, string referer, Method method, string data, ref string cookies, bool keepAlive)
        {
            StringBuilder responseText = new StringBuilder();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = 300000;
            request.Method = method.ToString();
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.KeepAlive = keepAlive;
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:8.0) Gecko/20100101 Firefox/8.0";
            request.Accept = "*/*";
            request.Referer = referer;
            request.Headers.Set("Cookie", cookies);

            Encoding encode = System.Text.Encoding.UTF8;

            if (method == Method.POST && !string.IsNullOrEmpty(data))
            {
                byte[] bytes = encode.GetBytes(data);
                request.ContentLength = bytes.Length;

                Stream oStreamOut = request.GetRequestStream();
                oStreamOut.Write(bytes, 0, bytes.Length);
                oStreamOut.Close();
            }

            HttpWebResponse response = null;

            try
            {
                int i = 1;
                while (i > 0)
                {
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK) break;
                    else response = null;
                    i--;
                }
            }
            catch { response = null; }

            if (response != null)
            {
                try
                {
                    string rcookies = response.Headers["Set-Cookie"];

                    if (!string.IsNullOrEmpty(rcookies))
                    {
                        StringBuilder sb = new StringBuilder();
                        string[] arr = rcookies.Split(';');
                        foreach (string s in arr)
                        {
                            if (string.IsNullOrEmpty(s) 
                                || s.ToLower().IndexOf("domain=") > -1 
                                || s.ToLower().IndexOf("path=") > -1 
                                || s.ToLower().IndexOf("expires=") > -1) continue;

                            sb.Append(s.Trim(','));
                            sb.Append(";");
                        }

                        cookies += sb.ToString();
                    }

                    Stream resStream = null;
                    resStream = response.GetResponseStream();

                    StreamReader readStream = new StreamReader(resStream, encode);

                    Char[] read = new Char[256];
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        string s = new String(read, 0, count);
                        responseText.Append(s);
                        count = readStream.Read(read, 0, 256);
                    }

                    resStream.Close();
                }
                catch { }
            }

            return responseText.ToString();

        }

        /// <summary>
        /// 微信多媒体文件下载
        /// </summary>
        /// <param name="requestUriString">需要下载的文件路径</param>
        /// <param name="filepath">文件保存路径</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool weixin_media_xiazai(string requestUriString,string filepath,out string filename)
        {
            filename = string.Empty;

            if (string.IsNullOrEmpty(requestUriString)) return false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = 300000;
            request.Method = "get";

            var response = (HttpWebResponse)request.GetResponse();

            if (response.ContentType.ToLower().StartsWith("text/")) { return false; }

            string disposition = response.Headers.Get("Content-disposition");
            string fielExtension = disposition.Substring(disposition.LastIndexOf("."));
            fielExtension = fielExtension.Substring(0, fielExtension.Length - 1);

            Random rnd = new Random();
            string saveFileName = DateTime.Now.ToFileTime().ToString() + rnd.Next(1000, 99999).ToString() + fielExtension;
            rnd = null;

            string dPath = System.Web.HttpContext.Current.Server.MapPath(filepath);
            if (!Directory.Exists(dPath)) Directory.CreateDirectory(dPath);

            string fPath = dPath + saveFileName;

            if (weixin_media_xiazai_baocunfile(response, fPath))
            {
                filename = filepath + saveFileName;
                return true;
            }

            return false;
        }
    }

    public enum Method
    {
        GET, POST
    }
}
