//微店相关业务实体 汪奇志 2015-01-19
using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    #region 微店信息业务实体
    /// <summary>
    /// 微店信息业务实体
    /// </summary>
    public class MWeiDianInfo
    {
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 微店名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 微店状态
        /// </summary>
        public WeiDianStatus Status { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ShenQingTime { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime ShenHeTime { get; set; }
        /// <summary>
        /// 微店介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 会员用户名（OUTPUT）
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName { get; set; }
        /// <summary>
        /// 微店logo
        /// </summary>
        public string LogoFilepath { get; set; }
        /// <summary>
        /// 微店电话
        /// </summary>
        public string DianHua { get; set; }
    }
    #endregion

    #region 微店查询信息业务实体
    /// <summary>
    /// 微店查询信息业务实体
    /// </summary>
    public class MWeiDianChaXunInfo
    {
        /// <summary>
        /// 微店名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 微店会员用户名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 微店会员姓名
        /// </summary>
        public string HuiYuanName { get; set; }
        /// <summary>
        /// 微店状态
        /// </summary>
        public WeiDianStatus? Status { get; set; }
    }
    #endregion

    #region 微店产品信息业务实体
    /// <summary>
    /// 微店产品信息业务实体
    /// </summary>
    public class MWeiDianChanPinInfo
    {
        /// <summary>
        /// 关系编号
        /// </summary>
        public int GuanXiId { get; set; }
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ChanPinId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ChanPinName { get; set; }
        /// <summary>
        /// 添加到微店时间
        /// </summary>
        public DateTime TianJiaTime { get; set; }
        /// <summary>
        /// 产品图片路径
        /// </summary>
        public string ChanPinTuPianFilepath { get; set; }
        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal ShiChangJiaGe { get; set; }
        /// <summary>
        /// 结算价格（APP价格）
        /// </summary>
        public decimal JieSuanJiaGe { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int PingLunJiShu { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime? ChuTuanRiQi { get; set; }
        /// <summary>
        /// 是否天天发团
        /// </summary>
        public bool IsTianTianFaTuan { get; set; }
    }
    #endregion

    #region 微店产品信息查询业务实体
    /// <summary>
    /// 微店产品信息查询业务实体
    /// </summary>
    public class MWeiDianChanPinChaXunInfo
    {
        /// <summary>
        /// 产品类型
        /// </summary>
        public int? ChanPinLeiXing { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ChanPinName { get; set; }
    }
    #endregion

    #region 微店订单信息业务实体
    /// <summary>
    /// 微店订单信息业务实体
    /// </summary>
    public class MWeiDianDingDanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ChanPinId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ChanPinName { get; set; }
        /// <summary>
        /// 产品图片路径
        /// </summary>
        public string ChanPinTuPianFilepath { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState DingDanStatus { get; set; }
        /// <summary>
        /// 审核状态 0：未审核 1：已审核
        /// </summary>
        public string ShenHeStatus { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PaymentState ZhiFuStatus { get; set; }
        /// <summary>
        /// 下单人会员编号
        /// </summary>
        public string XiaDanRenId { get; set; }
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime XiaDanTime { get; set; }
        /// <summary>
        /// 消费状态
        /// </summary>
        public ConSumState XiaoFeiStatus { get; set; }
    }
    #endregion

    #region 微店订单信息查询业务实体
    /// <summary>
    /// 微店订单信息查询业务实体
    /// </summary>
    public class MWeiDianDingDanChaXunInfo
    {

    }
    #endregion
}
