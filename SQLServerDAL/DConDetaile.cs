using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Xml.Linq;
using Eyousoft_yhq.Model;
using System.Data.Common;
using System.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DConDetaile : DALBase
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DConDetaile()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MConDetaile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_ConDetailed( HuiYuanID, JiaoYiHao ,JinE ,JiaoYiShiJian, XiaoFeiFangShi ,DingDanBianHao ,JiaoYiDuiXiang, DingDanLeiBie) VALUES ( @HuiYuanID, @JiaoYiHao,@JinE,@JiaoYiShiJian, @XiaoFeiFangShi,@DingDanBianHao,@JiaoYiDuiXiang,@DingDanLeiBie)");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            this._db.AddInParameter(cmd, "HuiYuanID", DbType.AnsiStringFixedLength, model.HuiYuanID);
            this._db.AddInParameter(cmd, "JiaoYiHao", DbType.String, model.JiaoYiHao);
            this._db.AddInParameter(cmd, "JinE", DbType.Decimal, model.JinE);
            this._db.AddInParameter(cmd, "JiaoYiShiJian", DbType.DateTime, model.JiaoYiShiJian);
            this._db.AddInParameter(cmd, "XiaoFeiFangShi", DbType.Byte, model.XFway);
            this._db.AddInParameter(cmd, "DingDanBianHao", DbType.String, model.DingDanBianHao);
            this._db.AddInParameter(cmd, "JiaoYiDuiXiang", DbType.String, model.JiaoYiDuiXiang);
            this._db.AddInParameter(cmd, "DingDanLeiBie", DbType.Byte, model.DDCarrtes);
            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MConDetaile> GetModelList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MConDetaile serModel)
        {
            IList<Eyousoft_yhq.Model.MConDetaile> list = new List<Eyousoft_yhq.Model.MConDetaile>();


            string tableName = "tbl_ConDetailed";
            string fileds = " ID,HuiYuanID,(select UserName from tbl_Member where UserId=tbl_ConDetailed.HuiYuanID ) as HuiYuanName, JiaoYiHao ,JinE ,JiaoYiShiJian, XiaoFeiFangShi ,DingDanBianHao ,JiaoYiDuiXiang,(select UserName from tbl_Member where UserId=tbl_ConDetailed.JiaoYiDuiXiang ) as DXName, DingDanLeiBie ";
            string orderByString = "JiaoYiShiJian desc ";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");

            if (serModel != null)
            {

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MConDetaile model = new Eyousoft_yhq.Model.MConDetaile();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.HuiYuanID = dr.GetString(dr.GetOrdinal("HuiYuanID"));
                    model.HuiYuanName = dr.GetString(dr.GetOrdinal("HuiYuanName"));

                    model.JiaoYiHao = dr.GetString(dr.GetOrdinal("JiaoYiHao"));
                    model.JinE = dr.GetDecimal(dr.GetOrdinal("JinE"));
                    model.JiaoYiShiJian = dr.GetDateTime(dr.GetOrdinal("JiaoYiShiJian"));
                    model.XFway = (Eyousoft_yhq.Model.XFfangshi)dr.GetByte(dr.GetOrdinal("XiaoFeiFangShi"));

                    model.DingDanBianHao = dr.GetString(dr.GetOrdinal("DingDanBianHao"));
                    model.DuiXiangName = dr.IsDBNull(dr.GetOrdinal("DXName")) ? "" : dr.GetString(dr.GetOrdinal("DXName"));
                    model.DDCarrtes = (Eyousoft_yhq.Model.DDleibie)dr.GetByte(dr.GetOrdinal("DingDanLeiBie"));

                    list.Add(model);
                }
            }
            return list;
        }


        /// <summary>
        /// 获取所有帐户的充值和消费金额
        /// </summary>

        /// <returns></returns>
    public int GetTotalMoney(TotalMoney Tmoney)
        {
            StringBuilder strSql = new StringBuilder();
            if (Tmoney == TotalMoney.账户充值金额)
            {
                strSql.Append("select sum(YuE) from tbl_Member");
            }
            else
            {
                strSql.Append("select sum(JinE) from tbl_ConDetailed where XiaoFeiFangShi <> 0");
            }

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
          

            return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db));
        }

    }
}
