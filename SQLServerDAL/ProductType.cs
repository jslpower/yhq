using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:ProductType
    /// </summary>
    public partial class ProductType : DALBase
    {

        private Database _db = null;
        public ProductType()
        {
            _db = base.SystemStore;
        }


        #region IProductType 成员
        /// <summary>
        /// 是否存在相同名称的类型
        /// </summary>
        /// <param name="TypeName">类型名称</param>
        /// <returns></returns>
        public bool Exists(string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbl_ProductType");
            strSql.Append(" where TypeName=@TypeName ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TypeName", System.Data.DbType.String, TypeName);

            return DbHelper.Exists(cmd, this._db);
        }

        public bool Add(Eyousoft_yhq.Model.ProductType model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("  INSERT INTO  tbl_ProductType ( TypeName , ProductID , TypeImg , TpMark,AdminName,OrderByInt,WebImg,XianLu)  		");
            strSql.Append(" VALUES ");
            strSql.Append(" (@TypeName , @ProductID , @TypeImg,@TpMark,@AdminName,@OrderByInt,@WebImg,@XianLu) ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TypeName", System.Data.DbType.AnsiStringFixedLength, model.TypeName);
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.String, model.ProductID);
            this._db.AddInParameter(cmd, "TypeImg", System.Data.DbType.String, model.TypeImg);
            this._db.AddInParameter(cmd, "TpMark", System.Data.DbType.Byte, model.TpMark);
            this._db.AddInParameter(cmd, "AdminName", System.Data.DbType.String, getJsonStr(model.AdminName));
            this._db.AddInParameter(cmd, "OrderByInt", System.Data.DbType.Int32, model.OrderBy);
            this._db.AddInParameter(cmd, "WebImg", System.Data.DbType.String, model.WebImg);
            this._db.AddInParameter(cmd, "XianLu", System.Data.DbType.Byte, (int)model.xianlu);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 实体修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Eyousoft_yhq.Model.ProductType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" UPDATE tbl_ProductType SET TypeName = @TypeName,ProductID = @ProductID,TypeImg = @TypeImg ,AdminName=@AdminName,OrderByInt=@OrderByInt,WebImg=@WebImg,XianLu=@XianLu");
            strSql.Append(" WHERE ");
            strSql.Append(" TypeID = @TypeID 	");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TypeName", System.Data.DbType.AnsiStringFixedLength, model.TypeName);
            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.String, model.ProductID);
            this._db.AddInParameter(cmd, "TypeImg", System.Data.DbType.String, model.TypeImg);
            this._db.AddInParameter(cmd, "AdminName", System.Data.DbType.String, getJsonStr(model.AdminName));
            this._db.AddInParameter(cmd, "TypeID", System.Data.DbType.Int32, model.TypeID);
            this._db.AddInParameter(cmd, "OrderByInt", System.Data.DbType.Int32, model.OrderBy);
            this._db.AddInParameter(cmd, "WebImg", System.Data.DbType.String, model.WebImg);
            this._db.AddInParameter(cmd, "XianLu", System.Data.DbType.Byte, (int)model.xianlu);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="TypeID">产品类型编号</param>
        /// <returns></returns>
        public bool Delete(int[] TypeID)
        {

            StringBuilder Sql = new StringBuilder();
            Sql.AppendFormat("SELECT COUNT(1) FROM dbo.tbl_Product WHERE ProductType IN({0})", Utils.GetSqlIdStrByArray(TypeID));

            DbCommand EXcmd = this._db.GetSqlStringCommand(Sql.ToString());

            bool result = DbHelper.Exists(EXcmd, this._db);

            if (result) return false;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  DELETE FROM  tbl_ProductType   WHERE  TypeID in ({0})  ", Utils.GetSqlIdStrByArray(TypeID));

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }



        public Eyousoft_yhq.Model.ProductType GetModel(int TypeID)
        {

            Eyousoft_yhq.Model.ProductType model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT    TypeName , ProductID , TypeImg  ,TpMark,AdminName,OrderByInt,WebImg,XianLu");
            strSql.Append("  FROM tbl_ProductType ");
            strSql.Append(" where TypeID=@TypeID   ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TypeID", System.Data.DbType.AnsiStringFixedLength, TypeID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.ProductType();
                    model.TypeID = TypeID;
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.TypeName = dr.IsDBNull(dr.GetOrdinal("TypeName")) ? "" : dr.GetString(dr.GetOrdinal("TypeName"));
                    model.TypeImg = dr.IsDBNull(dr.GetOrdinal("TypeImg")) ? "" : dr.GetString(dr.GetOrdinal("TypeImg"));
                    model.TpMark = dr.IsDBNull(dr.GetOrdinal("TpMark")) ? "" : dr.GetByte(dr.GetOrdinal("TpMark")).ToString();
                    model.AdminName = dr.IsDBNull(dr.GetOrdinal("AdminName")) ? null : getStrJson(dr.GetString(dr.GetOrdinal("AdminName")));
                    model.OrderBy = dr.IsDBNull(dr.GetOrdinal("OrderByInt")) ? 0 : dr.GetInt32(dr.GetOrdinal("OrderByInt"));
                    model.WebImg = dr.IsDBNull(dr.GetOrdinal("WebImg")) ? "" : dr.GetString(dr.GetOrdinal("WebImg"));
                    model.xianlu = (Eyousoft_yhq.Model.XianLu)dr.GetByte(dr.GetOrdinal("XianLu"));



                }
            }

            return model;

        }

        public IList<Eyousoft_yhq.Model.ProductType> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.serProductType serModel, string i)
        {
            IList<Eyousoft_yhq.Model.ProductType> list = new List<Eyousoft_yhq.Model.ProductType>();


            string tableName = "tbl_ProductType";
            string fileds = " TypeID, TypeName , ProductID , TypeImg,TpMark,AdminName ,OrderByInt ,WebImg,XianLu";
            string orderByString = "OrderByInt desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1  ");

            switch (i)
            {
                case "1":
                    query.Append(" and TpMark ='1'  ");
                    break;
                case "0":
                    query.Append(" and TpMark ='0'  ");
                    break;
                default:
                    break;
            }

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.TypeName) && !serModel.IsAdmin)
                {
                    query.AppendFormat(" and TypeName like '%{0}%' ", serModel.TypeName);
                }
                if (!string.IsNullOrEmpty(serModel.AdminID) && !serModel.IsAdmin)
                {
                    query.AppendFormat("  and  charindex('{0}',[AdminName])>0  ", serModel.AdminID);
                }
                if (serModel.IsAdmin && !string.IsNullOrEmpty(serModel.TypeName))
                {
                    query.AppendFormat(" and TypeName like '%{0}%' ", serModel.TypeName);
                }
                if (serModel.xianlu.HasValue)
                {
                    query.AppendFormat(" and XianLu = '{0}' ", (int)serModel.xianlu.Value);
                }
            }




            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    Eyousoft_yhq.Model.ProductType model = new Eyousoft_yhq.Model.ProductType();
                    model.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.TypeName = dr.IsDBNull(dr.GetOrdinal("TypeName")) ? "" : dr.GetString(dr.GetOrdinal("TypeName"));
                    model.TypeImg = dr.IsDBNull(dr.GetOrdinal("TypeImg")) ? "" : dr.GetString(dr.GetOrdinal("TypeImg"));
                    model.TpMark = dr.IsDBNull(dr.GetOrdinal("TpMark")) ? "" : dr.GetByte(dr.GetOrdinal("TpMark")).ToString();
                    model.AdminName = dr.IsDBNull(dr.GetOrdinal("AdminName")) ? null : getStrJson(dr.GetString(dr.GetOrdinal("AdminName")));
                    model.OrderBy = dr.IsDBNull(dr.GetOrdinal("OrderByInt")) ? 0 : dr.GetInt32(dr.GetOrdinal("OrderByInt"));
                    model.WebImg = dr.IsDBNull(dr.GetOrdinal("WebImg")) ? "" : dr.GetString(dr.GetOrdinal("WebImg"));
                    model.xianlu = (Eyousoft_yhq.Model.XianLu)dr.GetByte(dr.GetOrdinal("XianLu"));

                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取类型列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.ProductType> GetList(Eyousoft_yhq.Model.serProductType serModel)
        {
            IList<Eyousoft_yhq.Model.ProductType> list = new List<Eyousoft_yhq.Model.ProductType>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TypeID, TypeName , ProductID , TypeImg,TpMark ,AdminName,OrderByInt,WebImg,XianLu");
            strSql.Append("  from tbl_ProductType where 1=1");
            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.TypeName) && !serModel.IsAdmin)
                {
                    strSql.AppendFormat(" and TypeName like '%{0}%' ", serModel.TypeName);
                }
                if (!string.IsNullOrEmpty(serModel.AdminID) && !serModel.IsAdmin)
                {
                    strSql.AppendFormat("  and  charindex('{0}',[AdminName])>0  ", serModel.AdminID);
                }
                if (serModel.IsAdmin && !string.IsNullOrEmpty(serModel.TypeName))
                {
                    strSql.AppendFormat(" and TypeName like '%{0}%' ", serModel.TypeName);
                }
            }
            strSql.Append("  order by OrderByInt  DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.ProductType model = new Eyousoft_yhq.Model.ProductType();
                    model.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    model.ProductID = dr.IsDBNull(dr.GetOrdinal("ProductID")) ? "" : dr.GetString(dr.GetOrdinal("ProductID"));
                    model.TypeName = dr.IsDBNull(dr.GetOrdinal("TypeName")) ? "" : dr.GetString(dr.GetOrdinal("TypeName"));
                    model.TypeImg = dr.IsDBNull(dr.GetOrdinal("TypeImg")) ? "" : dr.GetString(dr.GetOrdinal("TypeImg"));
                    model.TpMark = dr.IsDBNull(dr.GetOrdinal("TpMark")) ? "" : dr.GetByte(dr.GetOrdinal("TpMark")).ToString();
                    model.AdminName = dr.IsDBNull(dr.GetOrdinal("AdminName")) ? null : getStrJson(dr.GetString(dr.GetOrdinal("AdminName")));
                    model.OrderBy = dr.IsDBNull(dr.GetOrdinal("OrderByInt")) ? 0 : dr.GetInt32(dr.GetOrdinal("OrderByInt"));
                    model.WebImg = dr.IsDBNull(dr.GetOrdinal("WebImg")) ? "" : dr.GetString(dr.GetOrdinal("WebImg"));
                    model.xianlu = (Eyousoft_yhq.Model.XianLu)dr.GetByte(dr.GetOrdinal("XianLu"));
                    list.Add(model);
                }
            }
            return list;

        }

        /// <summary>
        /// 序列化返回string类型
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string getJsonStr(IList<Eyousoft_yhq.Model.AdminNameList> list)
        {

            if (list == null || list.Count == 0) return string.Empty;
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        }
        /// <summary>
        /// 反序列化返回list
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static IList<Eyousoft_yhq.Model.AdminNameList> getStrJson(string jsonStr)
        {

            if (string.IsNullOrEmpty(jsonStr)) return null;

            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IList<Eyousoft_yhq.Model.AdminNameList>>(jsonStr);

        }

        #endregion
    }
}

