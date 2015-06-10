using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookies = "";
            EyouSoft.Toolkit.request.create("http://localhost:9984/TenPay/notify_url.aspx", "", EyouSoft.Toolkit.Method.POST, "<xml><appid><![CDATA[wx935e1ca713dff84f]]></appid><bank_type><![CDATA[CFT]]></bank_type><cash_fee><![CDATA[1]]></cash_fee><fee_type><![CDATA[CNY]]></fee_type><is_subscribe><![CDATA[Y]]></is_subscribe><mch_id><![CDATA[1230569102]]></mch_id><nonce_str><![CDATA[CFA0860E83A4C3A763A7E62D825349F7]]></nonce_str><openid><![CDATA[ouCeqjhgBlikzj4djxvKNXzPwfAY]]></openid><out_trade_no><![CDATA[CZ201504201522592553]]></out_trade_no><result_code><![CDATA[SUCCESS]]></result_code><return_code><![CDATA[SUCCESS]]></return_code><sign><![CDATA[C42F6E75ACE7D475029ED774164F0865]]></sign><time_end><![CDATA[20150420152311]]></time_end><total_fee>1</total_fee><trade_type><![CDATA[JSAPI]]></trade_type><transaction_id><![CDATA[1006600795201504200077229006]]></transaction_id></xml>", ref cookies, false);

            Console.ReadLine();
        }
    }
}
