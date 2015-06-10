using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class AppOrderList : EyouSoft.Common.Page.webmasterPage
    {

        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitOrders();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void InitOrders()
        {

            Eyousoft_yhq.BLL.Order bll = new Eyousoft_yhq.BLL.Order();

            #region 查询实体
            Eyousoft_yhq.Model.MSearchOrder serchModel = new Eyousoft_yhq.Model.MSearchOrder();
            serchModel.OrderCode = Utils.GetQueryStringValue("orderCode");
            serchModel.ConfirmCode = Utils.GetQueryStringValue("ConfirmCode");
            serchModel.STime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("StartTime"));
            serchModel.ETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("EndTime"));
            serchModel.AppUser = Utils.GetQueryStringValue("AppUser");
            serchModel.ConSumState = Eyousoft_yhq.Model.ConSumState.已消费;
            
            pageIndex = UtilsCommons.GetPagingIndex("Page");

            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                serchModel.ChanPinFaBuRenId = HuiYuanInfo.UserId;
            }
            #endregion

            var list = bll.GetScanList(pageSize, pageIndex, ref recordCount, serchModel);
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
