using System;
using System.Data;
using System.Collections.Generic;
using Eyousoft_yhq.Model;
namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// webmaster 
    /// </summary>
    public partial class User
    {
        private readonly Eyousoft_yhq.SQLServerDAL.User dal = new Eyousoft_yhq.SQLServerDAL.User();
        public User()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            if (string.IsNullOrEmpty(UserName)) return false;
            return dal.Exists(UserName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model)
        {
            model.UserId = Guid.NewGuid().ToString();
            bool result = dal.Add(model);
            if (result) new Eyousoft_yhq.BLL.Login().isLogin(model.Username, model.MiMa);

            return result;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model)
        {
            if (string.IsNullOrEmpty(model.UserId)) return false;
            return dal.Update(model);
        }
        /// <summary>
        /// 设置权限
        /// </summary>
        public bool UpdatePrivs(EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model)
        {
            if (string.IsNullOrEmpty(model.UserId)) return false;
            return dal.UpdatePrivs(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>return -99:不存在 1:删除(普通用户) 2:停用(管理员账号)</returns>
        public int Delete(string UserID)
        {
            if (string.IsNullOrEmpty(UserID)) return -99;
            return dal.Delete(UserID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>return  1:成功 2:失败</returns>
        public bool qiyong(string UserID)
        {
            if (string.IsNullOrEmpty(UserID)) return false;
            return dal.qiyong(UserID);
        }
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="UserIDlist"></param>
        /// <returns></returns>
        public bool DeleteList(string[] UserIDlist)
        {
            if (UserIDlist == null || UserIDlist.Length < 1) return false;
            return dal.DeleteList(UserIDlist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.SSOStructure.MGuanLiYuanInfo GetModel(string UserID)
        {
            if (string.IsNullOrEmpty(UserID)) return null;
            return dal.GetModel(UserID);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <param name="isAdmin">1,管理员，0，会员</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.SSOStructure.MGuanLiYuanChaXunInfo serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <param name="isAdmin">1,管理员，0，会员</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.SSOStructure.MGuanLiYuanInfo> GetList(EyouSoft.Model.SSOStructure.MGuanLiYuanChaXunInfo serModel)
        {
            return dal.GetList( serModel);
        }

        /// <summary>
        /// 获取省市区县镇乡列表
        /// </summary>
        /// <param name="serModel">查询实体</param>
        /// <returns></returns>
        public IList<Pro_City_Area_Street> GetProList(Pro_City_Area_StreetSer serModel)
        {
            return dal.GetProList(serModel);
        }
           
        #endregion  成员方法
    }
}

