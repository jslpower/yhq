//微店首页 汪奇志 2015-01-16
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.WeiDian
{
    /// <summary>
    /// 微店首页
    /// </summary>
    public partial class Default : WeiDianYeMian
    {
        #region attributes
        /// <summary>
        /// 微店logo文件路径
        /// </summary>
        protected string WeiDianLogoFilepath = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            phGL.Visible = IsLogin;

            var info = new Eyousoft_yhq.BLL.BWeiDian().GetInfo(WeiDianId);

            ltrWeiDianName.Text = info.MingCheng;
            ltrWeiDianDianHua.Text = "<a href='tel:" + info.DianHua + "'>" + info.DianHua + "</a>";
            ltrWeiDianJieShao.Text = info.JieShao;

            var member = new Eyousoft_yhq.BLL.Member().GetModel(info.HuiYuanId);
            
            string defaultfFlepath = "/images/weixin/head_no.png";
            if (member != null)
            {
                if (!string.IsNullOrEmpty(member.TuXiangFilepath))
                    imgHead.Src = member.TuXiangFilepath;
                else
                    imgHead.Src = defaultfFlepath;
            }

            WeiDianLogoFilepath = info.LogoFilepath;
            if (string.IsNullOrEmpty(WeiDianLogoFilepath)) WeiDianLogoFilepath = "/images/weixin/home_img.png";

            this.Title = info.MingCheng + "-微店";
        }
        #endregion
    }
}
