using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxSendMSG : System.Web.UI.Page
    {
        protected string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sendMark = Utils.GetQueryStringValue("mark");
                string strpid = Utils.GetQueryStringValue("pid");
                string FavourCode = Utils.GetQueryStringValue("cid");
                string SendCode = Utils.GetQueryStringValue("SendCode");
                string Tel = Utils.GetQueryStringValue("Tel");
                string SendAppMark = Utils.GetQueryStringValue("SendAppMark");


                if (sendMark == "1")
                {
                    sendMsg(strpid, FavourCode);
                }
                if (SendCode == "1")
                {
                    //sendCode(Tel);
                    NewSedCode(Tel);//邓保朝 修改 换发送短信方式
                }
                if (SendAppMark == "1")
                {
                    sendAppDown(Tel);
                }
            }
        }

        protected void sendMsg(string pid, string FavourCode)
        {
            Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (exModel.MsgNumber > 0)
            {


                var model = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
                IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
                string code = string.Empty;

                if (model != null && model.UserName != "")
                {

                    bool isSend = new Eyousoft_yhq.BLL.SendMsg().exists(model.UserName, pid, FavourCode);
                    if (isSend)
                    {
                        result = "您已经领取过此产品的优惠码！";
                        return;
                    }
                    if (!model.valiUser)
                    {
                        var sendModel = new Eyousoft_yhq.BLL.Product().GetModel(pid);
                        if (sendModel != null && !sendModel.IsEveryDay)
                        {
                            code = string.Format("您成功获取{0},{3}出团,优惠价{1}元,优惠码:{2}！【惠旅游】"
                                , sendModel.ProductName
                                , sendModel.AppPrice.ToString("C2")
                                , sendModel.FavourCode
                                , Utils.GetDateTime(sendModel.TourDate.ToString()).ToString("yyyy-MM-dd"));

                            Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(model.UserName, code, channel[0], out result);//发送

                        }
                        else if (sendModel != null && sendModel.IsEveryDay)
                        {
                            code = string.Format("您成功获取{0},优惠价{1}元,优惠码:{2}！【惠旅游】"
                                , sendModel.ProductName
                                , sendModel.AppPrice.ToString("C2")
                                , sendModel.FavourCode);

                            Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(model.UserName, code, channel[0], out result);//发送
                        }
                        else
                        {
                            result = "此产品已下架！";
                        }

                        #region  短信日志
                        Eyousoft_yhq.Model.MsgLog MsLog = new Eyousoft_yhq.Model.MsgLog
                        {
                            TelCode = model.UserName,
                            MsgText = code,
                            ReResult = result
                        };
                        new Eyousoft_yhq.BLL.MsgLog().Add(MsLog);
                        #endregion
                    }
                }
                else
                {
                    Response.Redirect("/login.aspx");
                }
                if (result == "成功")
                {
                    int minusNum = code.Length % 70 == 0 ? code.Length / 70 : (code.Length / 70) + 1;
                    new Eyousoft_yhq.BLL.SendMsg().Add(new Eyousoft_yhq.Model.SendMSG
                    {
                        SendNum = model.UserName,
                        SendText = code,
                        IssueTime = DateTime.Now,
                        ProductID = pid,
                        minusNum = minusNum,
                        FavourCode = FavourCode
                    });
                    result = "短信已发送，请注意查收！";
                }
                else
                {
                    result = "领取失败！";
                }
            }
            else
            {
                result = "短信系统维护中，请稍后再试！";
            }
        }


        protected void sendCode(string Tel)
        {
            string Code = string.Empty;
            Code = new Random().Next(100000, 999999).ToString();

            string CodeStr = string.Format("你正在注册惠旅游，验证码：{0}，有效期为五分钟，请不要向别人泄露验证码！如果不是本人操作可以忽略！【惠旅游】", Code);

            Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (exModel.MsgNumber <= 0)
            {
                result = "短信中心维护中！";
                return;
            }

            IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
            Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(Tel, CodeStr, channel[0], out result);//发送
            #region  短信日志
            Eyousoft_yhq.Model.MsgLog MsLogS = new Eyousoft_yhq.Model.MsgLog
            {
                TelCode = Tel,
                MsgText = CodeStr,
                ReResult = result
            };
            new Eyousoft_yhq.BLL.MsgLog().Add(MsLogS);
            #endregion
            if (result == "成功")
            {
                List<string[]> list = new List<string[]>();
                if (Session[Tel] != null)
                {
                    list = Session[Tel] as List<string[]>;
                    if (list.Count > 5)
                    {
                        result = "重复次数过多，请24小时之后再操作！";
                        return;
                    }
                    string[] arrStr = new string[] { Tel, Code, DateTime.Now.ToString() };
                    list.Add(arrStr);

                }
                else
                {
                    list.Add(new string[] { Tel, Code, DateTime.Now.ToString() });
                    Session[Tel] = list;
                }
                Session.Timeout = 1440;
            }
            else
            {
                result = "短信中心维护中！";
            }
        }

        void sendAppDown(string Tel)
        {
            string CodeStr = string.Format("你正在下载惠旅游手机App应用，下载地址：{0} \n如果不是本人操作可以忽略！【惠旅游】", "http://t.cn/8DFctTQ");

            Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (exModel.MsgNumber <= 0)
            {
                result = "短信中心维护中！";
                return;
            }
            IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
            Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(Tel, CodeStr, channel[0], out result);//发送
            #region  短信日志
            Eyousoft_yhq.Model.MsgLog MsLogEnd = new Eyousoft_yhq.Model.MsgLog
            {
                TelCode = Tel,
                MsgText = CodeStr,
                ReResult = result
            };
            new Eyousoft_yhq.BLL.MsgLog().Add(MsLogEnd);
            #endregion
            if (result == "成功")
            {
                result = "短信发送成功，请注意查收！ ";
                return;

            }
            else
            {
                result = "短信中心维护中，请稍后再试！ ";
                return;

            }
        }

        protected void NewSedCode(string Tel)
        {
            string Code = string.Empty;
            Code = new Random().Next(1000, 9999).ToString();
            string SendByteCode = "";
            for (int i = 0; i < Code.Length; i++)
            {
                SendByteCode += Code[i] + "、";
            }
            SendByteCode = SendByteCode.TrimEnd('、');
            string CodeStr = string.Format("你正在注册惠旅游，验证码为{0}，验证码为{0}，有效期为五分钟，请不要向别人泄露验证码！如果不是本人操作可以忽略！【惠旅游】", SendByteCode);

            Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (exModel.MsgNumber <= 0)
            {
                result = "短信中心维护中！";
                return;
            }

            result = Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMSVoice(Tel, CodeStr);



            #region  短信日志
            Eyousoft_yhq.Model.MsgLog MsLogS = new Eyousoft_yhq.Model.MsgLog
            {
                TelCode = Tel,
                MsgText = CodeStr,
                ReResult = result
            };
            new Eyousoft_yhq.BLL.MsgLog().Add(MsLogS);

            #endregion
            if (result == "成功")
            {
                List<string[]> list = new List<string[]>();
                if (Session[Tel] != null)
                {
                    list = Session[Tel] as List<string[]>;
                    if (list.Count > 5)
                    {
                        result = "重复次数过多，请24小时之后再操作！";
                        return;
                    }
                    string[] arrStr = new string[] { Tel, Code, DateTime.Now.ToString() };
                    list.Add(arrStr);

                }
                else
                {
                    list.Add(new string[] { Tel, Code, DateTime.Now.ToString() });
                    Session[Tel] = list;
                }
                Session.Timeout = 1440;
            }
            else
            {
                result = "短信中心维护中！";
            }
        }
        string GetMD5(string str)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
