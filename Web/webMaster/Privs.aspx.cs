using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class Privs : EyouSoft.Common.Page.webmasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("save");
            if (dotype == "save")
            {
                save();
            }
        }

        protected void save()
        {
            bool Result = false;
            string dotype = Utils.GetQueryStringValue("dotype");
            string RoleId = Utils.GetQueryStringValue("id");
            EyouSoft.Model.SSOStructure.MGuanLiYuanInfo model = new EyouSoft.Model.SSOStructure.MGuanLiYuanInfo();
            Eyousoft_yhq.BLL.User BComRoleBll = new Eyousoft_yhq.BLL.User();

            int length = Utils.GetFormValues("chk_id").Length;
            for (int i = 0; i < length; i++)
            {
                model.Privs += Utils.GetFormValues("chk_id")[i] + ",";
            }
            if (!string.IsNullOrEmpty(model.Privs))
            {
                model.Privs = model.Privs.Trim(',');
            }


            model.UserId = RoleId;
            Result = BComRoleBll.UpdatePrivs(model);
            if (Result)
            {
                Response.Write(UtilsCommons.AjaxReturnJson("1", "授权成功!"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson("0", "授权失败!"));
            }


            Response.End();
        }

        #region 初始化权限列表
        protected string initPrivList(string RoleID)
        {
            StringBuilder strCity = new StringBuilder("");
            string[] strPriv;
            if (HuiYuanInfo.Username.ToLower() == "admin")
            { strPriv = new[] { "0" }; }
            else
            {
                strPriv = new[] { "0", "18" };
            }

            var list = EnumObj.GetList(typeof(Eyousoft_yhq.Model.Privs), strPriv);

            if (list != null && list.Count > 0)
            {


                strCity.AppendFormat("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tbody>");
                for (int i = 0; i < list.Count; i++)
                {
                    if (i % 4 == 0)
                    {
                        strCity.AppendFormat("<tr>");
                    }

                    var model = new Eyousoft_yhq.BLL.User().GetModel(RoleID);

                    if (!string.IsNullOrEmpty(model.Privs) && model.Privs.Contains(list[i].Value))
                    {
                        strCity.AppendFormat("<td height=\"26\" bgcolor=\"#FFFFFF\" align=\"left\"><label><input type=\"checkbox\" value=\"{0}\" id=\"{0}\" name=\"chk_id\" checked=\"checked\"> {1}</label></td>", list[i].Value, list[i].Text);
                    }
                    else
                    {
                        strCity.AppendFormat("<td height=\"26\" bgcolor=\"#FFFFFF\" align=\"left\"><label><input type=\"checkbox\" value=\"{0}\" id=\"{0}\" name=\"chk_id\"> {1}</label></td>", list[i].Value, list[i].Text);
                    }








                    if (i != 0 && i % 20 == 0 || i + 1 == list.Count)
                    {
                        strCity.AppendFormat("</tr>");
                    }
                }
                strCity.AppendFormat("</tbody></table>");

            }
            return strCity.ToString();
        }
        #endregion
    }
}
