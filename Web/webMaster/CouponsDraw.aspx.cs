using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class CouponsDraw : System.Web.UI.Page
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string getID = Utils.GetQueryStringValue("id");
            initList(getID);
        }
        protected void initList(string id)
        {
            Eyousoft_yhq.BLL.SendMsg bll = new Eyousoft_yhq.BLL.SendMsg();
            Eyousoft_yhq.Model.serSendMSG serchModel = new Eyousoft_yhq.Model.serSendMSG();
            serchModel.ProductID = id;
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
