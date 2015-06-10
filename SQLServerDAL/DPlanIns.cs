using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Eyousoft_yhq.Model;
using System.Data.Common;
using System.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DPlanIns : DALBase
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DPlanIns()
        {
            _db = base.SystemStore;
        }
        #endregion
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">保险</param>
        /// <returns></returns>
        public int Insert(MPlanIns model)
        {
            string strSql = "INSERT INTO tbl_PlantIns(OrderID ,InsNO ,InsName ,OperatorID ,OperatorName ,IssueTime ,PlantID ,InsMoney ,OrderCode ,PolicTor ,LinkTel ,LinkMail ,LinkAddress) VALUES (@OrderID ,@InsNO ,@InsName ,@OperatorID ,@OperatorName ,@IssueTime ,@PlantID ,@InsMoney ,@OrderCode ,@PolicTor ,@LinkTel ,@LinkMail ,@LinkAddress)";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "OrderID", DbType.String, model.OrderID);
            this._db.AddInParameter(cmd, "InsNO", DbType.String, model.InsNO);
            this._db.AddInParameter(cmd, "InsName", DbType.String, model.InsName);
            this._db.AddInParameter(cmd, "OperatorID", DbType.String, model.OperatorID);
            this._db.AddInParameter(cmd, "OperatorName", DbType.String, model.OperatorName);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "PlantID", DbType.String, model.PlantID);
            this._db.AddInParameter(cmd, "InsMoney", DbType.Decimal, model.InsMoney);
            this._db.AddInParameter(cmd, "PolicTor", DbType.String, model.PolicTor);
            this._db.AddInParameter(cmd, "LinkTel", DbType.String, model.LinkTel);
            this._db.AddInParameter(cmd, "LinkMail", DbType.String, model.LinkMail);
            this._db.AddInParameter(cmd, "LinkAddress", DbType.String, model.LinkAddress);


            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取保险编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MPlanIns GetModel(int id)
        {
            Eyousoft_yhq.Model.MPlanIns model = null;

            string StrSql = "select  *  from tbl_PlantIns where id=@id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "id", DbType.Int32, id);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MPlanIns();

                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.InsMoney = dr.GetDecimal(dr.GetOrdinal("InsMoney"));
                    model.InsName = dr.GetString(dr.GetOrdinal("InsName"));
                    model.InsNO = dr.GetString(dr.GetOrdinal("InsNO"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LinkAddress = dr.GetString(dr.GetOrdinal("LinkAddress"));
                    model.LinkMail = dr.GetString(dr.GetOrdinal("LinkMail"));
                    model.LinkTel = dr.GetString(dr.GetOrdinal("LinkTel"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.PlantID = dr.GetString(dr.GetOrdinal("PlantID"));
                    model.PolicTor = dr.GetString(dr.GetOrdinal("PolicTor"));
                    model.State = (InsState)dr.GetByte(dr.GetOrdinal("State"));

                }
            }
            return model;
        }
        /// <summary>
        /// 获取保险编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<MPlanIns> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MPlanInsSer serModel)
        {
            IList<Eyousoft_yhq.Model.MPlanIns> list = new List<Eyousoft_yhq.Model.MPlanIns>();

            string tableName = "tbl_PlantIns";

            string fileds = " * ";

            string orderByString = " IssueTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" 1=1");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.OperatorID))
                {
                    query.AppendFormat(" and  OperatorID='{0}'  ", serModel.OperatorID);
                }

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MPlanIns model = new Eyousoft_yhq.Model.MPlanIns();

                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.InsMoney = dr.GetDecimal(dr.GetOrdinal("InsMoney"));
                    model.InsName = dr.GetString(dr.GetOrdinal("InsName"));
                    model.InsNO = dr.GetString(dr.GetOrdinal("InsNO"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LinkAddress = dr.GetString(dr.GetOrdinal("LinkAddress"));
                    model.LinkMail = dr.GetString(dr.GetOrdinal("LinkMail"));
                    model.LinkTel = dr.GetString(dr.GetOrdinal("LinkTel"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.PlantID = dr.GetString(dr.GetOrdinal("PlantID"));
                    model.PolicTor = dr.GetString(dr.GetOrdinal("PolicTor"));
                    model.State = (InsState)dr.GetByte(dr.GetOrdinal("State"));

                    list.Add(model);
                }
            }
            return list;
        }
    }
}
