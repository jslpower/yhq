namespace PayAPI.Model
{
    using System;

    /// <summary>
    /// 支付的基本业务信息基类
    /// </summary>
    public class PayTrade
    {
        private AttachCollection _attachlist = new AttachCollection();
        private Order _orderinfo = new Order();
        private string _outtradeno = "";
        private decimal _totalfee = 0.0M;

        /// <summary>
        /// 构造方法
        /// </summary>
        public PayTrade()
        {
            this._outtradeno = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 商家数据包集合
        /// </summary>
        public AttachCollection AttachList
        {
            get
            {
                return this._attachlist;
            }
            set
            {
                this._attachlist = value;
            }
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        public Order OrderInfo
        {
            get
            {
                return this._orderinfo;
            }
            set
            {
                this._orderinfo = value;
            }
        }

        /// <summary>
        /// 获得外部支付流水号(由我们传给支付接口的唯一订单号),默认值为:按当前时间构造订单号(年+月+日+小时+分+秒+毫秒)
        /// </summary>
        public virtual string OutTradeNo
        {
            get
            {
                return this._outtradeno;
            }
            set
            {
                this._outtradeno = value;
            }
        }

        /// <summary>
        /// 支付的总金额(0.01～100000000.00，最多2位小数，四舍五入)
        /// </summary>
        public virtual decimal Totalfee
        {
            get
            {
                return this._totalfee;
            }
            set
            {
                if ((value < 0.01M) || (value > 100000000M))
                {
                    throw new Exception("金额不在有效范围内!");
                }
                this._totalfee = value;
            }
        }
    }
}

