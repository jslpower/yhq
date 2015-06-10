using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class zxingCodePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("id");

            var model = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (model == null) return;

            System.Text.StringBuilder strbu = new System.Text.StringBuilder();

            strbu.AppendFormat("{0}|", "product");
            strbu.AppendFormat("{0}|", model.ProductID);
            strbu.AppendFormat("产品名称：{0}|", model.ProductName);
            strbu.AppendFormat("产品有效期：{0}", model.ValidiDate.ToString("yyyy-MM-dd"));

            string src = Utils.CreateZxingCode(strbu.ToString());
            ZXING.Text = "<img src=" + src + " />";
        }
    }
}
