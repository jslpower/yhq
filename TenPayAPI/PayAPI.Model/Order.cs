namespace PayAPI.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 订单商品信息
    /// </summary>
    public class Order
    {
        private string _body = "";
        private List<string> _orderid = new List<string>();
        private string _subject = "";

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Body
        {
            get
            {
                return this._body;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._body = value;
                    if (this._body.Length > 40)
                    {
                        this._body = this._body.Substring(0, 40) + "...";
                    }
                }
            }
        }

        /// <summary>
        /// 订单ID列表(只适用于一次支付少于10个订单ID左右)
        /// </summary>
        public List<string> OrderID
        {
            get
            {
                return this._orderid;
            }
            set
            {
                this._orderid = value;
            }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Subject
        {
            get
            {
                return this._subject;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._subject = value.Replace(" ", "");
                    if (this._subject.Length > 80)
                    {
                        this._subject = this._subject.Substring(0, 80) + "...";
                    }
                }
            }
        }
    }
}

