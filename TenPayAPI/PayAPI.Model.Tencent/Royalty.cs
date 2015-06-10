namespace PayAPI.Model.Tencent
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 分润信息
    /// </summary>
    public class Royalty
    {
        /// 业务参数
        /// 帐号^分帐金额^角色
        /// 角色说明:	1:供应商 2:平台服务方 4:独立分润方
        /// 帐号1^分帐金额1^角色1|帐号2^分帐金额2^角色2|...
        private decimal _price = 0.0M;

        /// <summary>
        /// 接受分润、提成的账户
        /// </summary>
        public string Account
        {

            get;

            set;
        }

        /// <summary>
        /// 分润、提成金额(0.01～100000000.00，最多2位小数，四舍五入)
        /// </summary>
        public decimal Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((value < 0.01M) || (value > 100000000M))
                {
                    throw new Exception("金额不在有效范围内!");
                }
                this._price = value;
            }
        }

        /// <summary>
        /// 分润角色
        /// </summary>
        public RoyaltyRole Role
        {

            get;

            set;
        }
    }
}

