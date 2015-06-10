/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.SSOStructure;

namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// webmaster登录数据访问类
    /// </summary>
    public class DWebmasterLogin : DALBase
    {
        #region static constants
        //static constants
        //  const string SQL_SELECT_Login = "SELECT [Id],[Username],[Password],[MD5Password],[Realname],[Telephone],[Fax],[Mobile],[Permissions],[IsEnable],[IsAdmin],[CreateTime] FROM [tbl_Webmaster] WHERE [Username]=@UN AND [MD5Password]=@MD5PWD and [IsEnable] = '1' ";
        const string SQL_SELECT_Login = "SELECT *  FROM tbl_User WHERE UserName=@un AND UserPwd=@uw AND UserState='1'";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DWebmasterLogin()
        {
            _db = SystemStore;
        }
        #endregion

        #region IWebmasterLogin 成员
        /// <summary>
        /// webmaster登录，根据用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public MWebmasterInfo Login(string username, string pwd)
        {
            MWebmasterInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_Login);
            _db.AddInParameter(cmd, "un", DbType.String, username);
            _db.AddInParameter(cmd, "uw", DbType.String, pwd);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (dr.Read())
                {
                    info = new MWebmasterInfo
                    {
                        UserId = dr.GetInt32(0),
                        Username = dr.GetString(1),
                        XingMing =
                            dr.IsDBNull(dr.GetOrdinal("ContactName"))
                                ? string.Empty
                                : dr.GetString(dr.GetOrdinal("ContactName")),
                        //Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? string.Empty : dr.GetString(dr.GetOrdinal("Fax")),
                        Telephone =
                            dr.IsDBNull(dr.GetOrdinal("ContactTel"))
                                ? string.Empty
                                : dr.GetString(dr.GetOrdinal("ContactTel")),
                        //Mobile =
                        //    dr.IsDBNull(dr.GetOrdinal("Mobile"))
                        //        ? string.Empty
                        //        : dr.GetString(dr.GetOrdinal("Mobile")),
                        //IsEnable =
                        //    this.GetBoolean(
                        //        dr.IsDBNull(dr.GetOrdinal("IsEnable"))
                        //            ? string.Empty
                        //            : dr.GetString(dr.GetOrdinal("IsEnable"))),
                        IsAdmin =
                            this.GetBoolean(
                                dr.IsDBNull(dr.GetOrdinal("IsAdmin"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("IsAdmin")))
                    };
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        info.CreateTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                    info.LeiXing = (Eyousoft_yhq.Model.WebmasterLeiXing)dr.GetInt32(dr.GetOrdinal("LeiXing"));
                }
            }

            return info;
        }
        #endregion
    }
}
*/