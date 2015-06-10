using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DYuYue : DALBase
    {
        private Database _db = null;
        public DYuYue()
        {
            _db = base.SystemStore;
        }

        #region  成员



        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.MYuYue model)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_YuYue (YYRoute ,YYName ,YYMobile ,YYInfo ) VALUES (@YYRoute ,@YYName ,@YYMobile ,@YYInfo )");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YYRoute", System.Data.DbType.String, model.YYRoute);
            this._db.AddInParameter(cmd, "YYName", System.Data.DbType.String, model.YYRoute);
            this._db.AddInParameter(cmd, "YYMobile", System.Data.DbType.String, model.YYMobile);
            this._db.AddInParameter(cmd, "YYInfo", System.Data.DbType.String, model.YYInfo);


            return DbHelper.ExecuteSql(cmd, this._db);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MYuYue GetModel(string id)
        {
            Eyousoft_yhq.Model.MYuYue model = null;

            string StrSql = "select  *  from tbl_YuYue where YYID=@YYID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "YYID", DbType.AnsiStringFixedLength, id);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MYuYue();

                    model.YYID = dr.GetInt32(dr.GetOrdinal("YYID"));

                    model.YYRoute = dr.IsDBNull(dr.GetOrdinal("YYRoute")) ? "" : dr.GetString(dr.GetOrdinal("YYRoute"));
                    model.YYName = dr.IsDBNull(dr.GetOrdinal("YYName")) ? "" : dr.GetString(dr.GetOrdinal("YYName"));
                    model.YYMobile = dr.IsDBNull(dr.GetOrdinal("YYMobile")) ? "" : dr.GetString(dr.GetOrdinal("YYMobile"));
                    model.YYInfo = dr.IsDBNull(dr.GetOrdinal("YYInfo")) ? "" : dr.GetString(dr.GetOrdinal("YYInfo"));

                    model.YYTime = dr.GetDateTime(dr.GetOrdinal("YYTime"));



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
        public IList<Eyousoft_yhq.Model.MYuYue> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MYuYueSer serModel)
        {
            IList<Eyousoft_yhq.Model.MYuYue> list = new List<Eyousoft_yhq.Model.MYuYue>();

            string tableName = "tbl_YuYue";

            string fileds = " * ";

            string orderByString = " YYTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {

            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MYuYue model = new Eyousoft_yhq.Model.MYuYue();

                    model.YYID = dr.GetInt32(dr.GetOrdinal("YYID"));

                    model.YYRoute = dr.IsDBNull(dr.GetOrdinal("YYRoute")) ? "" : dr.GetString(dr.GetOrdinal("YYRoute"));
                    model.YYName = dr.IsDBNull(dr.GetOrdinal("YYName")) ? "" : dr.GetString(dr.GetOrdinal("YYName"));
                    model.YYMobile = dr.IsDBNull(dr.GetOrdinal("YYMobile")) ? "" : dr.GetString(dr.GetOrdinal("YYMobile"));
                    model.YYInfo = dr.IsDBNull(dr.GetOrdinal("YYInfo")) ? "" : dr.GetString(dr.GetOrdinal("YYInfo"));

                    model.YYTime = dr.GetDateTime(dr.GetOrdinal("YYTime"));
                    list.Add(model);
                }
            };
            return list;
        }

        #endregion
    }
}
