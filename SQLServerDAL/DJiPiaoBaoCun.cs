using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml.Linq;
using Eyousoft_yhq.Model;
using System.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DJiPiaoBaoCun : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public DJiPiaoBaoCun()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 添加发送信息
        /// </summary>
        /// <param name="model">发送信息实体</param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.MJiPiaoBaoCun model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_PlanTicket (OrderID ,OrderCode ,OpeatorID ,OpeatorName ,IssueTime,ModifyTag,JpAdress,OrderPrice,InsPrice,WeiDianId) VALUES (@OrderID ,@OrderCode ,@OpeatorID ,@OpeatorName ,@IssueTime,@ModifyTag,@JpAdress,@OrderPrice,@InsPrice,@WeiDianId)");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderID", System.Data.DbType.String, model.OrderID);
            this._db.AddInParameter(cmd, "OrderCode", System.Data.DbType.String, model.OrderCode);
            this._db.AddInParameter(cmd, "OpeatorID", System.Data.DbType.String, model.OpeatorID);
            this._db.AddInParameter(cmd, "OpeatorName", System.Data.DbType.String, model.OpeatorName);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "ModifyTag", System.Data.DbType.String, model.ModifyTag);
            this._db.AddInParameter(cmd, "JpAdress", System.Data.DbType.String, model.JpAdress);
            this._db.AddInParameter(cmd, "OrderPrice", System.Data.DbType.Decimal, model.OrderPrice);
            this._db.AddInParameter(cmd, "InsPrice", System.Data.DbType.Decimal, model.InsPrice);
            _db.AddInParameter(cmd, "WeiDianId", System.Data.DbType.AnsiStringFixedLength, model.WeiDianId);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 删除订单记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool Delete(string OrderID)
        {
            DbCommand cmd = _db.GetSqlStringCommand("DELETE FROM tbl_PlanTicket      WHERE OrderID=@OrderID");
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, OrderID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setState(MJiPiaoBaoCun model)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_PlanTicket   SET payState = @payState  WHERE OrderID = @OrderID ");
            this._db.AddInParameter(cmd, "payState", DbType.Byte, model.payState);
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setStateAndCodeByOrderID(MJiPiaoBaoCun model)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_PlanTicket   SET payState = @payState , OrderCode=@OrderCode  WHERE OrderID = @OrderID ");
            this._db.AddInParameter(cmd, "payState", DbType.Byte, model.payState);
            this._db.AddInParameter(cmd, "OrderCode", DbType.String, model.OrderCode);
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, model.OrderID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public bool setStateByOrderCode(MJiPiaoBaoCun model)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_PlanTicket   SET payState = @payState  WHERE OrderCode = @OrderCode ");
            this._db.AddInParameter(cmd, "payState", DbType.Byte, model.payState);
            this._db.AddInParameter(cmd, "OrderCode", DbType.AnsiStringFixedLength, model.OrderCode);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 设置支付状态
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int ZhiFu(MJiPiaoBaoCun model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_zhifu");
            this._db.AddInParameter(cmd, "memnberId", DbType.AnsiStringFixedLength, model.OpeatorID);
            this._db.AddInParameter(cmd, "orderid", DbType.AnsiStringFixedLength, model.OrderID);
            this._db.AddInParameter(cmd, "price", DbType.Decimal, model.OrderPrice);

            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MJiPiaoBaoCun GetModel(string OrderID)
        {
            Eyousoft_yhq.Model.MJiPiaoBaoCun model = null;

            string StrSql = "select  *  from tbl_PlanTicket where OrderId=@OrderId";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "OrderId", DbType.AnsiStringFixedLength, OrderID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MJiPiaoBaoCun();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OpeatorID = dr.GetString(dr.GetOrdinal("OpeatorID"));
                    model.OpeatorName = dr.GetString(dr.GetOrdinal("OpeatorName"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ModifyTag = dr.IsDBNull(dr.GetOrdinal("ModifyTag")) ? "" : dr.GetString(dr.GetOrdinal("ModifyTag"));
                    model.JpAdress = dr.GetString(dr.GetOrdinal("JpAdress"));
                    model.InsPrice = dr.GetDecimal(dr.GetOrdinal("InsPrice"));


                }
            }
            return model;
        }
        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="serModel">订单编号</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MJiPiaoBaoCun> GetList(Eyousoft_yhq.Model.MJiPiaoBaoCunSer serModel)
        {
            IList<Eyousoft_yhq.Model.MJiPiaoBaoCun> list = new List<MJiPiaoBaoCun>();
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("select  *  from tbl_PlanTicket where  1=1 ");
            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.OpeatorID))
                {
                    StrSql.AppendFormat(" and  OpeatorID = '{0}' ", serModel.OpeatorID);
                }
                if (serModel.payState.HasValue && serModel.payState == TickOrderPayState.未支付)
                {
                    StrSql.AppendFormat(" and  payState = '{0}' ", (int)serModel.payState.Value);
                }
            }
            StrSql.Append("  order by IssueTime  DESC  ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MJiPiaoBaoCun model = new Eyousoft_yhq.Model.MJiPiaoBaoCun();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OpeatorID = dr.GetString(dr.GetOrdinal("OpeatorID"));
                    model.OpeatorName = dr.GetString(dr.GetOrdinal("OpeatorName"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.JpAdress = dr.IsDBNull(dr.GetOrdinal("JpAdress")) ? "" : dr.GetString(dr.GetOrdinal("JpAdress"));
                    model.ModifyTag = dr.IsDBNull(dr.GetOrdinal("ModifyTag")) ? "" : dr.GetString(dr.GetOrdinal("ModifyTag"));
                    model.payState = (TickOrderPayState)dr.GetByte(dr.GetOrdinal("payState"));
                    model.InsPrice = dr.GetDecimal(dr.GetOrdinal("InsPrice"));
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取一个订单
        /// </summary>
        /// <param name="OrderID">订单号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MJiPiaoBaoCun GetModelByCode(string OrderCode)
        {
            Eyousoft_yhq.Model.MJiPiaoBaoCun model = null;

            string StrSql = "select  *  from tbl_PlanTicket where OrderCode=@OrderCode";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "OrderCode", DbType.AnsiStringFixedLength, OrderCode);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MJiPiaoBaoCun();

                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OpeatorID = dr.GetString(dr.GetOrdinal("OpeatorID"));
                    model.OpeatorName = dr.GetString(dr.GetOrdinal("OpeatorName"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.payState = (TickOrderPayState)dr.GetByte(dr.GetOrdinal("payState"));
                    model.ModifyTag = dr.IsDBNull(dr.GetOrdinal("ModifyTag")) ? "" : dr.GetString(dr.GetOrdinal("ModifyTag"));
                    model.JpAdress = dr.IsDBNull(dr.GetOrdinal("JpAdress")) ? "" : dr.GetString(dr.GetOrdinal("JpAdress"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.InsPrice = dr.GetDecimal(dr.GetOrdinal("InsPrice"));
                }
            }


            return model;
        }

        public IList<Eyousoft_yhq.Model.MJiPiaoBaoCun> GetModelList(int PageSize, int PageIndex, ref int RecordCount, string userid)
        {
            IList<Eyousoft_yhq.Model.MJiPiaoBaoCun> list = new List<Eyousoft_yhq.Model.MJiPiaoBaoCun>();
            Eyousoft_yhq.Model.MJiPiaoBaoCun model = null;

            string tableName = "tbl_PlanTicket";
            string fileds = " OrderID,OrderCode, OpeatorID ,OpeatorName ,IssueTime, payState ,ModifyTag ,JpAdress,InsPrice";
            string orderByString = "IssueTime desc ";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1  and  OpeatorID = '{0}' ", userid);

            //if (serModel != null)
            //{

            //}


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MJiPiaoBaoCun();
                    model.OrderID = dr.GetString(dr.GetOrdinal("OrderID"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OpeatorID = dr.GetString(dr.GetOrdinal("OpeatorID"));
                    model.OpeatorName = dr.GetString(dr.GetOrdinal("OpeatorName"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.payState = (TickOrderPayState)dr.GetByte(dr.GetOrdinal("payState"));
                    model.ModifyTag = dr.IsDBNull(dr.GetOrdinal("ModifyTag")) ? "" : dr.GetString(dr.GetOrdinal("ModifyTag"));
                    model.JpAdress = dr.IsDBNull(dr.GetOrdinal("JpAdress")) ? "" : dr.GetString(dr.GetOrdinal("JpAdress"));
                    model.InsPrice = dr.GetDecimal(dr.GetOrdinal("InsPrice"));
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
