using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class TGlist : EyouSoft.Common.Page.HuiyuanPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
             initList();

        }

        protected void initList()
        {
             string Code = string.Empty;

            var memeber = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (memeber == null || !memeber.IsAgent) return;
            Code = memeber.PromotionCode;
            if (string.IsNullOrEmpty(Code))
            {
                litMsg.Visible = true;
                return;
            }
            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, new Eyousoft_yhq.Model.MSearchUser() { PromotionCode = Code }, 0);
            if (list != null && list.Count > 0)
            {
                rpt_list.DataSource = list;
                rpt_list.DataBind();
                this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
                this.ExporPageInfoSelect1.intPageSize = pageSize;
                this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
                this.ExporPageInfoSelect1.intRecordCount = recordCount;
                this.ExporPageInfoSelect1.UrlParams = Request.QueryString;


                litMsg.Visible = false;

            }
            else
            {
                rpt_list.Visible = false;
            }
        }

    }
}
