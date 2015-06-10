using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Eyousoft_yhq.Model;
using System.Data;
using System.Data.Common;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class persner : DALBase
    {
         #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public persner()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OrderPassenger model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_OrderPassenger( OrderCode, PsrName ,PsrType ,IdentityType, IdentityCard ,Mobile) VALUES ( @OrderCode, @PsrName,@PsrType,@IdentityType, @IdentityCard,@Mobile)");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "OrderCode", DbType.String, model.OrderCode);
            this._db.AddInParameter(cmd, "PsrName", DbType.String, model.PsrName);
            this._db.AddInParameter(cmd, "PsrType", DbType.Byte, model.PsrType);
            this._db.AddInParameter(cmd, "IdentityType", DbType.Byte, model.IdentityType);
            this._db.AddInParameter(cmd, "IdentityCard", DbType.String, model.IdentityCard);
            this._db.AddInParameter(cmd, "Mobile", DbType.String, model.Mobile);
           
            return DbHelper.ExecuteSql(cmd, this._db);

        }



        public IList<Eyousoft_yhq.Model.OrderPassenger> GetModelList(string ordercode,int PageSize, int PageIndex, ref int  RecordCount)
        {
            IList<Eyousoft_yhq.Model.OrderPassenger> list = new List<Eyousoft_yhq.Model.OrderPassenger>();


            string tableName = "tbl_OrderPassenger";
            string fileds = "ID, OrderCode, PsrName ,PsrType ,IdentityType, IdentityCard ,Mobile";
            string orderByString = "ID desc ";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 and OrderCode={0}",ordercode);

          

           
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.OrderPassenger model = new Eyousoft_yhq.Model.OrderPassenger();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.PsrName = dr.GetString(dr.GetOrdinal("PsrName"));

                    model.PsrType = (Eyousoft_yhq.Model.PerType)dr.GetByte(dr.GetOrdinal("PsrType"));
                    model.IdentityType = (Eyousoft_yhq.Model.CartType)dr.GetByte(dr.GetOrdinal("IdentityType"));
                    model.IdentityCard = dr.GetString(dr.GetOrdinal("IdentityCard"));



                    model.Mobile = dr.IsDBNull(dr.GetOrdinal("Mobile")) ? "" : dr.GetString(dr.GetOrdinal("Mobile"));

                    list.Add(model);
                }
            }
            return list;
        }



    }
}
