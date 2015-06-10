using System;
using System.Data;
using System.Collections.Generic;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 轮换图片/轮换图片
    /// </summary>
    public partial class ProductType
    {
        private readonly Eyousoft_yhq.SQLServerDAL.ProductType dal = new Eyousoft_yhq.SQLServerDAL.ProductType();
        public ProductType()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TypeName)
        {
            if (string.IsNullOrEmpty(TypeName)) return false;
            return dal.Exists(TypeName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eyousoft_yhq.Model.ProductType model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eyousoft_yhq.Model.ProductType model)
        {
            if (model.TypeID == 0) return false;
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int[] TypeID)
        {
            if (TypeID.Length < 1) return false;
            return dal.Delete(TypeID);

        }


        public Eyousoft_yhq.Model.ProductType GetModel(int TypeID)
        {
            if (TypeID == 0) return null;
            return dal.GetModel(TypeID);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize">每页条数</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="serModel">搜索条件</param>
        /// <param name="i">添加类型</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.ProductType> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serProductType serModel, string i) 
        {

            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel, i);
        }
        public IList<Eyousoft_yhq.Model.ProductType> GetList(Eyousoft_yhq.Model.serProductType serModel)
        {

            return dal.GetList(serModel);
        }

        #endregion  成员方法
    }
}

