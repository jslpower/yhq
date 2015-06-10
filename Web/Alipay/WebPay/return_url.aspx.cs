using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Collections.Generic;
using Com.Alipay;



namespace Eyousoft_yhq.Web.Alipay.WebPay
{
    public partial class return_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号

                    string out_trade_no = Request.QueryString["out_trade_no"];

                    //支付宝交易号

                    string trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    string trade_status = Request.QueryString["trade_status"];


                    Eyousoft_yhq.BLL.Order OrderType = new Eyousoft_yhq.BLL.Order();
                    var OrderModel = new Eyousoft_yhq.Model.Order();
                    string res = string.Empty;
                    if (trade_status == "TRADE_FINISHED")
                    {

                    }

                    else if (Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        OrderModel = OrderType.GetModel(out_trade_no);
                        if (OrderModel != null && OrderModel.PayState != Eyousoft_yhq.Model.PaymentState.已支付)
                        {

                            Eyousoft_yhq.Model.MConDetaile jilu = new Eyousoft_yhq.Model.MConDetaile()
                            {
                                HuiYuanID = OrderModel.MemberID,
                                XFway = Eyousoft_yhq.Model.XFfangshi.消费,
                                DingDanBianHao = OrderModel.OrderCode,
                                JiaoYiHao = DateTime.Now.ToString("yyyyMMddHHmm") + Eyousoft_yhq.SQLServerDAL.Utils.GetRandomString(5),
                                JiaoYiShiJian = DateTime.Now,
                                DDCarrtes = Eyousoft_yhq.Model.DDleibie.旅游订单,
                                JinE = OrderModel.OrderPrice
                            };
                            new Eyousoft_yhq.BLL.BConDetaile().Add(jilu);//消费记录


                            string Ra = Eyousoft_yhq.SQLServerDAL.Utils.GetRandomString(12);
                            while (OrderType.Exists(Ra))
                            {
                                Ra = Eyousoft_yhq.SQLServerDAL.Utils.GetRandomString(12);
                            }
                            Eyousoft_yhq.Model.Order OrderInfo = new Eyousoft_yhq.Model.Order()
                            {
                                OrderID = out_trade_no,
                                PayState = Eyousoft_yhq.Model.PaymentState.已支付,
                                ConfirmCode = Ra,
                                OrderState = Eyousoft_yhq.Model.OrderState.已成交
                            };
                            int Sum = OrderType.UpdatePayState(OrderInfo);
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
                                    Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(OrderModel.MemberTel, code, channel[0], out res);//发送
                                    #endregion
                                    #region  短信日志
                                    Eyousoft_yhq.Model.MsgLog MsLog = new Eyousoft_yhq.Model.MsgLog
                                    {
                                        TelCode = OrderModel.MemberTel,
                                        MsgText = code,
                                        ReResult = res
                                    };
                                    new Eyousoft_yhq.BLL.MsgLog().Add(MsLog);
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
                    Response.Redirect("/Huiyuan/OrderList.aspx");

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
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
        }
    }
}
