using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    public class Member
    {
        private readonly Eyousoft_yhq.SQLServerDAL.DMember dal = new Eyousoft_yhq.SQLServerDAL.DMember();
        public Member()
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
        public bool Add(Eyousoft_yhq.Model.User model)
        {
            model.UserID = Guid.NewGuid().ToString();
            bool result = dal.Add(model);
            if (result) new Eyousoft_yhq.BLL.Login().isLogin(model.UserName, model.UserPwd);

            return result;

        }
        /// <summary>
        /// 返回推广次数
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public int CountTGCS(string Code)
        {
            return dal.CountTGCS(Code);
        }
        /// <summary>
        /// 返回返佣次数
        /// </summary>
        /// <param name="MemberID">用户编号</param>
        /// <param name="PollCode">激活码</param>
        /// <returns></returns>
        public int CountFYCS(string MemberID, string PollCode)
        {
            return dal.CountFYCS(MemberID, PollCode);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eyousoft_yhq.Model.User model)
        {
            if (string.IsNullOrEmpty(model.UserID)) return false;
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateYuE(Eyousoft_yhq.Model.User model)
        {
            if (string.IsNullOrEmpty(model.UserID)) return false;
            return dal.UpdateYuE(model);
        }
        /// <summary>
        /// 修改最后查看时间
        /// </summary>
        /// <param name="UserId">用户id</param>
        /// <param name="XinXiType">查看类别（0-点赞1-留言2-关注）</param>
        /// <returns></returns>
        public bool Update(string UserId, Eyousoft_yhq.Model.OptionType XinXiType)
        {
            if (string.IsNullOrEmpty(UserId)) return false;
            return dal.Update(UserId, XinXiType);
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
        public Eyousoft_yhq.Model.User GetModel(string UserID)
        {
            if (string.IsNullOrEmpty(UserID)) return null;
            return dal.GetModel(UserID);
        }
        /// <summary>
        /// 根据用户名得到一个对象实体
        /// </summary>
        public Eyousoft_yhq.Model.User GetModelByName(string UserName)
        {
            if (string.IsNullOrEmpty(UserName)) return null;
            return dal.GetModelByName(UserName);
        }
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="cname"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.User GetModel(string cname, string mobile)
        {
            return dal.GetModel(cname, mobile);
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
        public IList<Eyousoft_yhq.Model.User> GetList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchUser serModel, int isAdmin)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel, isAdmin);
        }

        /*/// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="serModel"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.User> GetList(Eyousoft_yhq.Model.MSearchUser serModel)
        {
            return dal.GetList(serModel);
        }*/

        /// <summary>
        /// 修改余额
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public int UpdatePayState(string UserFromId, string UserToId, decimal money)
        {
            if (string.IsNullOrEmpty(UserFromId)) return -100;
            if (string.IsNullOrEmpty(UserToId)) return -101;
            if (money <= 0) return -102;
            return dal.UpdatePayState(UserFromId, UserToId, money);
        }



        /// <summary>
        /// 添加用户地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressAdd(Eyousoft_yhq.Model.UserAddress address)
        {
            address.AddressID = Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(address.UserID) ||
                address.AddressProvince == 0 ||
               address.AddressCity == 0
                ) return 0;
            return dal.UserAddressAdd(address);
        }

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressUpdate(Eyousoft_yhq.Model.UserAddress address)
        {
            if (string.IsNullOrEmpty(address.UserID) ||
             address.AddressProvince == 0 ||
              address.AddressCity == 0 ||
             string.IsNullOrEmpty(address.AddressID)
             ) return 0;
            return dal.UserAddressUpdate(address);
        }

        /// <summary>
        /// 修改地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressDefaultUpdate(Eyousoft_yhq.Model.UserAddress address)
        {
            if (string.IsNullOrEmpty(address.UserID) ||
                string.IsNullOrEmpty(address.AddressID)) return 0;
            return dal.UserAddressDefaultUpdate(address);
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public int UserAddressDelete(string address)
        {
            if (string.IsNullOrEmpty(address)) return 0;
            return dal.UserAddressDelete(address);
        }


        /// <summary>
        /// 获取用户地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.UserAddress GetAddress(string Address)
        {
            if (string.IsNullOrEmpty(Address)) return null;
            return dal.GetAddress(Address);
        }

        /// <summary>
        /// 获取用户地址
        /// </summary>
        /// <param name="address">地址信息</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.UserAddress> GetAddressList(int top, string userid)
        {
            return dal.GetAddressList(top, userid);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.UserAddress> GetAddressList(int PageSize, int PageIndex, ref int RecordCount, Eyousoft_yhq.Model.MSearchUserAddress serModel)
        {
            return dal.GetAddressList(PageSize, PageIndex, ref RecordCount, serModel);
        }

        #endregion  成员方法
        /// <summary>
        /// 给会员充值
        /// </summary>
        /// <param name="UserName">会员名称</param>
        /// <returns></returns>
        public int HuiYuangZZ(string UserName, decimal money)
        {
            if (string.IsNullOrEmpty(UserName)) return 0;
            if (money <= 0) return 0;
            return dal.HuiYuangZZ(UserName, money);
        }
        /// <summary>
        /// 给会员充值
        /// </summary>
        /// <param name="username">会员编号</param>
        /// <returns></returns>
        public int HuiYuangZzByID(string id, decimal money)
        {

            if (string.IsNullOrEmpty(id)) return 0;
            if (money <= 0) return 0;
            return dal.HuiYuangZzByID(id, money);

        }
        /// <summary>
        /// 设置账户金额
        /// </summary>
        /// <param name="username">会员编号</param>
        /// <returns></returns>
        public int setMoney(string id, decimal money)
        {
            if (string.IsNullOrEmpty(id)) return 0;
            return dal.setMoney(id, money);
        }
        /// <summary>
        /// 会员新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int HuiYuan_C(Eyousoft_yhq.Model.User info)
        {
            if (info == null || string.IsNullOrEmpty(info.UserName)) return 0;

            info.UserID = Guid.NewGuid().ToString();
            info.IssueTime = info.LvYouGuWenRenZhengTime = DateTime.Now;

            int dalRetCode = dal.HuiYuan_CU(info);
            return dalRetCode;
        }

        /// <summary>
        /// 会员修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int HuiYuan_U(Eyousoft_yhq.Model.User info)
        {
            if (info == null || string.IsNullOrEmpty(info.UserName) || string.IsNullOrEmpty(info.UserID)) return 0;

            info.IssueTime = info.LvYouGuWenRenZhengTime = DateTime.Now;

            int dalRetCode = dal.HuiYuan_CU(info);
            return dalRetCode;
        }

        /// <summary>
        /// 旅游顾问认证，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public int LvYouGuWen_RenZheng(string huiYuanId, bool isGuWen)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return 0;
            var info = GetModel(huiYuanId);
            if (info == null) return -1;
            //if (info.IsLvYouGuWen) return -2;
            if (isGuWen == true)
            {
                info.IsLvYouGuWen = false;
            }
            else
            {
                info.IsLvYouGuWen = true;
                info.LvYouGuWenRenZhengTime = DateTime.Now;
            }
            int dalRetCode = dal.HuiYuan_CU(info);
            return dalRetCode;
        }

        /// <summary>
        /// 获取名片信息业务实体
        /// </summary>
        /// <param name="mingPianId">名片编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MMingPianInfo GetMingPianInfo(string mingPianId)
        {
            if (string.IsNullOrEmpty(mingPianId)) return null;

            return dal.GetMingPianInfo(mingPianId);
        }
    }
}
