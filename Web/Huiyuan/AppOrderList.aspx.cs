using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class AppOrderList : EyouSoft.Common.Page.HuiyuanPage
    {

        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageInit();
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void PageInit()
        {
            Eyousoft_yhq.BLL.Order bll = new Eyousoft_yhq.BLL.Order();

            #region 查询实体
            Eyousoft_yhq.Model.MSearchOrder serchModel = new Eyousoft_yhq.Model.MSearchOrder();
            serchModel.STime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));
            serchModel.ETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime") + " 23:59:59");
            serchModel.XSTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXStartTime"));
            serchModel.XETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXEndTime") + " 23:59:59");
            serchModel.OrderCode = Utils.GetQueryStringValue("txtOrderCode");
            serchModel.AppUserId = HuiYuanInfo.UserID;
            serchModel.ConSumState = Eyousoft_yhq.Model.ConSumState.已消费;
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = bll.GetScanList(pageSize, pageIndex, ref recordCount, serchModel);

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

        #region 支付宝
        /// <summary>
        /// 支付宝绑定
        /// </summary>
        /// <param name="OrderId">订单ID</param>
        /// <param name="status">订单状态</param>
        /// <param name="zhifu">支付状态</param>
        /// <param name="IsealCheck">是否盖章</param>
        /// <param name="ContractType">合同类型</param>
        /// <returns></returns>
        protected string BindZhiFuBao(string orderId, object status, object zhifu, object IsealCheck, object ContractType)
        {
            System.Text.StringBuilder zhifubao = new System.Text.StringBuilder();

            Eyousoft_yhq.Model.OrderState OrderStatus = (Eyousoft_yhq.Model.OrderState)status;

            Eyousoft_yhq.Model.PaymentState PayStatus = (Eyousoft_yhq.Model.PaymentState)zhifu;

            if (Eyousoft_yhq.Model.OrderState.待付款 == OrderStatus || Eyousoft_yhq.Model.OrderState.已成交 == OrderStatus)
            {
                if (PayStatus == Eyousoft_yhq.Model.PaymentState.已支付)
                {
                    if (IsealCheck.ToString().ToLower() == "true")
                    {
                        if (Eyousoft_yhq.Model.ContractType.单定协议 == (Eyousoft_yhq.Model.ContractType)ContractType)
                        {
                            zhifubao.Append("<span style=\" color:#62A93E\">已付款</span>");
                        }
                        else
                        {
                            zhifubao.Append("<a id=\"AddressCheck\"  class=\"hetong\" href=\"javascript:;\" >合同寄送</a>");
                        }
                    }
                    else
                    {
                        if (Eyousoft_yhq.Model.ContractType.国外合同 == (Eyousoft_yhq.Model.ContractType)ContractType)
                        {
                            zhifubao.AppendFormat("<a target='_blank' class=\"qiandan\" href='/printPage/AbroadContract.aspx?id={0}'>电子签单</a>", orderId);
                        }
                        else if (Eyousoft_yhq.Model.ContractType.单定协议 == (Eyousoft_yhq.Model.ContractType)ContractType)
                        {
                            zhifubao.Append("<span style=\" color:#62A93E\">已付款</span>");
                        }
                        else
                        {
                            zhifubao.AppendFormat("<a target='_blank' class=\"qiandan\" href='/printPage/ChyardContract.aspx?id={0}'>电子签单</a>", orderId);
                        }
                    }

                }
                else
                {
                    zhifubao.AppendFormat("<a target='_blank' class=\"fukuan\" href='/Alipay/WebPay/AliPayIndex.aspx?OrderId={0}'>付款</a>", orderId);
                }
            }
            else
            {
                zhifubao.Append("<span style=\" color:red\">处理中</span>");
            }

            return zhifubao.ToString();
        }
        #endregion

        #region 出团通知单下载
        protected string DownFile(object FileXML)
        {
            System.Text.StringBuilder FileContent = new System.Text.StringBuilder();
            IList<Eyousoft_yhq.Model.Attach> Attach = (IList<Eyousoft_yhq.Model.Attach>)FileXML;
            if (Attach != null)
            {
                FileContent.Append(string.Format("<a title=\"出团通知单下载\" href=\"{0}\" target=\"_blank\"><img width=\"15\" height=\"15\" style=\"vertical-align:middle;\" src=\"/images/icon1.gif\"></a>", Attach[0].FilePath).ToString());
            }
            return FileContent.ToString();
        }
        #endregion

    }
}
