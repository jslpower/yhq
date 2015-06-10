using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection;

namespace EyouSoft.Common
{
    public class UtilsCommons
    {
        #region 格式转换 create by dyz

        /// <summary>
        /// 金额显示格式处理
        /// </summary>
        /// <param name="m">金额</param>
        /// <param name="name">预定义的 System.Globalization.CultureInfo 名称或现有 System.Globalization.CultureInfo名称</param>
        /// <returns></returns>
        public static string GetMoneyString(decimal m, string name)
        {
            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(name);

            return m.ToString("c2", cultureInfo);
        }

        /// <summary>
        /// 金额显示格式处理
        /// </summary>
        /// <param name="o">金额</param>
        /// <param name="name">预定义的 System.Globalization.CultureInfo 名称或现有 System.Globalization.CultureInfo名称</param>
        /// <returns></returns>
        public static string GetMoneyString(object o, string name)
        {
            if (o != null)
            {
                return GetMoneyString(Utils.GetDecimal(o.ToString()), name);
            }

            return string.Empty;
        }

        /// <summary>
        /// 时间显示格式处理
        /// </summary>
        /// <param name="d">时间值</param>
        /// <param name="format">格式字符串。</param>
        /// <returns></returns>
        public static string GetDateString(DateTime d, string format)
        {
            if (d == null || d.ToString() == "" || d.Equals(Utils.GetDateTime("1900-1-1 0:00:00")) || d.Equals(Utils.GetDateTime("0001-01-01 0:00:00")))
            {
                return "";
            }
            else
            {
                return d.ToString(format);
            }
        }

        /// <summary>
        /// 时间显示格式处理
        /// </summary>
        /// <param name="d">时间值</param>
        /// <param name="format">格式字符串。</param>
        /// <returns></returns>
        public static string GetDateString(object d, string format)
        {
            if (d != null)
            {
                return GetDateString(Utils.GetDateTime(d.ToString()), format);
            }

            return string.Empty;
        }

        #endregion

        #region ajax request,response josn data.  create by cyn
        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode)
        {
            return AjaxReturnJson(retCode, string.Empty);
        }
        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <param name="retMsg">return msg</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode, string retMsg)
        {
            return AjaxReturnJson(retCode, retMsg, null);
        }

        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <param name="retMsg">return msg</param>
        /// <param name="retObj">return object</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode, string retMsg, object retObj)
        {
            string output = "{}";

            if (retObj != null)
            {
                output = Newtonsoft.Json.JsonConvert.SerializeObject(retObj);
            }

            return string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\",\"obj\":{2}}}", retCode, retMsg, output);
        }
        #endregion

        /// <summary>
        /// 获取分页页索引，url页索引查询参数为Page
        /// </summary>
        /// <returns></returns>
        public static int GetPagingIndex()
        {
            return GetPagingIndex("Page");
        }

        /// <summary>
        /// 获取分页页索引
        /// </summary>
        /// <param name="s">url页索引查询参数</param>
        /// <returns></returns>
        public static int GetPagingIndex(string s)
        {
            int index = Utils.GetInt(Utils.GetQueryStringValue(s), 1);

            return index < 1 ? 1 : index;
        }

        /// <summary>
        /// 分页参数处理
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        public static void Paging(int pageSize, ref int pageIndex, int recordCount)
        {
            if (pageSize < 1) pageSize = 1;
            int pageCount = recordCount / pageSize;
            if (recordCount % pageSize > 0) pageCount++;
            if (pageIndex > pageCount) pageIndex = pageCount;
            if (pageIndex < 1) pageIndex = 1;
        }

        public static bool IsToXls()
        {
            return Utils.GetQueryStringValue("toxls") == "1";
        }
        public static int GetToXlsRecordCount()
        {
            return Utils.GetInt(Utils.GetQueryStringValue("toxlsrecordcount"));
        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选择value值</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal)
        {
            return GetEnumDDL(ls, selectedVal ?? "-1", false);

        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选择value值</param>
        /// <param name="isFirst">是否存在默认请选择项</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, bool isFirst)
        {

            return GetEnumDDL(ls, selectedVal, isFirst, "-1", "-请选择-");
        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选中的值</param>
        /// <param name="defaultKey">默认值Id</param>
        /// <param name="defaultVal">默认值文本</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, string defaultKey, string defaultVal)
        {

            return GetEnumDDL(ls, selectedVal, true, defaultKey, defaultVal);
        }
        /// <summary>
        /// 获取枚举下拉菜单(该方法isFirst为否则后2个属性无效)
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选中的值</param>
        /// <param name="isFirst">是否有默认值</param>
        /// <param name="defaultKey">默认值Id</param>
        /// <param name="defaultVal">默认值文本</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, bool isFirst, string defaultKey, string defaultVal)
        {
            StringBuilder sb = new StringBuilder();
            if (isFirst)
            {
                sb.Append("<option value=\"" + defaultKey + "\" selected=\"selected\">" + defaultVal + "</option>");
            }

            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Value != selectedVal.Trim())
                {
                    sb.Append("<option value=\"" + ls[i].Value.Trim() + "\">" + ls[i].Text.Trim() + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + ls[i].Value.Trim() + "\" selected=\"selected\">" + ls[i].Text.Trim() + "</option>");
                }
            }
            return sb.ToString();
        }
    }
}
