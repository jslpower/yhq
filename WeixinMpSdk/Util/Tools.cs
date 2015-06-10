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
using System.Web.Script.Serialization;

namespace Weixin.Mp.Sdk.Util
{
    /// <summary>
    /// 辅助工具类
    /// </summary>
    public  class Tools
    {
        #region 获取Json string某节点的值。
        /// <summary>
        /// 获取Json string某节点的值。
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJosnValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = jsonStr.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }
        #endregion

        /// <summary>
        /// datetime转换成unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static  long  ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long )(time - startTime).TotalSeconds;
        }

       /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
       /// </summary>
       /// <param name="d"></param>
       /// <returns></returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        /// <summary>
        /// Json序列化对象
        /// </summary>
        /// <typeparam name="ObjType"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static  string ToJsonString<ObjType>(ObjType obj) where ObjType : class
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string  s = jsonSerializer.Serialize(obj);
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
