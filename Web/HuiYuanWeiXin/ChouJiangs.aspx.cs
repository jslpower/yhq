using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class ChouJiangs : System.Web.UI.Page
    {
        EyouSoft.Model.SSOStructure.MUserInfo m = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (m == null)
            {
                Response.Redirect("/AppPage/register.aspx?rurl=/HuiYuanWeiXin/ChouJiangs.aspx");
            }
            initlist();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initlist()
        {
            var sermodel = new ChouJiangSer() { CaoZuoRenID = m.UserID };
            var list = new Eyousoft_yhq.BLL.BChouJiang().GetList(sermodel);
            var sum = new Eyousoft_yhq.BLL.BChouJiang().getSumMoney(sermodel);
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();
            }
            ltrSumMoney.Text = sum.ToString("F2");
        }
    }
}
