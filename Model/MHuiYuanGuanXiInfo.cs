//会员关系相关信息业务实体 汪奇志 2015-02-03
using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    #region 会员点赞信息业务实体
    /// <summary>
    /// 会员点赞信息业务实体
    /// </summary>
    public class MHuiYuanDianZanInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 点赞会员编号
        /// </summary>
        public string HuiYuanId1 { get; set; }
        /// <summary>
        /// 对方会员编号
        /// </summary>
        public string HuiYuanId2 { get; set; }
        /// <summary>
        /// 点赞时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 点赞会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName1 { get; set; }
        /// <summary>
        /// 点赞会员图像（OUTPUT）
        /// </summary>
        public string HuiYuanTuXiangFilepath1 { get; set; }
        /// <summary>
        /// 对方会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName2 { get; set; }
        /// <summary>
        /// 对方会员图像（OUTPUT）
        /// </summary>
        public string HuiYuanTuXiangFilepath2 { get; set; }
        /// <summary>
        /// 点赞会员名片编号
        /// </summary>
        public string MingPianId1 { get; set; }
        /// <summary>
        /// 对方会员名片编号
        /// </summary>
        public string MingPianId2 { get; set; }
    }
    #endregion

    #region 会员关注信息业务实体
    /// <summary>
    /// 会员关注信息业务实体
    /// </summary>
    public class MHuiYuanGuanZhuInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 关注会员编号
        /// </summary>
        public string HuiYuanId1 { get; set; }
        /// <summary>
        /// 对方会员编号
        /// </summary>
        public string HuiYuanId2 { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 关注会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName1 { get; set; }
        /// <summary>
        /// 关注会员图像（OUTPUT）
        /// </summary>
        public string HuiYuanTuXiangFilepath1 { get; set; }
        /// <summary>
        /// 对方会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName2 { get; set; }
        /// <summary>
        /// 对方会员图像（OUTPUT）
        /// </summary>
        public string HuiYuanTuXiangFilepath2 { get; set; }

        /// <summary>
        /// 关注会员名片编号
        /// </summary>
        public string MingPianId1 { get; set; }
        /// <summary>
        /// 对方会员名片编号
        /// </summary>
        public string MingPianId2 { get; set; }
    }
    #endregion

    #region 会员留言信息业务实体
    /// <summary>
    /// 会员留言信息业务实体
    /// </summary>
    public class MHuiYuanLiuYanInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 留言会员编号
        /// </summary>
        public string HuiYuanId1 { get; set; }
        /// <summary>
        /// 对方会员编号
        /// </summary>
        public string HuiYuanId2 { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string LiuYanNeiRong { get; set; }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime LiuYanTime { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string HuiFuNeiRong { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime HuiFuTime { get; set; }

        /// <summary>
        /// 留言会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName1 { get; set; }
        /// <summary>
        /// 留言会员图像（OUTPUT）
        /// </summary>
        public string HuiYuanTuXiangFilepath1 { get; set; }
        /// <summary>
        /// 对方会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName2 { get; set; }
        /// <summary>
        /// 对方会员图像（OUTPUT）
        /// </summary>
        public string HuiYuanTuXiangFilepath2 { get; set; }

        /// <summary>
        /// 留言会员名片编号
        /// </summary>
        public string MingPianId1 { get; set; }
        /// <summary>
        /// 对方会员名片编号
        /// </summary>
        public string MingPianId2 { get; set; }
    }
    #endregion
}
