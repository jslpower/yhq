using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        #region 输出参数
        protected string shichangjia = "￥0", appjia = "￥0", dianhua = "", pinglunshu = "0";
        Eyousoft_yhq.Model.Product gModel = null;
        protected string yhm = "", hybh = "";
        protected string descript = string.Empty;
       
        /// <summary>
        /// 产品编号
        /// </summary>
        protected string ChanPinId = string.Empty;
        /// <summary>
        /// 微店编号
        /// </summary>
        protected string WeiDianId = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "tianjiadaoweidian") TianJiaDaoWeiDian();

            string id = Utils.GetQueryStringValue("id");
            pageInit(id);

            ChanPinId = id;
            WeiDianId = Utils.GetWeiDianId();

            InitWeiDianInfo();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="id">产品编号</param>
        protected void pageInit(string id)
        {
            var model = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (model != null)
            {
                hybh = model.UserID;

            }
            Eyousoft_yhq.BLL.Product bll = new Eyousoft_yhq.BLL.Product();
            gModel = new Eyousoft_yhq.Model.Product();
            gModel = bll.GetModel(id);
            if (gModel != null)
            {
                lbl_ProName.Text = gModel.ProductName;
                shichangjia = gModel.MarketPrice.ToString("C0");
                appjia = gModel.AppPrice.ToString("C0");
                dianhua = gModel.LinkTel;
                descript = Utils.GetText2(gModel.ProductDis, 30, true);
                //Lit_chutuan.Text = gModel.SendTourKnow.Replace("\n", "<br/>");
                //Lit_conpair.Text = gModel.Scompare.Replace("\n", "<br/>");

                //Lit_xingcheng.Text = gModel.TourDis.Replace("\n", "<br/>");
                //Lit_jieshao.Text = gModel.ProductDis.Replace("\n", "<br/>");
                yhm = gModel.FavourCode;
                pinglunshu = new Eyousoft_yhq.BLL.Comment().GetCountNum(gModel.ProductID).ToString();
                if (DateTime.Compare(DateTime.Now, Utils.GetDateTime(gModel.ValidiDate.ToString())) > 0 && !gModel.IsEveryDay)
                {
                    spanResult.Visible = false;
                }
                switch (gModel.PType)
                {
                    case 2:
                        lit_Menu.Text = string.Format("<div class=\"pro_content\"> <h3><ul class=\"tiaozheng\"><li li_index=\"1\" class=\"active\">产品介绍</li><li li_index=\"2\">使用须知</li></ul></h3><div class=\"contentbox\"><div>{0}</div><div style=\"display: none\">{1}</div> </div><div><img src=\"/images/pro_b.png\" width=\"300\"></div></div>", gModel.ProductDis.Replace("\n", "<br/>"), gModel.SendTourKnow.Replace("\n", "<br/>"));
                        break;
                    case 3:
                        lit_Menu.Text = string.Format("<div class=\"pro_content\"> <h3><ul class=\"tiaozheng\"><li li_index=\"1\" class=\"active\">产品介绍</li><li li_index=\"2\">使用须知</li></ul></h3><div class=\"contentbox\"><div>{0}</div><div style=\"display: none\">{1}</div> </div><div><img src=\"/images/pro_b.png\" width=\"300\"></div></div>", gModel.ProductDis.Replace("\n", "<br/>"), gModel.SendTourKnow.Replace("\n", "<br/>"));
                        break;
                    default:
                        lit_Menu.Text = string.Format("<div class=\"pro_content\"> <h3><ul class=\"tiaozheng\"><li li_index=\"1\" class=\"active\">产品介绍</li><li li_index=\"2\">参考行程</li><li li_index=\"3\">出团须知</li><li li_index=\"4\">同类比较</li></ul></h3><div class=\"contentbox\"><div>{0}</div><div style=\"display: none\">{1}</div> <div style=\"display: none\">{2}</div><div style=\"display: none\">{3}</div></div><div><img src=\"/images/pro_b.png\" width=\"300\"></div></div>", gModel.ProductDis.Replace("\n", "<br/>"), gModel.TourDis.Replace("\n", "<br/>"), gModel.SendTourKnow.Replace("\n", "<br/>"), gModel.Scompare);
                        break;
                }

            }
            else
            {
                lit_Menu.Text = string.Format("<div class=\"pro_content\"> <h3><ul class=\"tiaozheng\"><li li_index=\"1\" class=\"active\">产品介绍</li><li li_index=\"2\">参考行程</li><li li_index=\"3\">出团须知</li><li li_index=\"4\">同类比较</li></ul></h3><div class=\"contentbox\"><div></div><div style=\"display: none\"></div> <div style=\"display: none\"></div><div style=\"display: none\"></div></div><div><img src=\"/images/pro_b.png\" width=\"300\"></div></div>");
            }
        }

        protected string getProImg(string id)
        {
            var img = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (img != null && img.AttachList != null && img.AttachList.Count > 0)
            {
                return img.AttachList[0].FilePath;
            }
            return "/images/pic01.jpg";
        }

        /// <summary>
        /// init weidian info
        /// </summary>
        void InitWeiDianInfo()
        {
            if (Eyousoft_yhq.BLL.MemberLogin.IsLogin() != 1) return;

            var huiYuanInfo = Eyousoft_yhq.BLL.MemberLogin.GetLoginHuiYuanInfo();
            if (string.IsNullOrEmpty(huiYuanInfo.WeiDianId)) return;

            phTianJiaDaoWeiDian.Visible = true;

            if (new Eyousoft_yhq.BLL.BWeiDian().ShiFouTianJiaChanPin(huiYuanInfo.WeiDianId, ChanPinId))
            {
                ltrTianJiaDaoWeiDian.Text = "<a class=\"wd_btn\" href=\"javascript:void(0)\" id=\"a_tianjiadaoweidian_yitianjia\">添加到微店 √</a>";
            }
        }

        /// <summary>
        /// tianjia dao weidian
        /// </summary>
        void TianJiaDaoWeiDian()
        {
            string txtChanPinId = Utils.GetFormValue("txtChanPinId");
            if (string.IsNullOrEmpty(txtChanPinId)) Utils.RCWE_AJAX("0", "添加到微店失败，不存在的产品信息");

            if (Eyousoft_yhq.BLL.MemberLogin.IsLogin() != 1) Utils.RCWE_AJAX("0", "添加到微店失败，请登录后再添加");

            var huiYuanInfo=Eyousoft_yhq.BLL.MemberLogin.GetLoginHuiYuanInfo();
            if (string.IsNullOrEmpty(huiYuanInfo.WeiDianId)) Utils.RCWE_AJAX("0", "添加到微店失败，你还没有开通微店功能");

            var bllRetCode = new Eyousoft_yhq.BLL.BWeiDian().WeiDianChanPin_C(huiYuanInfo.WeiDianId, huiYuanInfo.UserID, txtChanPinId);

            if (bllRetCode == 1) Utils.RCWE_AJAX("1", "添加到微店成功");
            else Utils.RCWE_AJAX("0", "添加到微店失败");
        }
    }
}
