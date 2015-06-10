namespace PayAPI.Model.Tencent
{
    using PayAPI.Model;

    /// <summary>
    /// 财务通的返回通知交易业务实体
    /// </summary>
    public class TenPayTradeNotify : PayTradeNotify
    {
        public TenPayTradeNotify()
        {
            PayNotify = new PrePay();
        }

        public PrePay PayNotify
        {
            get;
            set;
        }
    }
}

