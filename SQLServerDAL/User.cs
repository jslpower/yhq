using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Xml.Linq;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// webmaster
    /// </summary>
    public partial class User : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public User()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region IUser 成员
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_User");
            strSql.Append(" where UserName=@UserName ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.String, UserName);

            return DbHelper.Exists(cmd, this._db);
        }
        /// <summary>
        /// 注册用户/添加用户
        /// </summary>
        /// <param name="model">用户实体/管理员实体</param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model)
        {

            StringBuilder strSql = new StringBuilder();
            if (model.IsAdmin)
            {
                strSql.Append("  INSERT INTO tbl_User([UserID],[UserName],[UserPwd],[ContactName],[ContactSex],[Remark],[IssueTime],[ContactTel] ,[IsAdmin],[UserState],[Privs],SealImg,LeiXing)VALUES (@UserID,@UserName,@UserPwd,@ContactName,@ContactSex,@Remark,@IssueTime,@ContactTel,@IsAdmin,1,@Privs,@SealImg,@LeiXing) ");
            }
            else
            {
                strSql.Append("  INSERT INTO tbl_User([UserID],[UserName],[UserPwd],[ContactName],[Remark],[IssueTime],[ContactTel] ,[IsAdmin],[UserState],[LeiXing])		VALUES (@UserID,@UserName,@UserPwd,@ContactName,@Remark,@IssueTime,@ContactTel,@IsAdmin,1,@LeiXing) ");
            }

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, model.UserId);
            this._db.AddInParameter(cmd, "UserName", System.Data.DbType.String, model.Username);
            this._db.AddInParameter(cmd, "UserPwd", System.Data.DbType.String, model.MiMa);
            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.String, model.XingMing);
            this._db.AddInParameter(cmd, "ContactSex", System.Data.DbType.Byte, (int)0);
            this._db.AddInParameter(cmd, "Remark", System.Data.DbType.String, model.BeiZhu);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.CreateTime);
            this._db.AddInParameter(cmd, "ContactTel", System.Data.DbType.String, model.Telephone);
            this._db.AddInParameter(cmd, "IsAdmin", System.Data.DbType.String, model.IsAdmin ? "1" : "0");
            this._db.AddInParameter(cmd, "Privs", System.Data.DbType.String, "");
            this._db.AddInParameter(cmd, "SealImg", System.Data.DbType.String, model.GongZhangFilepath);
            _db.AddInParameter(cmd, "LeiXing", System.Data.DbType.Int32, model.LeiXing);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("UPDATE tbl_User  SET UserPwd = @UserPwd ,ContactName =@ContactName ,Remark =@Remark,SealImg=@SealImg ");
            strSql.Append(" ,ContactTel = @ContactTel  ");
            strSql.Append(" ,LeiXing=@LeiXing ");
            strSql.Append(" WHERE UserID = @UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, model.UserId);

            this._db.AddInParameter(cmd, "UserPwd", System.Data.DbType.String, model.MiMa);
            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.String, model.XingMing);
            this._db.AddInParameter(cmd, "ContactSex", System.Data.DbType.Byte, (int)0);
            this._db.AddInParameter(cmd, "Remark", System.Data.DbType.String, model.BeiZhu);

            this._db.AddInParameter(cmd, "ContactTel", System.Data.DbType.String, model.Telephone);
            this._db.AddInParameter(cmd, "UserState", System.Data.DbType.Byte, model.Status);
            this._db.AddInParameter(cmd, "SealImg", System.Data.DbType.String, model.GongZhangFilepath);
            _db.AddInParameter(cmd, "LeiXing", System.Data.DbType.Int32, model.LeiXing);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        public bool UpdatePrivs(EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("UPDATE tbl_User  SET Privs = @Privs ");


            strSql.Append(" WHERE UserID = @UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, model.UserId);
            this._db.AddInParameter(cmd, "Privs", System.Data.DbType.String, model.Privs);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public int Delete(string UserID)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_User_Delete");
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, UserID);
            this._db.AddOutParameter(cmd, "result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        public bool qiyong(string UserID)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.Append("UPDATE tbl_User  SET userstate = 1 ");


            strSql.Append(" WHERE UserID = @UserID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, UserID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="UserIDlist">用户编号</param>
        /// <returns></returns>
        public bool DeleteList(string[] UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("DELETE FROM  tbl_User   WHERE UserID in ({0}) ", Utils.GetSqlInExpression(UserIDlist));
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public EyouSoft.Model.SSOStructure.MGuanLiYuanInfo GetModel(string UserID)
        {
            EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("  FROM tbl_User  ");
            strSql.Append(" where UserID=@UserID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "UserID", System.Data.DbType.AnsiStringFixedLength, UserID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.SSOStructure.MGuanLiYuanInfo();
                    model.UserId = dr["UserID"].ToString();
                    model.Username = dr["UserName"].ToString();
                    model.MiMa = dr["UserPwd"].ToString();
                    model.XingMing = dr["ContactName"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex"))) model.XingBie = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.BeiZhu = dr["Remark"].ToString();
                    model.Telephone = dr["ContactTel"].ToString();
                    model.IsAdmin = dr["IsAdmin"].ToString() == "1";
                    model.Status = dr.GetByte(dr.GetOrdinal("UserState"));
                    model.Privs = dr["Privs"].ToString();
                    model.GongZhangFilepath = dr["SealImg"].ToString();
                    model.CreateTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LeiXing = (Eyousoft_yhq.Model.WebmasterLeiXing)dr.GetInt32(dr.GetOrdinal("LeiXing"));
                }
            }

            return model;
        }



        public IList<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.SSOStructure.MGuanLiYuanChaXunInfo serModel)
        {
            IList<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo> list = new List<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo>();


            string tableName = "tbl_User";
            string fileds = " *  ";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");
            if (serModel != null)
            {

                if (!string.IsNullOrEmpty(serModel.Username))
                {
                    query.AppendFormat(" and  UserName like '%{0}%' ", serModel.Username);
                }

                if (!string.IsNullOrEmpty(serModel.XingMing))
                {
                    query.AppendFormat(" and  ContactName like '%{0}%' ", serModel.XingMing);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    var model = new EyouSoft.Model.SSOStructure.MGuanLiYuanInfo();
                    model.UserId = dr["UserID"].ToString();
                    model.Username = dr["UserName"].ToString();
                    model.MiMa = dr["UserPwd"].ToString();
                    model.XingMing = dr["ContactName"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex"))) model.XingBie = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.BeiZhu = dr["Remark"].ToString();
                    model.Telephone = dr["ContactTel"].ToString();
                    model.IsAdmin = dr["IsAdmin"].ToString() == "1";
                    model.Status = dr.GetByte(dr.GetOrdinal("UserState"));
                    model.Privs = dr["Privs"].ToString();
                    model.GongZhangFilepath = dr["SealImg"].ToString();
                    model.CreateTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LeiXing = (Eyousoft_yhq.Model.WebmasterLeiXing)dr.GetInt32(dr.GetOrdinal("LeiXing"));

                    list.Add(model);
                }
            }
            return list;
        }

        public IList<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo> GetList(EyouSoft.Model.SSOStructure.MGuanLiYuanChaXunInfo serModel)
        {
            IList<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo> list = new List<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo>();
            StringBuilder query = new StringBuilder();
            query.Append("select *   from tbl_User where  1=1");

            if (serModel != null)
            {

                if (!string.IsNullOrEmpty(serModel.Username))
                {
                    query.AppendFormat(" and  UserName like '%{0}%' ", serModel.Username);
                }

                if (!string.IsNullOrEmpty(serModel.XingMing))
                {
                    query.AppendFormat(" and  ContactName like '%{0}%' ", serModel.XingMing);
                }
            }
            query.Append("  order by UserID  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {

                    var model = new EyouSoft.Model.SSOStructure.MGuanLiYuanInfo();
                    model.UserId = dr["UserID"].ToString();
                    model.Username = dr["UserName"].ToString();
                    model.MiMa = dr["UserPwd"].ToString();
                    model.XingMing = dr["ContactName"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex"))) model.XingBie = (sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.BeiZhu = dr["Remark"].ToString();
                    model.Telephone = dr["ContactTel"].ToString();
                    model.IsAdmin = dr["IsAdmin"].ToString() == "1";
                    model.Status = dr.GetByte(dr.GetOrdinal("UserState"));
                    model.Privs = dr["Privs"].ToString();
                    model.GongZhangFilepath = dr["SealImg"].ToString();
                    model.CreateTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LeiXing = (Eyousoft_yhq.Model.WebmasterLeiXing)dr.GetInt32(dr.GetOrdinal("LeiXing"));

                    list.Add(model);
                }
            }
            return list;
        }

        #endregion


        #region 获取省市区县镇乡
        /// <summary>
        /// 获取省市区县镇乡列表
        /// </summary>
        /// <param name="serModel">查询实体</param>
        /// <returns></returns>
        public IList<Pro_City_Area_Street> GetProList(Pro_City_Area_StreetSer serModel)
        {
            IList<Pro_City_Area_Street> list = new List<Pro_City_Area_Street>();
            StringBuilder query = new StringBuilder();
            query.Append("select *   from tbl_prov_city_area_street where  1=1");

            if (serModel != null)
            {

                if (serModel.id > 0)
                {
                    query.AppendFormat(" and  id={0} ", serModel.id);
                }

                if (serModel.level > 0)
                {
                    query.AppendFormat(" and  level={0} ", serModel.level);
                }
                if (!string.IsNullOrEmpty(serModel.parentId))
                {
                    query.AppendFormat(" and  parentId='{0}' ", serModel.parentId);
                }
            }
            query.Append("order by id asc");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {

                    var model = new Pro_City_Area_Street();
                    model.id = dr.GetInt32(dr.GetOrdinal("id"));
                    model.code = dr["code"].ToString();
                    model.level = dr.GetInt32(dr.GetOrdinal("level"));
                    model.name = dr["name"].ToString();
                    model.parentId = dr["parentId"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion

    }
}

