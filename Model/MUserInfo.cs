using System;
using System.Collections.Generic;
using System.Text;

namespace EyouSoft.Model.SSOStructure
{
    #region 登录用户信息业务实体
    /// <summary>
    /// 登录用户信息业务实体
    /// </summary>
    [Serializable]
    public class MUserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Eyousoft_yhq.Model.sexType ContactSex { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 是否管理员/是否代理（1是0否）
        /// </summary>
        public string IsAdmin { get; set; }
        /// <summary>
        /// 用户状态(1正常、2停用...)
        /// </summary>
        public int UserState { get; set; }
        /// <summary>
        /// 权限明细
        /// </summary>
        public string Privs { get; set; }
        /// <summary>
        /// 推广码（代理商专用）
        /// </summary>
        public string PromotionCode { get; set; }
        /// <summary>
        /// 用户是否通过验证
        /// </summary>
        public bool valiUser { get; set; }
        /// <summary>
        /// 是否允许转账
        /// </summary>
        public bool IsZZ { get; set; }
        /// <summary>
        /// 微店编号
        /// </summary>
        public string WeiDianId { get; set; }
        /// <summary>
        /// 名片编号
        /// </summary>
        public string MingPianId { get; set; }

    }
    #endregion
}
