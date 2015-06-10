//会员关系相关信息BLL 汪奇志 2015-02-03
using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 会员关系相关信息BLL
    /// </summary>
    public class BHuiYuanGuanXi
    {
        readonly Eyousoft_yhq.SQLServerDAL.DHuiYuanGuanXi dal = new Eyousoft_yhq.SQLServerDAL.DHuiYuanGuanXi();
        public BHuiYuanGuanXi() { }

        #region public members
        /// <summary>
        /// 会员点赞-点赞，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId1">点赞会员编号</param>
        /// <param name="huiYuanId2">对方会员编号</param>
        /// <returns></returns>
        public int HuiYuanDianZan(string huiYuanId1, string huiYuanId2)
        {
            if (string.IsNullOrEmpty(huiYuanId1) || string.IsNullOrEmpty(huiYuanId2)) return 0;

            var info = new Eyousoft_yhq.Model.MHuiYuanDianZanInfo();
            info.HuiYuanId1 = huiYuanId1;
            info.HuiYuanId2 = huiYuanId2;
            info.IdentityId = 0;
            info.IssueTime = DateTime.Now;

            return dal.HuiYuanDianZan_CUD("C", info);
        }

        /// <summary>
        /// 会员关注-关注，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId1">关注会员编号</param>
        /// <param name="huiYuanId2">对方会员编号</param>
        /// <returns></returns>
        public int HuiYuanGuanZhu(string huiYuanId1, string huiYuanId2)
        {
            if (string.IsNullOrEmpty(huiYuanId1) || string.IsNullOrEmpty(huiYuanId2)) return 0;

            var info = new Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo();
            info.HuiYuanId1 = huiYuanId1;
            info.HuiYuanId2 = huiYuanId2;
            info.IdentityId = 0;
            info.IssueTime = DateTime.Now;

            return dal.HuiYuanGuanZhu_CUD("C", info);
        }

        /// <summary>
        /// 会员关注-取消关注，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId">关注编号</param>
        /// <param name="huiYuanId1">关注会员编号</param>
        /// <param name="huiYuanId2">对方会员编号</param>
        /// <returns></returns>
        public int HuiYuanGuanZhu_QuXiao(int identityId,string huiYuanId1, string huiYuanId2)
        {
            if (identityId < 1 || string.IsNullOrEmpty(huiYuanId1) || string.IsNullOrEmpty(huiYuanId2)) return 0;

            var info = new Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo();
            info.HuiYuanId1 = huiYuanId1;
            info.HuiYuanId2 = huiYuanId2;
            info.IdentityId = identityId;
            info.IssueTime = DateTime.Now;

            return dal.HuiYuanGuanZhu_CUD("D", info);
        }

        /// <summary>
        /// 会员留言-留言，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId1">留言会员编号</param>
        /// <param name="huiYuanId2">对方会员编号</param>
        /// <param name="liuYanneiRong">留言内容</param>
        /// <returns></returns>
        public int HuiYuanLiuYan(string huiYuanId1, string huiYuanId2, string liuYanneiRong)
        {
            if (string.IsNullOrEmpty(huiYuanId1) || string.IsNullOrEmpty(huiYuanId2) || string.IsNullOrEmpty(liuYanneiRong)) return 0;

            var info = new Eyousoft_yhq.Model.MHuiYuanLiuYanInfo();
            info.HuiFuNeiRong = string.Empty;
            info.HuiFuTime = DateTime.Now;
            info.HuiYuanId1 = huiYuanId1;
            info.HuiYuanId2 = huiYuanId2;
            info.IdentityId = 0;
            info.LiuYanNeiRong = liuYanneiRong;
            info.LiuYanTime = DateTime.Now;

            return dal.HuiYuanLiuYan_CUD("C",info);
        }

        /// <summary>
        /// 会员留言-回复，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId">留言编号</param>
        /// <param name="huiYuanId1">留言会员编号</param>
        /// <param name="huiYanId2">对方会员编号</param>
        /// <param name="huiFuNeiRong">回复内容</param>
        /// <returns></returns>
        public int HuiYuanLiuYan_HuiFu(int identityId, string huiYuanId1, string huiYuanId2, string huiFuNeiRong)
        {
            if (identityId < 1 || string.IsNullOrEmpty(huiYuanId1) || string.IsNullOrEmpty(huiYuanId2) || string.IsNullOrEmpty(huiFuNeiRong)) return 0;

            var info = new Eyousoft_yhq.Model.MHuiYuanLiuYanInfo();
            info.HuiFuNeiRong = huiFuNeiRong;
            info.HuiFuTime = DateTime.Now;
            info.HuiYuanId1 = huiYuanId1;
            info.HuiYuanId2 = huiYuanId2;
            info.IdentityId = identityId;
            info.LiuYanNeiRong = string.Empty;
            info.LiuYanTime = DateTime.Now;

            return dal.HuiYuanLiuYan_CUD("H", info);
        }

        /// <summary>
        /// 会员留言-删除，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId">留言编号</param>
        /// <param name="huiYuanId1">留言会员编号</param>
        /// <param name="huiYuanId2">对方会员编号</param>
        /// <returns></returns>
        public int HuiYuanLiuYan_ShanChu(int identityId, string huiYuanId1, string huiYuanId2)
        {
            if (identityId < 1 || string.IsNullOrEmpty(huiYuanId1) || string.IsNullOrEmpty(huiYuanId2)) return 0;

            var info = new Eyousoft_yhq.Model.MHuiYuanLiuYanInfo();
            info.HuiFuNeiRong = string.Empty;
            info.HuiFuTime = DateTime.Now;
            info.HuiYuanId1 = huiYuanId1;
            info.HuiYuanId2 = huiYuanId2;
            info.IdentityId = identityId;
            info.LiuYanNeiRong = string.Empty;
            info.LiuYanTime = DateTime.Now;

            return dal.HuiYuanLiuYan_CUD("D", info);
        }

        /// <summary>
        /// 获取会员被点赞信息集合（被动）
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanDianZanInfo> GetDianZans(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return null;
            return dal.GetDianZans(huiYuanId);
        }

        /// <summary>
        /// 获取会员被关注信息集合（被动）
        /// </summary>
        /// <param name="huiYuanId"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo> GetGuanZhus(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return null;
            return dal.GetGuanZhus(huiYuanId);
        }

        /// <summary>
        /// 获取会员关注信息集合（主动）
        /// </summary>
        /// <param name="huiYuanId"></param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanGuanZhuInfo> GetGuanZhus1(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return null;

            return dal.GetGuanZhus1(huiYuanId);
        }

        /// <summary>
        /// 获取会员被留言信息集合（被动）
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MHuiYuanLiuYanInfo> GetLiuYans(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return null;
            return dal.GetLiuYans(huiYuanId);
        }
        /// <summary>
        /// 获取会员最新点赞条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetDianZanNum(string huiYuanId, DateTime times)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return 0;
            return dal.GetDianZanNum(huiYuanId,times);
        }
        /// <summary>
        /// 获取会员最新留言条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetLiuYanNum(string huiYuanId, DateTime times)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return 0;
            return dal.GetLiuYanNum(huiYuanId, times);
        }
        /// <summary>
        /// 获取会员最新关注条数
        /// </summary>
        /// <param name="huiYuanId">会员Id</param>
        /// <param name="times">最后查看时间</param>
        /// <returns></returns>
        public int GetGuanZhuNum(string huiYuanId, DateTime times)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return 0;
            return dal.GetGuanZhuNum(huiYuanId, times);
        }
        #endregion

    }
}
