using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Xml.Linq;


namespace Eyousoft_yhq.SQLServerDAL
{
    public class MsgLog : DALBase
    {
        private Database _db = null;
        public MsgLog()
        {
            _db = base.SystemStore;
        }

        /// <summary>
        /// 添加发送信息
        /// </summary>
        /// <param name="model">发送信息实体</param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.MsgLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO  tbl_MsgLog (TelCode,MsgText,ReResult,Issuetime) VALUES (@TelCode,@MsgText,@ReResult,@Issuetime) ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TelCode", System.Data.DbType.String, model.TelCode);
            this._db.AddInParameter(cmd, "MsgText", System.Data.DbType.String, model.MsgText);
            this._db.AddInParameter(cmd, "ReResult", System.Data.DbType.String, model.ReResult);
            this._db.AddInParameter(cmd, "Issuetime", System.Data.DbType.DateTime, DateTime.Now);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 获取发送列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MsgLog> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serMsgLog serModel)
        {
            IList<Eyousoft_yhq.Model.MsgLog> list = new List<Eyousoft_yhq.Model.MsgLog>();


            string tableName = "tbl_MsgLog";
            string fileds = "  msgID,TelCode,MsgText,ReResult,Issuetime  ";
            string orderByString = " msgID desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1  ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.TelCode))
                {
                    query.AppendFormat(" and  TelCode = '{0}' ", serModel.TelCode);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.MsgLog model = new Eyousoft_yhq.Model.MsgLog();
                    model.msgid = dr.GetInt32(dr.GetOrdinal("msgID"));
                    model.TelCode = dr.IsDBNull(dr.GetOrdinal("TelCode")) ? "" : dr.GetString(dr.GetOrdinal("TelCode"));
                    model.MsgText = dr.IsDBNull(dr.GetOrdinal("MsgText")) ? "" : dr.GetString(dr.GetOrdinal("MsgText"));
                    model.ReResult = dr.IsDBNull(dr.GetOrdinal("ReResult")) ? "" : dr.GetString(dr.GetOrdinal("ReResult"));
                    model.Issuetime = dr.GetDateTime(dr.GetOrdinal("ProductID"));

                    list.Add(model);
                }
            }
            return list;
        }



    }
}
