using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class TuWenFenXiang : HuiYuanWeiXinYeMian
    {
        /// <summary>
        /// 会员图像
        /// </summary>
        protected string TuXiangFilepath = string.Empty;
        protected string XingMing = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (HuiYuanInfo == null) { Response.Redirect("/HuiYuanWeiXin/Login.aspx?rurl=/HuiYuanWeiXin/TuWenFenXiang.aspx"); }
            //HuiYuanId = HuiYuanInfo.UserID;
            //var info = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanId);
            //if (info == null) { Response.Redirect("/HuiYuanWeiXin/Login.aspx"); }
            //XingMing = info.ContactName;
            //TuXiangFilepath = info.TuXiangFilepath;
            //if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";
            BindInte();

        }

        void BindInte()
        {
            Eyousoft_yhq.Model.MYouJiSer YouJiS = new Eyousoft_yhq.Model.MYouJiSer();
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
