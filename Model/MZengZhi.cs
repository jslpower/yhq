using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MZengZhi
    {
        /// <summary>
        /// 分享编号
        /// </summary>
        public int FenXiangID { get; set; }
        /// <summary>
        /// 红包编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 分享人ID
        /// </summary>
        public string FenXiangRenID { get; set; }
        /// <summary>
        /// 分享时间
        /// </summary>
        public DateTime FenXiangShiJian { get; set; }
        /// <summary>
        /// 增值
        /// </summary>
        public decimal ZengZhi { get; set; }

        #region 扩展
        /// <summary>
        /// 分享人姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 分享人账号
        /// </summary>
        public string UserName { get; set; }
        #endregion
    }
    /// <summary>
    /// 增值搜索类
    /// </summary>
    public class MZengZhiSer
    {

    }
}
