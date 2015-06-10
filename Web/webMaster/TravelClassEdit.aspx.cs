using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class TravelClassEdit : EyouSoft.Common.Page.webmasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string save = Utils.GetQueryStringValue("save");
            string tid = Utils.GetQueryStringValue("tid");
            string action = Utils.GetQueryStringValue("action").ToLower();

            if (save == "1")
            {
                Response.Clear();
                Response.Write(Save(action, tid));
                Response.End();

                return;
            }

            if (!IsPostBack)
            {
                PageInit(tid, action);
            }
        }


        private void PageInit(string tid, string action)
        {
            if (action != "edit") return;

            var model = new BLL.OtherStructure.BArticleClass().GetModel(Utils.GetInt(tid));

            if (model == null) return;

            txtAreaName.Text = model.ClassName;
            this.txtSort.Text = model.SortRule.ToString();
            this.hidIsSystme.Value = ((int)model.IsSystem).ToString();


        }

        private string Save(string action, string tid)
        {

            var model = new Model.MArticleClass
            {
                ClassName = Utils.GetFormValue(txtAreaName.UniqueID),
                SortRule = Utils.GetInt(Utils.GetFormValue(this.txtSort.UniqueID)),
                IsSystem = (Eyousoft_yhq.Model.ArticleType)Utils.GetInt(Utils.GetFormValue(this.hidIsSystme.UniqueID))
            };

            int r = 0;
            var bll = new BLL.OtherStructure.BArticleClass();
            if (action == "edit")
            {
                model.ClassId = Utils.GetInt(tid);

                r = bll.Update(model) ? 1 : -2;
            }
            else
            {
                r = bll.Add(model) ? 1 : -2;
            }

            switch (r)
            {
                case 0:
                    return UtilsCommons.AjaxReturnJson("0", "url错误，请重新打开此窗口操作！");
                case 1:
                    return UtilsCommons.AjaxReturnJson("1", "保存成功！");
                default:
                    return UtilsCommons.AjaxReturnJson("0", "保存失败！");
            }

        }
    }
}
