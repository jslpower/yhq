using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ValidateCode : IHttpHandler
    {
        private string CookieName = "SYS_TieLv_VC";
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["ValidateCodeName"]))
            {
                CookieName = context.Request.QueryString["ValidateCodeName"];
            }
            getNumbers(4, context);
        }

        private void getNumbers(int len, HttpContext context)
        {
            ValidateNumberAndChar.CurrentLength = len;
            ValidateNumberAndChar.CurrentNumber = ValidateNumberAndChar.CreateValidateNumber(ValidateNumberAndChar.CurrentLength);
            string number = ValidateNumberAndChar.CurrentNumber;
            ValidateNumberAndChar.CreateValidateGraphic(context, number);
            context.Response.Cookies[CookieName].Value = number;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
