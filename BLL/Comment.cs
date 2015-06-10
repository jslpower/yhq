using System;
using System.Data;
using System.Collections.Generic;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 评论表
    /// </summary>
    public partial class Comment
    {
        private readonly Eyousoft_yhq.SQLServerDAL.Comment dal = new Eyousoft_yhq.SQLServerDAL.Comment();
        public Comment()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eyousoft_yhq.Model.Comment model)
        {
            model.CommentID = Guid.NewGuid().ToString();
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(string[] modelIDs)
        {
            if (modelIDs == null || modelIDs.Length < 1) return false;
            return dal.Update(modelIDs);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string[] strIDs)
        {
            if (strIDs == null || strIDs.Length < 1) return false;
            return dal.Delete(strIDs);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.Comment GetModel(string strID)
        {
            if (string.IsNullOrEmpty(strID)) return null;
            return dal.GetModel(strID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Eyousoft_yhq.Model.Comment> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serComment serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<Eyousoft_yhq.Model.Comment> GetList( Eyousoft_yhq.Model.serComment serModel)
        {
            return dal.GetList(serModel);
        }
        /// <summary>
        /// 获取产品的留言数量
        /// </summary>
        /// <param name="id">产品编号</param>
        /// <returns></returns>
        public int GetCountNum(string id)
        {
            return dal.GetCountNum(id);
        }

        #endregion  成员方法
    }
}

