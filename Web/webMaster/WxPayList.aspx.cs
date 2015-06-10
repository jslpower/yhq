using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class WxPayList : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initList();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex("Page");

            var serModel = new Eyousoft_yhq.Model.MChongZhiSer();
            serModel.Account = Utils.GetQueryStringValue("Account");
            serModel.OrderCode = Utils.GetQueryStringValue("OrderCode");
            serModel.TradeNo = Utils.GetQueryStringValue("TradeNo");

            var list = new Eyousoft_yhq.BLL.BChongZhi().GetList(pageSize, pageIndex, ref recordCount, serModel);

            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();
                BindPage();
                litMsg.Visible = false;
            }
        }

        #region 绑定分页控件


        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion




    }
}
