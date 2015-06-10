using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class YuYue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("save");
            if (dotype == "save") pageSave();
            initPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        protected void initPage()
        {
            var user = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (user != null)
            {
                xingming.Value = user.ContactName;
                shouji.Value = user.UserName;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        void pageSave()
        {
            string DataXinxi = Utils.GetFormValue(xinxi.UniqueID);
            string DataXianLu = Utils.GetFormValue(xianlu.UniqueID);
            string DataMingCheng = Utils.GetFormValue(xianlu.UniqueID);
            string DataShouJi = Utils.GetFormValue(shouji.UniqueID);

            int result = new Eyousoft_yhq.BLL.BYuYue().Add(new Eyousoft_yhq.Model.MYuYue()
            {
                YYRoute = DataXianLu,
                YYName = DataShouJi,
                YYMobile = DataShouJi,
                YYInfo = DataXinxi
            });
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 0 ? "0" : "1", result == 0 ? "提交失败" : "提交成功"));
            Response.End();


        }
    }
}
