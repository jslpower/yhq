using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Web.HuiYuanWeiXin;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxYouJiList : HuiYuanWeiXinYeMian
    {
        protected string TuXiangFilepath = string.Empty;
        protected string XingMing = string.Empty;
        protected bool IsMy = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            string HuiYuanId = Utils.GetQueryStringValue("huiyuanid2");
            var info = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanId);
            
            if (info == null) { Response.Redirect("/HuiYuanWeiXin/Login.aspx"); }
            if (HuiYuanInfo != null && HuiYuanInfo.UserID == HuiYuanId)
            {
                IsMy = true;
            }
            XingMing = info.ContactName;
            TuXiangFilepath = info.TuXiangFilepath;
            if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";
            BindInte(HuiYuanId);
        }

        void BindInte(string HuiYuanId)
        {
            int PageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            Eyousoft_yhq.Model.MYouJiSer YouJiS = new Eyousoft_yhq.Model.MYouJiSer();
            YouJiS.HuiYuanId = HuiYuanId;
            YouJiS.YouJiType = Eyousoft_yhq.Model.YouJiLeiXing.图文游记;
            int count = 0;
            var list = new Eyousoft_yhq.BLL.BYouJi().GetList(10, PageIndex, ref count, YouJiS);
            if (list != null && list.Count > 0)
            {
                if (count > (PageIndex - 1) * 10)
                {
                    RepList.DataSource = list;
                }
                else
                {
                    RepList.DataSource = null;
                }
                
                RepList.DataBind();
            }
        }
    }
}
