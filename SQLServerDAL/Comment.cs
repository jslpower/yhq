using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Comment
    /// </summary>
    public partial class Comment : DALBase
    {
        private Database _db = null;
        public Comment()
        {
            _db = base.SystemStore;
        }


        #region IComment 成员
        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("INSERT INTO  tbl_Comment ( ProductID , CommentID , PeopleID , CommentText, CheckState , IssueTime )	VALUES ( @ProductID , @CommentID , @PeopleID , @CommentText, 0 , @IssueTime )");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.AnsiStringFixedLength, model.ProductID);
            this._db.AddInParameter(cmd, "CommentID", System.Data.DbType.String, model.CommentID);
            this._db.AddInParameter(cmd, "PeopleID", System.Data.DbType.String, model.PeopleID);
            this._db.AddInParameter(cmd, "CommentText", System.Data.DbType.String, model.CommentText);
            //this._db.AddInParameter(cmd, "CheckState", System.Data.DbType.String, model.ContactSex);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.String, model.IssueTime);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 审核留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(string[] strIDs)
        {



            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE  tbl_Comment    SET  CheckState  =  1 WHERE CommentID in ({0}) ", Utils.GetSqlInExpression(strIDs));

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            //this._db.AddInParameter(cmd, "CommentID", System.Data.DbType.String, model.CommentID);
            //this._db.AddInParameter(cmd, "CheckState", System.Data.DbType.String, model.CheckState);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <returns></returns>
        public bool Delete(string[] strIDs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  DELETE FROM  tbl_Comment   WHERE  CommentID in ({0})  ", Utils.GetSqlInExpression(strIDs));

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 获取留言实体
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.Comment GetModel(string strID)
        {
            Eyousoft_yhq.Model.Comment model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT ProductID,CommentID,PeopleID,CommentText,(SELECT UserName FROM tbl_member  WHERE UserID='{0}' )  as PeopleName", strID);
            strSql.Append("  FROM tbl_Comment   ");
            strSql.Append(" where CommentID=@CommentID  and  CheckState=1");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "CommentID", System.Data.DbType.AnsiStringFixedLength, strID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.Comment();
                    model.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    model.CommentID = dr.GetString(dr.GetOrdinal("CommentID"));
                    model.PeopleID = dr.GetString(dr.GetOrdinal("PeopleID"));
                    model.CommentText = dr.GetString(dr.GetOrdinal("CommentText"));


                }
            }

            return model;
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Comment> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serComment serModel)
        {
            IList<Eyousoft_yhq.Model.Comment> list = new List<Eyousoft_yhq.Model.Comment>();


            string tableName = "tbl_Comment";
            string fileds = "  ProductID,CommentID,PeopleID,CommentText,IssueTime,(select ContactName from tbl_member   where userid=PeopleID) as PeopleName ";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {
                if (serModel.sTime.HasValue) query.AppendFormat(" AND datediff(day,'{0}',IssueTime)>=0 ", serModel.sTime.Value);
                if (serModel.eTime.HasValue) query.AppendFormat(" AND datediff(day,'{0}',IssueTime)<=0 ", serModel.eTime.Value);
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.Comment model = new Eyousoft_yhq.Model.Comment();
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID")); ;
                    model.CommentID = dr.IsDBNull(dr.GetOrdinal("CommentID")) ? "" : dr.GetString(dr.GetOrdinal("CommentID"));
                    model.PeopleID = dr.IsDBNull(dr.GetOrdinal("PeopleID")) ? "" : dr.GetString(dr.GetOrdinal("PeopleID"));
                    model.CommentText = dr.IsDBNull(dr.GetOrdinal("CommentText")) ? "" : dr.GetString(dr.GetOrdinal("CommentText"));
                    model.IssueTime =  dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.PeopleName = dr.IsDBNull(dr.GetOrdinal("PeopleName")) ? "" : dr.GetString(dr.GetOrdinal("PeopleName"));
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.Comment> GetList(Eyousoft_yhq.Model.serComment serModel)
        {

            IList<Eyousoft_yhq.Model.Comment> list = new List<Eyousoft_yhq.Model.Comment>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ProductID,CommentID,PeopleID,CommentText,IssueTime,(select ContactName from tbl_member   where userid=PeopleID) as PeopleName   ");
            strSql.Append("  from tbl_Comment where  1=1  ");
            if (serModel != null)
            {
                if (serModel.sTime.HasValue) strSql.AppendFormat(" AND datediff(day,'{0}',IssueTime)>=0 ", serModel.sTime.Value);
                if (serModel.eTime.HasValue) strSql.AppendFormat(" AND datediff(day,'{0}',IssueTime)<=0 ", serModel.eTime.Value);
            }
            strSql.Append("  order by IssueTime  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.Comment model = new Eyousoft_yhq.Model.Comment();
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID")); ;
                    model.CommentID = dr.IsDBNull(dr.GetOrdinal("CommentID")) ? "" : dr.GetString(dr.GetOrdinal("CommentID"));
                    model.PeopleID = dr.IsDBNull(dr.GetOrdinal("PeopleID")) ? "" : dr.GetString(dr.GetOrdinal("PeopleID"));
                    model.CommentText = dr.IsDBNull(dr.GetOrdinal("CommentText")) ? "" : dr.GetString(dr.GetOrdinal("CommentText"));
                    model.IssueTime =  dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.PeopleName = dr.IsDBNull(dr.GetOrdinal("PeopleName")) ? "" : dr.GetString(dr.GetOrdinal("PeopleName"));
                    list.Add(model);
                }
            }
            return list;


        }
        /// <summary>
        /// 获取产品的留言数量
        /// </summary>
        /// <param name="productID">产品编号</param>
        /// <returns></returns>
        public int GetCountNum(string productID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_Comment");
            strSql.Append(" where ProductID=@ProductID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.String, productID);

            return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db));
        }
        #endregion
    }
}

