using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;


namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class InsOrders : EyouSoft.Common.Page.HuiyuanPage
    {

        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void PageInit()
        {
            Eyousoft_yhq.BLL.BPlanIns bll = new Eyousoft_yhq.BLL.BPlanIns();

            #region 查询实体
            var serchModel = new Eyousoft_yhq.Model.MPlanInsSer() { OperatorID = HuiYuanInfo.UserID };
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

 
            var list = new Eyousoft_yhq.BLL.BPlanIns().GetList(pageSize, pageIndex, ref recordCount, serchModel);

            if (list != null && list.Count > 0)
            {
                this.rpOrder.DataSource = list;
                this.rpOrder.DataBind();
                BindPage();
            }
            else
            {
                Literal1.Text = "<tr align=\"center\"> <td colspan=\"11\">没有相关数据</td></tr>";
            }
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }



    }
}
