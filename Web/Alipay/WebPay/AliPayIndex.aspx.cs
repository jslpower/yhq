using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Eyousoft_yhq.Web.Alipay.WebPay
{
    public partial class AliPayIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Err = string.Empty;
            string tmpOrderId = Request.QueryString["OrderId"];
            string type = Request.QueryString["type"];
            string totalfee = "";
            string subject = "";
            string body = "";
            string orderList = "";
            if (type == "1")
            {
                Err = getZFOrder(tmpOrderId, ref subject, ref body, ref totalfee, ref orderList);
            }
            else
            {
                Err = GetOrderInfo(tmpOrderId, ref subject, ref body, ref totalfee, ref orderList);
            }
            if (!string.IsNullOrEmpty(Err))
            {
                Response.Write(Err);
                Response.End();
            }
            else
            {
                AliPayReturn(orderList, subject, body, totalfee);
            }
        }


        private string GetOrderInfo(string PayOrderId, ref string subject, ref string body, ref string totalfee, ref string orderList)
        {
            if (string.IsNullOrEmpty(PayOrderId) || PayOrderId.Length <= 0) return "要支付的订单不存在！";


            var info = new Eyousoft_yhq.BLL.Order().GetModel(PayOrderId);

            if (info == null) return "要支付的订单不存在!";

            if (info.PayState == Eyousoft_yhq.Model.PaymentState.已支付) return "订单已支付！";
            if (info.OrderState != Eyousoft_yhq.Model.OrderState.待付款) return "订单正在审核当中请稍候支付！";
            if (info.OrderPrice <= 0) return "支付金额必须大于0才能支付！";
            subject = "订单名称：" + info.ProductName;
            body = "订单名称：" + info.ProductName + "，总金额：" + info.OrderPrice.ToString("C0") + " 元";

            totalfee = info.OrderPrice.ToString("0.00");

            orderList = PayOrderId;  //订单ID

            return string.Empty;
        }
        /// <summary>
        /// 账户充值
        /// </summary>
        /// <param name="PayOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string getZFOrder(string PayOrderId, ref string subject, ref string body, ref string totalfee, ref string orderList)
        {
            if (string.IsNullOrEmpty(PayOrderId) || PayOrderId.Length <= 0) return "要支付的订单不存在！";


            var info = new Eyousoft_yhq.BLL.BChongZhi().GetModel(PayOrderId);

            if (info == null) return "要支付的订单不存在!";

            if (info.PayState == Eyousoft_yhq.Model.PaymentState.已支付) return "订单已支付！";
            //if (info.OrderState != Eyousoft_yhq.Model.OrderState.待付款) return "订单正在审核当中请稍候支付！";
            if (info.OptMoney <= 0) return "支付金额必须大于0才能支付！";
            subject = "账户充值";
            body = "账户充值，总金额：" + info.OptMoney.ToString("C0") + " 元";

            totalfee = info.OptMoney.ToString("0.00");

            orderList = PayOrderId;  //订单ID

            return string.Empty;
        }

        #region 支付宝
        private void AliPayReturn(string orderID, string Subject, string Body, string Totalfee)
        {
            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径notify_url
            string notify_url = AlipayLibrary.Config.GetConfigString("Alipay", "notify_url");
            //"http://www.xxx.com/create_direct_pay_by_user-CSHARP-UTF-8/notify_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = AlipayLibrary.Config.GetConfigString("Alipay", "return_url");// "http://www.xxx.com/create_direct_pay_by_user-CSHARP-UTF-8/return_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //卖家支付宝帐户
            string seller_email = AlipayLibrary.Config.GetConfigString("appSettings", "AlipayAccount");
            //必填

            //商户订单号
            string out_trade_no = orderID;
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = Subject;
            //必填

            //付款金额
            string total_fee = Totalfee;
            //必填

            //订单描述

            string body = Body;
            //商品展示地址
            string show_url = AlipayLibrary.Config.GetConfigString("Alipay", "notify_url");
            //需以http://开头的完整路径，例如：http://www.xxx.com/myorder.html

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = "";
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Com.Alipay.Config.Partner);
            sParaTemp.Add("_input_charset", Com.Alipay.Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("seller_email", seller_email);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

            //建立请求
            string sHtmlText = Com.Alipay.Submit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);
        }
        #endregion
    }
}
