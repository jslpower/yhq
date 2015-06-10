namespace PayAPI.Model
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 支付的返回通知基本业务信息基类
    /// </summary>
    public class PayTradeNotify : PayTrade
    {
        private bool _istradesuccess;

        /// <summary>
        /// 付款人(即买家)账号
        /// </summary>
        public string OpenID
        {

            get;

            set;
        }

        /// <summary>
        /// 需要调试的消息输出
        /// </summary>
        public string DebugOutPut
        {

            get;

            set;
        }

        /// <summary>
        /// 交易是否成功
        /// </summary>
        public bool IsTradeSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// 返回通知时间[并不保证该字段都有值]
        /// </summary>
        public DateTime NotifyTime
        {

            get;

            set;
        }

        /// <summary>
        /// 获得外部支付流水号(由我们传给支付接口的唯一订单号)
        /// </summary>
        public override string OutTradeNo
        {

            get;

            set;
        }

        /// <summary>
        /// 接收到支付接口通知后，支付接口要回调的消息内容
        /// </summary>
        public string PayAPICallBackMsg
        {

            get;

            set;
        }

        /// <summary>
        /// 获得支付接口的支付流水号(由支付接口传给我们的唯一订单号)
        /// </summary>
        public string TradeNo
        {

            get;

            set;
        }
    }
}

