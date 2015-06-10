using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var model = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
                if (model != null)
                {
                    ltrInfo.Text = model.About;
                }
            }
        }

    }
}
