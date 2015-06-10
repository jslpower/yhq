using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.printPage
{
    public partial class AbroadContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string jisong = Utils.GetQueryStringValue("jisong");
            string dizhiid = Utils.GetQueryStringValue("aid");
            string id = Utils.GetQueryStringValue("id");
            if (jisong == "1")
            {
                PlaceHolder3.Visible = plac_ADDRESS.Visible = true;
                PlaceHolder2.Visible = false;
                initADDRESS(dizhiid);
            }

            initContract(id);

            if (Utils.GetQueryStringValue("save") == "save")
            {
                Response.Clear();
                Response.Write(saveContract(id));
                Response.End();
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
                IsealCheck = false
            };

            bool result = OrderBll.updateContract(OrderModel);
            if (result)
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "操作成功,等待审核！");
            }
            else
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "数据丢失！请重新操作！");
            }
        }
        protected void initContract(string id)
        {
            var model = new Eyousoft_yhq.BLL.Order().GetModel(id);
            if (model != null)
            {
                if (model.PayState != Eyousoft_yhq.Model.PaymentState.已支付)
                {
                    PlaceHolder2.Visible = PlaceHolder3.Visible = false;
                    return;
                }

                if (model.IsealCheck == true) PlaceHolder2.Visible = false;
                if (!string.IsNullOrEmpty(model.ContractText))
                {
                    PlaceHolder1.Visible = false;
                    Literal1.Visible = true;
                    Literal1.Text = model.ContractText;
                }
                else
                {
                    PlaceHolder1.Visible = true;
                    Literal1.Visible = false;
                }
            }
        }


        /// <summary>
        /// 初始化地址信息
        /// </summary>
        /// <param name="id"></param>
        protected void initADDRESS(string id)
        {

            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();

            var model = bll.GetAddress(id);
            if (model != null)
            {
                contactname.Text = model.ContactName;
                ADDRESS.Text = string.Format("{0} {1} {2} {3}", model.AddressProvinceName, model.AddressCityName, model.AddressCountryName, model.AddressInfo);
                zpcode.Text = model.ZpCode;
                mobileNum.Text = model.MobileNum;
                telNum.Text = model.TelNum;
            }

        }
    }
}
