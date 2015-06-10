namespace PayAPI.Tencent.Core
{
    using System;
    using System.Text;
    using System.Web;

    /// <summary>
    /// 即时到帐请求类
    /// </summary>
    /// 即时到帐请求类
    /// ============================================================================
    /// api说明：
    /// init(),初始化函数，默认给一些参数赋值，如cmdno,date等。
    /// getGateURL()/setGateURL(),获取/设置入口地址,不包含参数值
    /// getKey()/setKey(),获取/设置密钥
    /// getParameter()/setParameter(),获取/设置参数值
    /// getAllParameters(),获取所有参数
    /// getRequestURL(),获取带参数的请求URL
    /// doSend(),重定向到财付通支付
    /// getDebugInfo(),获取debug信息
    /// 
    /// ============================================================================
    public class PayRequestHandler : RequestHandler
    {
        public PayRequestHandler(HttpContext httpContext)
            : base(httpContext)
        {
            //base.setGateUrl("https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi");
        }

        ///// @Override
        ///// 创建签名
        //protected override void createSign()
        //{
        //    string str = base.getParameter("cmdno");
        //    string str2 = base.getParameter("date");
        //    string str3 = base.getParameter("bargainor_id");
        //    string str4 = base.getParameter("transaction_id");
        //    string str5 = base.getParameter("sp_billno");
        //    string str6 = base.getParameter("total_fee");
        //    string str7 = base.getParameter("fee_type");
        //    string str8 = base.getParameter("return_url");
        //    string str9 = base.getParameter("attach");
        //    string str10 = base.getParameter("spbill_create_ip");
        //    base.getParameter("key");
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("cmdno=" + str + "&");
        //    builder.Append("date=" + str2 + "&");
        //    builder.Append("bargainor_id=" + str3 + "&");
        //    builder.Append("transaction_id=" + str4 + "&");
        //    builder.Append("sp_billno=" + str5 + "&");
        //    builder.Append("total_fee=" + str6 + "&");
        //    builder.Append("fee_type=" + str7 + "&");
        //    builder.Append("return_url=" + str8 + "&");
        //    builder.Append("attach=" + str9 + "&");
        //    if (!"".Equals(str10))
        //    {
        //        builder.Append("spbill_create_ip=" + str10 + "&");
        //    }
        //    builder.Append("key=" + base.getKey());
        //    string parameterValue = MD5Util.GetMD5(builder.ToString(), this.getCharset());
        //    base.setParameter("sign", parameterValue);
        //    base.setDebugInfo(builder.ToString() + " => sign:" + parameterValue);
        //}

        ///// @Override
        ///// 初始化函数，默认给一些参数赋值，如cmdno,date等。
        //public override void init()
        //{
        //    base.setParameter("cmdno", TenPaySystem.Paymethod);
        //    base.setParameter("date", DateTime.Now.ToString("yyyyMMdd"));
        //    base.setParameter("bargainor_id", "");
        //    base.setParameter("transaction_id", "");
        //    base.setParameter("sp_billno", "");
        //    base.setParameter("total_fee", "");
        //    base.setParameter("fee_type", "1");
        //    base.setParameter("return_url", "");
        //    base.setParameter("attach", "");
        //    base.setParameter("spbill_create_ip", "");
        //    base.setParameter("desc", "");
        //    base.setParameter("bank_type", "0");
        //    base.setParameter("cs", TenPaySystem.Inputcharset);
        //    base.setParameter("sign", "");
        //}
    }
}

