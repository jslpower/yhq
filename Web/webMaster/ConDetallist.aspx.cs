using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class ConDetallist : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initList();
            BingToalMoney();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex("Page");

            Eyousoft_yhq.BLL.BConDetaile bll = new Eyousoft_yhq.BLL.BConDetaile();

            var list = bll.GetModelList(pageSize, pageIndex, ref recordCount, null);

            if (list != null && list.Count > 0)
            {
                rpTicket.DataSource = list;
                rpTicket.DataBind();
                BindPage();
                litMsg.Visible = false;
            }
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


        /// <summary>
        /// 计算账户消费和充值
        /// </summary>
        protected void BingToalMoney()
        {
            Eyousoft_yhq.BLL.BConDetaile bll = new Eyousoft_yhq.BLL.BConDetaile();
            decimal xmoney = bll.GetTotalMoney(Eyousoft_yhq.Model.TotalMoney.账户充值金额);
            decimal cmoney = bll.GetTotalMoney(Eyousoft_yhq.Model.TotalMoney.账户消费金额);
            lblCZ.Text = (xmoney+ cmoney).ToString("C2");
            lblXF.Text = cmoney.ToString("C2");

        }

    }
}

