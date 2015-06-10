using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class DownNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
        }
        void initPage()
        {
            string orderid = Utils.GetQueryStringValue("orderid");
            var order = new Eyousoft_yhq.BLL.Order().GetModel(orderid);
            if (order != null && order.SendFile != null && order.SendFile.Count > 0)
            {
                litURL.Text = string.Format(" <a href=\"{0}\">下载出团通知单</a>", "http://" + HttpContext.Current.Request.Url.Host + DownFile(order.SendFile));
            }
            else
            {
                string.Format(" <a  >暂无通知单</a>");
            }
        }


        #region 出团通知单下载
        protected string DownFile(object FileXML)
        {

            IList<Eyousoft_yhq.Model.Attach> Attach = (IList<Eyousoft_yhq.Model.Attach>)FileXML;
            if (Attach != null)
            {
                return Attach[0].FilePath.ToString();
            }
            return "";
        }
        #endregion
    }
}
