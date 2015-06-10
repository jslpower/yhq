using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;


namespace Eyousoft_yhq.Web.webMaster
{
    public partial class CommentList : EyouSoft.Common.Page.webmasterPage
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
                string[] strArr = ids.Split(',');
                delByIds(strArr);
            }
            if (dotype == "check")
            {
                string[] strArr = ids.Split(',');
                check(strArr);
            }
            initList();
        }

        protected void initList()
        {
            Eyousoft_yhq.BLL.Comment bll = new Eyousoft_yhq.BLL.Comment();
            Eyousoft_yhq.Model.serComment serchModel = new Eyousoft_yhq.Model.serComment();
            serchModel.sTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("stime"));
            serchModel.eTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("etime"));
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
        protected void delByIds(string[] strArr)
        {
            bool result = new BLL.Comment().Delete(strArr);
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", result ? "删除成功" : "删除失败"));
            Response.End();
        }

        protected void check(string[] strArr)
        {
            Response.Clear();
            Eyousoft_yhq.BLL.Comment BLL = new Eyousoft_yhq.BLL.Comment();
            bool result = BLL.Update(strArr);
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", result ? "审核成功！" : "审核失败！"));
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
