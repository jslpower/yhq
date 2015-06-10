using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayAPI.Model.Tencent;
using EyouSoft.Common;
using Eyousoft_yhq.BLL;
using PayAPI.Tencent;



namespace Enow.TZB.Web.TenPay
{
    /// <summary>
    /// 正式版微信支付
    /// </summary>
    public partial class P : System.Web.UI.Page
    {
        protected TenPayTrade TenPayTradeModel = new TenPayTrade();
        protected PrePay _TenPayTradeModel = new PrePay();
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected string weixin_jsapi_config = string.Empty;
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (userInfo == null) Response.Redirect("/APPPAGE/WEIXIN/LOGIN.ASPX");
                //string _weidianurl = "https://open.weixin.qq.com/connect/oauth2/authorize?";
                //_weidianurl += "appid=" + Utils.GetConfigString("", "YHQAppId").Trim();
                //_weidianurl += "&redirect_uri=http://www.4008005216.com/WeiXin/oauth2_authorize.aspx";
                //_weidianurl += "&response_type=code";
                //_weidianurl += "&scope=snsapi_base";
                //_weidianurl += "&state=weidian_snsapi_base";
                //_weidianurl += "#wechat_redirect";
                BWeiXin bll = new BWeiXin();
                var weixin = new BWeiXin().GetInfo3(userInfo.UserID);
                #region 验证
                string OpenId = weixin.openid;
                string s = Utils.GetQueryStringValue("id");
                if (!string.IsNullOrEmpty(s))
                {
                    InitMember(OpenId, s.Trim());
                }
                #endregion
            }
            var weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("chooseWXPay");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);

            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 处理支付信息
        /// </summary>
        /// <param name="OpenId">OpenId</param>
        /// <param name="Id">支付编号</param>
        private void InitMember(string OpenId, string Id)
        {
            var model = new BWeiXin().GetInfo2(OpenId);
            if (model != null)
            {
                //取得支付信息
                var PayModel = new Eyousoft_yhq.BLL.BChongZhi().GetModel(Id);
                if (PayModel != null)
                {
                    this.lblAccount.Text = PayModel.OptMoney.ToString("F2");
                    this.lblCope.Text = PayModel.OptMoney.ToString("F2");
                    #region 初始化支付信息
                    Tenpay pay = new Tenpay();
                    TenPayTradeModel.OPENID = OpenId;
                    TenPayTradeModel.Totalfee = PayModel.OptMoney;
                    TenPayTradeModel.UserIP = Utils.GetRemoteIP();
                    TenPayTradeModel.OutTradeNo = PayModel.OrderCode;
                    TenPayTradeModel.OrderInfo.Body = "充值金额:" + PayModel.OptMoney.ToString("F2") + "元";

                    _TenPayTradeModel = pay.Create_url(TenPayTradeModel);
                    #endregion
                }
            }

        }
    }
}