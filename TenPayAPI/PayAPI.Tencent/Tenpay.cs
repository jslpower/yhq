namespace PayAPI.Tencent
{
    using PayAPI.Model;
    using PayAPI.Model.Tencent;
    using PayAPI.Tencent.Core;
    using System;
    using System.Text;
    using System.Web;
    using System.Xml.Linq;
    using System.Linq;

    /// <summary>
    /// 财付通接口
    /// </summary>
    public class Tenpay
    {
        public Tenpay()
        {
        }

        /// <summary>
        /// 构造支付
        /// </summary>
        /// <param name="trade">交易业务实体</param>
        /// <returns></returns>
        public PrePay Create_url(TenPayTrade trade)
        {
            string s = "";
            if (trade.OrderInfo.OrderID.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string str2 in trade.OrderInfo.OrderID)
                {
                    builder.Append(str2 + ",");
                }
                if (builder.Length > 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
                Attach model = new Attach();
                model.Key = "OId";
                model.Value = builder.ToString();
                trade.AttachList.Add(model);
                model = null;
            }
            s = trade.AttachList.ToString();

            RequestHandler handler = new RequestHandler(HttpContext.Current);

            handler.init();
            handler.setKey(TenPaySystem.Key);
            handler.setParameter("mch_id", TenPaySystem.BargainorId);
            handler.setParameter("trade_type", "JSAPI");
            handler.setParameter("out_trade_no", trade.OutTradeNo);
            handler.setParameter("total_fee", (trade.Totalfee * 100M).ToString("F0"));
            handler.setParameter("notify_url", TenPaySystem.NotifyUrl);
            handler.setParameter("body", trade.OrderInfo.Body/*trade.OrderInfo.Subject*/);
            handler.setParameter("spbill_create_ip", trade.UserIP);
            handler.setParameter("openid", trade.OPENID);
            handler.setParameter("appid", TenPaySystem.appid);
            handler.setParameter("nonce_str", TenpayUtil.getNoncestr());
            handler.createMd5Sign();



            string xml = Toolkit.request.post("https://api.mch.weixin.qq.com/pay/unifiedorder", handler.parseXML(), "");

            var xrss = XElement.Parse(xml);
            var return_code = Toolkit.StringExtensions.GetXElement(xrss, "return_code").Value;
            var return_msg = Toolkit.StringExtensions.GetXElement(xrss, "return_msg").Value;
            var result_code = Toolkit.StringExtensions.GetXElement(xrss, "result_code").Value;
            var prepay_id = Toolkit.StringExtensions.GetXElement(xrss, "prepay_id").Value;
            var nonce_str = Toolkit.StringExtensions.GetXElement(xrss, "nonce_str").Value;
            var sign = Toolkit.StringExtensions.GetXElement(xrss, "sign").Value;

            PrePay Pay = new PrePay();

            if (return_code == "SUCCESS")
                Pay.ReqState = true;

            if (result_code == "SUCCESS")
                Pay.IsSuccess = true;


            string timeStamp = TenpayUtil.getTimestamp();
            string Noncestr = TenpayUtil.getNoncestr();

            RequestHandler reponse = new RequestHandler(HttpContext.Current);

            reponse.init();
            reponse.setKey(TenPaySystem.Key);
            reponse.setParameter("appId", TenPaySystem.appid);
            reponse.setParameter("timeStamp", timeStamp);
            reponse.setParameter("package", "prepay_id=" + prepay_id);
            reponse.setParameter("nonceStr", Noncestr);
            reponse.setParameter("signType", "MD5");
            sign = reponse.createMd5Sign();

            Pay.ReturnMsg = return_msg;
            Pay.NonceStr = Noncestr;
            Pay.PrepayId = prepay_id;
            Pay.Sign = sign;
            Pay.TimeStamp = timeStamp;


            return Pay;
        }

        /// <summary>
        /// 获得财付通的异步通知信息[注意:处理完消息后请将返回结果中的PayAPICallBackMsg属性传回给财付通，通过Response.Write()方式]
        /// </summary>
        /// <param name="isRoyalty">是否带分润功能</param>
        /// <returns></returns>
        public TenPayTradeNotify GetNotifyAsync()
        {
            TenPayTradeNotify notify = new TenPayTradeNotify();
            ResponseHandler resHandler = new ResponseHandler(HttpContext.Current);
            resHandler.init();
            resHandler.setKey(TenPaySystem.Key, TenPaySystem.appkey);
            
            //判断签名
            if (resHandler.isTenpaySign())
            {

                //支付结果
                string return_code = resHandler.getParameter("return_code");
                //支付结果
                string result_code = resHandler.getParameter("result_code");

                //即时到账
                if ("SUCCESS".Equals(return_code) && "SUCCESS".Equals(result_code))
                {
                    //取结果参数做业务处理
                    string out_trade_no = resHandler.getParameter("out_trade_no");
                    //财付通订单号
                    string transaction_id = resHandler.getParameter("transaction_id");
                    //金额,以分为单位
                    string total_fee = resHandler.getParameter("total_fee");

                    string sign = resHandler.getParameter("sign");

                    string noncestr = resHandler.getParameter("nonce_str");

                    notify.PayNotify.IsSuccess = true;
                    notify.PayNotify.ReqState = true;
                    notify.IsTradeSuccess = true;
                    notify.PayNotify.NonceStr = noncestr;
                    notify.PayNotify.Sign = sign;

                    notify.OutTradeNo = out_trade_no;
                    notify.Totalfee = decimal.Parse(total_fee);
                    if (notify.Totalfee > 0M)
                    {
                        notify.Totalfee /= 100.0M;
                    }
                    notify.TradeNo = transaction_id;
                }
                else
                {
                    if ("FAIL".Equals(return_code))
                        notify.PayNotify.ReturnMsg = resHandler.getParameter("return_msg");
                    else

                        notify.PayNotify.ReturnMsg = resHandler.getParameter("err_code_des");

                }
            }
            else
            {
                notify.PayNotify.ReturnMsg = "签名错误";
            }

            return notify;
        }
    }
}

