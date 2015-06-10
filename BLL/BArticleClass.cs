using System;
using System.Collections.Generic;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BArticleClass
    {
        private readonly EyouSoft.DAL.DArticleClass dal = new EyouSoft.DAL.DArticleClass();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BArticleClass() { }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(EyouSoft.Model.MArticleClass model)
        {
            if (!string.IsNullOrEmpty(model.ClassName))
                return dal.Add(model) == 0 ? false : true;
            else
                return false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.MArticleClass model)
        {
            if (!string.IsNullOrEmpty(model.ClassName) && model.ClassId > 0)
                return dal.Update(model) == 0 ? false : true;
            else
                return false;
            
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public bool Delete(string ClassId)
        {
            if (string.IsNullOrEmpty(ClassId)) return false;
            return dal.Delete(ClassId) == 0 ? false : true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MArticleClass GetModel(int ClassId)
        {
            if (ClassId == 0) return null;
            return dal.GetModel(ClassId);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MArticleClass> GetList(EyouSoft.Model.MArticleClass Search)
        {
            return dal.GetList(0, Search);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MArticleClass> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MArticleClass Search)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, Search);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MArticleClass> GetList(int top, EyouSoft.Model.MArticleClass Search)
        {
            return dal.GetList(top, Search);
        }
    }
}
