using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class YuYueList : System.Web.UI.Page
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 20, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initList();
        }

        protected void initList()
        {

            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = new Eyousoft_yhq.BLL.BYuYue().GetList(pageSize, pageIndex, ref recordCount, new Eyousoft_yhq.Model.MYuYueSer() { });
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindPage();
            }
            else
            {
                litMsg.Visible = true;
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
