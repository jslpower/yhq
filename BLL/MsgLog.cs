using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class MsgLog
    {
        Eyousoft_yhq.SQLServerDAL.MsgLog dal = new Eyousoft_yhq.SQLServerDAL.MsgLog();
        public MsgLog() { }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.MsgLog model)
        {
            if (string.IsNullOrEmpty(model.TelCode) ||
               string.IsNullOrEmpty(model.MsgText)) return false;
            return dal.Add(model);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize">每页显示条数</param>
        /// <param name="PageIndex">当前页数</param>
        /// <param name="RecordCount">总页数</param>
        /// <param name="serModel">搜索实体</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MsgLog> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serMsgLog serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }


    }
}
