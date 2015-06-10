using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.AppPage.ZxingCode
{
    public partial class AppXiaoFei : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("xiaofei") == "1")
            {
                setOrderState();
            }
            initPage();
        }
        /// <summary>
        /// 显示订单信息
        /// </summary>
        protected void initPage()
        {
            string id = Utils.GetQueryStringValue("id");
            var model = new Eyousoft_yhq.BLL.Order().GetModel(id);
            if (model == null)
            {
                lblxiaofei.Text = "未找到此订单！";
                xiaofei.Visible = isXF.Visible = false;
                return;
            }
            if (model.XiaoFei == Eyousoft_yhq.Model.XFstate.已消费)
            {
                lblxiaofei.Text = "此订单已消费！";
                xiaofei.Visible = isXF.Visible = false;
                return;
            }
            else if (DateTime.Compare(model.ZCodeViaDate, DateTime.Now) < 0)
            {
                lblxiaofei.Text = "此订单已过期！";
                xiaofei.Visible = isXF.Visible = false;
                return;
            }
            else
            {
                cusName.Value = model.MemberName;
                cusSex.Value = model.MemberSex.ToString();
                cusMob.Value = model.MemberTel;
                proName.Value = model.ProductName;
                lblxiaofei.Visible = false;
            }

        }
        /// <summary>
        /// 消费
        /// </summary>
        /// <returns></returns>
        protected string setOrderState()
        {
            string id = Utils.GetQueryStringValue("id");
            bool result = new Eyousoft_yhq.BLL.Order().setConSumState(id,string.Empty);
            if (result)
            {
                return UtilsCommons.AjaxReturnJson("0", "消费成功！");
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("1", "消费失败！");
            }
        }
    }
}
