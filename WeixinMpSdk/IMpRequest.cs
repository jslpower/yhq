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

namespace Weixin.Mp.Sdk
{
    /// <summary>
    /// 微信公众平台请求接口
    /// </summary>
    public interface IMpRequest<T> where T: MpResponse 
    {
        /// <summary>
        /// AppId信息
        /// </summary>
        AppIdInfo AppIdInfo { get; set; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        string GetReqUrl();
       
        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 请求参数文本值
        /// </summary>
        /// <returns>文本请求参数字典</returns>
        IDictionary<string, string> GetParameters();

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        string SendData { get; set; }

        /// <summary>
        /// 将平台返回的HTML转化成MpResponse对象
        /// </summary>
        /// <param name="body">返回的HTML</param>
        /// <returns></returns>
        T ParseHtmlToResponse(string body);

        /// <summary>
        /// 请求方式:GET或POST
        /// </summary>
        string Method { get; }

        /// <summary>
        /// 提前验证参数。
        /// </summary>
        void Validate();
    }
}
/*
 * 微信公众平台C#版SDK
 * www.qq8384.com 版权所有
 * 有任何疑问，请到官方网站:www.qq8484.com查看帮助文档
 * 您也可以联系QQ1397868397咨询
 * QQ群：124987242、191726276、234683801、273640175、234684104
*/
