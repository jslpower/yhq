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
    public partial class OrderList : EyouSoft.Common.Page.webmasterPage
    {

        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
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
            serchModel.OrderCode = Utils.GetQueryStringValue("orderCode");
            serchModel.ConfirmCode = Utils.GetQueryStringValue("ConfirmCode");
            serchModel.STime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("StartTime"));
            serchModel.ETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("EndTime"));
            serchModel.OrderState = (Eyousoft_yhq.Model.OrderState?)Utils.GetEnumValueNull(typeof(Eyousoft_yhq.Model.OrderState), Utils.GetQueryStringValue("sleorderstatus"));
            serchModel.PaymentState = (Eyousoft_yhq.Model.PaymentState?)Utils.GetEnumValueNull(typeof(Eyousoft_yhq.Model.PaymentState), Utils.GetQueryStringValue("slepaystatus"));
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("jiesuan"))) serchModel.jiesuan = (Eyousoft_yhq.Model.JSfangshi)Utils.GetInt(Utils.GetQueryStringValue("jiesuan"));

            pageIndex = UtilsCommons.GetPagingIndex("Page");

            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                serchModel.ChanPinFaBuRenId = HuiYuanInfo.UserId;
                phSMDZD.Visible = false;
            }
            #endregion

            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_orders.DataSource = list;
                rpt_orders.DataBind();
                BindPage();
                litMsg.Visible = false;

            }
            else
            {
                rpt_orders.Visible = false;
            }
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        }

        protected string getOption(int paystate, string orderid)
        {
            Eyousoft_yhq.Model.PaymentState state = (Eyousoft_yhq.Model.PaymentState)paystate;
            if (state == Eyousoft_yhq.Model.PaymentState.未支付) return "";
            return string.Format(" <a target=\"_blank\" href=\"SealPrint.aspx?id={0} \" class=\"contract\">合同</a> | ", orderid);
        }

        protected string getjiesuan(int paystate, int jiesuan)
        {
            Eyousoft_yhq.Model.PaymentState state = (Eyousoft_yhq.Model.PaymentState)paystate;
            if (state == Eyousoft_yhq.Model.PaymentState.未支付) return "";
            return ((Eyousoft_yhq.Model.JSfangshi)jiesuan).ToString();
        }
    }
}
