using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class HotLines
    {
        /// <summary>
        /// 热点航线
        /// </summary>
        public string HotLine { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>
        public string Ext { get; set; }
        /// <summary>
        /// 起飞城市
        /// </summary>

        public string BoardPoint { get; set; }
        /// <summary>
        /// 信用额度
        /// </summary>
        public string 到达城市 { get; set; }
        /// <summary>
        /// 航线价格列表
        /// </summary>
        public string PriceItems { get; set; }
    }
}
