using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.userControl
{
    public partial class MaqueeShow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInit();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void PageInit()
        {
            EyouSoft.Model.TravelArticleOrderBy orderBy = new EyouSoft.Model.TravelArticleOrderBy();
            orderBy.FiledOrder = Eyousoft_yhq.Model.TravelArticleFiledOrder.IssueTime;
            orderBy.OrderBy = Eyousoft_yhq.Model.OrderBy.DESC;
            List<EyouSoft.Model.TravelArticleOrderBy> orderBys = new List<EyouSoft.Model.TravelArticleOrderBy>();
            orderBys.Add(orderBy);
            EyouSoft.Model.MTravelArticleCX chaxun = new EyouSoft.Model.MTravelArticleCX();
            chaxun.IsSystem = new Eyousoft_yhq.Model.ArticleType[] { Eyousoft_yhq.Model.ArticleType.公告 };
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetTopList(1, chaxun, orderBys);
            if (list != null && list.Count > 0)
            {
                lbltext.Text = string.Format(" <div class=\"hot\"><a href=\"/NoticeInfo.aspx?NotIceId={0}\"><b>公告：</b>{1}</a><a href=\"/NoticeList.aspx\" class=\"more\">更多 ></a></div>", list[0].ArticleID, list[0].ArticleTitle);
            }



        }
    }
}