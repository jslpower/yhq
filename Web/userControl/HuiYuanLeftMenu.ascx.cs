using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Eyousoft_yhq.Web.userControl
{
    public partial class HuiYuanLeftMenu : System.Web.UI.UserControl
    {
        protected string M1, M2, M3, M4, M5, M6, M7, M8, M9, M10;
        protected void Page_Load(object sender, EventArgs e)
        {
            InitClass();
        }
        /// <summary>
        /// 初始化菜单
        /// </summary>
        private void InitClass()
        {
            string _class = "class=\"MenberDefault\"";
            string s = Request.Url.AbsolutePath.ToLower();

            switch (s)
            {
                case "/huiyuan/personalinfo.aspx": M1 = _class; break;
                case "/huiyuan/orderlist.aspx": M2 = _class; break;
                case "/huiyuan/apporderlist.aspx": M2 = _class; break;
                case "/huiyuan/addressmanage.aspx": M3 = _class; break;
                case "/huiyuan/tglist.aspx": M4 = _class; break;
                case "/huiyuan/fylist.aspx": M5 = _class; break;
                case "/huiyuan/jclist.aspx": M6 = _class; break;
                case "/huiyuan/planticketmanage.aspx": M7 = _class; break;
                case "/huiyuan/account.aspx": M8 = _class; break;
                case "/huiyuan/hyjp_orders.aspx": M9 = _class; break;
                case "/huiyuan/Insorders.aspx": M10 = _class; break;
                default: M1 = _class; break;
            }
            var MemberModel = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (MemberModel != null)
            {
                var memeber = new Eyousoft_yhq.BLL.Member().GetModel(MemberModel.UserID);
                if (memeber != null && memeber.IsAgent)
                {
                    PlaceHolder1.Visible = true;
                }
            }
        }


    }
}