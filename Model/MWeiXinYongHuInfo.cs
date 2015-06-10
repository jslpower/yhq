//微信用户信息业务实体 汪奇志 2014-01-14
using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 微信用户信息业务实体
    /// </summary>
    public class MWeiXinYongHuInfo
    {
        /// <summary>
        /// 用户编号（内部）
        /// </summary>
        public string YongHuId { get; set; }
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public string subscribe { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一 
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知 
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 用户的语言，简体中文为zh_CN 
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空 
        /// </summary>
        public string headimgurl { get; set; }
        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间 
        /// </summary>
        public string subscribe_time { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段
        /// </summary>
        public string unionid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime latesttime { get; set; }
        /// <summary>
        /// 类型 0:关注用户 1:网页授权用户
        /// </summary>
        public int LeiXing { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime BangDingTime { get; set; }
    }
}
