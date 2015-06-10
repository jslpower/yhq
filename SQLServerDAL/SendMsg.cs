using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class SendMsg : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public SendMsg()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 判断当前用户是否已经领取优惠码
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="productid">产品编号</param>
        /// <returns></returns>
        public bool Exists(string UserName, string productid, string FavourCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_SendMSG");
            strSql.Append(" where sendNum=@UserName  and ProductID=@productid and FavourCode=@FavourCode");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.String, UserName);
            this._db.AddInParameter(cmd, "productid", System.Data.DbType.String, productid);
            this._db.AddInParameter(cmd, "FavourCode", System.Data.DbType.String, FavourCode);

            return DbHelper.Exists(cmd, this._db);
        }

        /// <summary>
        /// 添加发送信息
        /// </summary>
        /// <param name="model">发送信息实体</param>
        /// <returns></returns>
        public bool Add(Eyousoft_yhq.Model.SendMSG model)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" INSERT INTO  tbl_SendMSG  (sendNum,SendText,issuetime,ProductID,FavourCode) 	VALUES (@sendNum,@SendText,@issuetime,@ProductID,@FavourCode) ;UPDATE [tbl_KV]   SET  v= v - @minusNum WHERE k='MsgNumber' ");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "sendNum", System.Data.DbType.AnsiStringFixedLength, model.SendNum);
            this._db.AddInParameter(cmd, "SendText", System.Data.DbType.String, model.SendText);
            this._db.AddInParameter(cmd, "issuetime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.AnsiStringFixedLength, model.ProductID);
            this._db.AddInParameter(cmd, "minusNum", System.Data.DbType.Int32, model.minusNum);
            this._db.AddInParameter(cmd, "FavourCode", System.Data.DbType.String, model.FavourCode);


            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 统计当前产品优惠码领取次数
        /// </summary>
        /// <param name="model">产品编号</param>
        /// <returns></returns>
        public int countNum(string id)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("  SELECT COUNT(1)  FROM tbl_SendMSG  WHERE ProductID=@ProductID  ");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.AnsiStringFixedLength, id);


            return (int)DbHelper.GetSingle(cmd, this._db);
        }
        /// <summary>
        /// 统计当前分类产品优惠码领取次数
        /// </summary>
        /// <param name="model">产品类别编号</param>
        /// <returns></returns>
        public int countTypeNum(string id)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("  SELECT COUNT(1) FROM tbl_SendMsg WHERE ProductID IN(SELECT tbl_Product.ProductID FROM tbl_Product WHERE ProductType=@ProductType)  ");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductType",DbType.Int32, id);


            return (int)DbHelper.GetSingle(cmd, this._db);
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
        public IList<Eyousoft_yhq.Model.SendMSG> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serSendMSG serModel)
        {
            IList<Eyousoft_yhq.Model.SendMSG> list = new List<Eyousoft_yhq.Model.SendMSG>();


            string tableName = "tbl_SendMSG";
            string fileds = "  msgId,sendNum,SendText,issuetime,ProductID  ";
            string orderByString = "msgId desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1  ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.ProductID))
                {
                    query.AppendFormat(" and  ProductID = '{0}' ", serModel.ProductID);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.SendMSG model = new Eyousoft_yhq.Model.SendMSG();
                    model.MsgID = dr.GetInt32(dr.GetOrdinal("msgId"));
                    model.SendNum = dr.IsDBNull(dr.GetOrdinal("SendNum")) ? "" : dr.GetString(dr.GetOrdinal("SendNum"));
                    model.SendText = dr.IsDBNull(dr.GetOrdinal("SendText")) ? "" : dr.GetString(dr.GetOrdinal("SendText"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID")).ToString();

                    list.Add(model);
                }
            }
            return list;
        }

    }
}
