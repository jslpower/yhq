using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public class MYuYue
    {
        /// <summary>
        /// 预约编号
        /// </summary>
        public int YYID { get; set; }
        /// <summary>
        /// 预约线路
        /// </summary>
        public string YYRoute { get; set; }
        /// <summary>
        /// 预约人姓名
        /// </summary>
        public string YYName { get; set; }
        /// <summary>
        /// 预约人电话
        /// </summary>
        public string YYMobile { get; set; }
        /// <summary>
        /// 预约信息
        /// </summary>
        public string YYInfo { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime YYTime { get; set; }
    }
    public class MYuYueSer
    {

    }
}
