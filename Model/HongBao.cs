using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class HongBao
    {
        /// <summary>
        /// 红包编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 红包金额
        /// </summary>
        public decimal HongBaoJinE { get; set; }

        #region 扩展
        /// <summary>
        /// 会员账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string ContactName { get; set; }
        #endregion

    }

    public class HongBaoSer
    {

        /// <summary>
        /// 会员编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string ContactName { get; set; }

    }
}
