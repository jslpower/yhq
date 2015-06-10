using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Xml;

namespace Eyousoft_yhq.Web.AppPage.ZxingCode
{
    public partial class JpXiaoFei : EyouSoft.Common.Page.HuiyuanPage
    {
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

            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModelByCode(id);

            if (model == null)
            {
                lblxiaofei.Text = "未找到此订单2！";
                xiaofei.Visible = isXF.Visible = false;
                return;
            }
            if (model.payState != Eyousoft_yhq.Model.TickOrderPayState.已出票)
            {
                lblxiaofei.Text = "此订单未出票！";
                xiaofei.Visible = isXF.Visible = false;
                return;
            }
            else
            {
                var huiyuan = new Eyousoft_yhq.BLL.Member().GetModel(model.OpeatorID);
                if (huiyuan == null)
                {
                    lblxiaofei.Text = "数据丢失，请联系我们！";
                    xiaofei.Visible = isXF.Visible = false;
                    return;
                }
                cusName.Value = huiyuan.ContactName;
                cusMob.Value = huiyuan.UserName;
                proName.Value = model.OrderCode;

                string policyXML = new com._8222666.fxb2b.Service().XmlSubmit(
   Utils.getIdentityXMLString()
    , string.Format("<QuerySubsOrder_1_3><SubsOrderNo>{0}</SubsOrderNo></QuerySubsOrder_1_3>", id)
    , "");
                getCarrNo(policyXML);
                lblxiaofei.Visible = false;
            }



        }
        /// <summary>
        /// 消费
        /// </summary>
        /// <returns></returns>
        protected void setOrderState()
        {
            Eyousoft_yhq.Model.MJiPiaoBaoCun model = new Eyousoft_yhq.Model.MJiPiaoBaoCun();
            Eyousoft_yhq.BLL.BJiPiaoBaoCun bll = new Eyousoft_yhq.BLL.BJiPiaoBaoCun();
            model.OrderCode = Utils.GetQueryStringValue("id");
            model.payState = Eyousoft_yhq.Model.TickOrderPayState.已签收;
            if (bll.setStateByOrderCode(model))
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "签收成功！"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "签收失败！"));
            }
        }
        /// <summary>
        /// 返回航班信息
        /// </summary>
        /// <param name="strXML"></param>
        /// <returns></returns>
        void getCarrNo(string strXML)
        {
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(strXML);
            if (dom.SelectSingleNode("ErrorInfo_1_0") != null
                         && !string.IsNullOrEmpty(dom.SelectSingleNode("ErrorInfo_1_0").InnerText))
                return;

            XmlNodeList hangbanXX = dom.SelectSingleNode("QuerySubsOrder_1_3").SelectSingleNode("Flights").SelectNodes("Flight");

            CarrNO.Value = hangbanXX[0].SelectSingleNode("Carrier").InnerText + hangbanXX[0].SelectSingleNode("FlightNo").InnerText;
            qujian.Value = hangbanXX[0].SelectSingleNode("BoardPointName").InnerText + "-" + hangbanXX[0].SelectSingleNode("OffPointName").InnerText;

        }
    }
}
