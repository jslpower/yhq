using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class GYSticket : DALBase
    {
        private Database _db = null;
        public GYSticket()
        {
            _db = base.SystemStore;
        }




        #region IGYSticket 成员


        /// <summary>
        /// 车票/景点门票添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.GYSticket model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  INSERT INTO GYSTicket  (ID,CusName,CusSex,CusMob,PlaneTicket,IssueTime,Remark,OpertorID,OrderState,TicketState) VALUES (@ID,@CusName,@CusSex,@CusMob,@PlaneTicket,@IssueTime,@Remark,@OpertorID,@OrderState,@TicketState) ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());


            this._db.AddInParameter(cmd, "ID", DbType.AnsiStringFixedLength, model.ID);
            this._db.AddInParameter(cmd, "CusName", DbType.String, model.CusName);
            this._db.AddInParameter(cmd, "CusSex", DbType.Int32, (int)model.CusSex);
            this._db.AddInParameter(cmd, "CusMob", DbType.String, model.CusMob);
            this._db.AddInParameter(cmd, "PlaneTicket", DbType.String, model.PlaneTicket);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "OpertorID", DbType.AnsiStringFixedLength, model.OpertorID);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.orderState);
            this._db.AddInParameter(cmd, "TicketState", DbType.Byte, (int)model.payState);


            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Eyousoft_yhq.Model.GYSticket model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("   UPDATE   GYSTicket  SET   CusName  = @CusName  , CusSex  = @CusSex , CusMob  = @CusMob , PlaneTicket  = @PlaneTicket , IssueTime  = @IssueTime  , Remark  =  @Remark ,OpertorID=@OpertorID ,OrderState=@OrderState,TicketState=@TicketState WHERE  ID  = @ID  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());


            this._db.AddInParameter(cmd, "ID", DbType.AnsiStringFixedLength, model.ID);
            this._db.AddInParameter(cmd, "CusName", DbType.String, model.CusName);
            this._db.AddInParameter(cmd, "CusSex", DbType.Int32, (int)model.CusSex);
            this._db.AddInParameter(cmd, "CusMob", DbType.String, model.CusMob);
            this._db.AddInParameter(cmd, "PlaneTicket", DbType.String, model.PlaneTicket);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "OpertorID", DbType.AnsiStringFixedLength, model.OpertorID);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.orderState);
            this._db.AddInParameter(cmd, "TicketState", DbType.Byte, (int)model.payState);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }


        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="ID">单个编号</param>
        /// <returns></returns>
        public bool Delete(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  DELETE FROM  GYSTicket        WHERE ID=@ID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "ID", DbType.AnsiStringFixedLength, ID);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }



        /// <summary>
        /// 获取机票实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.GYSticket GetModel(string id)
        {
            Eyousoft_yhq.Model.GYSticket model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT ID  , CusName  , CusSex  , CusMob  , PlaneTicket  , IssueTime  , Remark,OpertorID,OrderState,TicketState  FROM GYSTicket ");
            strSql.Append(" where id=@id ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "id", System.Data.DbType.AnsiStringFixedLength, id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.GYSticket();
                    model.ID = dr.GetString(dr.GetOrdinal("ID")); ;
                    model.CusName = dr.GetString(dr.GetOrdinal("CusName"));
                    model.CusSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("CusSex"));
                    model.CusMob = dr.GetString(dr.GetOrdinal("CusMob"));
                    model.PlaneTicket = dr.GetString(dr.GetOrdinal("PlaneTicket"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    model.OpertorID = dr.GetString(dr.GetOrdinal("OpertorID"));
                    model.orderState = (Eyousoft_yhq.Model.TickOrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.payState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("TicketState"));

                }
            }

            return model;
        }

        /// <summary>
        /// 返回分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.GYSticket> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.GysTicketSer serModel)
        {
            IList<Eyousoft_yhq.Model.GYSticket> list = new List<Eyousoft_yhq.Model.GYSticket>();


            string tableName = "GYSTicket";
            string fileds = "  ID  , CusName  , CusSex  , CusMob  , PlaneTicket  , IssueTime  , Remark, OpertorID,OrderState,TicketState ";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1  ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.OpertorID))
                {
                    query.AppendFormat(" and  OpertorID =  '{0}' ", serModel.OpertorID);
                }
                if (!string.IsNullOrEmpty(serModel.cusName))
                {
                    query.AppendFormat(" and  CusName  LIKE  '%{0}%' ", serModel.cusName);
                }
                if (!string.IsNullOrEmpty(serModel.cusMob))
                {
                    query.AppendFormat(" and  CusMob  LIKE  '%{0}%' ", serModel.cusMob);
                }
                if (!string.IsNullOrEmpty(serModel.tickNO))
                {
                    query.AppendFormat(" and  PlaneTicket  LIKE  '%{0}%' ", serModel.tickNO);
                }
            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.GYSticket model = new Eyousoft_yhq.Model.GYSticket();
                    model.ID = dr.GetString(dr.GetOrdinal("ID")); ;
                    model.CusName = dr.GetString(dr.GetOrdinal("CusName"));
                    model.CusSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("CusSex"));
                    model.CusMob = dr.GetString(dr.GetOrdinal("CusMob"));
                    model.PlaneTicket = dr.GetString(dr.GetOrdinal("PlaneTicket"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    model.OpertorID = dr.GetString(dr.GetOrdinal("OpertorID"));
                    model.orderState = (Eyousoft_yhq.Model.TickOrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.payState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("TicketState"));


                    list.Add(model);
                }
            }
            return list;
        }


        /// <summary>
        /// 返回分页列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.GYSticket> GetList(Eyousoft_yhq.Model.GysTicketSer serModel)
        {
            IList<Eyousoft_yhq.Model.GYSticket> list = new List<Eyousoft_yhq.Model.GYSticket>();
            StringBuilder query = new StringBuilder();


            query.Append("select     ID  , CusName  , CusSex  , CusMob  , PlaneTicket  , IssueTime  , Remark, OpertorID,OrderState,TicketState     from GYSTicket where  1=1");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.OpertorID))
                {
                    query.AppendFormat(" and  OpertorID =  '{0}' ", serModel.OpertorID);
                }
            }

            query.Append("  order by IssueTime  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.GYSticket model = new Eyousoft_yhq.Model.GYSticket();
                    model.ID = dr.GetString(dr.GetOrdinal("ID")); ;
                    model.CusName = dr.GetString(dr.GetOrdinal("CusName"));
                    model.CusSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("CusSex"));
                    model.CusMob = dr.GetString(dr.GetOrdinal("CusMob"));
                    model.PlaneTicket = dr.GetString(dr.GetOrdinal("PlaneTicket"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    model.OpertorID = dr.GetString(dr.GetOrdinal("OpertorID"));
                    model.orderState = (Eyousoft_yhq.Model.TickOrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.payState = (Eyousoft_yhq.Model.PaymentState)dr.GetByte(dr.GetOrdinal("TicketState"));


                    list.Add(model);
                }
            }
            return list;
        }

        #endregion



    }
}
