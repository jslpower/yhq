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
using System.Xml;
using Eyousoft_yhq.AlipayLibrary;

namespace Eyousoft_yhq.Web.Alipay
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.VerifyNotify(sPara, Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //解密（如果是RSA签名需要解密，如果是MD5签名则下面一行清注释掉）
                    sPara = aliNotify.Decrypt(sPara);

                    //XML解析notify_data数据
                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(sPara["notify_data"]);
                        //商户订单号
                        string out_trade_no = xmlDoc.SelectSingleNode("/notify/out_trade_no").InnerText;
                        //支付宝交易号
                        string trade_no = xmlDoc.SelectSingleNode("/notify/trade_no").InnerText;
                        //交易状态
                        string trade_status = xmlDoc.SelectSingleNode("/notify/trade_status").InnerText;

                        if (trade_status == "TRADE_FINISHED")//交易成功
                        {
                            Response.Write("success");
                        }
                        else if (trade_status == "TRADE_SUCCESS")//支付成功
                        {
                            Eyousoft_yhq.BLL.Order OrderType = new Eyousoft_yhq.BLL.Order();
                            var OrderModel = new Eyousoft_yhq.Model.Order();
                            OrderModel = OrderType.GetModel(out_trade_no);
                            string res = string.Empty;
                            if (OrderModel.PayState != Eyousoft_yhq.Model.PaymentState.已支付)
                            {
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
                                    OrderState = Eyousoft_yhq.Model.OrderState.已成交,
                                    JIESUAN = Eyousoft_yhq.Model.JSfangshi.预付

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
                            Response.Redirect("/AppPage/orderlist.aspx");
                        }
                        else
                        {
                            Response.Write(trade_status);
                        }

                    }
                    catch (Exception exc)
                    {
                        Response.Write(exc.ToString());
                    }



                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

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
        public Dictionary<string, string> GetRequestPost()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
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
