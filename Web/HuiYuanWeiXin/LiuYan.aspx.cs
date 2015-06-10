//给我（他她）的留言 汪奇志 2015-02-04
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 给我（他她）的留言
    /// </summary>
    public partial class LiuYan : HuiYuanWeiXinYeMian
    {
        #region attributes
        /// <summary>
        /// 被留言会员编号
        /// </summary>
        protected string HuiYuanId2 = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "tijiaoliuyan") TiJiaoLiuYan();
            if (Utils.GetQueryStringValue("dotype") == "huifuliuyan") HuiFuLiuYan();

            HuiYuanId2 = Utils.GetQueryStringValue("huiyuanid2");
            
            if (string.IsNullOrEmpty(HuiYuanId2))
            {
                if (IsLogin)
                {
                    HuiYuanId2 = HuiYuanInfo.UserID;
                    
                }
            }

            if (string.IsNullOrEmpty(HuiYuanId2))
            {
                YanZhengLogin();
            }
            
            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (IsLogin && HuiYuanId2 == HuiYuanInfo.UserID) ph03.Visible = false;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var items = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetLiuYans(HuiYuanId2);
            if (IsLogin && HuiYuanId2 == HuiYuanInfo.UserID)
            {
                new Eyousoft_yhq.BLL.Member().Update(HuiYuanId2, Eyousoft_yhq.Model.OptionType.留言);
            }

            if (items != null && items.Count > 0)
            {
                ph01.Visible = false;
                ph02.Visible = true;

                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                ph01.Visible = true;
                ph02.Visible = false;

                if (IsLogin && HuiYuanId2 == HuiYuanInfo.UserID)
                {
                    ltrXX01.Text = "还没有人给你留言哦<br/><a href=\"/huiyuanweixin/mingpian.aspx\">赶快把你的微名片分享给朋友吧</a>";
                    this.Title = "给我的留言";
                }
                else
                {
                    ltrXX01.Text = "还没有人给他留言哦<br/><!--<a href=\"javascript:void(0)\"  data-class=\"woyaoliuyan\">我要留言</a>-->";
                    this.Title = "给他（她）的留言";
                }
            }
        }

        /// <summary>
        /// tijiao liuyan
        /// </summary>
        void TiJiaoLiuYan()
        {
            if (!IsLogin) { Utils.RCWE_AJAX("-99", "需要登录后才能留言，你确定要跳转到登录窗口吗？", Request.Url.ToString().ToLower().Replace("dotype", "__dotype")); }

            string txtHuiYuanId2 = Utils.GetFormValue("txtHuiYuanId2");
            string txtLiuYanNeiRong = Utils.GetFormValue("txtLiuYanNeiRong");

            if (string.IsNullOrEmpty(txtHuiYuanId2) || string.IsNullOrEmpty(txtLiuYanNeiRong)) { Utils.RCWE_AJAX("-1", "留言失败，请重试"); }
            if (txtHuiYuanId2 == HuiYuanInfo.UserID) { Utils.RCWE_AJAX("-1", "留言失败：不能给自己留言"); }

            int bllRetCode = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().HuiYuanLiuYan(HuiYuanInfo.UserID, txtHuiYuanId2, txtLiuYanNeiRong);

            if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "留言成功"); }
            else { Utils.RCWE_AJAX("0", "留言失败，请重试"); }
        }

        /// <summary>
        /// huifu liuyan
        /// </summary>
        void HuiFuLiuYan()
        {
            if (!IsLogin) { Utils.RCWE_AJAX("-99", "需要登录后才能回复，你确定要跳转到登录窗口吗？", Request.Url.ToString().ToLower().Replace("dotype", "__dotype")); }

            string txtHuiYuanId1 = Utils.GetFormValue("txtHuiYuanId1");
            string txtHuiYuanId2 = Utils.GetFormValue("txtHuiYuanId2");
            string txtHuiFuNeiRong = Utils.GetFormValue("txtHuiFuNeiRong");
            int txtLiuYanId =Utils.GetInt( Utils.GetFormValue("txtLiuYanId"));

            if (string.IsNullOrEmpty(txtHuiYuanId1) || string.IsNullOrEmpty(txtHuiFuNeiRong) || txtLiuYanId < 1) { Utils.RCWE_AJAX("-1", "回复失败，请重试"); }
            if (txtHuiYuanId2 != HuiYuanInfo.UserID) { Utils.RCWE_AJAX("-1", "回复失败，请重试"); }

            int bllRetCode = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().HuiYuanLiuYan_HuiFu(txtLiuYanId, txtHuiYuanId1, HuiYuanInfo.UserID, txtHuiFuNeiRong);

            if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "回复成功"); }
            else { Utils.RCWE_AJAX("0", "回复失败，请重试"); }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get tuxiang
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetTuXiang(object filepath)
        {
            string defaultfFlepath = "/images/weixin/head_no.png";
            if (filepath == null) return defaultfFlepath;
            string _filepath = filepath.ToString();
            if (string.IsNullOrEmpty(_filepath)) return defaultfFlepath;

            return _filepath;
        }

        /// <summary>
        /// get huifu caozuo
        /// </summary>
        /// <returns></returns>
        protected string GetHuiFuCaoZuo(object huiFuNeiRong)
        {
            if (IsLogin && HuiYuanInfo.UserID == HuiYuanId2)
            {
                if (huiFuNeiRong == null || string.IsNullOrEmpty(huiFuNeiRong.ToString()))
                {
                    return "<a href=\"javascript:void(0)\" class=\"huifu\" data-class=\"huifu\">回复</a>";
                }

                return string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取留言时间
        /// </summary>
        /// <param name="liuYanTime"></param>
        /// <returns></returns>
        protected string GetLiuYanTime(object liuYanTime)
        {
            if (liuYanTime == null) return string.Empty;
            var _liuYanTime = (DateTime)liuYanTime;

            TimeSpan ts1 = new TimeSpan(_liuYanTime.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts3 = ts2.Subtract(ts1).Duration();

            var minutes = ts3.TotalMinutes;

            if (minutes <= 1)
            {
                return "1分钟前";
            }
            else if (minutes <= 3)
            {
                return "3分钟前";
            }
            else if (minutes <= 15)
            {
                return "15分钟前";
            }
            else if (minutes <= 30)
            {
                return "30分钟前";
            }
            else if (minutes <= 60)
            {
                return "1小时前";
            }
            else if (minutes <= 120)
            {
                return "2小时前";
            }
            else if (minutes <= 180)
            {
                return "3小时前";
            }
            else if (minutes <= 360)
            {
                return "6小时前";
            }
            else if (minutes <= 1440)
            {
                return "1天前";
            }
            else if (minutes <= 2880)
            {
                return "2天前";
            }
            else if (minutes <= 10080)
            {
                return "1星期前";
            }

            return _liuYanTime.ToString("yyyy-MM-dd");
        }
        #endregion
    }
}
