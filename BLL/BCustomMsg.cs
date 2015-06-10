using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class BCustomMsg
    {
        Eyousoft_yhq.SQLServerDAL.DCustomMsg dal = new Eyousoft_yhq.SQLServerDAL.DCustomMsg();
        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.CustomMsg model)
        {

            return dal.Add(model);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.CustomMsg GetModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
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
        public IList<Eyousoft_yhq.Model.CustomMsg> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serCustomMsg serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userid">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.WXBind GetWXBind(string userid)
        {
            if (string.IsNullOrEmpty(userid)) return null;
            return dal.GetWXBind(userid);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userid">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.WXBind GetWXBindByOpenid(string openid)
        {
            if (string.IsNullOrEmpty(openid)) return null;
            return dal.GetWXBindByOpenid(openid);
        }
        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddWXBind(Eyousoft_yhq.Model.WXBind model)
        {
            if (string.IsNullOrEmpty(model.CustomerId)) return 0;
            return dal.Add(model);
        }
        /// <summary>
        ///  修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int updateWXBind(Eyousoft_yhq.Model.WXBind model)
        {
            if (model.Id < 1) return 0;
            return dal.updateWXBind(model);
        }
    }
}
