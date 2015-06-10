using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    #region 订单状态
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// 未处理
        /// </summary>
        未处理 = 0,
        /// <summary>
        /// 不受理
        /// </summary>
        不受理 = 1,
        /// <summary>
        /// 已取消
        /// </summary>
        已取消 = 2,
        /// <summary>
        /// 处理中
        /// </summary>
        处理中 = 3,
        /// 待付款
        /// </summary>
        待付款 = 4,
        /// <summary>
        /// 已成交
        /// </summary>
        已成交 = 5
    }
    #endregion

    #region 消费状态
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum ConSumState
    {
        /// <summary>
        /// 未消费
        /// </summary>
        未消费 = 0,
        /// <summary>
        /// 已消费
        /// </summary>
        已消费 = 1
    }
    #endregion

    #region 支付状态
    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PaymentState
    {
        /// <summary>
        /// 未支付
        /// </summary>
        未支付 = 1,
        /// <summary>
        /// 已支付
        /// </summary>
        已支付 = 2
    }
    #endregion

    #region 性别
    /// <summary>
    /// 性别
    /// </summary>
    public enum sexType
    {
        /// <summary>
        /// 女
        /// </summary>
        女 = 0,
        /// <summary>
        /// 男
        /// </summary>
        男 = 1,
    }
    #endregion

    #region 合同类型
    /// <summary>
    /// 合同类型
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// 国内合同
        /// </summary>
        国内合同 = 0,
        /// <summary>
        /// 国外合同
        /// </summary>
        国外合同 = 1,
        /// <summary>
        /// 单定协议
        /// </summary>
        单定协议 = 2,
        /// <summary>
        /// 车票
        /// </summary>
        车票 = 3,
        /// <summary>
        /// 门票
        /// </summary>
        门票 = 4
    }
    #endregion

    #region 权限
    /// <summary>
    /// 明细权限枚举
    /// </summary>
    public enum Privs
    {
        /// <summary>
        /// 用户注册信息管理
        /// </summary>
        用户注册信息管理 = 1,
        /// <summary>
        /// 产品展示管理
        /// </summary>
        产品展示管理 = 2,
        /// <summary>
        /// 优惠券使用管理
        /// </summary>
        优惠券使用管理 = 3,
        /// <summary>
        /// 评论管理
        /// </summary>
        评论管理 = 4,
        /// <summary>
        /// 管理列表
        /// </summary>
        管理列表 = 5,
        /// <summary>
        /// 产品类别管理
        /// </summary>
        产品类别管理 = 6,
        /// <summary>
        /// 公司信息
        /// </summary>
        公司信息 = 7,
        /// <summary>
        /// 轮换图片
        /// </summary>
        轮换图片 = 8,
        /// <summary>
        /// 订单管理
        /// </summary>
        订单管理 = 9,
        /// <summary>
        /// 公告类型
        /// </summary>
        公告类型 = 10,
        /// <summary>
        /// 公告
        /// </summary>
        公告 = 11,
        /// <summary>
        /// 返佣结算
        /// </summary>
        返佣结算 = 12,
        /// <summary>
        /// 订单支付
        /// </summary>
        订单支付 = 13,
        /// <summary>
        /// 车票管理
        /// </summary>
        车票管理 = 14,
        /// <summary>
        /// 门票管理
        /// </summary>
        门票管理 = 15,
        /// <summary>
        /// 机票管理
        /// </summary>
        机票管理 = 16,
        /// <summary>
        /// 微信管理
        /// </summary>
        微信管理 = 17,
        /// <summary>
        /// 会员充值
        /// </summary>
        会员充值 = 18,
        /// <summary>
        /// 微店管理
        /// </summary>
        微店管理 = 19
    }
    #endregion

    #region 资讯类型
    /// <summary>
    /// 资讯类型
    /// </summary>
    public enum ArticleType
    {
        /// <summary>
        /// 旅游资讯
        /// </summary>
        旅游资讯 = 0,
        /// <summary>
        /// 公告
        /// </summary>
        公告,
        /// <summary>
        /// 订购指南
        /// </summary>
        订购指南,
        /// <summary>
        /// 安全指南
        /// </summary>
        安全指南,
        /// <summary>
        /// 支付与取票
        /// </summary>
        支付与取票,
        /// <summary>
        /// 沟通与订阅
        /// </summary>
        沟通与订阅,
        /// <summary>
        /// 会员公告
        /// </summary>
        会员公告,
        /// <summary>
        /// 定制游
        /// </summary>
        定制游
    }
    #endregion

    #region 旅游资讯排序字段
    /// <summary>
    /// 旅游排序字段
    /// </summary>
    public enum TravelArticleFiledOrder
    {
        /// <summary>
        /// 发布时间
        /// </summary>
        IssueTime = 0,
        /// <summary>
        /// 排序规则
        /// </summary>
        SortRule,
        /// <summary>
        /// 首页显示
        /// </summary>
        IsFrontPage,
        /// <summary>
        /// 头条
        /// </summary>
        IsHot,

        /// <summary>
        /// 浏览量
        /// </summary>
        Click

    }
    #endregion

    #region 排序
    /// <summary>
    /// 排序
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// 升序
        /// </summary>
        ASC = 0,
        /// <summary>
        /// 降序
        /// </summary>
        DESC
    }
    #endregion

    #region 行路区域类别
    /// <summary>
    /// 行路区域类别
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// none = 0
        /// </summary>
        请选择 = 0,
        /// <summary>
        /// 国内旅游
        /// </summary>
        国内旅游,
        /// <summary>
        /// 周边旅游
        /// </summary>
        周边旅游,
        /// <summary>
        /// 香港旅游
        /// </summary>
        香港旅游,
        /// <summary>
        /// 欧洲旅游
        /// </summary>
        欧洲旅游,
        /// <summary>
        /// 美洲旅游
        /// </summary>
        美洲旅游,
        /// <summary>
        /// 自由行
        /// </summary>
        自由行
    }
    #endregion

    #region  产品过期类型
    /// <summary>
    /// 产品过期类型
    /// </summary>
    public enum ProductOp
    {
        /// <summary>
        /// 可退款，过期产品可退款
        /// </summary>
        可退款 = 1,
        /// <summary>
        /// 不可退款，过期二维码作废
        /// </summary>
        不可退款 = 2
    }
    #endregion

    #region 机票订单状态
    /// <summary>
    /// 机票订单状态
    /// </summary>
    public enum TickOrderState
    {
        /// <summary>
        /// 未出票
        /// </summary>
        未出票 = 0,
        /// <summary>
        /// 已出票
        /// </summary>
        已出票 = 1

    }

    #endregion

    #region 机票订单支付状态
    /// <summary>
    /// 机票订单状态
    /// </summary>
    public enum TickOrderPayState
    {
        /// <summary>
        /// 未支付
        /// </summary>
        未支付 = 0,
        /// <summary>
        /// 已支付
        /// </summary>
        已支付 = 1,
        /// <summary>
        /// 已出票
        /// </summary>
        已出票 = 2,
        /// <summary>
        /// 已签收
        /// </summary>
        已签收 = 3,
        /// <summary>
        /// 出票中
        /// </summary>
        出票中 = 4,
        /// <summary>
        /// 出票失败
        /// </summary>
        出票失败 = 5,




    }

    #endregion

    #region 消费状态
    /// <summary>
    /// 消费状态
    /// </summary>
    public enum XFstate
    {
        /// <summary>
        /// 未消费
        /// </summary>
        未消费 = 0,
        /// <summary>
        /// 已消费
        /// </summary>
        已消费 = 1

    }

    #endregion

    #region 结算方式
    /// <summary>
    /// 结算方式
    /// </summary>
    public enum JSfangshi
    {
        /// <summary>
        /// 预付
        /// </summary>
        预付 = 0,
        /// <summary>
        /// 现付
        /// </summary>
        现付 = 1

    }
    #endregion

    #region 线路类型
    /// <summary>
    /// 线路类型
    /// </summary>
    public enum XianLu
    {
        /// <summary>
        /// 国内游
        /// </summary>
        国内游 = 0,
        /// <summary>
        /// 国际游
        /// </summary>
        国际游 = 1

    }
    #endregion

    #region 身份类型
    /// <summary>
    /// 身份类型
    /// </summary>
    public enum PersonType
    {
        /// <summary>
        /// 成人
        /// </summary>
        成人 = 0,
        /// <summary>
        /// 儿童
        /// </summary>
        儿童 = 1,
        /// <summary>
        /// 婴儿
        /// </summary>
        婴儿 = 2

    }
    #endregion

    #region 证件类型
    /// <summary>
    /// 证件类型枚举
    /// </summary>
    public enum CardType
    {

        /// <summary>
        /// 身份证
        /// </summary>
        身份证 = 1,
        /// <summary>
        /// 军官证
        /// </summary>
        军官证 = 2,
        /// <summary>
        /// 台胞证
        /// </summary>
        台胞证 = 3,
        /// <summary>
        /// 港澳通行证
        /// </summary>
        港澳通行证 = 4,
        /// <summary>
        /// 户口本
        /// </summary>
        户口本 = 5,
        /// <summary>
        /// 大陆居民
        /// </summary>
        大陆居民 = 6,
        /// <summary>
        /// 往来港澳通行证
        /// </summary>
        往来港澳通行证 = 7,
        /// <summary>
        /// 往来台湾通行证
        /// </summary>
        往来台湾通行证 = 8,
        /// <summary>
        /// 因私护照
        /// </summary>
        因私护照 = 9,
        /// <summary>
        /// 其他
        /// </summary>
        其他 = 0,
    }
    #endregion

    #region 消费方式
    /// <summary>
    /// 消费方式
    /// </summary>
    public enum XFfangshi
    {
        /// <summary>
        /// 充值
        /// </summary>
        充值 = 0,
        /// <summary>
        /// 消费
        /// </summary>
        消费 = 1,
        /// <summary>
        /// 转帐消费
        /// </summary>
        转帐 = 2,
        /// <summary>
        /// 抽奖
        /// </summary>
        红包充值 = 3,
        /// <summary>
        /// 红包抽奖
        /// </summary>
        红包抽奖 = 4

    }
    #endregion

    #region 订单类别
    /// <summary>
    /// 订单类别
    /// </summary>
    public enum DDleibie
    {
        /// <summary>
        /// 机票订单
        /// </summary>
        机票订单 = 0,
        /// <summary>
        /// 旅游订单
        /// </summary>
        旅游订单 = 1,
        /// <summary>
        /// 充值订单
        /// </summary>
        充值订单 = 2,
        /// <summary>
        /// 红包消费
        /// </summary>
        红包消费 = 3


    }

    #endregion

    #region 所有帐户充值和消费金额
    /// <summary>
    /// 订单类别
    /// </summary>
    public enum TotalMoney
    {
        /// <summary>
        /// 机票订单
        /// </summary>
        账户充值金额 = 0,
        /// <summary>
        /// 旅游订单
        /// </summary>
        账户消费金额 = 1


    }

    #endregion

    #region 证件类型
    /// <summary>
    /// 证件类型
    /// </summary>
    public enum CartType
    {
        /// <summary>
        /// 身份证
        /// </summary>
        NI = 0,
        /// <summary>
        /// 护照
        /// </summary>
        FOID = 1,
        /// <summary>
        /// 其他证件
        /// </summary>
        ID = 2


    }

    #endregion

    #region 乘机人类型
    /// <summary>
    /// 乘机人类型
    /// </summary>
    public enum PerType
    {
        /// <summary>
        /// 成人
        /// </summary>
        ADT = 0,
        /// <summary>
        /// 儿童
        /// </summary>
        CHD = 1,

        /// <summary>
        /// 婴儿
        /// </summary>
        INF = 2

    }

    #endregion

    #region 保险订单状态
    /// <summary>
    /// 保险订单状态
    /// </summary>
    public enum InsState
    {
        /// <summary>
        /// 未支付
        /// </summary>
        未支付 = 0,
        /// <summary>
        /// 已支付
        /// </summary>
        已支付 = 1,
        /// <summary>
        /// 已撤单
        /// </summary>
        已撤单 = 2


    }
    #endregion

    #region 微店状态
    /// <summary>
    /// 微店状态
    /// </summary>
    public enum WeiDianStatus
    {
        /// <summary>
        /// 申请中
        /// </summary>
        申请中 = 0,
        /// <summary>
        /// 已开通
        /// </summary>
        已开通 = 1
    }
    #endregion

    #region 管理员类型
    /// <summary>
    /// 管理员类型
    /// </summary>
    public enum WebmasterLeiXing
    {
        /// <summary>
        /// 系统
        /// </summary>
        系统 = 0,
        /// <summary>
        /// 供应商
        /// </summary>
        供应商 = 1
    }
    #endregion

    #region 产品审核状态
    /// <summary>
    /// 产品审核状态
    /// </summary>
    public enum ChanPinShenHeStatus
    {
        /// <summary>
        /// 已审核
        /// </summary>
        已审核 = 0,
        /// <summary>
        /// 未审核
        /// </summary>
        未审核 = 1
    }
    /// <summary>
    /// 会员项目服务
    /// </summary>
    public enum MemberOption
    {
        /// <summary>
        /// 请选择
        /// </summary>
        请选择 = -1,
        /// <summary>
        /// 导游
        /// </summary>
        导游 = 0,
        /// <summary>
        /// 翻译
        /// </summary>
        翻译 = 1,
        /// <summary>
        /// 票务
        /// </summary>
        票务 = 2,
        /// <summary>
        /// 旅游达人
        /// </summary>
        旅游达人 = 3,
        /// <summary>
        /// 旅游玩家
        /// </summary>
        旅游玩家 = 4
    }
    /// <summary>
    /// 消息类别
    /// </summary>
    public enum OptionType
    {
        /// <summary>
        /// 点赞
        /// </summary>
        点赞 = 0,
        /// <summary>
        /// 留言
        /// </summary>
        留言 = 1,
        /// <summary>
        /// 关注
        /// </summary>
        关注 = 2

    }

    #endregion

    #region 游记类型
    public enum YouJiLeiXing
    {
        /// <summary>
        /// 图文游记
        /// </summary>
        图文游记 = 0,
        /// <summary>
        /// 视频游记
        /// </summary>
        视频游记
    }
    #endregion

    #region 支付方式
    /// <summary>
    /// 充值方式
    /// </summary>
    public enum PayWay
    {
        /// <summary>
        /// 微信支付
        /// </summary>
        微信 = 1,
        /// <summary>
        /// 支付宝
        /// </summary>
        支付宝
    }
    #endregion

    #region 抽奖中奖结果
    /// <summary>
    /// 抽奖结果
    /// </summary>
    public enum ChouJiangJieGuo
    {
        /// <summary>
        /// 未中奖
        /// </summary>
        未中奖 = 0,
        /// <summary>
        ///中奖
        /// </summary>
        中奖
    }
    #endregion

    #region 获取奖励方式
    /// <summary>
    /// 获取奖励方式
    /// </summary>
    public enum JiangLiFangShi
    {
        /// <summary>
        /// 未中奖
        /// </summary>
        抽奖 = 0,
        /// <summary>
        ///中奖
        /// </summary>
        分享
    }
    #endregion
}
