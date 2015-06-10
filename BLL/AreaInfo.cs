using System;
using System.Collections.Generic;
using System.Text;
using Eyousoft_yhq.SQLServerDAL;

namespace Eyousoft_yhq.BLL
{
  public  class AreaInfo
    {
      Eyousoft_yhq.SQLServerDAL.DSysAreaInfo dal = new Eyousoft_yhq.SQLServerDAL.DSysAreaInfo();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public AreaInfo() { }
        #endregion

        #region public members


        #region  国家

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysCountry(Eyousoft_yhq.Model.MSysCountry model)
        {
            return dal.ExistsSysCountry(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysCountry(Eyousoft_yhq.Model.MSysCountry model)
        {
            if (model != null && !string.IsNullOrEmpty(model.CnName))
                return dal.AddSysCountry(model);
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysCountry(Eyousoft_yhq.Model.MSysCountry model)
        {
            if (model != null && model.Id > 0 && !string.IsNullOrEmpty(model.CnName))
                return dal.UpdateSysCountry(model);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysCountry(int ID)
        {
            if (ID > 0)
                return dal.DeleteSysCountry(ID);
            else
                return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysCountry GetSysCountryModel(int ID)
        {
            if (ID > 0)
                return dal.GetSysCountryModel(ID);
            else
                return null;
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
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetSysCountryList(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysCountry> GetSysCountryList(int Top, Eyousoft_yhq.Model.MSysCountry chaXun)
        {
            return dal.GetSysCountryList((Top < 0 ? 0 : Top), chaXun, "");
        }

        #endregion  国家

        #region  省份

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysProvince(Eyousoft_yhq.Model.MSysProvince model)
        {
            return dal.ExistsSysProvince(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysProvince(Eyousoft_yhq.Model.MSysProvince model)
        {
            if (model != null && !string.IsNullOrEmpty(model.Name))
                return dal.AddSysProvince(model);
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysProvince(Eyousoft_yhq.Model.MSysProvince model)
        {
            if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.Name))
                return dal.UpdateSysProvince(model);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysProvince(int ID)
        {
            if (ID > 0)
                return dal.DeleteSysProvince(ID);
            else
                return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysProvince GetSysProvinceModel(int ID)
        {
            if (ID > 0)
                return dal.GetSysProvinceModel(ID);
            else
                return null;
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
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetSysProvinceList(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysProvince> GetSysProvinceList(int Top, Eyousoft_yhq.Model.MSysProvince chaXun)
        {
            return dal.GetSysProvinceList((Top < 0 ? 0 : Top), chaXun, "");
        }

        #endregion  省份

        #region  城市

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysCity(Eyousoft_yhq.Model.MSysCity model)
        {
            return dal.ExistsSysCity(model);

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysCity(Eyousoft_yhq.Model.MSysCity model)
        {
            if (model != null && model.ProvinceId > 0 && !string.IsNullOrEmpty(model.Name))
                return dal.AddSysCity(model);
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysCity(Eyousoft_yhq.Model.MSysCity model)
        {
            if (model != null && model.ProvinceId > 0 && !string.IsNullOrEmpty(model.Name))
                return dal.UpdateSysCity(model);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysCity(int ID)
        {
            if (ID > 0)
                return dal.DeleteSysCity(ID);
            else
                return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysCity GetSysCityModel(int ID)
        {
            if (ID > 0)
                return dal.GetSysCityModel(ID);
            else
                return null;
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
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetSysCityList(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysCity> GetSysCityList(int Top, Eyousoft_yhq.Model.MSysCity chaXun)
        {
            return dal.GetSysCityList((Top < 0 ? 0 : Top), chaXun, "");
        }

        #endregion  城市

        #region  县区

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsSysDistrict(Eyousoft_yhq.Model.MSysDistrict model)
        {
            return dal.ExistsSysDistrict(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddSysDistrict(Eyousoft_yhq.Model.MSysDistrict model)
        {
            if (model != null && model.ProvinceId > 0 && model.CityId > 0 && !string.IsNullOrEmpty(model.Name))
                return dal.AddSysDistrict(model);
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysDistrict(Eyousoft_yhq.Model.MSysDistrict model)
        {
            if (model != null && model.ProvinceId > 0 && model.CityId > 0 && !string.IsNullOrEmpty(model.Name))
                return dal.UpdateSysDistrict(model);
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteSysDistrict(int ID)
        {
            if (ID > 0)
                return dal.DeleteSysDistrict(ID);
            else
                return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.MSysDistrict GetSysDistrictModel(int ID)
        {
            if (ID > 0)
                return dal.GetSysDistrictModel(ID);
            else
                return null;
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
            if (!Utils.ValidPaging(pageSize, pageIndex))
                return null;
            return dal.GetSysDistrictList(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MSysDistrict> GetSysDistrictList(int Top, Eyousoft_yhq.Model.MSysDistrict chaXun)
        {
            return dal.GetSysDistrictList((Top < 0 ? 0 : Top), chaXun, "");
        }

        #endregion  县区

        #endregion
    }
}
