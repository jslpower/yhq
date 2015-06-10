using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class BYuYue
    {
        Eyousoft_yhq.SQLServerDAL.DYuYue dal = new Eyousoft_yhq.SQLServerDAL.DYuYue();
        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.MYuYue model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MYuYue GetModel(string id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MYuYue> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MYuYueSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }

    }
}
