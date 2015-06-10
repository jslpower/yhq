//微信相关DAL 汪奇志 2014-01-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 微信相关DAL
    /// </summary>
    public class DWeiXin : DALBase
    {
        #region static constants
        //static constants

        #endregion

        #region constructor
        private Database _db = null;

        public DWeiXin()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// read yonghu info
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Eyousoft_yhq.Model.MWeiXinYongHuInfo ReadYongHuInfo(DbCommand cmd)
        {
            Eyousoft_yhq.Model.MWeiXinYongHuInfo info = null;
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new Eyousoft_yhq.Model.MWeiXinYongHuInfo();

                    info.city = rdr["city"].ToString();
                    info.country = rdr["country"].ToString();
                    info.createtime = rdr.GetDateTime(rdr.GetOrdinal("createtime"));
                    info.headimgurl = rdr["headimgurl"].ToString();
                    info.language = rdr["language"].ToString();
                    info.latesttime = rdr.GetDateTime(rdr.GetOrdinal("latesttime"));
                    info.nickname = rdr["nickname"].ToString();
                    info.openid = rdr["openid"].ToString();
                    info.province = rdr["province"].ToString();
                    info.sex = rdr["sex"].ToString();
                    info.subscribe = rdr["subscribe"].ToString();
                    info.subscribe_time = rdr["subscribe_time"].ToString();
                    info.unionid = rdr["unionid"].ToString();
                    info.YongHuId = rdr["YongHuId"].ToString();
                    info.LeiXing = rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    info.HuiYuanId = rdr["HuiYuanId"].ToString().Trim();
                    info.BangDingTime = rdr.GetDateTime(rdr.GetOrdinal("BangDingTime"));
                }
            }

            return info;
        }
        #endregion

        #region public members
        /// <summary>
        /// 微信用户新增修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int YongHu_CU(Eyousoft_yhq.Model.MWeiXinYongHuInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_WeiXin_YongHu_CU");

            _db.AddInParameter(cmd, "@YongHuId", DbType.AnsiStringFixedLength, info.YongHuId);
            _db.AddInParameter(cmd, "@subscribe", DbType.String, info.subscribe);
            _db.AddInParameter(cmd, "@openid", DbType.String, info.openid);
            _db.AddInParameter(cmd, "@nickname", DbType.String, info.nickname);
            _db.AddInParameter(cmd, "@sex", DbType.String, info.sex);
            _db.AddInParameter(cmd, "@city", DbType.String, info.city);
            _db.AddInParameter(cmd, "@country", DbType.String, info.country);
            _db.AddInParameter(cmd, "@province", DbType.String, info.province);
            _db.AddInParameter(cmd, "@language", DbType.String, info.language);
            _db.AddInParameter(cmd, "@headimgurl", DbType.String, info.headimgurl);
            _db.AddInParameter(cmd, "@subscribe_time", DbType.String, info.subscribe_time);
            _db.AddInParameter(cmd, "@unionid", DbType.String, info.unionid);
            _db.AddInParameter(cmd, "@createtime", DbType.DateTime, info.createtime);
            _db.AddInParameter(cmd, "@latesttime", DbType.DateTime, info.latesttime);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "@LeiXing", DbType.Int32, info.LeiXing);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取微信用户信息，按用户编号
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiXinYongHuInfo GetInfo1(string yongHuId)
        {
            var cmd = _db.GetSqlStringCommand("SELECT * FROM [tbl_WeiXin_YongHu] WHERE [YongHuId]=@YongHuId");
            _db.AddInParameter(cmd, "YongHuId", DbType.AnsiStringFixedLength, yongHuId);

            return ReadYongHuInfo(cmd);
        }

        /// <summary>
        /// 获取微信用户信息，按openid编号
        /// </summary>
        /// <param name="openid">openid</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiXinYongHuInfo GetInfo2(string openid)
        {
            var cmd = _db.GetSqlStringCommand("SELECT * FROM [tbl_WeiXin_YongHu] WHERE [openid]=@openid");
            _db.AddInParameter(cmd, "openid", DbType.AnsiStringFixedLength, openid);

            return ReadYongHuInfo(cmd);
        }
        /// <summary>
        /// 获取微信用户信息，按openid编号
        /// </summary>
        /// <param name="openid">openid</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiXinYongHuInfo GetInfo3(string HuiYuanId)
        {
            var cmd = _db.GetSqlStringCommand("SELECT * FROM [tbl_WeiXin_YongHu] WHERE [HuiYuanId]=@HuiYuanId");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, HuiYuanId);

            return ReadYongHuInfo(cmd);
        }
        /// <summary>
        /// 绑定会员，返回1成功，其它失败
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="openid">openid</param>
        /// <param name="u">用户名</param>
        /// <param name="p">密码</param>
        /// <param name="huiYuanId">out 会员编号</param>
        /// <returns></returns>
        public int BangDingHuiYuan(string yongHuId, string openid, string u, string p, out string huiYuanId)
        {
            huiYuanId = string.Empty;

            var cmd = _db.GetStoredProcCommand("proc_WeiXin_BangDingHuiYuan");
            _db.AddInParameter(cmd, "@YongHuId", DbType.AnsiStringFixedLength, yongHuId);
            _db.AddInParameter(cmd, "@openid", DbType.String, openid);
            _db.AddInParameter(cmd, "@U", DbType.String, u);
            _db.AddInParameter(cmd, "@P", DbType.String, p);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "@HuiYuanId", DbType.String, 36);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            int dbRetCode = Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));

            if (dbRetCode == 1)
            {
                huiYuanId = _db.GetParameterValue(cmd, "HuiYuanId").ToString();
            }

            return dbRetCode;
        }
        #endregion
    }
}
