using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class BusTicketList : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initList();
        }

        #region 初始化页面
        void initList()
        {
            Eyousoft_yhq.BLL.Product bll = new Eyousoft_yhq.BLL.Product();
            Eyousoft_yhq.Model.SerProduct serchModel = new Eyousoft_yhq.Model.SerProduct();
            serchModel.AdminName = HuiYuanInfo.UserId;
            serchModel.PType = 2;
            serchModel.PurductName = Utils.GetQueryStringValue("BusTicket");
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_list.DataSource = list;
                rpt_list.DataBind();
                BindPage();
                litMsg.Visible = false;

            }
            else
            {
                rpt_list.Visible = false;
            }
        }
        #endregion

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
