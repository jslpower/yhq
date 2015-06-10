using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;

namespace Eyousoft_yhq.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected string liImg = "", li = "", fenlei = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            initAdv();
        }
        protected void initAdv()
        {
            StringBuilder strImg = new StringBuilder("");
            StringBuilder strLi = new StringBuilder("");
            StringBuilder strFenLei = new StringBuilder();
            IList<Eyousoft_yhq.Model.ProductType> list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            if (list != null && list.Count > 0)
            {
                var htm = list.Where(i => i.TpMark == "0").Take(5).ToList();
                strImg.Append(" <ul>");
                strLi.Append("<ul id=\"indicator\">");
                for (int i = 0; i < htm.Count; i++)
                {
                    strImg.AppendFormat("<li><a href=\"/AppPage/productinfo.aspx?id={1}\"> <img width=\"320\" height=\"160\" src=\"{0}\"></a></li>", htm[i].TypeImg, htm[i].ProductID);
                    strLi.AppendFormat("<li {0}>{1}</li>", i == 0 ? "class=\"active\"" : "", i);
                }
                strImg.Append("</ul>");
                strLi.Append("</ul>");

                var lsfenlei = list.Where(i => i.TpMark == "1").Take(9).ToList();
                strFenLei.Append(" <ul>");
                for (int i = 0; i < lsfenlei.Count; i++)
                {
                    strFenLei.AppendFormat(" <li><a href=\"/AppPage/productlist.aspx?proType={0}\"><img src=\"{1}\" width=75 height=48/></a><p>{2}</p></li>", lsfenlei[i].TypeID, lsfenlei[i].TypeImg, lsfenlei[i].TypeName);
                }
                strFenLei.Append(" <ul>");


            }
            liImg = strImg.ToString();
            li = strLi.ToString();
            fenlei = strFenLei.ToString();
        }

        /// <summary>
        /// 初始化产品类型
        /// </summary>
        protected string InitDropDownList()
        {
            var list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=\"0\" >所有分类</option>");

            sb.Append("<option value=\"-2\" >车票</option>");

            sb.Append("<option value=\"-3\" >门票</option>");
            if (list != null && list.Count > 0)
            {
                var ls = list.Where(i => (i.TpMark == "1")).ToList();
                for (int i = 0; i < ls.Count; i++)
                {
                    sb.Append("<option value=\"" + ls[i].TypeID + "\" >" + ls[i].TypeName + "</option>");
                }

            }
            return sb.ToString();
        }
    }
}
