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
    public partial class DYouJi : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public DYouJi()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MYouJi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_HuiYouYouJi(");
            strSql.Append("YouJiId,HuiYuanId,YouJiTitle,YouJiContent,IssueTime,YouJiLeiXing,ShiPinLink,WeiXinMa)");
            strSql.Append(" values (");
            strSql.Append("@YouJiId,@HuiYuanId,@YouJiTitle,@YouJiContent,@IssueTime,@YouJiLeiXing,@ShiPinLink,@WeiXinMa)");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YouJiId", System.Data.DbType.String, model.YouJiId);
            this._db.AddInParameter(cmd, "HuiYuanId", System.Data.DbType.String, model.HuiYuanId);
            this._db.AddInParameter(cmd, "YouJiTitle", System.Data.DbType.String, model.YouJiTitle);
            this._db.AddInParameter(cmd, "YouJiContent", System.Data.DbType.String, getJsonStr(model.YouJiContent));
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "YouJiLeiXing", System.Data.DbType.Byte, model.YouJiType);
            this._db.AddInParameter(cmd, "ShiPinLink", System.Data.DbType.String, model.ShiPinLink);
            this._db.AddInParameter(cmd, "WeiXinMa", System.Data.DbType.String, model.WeiXinMa);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string YouJiId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_HuiYouYouJi ");
            strSql.AppendFormat(" where YouJiId='{0}' ", YouJiId);

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MYouJi GetModel(string YouJiId)
        {
            MYouJi model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 YouJiId,HuiYuanId,YouJiTitle,YouJiContent,IssueTime,ShiPinLink,WeiXinMa from tbl_HuiYouYouJi ");
            strSql.Append(" where YouJiId=@YouJiId ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YouJiId", System.Data.DbType.AnsiStringFixedLength, YouJiId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MYouJi();
                    model.YouJiId = dr.IsDBNull(dr.GetOrdinal("YouJiId")) ? "" : dr.GetString(dr.GetOrdinal("YouJiId"));
                    model.YouJiTitle = dr.IsDBNull(dr.GetOrdinal("YouJiTitle")) ? "" : dr.GetString(dr.GetOrdinal("YouJiTitle"));
                    model.YouJiContent = dr.IsDBNull(dr.GetOrdinal("YouJiContent")) ? null : getStrJson(dr.GetString(dr.GetOrdinal("YouJiContent")));
                    model.HuiYuanId = dr.IsDBNull(dr.GetOrdinal("HuiYuanId")) ? "" : dr.GetString(dr.GetOrdinal("HuiYuanId"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ShiPinLink = dr.IsDBNull(dr.GetOrdinal("ShiPinLink")) ? "" : dr.GetString(dr.GetOrdinal("ShiPinLink"));
                    model.WeiXinMa = dr.IsDBNull(dr.GetOrdinal("WeiXinMa")) ? "" : dr.GetString(dr.GetOrdinal("WeiXinMa"));
                }
            }

            return model;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<MYouJi> GetList(int PageSize, int PageIndex, ref int RecordCount, MYouJiSer serModel)
        {
            IList<MYouJi> list = new List<MYouJi>();


            string tableName = "tbl_HuiYouYouJi";
            string fileds = " * ";
            string orderByString = " IssueTime DESC ";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.HuiYuanId))
                {
                    query.AppendFormat(" AND HuiYuanId='{0}' ", serModel.HuiYuanId);
                }
                if (serModel.YouJiType.HasValue)
                {
                    query.AppendFormat(" AND YouJiLeiXing='{0}' ", (int)serModel.YouJiType.Value);
                }

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MYouJi model = new MYouJi();
                    model.YouJiId = dr.IsDBNull(dr.GetOrdinal("YouJiId")) ? "" : dr.GetString(dr.GetOrdinal("YouJiId"));
                    model.YouJiTitle = dr.IsDBNull(dr.GetOrdinal("YouJiTitle")) ? "" : dr.GetString(dr.GetOrdinal("YouJiTitle"));
                    model.YouJiContent = dr.IsDBNull(dr.GetOrdinal("YouJiContent")) ? null : getStrJson(dr.GetString(dr.GetOrdinal("YouJiContent")));
                    model.HuiYuanId = dr.IsDBNull(dr.GetOrdinal("HuiYuanId")) ? "" : dr.GetString(dr.GetOrdinal("HuiYuanId"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ShiPinLink = dr.IsDBNull(dr.GetOrdinal("ShiPinLink")) ? "" : dr.GetString(dr.GetOrdinal("ShiPinLink"));
                    model.WeiXinMa = dr.IsDBNull(dr.GetOrdinal("WeiXinMa")) ? "" : dr.GetString(dr.GetOrdinal("WeiXinMa"));
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取会员游记条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetYouJiNum(string huiYuanId)
        {
            IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> items = new List<Eyousoft_yhq.Model.MHuiYuanDianZanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT count(YouJiId) FROM tbl_HuiYouYouJi WHERE HuiYuanId=@HuiYuanId ");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            var rdr = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(rdr.ToString());
        }

        /// <summary>
        /// 序列化返回string类型
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string getJsonStr(IList<Eyousoft_yhq.Model.XingCheng> list)
        {

            if (list == null || list.Count == 0) return string.Empty;
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        }
        /// <summary>
        /// 反序列化返回list
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static IList<Eyousoft_yhq.Model.XingCheng> getStrJson(string jsonStr)
        {

            if (string.IsNullOrEmpty(jsonStr)) return null;

            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IList<Eyousoft_yhq.Model.XingCheng>>(jsonStr);

        }
        /// <summary>
        /// 修改游记内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateModel(MYouJi model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tbl_HuiYouYouJi SET  YouJiTitle = @YouJiTitle , YouJiContent = @YouJiContent ,ShiPinLink=@ShiPinLink,WeiXinMa=@WeiXinMa  WHERE YouJiId=@YouJiId");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "YouJiId", System.Data.DbType.String, model.YouJiId);
            this._db.AddInParameter(cmd, "YouJiTitle", System.Data.DbType.String, model.YouJiTitle);
            this._db.AddInParameter(cmd, "YouJiContent", System.Data.DbType.String, getJsonStr(model.YouJiContent));
            this._db.AddInParameter(cmd, "ShiPinLink", System.Data.DbType.String, model.ShiPinLink);
            this._db.AddInParameter(cmd, "WeiXinMa", System.Data.DbType.String, model.WeiXinMa);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

    }
}
