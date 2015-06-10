using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxDownOrder : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Utils.GetQueryStringValue("type");
                string strpid = Utils.GetQueryStringValue("pid");
                if (type == "DownOrder")
                {
                    Response.Clear();
                    Response.Write(this.MemberOrder(strpid));
                    Response.End();
                }
            }
        }

        protected string MemberOrder(string PId)
        {
            var model = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            //用户是否登录
            if (model != null)
            {
                Eyousoft_yhq.BLL.Product ProductBll = new Eyousoft_yhq.BLL.Product();

                var ProModel = ProductBll.GetModel(PId);
                Eyousoft_yhq.Model.Order order = new Eyousoft_yhq.Model.Order();
                //产品是否存在
                if (ProModel != null)
                {
                    if (ProModel != null && ProModel.ResidueNum <= 0)
                    {

                        Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
                        //短信数量
                        if (exModel != null && exModel.MsgNumber > 0)
                        {

                            IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
                            bool IsMsgAdd = AddOrder(PId, (int)Eyousoft_yhq.Model.OrderState.未处理, ProModel.AppPrice, out order);
                            if (IsMsgAdd)
                            {
                                string result = string.Empty;//返回发送结果
                                string sendNum = string.Empty; //发送账号
                                Eyousoft_yhq.BLL.ProductType ProductTypeBll = new Eyousoft_yhq.BLL.ProductType();
                                var ProductTypeModel = ProductTypeBll.GetModel(ProModel.ProductType);
                                var AdminUser = new EyouSoft.Model.SSOStructure.MWebmasterInfo();
                                if (ProductTypeModel != null)
                                {
                                    for (int i = 0; i < ProductTypeModel.AdminName.Count; i++)
                                    {
                                        AdminUser = new Eyousoft_yhq.BLL.User().GetModel(ProductTypeModel.AdminName[i].AdminN);
                                        if (AdminUser != null) sendNum = AdminUser.Telephone;
                                        string Msg = string.Format("产品{0}有未处理订单，订单号：{1}！【惠旅游】", ProModel.ProductName, order.OrderCode);
                                        Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(sendNum, Msg, channel[0], out result);//发送
                                        #region  短信日志
                                        Eyousoft_yhq.Model.MsgLog MsLog = new Eyousoft_yhq.Model.MsgLog
                                        {
                                            TelCode = sendNum,
                                            MsgText = Msg,
                                            ReResult = result
                                        };
                                        new Eyousoft_yhq.BLL.MsgLog().Add(MsLog);
                                        #endregion
                                    }
                                }
                                if (result == "成功") return UtilsCommons.AjaxReturnJson("1", "下单成功，订单由客服人员进行座位确认，在72小时内会短信通知您是否成交");
                                return UtilsCommons.AjaxReturnJson("1", "下单成功，我们会尽快与您联系!");

                            }
                            else
                            {
                                return UtilsCommons.AjaxReturnJson("0", "下单失败，请重新下单");
                            }

                        }
                        else
                        {
                            return UtilsCommons.AjaxReturnJson("0", "短信系统维护中，请稍后再试！");
                        }
                    }
                    else
                    {
                        bool IsAdd = AddOrder(PId, (int)Eyousoft_yhq.Model.OrderState.待付款, ProModel.AppPrice, out  order);
                        if (IsAdd)
                        {
                            return UtilsCommons.AjaxReturnJson("99", "下单成功，请付款", order.OrderID);
                        }
                        else
                        {
                            return UtilsCommons.AjaxReturnJson("0", "下单失败，请重新下单");
                        }
                    }
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "商品已下价!");
                }
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("2", "请先登录再操作！");
            }
        }

        #region 订单添加
        protected bool AddOrder(string Pid, object OrderstateDown, decimal Price, out  Eyousoft_yhq.Model.Order order)
        {

            Eyousoft_yhq.BLL.Order OrderBll = new Eyousoft_yhq.BLL.Order();
            var MemberModel = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();

            int peopole = Utils.GetInt(Utils.GetQueryStringValue("renshu"), 1);

            if (MemberModel != null)
            {
                Eyousoft_yhq.Model.Order OrderModel = new Eyousoft_yhq.Model.Order()
                {
                    OrderID = Guid.NewGuid().ToString(),
                    ProductID = Pid,
                    MemberID = MemberModel.UserID,
                    MemberTel = MemberModel.UserName,
                    MemberName = MemberModel.ContactName,
                    MemberSex = MemberModel.ContactSex,
                    OrderState = (Eyousoft_yhq.Model.OrderState)OrderstateDown,
                    PayState = Eyousoft_yhq.Model.PaymentState.未支付,
                    IsCheck = true,
                    ConfirmCode = "",
                    Remark = "",
                    OrderPrice = Price * peopole,
                    PeopleNum = peopole
                };
                OrderModel.WeiDianId = Utils.GetQueryStringValue("weidianid");
                int num = OrderBll.Add(OrderModel);
                if (num > 0)
                {
                    order = OrderModel;
                    return true;
                }
                else
                {
                    order = OrderModel;
                    return false;
                }
            }
            else
            {
                order = new Eyousoft_yhq.Model.Order();
                return false;
            }

        }
        #endregion

        #region 短信通知
        #endregion
    }
}
