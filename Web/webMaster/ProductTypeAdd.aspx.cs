using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using System.Linq;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class ProductTypeAdd : EyouSoft.Common.Page.webmasterPage
    {
        protected string getXianLu = string.Empty;
        protected string TypeAdminList = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));

            if (dotype == "edit") initPage(id);
            if (save == "save") pageSave(dotype);

        }
        protected void initPage(int strid)
        {
            var model = new Eyousoft_yhq.BLL.ProductType().GetModel(strid);

            if (model != null)
            {
                TypeAdminList = AdminList(model.AdminName);
                txtOrderByNum.Value = model.OrderBy.ToString();
                txtproductName.Value = model.TypeName;
                getXianLu = ((int)model.xianlu).ToString();
                if (!string.IsNullOrEmpty(model.TypeImg)) lblfile.Text = string.Format("<span class='upload_filename'><a href='{0}' target='_blank'>查看</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{0}'/></span>", model.TypeImg);

            }
        }

        protected void pageSave(string doType)
        {
            string id = Utils.GetQueryStringValue("id");
            var model = new Eyousoft_yhq.Model.ProductType();

            #region 实体赋值
            
            model.TpMark = "1";
            model.TypeName = Utils.GetFormValue(txtproductName.UniqueID);
            model.OrderBy = Utils.GetInt(Utils.GetFormValue(txtOrderByNum.UniqueID));
            //model.AdminName = Utils.GetFormValue("ddlAname");
            string[] ADNamelist = Utils.GetFormValue("AdminList").TrimEnd(',').Split(',');
            IList<Eyousoft_yhq.Model.AdminNameList> items = new List<Eyousoft_yhq.Model.AdminNameList>();
            for (int j = 0; j < ADNamelist.Length; j++)
            {
                var ADModel = new Eyousoft_yhq.Model.AdminNameList();
                    ADModel.AdminN = ADNamelist[j];
                    items.Add(ADModel);
            }
            model.AdminName = items;
            model.xianlu = (Eyousoft_yhq.Model.XianLu)Utils.GetInt(Utils.GetFormValue("ddlxianlu"));
            string stroldupload = Utils.GetFormValue("hideFileInfo");
            string newupload = Utils.GetFormValue(this.upload1.ClientHideID);
            if (!string.IsNullOrEmpty(newupload))
            {
                if (!string.IsNullOrEmpty(newupload))
                {
                    model.TypeImg = newupload.Split('|')[1];
                }

            }
            else
            {
                model.TypeImg = stroldupload;
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
        /// 绑定管理员账号列表
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        protected string BindAdmin(string id)
        {
            System.Text.StringBuilder option = new System.Text.StringBuilder();
            //option.Append("<option value=''>-请选择-</option>");
            Eyousoft_yhq.BLL.User bll = new Eyousoft_yhq.BLL.User();
            var list = bll.GetList(null);

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.UserId.Equals(id))
                    {
                        option.AppendFormat("<option value='{0}'  selected='selected'>{1}</option>", item.UserId, item.Username);
                    }
                    else
                    {
                        option.AppendFormat("<option value='{0}' >{1}</option>", item.UserId, item.Username);
                    }
                }
            }
            return option.ToString();
        }
        #endregion
        #region 绑定产品列表
        /// <summary>
        /// 绑定管理员账号列表
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        protected string AdminList(IList<AdminNameList> items)
        {
            System.Text.StringBuilder option = new System.Text.StringBuilder();
            //option.Append("<option value=''>-请选择-</option>");
            Eyousoft_yhq.BLL.User bll = new Eyousoft_yhq.BLL.User();
            var list = bll.GetList(null);
            
            
            for (int i = 0; i < items.Count(); i++)
            {
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.UserId == items[i].AdminN)
                        {
                            option.AppendFormat("<option value='{0}' >{1}</option>", item.UserId, item.Username);
                        }
                    }
                }
            }
            return option.ToString();
        }
        #endregion

    }
}
