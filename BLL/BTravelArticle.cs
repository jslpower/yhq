using System;
using System.Collections.Generic;
 using System.Text;
using Eyousoft_yhq.SQLServerDAL;
 
namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 旅游资讯
    /// </summary>
    public class BTravelArticle
    {
        private readonly EyouSoft.DAL.DTravelArticle dal = new EyouSoft.DAL.DTravelArticle();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BTravelArticle() { }
        #endregion

        #region public members
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EyouSoft.Model.MTravelArticle model)
        {

            if (model != null && !string.IsNullOrEmpty(model.ArticleTitle))
            {
                model.ArticleID = Guid.NewGuid().ToString();
                return dal.Add(model);
            }
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EyouSoft.Model.MTravelArticle model)
        {
            if (model != null && !string.IsNullOrEmpty(model.ArticleID) && !string.IsNullOrEmpty(model.ArticleTitle))
                return dal.Update(model);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(string ArticleID)
        {
            if (!string.IsNullOrEmpty(ArticleID))
                return dal.Delete(ArticleID);
            else
                return false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params string[] Ids)
        {
            if (Ids == null && Ids.Length == 0) return false;
            return dal.Delete(Ids);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MTravelArticle GetModel(string ArticleID)
        {
            if (!string.IsNullOrEmpty(ArticleID))
                return dal.GetModel(ArticleID);
            else
                return null;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelArticle> GetList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MTravelArticleCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun, FiledOrder);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelArticle> GetTopList(int Top, EyouSoft.Model.MTravelArticleCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            return dal.GetTopList((Top < 0 ? 0 : Top), chaXun, FiledOrder);
        }


        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="Id"></param>
        public void SetClick(string Id)
        {
            dal.SetClick(Id);
        }

        /// <summary>
        /// 获取首页底部的四个帮助信息
        /// </summary>
        /// <returns></returns>
        public IList<Model.MTravelArticle> GetHeadZiXun()
        {
            return dal.GetHeadZiXun();
        }

        #region 旅游资讯留言

        /// <summary>
        /// 增加一条留言
        /// </summary>
        public bool AddLiuYan(EyouSoft.Model.MTravelArticleLY model)
        {
            if (model != null && !string.IsNullOrEmpty(model.MemberID) && !string.IsNullOrEmpty(model.ArticleID))
            {
                model.LiuYanId = Guid.NewGuid().ToString();
                return dal.AddLiuYan(model);
            }
            else
                return false;
        }
        /// <summary>
        /// 回复留言
        /// </summary>
        public bool UpdateLiuYan(EyouSoft.Model.MTravelArticleLY model)
        {
            if (model != null && !string.IsNullOrEmpty(model.LiuYanId) && !string.IsNullOrEmpty(model.OperatorId))
                return dal.UpdateLiuYan(model);
            else
                return false;
        }

        /// <summary>
        /// 更新留言的审核状态
        /// </summary>
        /// <param name="DianPingIds"></param>
        /// <returns></returns>
        public bool UpdateLiuYan(bool IsCheck, params string[] LiuYanIds)
        {
            if (LiuYanIds != null && LiuYanIds.Length > 0)
                return dal.UpdateLiuYan(IsCheck, LiuYanIds);
            else
                return false;
        }
        /// <summary>
        /// 删除留言数据
        /// </summary>
        public bool DeleteLiuYan(params string[] LiuYanIds)
        {
            if (LiuYanIds != null && LiuYanIds.Length > 0)
                return dal.DeleteLiuYan(LiuYanIds);
            else
                return false;
        }
        /// <summary>
        /// 得到一个留言对象实体
        /// </summary>
        public EyouSoft.Model.MTravelArticleLY GetLiuYanModel(string LiuYanId)
        {
            if (!string.IsNullOrEmpty(LiuYanId))
                return dal.GetLiuYanModel(LiuYanId);
            else
                return null;
        }
        /// <summary>
        /// 获得留言数据列表
        /// </summary>
        public IList<EyouSoft.Model.MTravelArticleLY> GetLiuYanList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MTravelArticleLYCX chaxun)
        {
            if (!Utils.ValidPaging(PageSize, PageIndex))
                return null;
            return dal.GetLiuYanList(PageSize, PageIndex, ref RecordCount, chaxun);
        }
        /// <summary>
        /// 获得留言前几行数据
        /// </summary>
        public IList<EyouSoft.Model.MTravelArticleLY> GetLiuYanList(int Top, EyouSoft.Model.MTravelArticleLYCX chaxun)
        {
            return dal.GetLiuYanList((Top < 0 ? 0 : Top), chaxun);
        }

        #endregion

        #endregion
    }
}
