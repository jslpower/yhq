//微店信息查看 汪奇志 2015-01-20
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    /// <summary>
    /// 微店信息查看
    /// </summary>
    public partial class WeiDianEdit : EyouSoft.Common.Page.webmasterPage
    {
        #region attributes
        string WeiDianId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CheckGrantMenu2(Eyousoft_yhq.Model.Privs.微店管理)) { Utils.RCWE_AJAX("0", "没有权限"); }

            WeiDianId = Utils.GetQueryStringValue("weidianid");

            if (string.IsNullOrEmpty(WeiDianId)) RCWE("异常请求");

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new Eyousoft_yhq.BLL.BWeiDian().GetInfo(WeiDianId);
            if (info == null) RCWE("异常请求");

            ltrYongHuMing.Text = info.YongHuMing;
            ltrHuiYuanName.Text = info.HuiYuanName;
            ltrMingCheng.Text = info.MingCheng;
            ltrJieShao.Text = info.JieShao;
            ltrStatus.Text = info.Status.ToString();
            ltrShenQingTime.Text = info.ShenQingTime.ToString("yyyy-MM-dd HH:mm");

            if (info.Status == Eyousoft_yhq.Model.WeiDianStatus.已开通)
            {
                ltrShenHeTime.Text = info.ShenHeTime.ToString("yyyy-MM-dd HH:mm");
            }
        }
        #endregion
    }
}
