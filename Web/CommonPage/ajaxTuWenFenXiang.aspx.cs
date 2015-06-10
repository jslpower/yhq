using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxTuWenFenXiang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BindInte();
        }

        void BindInte()
        {
            int PageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            Eyousoft_yhq.Model.MYouJiSer YouJiS = new Eyousoft_yhq.Model.MYouJiSer();
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

        /// <summary>
        /// 获取会员姓名
        /// </summary>
        /// <param name="huiyuanID"></param>
        /// <returns></returns>
        protected string getMemberName(string huiyuanID, int getType)
        {
            var huiyuan = new Eyousoft_yhq.BLL.Member().GetModel(huiyuanID);
            if (huiyuan == null) return "";
            if (getType == 1) return huiyuan.ContactName;
            return string.IsNullOrEmpty(huiyuan.TuXiangFilepath) ? "/images/weixin/head_no.png" : huiyuan.TuXiangFilepath;
        }


    }
}
