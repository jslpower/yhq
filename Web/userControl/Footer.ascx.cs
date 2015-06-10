using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.Model;
using System.Linq;

namespace Eyousoft_yhq.Web.userControl
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected string guonei, zhoubian, xianggang, ouzhou, meizhou, ziyou;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 初始化菜单
        /// </summary>
        protected string InitMenu()
        {
            System.Text.StringBuilder strBu = new System.Text.StringBuilder();
            IList<Eyousoft_yhq.Model.ProductType> list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            if (list != null && list.Count > 0)
            {
                list = list.Where(t => t.TpMark == "1").Take(8).ToList();
                if (list.Count > 0) strBu.Append(" <li class=\"line\">|</li>");
                for (int i = 0; i < list.Count; i++)
                {
                    strBu.AppendFormat("<li><a href=\"/Index.aspx?routype={0}\">{1}</a></li> ", list[i].TypeID, list[i].TypeName);
                    if (i != list.Count - 1) strBu.Append("<li class=\"line\">|</li>");
                }
            }
            return strBu.ToString();
        }
    }
}