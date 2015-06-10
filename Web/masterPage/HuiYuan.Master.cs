using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.masterPage
{
    public partial class HuiYuan : System.Web.UI.MasterPage
    {
        protected string M1, M2, M3, M4, M5;
        EyouSoft.Model.SSOStructure.MUserInfo userinfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo != null)
            {
                PlaceHolder1.Visible = PlaceHolder2.Visible = false;
                PlaceHolder3.Visible = true;
            }
            InitClass();
        }
        void InitClass()
        {
            string _class = "class=\"default\"";
            string s = Request.Url.AbsolutePath.ToLower();

            switch (s)
            {
                case "/apppage/register.aspx": M1 = _class; break;
                case "/apppage/login.aspx": M2 = _class; break;
                case "/apppage/updateuser.aspx": M3 = _class; break;
                case "/apppage/about.aspx": M4 = _class; break;
                case "/apppage/orderlist.aspx": M5 = _class; break;
                default: M1 = _class; break;
            }

        }
    }
}
