using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_Search : System.Web.UI.Page
    {
        protected string StartCity { get; set; }
        protected string EndCity { get; set; }

        protected string WeiDianId = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            WeiDianId = Utils.GetWeiDianId();
        }

    }
}

