//微店相关BLL 汪奇志 2015-01-16
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Eyousoft_yhq.BLL
{
    /// <summary>
    /// 微店相关BLL
    /// </summary>
    public class BWeiDian
    {
        readonly Eyousoft_yhq.SQLServerDAL.DWeiDian dal = new Eyousoft_yhq.SQLServerDAL.DWeiDian();
        public BWeiDian() { }

        #region public static members
        /// <summary>
        /// 跳转至指定会员微店，且自动登录该会员，需要经过微信授权后调整
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="openid">weixin openid</param>
        public static void redirect_huiyuan_weidian(string huiYuanId, string weixin_openid)
        {
            var response = HttpContext.Current.Response;

            if (string.IsNullOrEmpty(weixin_openid)) { response.Redirect("/huiyuanweixin/login.aspx?rt=1"); }

            var weixin_yonghu_info = new Eyousoft_yhq.BLL.BWeiXin().GetInfo2(weixin_openid);
            if (weixin_yonghu_info == null || weixin_yonghu_info.HuiYuanId != huiYuanId) { response.Redirect("/huiyuanweixin/login.aspx?rt=1"); }

            EyouSoft.Model.SSOStructure.MUserInfo huiYuanInfo;
            int autoLoginRetCode = Eyousoft_yhq.BLL.MemberLogin.AutoLogin(huiYuanId, out huiYuanInfo);

            if (autoLoginRetCode != 1) { response.Redirect("/huiyuanweixin/login.aspx?rt=1"); }
            if (string.IsNullOrEmpty(huiYuanInfo.WeiDianId)) { response.Redirect("/weidian/shenqing.aspx"); }

            response.Redirect(string.Format("/weidian/default.aspx?weidianid={0}", huiYuanInfo.WeiDianId));
        }

        /// <summary>
        /// 跳转至指定会员微店
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        public static void redirect_huiyuan_weidian(string huiYuanId)
        {
            var response = HttpContext.Current.Response;

            var weiDianId = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianId(huiYuanId);

            if (string.IsNullOrEmpty(weiDianId)) response.Redirect(string.Format("/weidian/notfound.aspx"));

            response.Redirect(string.Format("/weidian/default.aspx?weidianid={0}", weiDianId));
        }
        #endregion

        #region public members
        /// <summary>
        /// 获取微店编号，按会员编号
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public string GetWeiDianId(string huiYuanId)
        {
            if (string.IsNullOrEmpty(huiYuanId)) return string.Empty;

            return dal.GetWeiDianId(huiYuanId);
        }

        /// <summary>
        /// 微店新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int WeiDian_C(Eyousoft_yhq.Model.MWeiDianInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.HuiYuanId) || string.IsNullOrEmpty(info.MingCheng)) return 0;

            info.ShenQingTime = info.ShenHeTime = DateTime.Now;
            info.WeiDianId = Guid.NewGuid().ToString();
            info.Status = Eyousoft_yhq.Model.WeiDianStatus.申请中;

            int dalRetCode = dal.WeiDian_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// 微店修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int WeiDian_U(Eyousoft_yhq.Model.MWeiDianInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.HuiYuanId) || string.IsNullOrEmpty(info.MingCheng) || string.IsNullOrEmpty(info.WeiDianId)) return 0;

            var info1 = GetInfo(info.WeiDianId);
            if (info1 == null) return 0;

            info.Status = info1.Status;

            info.ShenQingTime = info.ShenHeTime = DateTime.Now;
            int dalRetCode = dal.WeiDian_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// 获取微店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <returns></returns>
        public Eyousoft_yhq.Model.MWeiDianInfo GetInfo(string weiDianId)
        {
            if (string.IsNullOrEmpty(weiDianId)) return null;
            return dal.GetInfo(weiDianId);
        }

        /// <summary>
        /// 微店审核，返回1成功，其它失败
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <returns></returns>
        public int WeiDian_ShenHe(string weiDianId)
        {
            if (string.IsNullOrEmpty(weiDianId)) return 0;
            var info = GetInfo(weiDianId);

            if (info == null) return 0;

            if (info.Status == Eyousoft_yhq.Model.WeiDianStatus.已开通) return -1;

            info.Status = Eyousoft_yhq.Model.WeiDianStatus.已开通;
            info.ShenHeTime = DateTime.Now;
            int dalRetCode = dal.WeiDian_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// 获取微店信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianInfo> GetWeiDians(int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MWeiDianChaXunInfo chaXun)
        {
            return dal.GetWeiDians(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 微店产品添加，返回1成功，其它失败
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="chanPinId">产品编号</param>
        /// <returns></returns>
        public int WeiDianChanPin_C(string weiDianId, string huiYuanId, string chanPinId)
        {
            int dalRetCode = dal.WeiDianChanPinGuanXi_CD(weiDianId, huiYuanId, 0, chanPinId, "C", DateTime.Now);
            return dalRetCode;
        }

        /// <summary>
        /// 微店产品添加，返回1成功，其它失败
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="guanXiId">关系编号</param>
        /// <param name="chanPinId">产品编号</param>
        /// <returns></returns>
        public int WeiDianChanPin_D(string weiDianId, string huiYuanId, int guanXiId, string chanPinId)
        {
            int dalRetCode = dal.WeiDianChanPinGuanXi_CD(weiDianId, huiYuanId, guanXiId, chanPinId, "D", DateTime.Now);
            return dalRetCode;
        }

        /// <summary>
        /// 获取微店产品信息集合
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<Eyousoft_yhq.Model.MWeiDianChanPinInfo> GetWeiDianChanPins(string weiDianId, Eyousoft_yhq.Model.MWeiDianChanPinChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(weiDianId)) return null;

            return dal.GetWeiDianChanPins(weiDianId, chaXun);
        }

        /// <summary>
        /// 获取微店产品信息集合
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianChanPinInfo> GetWeiDianChanPins(string weiDianId, int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MWeiDianChanPinChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(weiDianId)) return null;

            return dal.GetWeiDianChanPins(weiDianId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 判断微店是否添加指定产品
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="chanPinId">产品编号</param>
        /// <returns></returns>
        public bool ShiFouTianJiaChanPin(string weiDianId, string chanPinId)
        {
            if (string.IsNullOrEmpty(weiDianId) || string.IsNullOrEmpty(chanPinId)) return false;

            return dal.ShiFouTianJiaChanPin(weiDianId, chanPinId);
        }

        /// <summary>
        /// 获取微店订单信息集合
        /// </summary>
        /// <param name="weiDianId">微店编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Eyousoft_yhq.Model.MWeiDianDingDanInfo> GetWeiDianDingDans(string weiDianId, int pageSize, int pageIndex, ref int recordCount, Eyousoft_yhq.Model.MWeiDianDingDanChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(weiDianId)) return null;

            return dal.GetWeiDianDingDans(weiDianId, pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
