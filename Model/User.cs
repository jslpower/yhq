using System;
using System.Collections.Generic;
namespace Eyousoft_yhq.Model
{
    #region 用户表
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 会员
        /// </summary>
        public User()
        { }
        #region Model
        private string _userid;
        private string _username;
        private string _userpwd;
        private string _contactname;
        private sexType _contactsex;
        private string _remark;
        private DateTime _issuetime;
        private string _contacttel;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string ContactName
        {
            set { _contactname = value; }
            get { return _contactname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public sexType ContactSex
        {
            set { _contactsex = value; }
            get { return _contactsex; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel
        {
            set { _contacttel = value; }
            get { return _contacttel; }
        }
        /// <summary>
        /// 用户地址
        /// </summary>
        public IList<UserAddress> AddressList { get; set; }
        /// <summary>
        /// 返佣
        /// </summary>
        public decimal CommissonScale { get; set; }
        /// <summary>
        /// 是否代理
        /// </summary>
        public bool IsAgent { get; set; }

        /// <summary>
        /// 交易次数
        /// </summary>
        public int OrderCount { get; set; }
        /// <summary>
        /// 注册码
        /// </summary>
        public string PollCode { get; set; }
        /// <summary>
        /// 推广码
        /// </summary>
        public string PromotionCode { get; set; }
        /// <summary>
        /// 推广次数
        /// </summary>
        public int PromotionCount { get; set; }
        /// <summary>
        /// 用户是否通过验证
        /// </summary>
        public bool valiUser { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal YuE { get; set; }
        /// <summary>
        /// 是否允许转账
        /// </summary>
        public bool IsZZ { get; set; }

        #endregion Model

        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiXinHao { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string GongSiName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string ZhiWei { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string ShouJi { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        public string TuXiangFilepath { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 项目服务
        /// </summary>
        public MemberOption MemberOption { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string YouXiang { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string DiZhi { get; set; }
        /// <summary>
        /// 是否旅游顾问
        /// </summary>
        public bool IsLvYouGuWen { get; set; }
        /// <summary>
        /// 旅游顾问认证时间
        /// </summary>
        public DateTime LvYouGuWenRenZhengTime { get; set; }

        /// <summary>
        /// 赞计数（被点赞）
        /// </summary>
        public int ZanJiShu { get; set; }
        /// <summary>
        /// 关注计数（被关注）
        /// </summary>
        public int GuanZhuJiShu { get; set; }
        /// <summary>
        /// 留言计数（被留言）
        /// </summary>
        public int LiuYanJiShu { get; set; }
        /// <summary>
        /// 名片编号
        /// </summary>
        public string MingPianId { get; set; }
        /// <summary>
        /// 省份Id
        /// </summary>
        public int ProviceId { get; set; }
        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 区县Id
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 街道乡镇Id
        /// </summary>
        public int StreetId { get; set; }
    }
    #endregion

    #region 会员联系地址
    /// <summary>
    /// 会员联系地址
    /// </summary>
    public class UserAddress
    {
        public UserAddress() { }

        /// <summary>
        /// 地址编号
        /// </summary>
        public string AddressID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int AddressProvince { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int AddressCity { get; set; }
        /// <summary>
        /// 县区编号
        /// </summary>
        public int AddressCountry { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 收货人名称
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZpCode { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobileNum { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string TelNum { get; set; }
        /// <summary>
        /// 省份 
        /// </summary>
        public string AddressProvinceName { get; set; }
        /// <summary>
        /// 城市 
        /// </summary>
        public string AddressCityName { get; set; }
        /// <summary>
        /// 县区 
        /// </summary>
        public string AddressCountryName { get; set; }

    }
    #endregion

    #region MSearchUser
    public class MSearchUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 推广码
        /// </summary>
        public string PromotionCode { get; set; }
        /// <summary>
        /// 是否旅游顾问
        /// </summary>
        public bool? IsLvYouGuWen { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        public MemberOption? MemberOption { get; set; }
        /// <summary>
        /// 省份Id
        /// </summary>
        public int ProviceId { get; set; }
        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 区县Id
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 街道乡镇Id
        /// </summary>
        public int StreetId { get; set; }
    }
    #endregion

    #region MSearchUserAddress
    public class MSearchUserAddress
    {

    }
    #endregion

    #region 名片信息业务实体
    /// <summary>
    /// 名片信息业务实体
    /// </summary>
    public class MMingPianInfo
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 名片编号
        /// </summary>
        public string MingPianId { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string ShouJi { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiXinHao { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string XingMing { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string ZhiWei { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string GongSiName { get; set; }
        /// <summary>
        /// 赞计数
        /// </summary>
        public int ZanJiShu { get; set; }
        /// <summary>
        /// 关注计数
        /// </summary>
        public int GuanZhuJiShu { get; set; }
        /// <summary>
        /// 留言计数
        /// </summary>
        public int LiuYanJiShu { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        public string TuXiangFilepath { get; set; }
        /// <summary>
        /// 最后查看点赞时间
        /// </summary>
        public DateTime DianZanTime { get; set; }
        /// <summary>
        /// 最后查看留言时间
        /// </summary>
        public DateTime LiuYanTime { get; set; }
        /// <summary>
        /// 最后查看关注时间
        /// </summary>
        public DateTime GuanZhuTime { get; set; }
    }
    #endregion

    #region 省市区县镇乡实体
    /// <summary>
    /// 省市区县镇乡实体
    /// </summary>
    public class Pro_City_Area_Street
    {
        /// <summary>
        /// 主ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int level { get; set; }
    }
    /// <summary>
    /// 省市区县镇乡查询实体
    /// </summary>
    public class Pro_City_Area_StreetSer
    {
        /// <summary>
        /// 主ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int level { get; set; }
    }
    #endregion
}

