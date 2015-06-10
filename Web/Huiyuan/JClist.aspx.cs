using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class JClist : System.Web.UI.Page
    {

        #region  分页参数
        protected int pageSize = 30, pageIndex = 1, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            InitList();
        }
        protected void InitList()
        {
            string typeStr = Utils.GetConfigString("appSettings", "JCtype");
            EyouSoft.Model.TravelArticleOrderBy orderBy = new EyouSoft.Model.TravelArticleOrderBy();
            orderBy.FiledOrder = Eyousoft_yhq.Model.TravelArticleFiledOrder.IssueTime;
            orderBy.OrderBy = Eyousoft_yhq.Model.OrderBy.DESC;
            List<EyouSoft.Model.TravelArticleOrderBy> orderBys = new List<EyouSoft.Model.TravelArticleOrderBy>();
            orderBys.Add(orderBy);
            EyouSoft.Model.MTravelArticleCX chaxun = new EyouSoft.Model.MTravelArticleCX();
            if (typeStr.Length > 0)
            {
                chaxun.ZXtype = typeStr.Split(',');
            }

            pageIndex = UtilsCommons.GetPagingIndex("Page");
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetList(pageSize, pageIndex, ref recordCount, chaxun, orderBys);

            if (list != null && list.Count > 0)
            {
                rpt_Notices.DataSource = list;
                rpt_Notices.DataBind();
                this.ExporPageInfoSelect1.intPageSize = pageSize;
                this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
                this.ExporPageInfoSelect1.intRecordCount = recordCount;
            }
            else
            {
                litMsg.Visible = true;
            }
        }
    }
}
