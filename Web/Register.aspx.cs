using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.Model;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string getDotype = Utils.GetQueryStringValue("register");
            if (getDotype == "1")
            {
                Response.Clear();
                Response.Write(save());
                Response.End();

            }

        }
        /// <summary>
        /// 添加用户
        /// </summary>
        protected string save()
        {


            var model = new Eyousoft_yhq.Model.User();
            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();

            model.ContactSex = (sexType)Utils.GetInt(Utils.GetFormValue("userSex"));
            model.UserName = Utils.GetFormValue("userName");
            model.UserPwd = Utils.GetFormValue("userPwd");
            model.ContactName = Utils.GetFormValue("contactName");
            model.PollCode = Utils.GetFormValue("userPollCode");
            model.IsAgent = false;
            model.IssueTime = DateTime.Now;
            //string ViaCode = Utils.GetFormValue("userViaCode");
            model.YuE = 0M;
            string msg = string.Empty;
            List<string[]> list = new List<string[]>();
            //list = Session[model.UserName] as List<string[]>;
            //if (list != null)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (ViaCode == list[i][1] && DateTime.Compare(Convert.ToDateTime(list[i][2]).AddMinutes(5), DateTime.Now) > 0)
            //        {
            //            msg = list[i][1];
            //        }
            //    }
            //}
            //if (string.IsNullOrEmpty(msg))
            //{
            //    return UtilsCommons.AjaxReturnJson("0", "请填写正确的验证码！");
            //}
            bool result = bll.Add(model);
            Session.Remove(model.UserName);
            if (result)
            {
                Session.Remove(model.UserName);
                EyouSoft.Model.SSOStructure.MUserInfo userInfo = new Eyousoft_yhq.BLL.MemberLogin().isLogin(model.UserName, model.UserPwd);
            }

            return UtilsCommons.AjaxReturnJson("1", string.Format("注册{0}", result ? "成功，正在跳转页面，请稍后 !" : "失败！请稍后再试"));

        }
    }
}
