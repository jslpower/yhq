using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class PlanInsList : EyouSoft.Common.Page.webmasterPage
    {

        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitOrders();
            }
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void InitOrders()
        {

            #region 查询实体
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = new Eyousoft_yhq.BLL.BPlanIns().GetList(pageSize, pageIndex, ref recordCount, null);
            if (list != null && list.Count > 0)
            {
                rpt_orders.DataSource = list;
                rpt_orders.DataBind();
                BindPage();
                litMsg.Visible = false;

            }
            else
            {
                rpt_orders.Visible = false;
            }
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        }


    }
}
