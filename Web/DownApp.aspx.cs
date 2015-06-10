using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web
{
    public partial class DownApp : System.Web.UI.Page
    {
        protected string Ititle = string.Empty;
        protected string KeyWords = string.Empty;
        protected string Description = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Ititle = "惠旅游手机应用";
            var KVModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (KVModel != null)
            {
                Ititle = Ititle + "-" + KVModel.Title;
                KeyWords = KVModel.Keywords;
                Description = KVModel.Description;
            }
        }
    }
}
