using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web
{
    public partial class NoticeList : System.Web.UI.Page
    {
        #region  分页参数
        protected int pageSize = 30, pageIndex = 1, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            InitList();
            InitBind();
        }
        protected void InitList()
        {
            EyouSoft.Model.TravelArticleOrderBy orderBy = new EyouSoft.Model.TravelArticleOrderBy();
            orderBy.FiledOrder = Eyousoft_yhq.Model.TravelArticleFiledOrder.IssueTime;
            orderBy.OrderBy = Eyousoft_yhq.Model.OrderBy.DESC;
            List<EyouSoft.Model.TravelArticleOrderBy> orderBys = new List<EyouSoft.Model.TravelArticleOrderBy>();
            orderBys.Add(orderBy);
            EyouSoft.Model.MTravelArticleCX chaxun = new EyouSoft.Model.MTravelArticleCX();
            chaxun.IsSystem = new Eyousoft_yhq.Model.ArticleType[] { Eyousoft_yhq.Model.ArticleType.公告 };
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetList(pageSize, pageIndex, ref recordCount, chaxun, orderBys);

            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            if (list != null && list.Count > 0)
            {
                rpt_Notices.DataSource = list;
                rpt_Notices.DataBind();

            }
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));
        }

        protected void RegisterScript(string script)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }


        /// <summary>
        /// 页面加载
        /// </summary>
        protected void InitBind()
        {
            Eyousoft_yhq.BLL.Product PBll = new Eyousoft_yhq.BLL.Product();
            Eyousoft_yhq.Model.SerProduct PModel = new Eyousoft_yhq.Model.SerProduct();
            PModel.SFTJ = 1;


            IList<Eyousoft_yhq.Model.Product> list = PBll.GetList(pageSize, pageIndex, ref recordCount, PModel);
            if (list != null && list.Count > 0)
            {
                rpList.DataSource = list;
                rpList.DataBind();
            }
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getImg(string id)
        {
            var model = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (model != null)
            {
                if (model.AttachList != null)
                {
                    for (int i = 0; i < model.AttachList.Count; i++)
                    {
                        if (model.AttachList[i].IsWebImage) return string.Format("<img src=\"{0}\" style=\"width:455px;height:280px\" />", model.AttachList[i].FilePath);
                    }
                }
                else
                {
                    return " <img src=\"/images/img00.jpg\">";
                }
            }
            return " <img src=\"/images/img00.jpg\">";
        }
    }
}
