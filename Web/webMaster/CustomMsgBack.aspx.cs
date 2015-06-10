using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Domain;
using System.Web.Script.Serialization;
using Weixin.Mp.Sdk.Util;
using EyouSoft.Common;
namespace Eyousoft_yhq.Web.webMaster
{
    public partial class CustomMsgBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Utils.GetQueryStringValue("save") == "save") savePave();

        }
        /// <summary>
        /// 回复数据
        /// </summary>
        void savePave()
        {
            string appId = System.Configuration.ConfigurationManager.AppSettings["YHQAppId"].Trim();
            string appSecret = System.Configuration.ConfigurationManager.AppSettings["YHQAppSecret"].Trim();
            string openid = Utils.GetQueryStringValue("openid");
            string getMsg = Utils.GetFormValue("txtMsg");

            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Console.WriteLine("位置错误..");
                return;
            }
            var response2 = MessageHandler.SendTextCustomMessage(response.AccessToken.AccessToken, openid, getMsg);
            Response.Clear();
            if (response2.IsError)
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "发送失败"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson("1", "发送成功"));
            }
            Response.End();
        }


    }
}
