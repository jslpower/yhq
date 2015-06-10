using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Common.Function
{   
   /// <summary>
   /// 自定义分页
   /// </summary>
    public class SelfExportPage
    {   
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static IList<T> GetList<T>(int pageIndex, int pageSize, out int recordCount, IList<T> list)
        {
            if (list != null && list.Count > 0)
            {
                pageSize = pageSize <= 0 ? 1 : pageSize;
                recordCount = list.Count;
                return list.Skip(((pageIndex<=0?1:pageIndex) - 1) * pageSize).Take(pageSize).ToList();
            }
            recordCount = 0;
            return null;
        }

    }
}
