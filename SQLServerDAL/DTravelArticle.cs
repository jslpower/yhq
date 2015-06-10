using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Eyousoft_yhq.SQLServerDAL;
using Eyousoft_yhq.Model;

namespace EyouSoft.DAL
{
    public class DTravelArticle : Eyousoft_yhq.SQLServerDAL.DALBase
    {

        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DTravelArticle()
        {
            _db = SystemStore;
        }
        #endregion

        #region ITravelArticle 成员

        #region 旅游资讯
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EyouSoft.Model.MTravelArticle model)
        {
            string StrSql = "INSERT INTO tbl_TravelArticle(ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag";
            StrSql += ",TitleColor,KeyWords,ClassId,IsFrontPage,IsHot,IssueTime,OperatorId,LinkUrl,Click,SortRule)";
            StrSql += " VALUES(@ArticleID,@Source,@ArticleTitle,@ImgPath,@Description,@ArticleText,@ArticleTag";
            StrSql += ",@TitleColor,@KeyWords,@ClassId,@IsFrontPage,@IsHot,@IssueTime,@OperatorId,@LinkUrl,@Click,@SortRule)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "ArticleID", DbType.AnsiStringFixedLength, model.ArticleID);
            this._db.AddInParameter(dc, "Source", DbType.String, model.Source);
            this._db.AddInParameter(dc, "ArticleTitle", DbType.String, model.ArticleTitle);
            this._db.AddInParameter(dc, "ImgPath", DbType.String, model.ImgPath);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "ArticleText", DbType.String, model.ArticleText);
            this._db.AddInParameter(dc, "ArticleTag", DbType.String, model.ArticleTag);
            this._db.AddInParameter(dc, "TitleColor", DbType.String, model.TitleColor);
            this._db.AddInParameter(dc, "KeyWords", DbType.String, model.KeyWords);
            this._db.AddInParameter(dc, "ClassId", DbType.Int32, model.ClassId);
            this._db.AddInParameter(dc, "IsFrontPage", DbType.AnsiStringFixedLength, model.IsFrontPage.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IsHot", DbType.AnsiStringFixedLength, model.IsHot.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(dc, "OperatorId", DbType.StringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "LinkUrl", DbType.String, model.LinkUrl);
            this._db.AddInParameter(dc, "Click", DbType.Int32, model.Click);
            this._db.AddInParameter(dc, "SortRule", DbType.Int32, model.SortRule);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EyouSoft.Model.MTravelArticle model)
        {
            string StrSql = "UPDATE tbl_TravelArticle SET ";
            StrSql += "Source=@Source,ArticleTitle=@ArticleTitle,ImgPath=@ImgPath,Description=@Description";
            StrSql += ",ArticleText=@ArticleText,ArticleTag=@ArticleTag,TitleColor=@TitleColor,KeyWords=@KeyWords";
            StrSql += ",ClassId=@ClassId,IsFrontPage=@IsFrontPage,IsHot=@IsHot,IssueTime=@IssueTime";
            StrSql += ",OperatorId=@OperatorId,LinkUrl=@LinkUrl,SortRule=@SortRule ";
            StrSql += " WHERE ArticleID=@ArticleID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Source", DbType.String, model.Source);
            this._db.AddInParameter(dc, "ArticleTitle", DbType.String, model.ArticleTitle);
            this._db.AddInParameter(dc, "ImgPath", DbType.String, model.ImgPath);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "ArticleText", DbType.String, model.ArticleText);
            this._db.AddInParameter(dc, "ArticleTag", DbType.String, model.ArticleTag);
            this._db.AddInParameter(dc, "TitleColor", DbType.String, model.TitleColor);
            this._db.AddInParameter(dc, "KeyWords", DbType.String, model.KeyWords);
            this._db.AddInParameter(dc, "ClassId", DbType.Int32, model.ClassId);
            this._db.AddInParameter(dc, "IsFrontPage", DbType.AnsiStringFixedLength, model.IsFrontPage.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IsHot", DbType.AnsiStringFixedLength, model.IsHot.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(dc, "OperatorId", DbType.StringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "LinkUrl", DbType.String, model.LinkUrl);
            this._db.AddInParameter(dc, "SortRule", DbType.Int32, model.SortRule);
            this._db.AddInParameter(dc, "ArticleID", DbType.AnsiStringFixedLength, model.ArticleID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(string ArticleID)
        {
            string StrSql = "DELETE FROM tbl_TravelArticle WHERE ArticleID=@ArticleID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "ArticleID", DbType.AnsiStringFixedLength, ArticleID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params string[] Ids)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in Ids)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    StrSql.AppendFormat(" DELETE FROM tbl_TravelArticle WHERE ArticleID='{0}' ", id);
                }
            }

            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MTravelArticle GetModel(string ArticleID)
        {
            EyouSoft.Model.MTravelArticle model = null;
            string StrSql = "SELECT ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,(select top 1 ClassName from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId) as ClassName,IsFrontPage,IsHot,IssueTime,OperatorId,(select ContactName from tbl_User where UserID=tbl_TravelArticle.OperatorId) as OperatorName,LinkUrl,Click,SortRule FROM tbl_TravelArticle WHERE ArticleID=@ArticleID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "ArticleID", DbType.AnsiStringFixedLength, ArticleID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.MTravelArticle();

                    model.ArticleID = dr.GetString(dr.GetOrdinal("ArticleID"));
                    model.Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source"));
                    model.ArticleTitle = dr.IsDBNull(dr.GetOrdinal("ArticleTitle")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTitle"));
                    model.ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath"));
                    model.Description = dr.IsDBNull(dr.GetOrdinal("Description")) ? "" : dr.GetString(dr.GetOrdinal("Description"));
                    model.ArticleText = dr.IsDBNull(dr.GetOrdinal("ArticleText")) ? "" : dr.GetString(dr.GetOrdinal("ArticleText"));
                    model.ArticleTag = dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag"));
                    model.TitleColor = dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor"));
                    model.KeyWords = dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords"));
                    model.ClassId = dr.GetInt32(dr.GetOrdinal("ClassId"));
                    model.ClassName = dr.IsDBNull(dr.GetOrdinal("ClassName")) ? "" : dr.GetString(dr.GetOrdinal("ClassName"));
                    model.IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false;
                    model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl"));
                    model.Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click"));
                    model.SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"));

                }
            };
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序字段</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelArticle> GetList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MTravelArticleCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            IList<EyouSoft.Model.MTravelArticle> ResultList = null;
            string tableName = "tbl_TravelArticle";
            StringBuilder fields = new StringBuilder();
            fields.Append("ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,IsFrontPage,IsHot,IssueTime,OperatorId,LinkUrl,Click,SortRule,");
            fields.Append("(select top 1 ClassName,IsSystem from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId for xml raw,root('Root')) as ClassName,(select ContactName from tbl_User where UserID=tbl_TravelArticle.OperatorId) as OperatorName");
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.Source))
                {
                    query = query + string.Format(" AND Source like '%{0}%'", chaXun.Source);
                }
                if (!string.IsNullOrEmpty(chaXun.ArticleTitle))
                {
                    query = query + string.Format(" AND ArticleTitle like '%{0}%'", chaXun.ArticleTitle);
                }
                if (!string.IsNullOrEmpty(chaXun.KeyWords))
                {
                    query = query + string.Format(" AND KeyWords like '%{0}%'", chaXun.KeyWords);
                }
                if (!string.IsNullOrEmpty(chaXun.ArticleTag))
                {
                    query = query + string.Format(" AND ArticleTag like '%{0}%'", chaXun.ArticleTag);
                }
                if (chaXun.ClassId > 0)
                {
                    query = query + string.Format(" AND ClassId={0}", chaXun.ClassId);
                }
                if (chaXun.IsFrontPage.HasValue)
                {
                    query = query + string.Format(" AND IsFrontPage='{0}'", chaXun.IsFrontPage.Value ? 1 : 0);
                }
                if (chaXun.IsHot.HasValue)
                {
                    query = query + string.Format(" AND IsHot='{0}'", chaXun.IsHot.Value ? 1 : 0);
                }
                if (chaXun.IssueTimeBegin != null)
                {
                    query = query + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeBegin.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeEnd != null)
                {
                    query = query + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeEnd.Value.ToShortDateString() + " 23:59:59");
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorId))
                {
                    query = query + string.Format(" AND OperatorId='{0}'", chaXun.OperatorId);
                }
                if (chaXun.IsSystem != null && chaXun.IsSystem.Length > 0)
                {
                    query = query + string.Format(" AND exists(select 1 from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId and IsSystem in ({0})) ", Utils.GetSqlIn(chaXun.IsSystem));
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorName))
                {

                    query = query + string.Format(" AND exists(select 1 from tbl_User where UserID=tbl_TravelArticle.OperatorId and ContactName like '%{0}%') ", chaXun.OperatorName);
                }

                if (chaXun.ZXtype != null && chaXun.ZXtype.Length > 0)
                {
                    query = query + string.Format(" AND ClassId IN (select ClassId from tbl_TravelArticleClass where ClassName  in  ({0})) ", Utils.GetSqlIn(chaXun.ZXtype));
                }
            }
            string orderByString = "";
            if (FiledOrder != null && FiledOrder.Count > 0)
            {
                for (int i = 0; i < FiledOrder.Count; i++)
                {
                    orderByString += "," + FiledOrder[i].FiledOrder.ToString() + " " + FiledOrder[i].OrderBy.ToString();
                }
                orderByString = orderByString.Substring(1);
            }
            else
            {
                orderByString = "SortRule DESC,IssueTime DESC";
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query, orderByString, null))
            {
                ResultList = new List<EyouSoft.Model.MTravelArticle>();
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelArticle model = new EyouSoft.Model.MTravelArticle();
                    model.ArticleID = dr.GetString(dr.GetOrdinal("ArticleID"));
                    model.Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source"));
                    model.ArticleTitle = dr.IsDBNull(dr.GetOrdinal("ArticleTitle")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTitle"));
                    model.ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath"));
                    model.Description = dr.IsDBNull(dr.GetOrdinal("Description")) ? "" : dr.GetString(dr.GetOrdinal("Description"));
                    model.ArticleText = dr.IsDBNull(dr.GetOrdinal("ArticleText")) ? "" : dr.GetString(dr.GetOrdinal("ArticleText"));
                    model.ArticleTag = dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag"));
                    model.TitleColor = dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor"));
                    model.KeyWords = dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords"));
                    model.ClassId = dr.GetInt32(dr.GetOrdinal("ClassId"));
                    model.IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false;
                    model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl"));
                    model.Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click"));
                    model.SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"));

                    if (!dr.IsDBNull(dr.GetOrdinal("ClassName")))
                    {
                        this.GetClassBySqlXml(dr.GetString(dr.GetOrdinal("ClassName")), ref model);
                    }

                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序字段</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelArticle> GetTopList(int Top, EyouSoft.Model.MTravelArticleCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            IList<EyouSoft.Model.MTravelArticle> ResultList = null;
            string StrSql = string.Format("SELECT {0} ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,(select top 1 ClassName,IsSystem from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId for xml raw,root('Root')) as ClassName,IsFrontPage,IsHot,IssueTime,OperatorId,(select ContactName from tbl_User where UserID=tbl_TravelArticle.OperatorId) as OperatorName,LinkUrl,Click,SortRule FROM tbl_TravelArticle WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.Source))
                {
                    StrSql = StrSql + string.Format(" AND Source like '%{0}%'", chaXun.Source);
                }
                if (!string.IsNullOrEmpty(chaXun.ArticleTitle))
                {
                    StrSql = StrSql + string.Format(" AND ArticleTitle like '%{0}%'", chaXun.ArticleTitle);
                }
                if (!string.IsNullOrEmpty(chaXun.KeyWords))
                {
                    StrSql = StrSql + string.Format(" AND KeyWords like '%{0}%'", chaXun.KeyWords);
                }
                if (!string.IsNullOrEmpty(chaXun.ArticleTag))
                {
                    StrSql = StrSql + string.Format(" AND ArticleTag like '%{0}%'", chaXun.ArticleTag);
                }
                if (chaXun.ClassId > 0)
                {
                    StrSql = StrSql + string.Format(" AND ClassId={0}", chaXun.ClassId);
                }
                if (chaXun.IsFrontPage.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND IsFrontPage='{0}'", chaXun.IsFrontPage.Value ? 1 : 0);
                }
                if (chaXun.IsHot.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND IsHot='{0}'", chaXun.IsHot.Value ? 1 : 0);
                }
                if (chaXun.IssueTimeBegin != null)
                {
                    StrSql = StrSql + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeBegin.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeEnd != null)
                {
                    StrSql = StrSql + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeEnd.Value.ToShortDateString() + " 23:59:59");
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorId))
                {
                    StrSql = StrSql + string.Format(" AND OperatorId='{0}'", chaXun.OperatorId);
                }
                if (chaXun.IsSystem != null && chaXun.IsSystem.Length > 0)
                {
                    StrSql = StrSql + string.Format(" AND exists(select 1 from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId and IsSystem in ({0})) ", Utils.GetSqlIn(chaXun.IsSystem));
                }
            }
            string orderByString = "";
            if (FiledOrder != null && FiledOrder.Count > 0)
            {
                for (int i = 0; i < FiledOrder.Count; i++)
                {
                    orderByString += "," + FiledOrder[i].FiledOrder.ToString() + " " + FiledOrder[i].OrderBy.ToString();
                }
                orderByString = orderByString.Substring(1);
            }
            else
            {
                orderByString = "SortRule DESC,IssueTime DESC";
            }
            StrSql = StrSql + " ORDER BY " + orderByString;
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<EyouSoft.Model.MTravelArticle>();
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelArticle model = new EyouSoft.Model.MTravelArticle();

                    model.ArticleID = dr.GetString(dr.GetOrdinal("ArticleID"));
                    model.Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source"));
                    model.ArticleTitle = dr.IsDBNull(dr.GetOrdinal("ArticleTitle")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTitle"));
                    model.ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath"));
                    model.Description = dr.IsDBNull(dr.GetOrdinal("Description")) ? "" : dr.GetString(dr.GetOrdinal("Description"));
                    model.ArticleText = dr.IsDBNull(dr.GetOrdinal("ArticleText")) ? "" : dr.GetString(dr.GetOrdinal("ArticleText"));
                    model.ArticleTag = dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag"));
                    model.TitleColor = dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor"));
                    model.KeyWords = dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords"));
                    model.ClassId = dr.GetInt32(dr.GetOrdinal("ClassId"));
                    model.IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false;
                    model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl"));
                    model.Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click"));
                    model.SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"));

                    if (!dr.IsDBNull(dr.GetOrdinal("ClassName")))
                    {
                        this.GetClassBySqlXml(dr.GetString(dr.GetOrdinal("ClassName")), ref model);
                    }


                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

        /// <summary>
        /// 获取首页底部的四个帮助信息
        /// </summary>
        /// <returns></returns>
        public IList<Model.MTravelArticle> GetHeadZiXun()
        {
            IList<Model.MTravelArticle> resultList;
            var strSql = new StringBuilder();
            strSql.AppendFormat(
                " SELECT top 3 ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,(select top 1 ClassName,IsSystem from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId for xml raw,root('Root')) as ClassName,IsFrontPage,IsHot,IssueTime,OperatorId,(select ContactName from tbl_User where UserID=tbl_TravelArticle.OperatorId) as OperatorName,LinkUrl,Click,SortRule FROM tbl_TravelArticle WHERE exists(select 1 from tbl_TravelArticleClass where ClassId = tbl_TravelArticle.ClassId and IsSystem = {0}) order by SortRule DESC,IssueTime DESC ; ",
                (int)ArticleType.安全指南);
            strSql.AppendFormat(
                " SELECT top 3 ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,(select top 1 ClassName,IsSystem from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId for xml raw,root('Root')) as ClassName,IsFrontPage,IsHot,IssueTime,OperatorId,(select ContactName from tbl_User  where UserID=tbl_TravelArticle.OperatorId) as OperatorName,LinkUrl,Click,SortRule FROM tbl_TravelArticle WHERE exists(select 1 from tbl_TravelArticleClass where ClassId = tbl_TravelArticle.ClassId and IsSystem = {0} ) order by SortRule DESC,IssueTime DESC ; ",
                (int)ArticleType.订购指南);
            strSql.AppendFormat(
                " SELECT top 3 ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,(select top 1 ClassName,IsSystem from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId for xml raw,root('Root')) as ClassName,IsFrontPage,IsHot,IssueTime,OperatorId,(select ContactName from tbl_User where UserID=tbl_TravelArticle.OperatorId) as OperatorName,LinkUrl,Click,SortRule FROM tbl_TravelArticle WHERE exists(select 1 from tbl_TravelArticleClass where ClassId = tbl_TravelArticle.ClassId and IsSystem = {0} ) order by SortRule DESC,IssueTime DESC ; ",
                (int)ArticleType.沟通与订阅);
            strSql.AppendFormat(
                " SELECT top 3 ArticleID,Source,ArticleTitle,ImgPath,Description,ArticleText,ArticleTag,TitleColor,KeyWords,ClassId,(select top 1 ClassName,IsSystem from tbl_TravelArticleClass where ClassId=tbl_TravelArticle.ClassId for xml raw,root('Root')) as ClassName,IsFrontPage,IsHot,IssueTime,OperatorId,(select ContactName from tbl_User where UserID=tbl_TravelArticle.OperatorId) as OperatorName,LinkUrl,Click,SortRule FROM tbl_TravelArticle WHERE exists(select 1 from tbl_TravelArticleClass where ClassId = tbl_TravelArticle.ClassId and IsSystem = {0} ) order by SortRule DESC,IssueTime DESC ; ",
                (int)ArticleType.支付与取票);

            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                resultList = new List<Model.MTravelArticle>();
                while (dr.Read())
                {
                    var model = new Model.MTravelArticle
                        {
                            ArticleID = dr.GetString(dr.GetOrdinal("ArticleID")),
                            Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source")),
                            ArticleTitle =
                                dr.IsDBNull(dr.GetOrdinal("ArticleTitle"))
                                    ? ""
                                    : dr.GetString(dr.GetOrdinal("ArticleTitle")),
                            ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath")),
                            Description =
                                dr.IsDBNull(dr.GetOrdinal("Description"))
                                    ? ""
                                    : dr.GetString(dr.GetOrdinal("Description")),
                            ArticleText =
                                dr.IsDBNull(dr.GetOrdinal("ArticleText"))
                                    ? ""
                                    : dr.GetString(dr.GetOrdinal("ArticleText")),
                            ArticleTag =
                                dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag")),
                            TitleColor =
                                dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor")),
                            KeyWords =
                                dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords")),
                            ClassId = dr.GetInt32(dr.GetOrdinal("ClassId")),
                            IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false,
                            IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false,
                            IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId")),
                            OperatorName =
                                dr.IsDBNull(dr.GetOrdinal("OperatorName"))
                                    ? ""
                                    : dr.GetString(dr.GetOrdinal("OperatorName")),
                            LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl")),
                            Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click")),
                            SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"))
                        };

                    if (!dr.IsDBNull(dr.GetOrdinal("ClassName")))
                    {
                        this.GetClassBySqlXml(dr.GetString(dr.GetOrdinal("ClassName")), ref model);
                    }

                    resultList.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MTravelArticle
                    {
                        ArticleID = dr.GetString(dr.GetOrdinal("ArticleID")),
                        Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source")),
                        ArticleTitle =
                            dr.IsDBNull(dr.GetOrdinal("ArticleTitle"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("ArticleTitle")),
                        ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath")),
                        Description =
                            dr.IsDBNull(dr.GetOrdinal("Description"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("Description")),
                        ArticleText =
                            dr.IsDBNull(dr.GetOrdinal("ArticleText"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("ArticleText")),
                        ArticleTag =
                            dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag")),
                        TitleColor =
                            dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor")),
                        KeyWords =
                            dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords")),
                        ClassId = dr.GetInt32(dr.GetOrdinal("ClassId")),
                        IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false,
                        IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false,
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        OperatorId =
                            dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId")),
                        OperatorName =
                            dr.IsDBNull(dr.GetOrdinal("OperatorName"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("OperatorName")),
                        LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl")),
                        Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click")),
                        SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"))
                    };

                    if (!dr.IsDBNull(dr.GetOrdinal("ClassName")))
                    {
                        this.GetClassBySqlXml(dr.GetString(dr.GetOrdinal("ClassName")), ref model);
                    }

                    resultList.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MTravelArticle
                    {
                        ArticleID = dr.GetString(dr.GetOrdinal("ArticleID")),
                        Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source")),
                        ArticleTitle =
                            dr.IsDBNull(dr.GetOrdinal("ArticleTitle"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("ArticleTitle")),
                        ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath")),
                        Description =
                            dr.IsDBNull(dr.GetOrdinal("Description"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("Description")),
                        ArticleText =
                            dr.IsDBNull(dr.GetOrdinal("ArticleText"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("ArticleText")),
                        ArticleTag =
                            dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag")),
                        TitleColor =
                            dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor")),
                        KeyWords =
                            dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords")),
                        ClassId = dr.GetInt32(dr.GetOrdinal("ClassId")),
                        IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false,
                        IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false,
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        OperatorId =
                            dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId")),
                        OperatorName =
                            dr.IsDBNull(dr.GetOrdinal("OperatorName"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("OperatorName")),
                        LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl")),
                        Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click")),
                        SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"))
                    };

                    if (!dr.IsDBNull(dr.GetOrdinal("ClassName")))
                    {
                        this.GetClassBySqlXml(dr.GetString(dr.GetOrdinal("ClassName")), ref model);
                    }

                    resultList.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MTravelArticle
                    {
                        ArticleID = dr.GetString(dr.GetOrdinal("ArticleID")),
                        Source = dr.IsDBNull(dr.GetOrdinal("Source")) ? "" : dr.GetString(dr.GetOrdinal("Source")),
                        ArticleTitle =
                            dr.IsDBNull(dr.GetOrdinal("ArticleTitle"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("ArticleTitle")),
                        ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath")),
                        Description =
                            dr.IsDBNull(dr.GetOrdinal("Description"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("Description")),
                        ArticleText =
                            dr.IsDBNull(dr.GetOrdinal("ArticleText"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("ArticleText")),
                        ArticleTag =
                            dr.IsDBNull(dr.GetOrdinal("ArticleTag")) ? "" : dr.GetString(dr.GetOrdinal("ArticleTag")),
                        TitleColor =
                            dr.IsDBNull(dr.GetOrdinal("TitleColor")) ? "" : dr.GetString(dr.GetOrdinal("TitleColor")),
                        KeyWords =
                            dr.IsDBNull(dr.GetOrdinal("KeyWords")) ? "" : dr.GetString(dr.GetOrdinal("KeyWords")),
                        ClassId = dr.GetInt32(dr.GetOrdinal("ClassId")),
                        IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false,
                        IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false,
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        OperatorId =
                            dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId")),
                        OperatorName =
                            dr.IsDBNull(dr.GetOrdinal("OperatorName"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("OperatorName")),
                        LinkUrl = dr.IsDBNull(dr.GetOrdinal("LinkUrl")) ? "" : dr.GetString(dr.GetOrdinal("LinkUrl")),
                        Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click")),
                        SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"))
                    };

                    if (!dr.IsDBNull(dr.GetOrdinal("ClassName")))
                    {
                        this.GetClassBySqlXml(dr.GetString(dr.GetOrdinal("ClassName")), ref model);
                    }

                    resultList.Add(model);
                }

            }

            return resultList;
        }

        #endregion

        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="Id"></param>
        public void SetClick(string Id)
        {
            string strSql = "UPDATE tbl_TravelArticle SET Click=Click+1 Where ArticleID=@ArticleID";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "ArticleID", DbType.AnsiStringFixedLength, Id);
            DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 生成资讯类别信息实体
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private void GetClassBySqlXml(string xml, ref Model.MTravelArticle model)
        {
            if (string.IsNullOrEmpty(xml)) return;

            var xRoot = XElement.Parse(xml);
            var xRows = Utils.GetXElements(xRoot, "row");

            if (xRows == null || !xRows.Any()) return;

            if (model == null) model = new Model.MTravelArticle();

            foreach (var t in xRows)
            {
                model.ClassName = Utils.GetXAttributeValue(t, "ClassName");
                model.ArticleType = (ArticleType)Utils.GetInt(Utils.GetXAttributeValue(t, "IsSystem"));

                break;
            }
        }


        #region 旅游资讯留言
        /// <summary>
        /// 增加一条留言
        /// </summary>
        public bool AddLiuYan(EyouSoft.Model.MTravelArticleLY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_TravelArticleLY(");
            strSql.Append("[LiuYanId],[ArticleID],[MemberID],[LiuYanShiJian],[LiuYanContet]");
            strSql.Append(") values (");
            strSql.Append("@LiuYanId,@ArticleID,@MemberID,@LiuYanShiJian,@LiuYanContet");
            strSql.Append(") ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LiuYanId", DbType.AnsiStringFixedLength, model.LiuYanId);
            this._db.AddInParameter(cmd, "ArticleID", DbType.AnsiStringFixedLength, model.ArticleID);
            this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
            this._db.AddInParameter(cmd, "LiuYanShiJian", DbType.DateTime, model.LiuYanShiJian);
            this._db.AddInParameter(cmd, "LiuYanContet", DbType.String, model.LiuYanContet);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;


        }
        /// <summary>
        /// 回复留言
        /// </summary>
        public bool UpdateLiuYan(EyouSoft.Model.MTravelArticleLY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_TravelArticleLY set ");
            strSql.Append(" HuiFuContet = @HuiFuContet , ");
            strSql.Append(" IsCheck = @IsCheck , ");
            strSql.Append(" OperatorId = @OperatorId , ");
            strSql.Append(" IssueTime = @IssueTime ");
            strSql.Append(" where LiuYanId=@LiuYanId  ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LiuYanId", DbType.AnsiStringFixedLength, model.LiuYanId);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime.HasValue ? (DateTime?)model.IssueTime.Value : null);
            this._db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, model.IsCheck ? 1 : 0);
            this._db.AddInParameter(cmd, "HuiFuContet", DbType.String, model.HuiFuContet);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新留言的审核状态
        /// </summary>
        /// <param name="DianPingIds"></param>
        /// <returns></returns>
        public bool UpdateLiuYan(bool IsCheck, params string[] LiuYanIds)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (var id in LiuYanIds)
            {
                strSql.AppendFormat("update tbl_TravelArticleLY set IsCheck='{0}' where LiuYanId='{1}' ", IsCheck ? 1 : 0, id);
            }
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSqlTrans(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 删除留言数据
        /// </summary>
        public bool DeleteLiuYan(params string[] LiuYanIds)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in LiuYanIds)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    StrSql.AppendFormat(" delete from tbl_TravelArticleLY where LiuYanId='{0}' ", id);
                }
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一个留言对象实体
        /// </summary>
        public EyouSoft.Model.MTravelArticleLY GetLiuYanModel(string LiuYanId)
        {
            EyouSoft.Model.MTravelArticleLY model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select LiuYanId, ArticleID, MemberID, LiuYanShiJian, LiuYanContet, HuiFuContet,IsCheck, OperatorId, IssueTime,  ");
            strSql.Append(" (select top 1 ArticleTitle from tbl_TravelArticle where ArticleID=tbl_TravelArticleLY.ArticleID ) as ArticleTitle, ");
            strSql.Append(" (select top 1 Account from tbl_Member where MemberID=tbl_TravelArticleLY.MemberID ) as Account, ");
            strSql.Append(" (select top 1 ContactName from tbl_User where UserID=tbl_TravelArticleLY.OperatorId ) as Username ");
            strSql.Append(" from tbl_TravelArticleLY ");
            strSql.Append(" where LiuYanId=@LiuYanId ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LiuYanId", DbType.AnsiStringFixedLength, LiuYanId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MTravelArticleLY();

                    model.LiuYanId = dr.GetString(dr.GetOrdinal("LiuYanId"));
                    model.ArticleID = dr.GetString(dr.GetOrdinal("ArticleID"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.LiuYanShiJian = dr.GetDateTime(dr.GetOrdinal("LiuYanShiJian"));
                    model.LiuYanContet = dr["LiuYanContet"].ToString();
                    model.HuiFuContet = dr["HuiFuContet"].ToString();
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1";
                    model.OperatorId = dr["OperatorId"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.ArticleTitle = dr["ArticleTitle"].ToString();
                    model.Account = dr["Account"].ToString();
                    model.Username = dr["Username"].ToString();
                }
            }
            return model;

        }
        /// <summary>
        /// 获得留言数据列表
        /// </summary>
        public IList<EyouSoft.Model.MTravelArticleLY> GetLiuYanList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MTravelArticleLYCX chaxun)
        {
            IList<EyouSoft.Model.MTravelArticleLY> list = new List<EyouSoft.Model.MTravelArticleLY>();

            string tableName = "tbl_TravelArticleLY";

            StringBuilder fields = new StringBuilder();
            fields.Append("  LiuYanId, ArticleID, MemberID, LiuYanShiJian, LiuYanContet, HuiFuContet,IsCheck, OperatorId, IssueTime,  ");
            fields.Append(" (select top 1 ArticleTitle from tbl_TravelArticle where ArticleID=tbl_TravelArticleLY.ArticleID ) as ArticleTitle, ");
            fields.Append(" (select top 1 Account from tbl_Member where MemberID=tbl_TravelArticleLY.MemberID ) as Account, ");
            fields.Append(" (select top 1 ContactName from tbl_User where UserID=tbl_TravelArticleLY.OperatorId ) as Username ");

            string orderByString = "IsCheck asc,LiuYanShiJian desc,IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (chaxun != null)
            {
                if (!string.IsNullOrEmpty(chaxun.ArticleID))
                {

                    query.AppendFormat(" and ArticleID='{0}' ", chaxun.ArticleID);
                }
                if (chaxun.IsCheck.HasValue)
                {
                    query.AppendFormat(" and IsCheck='{0}' ", chaxun.IsCheck == true ? "1" : "0");
                }

                if (chaxun.Stime != null)
                {
                    query.AppendFormat(" AND LiuYanShiJian>='{0}' ", chaxun.Stime.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaxun.Etime != null)
                {
                    query.AppendFormat(" AND LiuYanShiJian<='{0}' ", chaxun.Etime.Value.ToShortDateString() + " 23:59:59");
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelArticleLY model = new EyouSoft.Model.MTravelArticleLY();
                    model.LiuYanId = dr.GetString(dr.GetOrdinal("LiuYanId"));
                    model.ArticleID = dr.GetString(dr.GetOrdinal("ArticleID"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.LiuYanShiJian = dr.GetDateTime(dr.GetOrdinal("LiuYanShiJian"));
                    model.LiuYanContet = dr["LiuYanContet"].ToString();
                    model.HuiFuContet = dr["HuiFuContet"].ToString();
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1";
                    model.OperatorId = dr["OperatorId"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.ArticleTitle = dr["ArticleTitle"].ToString();
                    model.Account = dr["Account"].ToString();
                    model.Username = dr["Username"].ToString();
                    list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        /// 获得留言前几行数据
        /// </summary>
        public IList<EyouSoft.Model.MTravelArticleLY> GetLiuYanList(int Top, EyouSoft.Model.MTravelArticleLYCX chaxun)
        {
            IList<EyouSoft.Model.MTravelArticleLY> list = new List<EyouSoft.Model.MTravelArticleLY>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }

            strSql.Append("  LiuYanId, ArticleID, MemberID, LiuYanShiJian, LiuYanContet, HuiFuContet,IsCheck, OperatorId, IssueTime,  ");
            strSql.Append(" (select top 1 ArticleTitle from tbl_TravelArticle where ArticleID=tbl_TravelArticleLY.ArticleID ) as ArticleTitle, ");
            strSql.Append(" (select top 1 Account from tbl_Member where MemberID=tbl_TravelArticleLY.MemberID ) as Account, ");
            strSql.Append(" (select top 1 ContactName from tbl_User where UserID=tbl_TravelArticleLY.OperatorId ) as Username ");

            strSql.Append("  from tbl_TravelArticleLY ");
            strSql.Append(" Where 1=1 ");

            if (chaxun != null)
            {
                if (!string.IsNullOrEmpty(chaxun.ArticleID))
                {

                    strSql.AppendFormat(" and ArticleID='{0}' ", chaxun.ArticleID);
                }
                if (chaxun.IsCheck.HasValue)
                {
                    strSql.AppendFormat(" and IsCheck='{0}' ", chaxun.IsCheck == true ? "1" : "0");
                }

                if (chaxun.Stime != null)
                {
                    strSql.AppendFormat(" AND LiuYanShiJian>='{0}' ", chaxun.Stime.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaxun.Etime != null)
                {
                    strSql.AppendFormat(" AND LiuYanShiJian<='{0}' ", chaxun.Etime.Value.ToShortDateString() + " 23:59:59");
                }
            }


            strSql.Append(" Order by IsCheck asc,LiuYanShiJian desc,IssueTime desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelArticleLY model = new EyouSoft.Model.MTravelArticleLY();
                    model.LiuYanId = dr.GetString(dr.GetOrdinal("LiuYanId"));
                    model.ArticleID = dr.GetString(dr.GetOrdinal("ArticleID"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.LiuYanShiJian = dr.GetDateTime(dr.GetOrdinal("LiuYanShiJian"));
                    model.LiuYanContet = dr["LiuYanContet"].ToString();
                    model.HuiFuContet = dr["HuiFuContet"].ToString();
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1";
                    model.OperatorId = dr["OperatorId"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.ArticleTitle = dr["ArticleTitle"].ToString();
                    model.Account = dr["Account"].ToString();
                    model.Username = dr["Username"].ToString();
                    list.Add(model);
                }
            }

            return list;
        }
        #endregion

        #endregion
    }
}
