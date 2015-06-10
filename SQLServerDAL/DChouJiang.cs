using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eyousoft_yhq.Model;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DChouJiang : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public DChouJiang()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 判断当日用户是否抽奖
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool Exists(ChouJiang info)
        {
            StringBuilder ExistStr = new StringBuilder();
            ExistStr.Append("select count(1) from tbl_ChouJiang  where  CONVERT(varchar(20), ChouJiangShiJian, 23)  =@ChouJiangShiJian  AND  CaoZuoRenID=@CaoZuoRenID   and  FangShi=@FangShi ");

            DbCommand ExistsCmd = this._db.GetSqlStringCommand(ExistStr.ToString());
            this._db.AddInParameter(ExistsCmd, "ChouJiangShiJian", System.Data.DbType.String, info.ChouJiangShiJian.ToString("yyyy-MM-dd"));
            this._db.AddInParameter(ExistsCmd, "CaoZuoRenID", System.Data.DbType.String, info.CaoZuoRenID);
            this._db.AddInParameter(ExistsCmd, "FangShi", System.Data.DbType.Byte, info.FangShi);

            return DbHelper.Exists(ExistsCmd, this._db);


        }

        /// <summary>
        /// 添加一条抽奖记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(ChouJiang info)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO tbl_ChouJiang (ChouJiangID ,LiuShuiHao ,ID ,CaoZuoRenID ,ChouJiangShiJian ,JieGuo ,DianShu,FangShi) VALUES ( @ChouJiangID , @LiuShuiHao , @ID , @CaoZuoRenID , @ChouJiangShiJian , @JieGuo , @DianShu ,@FangShi) ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ChouJiangID", System.Data.DbType.AnsiStringFixedLength, info.ChouJiangID);
            this._db.AddInParameter(cmd, "LiuShuiHao", System.Data.DbType.String, info.LiuShuiHao);
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, info.ID);
            this._db.AddInParameter(cmd, "CaoZuoRenID", System.Data.DbType.AnsiStringFixedLength, info.CaoZuoRenID);
            this._db.AddInParameter(cmd, "ChouJiangShiJian", System.Data.DbType.DateTime, info.ChouJiangShiJian);
            this._db.AddInParameter(cmd, "JieGuo", System.Data.DbType.Byte, info.JieGuo);
            this._db.AddInParameter(cmd, "DianShu", System.Data.DbType.Decimal, info.DianShu);
            this._db.AddInParameter(cmd, "FangShi", System.Data.DbType.Byte, info.FangShi);



            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<ChouJiang> GetList(int PageSize, int PageIndex, ref int RecordCount, ChouJiangSer serModel)
        {
            IList<ChouJiang> list = new List<ChouJiang>();


            string tableName = "view_ChouJiang";
            string fileds = "  *    ";
            string orderByString = "ChouJiangShiJian desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.CaoZuoRenID))
                {
                    query.AppendFormat(" and  CaoZuoRenID  = '{0}' ", serModel.CaoZuoRenID);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    ChouJiang model = new ChouJiang();
                    model.CaoZuoRenID = dr.GetString(dr.GetOrdinal("CaoZuoRenID"));
                    model.ChouJiangID = dr.GetString(dr.GetOrdinal("ChouJiangID"));
                    model.ChouJiangShiJian = dr.GetDateTime(dr.GetOrdinal("ChouJiangShiJian"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    model.DianShu = dr.GetDecimal(dr.GetOrdinal("DianShu"));
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.JieGuo = (ChouJiangJieGuo)dr.GetByte(dr.GetOrdinal("JieGuo"));
                    model.LiuShuiHao = dr.GetString(dr.GetOrdinal("LiuShuiHao"));
                    model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    model.FangShi = (JiangLiFangShi)dr.GetByte(dr.GetOrdinal("FangShi"));

                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<ChouJiang> GetList(ChouJiangSer serModel)
        {
            IList<ChouJiang> list = new List<ChouJiang>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  *  FROM   view_ChouJiang WHERE  1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.CaoZuoRenID))
                {
                    strSql.AppendFormat(" and  CaoZuoRenID  = '{0}' ", serModel.CaoZuoRenID);
                }
                if (!string.IsNullOrEmpty(serModel.ID))
                {
                    strSql.AppendFormat(" and  ID  = '{0}' ", serModel.ID);
                }
            }
            strSql.Append("  order by  ChouJiangShiJian  desc ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    ChouJiang model = new ChouJiang();
                    model.CaoZuoRenID = dr.GetString(dr.GetOrdinal("CaoZuoRenID"));
                    model.ChouJiangID = dr.GetString(dr.GetOrdinal("ChouJiangID"));
                    model.ChouJiangShiJian = dr.GetDateTime(dr.GetOrdinal("ChouJiangShiJian"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    model.DianShu = dr.GetDecimal(dr.GetOrdinal("DianShu"));
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.JieGuo = (ChouJiangJieGuo)dr.GetByte(dr.GetOrdinal("JieGuo"));
                    model.LiuShuiHao = dr.GetString(dr.GetOrdinal("LiuShuiHao"));
                    model.UserName = dr.GetString(dr.GetOrdinal("UserName"));

                    list.Add(model);

                }
            }

            return list;
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public decimal getSumMoney(ChouJiangSer serModel)
        {
            IList<ChouJiang> list = new List<ChouJiang>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  sum(DianShu)  FROM   view_ChouJiang WHERE  1=1 ");

            if (serModel == null)
            {
                if (!string.IsNullOrEmpty(serModel.CaoZuoRenID))
                {
                    strSql.AppendFormat(" and  CaoZuoRenID  = '{0}' ", serModel.CaoZuoRenID);
                }
            }
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());


            decimal sum = Convert.ToDecimal(DbHelper.GetSingle(cmd, this._db));

            return sum;
        }
    }
}
