namespace PayAPI.Model.Tencent
{
    using PayAPI.Model;
    using PayAPI.Tencent.Core;
    using System;

    /// <summary>
    /// 财付通交易业务实体
    /// </summary>
    public class TenPayTrade : PayTrade
    {
        private BusinessDescribe _describe = new BusinessDescribe();
        private bool _isroyalty = true;
        private string _outtradeno = "";
        //private PayAPI.Model.Tencent.RoyaltyList _royallist = new PayAPI.Model.Tencent.RoyaltyList();

        /// <summary>
        /// 构造方法
        /// </summary>
        //public TenPayTrade()
        //{
        //    // this._outtradeno = TenPaySystem.BargainorId + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + TenpayUtil.BuildRandomStr(4);
        //}

        ///// <summary>
        ///// 该笔交易是否要提成、分润，默认为true
        ///// </summary>
        //public bool IsRoyalty
        //{
        //    get
        //    {
        //        return this._isroyalty;
        //    }
        //    set
        //    {
        //        this._isroyalty = value;
        //    }
        //}

        /// <summary>
        /// 获得外部支付流水号(由我们传给支付接口的唯一订单号),默认值为:10位商户号+8位时间（YYYYmmdd)+10位流水号
        /// </summary>
        public override string OutTradeNo
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
        /// 用户公网ip
        /// </summary>
        public string UserIP
        {
            get;
            set;

        }

        /// <summary>
        /// 用户OPENID
        /// </summary>
        public string OPENID
        {
            get;
            set;

        }

        ///// <summary>
        ///// 分润、提成信息集合
        ///// </summary>
        //public PayAPI.Model.Tencent.RoyaltyList RoyaltyList
        //{
        //    get
        //    {
        //        if (!this._isroyalty)
        //        {
        //            throw new Exception("未开启分润功能，请设置IsRoyalty属性为True");
        //        }
        //        return this._royallist;
        //    }
        //    set
        //    {
        //        if (!this._isroyalty)
        //        {
        //            throw new Exception("未开启分润功能，请设置IsRoyalty属性为True");
        //        }
        //        this._royallist = value;
        //    }
        //}
    }
}

