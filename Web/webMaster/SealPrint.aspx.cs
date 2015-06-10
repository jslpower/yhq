using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class SealPrint : EyouSoft.Common.Page.webmasterPage
    {
        protected string SealImg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            getSeal();
            string id = Utils.GetQueryStringValue("id");
            getContractText(id);
            if (Utils.GetQueryStringValue("save") == "save")
            {
                Response.Clear();
                Response.Write(saveContract(id));
                Response.End();
            }

        }
        protected void getContractText(string id)
        {
            var model = new Eyousoft_yhq.BLL.Order().GetModel(id);
            if (model == null) Utils.Show("订单不存在");
            if (!string.IsNullOrEmpty(model.ContractText))
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;
                if (model.IsealCheck) PlaceHolder1.Visible = false;
                contractHTML.Text = model.ContractText;
            }

        }

        protected string saveContract(string id)
        {
            string contractHTML = Request.Form["saveHTML"];
            if (string.IsNullOrEmpty(contractHTML) || string.IsNullOrEmpty(id)) return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "操作失败!");

            Eyousoft_yhq.BLL.Order OrderBll = new Eyousoft_yhq.BLL.Order();
            Eyousoft_yhq.Model.Order OrderModel = new Eyousoft_yhq.Model.Order()
            {
                OrderID = id,
                ContractText = contractHTML,
                IsealCheck = Utils.GetFormValue("isCheck") == "0" ? false : true
            };

            bool result = OrderBll.updateContract(OrderModel);
            if (result)
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "操作成功！");
            }
            else
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "数据丢失！请重新操作！");
            }
        }

        protected void getSeal()
        {
            var admin = new Eyousoft_yhq.BLL.User().GetModel(HuiYuanInfo.UserId);
            if (admin != null)
            {
                SealImg = string.Format("<img id=\"Gimg\" src=\"{0}\" style=\"display:none\">", admin.GongZhangFilepath);
            }
        }
    }
}
