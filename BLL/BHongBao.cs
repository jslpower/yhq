using System;
using System.Collections.Generic;
using System.Text;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.BLL
{
    /// <summary>
    ///红包操作相关 
    /// </summary>
    public class BHongBao
    {
        readonly Eyousoft_yhq.SQLServerDAL.DHongBao dal = new Eyousoft_yhq.SQLServerDAL.DHongBao();

        /// <summary>
        /// 判断当前用户是否有红包
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool Exists(string userid)
        {
            if (string.IsNullOrEmpty(userid)) return false;
            return dal.Exists(userid);
        }
        /// <summary>
        /// 添加一个红包
        /// </summary>
        /// <param name="info">红包</param>
        /// <returns></returns>
        public int Insert(HongBao info)
        {
            if (string.IsNullOrEmpty(info.UserID)) return 0;

            info.ID = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            int result = dal.Insert(info);
            if (result == 1)//修改账户金额
            {
                Eyousoft_yhq.BLL.BConDetaile bll = new Eyousoft_yhq.BLL.BConDetaile();
                Eyousoft_yhq.Model.MConDetaile con = new Eyousoft_yhq.Model.MConDetaile();
                con.JiaoYiHao = info.IssueTime.ToString("yyyyMMddhhmmssfff");
                con.DingDanBianHao = info.IssueTime.ToString("yyyyMMddhhmmssfff");
                con.JinE = info.HongBaoJinE;
                con.JiaoYiShiJian = DateTime.Now;
                con.XFway = Eyousoft_yhq.Model.XFfangshi.红包抽奖;
                con.HuiYuanID = info.UserID;
                bll.Add(con);
            }

            return result;
        }
        /// <summary>
        /// 修改红包金额
        /// </summary>
        /// <param name="model">红包</param>
        /// <returns></returns>
        public int Update(HongBao info)
        {
            if (string.IsNullOrEmpty(info.ID)) return 0;

            var yuan = GetInfo(info.ID);
            if (yuan == null) return 0;
            decimal yuanJinE = yuan.HongBaoJinE;
            int result = dal.Update(info);

            return result;
        }

        /// <summary>
        /// 获取红包实体
        /// </summary>
        /// <param name="ID">红包编号</param>
        /// <returns></returns>
        public HongBao GetInfo(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            return dal.GetInfo(Id);
        }

        /// <summary>
        /// 获取红包实体
        /// </summary>
        /// <param name="ID">会员编号</param>
        /// <returns></returns>
        public HongBao GetInfoByUserID(string UserID)
        {
            if (string.IsNullOrEmpty(UserID)) return null;
            return dal.GetInfoByUserID(UserID);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="serModel"></param>
        /// <returns></returns>
        public IList<HongBao> GetList(int PageSize, int PageIndex, ref int RecordCount, HongBaoSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }


    }
}
