//会员关系相关信息DAL 汪奇志 2015-02-03
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
    /// 会员关系相关信息DAL
    /// </summary>
    public class DHuiYuanGuanXi : DALBase
    {
        #region static constants
        //static constants

        #endregion

        #region constructor
        private Database _db = null;

        public DHuiYuanGuanXi()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region public members
        /// <summary>
        /// 会员点赞新增、修改、删除，返回1成功，其它失败
        /// </summary>
        /// <param name="FS">C:新增 U:修改 D:删除</param>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int HuiYuanDianZan_CUD(string FS, Eyousoft_yhq.Model.MHuiYuanDianZanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_HuiYuan_DianZan_CUD");
            _db.AddInParameter(cmd, "@IdentityId", DbType.Int32, info.IdentityId);
            _db.AddInParameter(cmd, "@HuiYuanId1", DbType.AnsiStringFixedLength, info.HuiYuanId1);
            _db.AddInParameter(cmd, "@HuiYuanId2", DbType.AnsiStringFixedLength, info.HuiYuanId2);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@FS", DbType.AnsiStringFixedLength, FS);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "@RetCode"));
        }

        /// <summary>
        /// 会员关注新增、修改、删除，返回1成功，其它失败
        /// </summary>
        /// <param name="FS">C:新增 U:修改 D:删除</param>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int HuiYuanGuanZhu_CUD(string FS, Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_HuiYuan_GuanZhu_CUD");
            _db.AddInParameter(cmd, "@IdentityId", DbType.Int32, info.IdentityId);
            _db.AddInParameter(cmd, "@HuiYuanId1", DbType.AnsiStringFixedLength, info.HuiYuanId1);
            _db.AddInParameter(cmd, "@HuiYuanId2", DbType.AnsiStringFixedLength, info.HuiYuanId2);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@FS", DbType.AnsiStringFixedLength, FS);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "@RetCode"));
        }

        /// <summary>
        /// 会员留言新增、修改、删除，返回1成功，其它失败
        /// </summary>
        /// <param name="FS">C:新增 U:修改 D:删除 H:回复</param>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int HuiYuanLiuYan_CUD(string FS, Eyousoft_yhq.Model.MHuiYuanLiuYanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_HuiYuan_LiuYan_CUD");
            _db.AddInParameter(cmd, "@IdentityId", DbType.Int32, info.IdentityId);
            _db.AddInParameter(cmd, "@HuiYuanId1", DbType.AnsiStringFixedLength, info.HuiYuanId1);
            _db.AddInParameter(cmd, "@HuiYuanId2", DbType.AnsiStringFixedLength, info.HuiYuanId2);
            _db.AddInParameter(cmd, "@LiuYanNeiRong", DbType.String, info.LiuYanNeiRong);
            _db.AddInParameter(cmd, "@LiuYanTime", DbType.DateTime, info.LiuYanTime);
            _db.AddInParameter(cmd, "@HuiFuNeiRong", DbType.String, info.HuiFuNeiRong);
            _db.AddInParameter(cmd, "@HuiFuTime", DbType.DateTime, info.HuiFuTime);
            _db.AddInParameter(cmd, "@FS", DbType.AnsiStringFixedLength, FS);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "@RetCode"));
        }

        /// <summary>
        /// 获取会员被点赞信息集合（被动）
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> GetDianZans(string huiYuanId)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanDianZanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_HuiYuan_DianZan WHERE HuiYuanId2=@HuiYuanId ORDER BY IdentityId DESC");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item =new Eyousoft_yhq.Model.MHuiYuanDianZanInfo();

                    item.HuiYuanId1 = rdr["HuiYuanId1"].ToString();
                    item.HuiYuanId2 = rdr["HuiYuanId2"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));

                    item.HuiYuanName1 = rdr["HuiYuanXingMing1"].ToString();
                    item.HuiYuanName2 = rdr["HuiYuanXingMing2"].ToString();
                    item.HuiYuanTuXiangFilepath1 = rdr["HuiYuanTuXiangFilepath1"].ToString();
                    item.HuiYuanTuXiangFilepath2 = rdr["HuiYuanTuXiangFilepath2"].ToString();

                    item.MingPianId1 = rdr["MingPianId1"].ToString();
                    item.MingPianId2 = rdr["MingPianId2"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取会员被关注信息集合（被动）
        /// </summary>
        /// <param name="huiYuanId"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo> GetGuanZhus(string huiYuanId)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_HuiYuan_GuanZhu WHERE HuiYuanId2=@HuiYuanId ORDER BY IdentityId DESC");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo();

                    item.HuiYuanId1 = rdr["HuiYuanId1"].ToString();
                    item.HuiYuanId2 = rdr["HuiYuanId2"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));

                    item.HuiYuanName1 = rdr["HuiYuanXingMing1"].ToString();
                    item.HuiYuanName2 = rdr["HuiYuanXingMing2"].ToString();
                    item.HuiYuanTuXiangFilepath1 = rdr["HuiYuanTuXiangFilepath1"].ToString();
                    item.HuiYuanTuXiangFilepath2 = rdr["HuiYuanTuXiangFilepath2"].ToString();

                    item.MingPianId1 = rdr["MingPianId1"].ToString();
                    item.MingPianId2 = rdr["MingPianId2"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取会员关注信息集合（主动）
        /// </summary>
        /// <param name="huiYuanId"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo> GetGuanZhus1(string huiYuanId)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_HuiYuan_GuanZhu WHERE HuiYuanId1=@HuiYuanId ORDER BY IdentityId DESC");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo();

                    item.HuiYuanId1 = rdr["HuiYuanId1"].ToString();
                    item.HuiYuanId2 = rdr["HuiYuanId2"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));

                    item.HuiYuanName1 = rdr["HuiYuanXingMing1"].ToString();
                    item.HuiYuanName2 = rdr["HuiYuanXingMing2"].ToString();
                    item.HuiYuanTuXiangFilepath1 = rdr["HuiYuanTuXiangFilepath1"].ToString();
                    item.HuiYuanTuXiangFilepath2 = rdr["HuiYuanTuXiangFilepath2"].ToString();

                    item.MingPianId1 = rdr["MingPianId1"].ToString();
                    item.MingPianId2 = rdr["MingPianId2"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取会员被留言信息集合
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanLiuYanInfo> GetLiuYans(string huiYuanId)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanLiuYanInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanLiuYanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_HuiYuan_LiuYan WHERE HuiYuanId2=@HuiYuanId ORDER BY IdentityId DESC");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new Eyousoft_yhq.Model.MHuiYuanLiuYanInfo();

                    item.HuiFuNeiRong = rdr["HuiFuNeiRong"].ToString();
                    item.HuiFuTime = rdr.GetDateTime(rdr.GetOrdinal("HuiFuTime"));
                    item.HuiYuanId1 = rdr["HuiYuanId1"].ToString();
                    item.HuiYuanId2 = rdr["HuiYuanId2"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.LiuYanNeiRong = rdr["LiuYanNeiRong"].ToString();
                    item.LiuYanTime = rdr.GetDateTime(rdr.GetOrdinal("LiuYanTime"));

                    item.HuiYuanName1 = rdr["HuiYuanXingMing1"].ToString();
                    item.HuiYuanName2 = rdr["HuiYuanXingMing2"].ToString();
                    item.HuiYuanTuXiangFilepath1 = rdr["HuiYuanTuXiangFilepath1"].ToString();
                    item.HuiYuanTuXiangFilepath2 = rdr["HuiYuanTuXiangFilepath2"].ToString();

                    item.MingPianId1 = rdr["MingPianId1"].ToString();
                    item.MingPianId2 = rdr["MingPianId2"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取会员最新点赞条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetDianZanNum(string huiYuanId, DateTime times)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanDianZanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT count(IdentityId) FROM view_HuiYuan_DianZan WHERE HuiYuanId2=@HuiYuanId And IssueTime>@Times");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "Times", DbType.DateTime, times);

            var rdr = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(rdr.ToString());
        }

        /// <summary>
        /// 获取会员最新关注条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetGuanZhuNum(string huiYuanId, DateTime times)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanDianZanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT count(IdentityId) FROM view_HuiYuan_GuanZhu WHERE HuiYuanId2=@HuiYuanId And IssueTime>@Times");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "Times", DbType.DateTime, times);

            var rdr = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(rdr.ToString());
        }

        /// <summary>
        /// 获取会员最新留言条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetLiuYanNum(string huiYuanId, DateTime times)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanDianZanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT count(IdentityId) FROM view_HuiYuan_LiuYan WHERE HuiYuanId2=@HuiYuanId And LiuYanTime>@Times");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "Times", DbType.DateTime, times);

            var rdr = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(rdr.ToString());
        }

        #endregion
    }
}
