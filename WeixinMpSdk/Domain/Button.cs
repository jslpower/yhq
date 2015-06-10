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

namespace Weixin.Mp.Sdk.Domain
{
    /// <summary>
    /// 菜单组
    /// </summary>
    public class MenuGroup
    {
        public Menu menu { get; set; }

        /// <summary>
        /// 组装POST到公众平台的菜单Json字符串
        /// </summary>
        /// <returns></returns>
        public string  ToJsonString()
        {
          //  JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
           // string r1 = jsonSerializer.Serialize(menu);
           // return r1;
            string s1 = string.Empty;
            for (int i = 0; i < menu.button.Count; i++)
            {
                if (i > 0)
                {
                    s1 += ",";
                }
                s1 += menu.button[i].ToJsonString();
            }

            string s = "{ \"button\":[" + s1 + "]}";

            return s;
        }
    }

    /// <summary>
    /// 自定义菜单
    /// </summary>
    public class Menu
    {
        public List<Button> button { get; set; }
    }

    /// <summary>
    /// 自定义菜单按钮
    /// </summary>
    public class Button
    {
        /// <summary>
        /// 菜单的响应动作类型，目前有click、view两种类型 
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过40个字节 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 菜单KEY值，用于消息接口推送，不超过128字节 
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 网页链接，用户点击菜单可打开链接，不超过256字节 
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 二级菜单数组，个数应为1~5个 
        /// </summary>
        public List<Button> sub_button { get; set; }

        public string ToJsonString()
        {
            if (sub_button != null && sub_button.Count > 0)
            {
                string s1 = string.Empty;
                for (int i = 0; i < sub_button.Count; i++)
                {
                    if (i > 0)
                    {
                        s1 += ",";
                    }
                    s1 += sub_button[i].ToJsonString();
                }
                string s = " {\"name\":\"" + name + "\", \"sub_button\":[" + s1 + "]}";
                return s;
            }
            else
            {
                if (type == "click")
                {
                    return "{ \"type\":\"click\", \"name\":\"" + name + "\",\"key\":\"" + key + "\" }";
                }
                else
                {
                    return "{ \"type\":\"view\", \"name\":\"" + name + "\",\"url\":\"" + url + "\" }";
                }
            }
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
