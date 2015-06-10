using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class CustomMsgLis : System.Web.UI.Page
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 20, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string ids = Utils.GetQueryStringValue("ids");
            rptList.Visible = litMsg.Visible = true;

            initList();
        }

        protected void initList()
        {
            Eyousoft_yhq.BLL.BCustomMsg bll = new Eyousoft_yhq.BLL.BCustomMsg();
            Eyousoft_yhq.Model.serCustomMsg serchModel = new Eyousoft_yhq.Model.serCustomMsg();

            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindPage();
                litMsg.Visible = false;

            }
            else
            {
                rptList.Visible = false;
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
