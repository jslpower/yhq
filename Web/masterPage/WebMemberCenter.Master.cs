using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Eyousoft_yhq.Model;
using System.Collections.Generic;

namespace Eyousoft_yhq.Web.masterPage
{
    public partial class MemberCenter : System.Web.UI.MasterPage
    {
        protected string Ititle = string.Empty;
        protected string KeyWords = string.Empty;
        protected string Description = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (EyouSoft.Common.Page.HuiyuanPage.GetUserInfo() != null)
            {
                PlaceHolder1.Visible = true;
                a_regeister.HRef = a_login.HRef = "/Huiyuan/PersonalInfo.aspx";
            }
            Ititle = Page.Title;
            var KVModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (KVModel != null)
            {
                Ititle = Ititle + "-" + KVModel.Title;
                KeyWords = KVModel.Keywords;
                Description = KVModel.Description;
            }
        }
        /// <summary>
        /// 初始化菜单
        /// </summary>
        protected string InitMenu()
        {
            System.Text.StringBuilder strBu = new System.Text.StringBuilder();
            IList<Eyousoft_yhq.Model.ProductType> list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            if (list != null && list.Count > 0)
            {
                list = list.Where(t => t.TpMark == "1").Take(6).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    strBu.AppendFormat("<li><a id=\"{0}\" href=\"/Index.aspx?tp=1&routype={0}\">{1}</a></li>", list[i].TypeID, list[i].TypeName);
                }
            }
            return strBu.ToString();
        }
    }
}
