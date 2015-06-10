using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web
{
    public partial class OrderStep1 : EyouSoft.Common.Page.HuiyuanPage
    {
        protected int numS = 0;
        protected string Gname, Gmobile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("orderReceive") == "1")
            {
                Response.Clear();
                Response.Write(saveOrder());
                Response.End();
            }

            initPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void initPage()
        {
            string id = Utils.GetQueryStringValue("id");
            int orderNums = 1;
            var model = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (model != null)
            {
                lbl_Pname.Text = model.ProductName;
                lbl_Price.Text = model.AppPrice.ToString("C0");
                decimal getPrice = orderNums * model.AppPrice;
                singlePirce.Value = model.AppPrice.ToString("0");
                sumPirce.Value = model.AppPrice.ToString("0");
                lbl_SumPrice.Text = getPrice.ToString("C0");
                lbl_orderPrice.Text = getPrice.ToString("0");
                numS = model.ResidueNum;
            }

            var MemberModel = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (MemberModel != null)
            {
                Gname = MemberModel.ContactName;
                Gmobile = MemberModel.UserName;
            }

        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <returns></returns>
        private string saveOrder()
        {
            Eyousoft_yhq.Model.OrderState Orderstate = Eyousoft_yhq.Model.OrderState.未处理;
            int orderNums = Utils.GetInt(Utils.GetFormValue("orderNum"));
            string id = Utils.GetFormValue("id");
            var model = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (model != null)
            {
                if (model.ResidueNum - orderNums >= 0)
                {
                    Orderstate = Eyousoft_yhq.Model.OrderState.待付款;
                }
                Eyousoft_yhq.BLL.Order OrderBll = new Eyousoft_yhq.BLL.Order();
                var MemberModel = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
                if (MemberModel != null)
                {
                    Eyousoft_yhq.Model.Order OrderModel = new Eyousoft_yhq.Model.Order()
                    {
                        ProductID = id,
                        OrderCode = DateTime.Now.ToString("yyyy-MM-dd "),
                        MemberID = MemberModel.UserID,
                        MemberTel = Utils.GetFormValue("receiveMobile"),
                        MemberName = Utils.GetFormValue("receiveName"),
                        MemberSex = MemberModel.ContactSex,
                        OrderState = Orderstate,
                        PayState = Eyousoft_yhq.Model.PaymentState.未支付,
                        IsCheck = true,
                        ConfirmCode = "",
                        Remark = "",
                        OrderPrice = model.AppPrice * orderNums,
                        PeopleNum = orderNums
                    };
                    int num = OrderBll.Add(OrderModel);
                    if (num > 0 && Orderstate == Eyousoft_yhq.Model.OrderState.待付款)
                    {
                        return UtilsCommons.AjaxReturnJson("1", "操作成功,请及时付款!", OrderModel.OrderID);
                    }
                    if (num > 0 && Orderstate == Eyousoft_yhq.Model.OrderState.未处理)
                    {
                        string result = string.Empty;//返回发送结果
                        string sendNum = string.Empty; //发送账号
                        Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
                        if (exModel == null || exModel.MsgNumber <= 0) return UtilsCommons.AjaxReturnJson("2", "操作成功,等待审核！短信发送失败，请联系我们！");
                        IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
                        var ProductTypeModel = new Eyousoft_yhq.BLL.ProductType().GetModel(model.ProductType);

                        if (ProductTypeModel == null || ProductTypeModel.AdminName == null) 
                        {
                            sendNum = HuiYuanInfo.ContactTel;
                            string Msg = "收到新订单请处理，订单号为：" + OrderModel.OrderCode.Trim() + "！【惠旅游】";

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
                        else
                        {
                            for (int i = 0; i < ProductTypeModel.AdminName.Count; i++)
                            {
                                sendNum = new Eyousoft_yhq.BLL.User().GetModel(ProductTypeModel.AdminName[i].AdminN).Telephone;
                                string Msg = "收到新订单请处理，订单号为：" + OrderModel.OrderCode.Trim() + "！【惠旅游】";

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
                        if (result == "成功") return UtilsCommons.AjaxReturnJson("2", "操作成功,等待审核！已通知客服人员！");
                        return UtilsCommons.AjaxReturnJson("2", "操作成功,等待审核！短信发送失败，请联系我们！");

                    }
                    return UtilsCommons.AjaxReturnJson("0", "操作失败!");
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "操作失败，请登陆后重新操作... ...");
                }
            }
            return UtilsCommons.AjaxReturnJson("0", "操作失败，此产品已经下架... ...");

        }


    }
}
