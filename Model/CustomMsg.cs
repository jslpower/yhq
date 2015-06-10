using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class CustomMsg
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 发送人编号
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 发送人昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 发送人性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string CommendInfo { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }
    public class serCustomMsg
    {

    }

    /// <summary>
    /// 绑定微信账号
    /// </summary>
    public class WXBind
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 服务号
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime BindTime { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime SubscribeTime { get; set; }
        /// <summary>
        /// 所在国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 用户语言
        /// </summary>
        public string Language { get; set; }
    }
}
