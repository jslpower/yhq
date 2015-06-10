using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.ZxingCode
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    /// 2014-08-17 下单增加剩余数量，扫码时判断数量
    public partial class XiaoFei : EyouSoft.Common.Page.HuiyuanPage
    {
        Eyousoft_yhq.Model.JSfangshi fangshi = Eyousoft_yhq.Model.JSfangshi.现付;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initPage();
            }
            if (Utils.GetQueryStringValue("xiaofei") == "1")
            {

                setOrderState();
            }

        }
        /// <summary>
        /// 显示订单信息
        /// </summary>
        protected void initPage()
        {
            string id = Utils.GetQueryStringValue("id");
            string ordertype = Utils.GetQueryStringValue("ordertype");
            if (ordertype == "order")
            {
                var model = new Eyousoft_yhq.BLL.Order().GetModel(id);
                if (model == null)
                {
                    lblxiaofei.Text = "未找到此订单！";
                    xiaofei.Visible = isXF.Visible = false;
                    return;
                }
                if (model.XiaoFei == Eyousoft_yhq.Model.XFstate.已消费 && model.AvailNum <= 0)
                {
                    lblxiaofei.Text = "此订单已消费！";
                    xiaofei.Visible = isXF.Visible = false;
                    return;
                }
                else if (DateTime.Compare(model.ZCodeViaDate, DateTime.Now) < 0)
                {
                    lblxiaofei.Text = "此订单已过期！";
                    xiaofei.Visible = isXF.Visible = false;
                    return;
                }
                else
                {
                    cusName.Value = model.MemberName;
                    cusMob.Value = model.MemberTel;
                    proName.Value = model.ProductName;
                    if (model.JIESUAN == Eyousoft_yhq.Model.JSfangshi.预付 &&
                        model.PayState == Eyousoft_yhq.Model.PaymentState.已支付) fangshi = model.JIESUAN;
                    lblxiaofei.Visible = false;
                }
            }
            else
            {
                var model = new Eyousoft_yhq.BLL.GYSticket().GetModel(id);
                if (model == null)
                {
                    lblxiaofei.Text = "未找到此订单！";
                    xiaofei.Visible = isXF.Visible = false;
                    return;
                }
                if (model.orderState == Eyousoft_yhq.Model.TickOrderState.已出票)
                {
                    lblxiaofei.Text = "此订单已出票！";
                    xiaofei.Visible = isXF.Visible = false;
                    return;
                }
                else
                {
                    cusName.Value = model.CusName;
                    cusMob.Value = model.CusMob;
                    proName.Value = "机票：" + model.PlaneTicket;
                    lblxiaofei.Visible = false;
                }
            }

        }
        /// <summary>
        /// 消费
        /// </summary>
        /// <returns></returns>
        protected void setOrderState()
        {
            string id = Utils.GetQueryStringValue("id");
            string ordertype = Utils.GetQueryStringValue("ordertype");
            string mobNo = Utils.GetQueryStringValue("appMob");
            if (ordertype == "order")
            {
                bool result = new Eyousoft_yhq.BLL.Order().setConSumState(id, HuiYuanInfo.UserID, fangshi, mobNo);

                Response.Clear();
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", result ? "操作成功" : "操作失败"));
                Response.End();
            }
            else if (ordertype == "torder")
            {

                var model = new Eyousoft_yhq.BLL.GYSticket().GetModel(id);
                model.orderState = Eyousoft_yhq.Model.TickOrderState.已出票;
                model.payState = Eyousoft_yhq.Model.PaymentState.已支付;
                bool result = new Eyousoft_yhq.BLL.GYSticket().Update(model);

                Response.Clear();
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", result ? "操作成功" : "操作失败"));
                Response.End();
            }
        }
    }
}
