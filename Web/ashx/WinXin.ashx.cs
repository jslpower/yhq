using System;
using System.Collections.Generic;
using System.Web;

namespace Eyousoft_yhq.Web.ashx
{
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            String postStr = String.Empty;

            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            {
                Web.BsendMsg.WeiXin.MsgHandler();


            }
            else
            {
                HttpContext.Current.Response.Write(Web.BsendMsg.WeiXin.Auth());
                HttpContext.Current.Response.End();
            }

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
