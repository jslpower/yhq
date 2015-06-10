using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class AdvImgList : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string ids = Utils.GetQueryStringValue("ids");
            rpt_list.Visible = litMsg.Visible = true;
            if (dotype == "delete")
            {
                int[] strArr = Utils.GetIntArray(ids, ",");
                delByIds(strArr);
            }
            initList();
        }

        protected void initList()
        {
            Eyousoft_yhq.BLL.ProductType bll = new Eyousoft_yhq.BLL.ProductType();
            Eyousoft_yhq.Model.serProductType serchModel = new Eyousoft_yhq.Model.serProductType();
            serchModel.TypeName = Utils.GetQueryStringValue("productName");
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel, "0");
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
        protected void delByIds(int[] strArr)
        {
            bool result = new BLL.ProductType().Delete(strArr);
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", result ? "删除成功" : "删除失败"));
            Response.End();
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
