//2011-09-23 汪奇志
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.SSOStructure;
using System.Xml.Linq;
using Eyousoft_yhq.SQLServerDAL;

namespace Eyousoft_yhq.SQLServerDAL
{

    /// <summary>
    /// webmaster login
    /// </summary>
    public class DUserLogin : DALBase
    {
        #region static constants
        //static constants

        private const string SqlSelectLogin ="SELECT * FROM [tbl_User] ";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DUserLogin()
        {
            _db = SystemStore;
        }

        #endregion

        #region private members
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private MWebmasterInfo ReadUserInfo(DbCommand cmd)
        {
            EyouSoft.Model.SSOStructure.MWebmasterInfo model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, SystemStore))
            {
                if (dr.Read())
                {
                    model = new MWebmasterInfo();
                    model.UserId = dr["UserID"].ToString();
                    model.Username = dr["UserName"].ToString();
                    model.XingMing = dr["ContactName"].ToString();
                    model.Telephone = dr["ContactTel"].ToString();
                    model.IsAdmin = dr["IsAdmin"].ToString() == "1";
                    model.Status = dr.GetByte(dr.GetOrdinal("UserState"));
                    model.Privs = dr["Privs"].ToString();
                    model.CreateTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LeiXing = (Eyousoft_yhq.Model.WebmasterLeiXing)dr.GetInt32(dr.GetOrdinal("LeiXing"));

                }
            }

            return model;
        }

        #endregion

        #region IUserLogin 成员

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public MWebmasterInfo Login(string username, string pwd)
        {
            DbCommand cmd =
                _db.GetSqlStringCommand(
                    string.Format(
                        " {0} WHERE [UserName]=@UserName AND [UserPwd]=@UserPwd AND [UserState]=1", SqlSelectLogin));
            _db.AddInParameter(cmd, "UserName", DbType.String, username);
            _db.AddInParameter(cmd, "UserPwd", DbType.String, pwd);

            return ReadUserInfo(cmd);
        }

        /// <summary>
        /// 用户登录，根据用户编号获取用户信息
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public MWebmasterInfo LoginById(string userid)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SqlSelectLogin + " WHERE [UserID]=@UID ");
            _db.AddInParameter(cmd, "UID", DbType.AnsiStringFixedLength, userid);

            return ReadUserInfo(cmd);
        }

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <returns></returns>
        public MWebmasterInfo LoginByName(string username)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SqlSelectLogin + " WHERE [Account]=@UN ");
            _db.AddInParameter(cmd, "UN", DbType.String, username);

            return ReadUserInfo(cmd);
        }


        #endregion
    }
}
