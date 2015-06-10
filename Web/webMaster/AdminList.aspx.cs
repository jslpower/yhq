using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class AdminList : EyouSoft.Common.Page.webmasterPage
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
                //string[] strArr = ids.Split(',');
                delByIds(ids);
            }
            if (dotype == "qiyong")
            {
                qiyongByID(ids);
            }
            initList();
        }

        protected void initList()
        {
            Eyousoft_yhq.BLL.User bll = new Eyousoft_yhq.BLL.User();
            var serchModel = new EyouSoft.Model.SSOStructure.MGuanLiYuanChaXunInfo();
            serchModel.XingMing = Utils.GetQueryStringValue("contactName");
            serchModel.Username = Utils.GetQueryStringValue("userName");
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
        protected void delByIds(string strArr)
        {
            int result = new BLL.User().Delete(strArr);
            Response.Clear();
            switch (result)
            {
                case 2:
                    Response.Write(UtilsCommons.AjaxReturnJson(result.ToString(), "停用成功"));
                    break;
                case 3:
                    Response.Write(UtilsCommons.AjaxReturnJson(result.ToString(), "停用失败"));
                    break;
                default:
                    break;
            }
            Response.End();
        }
        protected void qiyongByID(string id)
        {
            bool result = new BLL.User().qiyong(id);
            Response.Clear();
            if (result) Response.Write(UtilsCommons.AjaxReturnJson(result.ToString(), "启用成功"));
            if (!result) Response.Write(UtilsCommons.AjaxReturnJson(result.ToString(), "启用失败"));

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
