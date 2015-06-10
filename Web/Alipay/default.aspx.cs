using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.AlipayLibrary;
using System.Text;

namespace Eyousoft_yhq.Web.Alipay
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 订单信息
            string tmpOrderId = Request.QueryString["OrderId"];
            Eyousoft_yhq.BLL.Order OrderInfo = new Eyousoft_yhq.BLL.Order();
            Eyousoft_yhq.Model.Order OrderModel = null;
            if (!string.IsNullOrEmpty(tmpOrderId))
            {
                OrderModel = OrderInfo.GetModel(tmpOrderId);
                if (OrderModel != null)
                {
                    if (OrderModel.OrderPrice <= 0)
                    {
                        Response.Write("支付金额必须大于0才能支付！");
                        Response.End();

                    }
                    else if (OrderModel.OrderState != Eyousoft_yhq.Model.OrderState.待付款)
                    {
                        Response.Write("订单状态不符合请稍候支付");
                        Response.End();
                    }
                    else if (OrderModel.PayState != Eyousoft_yhq.Model.PaymentState.未支付)
                    {
                        Response.Write("订单已支付");
                        Response.End();
                    }
                }
            }
            else
            {
                Response.Write("订单错误");
                Response.End();
            }
            #endregion

            #region 手机支付宝 支付
            //支付宝网关地址
            string GATEWAY_NEW = "http://wappaygw.alipay.com/service/rest.htm?";

            ////////////////////////////////////////////调用授权接口alipay.wap.trade.create.direct获取授权码token////////////////////////////////////////////

            //返回格式
            string format = "xml";
            //必填，不需要修改

            //返回格式
            string v = "2.0";
            //必填，不需要修改

            //请求号
            string req_id = DateTime.Now.ToString("yyyyMMddHHmmss");
            //必填，须保证每次请求都是唯一

            //req_data详细信息

            //服务器异步通知页面路径
            string notify_url = AlipayLibrary.Config.GetConfigString("Alipay", "app_notify_url");// "http://www.xxx.com/Alipay/notify_url.aspx";
            //需http://格式的完整路径，不允许加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string call_back_url = AlipayLibrary.Config.GetConfigString("Alipay", "app_callback_url");// "http://127.0.0.1:64704/Alipay/call_back_url.aspx";
            //需http://格式的完整路径，不允许加?id=123这类自定义参数

            //操作中断返回地址
            string merchant_url = AlipayLibrary.Config.GetConfigString("Alipay", "app_return_url");
            //用户付款中途退出返回商户的地址。需http://格式的完整路径，不允许加?id=123这类自定义参数

            #region 订单信息|卖家帐号
            //卖家支付宝帐户
            string seller_email =AlipayLibrary.Config.GetConfigString("appSettings", "AlipayAccount");
            //必填

            //商户订单号
            string out_trade_no = OrderModel.OrderID;
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = "产品名称：" + OrderModel.ProductName;
            //必填

            //付款金额
            string total_fee = OrderModel.OrderPrice.ToString();
            //必填
            #endregion

            //请求业务参数详细
            string req_dataToken = "<direct_trade_create_req><notify_url>" + notify_url + "</notify_url><call_back_url>" + call_back_url + "</call_back_url><seller_account_name>" + seller_email + "</seller_account_name><out_trade_no>" + out_trade_no + "</out_trade_no><subject>" + subject + "</subject><total_fee>" + total_fee + "</total_fee><merchant_url>" + merchant_url + "</merchant_url></direct_trade_create_req>";
            //必填

            //把请求参数打包成数组
            Dictionary<string, string> sParaTempToken = new Dictionary<string, string>();
            sParaTempToken.Add("partner", Config.Partner);
            sParaTempToken.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTempToken.Add("sec_id", Config.Sign_type.ToUpper());
            sParaTempToken.Add("service", "alipay.wap.trade.create.direct");
            sParaTempToken.Add("format", format);
            sParaTempToken.Add("v", v);
            sParaTempToken.Add("req_id", req_id);
            sParaTempToken.Add("req_data", req_dataToken);

            //建立请求
            string sHtmlTextToken = Submit.BuildRequest(GATEWAY_NEW, sParaTempToken);
            //URLDECODE返回的信息
            Encoding code = Encoding.GetEncoding(Config.Input_charset);
            sHtmlTextToken = HttpUtility.UrlDecode(sHtmlTextToken, code);

            //解析远程模拟提交后返回的信息
            Dictionary<string, string> dicHtmlTextToken = Submit.ParseResponse(sHtmlTextToken);

            //获取token
            string request_token = dicHtmlTextToken["request_token"];

            ////////////////////////////////////////////根据授权码token调用交易接口alipay.wap.auth.authAndExecute////////////////////////////////////////////


            //业务详细
            string req_data = "<auth_and_execute_req><request_token>" + request_token + "</request_token></auth_and_execute_req>";
            //必填

            //把请求参数打包成数组
            Dictionary<string, string> sParaTemp = new Dictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("sec_id", Config.Sign_type.ToUpper());
            sParaTemp.Add("service", "alipay.wap.auth.authAndExecute");
            sParaTemp.Add("format", format);
            sParaTemp.Add("v", v);
            sParaTemp.Add("req_data", req_data);

            //建立请求
            string sHtmlText = Submit.BuildRequest(GATEWAY_NEW, sParaTemp, "get", "确认");
            Response.Write(sHtmlText);

            #endregion
        }

        
    }
}
