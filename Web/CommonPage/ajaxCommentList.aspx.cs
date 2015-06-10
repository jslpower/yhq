using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.SSOStructure;
using System.Linq;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxCommentList : System.Web.UI.Page
    {
        MUserInfo info = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected string shuliang = "0" ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dotype = Utils.GetQueryStringValue("dotype");
                string pid = Utils.GetQueryStringValue("pid");
                if (dotype == "save")
                {
                    addMsg(pid);
                }
                initList(pid);
            }

        }
        protected void initList(string pid)
        {

            Eyousoft_yhq.BLL.Comment combll = new Eyousoft_yhq.BLL.Comment();
            var list = combll.GetList(null);
            if (list != null && list.Count > 0)
            {
                var count = list.Where(t => t.ProductID == pid).ToList();
                shuliang = count.Count.ToString();
                rpt_list.DataSource = count;
                rpt_list.DataBind();
            }
        }

        protected void addMsg(string productId)
        {
            if (info != null)
            {
                var model = new Eyousoft_yhq.Model.Comment();
                model.CommentText = Utils.GetQueryStringValue("context");
                model.ProductID = productId;
                model.PeopleID = info.UserID;
                model.IssueTime = DateTime.Now;
                model.CheckState = "0";
                bool i = new Eyousoft_yhq.BLL.Comment().Add(model);
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
    }
}
