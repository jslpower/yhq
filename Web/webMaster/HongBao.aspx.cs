using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class HongBao : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 20, recordCount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            initlist();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initlist()
        {
            Eyousoft_yhq.BLL.BHongBao bll = new Eyousoft_yhq.BLL.BHongBao();
            Eyousoft_yhq.Model.HongBaoSer serchModel = new Eyousoft_yhq.Model.HongBaoSer();


            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

                this.ExporPageInfoSelect1.intPageSize = pageSize;
                this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
                this.ExporPageInfoSelect1.intRecordCount = recordCount;


                litMsg.Visible = false;
            }

        }
    }
}
