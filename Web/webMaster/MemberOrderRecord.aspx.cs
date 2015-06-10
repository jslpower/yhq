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
    public partial class OrderRecord : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        protected decimal sumPayED = 0, sumBacK = 0;//已结算合计，待结算合计
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitOrders();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void InitOrders()
        {

            Eyousoft_yhq.BLL.Order bll = new Eyousoft_yhq.BLL.Order();

            #region 查询实体
            Eyousoft_yhq.Model.MSearchOrder serchModel = new Eyousoft_yhq.Model.MSearchOrder();
            serchModel.MemberID = Utils.GetQueryStringValue("userid");
            serchModel.PromotionCode = Utils.GetQueryStringValue("Code") == "" ? "未知" : Utils.GetQueryStringValue("Code");
            serchModel.PaymentState = Eyousoft_yhq.Model.PaymentState.已支付;
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = bll.GetFYList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_orders.DataSource = list;
                rpt_orders.DataBind();
                this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
                this.ExporPageInfoSelect1.intPageSize = pageSize;
                this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
                this.ExporPageInfoSelect1.intRecordCount = recordCount;
                this.ExporPageInfoSelect1.UrlParams = Request.QueryString;


                litMsg.Visible = false;



                var Countlist = bll.GetList(serchModel);
                for (int i = 0; i < Countlist.Count; i++)
                {
                    sumPayED += Countlist[i].RebackMoney;
                    sumBacK += Countlist[i].backMoney;
                }
                lblPayED.Text = sumPayED.ToString("C2");
                lblBacK.Text = sumBacK.ToString("C2");

            }
            else
            {
                plaHJ.Visible = false;
                rpt_orders.Visible = false;
            }
        }
        protected string getDecimal(object obj)
        {
            decimal getDecimal = Utils.GetDecimal(obj.ToString());
            decimal getScale = Utils.GetDecimal(Utils.GetQueryStringValue("scale"));
            return (getDecimal * getScale / 100m).ToString("0.00");
        }

    }
}
