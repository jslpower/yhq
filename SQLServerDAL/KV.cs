using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:KV
    /// </summary>
    public class DKV : DALBase
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DKV()
        {
            _db = base.SystemStore;
        }
        #endregion

        private const string SqlBcthSetSeting = "if not exists(select 1 from tbl_KV where K = '{0}' ) begin insert into tbl_KV(K,V) values('{0}','{1}') end else begin update tbl_KV set V='{1}' where K = '{0}'  end ;";

        private const string SqlGetValue = "select V from tbl_KV where  and K = @K";

        private const string SqlSetSetting = " delete tbl_KV where  K= @K; insert into tbl_KV(K,V) values(@K,@V);";

        #region IKV 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> 
        public bool SetCompanySetting(Eyousoft_yhq.Model.MCompanySetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(SqlBcthSetSeting, "CompanyIntroduce", model.CompanyIntroduce);
            strSql.AppendFormat(SqlBcthSetSeting, "About", model.About);
            strSql.AppendFormat(SqlBcthSetSeting, "Contact", model.Contact);
            strSql.AppendFormat(SqlBcthSetSeting, "Join", model.Join);
            strSql.AppendFormat(SqlBcthSetSeting, "LegalNotices", model.LegalNotices);
            strSql.AppendFormat(SqlBcthSetSeting, "Copyright", model.Copyright);
            strSql.AppendFormat(SqlBcthSetSeting, "Code", model.Code);
            strSql.AppendFormat(SqlBcthSetSeting, "Description", model.Description);
            strSql.AppendFormat(SqlBcthSetSeting, "Keywords", model.Keywords);
            strSql.AppendFormat(SqlBcthSetSeting, "Title", model.Title);
            strSql.AppendFormat(SqlBcthSetSeting, "Logo", model.Logo);
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            return DbHelper.ExecuteSqlTrans(cmd, this._db) == 0 ? false : true;
        }

        /// <summary>
        /// 获取公司配置信息
        /// </summary>
        public Eyousoft_yhq.Model.MCompanySetting GetCompanySetting()
        {
            var strSql = new StringBuilder();

            strSql.Append(" select * from tbl_KV ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            var model = new Eyousoft_yhq.Model.MCompanySetting();
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(dr.GetOrdinal("K")) && !string.IsNullOrEmpty(dr.GetString(dr.GetOrdinal("K"))))
                    {
                        switch (dr.GetString(dr.GetOrdinal("K")))
                        {
                            case "CompanyIntroduce":
                                model.CompanyIntroduce = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "About":
                                model.About = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Contact":
                                model.Contact = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Join":
                                model.Join = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "LegalNotices":
                                model.LegalNotices = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Copyright":
                                model.Copyright = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Code":
                                model.Code = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Description":
                                model.Description = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Keywords":
                                model.Keywords = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Title":
                                model.Title = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "Logo":
                                model.Logo = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? string.Empty
                                                             : dr.GetString(dr.GetOrdinal("V"));
                                break;
                            case "MsgNumber":
                                model.MsgNumber = dr.IsDBNull(dr.GetOrdinal("V"))
                                                             ? 0
                                                             : Utils.GetInt(dr.GetString(dr.GetOrdinal("V")));
                                break;
                        }
                    }
                }
            }

            return model;
        }


        /// <summary>
        /// 获取公司配置信息
        /// </summary>
        public Eyousoft_yhq.Model.MComLianMeng GetComLianMeng()
        {
            var strSql = new StringBuilder();

            strSql.Append("SELECT SUM(OrderPrice) AS SealMoney,(SELECT COUNT(1) FROM dbo.tbl_Member WHERE IsAgent='1')AS Agent,COUNT(1) AS OorderCount FROM dbo.tbl_Order");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            var model = new Eyousoft_yhq.Model.MComLianMeng();
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    model.Agent = dr.IsDBNull(dr.GetOrdinal("Agent")) ? 0 : dr.GetInt32(dr.GetOrdinal("Agent"));
                    model.OorderCount = dr.IsDBNull(dr.GetOrdinal("OorderCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("OorderCount"));
                    model.SealMoney = dr.IsDBNull(dr.GetOrdinal("SealMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("SealMoney"));

                }
            }

            return model;
        }




        /// <summary>
        /// 获取指定公司的配置信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="fileKey"></param>
        /// <returns></returns>
        public string GetValue(string K)
        {
            string V = string.Empty;
            DbCommand cmd = this._db.GetSqlStringCommand(SqlGetValue);
            this._db.AddInParameter(cmd, "K", DbType.String, K);


            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    V = rdr.IsDBNull(rdr.GetOrdinal("V"))
                                     ? string.Empty
                                     : rdr.GetString(rdr.GetOrdinal("V"));
                }
            }

            return V;
        }

        /// <summary>
        /// 设置指定公司的配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="fieldKey">配置key</param>
        /// <param name="fieldValue">配置value</param>
        /// <returns></returns>
        public bool SetValue(string K, string V)
        {
            DbCommand dc = this._db.GetSqlStringCommand(SqlSetSetting);
            this._db.AddInParameter(dc, "K", DbType.String, K);
            this._db.AddInParameter(dc, "V", DbType.String, V);
            return DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }


        #endregion
    }
}

