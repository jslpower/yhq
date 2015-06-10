using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web
{
    public partial class orderlist : EyouSoft.Common.Page.HuiyuanPage
    {

        #region  页面参数
        protected int pageIndex = 1, pageSize =5, recordCount = 0;
        #endregion
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (userInfo != null)
                {
                    string OrderType = Utils.GetQueryStringValue("OrderType");

                    InitOrders(OrderType);
                }
                else
                {
                    Response.Redirect("/AppPage/register.aspx");
                }


            }
        }

        protected void InitOrders(string Type)
        {

            Eyousoft_yhq.BLL.Order bll = new Eyousoft_yhq.BLL.Order();

            #region 查询实体
            Eyousoft_yhq.Model.MSearchOrder serchModel = new Eyousoft_yhq.Model.MSearchOrder();
            serchModel.PaymentState = (Eyousoft_yhq.Model.PaymentState?)Utils.GetEnumValueNull(typeof(Eyousoft_yhq.Model.PaymentState), Utils.GetQueryStringValue("OrderType"), (int)Eyousoft_yhq.Model.PaymentState.未支付);
            serchModel.MemberID = userInfo.UserID;
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_orders.DataSource = list;
                rpt_orders.DataBind();
                litMsg.Visible = false;
            }
            else
            {
                PlaceHolder1.Visible = false;
                litMsg.Visible = true;
            }
        }


        #region 出团通知单下载
        protected string DownFile(object FileXML)
        {


            IList<Eyousoft_yhq.Model.Attach> Attach = (IList<Eyousoft_yhq.Model.Attach>)FileXML;
            if (Attach != null && Attach.Count > 0)
            {
                return string.Format("<a    href=\"{0}\"><img src=\"/images/icon1.gif\"> 出团通知单下载</a>  ", "http://" + HttpContext.Current.Request.Url.Host + Attach[0].FilePath.ToString());
            }


            return "<a>暂无出团通知单</a>";
        }
        #endregion

        #region  产品图片
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getProImg(string id)
        {
            var img = new Eyousoft_yhq.BLL.Product().GetModel(id).AttachList;
            if (img != null && img.Count > 0)
            {
                for (int i = 0; i < img.Count; i++)
                {
                    if (img[i].IsWebImage && !string.IsNullOrEmpty(img[i].FilePath)) return img[i].FilePath;
                }
            }
            return "/images/list_img.gif";
        }

        #endregion

        #region  支付宝
        /// <summary>
        /// 支付宝绑定
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string BindZhiFuBao(string orderId, object status, object zhifu, object xiafei)
        {
            System.Text.StringBuilder zhifubao = new System.Text.StringBuilder();

            Eyousoft_yhq.Model.OrderState OrderStatus = (Eyousoft_yhq.Model.OrderState)status;

            Eyousoft_yhq.Model.PaymentState PayStatus = (Eyousoft_yhq.Model.PaymentState)zhifu;

            Eyousoft_yhq.Model.ConSumState ConSumState = (Eyousoft_yhq.Model.ConSumState)xiafei;

            if (Eyousoft_yhq.Model.OrderState.待付款 == OrderStatus || Eyousoft_yhq.Model.OrderState.已成交 == OrderStatus)
            {
                if (PayStatus == Eyousoft_yhq.Model.PaymentState.已支付)
                {
                    zhifubao.Append("<span class=\"yifu\">" + ConSumState.ToString() + "</span>");
                }
                else
                {
                    zhifubao.AppendFormat("<a href=\"/AliPay/default.aspx?OrderId={0}\"><img src=\"/Images/zhifb.jpg\"></a>", orderId);
                }
            }
            else
            {
                zhifubao.Append("<span class=\"daifu\">等待付款</span>");
            }

            return zhifubao.ToString();
        }

        #endregion
    }
}
