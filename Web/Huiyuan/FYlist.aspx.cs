using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class GYlist : EyouSoft.Common.Page.HuiyuanPage
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

            var memeber = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (memeber == null || !memeber.IsAgent) return;
            Eyousoft_yhq.Model.MSearchOrder serchModel = new Eyousoft_yhq.Model.MSearchOrder();
            serchModel.MemberID = memeber.UserID;
            serchModel.PromotionCode = memeber.PollCode == "" ? "未知" : memeber.PromotionCode;
            serchModel.PaymentState = Eyousoft_yhq.Model.PaymentState.已支付;
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = bll.GetFYList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_orders.DataSource = list;
                rpt_orders.DataBind();
                this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
                this.ExporPageInfoSelect1.intPageSize = pageSize;
                this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
                this.ExporPageInfoSelect1.intRecordCount = recordCount;
                this.ExporPageInfoSelect1.UrlParams = Request.QueryString;


                litMsg.Visible = false;

            }
            else
            {
                rpt_orders.Visible = false;
            }

        }
    }
}
