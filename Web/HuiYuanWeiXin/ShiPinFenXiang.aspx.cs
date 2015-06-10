using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;


namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class ShiPinFenXiang : HuiYuanWeiXinYeMian
    {
        /// <summary>
        /// 会员图像
        /// </summary>
        protected string TuXiangFilepath = string.Empty;
        protected string XingMing = string.Empty;
        protected string HuiYuanId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo == null) { Response.Redirect("/HuiYuanWeiXin/Login.aspx?rurl=/HuiYuanWeiXin/Login.aspxShiPinFenXiang.aspx"); }
            HuiYuanId = HuiYuanInfo.UserID;
            var info = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanId);
            if (info == null) { Response.Redirect("/HuiYuanWeiXin/Login.aspx"); }
            XingMing = info.ContactName;
            TuXiangFilepath = info.TuXiangFilepath;
            if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";
            BindInte(HuiYuanId);
        }

        void BindInte(string HuiYuanId)
        {
            Eyousoft_yhq.Model.MYouJiSer YouJiS = new Eyousoft_yhq.Model.MYouJiSer();
            YouJiS.HuiYuanId = HuiYuanId;
            YouJiS.YouJiType = Eyousoft_yhq.Model.YouJiLeiXing.视频游记;
            int count = 0;
            var list = new Eyousoft_yhq.BLL.BYouJi().GetList(10, 1, ref count, YouJiS);
            if (list != null && list.Count > 0)
            {
                RepList.DataSource = list;
                RepList.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
                PlaceHolder1.Visible = false;
            }
        }

    }
}
