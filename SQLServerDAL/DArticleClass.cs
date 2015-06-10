using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
 using System.Data.Common;
using Eyousoft_yhq.SQLServerDAL;
using Eyousoft_yhq.Model;

namespace EyouSoft.DAL
{
    public class DArticleClass :  DALBase 
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DArticleClass()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region IArticleClass 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EyouSoft.Model.MArticleClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_TravelArticleClass(");
            strSql.Append("ClassName,IsSystem,SortRule");
            strSql.Append(") values (");
            strSql.Append("@ClassName,@IsSystem,@SortRule");
            strSql.Append(") ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ClassName", System.Data.DbType.String, model.ClassName);
            this._db.AddInParameter(cmd, "IsSystem", DbType.Int32, model.IsSystem);
            this._db.AddInParameter(cmd, "SortRule", System.Data.DbType.Int32, model.SortRule);
            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(EyouSoft.Model.MArticleClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_TravelArticleClass set ");
            strSql.Append(" ClassName = @ClassName,IsSystem=@IsSystem,SortRule=@SortRule ");
            strSql.Append(" where ClassId=@ClassId  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ClassId", System.Data.DbType.Int32, model.ClassId);
            this._db.AddInParameter(cmd, "ClassName", System.Data.DbType.String, model.ClassName);
            this._db.AddInParameter(cmd, "IsSystem", DbType.Int32, model.IsSystem);
            this._db.AddInParameter(cmd, "SortRule", System.Data.DbType.Int32, model.SortRule);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(string ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_TravelArticleClass where ");
            string[] str = ClassId.Split(',');
            string c = "";
            if (str.Length > 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    c += ",'" + str[i].Trim() + "'";
                }
                strSql.AppendFormat(" ClassId in ({0}) ", c.Substring(1));
            }
            else
            {
                strSql.AppendFormat(" ClassId = '{0}' ", ClassId.Trim());
            }
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MArticleClass GetModel(int ClassId)
        {
            EyouSoft.Model.MArticleClass model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClassId, ClassName,IsSystem,SortRule  ");
            strSql.Append("  from tbl_TravelArticleClass ");
            strSql.Append(" where ClassId=@ClassId ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ClassId", System.Data.DbType.Int32, ClassId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MArticleClass();
                    model.ClassId = dr.GetInt32(dr.GetOrdinal("ClassId"));
                    model.ClassName = !dr.IsDBNull(dr.GetOrdinal("ClassName")) ? dr.GetString(dr.GetOrdinal("ClassName")) : "";
                    model.IsSystem = !dr.IsDBNull(dr.GetOrdinal("IsSystem")) ? (ArticleType)dr.GetInt32(dr.GetOrdinal("IsSystem")) : (ArticleType)0;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                }
            }

            return model;
        }
        
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MArticleClass> GetList(int top, EyouSoft.Model.MArticleClass Search)
        {
            IList<EyouSoft.Model.MArticleClass> list = new List<EyouSoft.Model.MArticleClass>();

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select {0} ", top > 0 ? string.Format(" top {0} ", top) : string.Empty);
            strSql.Append(" ClassId, ClassName,IsSystem,SortRule ");
            strSql.Append("  from tbl_TravelArticleClass where 1=1");
            if (Search != null)
            {
                if ((int)Search.IsSystem >= 0)
                {
                    strSql.AppendFormat(" AND IsSystem={0}", (int)Search.IsSystem);
                }
                if (!string.IsNullOrEmpty(Search.ClassName))
                {
                    strSql.AppendFormat(" and ClassName like '%{0}%' ", Search.ClassName);
                }
            }
            strSql.Append("   order by IsSystem desc, SortRule desc,ClassId desc ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MArticleClass model = new EyouSoft.Model.MArticleClass();
                    model.ClassId = dr.GetInt32(dr.GetOrdinal("ClassId"));
                    model.ClassName = !dr.IsDBNull(dr.GetOrdinal("ClassName")) ? dr.GetString(dr.GetOrdinal("ClassName")) : "";
                    model.IsSystem = !dr.IsDBNull(dr.GetOrdinal("IsSystem")) ? ( ArticleType)dr.GetInt32(dr.GetOrdinal("IsSystem")) : ( ArticleType)0;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MArticleClass> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MArticleClass Search)
        {
            IList<EyouSoft.Model.MArticleClass> list = new List<EyouSoft.Model.MArticleClass>();

            string tableName = "tbl_TravelArticleClass";
            string fileds = "ClassId, ClassName,IsSystem,SortRule";
            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (Search != null)
            {
                if ((int)Search.IsSystem >= 0)
                {
                    query.AppendFormat(" AND IsSystem={0}", (int)Search.IsSystem);
                }
                if (!string.IsNullOrEmpty(Search.ClassName))
                {
                    query.AppendFormat(" AND ClassName like '%{0}%' ", Search.ClassName);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), "IsSystem desc,SortRule desc,ClassId desc ", null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MArticleClass model = new EyouSoft.Model.MArticleClass();
                    model.ClassId = dr.GetInt32(dr.GetOrdinal("ClassId"));
                    model.ClassName = !dr.IsDBNull(dr.GetOrdinal("ClassName")) ? dr.GetString(dr.GetOrdinal("ClassName")) : "";
                    model.IsSystem = !dr.IsDBNull(dr.GetOrdinal("IsSystem")) ? (ArticleType)dr.GetInt32(dr.GetOrdinal("IsSystem")) : (ArticleType)0;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion
    }
}
