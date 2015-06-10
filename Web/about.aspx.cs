using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web
{
    public partial class about1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (model != null)
            {
                lbl_ABOUT.Text = model.About;
            }
        }
    }
}
