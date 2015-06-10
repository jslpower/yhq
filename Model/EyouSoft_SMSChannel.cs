using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    /// <summary>
    /// 短信通道实体
    /// </summary>
    /// Author:张志瑜 2010-09-20
    public class SMSChannel
    {
        /// <summary>
        /// 该通道短信通道索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 该通道短信通道名称
        /// </summary>
        public string ChannelName { get; set; }
        /// <summary>
        /// 该通道发送短信的用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 该通道发送短信的密码
        /// </summary>
        public string Pw { get; set; }
        /// <summary>
        /// 该通道发送1条短信的价格(单位:分/条)
        /// </summary>
        public decimal PriceOne { get; set; }
        /// <summary>
        /// 是否为长短信通道,true则为210个字的长短信
        /// </summary>
        public bool IsLong { get; set; }
    }

    #region SendType 短信发送方式
    /// <summary>
    /// 短信发送方式
    /// </summary>
    public enum SendType
    {
        /// <summary>
        /// 直接发送
        /// </summary>
        直接发送 = 0,
        /// <summary>
        /// 定时发送
        /// </summary>
        定时发送
    }
    #endregion
}
