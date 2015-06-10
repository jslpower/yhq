using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
namespace EyouSoft.Web.WebMaster
{
    public partial class TravelArticleClass : EyouSoft.Common.Page.webmasterPage
    {
        private int pagesize = 20;
        private int pagecount = 0;
        private int pageindex = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(Eyousoft_yhq.Model.Privs.公告类型))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string dotype = Utils.GetQueryStringValue("dotype");
            string tid = Utils.GetQueryStringValue("tid");
            int tis = Utils.GetInt(Utils.GetQueryStringValue("tis"));
            if (!string.IsNullOrEmpty(dotype))
            {
                AJAX(dotype, tid, tis);
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            pageindex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            var list = new  BLL.OtherStructure.BArticleClass().GetList(pagesize, pageindex, ref pagecount, null);

            UtilsCommons.Paging(pagesize, ref pageindex, pagecount);

            rptList.DataSource = list;
            rptList.DataBind();

            BindExportPage();
        }

        protected string GetIndex(int index)
        {
            return ((pageindex - 1) * pagesize + index + 1).ToString();
        }

        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id, int tis)
        {
            string msg = string.Empty;

            msg = DeleteData(id, tis);

            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private string DeleteData(string id, int tis)
        {
            string msg = string.Empty;
            if (!String.IsNullOrEmpty(id) && tis == 0)
            {
                EyouSoft.BLL.OtherStructure.BArticleClass bll = new EyouSoft.BLL.OtherStructure.BArticleClass();
                if (bll.Delete(id.Trim()))
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "删除成功");
                else
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "删除失败");
            }
            return msg;
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pagesize;
            this.ExporPageInfoSelect1.CurrencyPage = pageindex;
            this.ExporPageInfoSelect1.intRecordCount = pagecount;
        }
    }
}
