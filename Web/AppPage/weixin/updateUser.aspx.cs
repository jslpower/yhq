using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.SSOStructure;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class updateUser : System.Web.UI.Page
    {
        MUserInfo userinfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        string URL = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            URL = Server.UrlDecode(Request.Url.ToString());
            if (IsPostBack)
            {
                save();
            }
            initModel();
            if (Utils.GetQueryStringValue("loginout") == "1")
            {
                Response.Clear();
                Response.Write(loginout());
                Response.End();
            }
        }
        protected void initModel()
        {
            if (userinfo != null)
            {
                lblmobile.Text = userinfo.UserName;
                contactName.Value = userinfo.ContactName;
                ddl_sex.SelectedValue = userinfo.ContactSex.ToString();
            }
            else
            {
                string URL = Server.UrlEncode(Request.Url.ToString());
                Response.Redirect("/AppPage/weixin/Login.aspx?rurl=" + URL);

            }


        }

        protected void save()
        {
            Eyousoft_yhq.Model.User model = new Eyousoft_yhq.Model.User();
            model.ContactName = Utils.GetFormValue(contactName.UniqueID);
            model.ContactSex = (sexType)Utils.GetInt(Utils.GetFormValue(ddl_sex.UniqueID)); ;
            model.UserPwd = Utils.GetFormValue(userPwd.UniqueID);
            model.UserID = userinfo.UserID;
            model.Remark = userinfo.Remark;
            bool result = new Eyousoft_yhq.BLL.Member().Update(model);
            if (result)
            {
                Utils.ShowMsg("修改成功！");
            }
            else
            {
                Utils.ShowMsg("修改失败！");

            }
        }

        string loginout()
        {
            EyouSoft.Common.Page.HuiyuanPage.Logout();
            return UtilsCommons.AjaxReturnJson("1", "安全退出");
        }
    }
}
