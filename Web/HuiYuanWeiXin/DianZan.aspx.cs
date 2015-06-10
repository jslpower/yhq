//点赞（我他她）的人 汪奇志 2015-02-04
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 点赞（我他她）的人
    /// </summary>
    public partial class DianZan : HuiYuanWeiXinYeMian
    {
        #region attributes
        /// <summary>
        /// 被点赞计数
        /// </summary>
        protected int BeiDianZanJiShu = 0;
        /// <summary>
        /// 被点赞会员编号
        /// </summary>
        protected string HuiYuanId2 = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            HuiYuanId2 = Utils.GetQueryStringValue("huiyuanid2");

            if (Utils.GetQueryStringValue("dotype") == "woyaodianzan") WoYaoDianZan();

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
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var huiYuanInfo = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanId2);
            if (huiYuanInfo == null) { RedirectLogin("/huiyuanweixin/mingpian.aspx");  }

            BeiDianZanJiShu = huiYuanInfo.ZanJiShu;

            if (BeiDianZanJiShu == 0)
            {
                ph01.Visible = true;
                ph02.Visible = false;

                if (IsLogin && huiYuanInfo.UserID == HuiYuanInfo.UserID)
                {
                    new Eyousoft_yhq.BLL.Member().Update(HuiYuanId2, Eyousoft_yhq.Model.OptionType.点赞);
                    ltrXX01.Text = "还没有人为你点赞哦<br/><a class=\"font_blue\" href=\"/huiyuanweixin/mingpian.aspx\">赶快把你的微名片分享给朋友吧</a>";
                    this.Title = "点赞我的人";
                }
                else
                {
                    ltrXX01.Text = "还没有人为他（她）点赞哦<br/><!--<a href=\"javascript:void(0)\" id=\"a_woyaodianzan\">我要点赞</a>-->";
                    this.Title = "点赞他（她）的人";
                }
            }
            else
            {
                ph01.Visible = false;
                ph02.Visible = true;

                if (IsLogin && huiYuanInfo.UserID == HuiYuanInfo.UserID)
                {
                    new Eyousoft_yhq.BLL.Member().Update(HuiYuanId2, Eyousoft_yhq.Model.OptionType.点赞);
                    ltrXX02.Text = "点赞我的人";
                    this.Title = "点赞我的人";
                }
                else
                {
                    ltrXX02.Text = "点赞他（她）的人";
                    this.Title = "点赞他（她）的人";
                }

                InitRpt();
            }

            if (IsLogin && HuiYuanInfo.UserID == HuiYuanId2) ph03.Visible = false;

        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var items = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetDianZans(HuiYuanId2);

            rpt01.DataSource = items;
            rpt01.DataBind();
        }

        /// <summary>
        /// wo yao dian zan
        /// </summary>
        void WoYaoDianZan()
        {
            if (!IsLogin) { Utils.RCWE_AJAX("-99", "需要登录后才能点赞，你确定要跳转到登录窗口吗？", Request.Url.ToString().ToLower().Replace("dotype", "__dotype")); }

            string txtHuiYuanId2 = Utils.GetFormValue("txtHuiYuanId2");
            var bllRetCode = new Eyousoft_yhq.BLL.BHuiYuanGuanXi().HuiYuanDianZan(HuiYuanInfo.UserID, txtHuiYuanId2);

            if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "点赞成功"); }
            else { Utils.RCWE_AJAX("0", "点赞失败，请重试"); }
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
            string defaultfFlepath= "/images/weixin/head_no.png";
            if (filepath == null) return defaultfFlepath;
            string _filepath = filepath.ToString();
            if (string.IsNullOrEmpty(_filepath)) return defaultfFlepath;

            return _filepath;
        }
        #endregion
    }
}
