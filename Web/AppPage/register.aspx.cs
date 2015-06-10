using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.AppPage
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (userInfo != null)
            {
                Response.Redirect("/AppPage/updateuser.aspx");
            }
            if (IsPostBack)
            {
                save();
            }
        }
        protected void save()
        {
            var model = new Eyousoft_yhq.Model.User();
            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();

            model.ContactSex = (sexType)Utils.GetInt(Utils.GetFormValue(ddl_sex.UniqueID));
            model.UserName = Utils.GetFormValue("userName");
            model.UserPwd = Utils.GetFormValue("userPwd");
            model.ContactName = Utils.GetFormValue("contactName");
            model.PollCode = Utils.GetFormValue("PollCode");
            model.YuE = 0M;
            model.IssueTime = DateTime.Now;
            bool result = bll.Add(model);
            if (result)
            {
                EyouSoft.Model.SSOStructure.MUserInfo userInfo = new Eyousoft_yhq.BLL.MemberLogin().isLogin(model.UserName, model.UserPwd);
                Response.Redirect("/AppPage/Default.aspx");
            }

        }

    }
}
