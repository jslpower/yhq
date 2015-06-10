using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    //新闻栏目新闻
   public class News
    {
        /// <summary>
        /// 新闻 ID 
        /// </summary>
       public string NewsID { get; set; }
        /// <summary>
       /// 新闻名称
        /// </summary>
       public string NewsTitle { get; set; }
        /// <summary>
       /// 创建时间
        /// </summary>
       public DateTime CreateTime { get; set; }
    }
}
