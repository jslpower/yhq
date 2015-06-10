using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml.Linq;
using Eyousoft_yhq.Model;
using System.Data.Common;
using System.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DChongZhi : DALBase
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DChongZhi()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MChongZhi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tmp_tbl_ChongZhi(OrderID, OperatorID, OptMoney,OrderCode,PayState) VALUES (@OrderID, @OperatorID, @OptMoney,@OrderCode,@PayState)");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "OperatorID", DbType.AnsiStringFixedLength, model.OperatorID);
            this._db.AddInParameter(cmd, "OptMoney", DbType.String, model.OptMoney);
            this._db.AddInParameter(cmd, "OrderCode", DbType.AnsiStringFixedLength, model.OrderCode);
            this._db.AddInParameter(cmd, "PayState", DbType.Byte, model.PayState);
            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int SheZhiZhiFus(string DingDanId, PaymentState state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tmp_tbl_ChongZhi   SET  PayState = @PayState WHERE orderid=@orderid ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "orderid", DbType.AnsiStringFixedLength, DingDanId);
            this._db.AddInParameter(cmd, "PayState", DbType.Byte, state);
            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int SheZhiZhiFuByOrderCode(string OrderCode, PaymentState state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tmp_tbl_ChongZhi   SET  PayState = @PayState WHERE OrderCode=@OrderCode");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderCode", DbType.AnsiStringFixedLength, OrderCode);
            this._db.AddInParameter(cmd, "PayState", DbType.Byte, state);
            return DbHelper.ExecuteSql(cmd, this._db);

        }   /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MChongZhi GetModel(string ID)
        {
            MChongZhi model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT   [OrderCode]      ,[OperatorID]      ,[OptMoney]      ,[Issuetime]      ,[PayState] ,[TradeNo]  FROM tmp_tbl_ChongZhi WHERE orderid=@orderid and PayState=1");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "orderid", DbType.AnsiStringFixedLength, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    model = new MChongZhi();
                    model.OrderID = ID;
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OptMoney = dr.GetDecimal(dr.GetOrdinal("OptMoney"));
                    model.Issuetime = dr.GetDateTime(dr.GetOrdinal("Issuetime"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.PayState = (PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.TradeNo = dr.IsDBNull(dr.GetOrdinal("TradeNo")) ? "" : dr.GetString(dr.GetOrdinal("TradeNo"));
                }
            }

            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MChongZhi GetModelByOrderCode(string TradeNO)
        {
            MChongZhi model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  [OrderID], [OrderCode]      ,[OperatorID]      ,[OptMoney]      ,[Issuetime]      ,[PayState] ,[TradeNO]  FROM tmp_tbl_ChongZhi WHERE OrderCode=@OrderCode ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderCode", DbType.AnsiStringFixedLength, TradeNO);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    model = new MChongZhi();
                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OptMoney = dr.GetDecimal(dr.GetOrdinal("OptMoney"));
                    model.Issuetime = dr.GetDateTime(dr.GetOrdinal("Issuetime"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.PayState = (PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.TradeNo = dr.IsDBNull(dr.GetOrdinal("TradeNo")) ? "" : dr.GetString(dr.GetOrdinal("TradeNo"));
                }
            }
            Eyousoft_yhq.SQLServerDAL.Utils.WLog("1", "/log_2.txt");

            return model;
        }     /// <summary>
        /// 更新交易号
        /// </summary>
        /// <param name="dingdanid"></param>
        /// <param name="TradeNO"></param>
        /// <returns></returns>
        public bool UpdateTradeNO(string OrderCode, string TradeNO)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE  tmp_tbl_ChongZhi SET  TradeNO = @TradeNO WHERE OrderCode=@OrderCode");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TradeNO", System.Data.DbType.String, TradeNO);
            this._db.AddInParameter(cmd, "OrderCode", System.Data.DbType.String, OrderCode);


            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<MChongZhi> GetList(int PageSize, int PageIndex, ref int RecordCount, MChongZhiSer serModel)
        {
            IList<MChongZhi> list = new List<MChongZhi>();


            string tableName = "view_ChongZhi";
            string fileds = "* ";
            string orderByString = "ISSUETIME DESC ";

            StringBuilder query = new StringBuilder();
            query.AppendFormat("  PayState=2   ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.OrderCode))
                {
                    query.AppendFormat(" and OrderCode  like '%{0}%' ", serModel.OrderCode);
                }
                if (!string.IsNullOrEmpty(serModel.TradeNo))
                {
                    query.AppendFormat(" and TradeNo like '%{0}%' ", serModel.TradeNo);
                }
                if (!string.IsNullOrEmpty(serModel.Account))
                {
                    query.AppendFormat(" and UserName like '%{0}%'  ", serModel.Account);
                }
                if (!string.IsNullOrEmpty(serModel.OperatorID))
                {
                    query.AppendFormat(" and OperatorID = '{0}' ", serModel.OperatorID);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MChongZhi model = new MChongZhi();
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));


                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OptMoney = dr.GetDecimal(dr.GetOrdinal("OptMoney"));
                    model.Issuetime = dr.GetDateTime(dr.GetOrdinal("Issuetime"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.PayState = (PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.TradeNo = dr.IsDBNull(dr.GetOrdinal("TradeNo")) ? "" : dr.GetString(dr.GetOrdinal("TradeNo"));

                    list.Add(model);
                }
            }
            return list;
        }
    }
}
