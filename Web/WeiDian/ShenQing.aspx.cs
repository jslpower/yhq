//微店申请 汪奇志 2015-01-19
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiDian
{
    /// <summary>
    /// 微店申请
    /// </summary>
    public partial class ShenQing : WeiDianYeMian
    {
        #region attributes
        /// <summary>
        /// 微店编号
        /// </summary>
        protected string WeiDianId = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "shenqing") ShenQing1();

            //YanZhengLogin();
            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            WeiDianId = HuiYuanInfo.WeiDianId;
            ltrYongHuMing.Text = HuiYuanInfo.UserName;
            ltrXingMing.Text = HuiYuanInfo.ContactName;
        }

        /// <summary>
        /// weidian shenqing
        /// </summary>
        void ShenQing1()
        {
            if (!IsLogin) { Utils.RCWE_AJAX("-1", "请先登录后再申请开通微店"); }

            if (!string.IsNullOrEmpty(HuiYuanInfo.WeiDianId)) { Utils.RCWE_AJAX("-2", "你已经申请开通过微店", HuiYuanInfo.WeiDianId); }

            var info = new Eyousoft_yhq.Model.MWeiDianInfo();
            info.HuiYuanId = HuiYuanInfo.UserID;
            info.JieShao = Utils.GetFormValue("txtJieShao");
            info.MingCheng = Utils.GetFormValue("txtMingCheng");
            info.ShenHeTime = DateTime.Now;
            info.ShenQingTime = DateTime.Now;
            info.Status = Eyousoft_yhq.Model.WeiDianStatus.申请中;
            info.WeiDianId = Guid.NewGuid().ToString();
            info.DianHua = Utils.GetFormValue("txtDianHua");

            int bllRetCode = new Eyousoft_yhq.BLL.BWeiDian().WeiDian_C(info);

            if (bllRetCode == 1)
            {
                Utils.RCWE_AJAX("1", "申请成功，请等待审核后为你开通微店", info.WeiDianId);
            }
            else
            {
                Utils.RCWE_AJAX("0", "申请失败，请重试");
            }
        }
        #endregion
    }
}
