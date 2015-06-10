namespace PayAPI.Model.Tencent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 业务描述集合
    /// </summary>
    public class BusinessDescribe
    {
        private List<string> _describe = new List<string>();

        /// <summary>
        /// 添加业务描述信息
        /// </summary>
        /// <param name="describe">描述信息</param>
        public void Add(string describe)
        {
            this._describe.Add(describe.Replace("^", " ").Replace("|", " "));
        }

        /// <summary>
        /// 输出拼接后的业务描述字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ((this._describe == null) || (this._describe.Count == 0))
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            foreach (string str in this._describe)
            {
                builder.Append(str + "^");
            }
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            return builder.ToString();
        }
    }
}

