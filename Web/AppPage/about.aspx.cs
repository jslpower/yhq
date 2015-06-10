using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.BLL;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetAbout();
            }
        }
        protected void GetAbout()
        {
            KV BLL = new KV();
            MCompanySetting model = BLL.GetCompanySetting();
            lit_about.Text = model.About;
        }

    }
}
