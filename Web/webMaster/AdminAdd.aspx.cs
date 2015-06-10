using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class AdminAdd : EyouSoft.Common.Page.webmasterPage
    {
        protected string LeiXing = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            string id = Utils.GetQueryStringValue("id");
            if (dotype == "edit") initPage(id);

            if (save == "save") pageSave(dotype);

        }
        protected void initPage(string strid)
        {
            var model = new Eyousoft_yhq.BLL.User().GetModel(strid);

            if (model != null)
            {
                userName.Value = model.Username;
                userName.Attributes.Add("readonly", "readonly");
                ContactName.Value = model.XingMing;
                tel.Value = model.Telephone;
                remark.Value = model.BeiZhu;
                if (!string.IsNullOrEmpty(model.GongZhangFilepath)) lblsealimg.Text = string.Format("<span class='upload_filename'><a href='{0}' target='_blank'>查看</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{0}'/></span>", model.GongZhangFilepath);

                LeiXing = ((int)model.LeiXing).ToString();
            }
        }

        protected void pageSave(string doType)
        {
            string id = Utils.GetQueryStringValue("id");
            var model = new EyouSoft.Model.SSOStructure.MGuanLiYuanInfo();
            #region 表单取值
            string getusername = Utils.GetFormValue(userName.UniqueID);
            string getuserpwd = Utils.GetFormValue(userPwd.UniqueID);
            string getcontactname = Utils.GetFormValue(ContactName.UniqueID);
            string gettel = Utils.GetFormValue(tel.UniqueID);
            string getremark = Utils.GetFormValue(remark.UniqueID);

            #endregion
            #region 实体赋值
            model.Username = getusername;
            model.MiMa = getuserpwd;
            model.XingMing = getcontactname;
            model.Telephone = gettel;
            model.BeiZhu = getremark;
            model.CreateTime = DateTime.Now;
            model.IsAdmin = false;
            string stroldupload = Utils.GetFormValue("hideFileInfo");
            string newupload = Utils.GetFormValue(this.UploadSeal.ClientHideID);
            if (!string.IsNullOrEmpty(newupload))
            {
                if (!string.IsNullOrEmpty(newupload))
                {
                    model.GongZhangFilepath = newupload.Split('|')[1];
                }

            }
            else
            {
                model.GongZhangFilepath = stroldupload;
            }
            #endregion

            #region 提交保存
            bool result = false;
            string msg = "";
            Response.Clear();

            model.LeiXing = Utils.GetEnumValue<Eyousoft_yhq.Model.WebmasterLeiXing>(Utils.GetFormValue("txtLeiXing"), Eyousoft_yhq.Model.WebmasterLeiXing.系统);

            Eyousoft_yhq.BLL.User BLL = new Eyousoft_yhq.BLL.User();
            if (doType == "add")
            {
                result = BLL.Add(model);
                msg = result ? "添加成功！" : "添加失败！";
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            }
            else
            {
                model.UserId = id;
                result = BLL.Update(model);
                msg = result ? "修改成功！" : "修改失败！";
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            }
            Response.End();
            #endregion
        }
    }
}
