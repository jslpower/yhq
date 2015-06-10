using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Common.Page.webmasterPage.RemoveCookies();
            Response.Redirect("/webMaster/login.aspx");
        }
    }
}
