using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class YouJiList : HuiYuanWeiXinYeMian
    {
        /// <summary>
        /// 会员图像
        /// </summary>
        protected string TuXiangFilepath = string.Empty;
        protected string XingMing = string.Empty;
        protected string HuiYuanId = string.Empty;
        protected bool IsMy = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "DelYouJi") DelYouJi();
            HuiYuanId = Utils.GetQueryStringValue("huiyuanid2");
            var info = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanId);
            if (HuiYuanInfo != null && HuiYuanInfo.UserID == HuiYuanId)
            {
                IsMy = true;
            }
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
            YouJiS.YouJiType = Eyousoft_yhq.Model.YouJiLeiXing.图文游记;
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
        /// <summary>
        /// 删除游记
        /// </summary>
        void DelYouJi()
        {
            string YouJiId = Utils.GetFormValue("youjid");
            if (string.IsNullOrEmpty(YouJiId)) Utils.RCWE_AJAX("0", "请选择需要删除的游记");

            bool bllRetCode = new Eyousoft_yhq.BLL.BYouJi().Delete(YouJiId);

            if (bllRetCode)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else
            {
                Utils.RCWE_AJAX("0", "操作失败");
            }

        }
    }
}
