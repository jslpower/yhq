using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Com.Alipay;

namespace Eyousoft_yhq.Web.Alipay.WebPay
{
    public partial class Alipay_Notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号

                    string out_trade_no = Request.Form["out_trade_no"];

                    //支付宝交易号

                    string trade_no = Request.Form["trade_no"];

                    //交易状态
                    string trade_status = Request.Form["trade_status"];


                    if (Request.Form["trade_status"] == "TRADE_FINISHED")
                    {
                        Response.Write("success");
                    }
                    else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {

                        var OrderModel = new Eyousoft_yhq.Model.Order();
                        var OrderBll = new Eyousoft_yhq.BLL.Order();
                        OrderModel = OrderBll.GetModel(out_trade_no);
                        if (OrderModel != null && OrderModel.PayState == Eyousoft_yhq.Model.PaymentState.未支付)
                        {
                            string result = string.Empty;
                            string Ra = Eyousoft_yhq.SQLServerDAL.Utils.GetRandomString(12);
                            while (OrderBll.Exists(Ra))
                            {
                                Ra = Eyousoft_yhq.SQLServerDAL.Utils.GetRandomString(12);
                            }
                            OrderModel.OrderID = out_trade_no;
                            OrderModel.PayState = Eyousoft_yhq.Model.PaymentState.已支付;
                            OrderModel.OrderState = Eyousoft_yhq.Model.OrderState.已成交;
                            OrderModel.ConfirmCode = Ra;
                            int Sum = OrderBll.UpdatePayState(OrderModel);
                            if (Sum > 0)
                            {
                                Eyousoft_yhq.BLL.Member UM = new Eyousoft_yhq.BLL.Member();
                                bool Mo = UM.GetModel(OrderModel.MemberID).valiUser;
                                if (!Mo)
                                {
                                    #region 短信发送
                                    string code = string.Empty;
                                    IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
                                    code = string.Format("下单成功，确认码：{0}！【惠旅游】", Ra);
                                    Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(OrderModel.MemberTel, code, channel[0], out result);//发送
                                    #region  短信日志
                                    Eyousoft_yhq.Model.MsgLog MsLog = new Eyousoft_yhq.Model.MsgLog
                                    {
                                        TelCode = OrderModel.MemberTel,
                                        MsgText = code,
                                        ReResult = result
                                    };
                                    new Eyousoft_yhq.BLL.MsgLog().Add(MsLog);
                                    #endregion

                                    #endregion
                                }
                            }
                        }
                        var chongzhiModel = new Eyousoft_yhq.BLL.BChongZhi().GetModel(out_trade_no);
                        if (chongzhiModel != null && chongzhiModel.PayState == Eyousoft_yhq.Model.PaymentState.未支付)
                        {
                            var member = new Eyousoft_yhq.BLL.Member().GetModel(chongzhiModel.OperatorID);
                            if (member != null)
                            {
                                member.YuE = member.YuE + chongzhiModel.OptMoney;
                                bool result = new Eyousoft_yhq.BLL.Member().Update(member);
                            }
                            new Eyousoft_yhq.BLL.BChongZhi().SheZhiZhiFus(out_trade_no, Eyousoft_yhq.Model.PaymentState.已支付);
                        }
                    }
                    else
                    {
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    Response.Write("success");  //请不要修改或删除


                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
    }
}
