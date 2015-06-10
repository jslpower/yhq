using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eyousoft_yhq.Model;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Eyousoft_yhq.SQLServerDAL
{
    public class DZengZhi : DALBase
    {
        #region 初始化db
        private Database _db = null;

        public DZengZhi()
        {
            _db = base.SystemStore;
        }
        #endregion

        public int Insert(MZengZhi info)
        {
            return 0;
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<MZengZhi> GetList(int PageSize, int PageIndex, ref int RecordCount, MZengZhiSer serModel)
        {
            IList<MZengZhi> list = new List<MZengZhi>();


            string tableName = "view_ZengZhi";
            string fileds = "  *    ";
            string orderByString = "FenXiangShiJian desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" 1=1 ");

            if (serModel != null)
            {

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MZengZhi model = new MZengZhi();
                    model.FenXiangID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ID"));
                    model.FenXiangRenID = dr.GetString(dr.GetOrdinal("ID"));
                    model.FenXiangShiJian = dr.GetDateTime(dr.GetOrdinal("ID"));
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.UserName = dr.GetString(dr.GetOrdinal("ID"));
                    model.ZengZhi = dr.GetDecimal(dr.GetOrdinal("ID"));

                    list.Add(model);
                }
            }
            return list;
        }
    }
}
