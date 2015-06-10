using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class TravelArticleList : EyouSoft.Common.Page.webmasterPage
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(Eyousoft_yhq.Model.Privs.公告))
            {
                ToUrl("/webmaster/default.aspx");
            }

            //ajax for delete
            string dotype = Utils.GetQueryStringValue("dotype");
            if (!string.IsNullOrEmpty(dotype))
            {
                if (dotype.Equals("delete"))
                {
                    Response.Clear();
                    Response.Write(Delete(Utils.GetQueryStringValue("tid")));
                    Response.End();
                }
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void PageInit()
        {
            EyouSoft.Model.MTravelArticleCX model = new EyouSoft.Model.MTravelArticleCX();
            model.ArticleTitle = Utils.GetQueryStringValue("txtArticleTitle");
            model.ClassId = Utils.GetInt(Utils.GetQueryStringValue("ddlArticleClass"));
            model.KeyWords = Utils.GetQueryStringValue("txtKeyWords");
            model.OperatorName = Utils.GetQueryStringValue("txtOperatorName");
            model.IssueTimeBegin = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtStartTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime")) : null;
            model.IssueTimeEnd = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtEndTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime")) : null;
            model.IsFrontPage = !string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlIsFrontPage")) ? (bool?)(Utils.GetQueryStringValue("ddlIsFrontPage") == "1" ? true : false) : null;
            model.IsHot = !string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlIsHot")) ? (bool?)(Utils.GetQueryStringValue("ddlIsHot") == "1" ? true : false) : null;
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            EyouSoft.BLL.OtherStructure.BTravelArticle bll = new EyouSoft.BLL.OtherStructure.BTravelArticle();
            IList<EyouSoft.Model.MTravelArticle> list = bll.GetList(pageSize, pageIndex, ref recordCount, model, null);
            if (list != null && list.Count > 0)
            {
                this.RpArticle.DataSource = list;
                this.RpArticle.DataBind();
                BindExportPage();
            }
            else
            {
                Literal1.Text = "<tr align=\"center\"> <td colspan=\"12\">没有相关数据</td></tr>";
            }


        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExportPageInfo1.intPageSize = pageSize;
            this.ExportPageInfo1.CurrencyPage = pageIndex;
            this.ExportPageInfo1.intRecordCount = recordCount;
        }
        #endregion


        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindArticleClass(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            IList<EyouSoft.Model.MArticleClass> list = new EyouSoft.BLL.OtherStructure.BArticleClass().GetList(null);
            query.Append("<option value='0' >-请选择-</option>");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ClassId.ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].ClassId, list[i].ClassName);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", list[i].ClassId, list[i].ClassName);

                }
            }
            return query.ToString();

        }
        #endregion

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private string Delete(string ids)
        {
            string msg = null;
            EyouSoft.BLL.OtherStructure.BTravelArticle bll = new EyouSoft.BLL.OtherStructure.BTravelArticle();
            if (bll.Delete(ids.Split(',')))
            {
                msg = Utils.AjaxReturnJson("1", "删除成功！");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "删除失败！");
            }
            return msg;
        }
    }
}
