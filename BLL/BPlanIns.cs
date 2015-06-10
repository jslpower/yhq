using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class BPlanIns
    {
        Eyousoft_yhq.SQLServerDAL.DPlanIns dal = new Eyousoft_yhq.SQLServerDAL.DPlanIns();
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">保险</param>
        /// <returns></returns>
        public int Insert(Eyousoft_yhq.Model.MPlanIns model)
        {
            model.OrderID = Guid.NewGuid().ToString();
            return dal.Insert(model);
        }
        /// <summary>
        /// 获取保险编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MPlanIns GetModel(int id)
        {
            if (id == 0) return null;
            return dal.GetModel(id);
        }
        /// <summary>
        /// 获取保险编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MPlanIns> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MPlanInsSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
    }
}
