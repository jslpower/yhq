using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string retUrl = Utils.GetFormValue("rurl");
            bool result = bll.Add(model);
            if (result)
            {
                if (!string.IsNullOrEmpty(retUrl)) Response.Redirect(retUrl);
                EyouSoft.Common.Page.HuiyuanPage.Logout();
                Response.Redirect("/AppPage/weixin/Login.aspx");
            }

        }
    }
}
