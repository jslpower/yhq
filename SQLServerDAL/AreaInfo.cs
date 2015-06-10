using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;
using System.Linq;

namespace Eyousoft_yhq.SQLServerDAL
{
    /// <summary>
    /// 区域省份城市区县
    /// </summary>
    public class DSysAreaInfo : DALBase
    {

        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DSysAreaInfo()
        {
            _db = SystemStore;
        }
        #endregion

        #region AreaInfo 成员

        #region  国家

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysCountry(Eyousoft_yhq.Model.MSysCountry model)
        {
            string StrSql = " select count(1) from tbl_SysCountry WHERE 1=1 ";
            if (model.Id > 0)
            {
                StrSql += " AND Id<>@Id ";
            }
            if (!string.IsNullOrEmpty(model.EnName))
            {
                StrSql += " AND EnName=@EnName ";
            }
            if (!string.IsNullOrEmpty(model.CnName))
            {
                StrSql += " AND CnName=@CnName ";
            }
            if (model.Zones > 0)
            {
                StrSql += " AND Zones = @Zones ";
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            if (model.Id > 0)
            {
                this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            }
            if (!string.IsNullOrEmpty(model.EnName))
            {
                this._db.AddInParameter(dc, "EnName", DbType.String, model.EnName);
            }
            if (!string.IsNullOrEmpty(model.CnName))
            {
                this._db.AddInParameter(dc, "CnName", DbType.String, model.CnName);
            }
            if (model.Zones > 0)
            {
                this._db.AddInParameter(dc, "Zones", DbType.Int32, model.Zones);
            }
            return DbHelper.Exists(dc, _db);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysCountry(Eyousoft_yhq.Model.MSysCountry model)
        {
            string StrSql = "INSERT INTO tbl_SysCountry(EnName,Zones,CnName) VALUES(@EnName,@Zones,@CnName)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "EnName", DbType.String, model.EnName);
            this._db.AddInParameter(dc, "CnName", DbType.String, model.CnName);
            this._db.AddInParameter(dc, "Zones", DbType.Int32, model.Zones);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysCountry(Eyousoft_yhq.Model.MSysCountry model)
        {
            string StrSql = "UPDATE tbl_SysCountry SET EnName = @EnName,Zones = @Zones,CnName = @CnName WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "EnName", DbType.String, model.EnName);
            this._db.AddInParameter(dc, "CnName", DbType.String, model.CnName);
            this._db.AddInParameter(dc, "Zones", DbType.Int32, model.Zones);
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysCountry(int ID)
        {
            string StrSql = "DELETE FROM tbl_SysCountry WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysCountry GetSysCountryModel(int ID)
        {
            Eyousoft_yhq.Model.MSysCountry model = null;
            string StrSql = "SELECT Id, EnName,Zones,CnName FROM tbl_SysCountry WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MSysCountry()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        EnName = dr.IsDBNull(dr.GetOrdinal("EnName")) ? "" : dr.GetString(dr.GetOrdinal("EnName")),
                        Zones = dr.GetInt32(dr.GetOrdinal("Zones")),
                        CnName = dr.IsDBNull(dr.GetOrdinal("CnName")) ? "" : dr.GetString(dr.GetOrdinal("CnName"))
                    };
                }
            };
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysCountry> GetSysCountryList(int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MSysCountry chaXun)
        {
            IList<Eyousoft_yhq.Model.MSysCountry> ResultList = null;
            string tableName = "tbl_SysCountry";
            string identityColumnName = "Id";
            string fields = "Id, EnName,Zones,CnName";
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (chaXun.Zones > 0)
                {
                    query = query + string.Format(" AND Zones={0} ", chaXun.Zones);
                }
                if (!string.IsNullOrEmpty(chaXun.EnName))
                {
                    query = query + string.Format(" AND EnName like '%{0}%'", chaXun.EnName);
                }
                if (!string.IsNullOrEmpty(chaXun.CnName))
                {
                    query = query + string.Format(" AND CnName like '%{0}%'", chaXun.CnName);
                }
            }
            string orderByString = " ID ASC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, identityColumnName, fields, query, orderByString))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysCountry>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysCountry model = new Eyousoft_yhq.Model.MSysCountry()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        EnName = dr.IsDBNull(dr.GetOrdinal("EnName")) ? "" : dr.GetString(dr.GetOrdinal("EnName")),
                        Zones = dr.GetInt32(dr.GetOrdinal("Zones")),
                        CnName = dr.IsDBNull(dr.GetOrdinal("CnName")) ? "" : dr.GetString(dr.GetOrdinal("CnName"))
                    };
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysCountry> GetSysCountryList(int Top, Eyousoft_yhq.Model.MSysCountry chaXun, string filedOrder)
        {
            IList<Eyousoft_yhq.Model.MSysCountry> ResultList = null;
            string StrSql = string.Format("SELECT {0} Id, EnName,Zones,CnName FROM tbl_SysCountry WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (chaXun != null)
            {
                if (chaXun.Zones > 0)
                {
                    StrSql = StrSql + string.Format(" AND Zones={0} ", chaXun.Zones);
                }
                if (!string.IsNullOrEmpty(chaXun.EnName))
                {
                    StrSql = StrSql + string.Format(" AND EnName like '%{0}%'", chaXun.EnName);
                }
                if (!string.IsNullOrEmpty(chaXun.CnName))
                {
                    StrSql = StrSql + string.Format(" AND CnName like '%{0}%'", chaXun.CnName);
                }
            }
            StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysCountry>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysCountry model = new Eyousoft_yhq.Model.MSysCountry()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        EnName = dr.IsDBNull(dr.GetOrdinal("EnName")) ? "" : dr.GetString(dr.GetOrdinal("EnName")),
                        Zones = dr.GetInt32(dr.GetOrdinal("Zones")),
                        CnName = dr.IsDBNull(dr.GetOrdinal("CnName")) ? "" : dr.GetString(dr.GetOrdinal("CnName"))
                    };
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

        #endregion  国家

        #region  省份

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysProvince(Eyousoft_yhq.Model.MSysProvince model)
        {
            string StrSql = " select count(1) from tbl_SysProvince WHERE 1=1 ";
            if (model.ID > 0)
            {
                StrSql += " AND ID<>@ID ";
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                StrSql += " AND Name=@Name ";
            }
            if (!string.IsNullOrEmpty(model.HeaderLetter))
            {
                StrSql += " AND HeaderLetter=@HeaderLetter ";
            }
            if (model.CountryId > 0)
            {
                StrSql += " AND CountryId = @CountryId ";
            }
            if (model.AreaId > 0)
            {
                StrSql += " AND AreaId = @AreaId ";
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            if (model.ID > 0)
            {
                this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            }
            if (!string.IsNullOrEmpty(model.HeaderLetter))
            {
                this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            }
            if (model.CountryId > 0)
            {
                this._db.AddInParameter(dc, "CountryId", DbType.Int32, model.CountryId);
            }
            if (model.AreaId > 0)
            {
                this._db.AddInParameter(dc, "AreaId", DbType.Int32, model.AreaId);
            }
            return DbHelper.Exists(dc, _db);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysProvince(Eyousoft_yhq.Model.MSysProvince model)
        {
            string StrSql = "INSERT INTO tbl_SysProvince(CountryId,HeaderLetter,Name,AreaId,SortId) VALUES(@CountryId,@HeaderLetter,@Name,@AreaId,@SortId)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "CountryId", DbType.Int32, model.CountryId);
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            this._db.AddInParameter(dc, "AreaId", DbType.Int32, model.AreaId);
            this._db.AddInParameter(dc, "SortId", DbType.Int32, model.SortId);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysProvince(Eyousoft_yhq.Model.MSysProvince model)
        {
            string StrSql = "UPDATE tbl_SysProvince SET CountryId=@CountryId,HeaderLetter=@HeaderLetter,Name=@Name,AreaId=@AreaId,SortId=@SortId WHERE ID=@ID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "CountryId", DbType.Int32, model.CountryId);
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            this._db.AddInParameter(dc, "AreaId", DbType.Int32, model.AreaId);
            this._db.AddInParameter(dc, "SortId", DbType.Int32, model.SortId);
            this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysProvince(int ID)
        {
            string StrSql = " DELETE FROM tbl_SysCity WHERE ProvinceId=@ID ;DELETE FROM tbl_SysProvince WHERE ID=@ID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysProvince GetSysProvinceModel(int ID)
        {
            Eyousoft_yhq.Model.MSysProvince model = null;
            string StrSql = "SELECT ID, CountryId,HeaderLetter,Name,AreaId,SortId FROM tbl_SysProvince WHERE ID=@ID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MSysProvince()
                    {
                        ID = dr.GetInt32(dr.GetOrdinal("ID")),
                        CountryId = dr.GetInt32(dr.GetOrdinal("CountryId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                        SortId = dr.GetInt32(dr.GetOrdinal("SortId"))
                    };
                }
            };
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysProvince> GetSysProvinceList(int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MSysProvince chaXun)
        {
            IList<Eyousoft_yhq.Model.MSysProvince> ResultList = null;
            string tableName = "tbl_SysProvince";
            string fields = "ID, CountryId,HeaderLetter,Name,AreaId,SortId,(select [Id],[ProvinceId],[Name],[CenterCityId],[HeaderLetter],[IsSite],[DomainName],[IsEnabled] from tbl_SysCity where tbl_SysCity.ProvinceId = tbl_SysProvince.ID for xml raw,root('Root')) as CityList ";
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (chaXun.CountryId > 0)
                {
                    query = query + string.Format(" AND CountryId={0} ", chaXun.CountryId);
                }
                if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
                {
                    query = query + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
                }
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    query = query + string.Format(" AND Name like '%{0}%'", chaXun.Name);
                }
                if (chaXun.AreaId > 0)
                {
                    query = query + string.Format(" AND AreaId={0} ", chaXun.AreaId);
                }
            }
            string orderByString = " ID ASC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
                , orderByString, string.Empty))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysProvince>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysProvince model = new Eyousoft_yhq.Model.MSysProvince()
                    {
                        ID = dr.GetInt32(dr.GetOrdinal("ID")),
                        CountryId = dr.GetInt32(dr.GetOrdinal("CountryId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                        SortId = dr.GetInt32(dr.GetOrdinal("SortId"))
                    };
                    if (!dr.IsDBNull(dr.GetOrdinal("CityList")))
                        model.CityList = (List<Eyousoft_yhq.Model.MSysCity>)this.GetCity(dr.GetString(dr.GetOrdinal("CityList")));

                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysProvince> GetSysProvinceList(int Top, Eyousoft_yhq.Model.MSysProvince chaXun, string filedOrder)
        {
            IList<Eyousoft_yhq.Model.MSysProvince> ResultList = null;
            string StrSql = string.Format("SELECT {0} ID, CountryId,HeaderLetter,Name,AreaId,SortId FROM tbl_SysProvince WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (chaXun != null)
            {
                if (chaXun.CountryId > 0)
                {
                    StrSql = StrSql + string.Format(" AND CountryId={0} ", chaXun.CountryId);
                }
                if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
                {
                    StrSql = StrSql + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
                }
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    StrSql = StrSql + string.Format(" AND Name like '%{0}%'", chaXun.Name);
                }
                if (chaXun.AreaId > 0)
                {
                    StrSql = StrSql + string.Format(" AND AreaId={0} ", chaXun.AreaId);
                }
            }
            StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysProvince>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysProvince model = new Eyousoft_yhq.Model.MSysProvince()
                    {
                        ID = dr.GetInt32(dr.GetOrdinal("ID")),
                        CountryId = dr.GetInt32(dr.GetOrdinal("CountryId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                        SortId = dr.GetInt32(dr.GetOrdinal("SortId"))
                    };
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

        private IList<Eyousoft_yhq.Model.MSysCity> GetCity(string sqlXml)
        {
            if (string.IsNullOrEmpty(sqlXml)) return null;

            var xRoot = XElement.Parse(sqlXml);
            var xRow = Utils.GetXElements(xRoot, "row");

            if (xRow == null || !xRow.Any()) return null;

            return
                xRow.Select(
                    t =>
                    new Model.MSysCity
                    {
                        CenterCityId = Utils.GetInt(Utils.GetXAttributeValue(t, "CenterCityId")),
                        DomainName = Utils.GetXAttributeValue(t, "DomainName"),
                        HeaderLetter = Utils.GetXAttributeValue(t, "HeaderLetter"),
                        Id = Utils.GetInt(Utils.GetXAttributeValue(t, "Id")),
                        IsEnabled = this.GetBoolean(Utils.GetXAttributeValue(t, "IsEnabled")),
                        IsSite = this.GetBoolean(Utils.GetXAttributeValue(t, "IsSite")),
                        Name = Utils.GetXAttributeValue(t, "Name"),
                        ProvinceId = Utils.GetInt(Utils.GetXAttributeValue(t, "ProvinceId"))
                    }).ToList();
        }

        #endregion  省份

        #region  城市

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysCity(Eyousoft_yhq.Model.MSysCity model)
        {
            string StrSql = " select count(1) from tbl_SysCity WHERE 1=1 ";
            if (model.Id > 0)
            {
                StrSql += " AND Id<>@Id ";
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                StrSql += " AND Name=@Name ";
            }
            if (!string.IsNullOrEmpty(model.HeaderLetter))
            {
                StrSql += " AND HeaderLetter=@HeaderLetter ";
            }
            if (model.ProvinceId > 0)
            {
                StrSql += " AND ProvinceId = @ProvinceId ";
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            if (model.Id > 0)
            {
                this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            }
            if (!string.IsNullOrEmpty(model.HeaderLetter))
            {
                this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            }
            if (model.ProvinceId > 0)
            {
                this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            }
            return DbHelper.Exists(dc, _db);

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysCity(Eyousoft_yhq.Model.MSysCity model)
        {
            string StrSql = "INSERT INTO tbl_SysCity(ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) VALUES(@ProvinceId,@Name,@CenterCityId,@HeaderLetter,@IsSite,@DomainName,@IsEnabled)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            this._db.AddInParameter(dc, "CenterCityId", DbType.Int32, model.CenterCityId);
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            this._db.AddInParameter(dc, "IsSite", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsSite));
            this._db.AddInParameter(dc, "DomainName", DbType.String, model.DomainName);
            this._db.AddInParameter(dc, "IsEnabled", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsEnabled));
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysCity(Eyousoft_yhq.Model.MSysCity model)
        {
            string StrSql = "UPDATE tbl_SysCity SET ProvinceId = @ProvinceId,Name = @Name,CenterCityId = @CenterCityId,HeaderLetter = @HeaderLetter,IsSite = @IsSite,DomainName = @DomainName,IsEnabled = @IsEnabled WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            this._db.AddInParameter(dc, "CenterCityId", DbType.Int32, model.CenterCityId);
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            this._db.AddInParameter(dc, "IsSite", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsSite));
            this._db.AddInParameter(dc, "DomainName", DbType.String, model.DomainName);
            this._db.AddInParameter(dc, "IsEnabled", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsEnabled));
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysCity(int ID)
        {
            string StrSql = " DELETE FROM tbl_SysCity WHERE Id=@Id ";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysCity GetSysCityModel(int ID)
        {
            Eyousoft_yhq.Model.MSysCity model = null;
            string StrSql = "SELECT Id, ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled FROM tbl_SysCity WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MSysCity()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                        IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                        DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                        IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
                    };
                }
            };
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysCity> GetSysCityList(int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MSysCity chaXun)
        {
            IList<Eyousoft_yhq.Model.MSysCity> ResultList = null;
            string tableName = "tbl_SysCity";
            string identityColumnName = "Id";
            string fields = "Id, ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled";
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (chaXun.ProvinceId > 0)
                {
                    query = query + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
                }
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    query = query + string.Format(" AND Name like '%{0}%'", chaXun.Name);
                }
                if (chaXun.CenterCityId > 0)
                {
                    query = query + string.Format(" AND CenterCityId={0} ", chaXun.CenterCityId);
                }
                if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
                {
                    query = query + string.Format(" OR HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
                }
                if (chaXun.IsSite)
                {
                    query = query + string.Format(" AND IsSite='{0}'", this.GetBooleanToStr(chaXun.IsSite));
                }
                if (!string.IsNullOrEmpty(chaXun.DomainName))
                {
                    query = query + string.Format(" AND DomainName like '%{0}%'", chaXun.DomainName);
                }
                if (chaXun.IsEnabled)
                {
                    query = query + string.Format(" AND IsEnabled='{0}'", this.GetBooleanToStr(chaXun.IsEnabled));
                }
            }
            string orderByString = " Id ASC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query, orderByString, ""))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysCity>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysCity model = new Eyousoft_yhq.Model.MSysCity()
                     {
                         Id = dr.GetInt32(dr.GetOrdinal("Id")),
                         ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                         Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                         CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                         HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                         IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                         DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                         IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
                     };
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysCity> GetSysCityList(int Top, Eyousoft_yhq.Model.MSysCity chaXun, string filedOrder)
        {
            IList<Eyousoft_yhq.Model.MSysCity> ResultList = null;
            string StrSql = string.Format("SELECT {0} Id, ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled FROM tbl_SysCity WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (chaXun != null)
            {
                if (chaXun.ProvinceId > -1)
                {
                    StrSql = StrSql + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
                }
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    StrSql = StrSql + string.Format(" AND Name like '%{0}%'", chaXun.Name);
                }
                if (chaXun.CenterCityId > 0)
                {
                    StrSql = StrSql + string.Format(" AND CenterCityId={0} ", chaXun.CenterCityId);
                }
                if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
                {
                    StrSql = StrSql + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
                }
                if (chaXun.IsSite)
                {
                    StrSql = StrSql + string.Format(" AND IsSite='{0}'", this.GetBooleanToStr(chaXun.IsSite));
                }
                if (!string.IsNullOrEmpty(chaXun.DomainName))
                {
                    StrSql = StrSql + string.Format(" AND DomainName like '%{0}%'", chaXun.DomainName);
                }
                if (chaXun.IsEnabled)
                {
                    StrSql = StrSql + string.Format(" AND IsEnabled='{0}'", this.GetBooleanToStr(chaXun.IsEnabled));
                }
            }
            StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysCity>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysCity model = new Eyousoft_yhq.Model.MSysCity()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                        IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                        DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                        IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
                    };
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

        #endregion  城市

        #region  县区

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysDistrict(Eyousoft_yhq.Model.MSysDistrict model)
        {
            string StrSql = " select count(1) from tbl_SysDistrict WHERE 1=1 ";
            if (model.Id > 0)
            {
                StrSql += " AND Id<>@Id ";
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                StrSql += " AND Name=@Name ";
            }
            if (!string.IsNullOrEmpty(model.HeaderLetter))
            {
                StrSql += " AND HeaderLetter=@HeaderLetter ";
            }
            if (model.CityId > 0)
            {
                StrSql += " AND CityId = @CityId ";
            }
            if (model.ProvinceId > 0)
            {
                StrSql += " AND ProvinceId = @ProvinceId ";
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            if (model.Id > 0)
            {
                this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            }
            if (!string.IsNullOrEmpty(model.HeaderLetter))
            {
                this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            }
            if (model.CityId > 0)
            {
                this._db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
            }
            if (model.ProvinceId > 0)
            {
                this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            }
            return DbHelper.Exists(dc, _db);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysDistrict(Eyousoft_yhq.Model.MSysDistrict model)
        {
            string StrSql = "INSERT INTO tbl_SysDistrict(Name,ProvinceId,CityId,HeaderLetter) VALUES(@Name,@ProvinceId,@CityId,@HeaderLetter)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysDistrict(Eyousoft_yhq.Model.MSysDistrict model)
        {
            string StrSql = "UPDATE tbl_SysDistrict SET Name = @Name,ProvinceId = @ProvinceId,CityId = @CityId,HeaderLetter=@HeaderLetter WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
            this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysDistrict(int ID)
        {
            string StrSql = "DELETE FROM tbl_SysDistrict WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysDistrict GetSysDistrictModel(int ID)
        {
            Eyousoft_yhq.Model.MSysDistrict model = null;
            string StrSql = "SELECT Id, Name,ProvinceId,CityId,HeaderLetter FROM tbl_SysDistrict WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new Eyousoft_yhq.Model.MSysDistrict()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                        CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter"))
                    };
                }
            };
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysDistrict> GetSysDistrictList(int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MSysDistrict chaXun)
        {
            IList<Eyousoft_yhq.Model.MSysDistrict> ResultList = null;
            string tableName = "tbl_SysDistrict";
            string identityColumnName = "Id";
            string fields = "Id, Name,ProvinceId,CityId,HeaderLetter";
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    query = query + string.Format(" AND Name like '%{0}%'", chaXun.Name);
                }
                if (chaXun.ProvinceId > 0)
                {
                    query = query + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
                }
                if (chaXun.CityId > 0)
                {
                    query = query + string.Format(" AND CityId={0} ", chaXun.CityId);
                }
                if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
                {
                    query = query + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
                }
            }
            string orderByString = " Id ASC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, identityColumnName, fields, query, orderByString))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysDistrict>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysDistrict model = new Eyousoft_yhq.Model.MSysDistrict()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                        CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter"))
                    };
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysDistrict> GetSysDistrictList(int Top, Eyousoft_yhq.Model.MSysDistrict chaXun, string filedOrder)
        {
            IList<Eyousoft_yhq.Model.MSysDistrict> ResultList = null;
            string StrSql = string.Format("SELECT {0} Id, Name,ProvinceId,CityId,HeaderLetter FROM tbl_SysDistrict WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    StrSql = StrSql + string.Format(" AND Name like '%{0}%'", chaXun.Name);
                }
                if (chaXun.ProvinceId > 0)
                {
                    StrSql = StrSql + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
                }
                if (chaXun.CityId > -1)
                {
                    StrSql = StrSql + string.Format(" AND CityId={0} ", chaXun.CityId);
                }
                if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
                {
                    StrSql = StrSql + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
                }
            }
            StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<Eyousoft_yhq.Model.MSysDistrict>();
                while (dr.Read())
                {
                    Eyousoft_yhq.Model.MSysDistrict model = new Eyousoft_yhq.Model.MSysDistrict()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                        ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                        CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                        HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter"))
                    };
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

        #endregion  县区

        #endregion AreaInfo 成员
    }
}
