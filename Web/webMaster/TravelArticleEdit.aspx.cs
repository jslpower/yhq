using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class TravelArticleEdit : EyouSoft.Common.Page.webmasterPage
    {
        EyouSoft.Model.SSOStructure.MWebmasterInfo userinfo = GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("tid");
            string dotype = Utils.GetQueryStringValue("dotype").Trim();
            string type = Utils.GetQueryStringValue("type").Trim();

            //Ajax
            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(PageSave(id, dotype));
                    Response.End();
                    break;
                default:
                    break;
            }

            if (!IsPostBack)
            {
                InitDropDownList();
                PageInit(id, dotype);
            }
        }

        /// <summary>
        /// 初始化类别
        /// </summary>
        private void InitDropDownList()
        {
            ddlClassId.DataSource = new EyouSoft.BLL.OtherStructure.BArticleClass().GetList(null);
            ddlClassId.DataTextField = "ClassName";
            ddlClassId.DataValueField = "ClassId";
            ddlClassId.DataBind();
            ddlClassId.Items.Insert(0, new ListItem("请选择类别", ""));
        }

        private void PageInit(string id, string dotype)
        {
            if (id != "" && dotype != "add")
            {
                EyouSoft.BLL.OtherStructure.BTravelArticle bll = new EyouSoft.BLL.OtherStructure.BTravelArticle();
                EyouSoft.Model.MTravelArticle model = bll.GetModel(id);
                if (model != null)
                {
                    this.txtArticleTitle.Text = model.ArticleTitle;
                    this.ddlClassId.SelectedValue = model.ClassId.ToString();
                    //this.txtArticleTag.Text = model.ArticleTag;
                    //this.txtKeyWords.Text = model.KeyWords;
                    //this.txtDescription.Text = model.Description;
                    this.txtArticleText.Text = model.ArticleText;
                    //this.txtASource.Text = model.Source;
                    //this.txtLinkUrl.Text = model.LinkUrl;
                    //this.ddlIsFrontPage.SelectedValue = model.IsFrontPage.HasValue ? (model.IsFrontPage.Value ? "1" : "0") : "";
                    //this.ddlIsHot.SelectedValue = model.IsHot.HasValue ? (model.IsHot.Value ? "1" : "0") : "";
                    //this.ddlSort.SelectedValue = model.SortRule.ToString();
                    //this.hdTitleColor.Value = model.TitleColor;

                    //if (!string.IsNullOrEmpty(model.TitleColor))
                    //{
                    //    this.txtArticleTitle.Attributes["style"] = string.Format("color:{0}", model.TitleColor);
                    //}
                    upload1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo>() { new EyouSoft.Web.UserControl.MFileInfo() { FileName = "附件", FilePath = model.ImgPath } };


                    if (dotype.Equals("show"))
                    {
                        this.ltClicks.Text = model.Click.ToString();
                        this.btn.Visible = false;
                    }
                }
            }


        }

        /// <summary>
        /// 保存或修改信息
        /// </summary>
        private string PageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            string msg = string.Empty;

            EyouSoft.BLL.OtherStructure.BTravelArticle bll = new EyouSoft.BLL.OtherStructure.BTravelArticle();
            EyouSoft.Model.MTravelArticle model = new EyouSoft.Model.MTravelArticle();

            model.ArticleTitle = Utils.GetFormValue(this.txtArticleTitle.UniqueID);
            model.ClassId = Utils.GetInt(Utils.GetFormValue(this.ddlClassId.UniqueID));
            //model.ArticleTag = Utils.GetFormValue(this.txtArticleTag.UniqueID);
            //model.KeyWords = Utils.GetFormValue(this.txtKeyWords.UniqueID);
            //model.Description = Utils.GetFormValue(this.txtDescription.UniqueID);
            model.ArticleText = Utils.GetFormValue(this.txtArticleText.UniqueID);
            //model.Source = Utils.GetFormValue(this.txtASource.UniqueID);
            //model.LinkUrl = Utils.GetFormValue(this.txtLinkUrl.UniqueID);
            model.IsFrontPage = false;
            model.IsFrontPage = false;
            model.IsHot = false; ;
            //model.SortRule = Utils.GetInt(Utils.GetFormValue(this.ddlSort.UniqueID));
            //model.TitleColor = Utils.GetFormValue(this.hdTitleColor.UniqueID);

            var newFiles = upload1.Files;
            if (newFiles == null || !newFiles.Any())
            {
                var oldFiles = upload1.YuanFiles;
                if (oldFiles != null && oldFiles.Any())
                {
                    model.ImgPath = oldFiles[0].FilePath;
                }
                else
                {
                    model.ImgPath = string.Empty;
                }
            }
            else
            {
                model.ImgPath = newFiles[0].FilePath;
            }


            model.IssueTime = DateTime.Now;
            model.OperatorId = userinfo.UserId;

            bool result = false;
            if (t)
            {
                result = bll.Add(model);
            }
            else
            {
                model.ArticleID = id;
                result = bll.Update(model);
            }
            switch (result)
            {
                case true:
                    msg = Utils.AjaxReturnJson("1", (t ? "新增" : "修改") + "成功");
                    break;
                case false:
                    msg = Utils.AjaxReturnJson("0", (t ? "新增" : "修改") + "失败");
                    break;
                default:
                    break;
            }
            return msg;
        }

    }

}
