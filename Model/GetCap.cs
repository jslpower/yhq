using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
   public class GetCap
    {
        /// <summary>
        /// 舱为单程特价
        /// </summary>
       public string T { get; set; }
        /// <summary>
       /// 头等舱
        /// </summary>
       public string F { get; set; }
        /// <summary>
       /// 公务舱
        /// </summary>
       public string C { get; set; }
        /// <summary>
       /// 经济舱
        /// </summary>
       public string Y { get; set; }
        /// <summary>
       /// 95 折扣
        /// </summary>
       public string F95 { get; set; }
        /// <summary>
       /// 90 折扣
        /// </summary>
       public string F90 { get; set; }
        /// <summary>
       /// 85 折扣
        /// </summary>
       public string F85 { get; set; }
       /// <summary>
       /// F15 往返特价一 
       /// </summary>
       public string F15 { get; set; }
       /// <summary>
       /// F10 往返特价二
       /// </summary>
       public string F10 { get; set; }
    }
}
