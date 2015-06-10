using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace Eyousoft_yhq.SQLServerDAL
{  
    /// <summary>
    /// utils
    /// </summary>
    public class Utils
    {
        #region public static members
        public const string RANDOM_STRING_SOURCE = "0123456789abcdefghijklmnopqrstuvwxyz";
        public static Random rnd = new Random();

        /// <summary>
        /// 获取网站根目录的绝对地址。
        /// </summary>
        /// <value>返回的地址以'/'结束.</value>
        public static Uri AbsoluteWebRoot
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                    throw new System.Net.WebException("The current HttpContext is null");

                if (context.Items["absoluteurl"] == null)
                    context.Items["absoluteurl"] = new Uri(context.Request.Url.GetLeftPart(UriPartial.Authority) + RelativeWebRoot);

                return context.Items["absoluteurl"] as Uri;
            }
        }

        private static string _RelativeWebRoot;

        /// <summary>
        /// 获取网站根目录的相对路径。
        /// </summary>
        /// <value>返回的地址以'/'结束.</value>
        public static string RelativeWebRoot
        {
            get
            {
                if (_RelativeWebRoot == null)
                    _RelativeWebRoot = VirtualPathUtility.ToAbsolute("~/");

                return _RelativeWebRoot;
            }
        }

        /// <summary>
        /// 获取域名后缀。
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetDomainSuffix(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;
                if (host.Split('.').Length > 2)
                {
                    int lastIndex = host.LastIndexOf(".");
                    int index = host.LastIndexOf(".", lastIndex - 1);
                    return host.Substring(index + 1);
                }
            }

            return null;
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.IndexOf("\\") == 0)
                {
                    strPath = strPath.Substring(1);
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 取得客户的IP数据
        /// </summary>
        /// <returns>客户的IP</returns>
        public static string GetRemoteIP()
        {
            string Remote_IP = "";
            try
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    Remote_IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    Remote_IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                }
            }
            catch
            {
            }
            return Remote_IP;
        }

        /// <summary>
        /// 获取当前页面地址
        /// </summary>
        /// <returns></returns>
        public static string GetRequestUrl()
        {
            string RequestUrl = "";
            try
            {
                if (HttpContext.Current.Request.Url != null)
                {
                    RequestUrl = HttpContext.Current.Request.Url.ToString();
                }
            }
            catch
            {
            }
            return RequestUrl;
        }

        /// <summary>
        /// 获取上次请求本页面地址
        /// </summary>
        /// <returns></returns>
        public static string GetRequestUrlReferrer()
        {
            string RequestUrl = "";
            try
            {
                if (HttpContext.Current.Request.UrlReferrer != null)
                {
                    RequestUrl = HttpContext.Current.Request.UrlReferrer.ToString();
                    //控制是否显示保存（历史静态页面）
                    RequestUrl += (RequestUrl.Contains("?") ? "&" : "?") + "chakan=1";
                }
            }
            catch
            {
            }
            return RequestUrl;
        }

        /// <summary>
        /// 将127.0.0.1 形式的IP地址转换成10进制整数，这里没有进行任何错误处理
        /// </summary>
        /// <param name="strIP">IP地址转换</param>
        /// <returns>返回0进制整数</returns>
        public static long IpToLong(string strIP)
        {
            if (string.IsNullOrEmpty(strIP))
                return 0;

            string[] strIPs = strIP.Trim().Split('.');
            if (strIPs.Length != 4)
                return 0;

            long[] ip = new long[4];
            for (int i = 0; i < strIPs.Length; i++)
            {
                ip[i] = long.Parse(strIPs[i]);
            }

            return ip[0] * 256 * 256 * 256 + ip[1] * 256 * 256 + ip[2] * 256 + ip[3];
        }

        /// <summary>
        /// 替换XML敏感字符
        /// </summary>
        /// <param name="s">输入字符串</param>
        /// <returns></returns>
        public static string ReplaceXmlSpecialCharacter(string s)
        {
            //Replace("", string.Empty);  处理特殊字符的 你看不到不代表没有，不是空替换空
            if (!string.IsNullOrEmpty(s))
            {
                return
                    s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace(
                        "\"", "&quot;").Replace("", string.Empty);
            }

            return s;
        }

        /// <summary>
        /// 将字符串转化为数字 若值不是数字返回defaultValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt(string key, int defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }

            int result = 0;
            bool b = Int32.TryParse(key, out result);

            if (b) return result;

            return defaultValue;
        }

        /// <summary>
        /// 将字符串转化为数字 若值不是数字返回0
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt(string key)
        {
            return GetInt(key, 0);
        }

        /// <summary>
        /// get Nullable<int>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int? GetIntNullable(string key, int? defaultValue)
        {
            if (string.IsNullOrEmpty(key)) return defaultValue;

            int result = 0;
            bool b = int.TryParse(key, out result);

            if (b) return result;

            return defaultValue;
        }

        /// <summary>
        /// 将字符串转化为decimal 若值不是数字返回defaultValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string key, decimal defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }

            decimal result = 0;
            bool b = decimal.TryParse(key, out result);

            if (b) return result;

            return defaultValue;
        }

        /// <summary>
        /// 将字符串转化为decimal 若值不是数字返回0
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string key)
        {
            return GetDecimal(key, 0);
        }

        /// <summary>
        /// 将字符串转化为double 若值不是数字返回defaultValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDouble(string key, double defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }

            double result = 0;
            bool b = double.TryParse(key, out result);

            if (b) return result;

            return defaultValue;
        }

        /// <summary>
        /// 将字符串转化为double 若值不是数字返回0
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDouble(string key)
        {
            return GetDouble(key, 0);
        }

        /// <summary>
        /// 将格式为yyyyMMdd(如：2010-12-05)的字符串转换成日期格式 若不能转换成日期将返回defaultValue
        /// </summary>
        /// <param name="s">要转换的字符串 格式(yyyyMMdd 如：20101205)</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime112(string s, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(s))
            {
                return defaultValue;
            }

            DateTime result = defaultValue;
            bool b = DateTime.TryParse(s.Substring(0, 4) + "-" + s.Substring(4, 2) + "-" + s.Substring(6, 2), out result);

            return result;
        }

        /// <summary>
        /// 将格式为yyyyMMdd(如：2010-12-05)的字符串转换成日期格式 若不能转换成日期将返回DateTime.MinValue
        /// </summary>
        /// <param name="s">要转换的字符串 格式(yyyyMMdd 如：20101205)</param>
        /// <returns></returns>
        public static DateTime GetDateTime112(string s)
        {
            return GetDateTime112(s, DateTime.MinValue);
        }

        /// <summary>
        /// 将字符串转换成日期格式 若不能转换成日期将返回defaultValue
        /// </summary>
        /// <param name="s">要转换的字符串</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string s, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(s))
            {
                return defaultValue;
            }

            DateTime result = defaultValue;
            bool b = DateTime.TryParse(s, out result);

            if (b) return result;

            return defaultValue;
        }

        /// <summary>
        /// 将字符串转换成日期格式 若不能转换成日期将返回DateTime.MinValue
        /// </summary>
        /// <param name="s">要转换的字符串</param>
        /// <returns></returns>
        public static DateTime GetDateTime(string s)
        {
            return GetDateTime(s, DateTime.MinValue);
        }

        /// <summary>
        /// 获取当前农历日期
        /// </summary>
        /// <returns></returns>
        public static LunarCalendar GetLunarCalendar()
        {
            return GetLunarCalendar(DateTime.Today);
        }

        /// <summary>
        /// 将指定日期转换成农历日期
        /// </summary>
        /// <param name="d">公历日期</param>
        /// <returns></returns>
        public static LunarCalendar GetLunarCalendar(DateTime d)
        {
            LunarCalendar lunarCalendar = new LunarCalendar();

            ChineseLunisolarCalendar chineseLunisolarCalendar = new ChineseLunisolarCalendar();
            lunarCalendar.Year = chineseLunisolarCalendar.GetYear(d);
            lunarCalendar.Month = chineseLunisolarCalendar.GetMonth(d);
            lunarCalendar.Day = chineseLunisolarCalendar.GetDayOfMonth(d);
            lunarCalendar.DaysInMonth = chineseLunisolarCalendar.GetDaysInMonth(lunarCalendar.Year, lunarCalendar.Month);
            lunarCalendar.DaysInYear = chineseLunisolarCalendar.GetDaysInYear(lunarCalendar.Year);

            return lunarCalendar;
        }

        /// <summary>
        /// 根据整型数组生成半角逗号分割的Sql字符串
        /// </summary>
        /// <param name="arrIds">整型数组</param>
        /// <returns>半角逗号分割的Sql字符串</returns>
        public static string GetSqlIdStrByArray(int[] arrIds)
        {
            if (arrIds == null || arrIds.Length < 1) return "0";

            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}", arrIds[0].ToString());

            for (int i = 1; i < arrIds.Length; i++)
            {
                s.AppendFormat(",{0}", arrIds[i].ToString());
            }

            return s.ToString();
        }

        /// <summary>
        /// 根据整型集合生成半角逗号分割的的Sql字符串
        /// </summary>
        /// <param name="ids">整形集合</param>
        /// <returns></returns>
        public static string GetSqlIdStrByList(IList<int> ids)
        {
            if (ids == null || ids.Count < 1) return "0";
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}", ids[0].ToString());

            for (int i = 1; i < ids.Count; i++)
            {
                s.AppendFormat(",{0}", ids[i].ToString());
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取SQL IN 字符串
        /// </summary>
        /// <param name="ids">匹配字符串数组</param>
        /// <returns></returns>
        public static string GetSqlInExpression(string[] ids)
        {
            if (ids == null || ids.Length == 0) return "''";

            StringBuilder s = new StringBuilder();
            s.AppendFormat("'{0}'", ids[0]);

            for (int i = 1; i < ids.Length; i++)
            {
                s.AppendFormat(",'{0}'", ids[i]);
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取SQL IN 字符串
        /// </summary>
        /// <param name="ids">匹配字符串集合</param>
        /// <returns></returns>
        public static string GetSqlInExpression(IList<string> ids)
        {
            if (ids == null || ids.Count == 0) return "''";

            StringBuilder s = new StringBuilder();
            s.AppendFormat("'{0}'", ids[0]);

            for (int i = 1; i < ids.Count; i++)
            {
                s.AppendFormat(",'{0}'", ids[i]);
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取SQL IN 字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string GetSqlIn<T>(ICollection<T> ids)
        {
           
            if (typeof(T).IsEnum)
            {
                if (ids == null || ids.Count < 1) return "-1";
                StringBuilder s1 = new StringBuilder();
                foreach (var item in ids)
                {
                    s1.AppendFormat(",{0}", Convert.ToInt32(item));
                }

                return s1.ToString().Substring(1);
            }

            if (typeof(T)==typeof(int)||typeof(T)==typeof(byte))
            {
                if (ids == null || ids.Count < 1) return "0";
                StringBuilder s2 = new StringBuilder();
                foreach (var item in ids)
                {
                    s2.AppendFormat(",{0}", item);
                }
                return s2.ToString().Substring(1);
            }

            if (typeof(T) == typeof(string))
            {
                if (ids == null || ids.Count < 1) return "''";
                StringBuilder s3 = new StringBuilder();
                foreach (var item in ids)
                {
                    s3.AppendFormat(",'{0}'",item);
                }
                return s3.ToString().Substring(1);
            }

            return "-1";
        }

        #region XElement
        /// <summary>
        /// Get XAttribute Value
        /// </summary>
        /// <param name="XAttribute">xAttribute</param>
        /// <returns>Value</returns>
        public static string GetXAttributeValue(XAttribute xAttribute)
        {
            if (xAttribute == null)
                return string.Empty;

            return xAttribute.Value;
        }

        /// <summary>
        /// Get XAttribute Value
        /// </summary>
        /// <param name="xElement">XElement</param>
        /// <param name="attributeName">Attribute Name</param>
        /// <returns></returns>
        public static string GetXAttributeValue(XElement xElement, string attributeName)
        {
            return GetXAttributeValue(xElement.Attribute(attributeName));
        }

        /// <summary>
        /// Get XElement
        /// </summary>
        /// <param name="xElement">parent xElement</param>
        /// <param name="xName">xName</param>
        /// <returns>XElement</returns>
        public static XElement GetXElement(XElement xElement, string xName)
        {
            XElement x = xElement.Element(xName);

            if (x != null) return x;

            return new XElement(xName);
        }

        /// <summary>
        /// Get XElements
        /// </summary>
        /// <param name="xElement">parent xElement</param>
        /// <param name="xName">xName</param>
        /// <returns>XElements</returns>
        public static IEnumerable<XElement> GetXElements(XElement xElement, string xName)
        {
            var x = xElement.Elements(xName);
            if (x == null)
                return new List<XElement>();

            return x;
        }
        #endregion

        /// <summary>
        /// 传的like key参数经过toSqlLike格式化
        /// </summary>
        /// <param name="s">匹配字符串</param>
        /// <returns>格式化字符串</returns>
        public static string ToSqlLike(string s)
        {
            return string.IsNullOrEmpty(s) ? s : ((new Regex(@"(\[|\]|\*|_|%)")).Replace(s, "[$1]").Replace("'", "''"));
        }

        /// <summary>
        /// 获取XML文档指定属性值
        /// </summary>
        /// <param name="xml">XML文档</param>
        /// <param name="attribute">属性</param>
        /// <returns>属性值</returns>
        public static string GetValueFromXmlByAttribute(string xml, string attribute)
        {
            if (string.IsNullOrEmpty(xml)) return "";
            var xRoot = XElement.Parse(xml);
            var xRows = GetXElements(xRoot, "row");
            foreach (var xRow in xRows)
            {
                return GetXAttributeValue(xRow, attribute);
            }
            return "";
        }

        /// <summary>
        /// get enum value
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="s">转换的字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetEnumValue(Type enumType, string s, int defaultValue)
        {
            int? _enum = GetIntNullable(s, null);
            if (!_enum.HasValue) return defaultValue;

            if (!Enum.IsDefined(enumType, _enum)) return defaultValue;

            return _enum.Value;
        }

        /// <summary>
        /// get enum value
        /// </summary>
        /// <param name="s">转换的字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <typeparam name="T">typeof(T).IsEnum==true</typeparam>
        /// <returns></returns>
        public static T GetEnumValue<T>(string s, T defaultValue)
        {
            if (typeof(T).IsEnum)
            {
                int? _enum = GetIntNullable(s, null);
                if (!_enum.HasValue) return defaultValue;

                if (!Enum.IsDefined(typeof(T), _enum.Value)) return defaultValue;

                return (T)(object)_enum.Value;
            }

            return defaultValue;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="s">内容</param>
        /// <param name="path">相对路径，确保目录实际存在</param>
        public static void WLog(string s, string path)
        {
            string fPath = Utils.GetMapPath(path);

            string extension = System.IO.Path.GetExtension(fPath);

            if (!string.IsNullOrEmpty(extension))
            {
                fPath = fPath.Substring(0, fPath.LastIndexOf(extension)) + "." + DateTime.Today.ToString("yyyyMMdd") + extension;
            }

            if (!File.Exists(fPath))
            {
                FileStream fs = File.Create(fPath);
                fs.Close();
            }

            try
            {
                var sw = new StreamWriter(fPath, true, System.Text.Encoding.UTF8);
                sw.Write(DateTime.Now.ToString("o") + "\t" + s + "\r\n");
                sw.Close();
            }
            catch { }
        }

        /// <summary>
        /// 分割字符串成int数组
        /// </summary>
        /// <param name="s">要分割的字符串</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static int[] Split(string s, string separator)
        {
            if (string.IsNullOrEmpty(s)) return new int[] { };
            if (string.IsNullOrEmpty(separator)) return new int[] { };

            string[] _tmp = s.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (_tmp == null || _tmp.Length == 0) return new int[] { };

            int _length = _tmp.Length;
            int[] _tmp1 = new int[_length];

            for (int i = 0; i < _length; i++)
            {
                _tmp1[i] = GetInt(_tmp[i]);
            }

            return _tmp1;
        }

        /// <summary>
        /// 将字符串转换为可空的日期类型，如果字符串不是有效的日期格式，则返回null
        /// </summary>
        /// <param name="s">进行转换的字符串</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeNullable(string s)
        {
            return GetDateTimeNullable(s, null);
        }

        /// <summary>
        /// 将字符串转换为可空的日期类型，如果字符串不是有效的日期格式，则返回defaultValue
        /// </summary>
        /// <param name="s">进行转换的字符串</param>
        /// <param name="defaultValue">要返回的默认值</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeNullable(string s, DateTime? defaultValue)
        {
            if (string.IsNullOrEmpty(s))
            {
                return defaultValue;
            }

            DateTime tmp;
            bool b = DateTime.TryParse(s, out tmp);

            if (b) return DateTime.Parse(s);

            return defaultValue;
        }

        /// <summary>  
        /// 替换字符串中低序位ASCII字符(非打印控制字符)为string.Empty
        /// 转换 ASCII  0 - 8
        /// 转换 ASCII 11 - 12
        /// 转换 ASCII 14 - 31
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string ReplaceNonPrintingASCIICharacters(string s)
        {

            if (string.IsNullOrEmpty(s)) return string.Empty;

            StringBuilder s1 = new StringBuilder();

            foreach (char c in s)
            {
                int i = (int)c;
                if (((i >= 0) && (i <= 8)) || ((i >= 11) && (i <= 12)) || ((i >= 14) && (i < 32)))
                {
                    //s1.AppendFormat(string.Empty);
                    continue;
                }
                else
                {
                    s1.Append(c);
                }
            }

            return s1.ToString();
        }

        /// <summary>
        /// 分页参数验证
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public static bool ValidPaging(int pageSize, int pageIndex)
        {
            if (pageSize <= 0) return false;
            if (pageIndex < 1) return false;

            return true;
        }

        /// <summary>
        /// 随机数
        /// </summary>
        /// <param name="num">随机数的位数</param>
        /// <returns></returns>
        public static string GetRandomString(int num)
        {
            string rndStr = "";
            
            for (int i = 0; i < num; i++)
            {
                rndStr += RANDOM_STRING_SOURCE.Substring(Convert.ToInt32(Math.Round(rnd.NextDouble() * 9, 0)), 1);
            }
            return rndStr;
        }
        #endregion

    }
}
