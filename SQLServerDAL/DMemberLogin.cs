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
    /// 系统用户登录数据访问类
    /// </summary>
    public class DMemberLogin : DALBase
    {
        #region static constants
        //static constants

        private const string SqlSelectLogin =
            @"SELECT [UserID],[UserName],[UserPwd],[ContactName],[ContactSex],[Remark],[IssueTime],[PromotionCode],[valiUser],[IsAgent],[iszz],[MingPianId]  FROM [tbl_Member] ";


        private const string SqlUpdateSetOnlineStatus = " UPDATE [tbl_Member] SET [OnlineStatus]=@OnlineStatus,[OnlineSessionId]=@OnlineSessionId WHERE [MemberID]=@UserId";

        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DMemberLogin()
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
        private MUserInfo ReadUserInfo(DbCommand cmd)
        {
            EyouSoft.Model.SSOStructure.MUserInfo model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, SystemStore))
            {
                if (dr.Read())
                {
                    model = new MUserInfo();
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.UserPwd = dr.IsDBNull(dr.GetOrdinal("UserPwd")) ? "" : dr.GetString(dr.GetOrdinal("UserPwd"));
                    model.ContactName = dr.IsDBNull(dr.GetOrdinal("ContactName")) ? "" : dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactSex = (Eyousoft_yhq.Model.sexType)dr.GetByte(dr.GetOrdinal("ContactSex"));
                    model.Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"));
                    model.PromotionCode = dr.IsDBNull(dr.GetOrdinal("PromotionCode")) ? "" : dr.GetString(dr.GetOrdinal("PromotionCode"));
                    model.valiUser = GetBoolean(dr.GetString(dr.GetOrdinal("valiUser")));
                    model.IsAdmin = dr.GetString(dr.GetOrdinal("IsAgent"));
                    model.IsZZ = GetBoolean(dr.GetString(dr.GetOrdinal("IsZZ")));

                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }

                    model.MingPianId = dr["MingPianId"].ToString();
                }
            }

            if (model != null)
            {
                model.WeiDianId = GetWeiDianId(model.UserID);
            }

            return model;
        }

        /// <summary>
        /// 获取微店编号
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        string GetWeiDianId(string huiYuanId)
        {
            string weiDianId = string.Empty;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_WeiDian WHERE HuiYuanId=@HuiYuanId");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    weiDianId = rdr["WeiDianId"].ToString();
                }
            }

            return weiDianId;
        }
        #endregion

        #region IUserLogin 成员

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public MUserInfo Login(string username, string pwd)
        {
            DbCommand cmd =
                _db.GetSqlStringCommand(
                    string.Format(
                        " {0} WHERE [UserName]=@UserName AND [UserPwd]=@UserPwd ", SqlSelectLogin));
            _db.AddInParameter(cmd, "UserName", DbType.String, username);
            _db.AddInParameter(cmd, "UserPwd", DbType.String, pwd);

            return ReadUserInfo(cmd);
        }

        /// <summary>
        /// 用户登录，根据用户编号获取用户信息
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public MUserInfo LoginById(string userid)
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
        public MUserInfo LoginByName(string username)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SqlSelectLogin + " WHERE [Account]=@UN ");
            _db.AddInParameter(cmd, "UN", DbType.String, username);

            return ReadUserInfo(cmd);
        }


        #endregion
    }
}
