using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class ProductView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            string tp = Utils.GetQueryStringValue("xianlu");
            int xianlu = tp == "1" ? 1 : 0;
            int RecordCount = 0;
            var list = new Eyousoft_yhq.BLL.ProductType().GetList(9, 1, ref RecordCount, new Eyousoft_yhq.Model.serProductType() { xianlu = (Eyousoft_yhq.Model.XianLu)xianlu }, "1");
            StringBuilder strbu = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                #region 返回HTML
                switch (list.Count)
                {
                    case 1:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a   class=\"size01 bg02 mar_b10\"><span>{0}</span></a>", "");
                        strbu.AppendFormat("<a  class=\"size02 bg03\"><span>{0}</span></a></li> ", "");
                        strbu.AppendFormat("<li><a  class=\"size03 bg04\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size02 bg05\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size01 bg06 mar10\"><span>{0}</span></a>", "");
                        strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 2:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a  class=\"size02 bg03\"><span>{0}</span></a></li> ", "");
                        strbu.AppendFormat("<li><a  class=\"size03 bg04\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size02 bg05\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size01 bg06 mar10\"><span>{0}</span></a>", "");
                        strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 3:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a  class=\"size03 bg04\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size02 bg05\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size01 bg06 mar10\"><span>{0}</span></a>", "");
                        strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;

                    case 4:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg04\"><span>{1}</span></a></li>", list[3].TypeID, list[3].TypeName);
                        strbu.AppendFormat("<li><a    class=\"size02 bg05\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size01 bg06 mar10\"><span>{0}</span></a>", "");
                        strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 5:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg04\"><span>{1}</span></a></li>", list[3].TypeID, list[3].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg05\"><span>{1}</span></a></li>", list[4].TypeID, list[4].TypeName);
                        strbu.AppendFormat("<li><a    class=\"size01 bg06 mar10\"><span>{0}</span></a>", "");
                        strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 6:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg04\"><span>{1}</span></a></li>", list[3].TypeID, list[3].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg05\"><span>{1}</span></a></li>", list[4].TypeID, list[4].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg06 mar10\"><span>{1}</span></a>", list[5].TypeID, list[5].TypeName);
                        strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 7:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg04\"><span>{1}</span></a></li>", list[3].TypeID, list[3].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg05\"><span>{1}</span></a></li>", list[4].TypeID, list[4].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg06 mar10\"><span>{1}</span></a>", list[5].TypeID, list[5].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg07\"><span>{1}</span></a></li>", list[6].TypeID, list[6].TypeName);
                        strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 8:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg04\"><span>{1}</span></a></li>", list[3].TypeID, list[3].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg05\"><span>{1}</span></a></li>", list[4].TypeID, list[4].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg06 mar10\"><span>{1}</span></a>", list[5].TypeID, list[5].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg07\"><span>{1}</span></a></li>", list[6].TypeID, list[6].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg08\"><span>{1}</span></a></li>", list[7].TypeID, list[7].TypeName);
                        strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
                        break;
                    case 9:
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg01 mar10 mar_b10\"><span>{1}</span></a>", list[0].TypeID, list[0].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg02 mar_b10\"><span>{1}</span></a>", list[1].TypeID, list[1].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg03\"><span>{1}</span></a></li> ", list[2].TypeID, list[2].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg04\"><span>{1}</span></a></li>", list[3].TypeID, list[3].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size02 bg05\"><span>{1}</span></a></li>", list[4].TypeID, list[4].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg06 mar10\"><span>{1}</span></a>", list[5].TypeID, list[5].TypeName);
                        strbu.AppendFormat("<a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size01 bg07\"><span>{1}</span></a></li>", list[6].TypeID, list[6].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg08\"><span>{1}</span></a></li>", list[7].TypeID, list[7].TypeName);
                        strbu.AppendFormat("<li><a href=\"/AppPage/weixin/ProductList.aspx?proType={0}\" class=\"size03 bg09\"><span>{1}</span></a></li>", list[8].TypeID, list[8].TypeName);
                        break;
                    default:
                        break;
                }
                #endregion
            }
            else
            {
                strbu.AppendFormat("<li><a   class=\"size01 bg01 mar10 mar_b10\"><span>{0}</span></a>", "");
                strbu.AppendFormat("<a   class=\"size01 bg02 mar_b10\"><span>{0}</span></a>", "");
                strbu.AppendFormat("<a  class=\"size02 bg03\"><span>{0}</span></a></li> ", "");
                strbu.AppendFormat("<li><a  class=\"size03 bg04\"><span>{0}</span></a></li>", "");
                strbu.AppendFormat("<li><a    class=\"size02 bg05\"><span>{0}</span></a></li>", "");
                strbu.AppendFormat("<li><a    class=\"size01 bg06 mar10\"><span>{0}</span></a>", "");
                strbu.AppendFormat("<a   class=\"size01 bg07\"><span>{0}</span></a></li>", "");
                strbu.AppendFormat("<li><a    class=\"size03 bg08\"><span>{0}</span></a></li>", "");
                strbu.AppendFormat("<li><a   class=\"size03 bg09\"><span>{0}</span></a></li>", "");
            }
            litext.Text = strbu.ToString();

        }

    }
}
