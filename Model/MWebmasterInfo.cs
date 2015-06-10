using System;
using System.Collections.Generic;
using System.Text;

namespace EyouSoft.Model.SSOStructure
{
    #region webmaster登录信息业务实体
    /// <summary>
    /// webmaster登录信息业务实体
    /// </summary>
    public class MWebmasterInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string XingMing { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 管理员类型
        /// </summary>
        public Eyousoft_yhq.Model.WebmasterLeiXing LeiXing { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Eyousoft_yhq.Model.sexType XingBie { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Privs { get; set; }
    }
    #endregion

    #region 管理员信息业务实体
    /// <summary>
    /// 管理员信息业务实体
    /// </summary>
    public class MGuanLiYuanInfo : MWebmasterInfo
    {
        /// <summary>
        /// 公章
        /// </summary>
        public string GongZhangFilepath { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string MiMa { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string BeiZhu { get; set; }


    }
    #endregion

    #region 管理员信息查询业务实体
    /// <summary>
    /// 管理员信息查询业务实体
    /// </summary>
    public class MGuanLiYuanChaXunInfo
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string XingMing { get; set; }
    }
    #endregion
}
