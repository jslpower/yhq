using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web
{
    public partial class RouteInfo : System.Web.UI.Page
    {
        protected string yhm = "", pinglunshu = "0", isLogin = "0";
        protected string getType = "景点";
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        protected void initPage()
        {
            EyouSoft.Model.SSOStructure.MUserInfo info = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (info != null)
            {
                isLogin = "1";
            }

            string id = Utils.GetQueryStringValue("id");
            var model = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (model != null)
            {
                yhm = model.FavourCode;
                lblproductName.Text = lblMenuTitle.Text = model.ProductName;
                lbldescript.Text = Utils.GetText2(model.ProductDis, 100, true);
                lblprice.Text = model.AppPrice.ToString("0");
                lblZK.Text = ((model.AppPrice / model.MarketPrice) * 10).ToString("0.0");
                lblMarketPrice.Text = model.MarketPrice.ToString("C0");
                lblSaleCount.Text = model.SaleNum.ToString();
                ltrDescript.Text = model.ProductDis.Replace("\n", "<br/>");
                ltrTour.Text = model.TourDis.Replace("\n", "<br/>");
                ltrKown.Text = model.SendTourKnow.Replace("\n", "<br/>");
                ltrCompair.Text = model.Scompare.Replace("\n", "<br/>");
                if (!string.IsNullOrEmpty(model.ServiceQQ))
                {
                    lblQQ.Text = string.Format("<a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin={0}&site=qq&menu=yes\"  ><img src=\"/images/qq.gif\"></a>", model.ServiceQQ);
                }
                else
                {
                    lblQQ.Text = "<a href=\"javascript:;\" ><img src=\"/images/qq.gif\"></a>";
                }
                if (model.AttachList != null)
                {
                    for (int i = 0; i < model.AttachList.Count; i++)
                    {
                        if (model.AttachList[i].IsWebImage) lblImg.Text = string.Format("<img src=\"{0}\" style=\"width:455px;height:280px\" />", model.AttachList[i].FilePath);
                    }
                }
                else
                {
                    lblImg.Text = "<img src=\"/images/pro_mainpic.jpg\" />";
                }
                pinglunshu = new Eyousoft_yhq.BLL.Comment().GetCountNum(model.ProductID).ToString();

                if (DateTime.Compare(DateTime.Now, Utils.GetDateTime(model.ValidiDate.ToString())) > 0 && !model.IsEveryDay)
                {
                    place_Viadate.Visible = false;
                    place_isViadate.Visible = true;
                }
                switch (model.PType)
                {
                    case 2:
                        getType = "车票";
                        lblKnow.Text = "使用须知";
                        PlaceHolder1.Visible = PlaceHolder2.Visible = false;
                        break;
                    case 3:
                        getType = "景点门票";
                        lblKnow.Text = "使用须知";
                        PlaceHolder1.Visible = PlaceHolder2.Visible = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
