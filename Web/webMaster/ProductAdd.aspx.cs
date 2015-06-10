using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using System.Linq;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class ProductAdd : EyouSoft.Common.Page.webmasterPage
    {
        protected int everyDay = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            string id = Utils.GetQueryStringValue("id");

            InitDropDownList();
            initContact();
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
                if (ddltype.Items.FindByValue(model.ProductType.ToString()) != null)
                    ddltype.Items.FindByValue(model.ProductType.ToString()).Selected = true;
                if (ddl_isHot.Items.FindByValue(model.IsHot.ToString()) != null)
                    ddl_isHot.Items.FindByValue(model.IsHot.ToString()).Selected = true;
                if (ddl_contact.Items.FindByValue(((int)model.ContractType).ToString()) != null)
                    ddl_contact.Items.FindByValue(((int)model.ContractType).ToString()).Selected = true;
                #region  新增二维码，产品类型

                if (ddl_proType.Items.FindByValue(((int)model.ProductOpState).ToString()) != null)
                    ddl_proType.Items.FindByValue(((int)model.ProductOpState).ToString()).Selected = true;
                txtZxingdate.Value = model.ZCodeViaDate.ToString("yyyy-MM-dd");

                #endregion
                if (model.IsEveryDay)
                {
                    chk_Isevery.Checked = true;
                    everyDay = 1;
                }
                else
                {
                    txtsendDate.Value = Utils.GetDateTime(model.TourDate.ToString()).ToString("yyyy-MM-dd");
                }
                txtmarkPrice.Value = model.MarketPrice.ToString("0.00");
                txtappPrice.Value = model.AppPrice.ToString("0.00");
                txtWXcode.Value = model.FavourCode;
                txttel.Value = model.LinkTel;
                txtdescript.InnerText = model.ProductDis;
                txtjoury.InnerText = model.TourDis;
                txtsendMark.InnerText = model.SendTourKnow;
                txtScompare.InnerText = model.Scompare; ;
                txtValidate.Value = model.ValidiDate.ToString("yyyy-MM-dd");
                txtWXcode.Value = model.FavourCode;
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
            model.ProductType = Utils.GetInt(Utils.GetFormValue(ddltype.UniqueID));
            model.TourDate = Utils.GetDateTimeNullable(Utils.GetFormValue(txtsendDate.UniqueID));
            model.MarketPrice = Utils.GetDecimal(Utils.GetFormValue(txtmarkPrice.UniqueID));
            model.AppPrice = Utils.GetDecimal(Utils.GetFormValue(txtappPrice.UniqueID));
            model.LinkTel = Utils.GetFormValue(txttel.UniqueID);
            model.ProductDis = Utils.GetFormValue(txtdescript.UniqueID);
            model.TourDis = Utils.GetFormValue(txtjoury.UniqueID);
            model.SendTourKnow = Utils.GetFormValue(txtsendMark.UniqueID);
            model.Scompare = Utils.GetFormValue(txtScompare.UniqueID);
            model.ValidiDate = Utils.GetDateTime(Utils.GetFormValue(txtValidate.UniqueID));
            model.ProductState = 0;
            model.AttachList = NewGetAttach();
            model.IsEveryDay = Utils.GetFormValue("isEvery") == "1" ? true : false;
            model.IsHot = Utils.GetInt(Utils.GetFormValue(ddl_isHot.UniqueID));
            model.ServiceQQ = Utils.GetFormValue(txtkfqq.UniqueID);
            model.ContractType = (Model.ContractType)Utils.GetInt(Utils.GetFormValue(ddl_contact.UniqueID));
            model.ControlPeople = Utils.GetInt(Utils.GetFormValue(txtPeopleNum.UniqueID));

            model.ProductOpState = (Model.ProductOp)Utils.GetInt(Utils.GetFormValue(ddl_proType.UniqueID));
            model.ZCodeViaDate = Utils.GetDateTime(Utils.GetFormValue(txtZxingdate.UniqueID));
            model.PType = 1;
            model.ProductSdate = DateTime.Now;
            model.FavourCode = Utils.GetFormValue(txtWXcode.UniqueID);

            model.FaBuRenId = HuiYuanInfo.UserId;
            model.ShenHeStatus = Eyousoft_yhq.Model.ChanPinShenHeStatus.已审核;
            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                model.ShenHeStatus = Eyousoft_yhq.Model.ChanPinShenHeStatus.未审核;
            }
            #endregion



            if (new Eyousoft_yhq.BLL.Product().Exists(model))
            {
                Response.Clear();
                Response.Write(UtilsCommons.AjaxReturnJson("0", "此微信码已被使用"));
                Response.End();
            }

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
        /// 初始化产品类型
        /// </summary>
        private void InitDropDownList()
        {
            var list = new Eyousoft_yhq.BLL.ProductType().GetList(new Eyousoft_yhq.Model.serProductType() { AdminID = HuiYuanInfo.UserId, IsAdmin = HuiYuanInfo.IsAdmin });
            if (list != null && list.Count > 0)
            {
                var ls = list.Where(i => (i.TpMark == "1")).ToList();
                ddltype.DataSource = ls;
                ddltype.DataTextField = "TypeName";
                ddltype.DataValueField = "TypeID";
                ddltype.DataBind();
            }

            ddltype.Items.Insert(0, new ListItem("请选择分类", ""));
        }

        /// <summary>
        /// 初始化合同类型
        /// </summary>
        protected void initContact()
        {


            var ContractTypeList = EnumObj.GetList(typeof(Model.ContractType));
            ddl_contact.DataSource = ContractTypeList;
            ddl_contact.DataTextField = "Text";
            ddl_contact.DataValueField = "Value";
            ddl_contact.DataBind();

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
