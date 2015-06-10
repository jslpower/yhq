using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class PlanTicketList : EyouSoft.Common.Page.webmasterPage
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
            Eyousoft_yhq.BLL.GYSticket bll = new Eyousoft_yhq.BLL.GYSticket();

            #region 查询实体
            Eyousoft_yhq.Model.GysTicketSer serchModel = new Eyousoft_yhq.Model.GysTicketSer();
            serchModel.cusName = Utils.GetQueryStringValue("cusName");
            serchModel.cusMob = Utils.GetQueryStringValue("cusMob");
            serchModel.tickNO = Utils.GetQueryStringValue("GysTicket");
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);

            if (list != null && list.Count > 0)
            {
                rpTicket.DataSource = list;
                rpTicket.DataBind();
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
