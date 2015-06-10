using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml.Linq;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DCustomMsg : DALBase
    {
        #region 初始化db
        private Database _db = null;
        public DCustomMsg()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region DCustomMsg 成员



        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.CustomMsg model)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_Recommend (OpenId ,NickName ,Sex ,CommendInfo ) VALUES (@OpenId ,@NickName ,@Sex ,@CommendInfo )");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OpenId", System.Data.DbType.String, model.OpenId);
            this._db.AddInParameter(cmd, "NickName", System.Data.DbType.String, model.NickName);
            this._db.AddInParameter(cmd, "Sex", System.Data.DbType.String, model.Sex);
            this._db.AddInParameter(cmd, "CommendInfo", System.Data.DbType.String, model.CommendInfo);


            return DbHelper.ExecuteSql(cmd, this._db);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.CustomMsg GetModel(string id)
        {
            Eyousoft_yhq.Model.CustomMsg model = null;

            string StrSql = "select  *  from tbl_Recommend where id=@id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "id", DbType.AnsiStringFixedLength, id);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.CustomMsg();

                    model.Id = dr.GetInt32(dr.GetOrdinal("id"));
                    model.OpenId = dr.GetString(dr.GetOrdinal("OpenId"));
                    model.NickName = dr.GetString(dr.GetOrdinal("NickName"));
                    model.Sex = dr.GetString(dr.GetOrdinal("Sex"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.CommendInfo = dr.GetString(dr.GetOrdinal("CommendInfo"));


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
        public IList<Eyousoft_yhq.Model.CustomMsg> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serCustomMsg serModel)
        {
            IList<Eyousoft_yhq.Model.CustomMsg> list = new List<Eyousoft_yhq.Model.CustomMsg>();

            string tableName = "tbl_Recommend";

            string fileds = " * ";

            string orderByString = " IssueTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {

            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    Eyousoft_yhq.Model.CustomMsg model = new Eyousoft_yhq.Model.CustomMsg();

                    model.Id = dr.GetInt32(dr.GetOrdinal("id"));
                    model.OpenId = dr.GetString(dr.GetOrdinal("OpenId"));
                    model.NickName = dr.GetString(dr.GetOrdinal("NickName"));
                    model.Sex = dr.GetString(dr.GetOrdinal("Sex"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.CommendInfo = dr.GetString(dr.GetOrdinal("CommendInfo"));
                    list.Add(model);
                }
            };
            return list;
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userid">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.WXBind GetWXBind(string userid)
        {
            Eyousoft_yhq.Model.WXBind model = null;

            string StrSql = "select  *  from tbl_WeiXinBind where CustomerId=@id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "id", DbType.AnsiStringFixedLength, userid);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.WXBind();

                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.CustomerId = dr.GetString(dr.GetOrdinal("CustomerId"));
                    model.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    model.MobilePhone = dr.GetString(dr.GetOrdinal("MobilePhone"));
                    model.OpenId = dr.GetString(dr.GetOrdinal("OpenId")); ;
                    model.NickName = dr.GetString(dr.GetOrdinal("NickName"));
                    model.Sex = dr.GetString(dr.GetOrdinal("Sex"));
                    model.BindTime = dr.IsDBNull(dr.GetOrdinal("BindTime")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("BindTime"));
                    model.SubscribeTime = dr.IsDBNull(dr.GetOrdinal("SubscribeTime")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("SubscribeTime"));
                    model.Country = dr.GetString(dr.GetOrdinal("Country"));
                    model.Province = dr.GetString(dr.GetOrdinal("Province"));
                    model.City = dr.GetString(dr.GetOrdinal("City"));
                    model.Language = dr.GetString(dr.GetOrdinal("Language"));


                }
            }
            return model;
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userid">编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.WXBind GetWXBindByOpenid(string openid)
        {
            Eyousoft_yhq.Model.WXBind model = null;

            string StrSql = "select  *  from tbl_WeiXinBind where OpenId=@OpenId";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "OpenId", DbType.AnsiStringFixedLength, openid);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.WXBind();

                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.CustomerId = dr.GetString(dr.GetOrdinal("CustomerId"));
                    model.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    model.MobilePhone = dr.GetString(dr.GetOrdinal("MobilePhone"));
                    model.OpenId = openid;
                    model.NickName = dr.GetString(dr.GetOrdinal("NickName"));
                    model.Sex = dr.GetString(dr.GetOrdinal("Sex"));
                    model.BindTime = dr.IsDBNull(dr.GetOrdinal("BindTime")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("BindTime"));
                    model.SubscribeTime = dr.IsDBNull(dr.GetOrdinal("SubscribeTime")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("SubscribeTime"));
                    model.Country = dr.GetString(dr.GetOrdinal("Country"));
                    model.Province = dr.GetString(dr.GetOrdinal("Province"));
                    model.City = dr.GetString(dr.GetOrdinal("City"));
                    model.Language = dr.GetString(dr.GetOrdinal("Language"));


                }
            }
            return model;
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Eyousoft_yhq.Model.WXBind model)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO tbl_WeiXinBind( CustomerId , CustomerName , MobilePhone , OpenId , NickName , Sex  , SubscribeTime , Country , Province , City , Language ) VALUES ( @CustomerId , @CustomerName , @MobilePhone , @OpenId , @NickName , @Sex  , @SubscribeTime , @Country , @Province , @City , @LANGUAGE )");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CustomerId", System.Data.DbType.String, model.CustomerId);
            this._db.AddInParameter(cmd, "CustomerName", System.Data.DbType.String, model.CustomerName);
            this._db.AddInParameter(cmd, "MobilePhone", System.Data.DbType.String, model.MobilePhone);
            this._db.AddInParameter(cmd, "OpenId", System.Data.DbType.String, model.OpenId);
            this._db.AddInParameter(cmd, "NickName", System.Data.DbType.String, model.NickName);
            this._db.AddInParameter(cmd, "Sex", System.Data.DbType.String, model.Sex);
            this._db.AddInParameter(cmd, "SubscribeTime", System.Data.DbType.String, model.SubscribeTime);
            this._db.AddInParameter(cmd, "Province", System.Data.DbType.String, model.Province);
            this._db.AddInParameter(cmd, "City", System.Data.DbType.String, model.City);
            this._db.AddInParameter(cmd, "Language", System.Data.DbType.String, model.Language);


            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        ///  修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int updateWXBind(Eyousoft_yhq.Model.WXBind model)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_WeiXinBind  SET CustomerId=@CustomerId,  OpenId = @OpenId , NickName = @NickName , Sex = @Sex  WHERE Id=@Id)");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", System.Data.DbType.String, model.Id);
            this._db.AddInParameter(cmd, "CustomerId", System.Data.DbType.String, model.CustomerId);
            this._db.AddInParameter(cmd, "OpenId", System.Data.DbType.String, model.OpenId);
            this._db.AddInParameter(cmd, "NickName", System.Data.DbType.String, model.NickName);
            this._db.AddInParameter(cmd, "Sex", System.Data.DbType.String, model.Sex);


            return DbHelper.ExecuteSql(cmd, this._db);
        }
        #endregion
    }
}
