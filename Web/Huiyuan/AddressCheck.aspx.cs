using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class AddressCheck : EyouSoft.Common.Page.HuiyuanPage
    {
        protected int xSelect, xCityId, xProvinceId, mark;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string isetDefault = Utils.GetQueryStringValue("setDefault");
            string aid = Utils.GetQueryStringValue("id");


            if (dotype == "check")
            {
                initList();
            }
            else if (dotype == "save")
            {
                Response.Clear();
                Response.Write(SaveAdress());
                Response.End();
            }
        }
        #region 初始化页面
        /// <summary>
        /// 初始化地址列表
        /// </summary>
        protected void initList()
        {
            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();

            var list = bll.GetAddressList(0, HuiYuanInfo.UserID);
            if (list != null && list.Count > 0)
            {
                rpt_address.DataSource = list;
                rpt_address.DataBind();
                NoMsg.Visible = false;
            }
            else
            {
                rpt_address.Visible = false;
                NoMsg.Text = "<tr><td align=\"center\" colspan=\"6\">没有相关数据!</td></tr>";

            }
        }
        /// <summary>
        /// 是否默认地址
        /// </summary>
        /// <param name="checkstype"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string IsCheck(object checkstype, object value)
        {
            if (checkstype.ToString().ToLower() == "true")
            {
                return "<input type=\"radio\" value=\"" + value + "\" name=\"Adressradio\" checked=\"checked\"  />";
            }
            else
            {
                return "<input type=\"radio\" value=\"" + value + "\" name=\"Adressradio\"/>";
            }
        }
        #endregion

        protected string SaveAdress()
        {
            string OrderID = Utils.GetQueryStringValue("OrderId");
            string Adress = Utils.GetQueryStringValue("AdId");
            Eyousoft_yhq.BLL.Order Or = new Eyousoft_yhq.BLL.Order();
            Eyousoft_yhq.Model.Order OrModel = new Eyousoft_yhq.Model.Order
            {
                OrderID = OrderID,
                AddressID = Adress
            };
            bool IsTrue = Or.setAddressID(OrModel);
            if (IsTrue)
            {
                return UtilsCommons.AjaxReturnJson("1", "合同寄送地址添加成功！");
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("0", "合同寄送地址添加失败！");
            }

        }
    }
}
