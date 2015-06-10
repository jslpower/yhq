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
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class JpOrderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") pageSave();
            initPage();
        }


        /// <summary>
        /// 初始化页面
        /// </summary>
        protected void initPage()
        {
            var OrderStateList = EnumObj.GetList(typeof(TickOrderPayState), new string[] { "2", "3", "4", "5" });
            ddl_orderState.DataSource = OrderStateList;
            ddl_orderState.DataTextField = "Text";
            ddl_orderState.DataValueField = "Value";
            ddl_orderState.DataBind();

            var model = new Eyousoft_yhq.BLL.BJiPiaoBaoCun().GetModel(Utils.GetQueryStringValue("id"));
            if (model == null) Utils.RCWE("请求错误");
            txtUserName.Text = model.OpeatorName;
            lblIphone.Text = model.OpeatorName;
        }
        /// <summary>
        ///保存操作
        /// </summary>
        protected void pageSave()
        {
            Eyousoft_yhq.Model.MJiPiaoBaoCun model = new Eyousoft_yhq.Model.MJiPiaoBaoCun();
            Eyousoft_yhq.BLL.BJiPiaoBaoCun bll = new Eyousoft_yhq.BLL.BJiPiaoBaoCun();
            model.OrderID = Utils.GetQueryStringValue("id");
            model.payState = (Eyousoft_yhq.Model.TickOrderPayState)Utils.GetInt(Utils.GetFormValue(this.ddl_orderState.UniqueID));
            if (bll.setState(model))
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "修改成功！"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "修改失败！"));
            }




        }
    }
}
