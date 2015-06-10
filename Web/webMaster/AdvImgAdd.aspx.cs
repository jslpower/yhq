using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class AdvImgAdd : EyouSoft.Common.Page.webmasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));

            if (dotype == "edit") initPage(id);
            if (save == "save") pageSave(dotype);
            //EyouSoft.Common.Utils.GetQueryStringValue("id")
        }
        protected void initPage(int strid)
        {
            var model = new Eyousoft_yhq.BLL.ProductType().GetModel(strid);
            if (model != null)
            {
                BindPro(model.ProductID);
                if (!string.IsNullOrEmpty(model.TypeImg))
                {
                    lblfile.Text = string.Format("<span class='upload_filename'><a href='{0}' target='_blank'>查看</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{0}'/></span>", model.TypeImg);
                }
                if (!string.IsNullOrEmpty(model.WebImg))
                {
                    lblwebfile.Text = string.Format("<span class='upload_filename'><a href='{0}' target='_blank'>查看</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideWebFileInfo\" value='{0}'/></span>", model.WebImg);
                }

            }

        }

        protected void pageSave(string doType)
        {
            string id = Utils.GetQueryStringValue("id");
            var model = new Eyousoft_yhq.Model.ProductType();

            #region 实体赋值

            model.TpMark = "0";
            model.ProductID = Utils.GetFormValue("ddlPname");
            string stroldupload = Utils.GetFormValue("hideFileInfo");
            string stroldwebload = Utils.GetFormValue("hideWebFileInfo");
            if (!string.IsNullOrEmpty(stroldupload))
            {
                model.TypeImg = stroldupload;
            }
            else
            {
                string newupload = Utils.GetFormValue(this.upload1.ClientHideID);
                if (!string.IsNullOrEmpty(newupload))
                {
                    model.TypeImg = newupload.Split('|')[1];
                }
            }

            if (!string.IsNullOrEmpty(stroldwebload))
            {
                model.WebImg = stroldwebload;
            }
            else
            {
                string newupload = Utils.GetFormValue(this.upload2.ClientHideID);
                if (!string.IsNullOrEmpty(newupload))
                {
                    model.WebImg = newupload.Split('|')[1];
                }
            }

            #endregion

            #region 提交保存
            bool result = false;
            string msg = "";
            Response.Clear();
            Eyousoft_yhq.BLL.ProductType BLL = new Eyousoft_yhq.BLL.ProductType();
            if (doType == "add")
            {
                result = BLL.Add(model);
                msg = result ? "添加成功！" : "添加失败！";
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            }
            else
            {
                model.TypeID = Utils.GetInt(id);
                result = BLL.Update(model);
                msg = result ? "修改成功！" : "修改失败！";
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            }
            Response.End();
            #endregion




        }

        #region 绑定产品列表
        /// <summary>
        /// 绑定产品列表
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        protected string BindPro(string id)
        {
            System.Text.StringBuilder option = new System.Text.StringBuilder();
            option.Append("<option value=''>-请选择-</option>");
            Eyousoft_yhq.BLL.Product bll = new Eyousoft_yhq.BLL.Product();
            IList<Eyousoft_yhq.Model.Product> list = bll.GetList(null);

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.ProductID.Equals(id))
                    {
                        option.AppendFormat("<option value='{0}'  selected='selected'>{1}</option>", item.ProductID, item.ProductName);
                    }
                    else
                    {
                        option.AppendFormat("<option value='{0}' >{1}</option>", item.ProductID, item.ProductName);
                    }
                }
            }
            return option.ToString();
        }
        #endregion
    }
}
