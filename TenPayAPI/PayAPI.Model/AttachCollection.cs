namespace PayAPI.Model
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// 商家数据包参数集合
    /// </summary>
    public class AttachCollection
    {
        private List<Attach> _list = new List<Attach>();

        /// <summary>
        /// 添加键值对数据
        /// </summary>
        /// <param name="model">数据包键值对</param>
        public void Add(Attach model)
        {
            if (this._list.Find(delegate (Attach item) {
                return item.Key == model.Key;
            }) != null)
            {
                throw new Exception("不能包含重复的Key:" + model.Key);
            }
            this._list.Add(model);
        }

        /// <summary>
        /// 设置指定格式的字符串数据包到当前实体集合中
        /// </summary>
        /// <param name="formatStr">指定格式的字符串(key1^value1|key2^value2)</param>
        /// <returns></returns>
        public void ToCollection(string formatStr)
        {
            this._list.Clear();
            if (!string.IsNullOrEmpty(formatStr))
            {
                string[] strArray = formatStr.Split("|".ToCharArray());
                if ((strArray != null) && (strArray.Length > 0))
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(strArray[i]))
                        {
                            string[] strArray2 = strArray[i].Split("^".ToCharArray());
                            if ((strArray2 != null) && (strArray2.Length == 2))
                            {
                                string str = strArray2[0];
                                string str2 = strArray2[1];
                                if (!string.IsNullOrEmpty(str))
                                {
                                    Attach model = new Attach();
                                    model.Key = str;
                                    model.Value = str2;
                                    this.Add(model);
                                    model = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 输出按一定格式拼接后的商家数据包
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ((this._list == null) || (this._list.Count == 0))
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            foreach (Attach attach in this._list)
            {
                builder.AppendFormat("{0}^{1}|", attach.Key, attach.Value);
            }
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 获得集合个数
        /// </summary>
        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }

        /// <summary>
        /// 根据索引值获取数据包实体(若不存在该key则返回null)
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Attach this[int index]
        {
            get
            {
                return this._list[index];
            }
        }

        /// <summary>
        /// 根据KEY值获取数据包实体(若不存在该key则返回null)
        /// </summary>
        /// <param name="key">key(不区分大小写)</param>
        /// <returns></returns>
        public Attach this[string key]
        {
            get
            {
                return this._list.Find(delegate (Attach item) {
                    return item.Key == key.ToLower();
                });
            }
        }
    }
}

