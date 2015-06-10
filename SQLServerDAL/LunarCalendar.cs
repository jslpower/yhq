using System;
using System.Collections.Generic;

namespace Eyousoft_yhq.SQLServerDAL
{
    #region 农历信息业务实体
    /// <summary>
    /// 农历信息业务实体
    /// </summary>
    public class LunarCalendar
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 月份中的天数
        /// </summary>
        public int DaysInMonth { get; set; }
        /// <summary>
        /// 年份中的天数
        /// </summary>
        public int DaysInYear { get; set; }
    }
    #endregion
}
