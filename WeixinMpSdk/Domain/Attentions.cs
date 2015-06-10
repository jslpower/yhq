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
    /// 关注着列表
    /// </summary>
    public class Attentions
    {
        public int total { get; set; }
        public int count { get; set; }
        public string next_openid { get; set; }
        public AttentionsData data { get; set; }
    }

    /// <summary>
    /// 关注着列表数据
    /// </summary>
    public class AttentionsData
    {
        public List<string> openid { get; set; }
    }
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
