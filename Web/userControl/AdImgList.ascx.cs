using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Linq;

namespace Eyousoft_yhq.Web.userControl
{
    public partial class AdImgList : System.Web.UI.UserControl
    {

        protected string liImg = "", li = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            initAdv();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected void initAdv()
        {
            StringBuilder strImg = new StringBuilder("");
            StringBuilder strLi = new StringBuilder("");
            IList<Eyousoft_yhq.Model.ProductType> list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            if (list != null && list.Count > 0)
            {
                var htm = list.Where(i => i.TpMark == "0").Take(5).ToList();
                for (int i = 0; i < htm.Count; i++)
                {
                    strImg.AppendFormat("<li style=\"position: absolute; left: {2}px; display: block;\"><a target=\"_blank\"  href=\"/RouteInfo.aspx?id={1}\"> <img src=\"{0}\"></a></li>", htm[i].WebImg, htm[i].ProductID, 960 * i);
                    strLi.AppendFormat(" <li class=\"\"><a href=\"javascript:;\" rel=\"1\">{0}</a></li>", i + 1);
                }

            }
            liImg = strImg.ToString();
            li = strLi.ToString();

        }
    }
}