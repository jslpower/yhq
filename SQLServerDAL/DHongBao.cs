using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Eyousoft_yhq.Model;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DHongBao : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public DHongBao()
        {
            _db = base.SystemStore;
        }
        #endregion



        /// <summary>
        /// 判断当前用户是否有红包
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool Exists(string userid)
        {
            StringBuilder ExistStr = new StringBuilder();
            ExistStr.Append("select count(1) from tbl_HongBao  where userid=@userid ");

            DbCommand ExistsCmd = this._db.GetSqlStringCommand(ExistStr.ToString());
            this._db.AddInParameter(ExistsCmd, "userid", System.Data.DbType.String, userid);

            return DbHelper.Exists(ExistsCmd, this._db);


        }



        /// <summary>
        /// 添加一个红包
        /// </summary>
        /// <param name="info">红包</param>
        /// <returns></returns>
        public int Insert(HongBao info)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO tbl_HongBao (ID ,UserID ,IssueTime ,HongBaoJinE) VALUES (@ID ,@UserID ,@IssueTime ,@HongBaoJinE) ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, info.ID);
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, info.UserID);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, info.IssueTime);
            this._db.AddInParameter(cmd, "HongBaoJinE", System.Data.DbType.Decimal, info.HongBaoJinE);

            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 修改红包金额
        /// </summary>
        /// <param name="model">红包</param>
        /// <returns></returns>
        public int Update(HongBao info)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_HongBao   SET       HongBaoJinE = @HongBaoJinE WHERE ID=@ID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, info.ID);
            this._db.AddInParameter(cmd, "HongBaoJinE", System.Data.DbType.Decimal, info.HongBaoJinE);

            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 获取红包实体
        /// </summary>
        /// <param name="ID">红包编号</param>
        /// <returns></returns>
        public HongBao GetInfo(string Id)
        {
            HongBao model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ID , UserID , IssueTime , HongBaoJinE ,UserName,ContactName  FROM   view_hongbao WHERE   ID =@ID   ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, Id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new HongBao();
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.HongBaoJinE = dr.GetDecimal(dr.GetOrdinal("HongBaoJinE"));
                    model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));

                }
            }

            return model;
        }

        /// <summary>
        /// 获取红包实体
        /// </summary>
        /// <param name="ID">会员编号</param>
        /// <returns></returns>
        public HongBao GetInfoByUserID(string UserID)
        {
            HongBao model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ID , UserID , IssueTime , HongBaoJinE ,UserName,ContactName  FROM   view_hongbao WHERE   UserID =@UserID   ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, UserID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new HongBao();
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.HongBaoJinE = dr.GetDecimal(dr.GetOrdinal("HongBaoJinE"));
                    model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));

                }
            }

            return model;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<HongBao> GetList(int PageSize, int PageIndex, ref int RecordCount, HongBaoSer serModel)
        {
            IList<HongBao> list = new List<HongBao>();


            string tableName = "view_hongbao";
            string fileds = "  ID , UserID , IssueTime , HongBaoJinE,UserName,ContactName    ";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.UserID))
                {
                    query.AppendFormat(" and  userid  = '{0}' ", serModel.UserID);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    HongBao model = new HongBao();
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.HongBaoJinE = dr.GetDecimal(dr.GetOrdinal("HongBaoJinE"));
                    model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    list.Add(model);
                }
            }
            return list;
        }

    }
}
