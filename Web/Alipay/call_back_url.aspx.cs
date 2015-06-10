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
using Eyousoft_yhq.AlipayLibrary;
using EyouSoft.Common;
using ZXing.QrCode;
using ZXing;
using System.Drawing;
using System.IO;

namespace Eyousoft_yhq.Web.Alipay
{
    public partial class call_back_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.VerifyReturn(sPara, Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表

                    //商户订单号
                    string out_trade_no = Request.QueryString["out_trade_no"];

                    //支付宝交易号
                    string trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    string result = Request.QueryString["result"];

                    Eyousoft_yhq.BLL.Order OrderType = new Eyousoft_yhq.BLL.Order();
                    var OrderModel = new Eyousoft_yhq.Model.Order();
                    string res = string.Empty;
                    if (result == "success")
                    {
                        //纪录充值消费纪录
                        try
                        {
                            string price = Request.QueryString["price"];
                            Eyousoft_yhq.BLL.BConDetaile service = new Eyousoft_yhq.BLL.BConDetaile();
                            Eyousoft_yhq.Model.MConDetaile con = new Eyousoft_yhq.Model.MConDetaile();
                            con.JiaoYiHao = trade_no;
                            con.DingDanBianHao = out_trade_no;
                            con.JinE = Decimal.Parse(price);
                            con.JiaoYiShiJian = DateTime.Now;
                            con.XFway = Eyousoft_yhq.Model.XFfangshi.消费;

                            EyouSoft.Model.SSOStructure.MUserInfo userInfo = Session["HuiYuanInfo"] as EyouSoft.Model.SSOStructure.MUserInfo;
                            con.HuiYuanID = userInfo.UserID;
                            service.Add(con);
                        }
                        catch (Exception)
                        {


                        }

                        OrderModel = OrderType.GetModel(out_trade_no);
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
                                    //code = CreateZxingCode(Ra) + string.Format("下单成功，确认码：{0}！【惠旅游】", Ra);//生成二维码，发送彩信

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
                    }


                    Response.Redirect("/AppPage/orderlist.aspx");

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("验证失败");
                }
            }
            else
            {
                Response.Write("无返回参数");
            }
        }
        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public Dictionary<string, string> GetRequestGet()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
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
