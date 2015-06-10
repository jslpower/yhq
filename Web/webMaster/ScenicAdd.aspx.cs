using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class ScenicAdd : EyouSoft.Common.Page.webmasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            string id = Utils.GetQueryStringValue("id");


            initProTypeList();
            if (dotype == "edit") initPage(id);
            if (save == "save") pageSave(dotype);

        }
        protected void initPage(string strid)
        {
            var model = new Eyousoft_yhq.BLL.Product().GetModel(strid);

            if (model != null)
            {
                txtproductName.Value = model.ProductName;

                #region  新增二维码，产品类型

                if (ddl_proType.Items.FindByValue(((int)model.ProductOpState).ToString()) != null)
                    ddl_proType.Items.FindByValue(((int)model.ProductOpState).ToString()).Selected = true;
                txtZxingdate.Value = model.ZCodeViaDate.ToString("yyyy-MM-dd");

                #endregion
                if (model.IsEveryDay)
                {

                }
                else
                {
                    txtsendsDate.Value = model.ProductSdate.ToString("yyyy-MM-dd");
                    txtsendDate.Value = Utils.GetDateTime(model.TourDate.ToString()).ToString("yyyy-MM-dd");
                }
                txtmarkPrice.Value = model.MarketPrice.ToString("0.00");
                txtappPrice.Value = model.AppPrice.ToString("0.00");
                txtWXcode.Value = model.FavourCode;
               // txtcoupons.Value = model.FavourCode;
                txttel.Value = model.LinkTel;
                txtdescript.InnerText = model.ProductDis;
                txtStation.Value = model.TourDis;
                txtjoury.InnerText = model.SendTourKnow;
                txtValidate.Value = model.ValidiDate.ToString("yyyy-MM-dd");

                // model.AttachList 
                #region 附件处理
                //附件
                StringBuilder strFile = new StringBuilder();
                StringBuilder strWebFile = new StringBuilder();
                IList<Eyousoft_yhq.Model.Attach> lstFile = model.AttachList;
                if (null != lstFile && lstFile.Count > 0)
                {
                    for (int i = 0; i < lstFile.Count; i++)
                    {
                        if (lstFile[i].IsWebImage)
                        {
                            strWebFile.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideWebFileInfo\" value='{1}|{0}|{2}'/></span>", lstFile[i].FilePath, lstFile[i].Name, lstFile[i].IsWebImage);
                        }
                        else
                        {
                            strFile.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{1}|{0}|{2}'/></span>", lstFile[i].FilePath, lstFile[i].Name, lstFile[i].IsWebImage);
                        }
                    }
                }
                this.lblfile.Text = strFile.ToString();//附件
                this.lblfileWeb.Text = strWebFile.ToString();//网站图片
                txtkfqq.Value = model.ServiceQQ;
                txtPeopleNum.Value = model.ControlPeople.ToString();
                #endregion

            }
        }

        protected void pageSave(string doType)
        {
            string id = Utils.GetQueryStringValue("id");
            var model = new Eyousoft_yhq.Model.Product();

            #region 实体赋值

            model.ProductName = Utils.GetFormValue(txtproductName.UniqueID);
            model.ProductType = 0;
            model.TourDate = Utils.GetDateTimeNullable(Utils.GetFormValue(txtsendDate.UniqueID));
            model.MarketPrice = Utils.GetDecimal(Utils.GetFormValue(txtmarkPrice.UniqueID));
            model.AppPrice = Utils.GetDecimal(Utils.GetFormValue(txtappPrice.UniqueID));
            //model.FavourCode = Utils.GetFormValue(txtcoupons.UniqueID);
            model.LinkTel = Utils.GetFormValue(txttel.UniqueID);
            model.ProductDis = Utils.GetFormValue(txtdescript.UniqueID);
            model.TourDis = Utils.GetFormValue(txtStation.UniqueID);
            model.SendTourKnow = Utils.GetFormValue(txtjoury.UniqueID);
            model.ValidiDate = Utils.GetDateTime(Utils.GetFormValue(txtValidate.UniqueID));
            model.ProductState = 0;
            model.AttachList = NewGetAttach();
            model.IsEveryDay = false;
            model.IsHot = 0;
            model.ServiceQQ = Utils.GetFormValue(txtkfqq.UniqueID);
            model.ContractType = Model.ContractType.车票;
            model.ControlPeople = Utils.GetInt(Utils.GetFormValue(txtPeopleNum.UniqueID));
            model.FavourCode = Utils.GetFormValue(txtWXcode.UniqueID);

            model.ProductSdate = Utils.GetDateTime(Utils.GetFormValue(txtsendsDate.UniqueID));
            model.ProductOpState = (Model.ProductOp)Utils.GetInt(Utils.GetFormValue(ddl_proType.UniqueID));
            model.ZCodeViaDate = Utils.GetDateTime(Utils.GetFormValue(txtZxingdate.UniqueID));
            model.PType = 3;
            #endregion

            cn.myvo.smc.Service sms = new cn.myvo.smc.Service();
            string IsContact = sms.IsIncludeKeyWord(model.ProductName);

            #region 提交保存
            bool result = false;
            string msg = "";

            if (string.IsNullOrEmpty(IsContact))
            {
                Response.Clear();
                Eyousoft_yhq.BLL.Product BLL = new Eyousoft_yhq.BLL.Product();
                if (doType == "add")
                {
                    result = BLL.Add(model);
                    msg = result ? "添加成功！" : "添加失败！";
                    Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
                }
                else
                {
                    model.ProductID = id;
                    result = BLL.Update(model);
                    msg = result ? "修改成功！" : "修改失败！";
                    Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
                }
                Response.End();
            }
            else
            {
                msg = "产品名称包含敏感字符[" + IsContact + "]，请修改后再保存！";
                Response.Clear();
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
                Response.End();
            }
            #endregion

        }

        /// <summary>
        /// 附件操作
        /// </summary>
        /// <returns>附件列表</returns>
        private IList<Eyousoft_yhq.Model.Attach> NewGetAttach()
        {
            IList<Eyousoft_yhq.Model.Attach> lst = new List<Eyousoft_yhq.Model.Attach>();
            #region 手机端图片处理
            //新上传附件
            string[] upload = Utils.GetFormValues(this.upload1.ClientHideID);
            if (upload.Length != 0)
            {
                for (int i = 0; i < upload.Length; i++)
                {
                    string[] newupload = upload[i].Split('|');
                    if (newupload != null && newupload.Length > 1)
                    {
                        Eyousoft_yhq.Model.Attach attModel = new Eyousoft_yhq.Model.Attach();
                        attModel.FilePath = newupload[1];
                        attModel.Name = newupload[0];
                        attModel.IsWebImage = false;
                        lst.Add(attModel);
                    }
                }
            }
            else
            {
                //之前上传的附件
                string stroldupload = Utils.GetFormValue("hideFileInfo");

                if (!string.IsNullOrEmpty(stroldupload))
                {
                    string[] oldupload = stroldupload.Split(',');
                    if (oldupload != null && oldupload.Length > 0)
                    {
                        for (int i = 0; i < oldupload.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(oldupload[i]))
                            {
                                string[] uploaditem = oldupload[i].Split('|');
                                Eyousoft_yhq.Model.Attach attModel = new Eyousoft_yhq.Model.Attach();
                                attModel.Name = uploaditem[0];
                                attModel.FilePath = uploaditem[1];
                                attModel.IsWebImage = bool.Parse(uploaditem[2]);
                                lst.Add(attModel);
                            }
                        }
                    }
                }
            }
            #endregion

            #region 网站端图片处理
            //新上传网站附件
            string[] upload2 = Utils.GetFormValues(this.upload2.ClientHideID);
            if (upload2.Length != 0)
            {
                for (int i = 0; i < upload2.Length; i++)
                {
                    string[] newupload = upload2[i].Split('|');
                    if (newupload != null && newupload.Length > 1)
                    {
                        Eyousoft_yhq.Model.Attach attModel = new Eyousoft_yhq.Model.Attach();
                        attModel.FilePath = newupload[1];
                        attModel.Name = newupload[0];
                        attModel.IsWebImage = true;
                        lst.Add(attModel);
                    }
                }
            }
            else
            {
                //之前上传的网站附件
                string stroldwebupload = Utils.GetFormValue("hideWebFileInfo");
                if (!string.IsNullOrEmpty(stroldwebupload))
                {
                    string[] oldupload = stroldwebupload.Split(',');
                    if (oldupload != null && oldupload.Length > 0)
                    {
                        for (int i = 0; i < oldupload.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(oldupload[i]))
                            {
                                string[] uploaditem = oldupload[i].Split('|');
                                Eyousoft_yhq.Model.Attach attModel = new Eyousoft_yhq.Model.Attach();
                                attModel.Name = uploaditem[0];
                                attModel.FilePath = uploaditem[1];
                                attModel.IsWebImage = bool.Parse(uploaditem[2]);
                                lst.Add(attModel);
                            }
                        }
                    }
                }
            }

            #endregion

            return lst;
        }





        /// <summary>
        /// 初始商品类型
        /// </summary>
        protected void initProTypeList()
        {


            var proTypeList = EnumObj.GetList(typeof(Model.ProductOp));
            ddl_proType.DataSource = proTypeList;
            ddl_proType.DataTextField = "Text";
            ddl_proType.DataValueField = "Value";
            ddl_proType.DataBind();

        }

    }
}
