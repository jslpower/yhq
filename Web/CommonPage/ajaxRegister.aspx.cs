using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxRegister : System.Web.UI.Page
    {
        protected bool result = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            string isRegister = Utils.GetQueryStringValue("userName");

            result = new Eyousoft_yhq.BLL.Member().Exists(isRegister);
        }
    }
}
