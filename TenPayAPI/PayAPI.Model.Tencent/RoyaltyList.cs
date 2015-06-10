namespace PayAPI.Model.Tencent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 分润提成信息集合
    /// </summary>
    public class RoyaltyList
    {
        private List<Royalty> _royallist = new List<Royalty>();
        /// <summary>
        /// 所有分润的总金额[单位：元]
        /// </summary>
        private decimal _totalmoney = 0.0M;

        /// <summary>
        /// 添加分润信息
        /// </summary>
        /// <param name="royalty"></param>
        public void Add(Royalty royalty)
        {
            this._royallist.Add(royalty);
            this._totalmoney += royalty.Price;
        }

        /// <summary>
        /// 输出分润，拼接后的分润字符串信息
        /// </summary>
        /// <param name="totalfee">要支付的总金额[单位：元]</param>
        /// <returns></returns>
        public string ToString(decimal totalfee)
        {
            if ((this._royallist == null) || (this._royallist.Count == 0))
            {
                return "";
            }
            if (totalfee != this._totalmoney)
            {
                throw new Exception("分润总金额必须等于总的支付金额");
            }
            StringBuilder builder = new StringBuilder();
            int num = 0;
            foreach (Royalty royalty in this._royallist)
            {
                if (string.IsNullOrEmpty(royalty.Account))
                {
                    throw new Exception("缺少要分润的账户信息");
                }
                object[] objArray = new object[] { royalty.Account, "^", (royalty.Price * 100M).ToString("F0"), "^", (int) royalty.Role, "|" };
                builder.Append(string.Concat(objArray));
                if (royalty.Role == RoyaltyRole.供应商)
                {
                    num++;
                }
            }
            if (num < 1)
            {
                throw new Exception("分润时，必须要包含有供应商角色，且只能有一个");
            }
            if (num > 1)
            {
                throw new Exception("分润时，供应商角色只能有一个");
            }
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            return builder.ToString();
        }
    }
}

