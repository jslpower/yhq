using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class GYSticket
    {
        Eyousoft_yhq.SQLServerDAL.GYSticket dal = new Eyousoft_yhq.SQLServerDAL.GYSticket();

        #region IProduct 成员


        /// <summary>
        /// 车票/景点门票添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.GYSticket model)
        {
            model.ID = Guid.NewGuid().ToString();
            model.IssueTime = DateTime.Now;
            return dal.Add(model);

        }
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Eyousoft_yhq.Model.GYSticket model)
        {
            if (string.IsNullOrEmpty(model.ID)) return false;
            model.IssueTime = DateTime.Now;
            return dal.Update(model);

        }


        /// <summary>
        /// 删除/批量删除
        /// </summary>
        /// <param name="ProductIDs">单个ID/多个ID拼接的字符串</param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            return dal.Delete(id);
        }



        public Eyousoft_yhq.Model.GYSticket GetModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return dal.GetModel(id);
        }

        /// <summary>
        /// 返回分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.GYSticket> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.GysTicketSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 返回分页列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.GYSticket> GetList( Eyousoft_yhq.Model.GysTicketSer serModel)
        {
            return dal.GetList(serModel);
        }



        #endregion
    }
}
