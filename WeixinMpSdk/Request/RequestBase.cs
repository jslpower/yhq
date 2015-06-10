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
using Weixin.Mp.Sdk.Domain;

namespace Weixin.Mp.Sdk.Request
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public abstract class RequestBase<T> where T : MpResponse 
    {
        /* 测试账号申请地址
         *  http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login
        */

        /// <summary>
        /// 获取默认AppInfo信息
        /// </summary>
        /// <returns></returns>
        protected AppIdInfo GetDefaultAppIdInfo()
        {
            AppIdInfo info = new AppIdInfo()
            {
                AppID = "1",
                AppSecret = "2",
                CallBack = "3"
            };
            return info;
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
