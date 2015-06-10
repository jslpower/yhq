namespace PayAPI.Tencent.Core
{
    using System;
    using System.Text;
    using System.Web;

    /// <summary>
    /// PayResponseHandler 的摘要说明。
    /// </summary>
    /// 即时到帐应答类
    /// ============================================================================
    /// api说明：
    /// getKey()/setKey(),获取/设置密钥
    /// getParameter()/setParameter(),获取/设置参数值
    /// getAllParameters(),获取所有参数
    /// isTenpaySign(),是否财付通签名,true:是 false:否
    /// doShow(),显示处理结果
    /// getDebugInfo(),获取debug信息
    /// 
    /// ============================================================================
    public class PayResponseHandler : ResponseHandler
    {
        public PayResponseHandler(HttpContext httpContext) : base(httpContext)
        {
        }

        /// 是否财付通签名
        /// @Override
        /// @return boolean
        public override bool isTenpaySign()
        {
            string str = base.getParameter("cmdno");
            string str2 = base.getParameter("pay_result");
            string str3 = base.getParameter("date");
            string str4 = base.getParameter("transaction_id");
            string str5 = base.getParameter("sp_billno");
            string str6 = base.getParameter("total_fee");
            string str7 = base.getParameter("fee_type");
            string str8 = base.getParameter("attach");
            string str9 = base.getParameter("sign").ToUpper();
            string str10 = base.getKey();
            StringBuilder builder = new StringBuilder();
            builder.Append("cmdno=" + str + "&");
            builder.Append("pay_result=" + str2 + "&");
            builder.Append("date=" + str3 + "&");
            builder.Append("transaction_id=" + str4 + "&");
            builder.Append("sp_billno=" + str5 + "&");
            builder.Append("total_fee=" + str6 + "&");
            builder.Append("fee_type=" + str7 + "&");
            builder.Append("attach=" + str8 + "&");
            builder.Append("key=" + str10);
            string str11 = MD5Util.GetMD5(builder.ToString(), this.getCharset());
            base.setDebugInfo(builder.ToString() + " => sign:" + str11 + " tenpaySign:" + str9);
            return str11.Equals(str9);
        }
    }
}

