//微店相关DAL 汪奇志 2014-01-14
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
    /// 微店相关DAL
    /// </summary>
    public class DWeiDian : DALBase
    {
         #region static constants
        //static constants

        #endregion

        #region constructor
        private Database _db = null;

        public DWeiDian()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region public members
        /// <summary>
        /// 获取微店编号，按会员编号
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public string GetWeiDianId(string huiYuanId)
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

        /// <summary>
        /// 微店新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int WeiDian_CU(Eyousoft_yhq.Model.MWeiDianInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_WeiDian_CU");
            _db.AddInParameter(cmd, "@WeiDianId", DbType.AnsiStringFixedLength, info.WeiDianId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, info.HuiYuanId);
            _db.AddInParameter(cmd, "@MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "@Status", DbType.Int32, info.Status);
            _db.AddInParameter(cmd, "@ShenQingTime", DbType.DateTime, info.ShenQingTime);
            _db.AddInParameter(cmd, "@ShenHeTime", DbType.DateTime, info.ShenHeTime);
            _db.AddInParameter(cmd, "@JieShao", DbType.String, info.JieShao);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "@LogoFilepath", DbType.String, info.LogoFilepath);
            _db.AddInParameter(cmd, "@DianHua", DbType.String, info.DianHua);

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
        /// 获取微店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiDianInfo GetInfo(string weiDianId)
        {
            Eyousoft_yhq.Model.MWeiDianInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_WeiDian WHERE WeiDianId=@WeiDianId");
            _db.AddInParameter(cmd, "WeiDianId", DbType.AnsiStringFixedLength, weiDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new Eyousoft_yhq.Model.MWeiDianInfo();

                    info.HuiYuanId = rdr["HuiYuanId"].ToString();
                    info.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ShenHeTime"));
                    info.ShenQingTime = rdr.GetDateTime(rdr.GetOrdinal("ShenQingTime"));
                    info.Status = (Eyousoft_yhq.Model.WeiDianStatus)rdr.GetInt32(rdr.GetOrdinal("Status"));
                    info.WeiDianId = rdr["WeiDianId"].ToString();
                    info.HuiYuanName = rdr["HuiYuanName"].ToString();
                    info.YongHuMing = rdr["YongHuMing"].ToString();
                    info.LogoFilepath = rdr["LogoFilepath"].ToString();
                    info.DianHua = rdr["DianHua"].ToString();

                }
            }

            return info;
        }

        /// <summary>
        /// 获取微店信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianInfo> GetWeiDians(int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MWeiDianChaXunInfo chaXun)
        {
            IList<Eyousoft_yhq.Model.MWeiDianInfo> items = new List<Eyousoft_yhq.Model.MWeiDianInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_WeiDian";
            string orderByString = " ShenQingTime DESC ";
            string sumString = "";

            #region chaxun
            sql.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.HuiYuanName))
                {
                    sql.AppendFormat(" AND HuiYuanName LIKE '%{0}%' ", chaXun.HuiYuanName);
                }
                if (!string.IsNullOrEmpty(chaXun.MingCheng))
                {
                    sql.AppendFormat(" AND MingCheng LIKE '%{0}%' ", chaXun.MingCheng);
                }
                if (chaXun.Status.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.Status);
                }
                if (!string.IsNullOrEmpty(chaXun.YongHuMing))
                {
                    sql.AppendFormat(" AND YongHuMing LIKE '%{0}%' ", chaXun.YongHuMing);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MWeiDianInfo();
                    item.HuiYuanId = rdr["HuiYuanId"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.JieShao = rdr["JieShao"].ToString();
                    item.MingCheng = rdr["MingCheng"].ToString();
                    item.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ShenHeTime"));
                    item.ShenQingTime = rdr.GetDateTime(rdr.GetOrdinal("ShenQingTime"));
                    item.Status = (Eyousoft_yhq.Model.WeiDianStatus)rdr.GetInt32(rdr.GetOrdinal("Status"));
                    item.WeiDianId = rdr["WeiDianId"].ToString();
                    item.HuiYuanName = rdr["HuiYuanName"].ToString();
                    item.YongHuMing = rdr["YongHuMing"].ToString();
                    item.LogoFilepath = rdr["LogoFilepath"].ToString();
                    item.DianHua = rdr["DianHua"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 微店产品关系新增、删除，返回1成功，其它失败。
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="guanXiId">关系编号</param>
        /// <param name="chanPinId">产品编号</param>
        /// <param name="fs">操作方式 C:新增 D:删除</param>
        /// <param name="caoZuoTime">操作时间</param>
        /// <returns></returns>
        public int WeiDianChanPinGuanXi_CD(string weiDianId, string huiYuanId,int guanXiId, string chanPinId, string fs, DateTime caoZuoTime)
        {
            var cmd = _db.GetStoredProcCommand("proc_WeiDian_ChanPinGuanXi_CD");

            _db.AddInParameter(cmd, "@WeiDianId", DbType.AnsiStringFixedLength, weiDianId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "@GuanXiId", DbType.Int32, guanXiId);
            _db.AddInParameter(cmd, "@ChanPinId", DbType.AnsiStringFixedLength, chanPinId);
            _db.AddInParameter(cmd, "@CaoZuoTime", DbType.DateTime, caoZuoTime);
            _db.AddInParameter(cmd, "@FS", DbType.AnsiStringFixedLength, fs);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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
        /// 获取微店产品信息集合
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianChanPinInfo> GetWeiDianChanPins(string weiDianId,Eyousoft_yhq.Model.MWeiDianChanPinChaXunInfo chaXun)
        {
            IList<Eyousoft_yhq.Model.MWeiDianChanPinInfo> items = new List<Eyousoft_yhq.Model.MWeiDianChanPinInfo>();
            var sql = new StringBuilder();
            sql.AppendFormat("SELECT * FROM view_WeiDian_ChanPin WHERE [WeiDianId]='{0}' ", weiDianId);

            if (chaXun != null)
            {
                if (chaXun.ChanPinLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND ChanPinLeiXing={0} ", chaXun.ChanPinLeiXing.Value);
                }

                if (!string.IsNullOrEmpty(chaXun.ChanPinName))
                {
                    sql.AppendFormat(" AND ChanPinName LIKE '%{0}%' ", chaXun.ChanPinName);
                }
            }

            sql.AppendFormat(" ORDER BY IssueTime DESC ");

            var cmd = _db.GetSqlStringCommand(sql.ToString());

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MWeiDianChanPinInfo();
                    item.ChanPinId = rdr["ChanPinId"].ToString();
                    item.ChanPinName = rdr["ChanPinName"].ToString();
                    item.ChanPinTuPianFilepath = rdr["ChanPinTuPianFilepath"].ToString();
                    item.GuanXiId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.HuiYuanId = rdr["HuiYuanId"].ToString();
                    item.TianJiaTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.WeiDianId = rdr["WeiDianId"].ToString();

                    item.ShiChangJiaGe = rdr.GetDecimal(rdr.GetOrdinal("ShiChangJiaGe"));
                    item.JieSuanJiaGe = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChuTuanRiQi"))) item.ChuTuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuTuanRiQi"));
                    item.IsTianTianFaTuan = rdr["IsTianTianFaTuan"].ToString() == "1";
                    item.PingLunJiShu = rdr.GetInt32(rdr.GetOrdinal("PingLunJiShu"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取微店产品信息集合
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianChanPinInfo> GetWeiDianChanPins(string weiDianId, int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MWeiDianChanPinChaXunInfo chaXun)
        {
            IList<Eyousoft_yhq.Model.MWeiDianChanPinInfo> items = new List<Eyousoft_yhq.Model.MWeiDianChanPinInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_WeiDian_ChanPin";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            #region chaxun
            sql.Append(" 1=1 ");
            sql.AppendFormat(" AND WeiDianId='{0}' ", weiDianId);

            if (chaXun != null)
            {
                if (chaXun.ChanPinLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND ChanPinLeiXing={0} ", chaXun.ChanPinLeiXing.Value);
                }

                if (!string.IsNullOrEmpty(chaXun.ChanPinName))
                {
                    sql.AppendFormat(" AND ChanPinName LIKE '%{0}%' ", chaXun.ChanPinName);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MWeiDianChanPinInfo();
                    item.ChanPinId = rdr["ChanPinId"].ToString();
                    item.ChanPinName = rdr["ChanPinName"].ToString();
                    item.ChanPinTuPianFilepath = rdr["ChanPinTuPianFilepath"].ToString();
                    item.GuanXiId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.HuiYuanId = rdr["HuiYuanId"].ToString();
                    item.TianJiaTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.WeiDianId = rdr["WeiDianId"].ToString();

                    item.ShiChangJiaGe = rdr.GetDecimal(rdr.GetOrdinal("ShiChangJiaGe"));
                    item.JieSuanJiaGe = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChuTuanRiQi"))) item.ChuTuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuTuanRiQi"));
                    item.IsTianTianFaTuan = rdr["IsTianTianFaTuan"].ToString() == "1";
                    item.PingLunJiShu = rdr.GetInt32(rdr.GetOrdinal("PingLunJiShu"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 判断微店是否添加指定产品
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="chanPinId">产品编号</param>
        /// <returns></returns>
        public bool ShiFouTianJiaChanPin(string weiDianId, string chanPinId)
        {
            var cmd = _db.GetSqlStringCommand("SELECT COUNT(*) FROM tbl_WeiDianChanPinGuanXi WHERE WeiDianId=@WeiDianId AND ChanPinId=@ChanPinId");
            _db.AddInParameter(cmd, "WeiDianId", DbType.AnsiStringFixedLength, weiDianId);
            _db.AddInParameter(cmd, "ChanPinId", DbType.AnsiStringFixedLength, chanPinId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0) > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取微店订单信息集合
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianDingDanInfo> GetWeiDianDingDans(string weiDianId, int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MWeiDianDingDanChaXunInfo chaXun)
        {
            IList<Eyousoft_yhq.Model.MWeiDianDingDanInfo> items = new List<Eyousoft_yhq.Model.MWeiDianDingDanInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_WeiDian_DingDan";
            string orderByString = " XiaDanTime DESC ";
            string sumString = "";

            #region chaxun
            sql.Append(" 1=1 ");
            sql.AppendFormat(" AND WeiDianId='{0}' ", weiDianId);

            if (chaXun != null)
            {
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MWeiDianDingDanInfo();

                    item.ChanPinId = rdr["ChanPinId"].ToString();
                    item.ChanPinName = rdr["ChanPinName"].ToString();
                    item.ChanPinTuPianFilepath = rdr["ChanPinTuPianFilepath"].ToString();
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanStatus = (Eyousoft_yhq.Model.OrderState)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.ShenHeStatus = rdr["ShenHeStatus"].ToString();
                    item.WeiDianId = rdr["WeiDianId"].ToString();
                    item.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    item.XiaDanTime = rdr.GetDateTime(rdr.GetOrdinal("XiaDanTime"));
                    item.ZhiFuStatus = (Eyousoft_yhq.Model.PaymentState)rdr.GetByte(rdr.GetOrdinal("ZhiFuStatus"));
                    item.XiaoFeiStatus = (Eyousoft_yhq.Model.ConSumState)rdr.GetByte(rdr.GetOrdinal("XiaoFeiStatus"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion
    }
}
