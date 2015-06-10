using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class YouJiShiPinAdd : HuiYuanWeiXinYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();
            init();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void init()
        {
            if (HuiYuanInfo == null || string.IsNullOrEmpty(HuiYuanInfo.UserID)) Response.Redirect("Login.aspx");
            var model = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (model != null && model.IsLvYouGuWen)
            {
                PlaceHolder1.Visible = true;
            }

            string yid = Utils.GetQueryStringValue("yid");
            var info = new Eyousoft_yhq.BLL.BYouJi().GetModel(yid);
            if (info == null) return;
            txttitle.Text = info.YouJiTitle;
            txtlink.Text = info.ShiPinLink;
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        void BaoCun()
        {
            var info = new Eyousoft_yhq.Model.MYouJi();
            string youjiid = Utils.GetFormValue("yid");
            string link = Utils.GetFormValue(txtlink.ClientID);
            info.YouJiTitle = Utils.GetFormValue(txttitle.ClientID);
            info.ShiPinLink = Utils.GetFormValue(txtlink.ClientID);
            info.HuiYuanId = HuiYuanInfo.UserID;
            info.IssueTime = DateTime.Now;
            info.YouJiType = Eyousoft_yhq.Model.YouJiLeiXing.视频游记;
            bool bllRetCode = false;
            if (string.IsNullOrEmpty(youjiid))
            {
                bllRetCode = new Eyousoft_yhq.BLL.BYouJi().Add(info);
            }
            else
            {
                info.YouJiId = youjiid;
                bllRetCode = new Eyousoft_yhq.BLL.BYouJi().UpdateModel(info);
            }


            if (bllRetCode == true)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else
            {
                Utils.RCWE_AJAX("1", "操作失败，请重试");
            }
        }
    }
}
