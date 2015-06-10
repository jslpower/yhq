namespace PayAPI.Model
{
    using System;

    /// <summary>
    /// 商家数据包参数实体
    /// </summary>
    public class Attach
    {
        private string _key;
        private string _value;

        /// <summary>
        /// 构造方法
        /// </summary>
        public Attach()
        {
            this._key = "";
            this._value = "";
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="key">key键，请勿使用特殊字符以及中文(不区分大小写，名称命名竟然简短，否则将过多占用数据包长度)</param>
        /// <param name="value">数据值，请勿使用特殊字符以及中文</param>
        public Attach(string key, string value)
        {
            this._key = "";
            this._value = "";
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// key键，请勿使用特殊字符以及中文(不区分大小写，名称命名竟然简短，否则将过多占用数据包长度)
        /// </summary>
        public string Key
        {
            get
            {
                return this._key;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._key = value.ToLower().Replace("^", " ").Replace("|", "").Replace("&", " ").Replace("?", " ").Replace("=", " ");
                }
            }
        }

        /// <summary>
        /// 数据值，请勿使用特殊字符以及中文
        /// </summary>
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._value = value.Replace("^", " ").Replace("|", "").Replace("&", " ").Replace("?", " ").Replace("=", " ");
                }
            }
        }
    }
}

