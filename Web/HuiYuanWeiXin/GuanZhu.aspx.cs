//关注（我他她）的人 汪奇志 2015-02-04
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 关注（我他她）的人
    /// </summary>
    public partial class GuanZhu : HuiYuanWeiXinYeMian
    {
        #region attributes
        /// <summary>
        /// 被关注计数
        /// </summary>
        protected int BeiGuanZhuJiShu = 0;
        /// <summary>
        /// 我关注计数
        /// </summary>
        protected int WoGuanZhuJiShu = 0;
        /// <summary>
        /// 被关注会员编号
        /// </summary>
        protected string HuiYuanId2 = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            HuiYuanId2 = Utils.GetQueryStringValue("huiyuanid2");

            if (Utils.GetQueryStringValue("dotype") == "woyaoguanzhu") WoYaoGuanZhu();
            if (Utils.GetQueryStringValue("dotype") == "quxiaoguanzhu") QuXiaoGuanZhu();

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
            
            InitRpt2();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var huiYuanInfo = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanId2);
            if (huiYuanInfo == null) { RedirectLogin("/huiyuanweixin/mingpian.aspx"); }

            BeiGuanZhuJiShu = huiYuanInfo.GuanZhuJiShu;

            if (BeiGuanZhuJiShu == 0)
            {
                ph01.Visible = true;
                ph02.Visible = false;

                if (IsLogin && huiYuanInfo.UserID == HuiYuanInfo.UserID)
                {
                    new Eyousoft_yhq.BLL.Member().Update(HuiYuanId2, Eyousoft_yhq.Model.OptionType.关注);
                    ltrXX01.Text = "还没有人关注你哦<br/><a class=\"font_blue\" href=\"/huiyuanweixin/mingpian.aspx\">赶快把你的微名片分享给朋友吧</a>";
                    this.Title = "关注我的人";
                }
                else
                {
                    ltrXX01.Text = "还没有人关注他（她）哦<br/><!--<a href=\"javascript:void(0)\" id=\"a_woyaoguanzhu\">我要关注</a>-->";
                    this.Title = "关注他（她）的人";
                }
            }
            else
            {
                ph01.Visible = false;
                ph02.Visible = true;

                if (IsLogin && huiYuanInfo.UserID == HuiYuanInfo.UserID)
                {
                    new Eyousoft_yhq.BLL.Member().Update(HuiYuanId2, Eyousoft_yhq.Model.OptionType.关注);
                    ltrXX02.Text = "关注我的人";
                    this.Title = "关注我的人";
                }
                else
                {
                    ltrXX02.Text = "关注他（她）的人";
                    this.Title = "关注他（她）的人";
                }

                InitRpt1();
            }

            if (IsLogin && HuiYuanInfo.UserID == HuiYuanId2) ph04.Visible = false;

        }

        /// <summary>
        /// init repeater 01
        /// </summary>
        void InitRpt1()
        {
            var items = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetGuanZhus(HuiYuanId2);

            rpt01.DataSource = items;
            rpt01.DataBind();
        }

        /// <summary>
        /// init repeater 02
        /// </summary>
        void InitRpt2()
        {
            if (!IsLogin) return;

            var items = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetGuanZhus1(HuiYuanInfo.UserID);

            if (items != null&&items.Count>0)
            {
                rpt02.DataSource = items;
                rpt02.DataBind();
                ph03.Visible = true;

                WoGuanZhuJiShu = items.Count;
            }
        }

        /// <summary>
        /// wo yao guanzhu
        /// </summary>
        void WoYaoGuanZhu()
        {
            if (!IsLogin) { Utils.RCWE_AJAX("-99", "需要登录后才能关注，你确定要跳转到登录窗口吗？", Request.Url.ToString().ToLower().Replace("dotype", "__dotype")); }

            string txtHuiYuanId2 = Utils.GetFormValue("txtHuiYuanId2");
            var bllRetCode = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().HuiYuanGuanZhu(HuiYuanInfo.UserID, txtHuiYuanId2);

            if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "关注成功"); }
            else { Utils.RCWE_AJAX("0", "关注失败，请重试"); }
        }

        /// <summary>
        /// quxiao guanzhu
        /// </summary>
        void QuXiaoGuanZhu()
        {
            if (!IsLogin) { Utils.RCWE_AJAX("-99", "需要登录后才能取消关注，你确定要跳转到登录窗口吗？", Request.Url.ToString().ToLower().Replace("dotype", "__dotype")); }

            string txtHuiYuanId1 = Utils.GetFormValue("txtHuiYuanId1");
            string txtHuiYuanId2 = Utils.GetFormValue("txtHuiYuanId2");
            int txtGuanZhuId = Utils.GetInt(Utils.GetFormValue("txtGuanZhuId"));

            if (HuiYuanInfo.UserID != txtHuiYuanId1) { Utils.RCWE_AJAX("0", "取消关注失败，请重试"); }

            var bllRetCode = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().HuiYuanGuanZhu_QuXiao(txtGuanZhuId, txtHuiYuanId1, txtHuiYuanId2);

            if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "取消关注成功"); }
            else { Utils.RCWE_AJAX("0", "取消关注失败，请重试"); }
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
        #endregion
    }
}
