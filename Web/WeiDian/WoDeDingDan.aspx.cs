//我的微店订单 汪奇志 2015-02-10
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiDian
{
    /// <summary>
    /// 我的微店订单
    /// </summary>
    public partial class WoDeDingDan : Eyousoft_yhq.Web.HuiYuanWeiXin.HuiYuanWeiXinYeMian
    {
        #region attributes
        /// <summary>
        /// 微店编号
        /// </summary>
        protected string WeiDianId = string.Empty;

        int PageSize = 5;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("jiazaigengduo") == "1" || Utils.GetQueryStringValue("chaxun") == "1") JiaZaiGengDuo();

            Master.IsLoadDefaultCss = false;
            YanZhengLogin();

            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(HuiYuanInfo.WeiDianId)) Response.Redirect("notfound.aspx?xxlx=2");

            WeiDianId = HuiYuanInfo.WeiDianId;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            int recordCount = 0;
            var items = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianDingDans(HuiYuanInfo.WeiDianId, PageSize, 1, ref recordCount, null);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phShangLaJiaZai.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// jiazai gengduo
        /// </summary>
        void JiaZaiGengDuo()
        {
            int pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            var items = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianDingDans(HuiYuanInfo.WeiDianId, PageSize, pageIndex, ref recordCount, chaXun);

            string html = string.Empty;

            int pageCount = 0;
            if (recordCount % PageSize == 0) pageCount = recordCount / PageSize;
            else pageCount = recordCount / PageSize + 1;

            if (pageIndex > pageCount)
            {
                Utils.RCWE_AJAX("-1");
            }

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                rpt.RenderControl(htw);

                var obj = new { html = htw.InnerWriter.ToString() };

                Utils.RCWE_AJAX("1", "", obj);
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        Eyousoft_yhq.Model.MWeiDianDingDanChaXunInfo GetChaXunInfo()
        {
            var info = new Eyousoft_yhq.Model.MWeiDianDingDanChaXunInfo();
            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// get tupian filepath
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetTuPianFilepath(object filepath)
        {
            var _filepath = (string)filepath;

            if (string.IsNullOrEmpty(_filepath)) return "/images/chanpin_moren.png";

            return _filepath;
        }

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="shenHeStatus">审核状态</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <param name="zhiFuStatus">支付状态</param>
        /// <param name="xiaoFeiStatus">消费状态</param>
        /// <returns></returns>
        protected string GetDingDanStatus(object shenHeStatus, object dingDanStatus, object zhiFuStatus, object xiaoFeiStatus)
        {
            var _shenHeStatus = shenHeStatus.ToString();
            var _dingDanStatus = (Eyousoft_yhq.Model.OrderState)dingDanStatus;
            var _zhiFuStatus = (Eyousoft_yhq.Model.PaymentState)zhiFuStatus;
            var _xiaoFeiStatus = (Eyousoft_yhq.Model.ConSumState)xiaoFeiStatus;

            if (_dingDanStatus == Eyousoft_yhq.Model.OrderState.待付款 || _dingDanStatus == Eyousoft_yhq.Model.OrderState.已成交)
            {
                if (_zhiFuStatus == Eyousoft_yhq.Model.PaymentState.已支付)
                {
                    return "已支付";
                }
                else
                {
                    return "未支付";
                }
            }

            return _dingDanStatus.ToString();
        }
        #endregion
    }
}
