using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public partial class CompanyInfo : EyouSoft.Common.Page.webmasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.InitPage();
            }
        }

        private void InitPage()
        {
            var model = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (model == null) return;

            txtAboutUs.Text = model.About;
            txtTitle.Text = model.Title;
            txtKeys.Text = model.Keywords;
            txtDescript.Text = model.Description;
            lbl_MsgCount.Text = model.MsgNumber.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool r = new Eyousoft_yhq.BLL.KV().SetCompanySetting(this.GetFormValue());

            EyouSoft.Common.Function.MessageBox.ShowAndRedirect(this, string.Format("保存{0}！", r ? "成功" : "失败"), "/WebMaster/CompanyInfo.aspx");
        }

        private Eyousoft_yhq.Model.MCompanySetting GetFormValue()
        {
            var model = new Eyousoft_yhq.BLL.KV().GetCompanySetting() ?? new Eyousoft_yhq.Model.MCompanySetting();

            model.About = Utils.EditInputText(txtAboutUs.Text);
            model.Title = Utils.EditInputText(txtTitle.Text);
            model.Keywords = Utils.EditInputText(txtKeys.Text);
            model.Description = Utils.EditInputText(txtDescript.Text);


            return model;
        }
    }
}
