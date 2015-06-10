//微信相关BLL 汪奇志 2014-01-14
using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 微信相关BLL
    /// </summary>
    public class BWeiXin
    {
        readonly Eyousoft_yhq.SQLServerDAL.DWeiXin dal = new Eyousoft_yhq.SQLServerDAL.DWeiXin();

        #region private members
        /// <summary>
        /// 微信用户新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int YongHu_C(Eyousoft_yhq.Model.MWeiXinYongHuInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.openid)) return 0;

            info.YongHuId = Guid.NewGuid().ToString();
            info.createtime = info.latesttime = DateTime.Now;

            int dalRetCode = dal.YongHu_CU(info);
            return dalRetCode;
        }
        #endregion

        #region public members
        /// <summary>
        /// 微信用户修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int YongHu_U(Eyousoft_yhq.Model.MWeiXinYongHuInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.openid) || string.IsNullOrEmpty(info.YongHuId)) return 0;

            info.latesttime = DateTime.Now;

            int dalRetCode = dal.YongHu_CU(info);
            return dalRetCode;
        }

        /// <summary>
        /// 获取微信用户信息，按用户编号
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiXinYongHuInfo GetInfo1(string yongHuId)
        {
            if (string.IsNullOrEmpty(yongHuId)) return null;

            return dal.GetInfo1(yongHuId);
        }

        /// <summary>
        /// 获取微信用户信息，按openid编号
        /// </summary>
        /// <param name="openid">openid</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiXinYongHuInfo GetInfo2(string openid)
        {
            if (string.IsNullOrEmpty(openid)) return null;

            return dal.GetInfo2(openid);
        }

        /// <summary>
        /// 获取微信用户信息，按用户编号
        /// </summary>
        /// <param name="huiyuanID">用户编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiXinYongHuInfo GetInfo3(string huiyuanID)
        {
            if (string.IsNullOrEmpty(huiyuanID)) return null;

            return dal.GetInfo3(huiyuanID);
        }

        /// <summary>
        /// 关注，取消关注，返回1成功，其它失败
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="subscribe">1关注 0取消关注</param>
        /// <returns></returns>
        public int GuanZhu(string openid, string subscribe)
        {
            if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(subscribe)) return 0;
            if (subscribe != "0" && subscribe != "1") return 0;

            var info = GetInfo2(openid);

            if (info == null)
            {
                info = new Eyousoft_yhq.Model.MWeiXinYongHuInfo();
                info.YongHuId = Guid.NewGuid().ToString();
                info.openid = openid;
            }

            info.subscribe = subscribe;
            info.createtime = info.latesttime = DateTime.Now;

            var dalRetCode = dal.YongHu_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// 绑定会员，返回1成功，其它失败
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="openid">openid</param>
        /// <param name="u">用户名</param>
        /// <param name="p">密码</param>
        /// <param name="huiYuanId">out 会员编号</param>
        /// <returns></returns>
        public int BangDingHuiYuan(string yongHuId, string openid, string u, string p, out string huiYuanId)
        {
            huiYuanId = string.Empty;
            if (string.IsNullOrEmpty(yongHuId) || string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p)) return 0;

            int dalRetCode = dal.BangDingHuiYuan(yongHuId, openid, u, p, out huiYuanId);

            return dalRetCode;
        }
        #endregion
    }
}
