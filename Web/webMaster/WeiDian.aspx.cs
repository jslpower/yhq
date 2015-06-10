//微店管理 汪奇志 2015-01-20
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    /// <summary>
    /// 微店管理
    /// </summary>
    public partial class WeiDian : EyouSoft.Common.Page.webmasterPage
    {
        #region attributes
        protected int PageSize = 20;
        protected int PageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CheckGrantMenu2(Eyousoft_yhq.Model.Privs.微店管理)) { Utils.RCWE_AJAX("0", "没有权限"); }
            if (Utils.GetQueryStringValue("dotype") == "shenhe") ShenHe();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        Eyousoft_yhq.Model.MWeiDianChaXunInfo GetChaXunInfo()
        {
            var info = new Eyousoft_yhq.Model.MWeiDianChaXunInfo();

            info.MingCheng = Utils.GetQueryStringValue("txtMingCheng");
            info.Status = (Eyousoft_yhq.Model.WeiDianStatus?)Utils.GetEnumValueNull(typeof(Eyousoft_yhq.Model.WeiDianStatus), Utils.GetQueryStringValue("txtStatus"));

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            PageIndex = UtilsCommons.GetPagingIndex();
            var chaXun = GetChaXunInfo();

            int recordCount = 0;
            var items = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDians(PageSize, PageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                FenYe.intPageSize = PageSize;
                FenYe.CurrencyPage = PageIndex;
                FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// shenhe
        /// </summary>
        void ShenHe()
        {
            string txtWeiDianId = Utils.GetFormValue("txtWeiDianId");

            if (string.IsNullOrEmpty(txtWeiDianId)) Utils.RCWE_AJAX("0", "请选择需要审核的微店信息");

            var bllRetCode = new Eyousoft_yhq.BLL.BWeiDian().WeiDian_ShenHe(txtWeiDianId);

            if (bllRetCode == 1)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else if (bllRetCode == -1)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else
            {
                Utils.RCWE_AJAX("0", "操作失败");
            }

        }
        #endregion

        #region protected members
        /// <summary>
        /// get shenhe time
        /// </summary>
        /// <param name="shenHeTime"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetShenHeTime(object shenHeTime, object status)
        {
            var _status = (Eyousoft_yhq.Model.WeiDianStatus)status;

            if (_status == Eyousoft_yhq.Model.WeiDianStatus.已开通)
            {
                return ((DateTime)shenHeTime).ToString("yyyy-MM-dd HH:mm");
            }

            return string.Empty;
        }

        /// <summary>
        /// get caozuo
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetCaoZuo(object status)
        {
            string s1 = "<a href=\"javascript:void(0)\" class=\"chakan\">查看</a>";
            string s2 = "<a href=\"javascript:void(0)\" class=\"shenhe\">开通微店</a>";
            string s3 = "&nbsp;";
            var _status = (Eyousoft_yhq.Model.WeiDianStatus)status;

            if (_status == Eyousoft_yhq.Model.WeiDianStatus.申请中)
            {
                return s1 + s3 + s2;
            }

            return s1;
        }
        #endregion
    }
}
