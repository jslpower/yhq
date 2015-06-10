using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class MemberAdd : EyouSoft.Common.Page.webmasterPage
    {
        protected int Option = -1;//服务项目类别
        protected int ProviceId = 0;//省份
        protected int CityId = 0;//城市
        protected int AreaId = 0;//区县
        protected int StreetId = 0;//街道
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            string id = Utils.GetQueryStringValue("id");
            string posttype = Utils.GetQueryStringValue("posttype");
            if (posttype == "city")
            {
                Response.Write(BindCity(Utils.GetQueryStringValue("selectvalue"), Utils.GetQueryStringValue("proid")));
                Response.End();
            }
            if (posttype == "area")
            {
                Response.Write(BindArea(Utils.GetQueryStringValue("selectvalue"), Utils.GetQueryStringValue("cityid")));
                Response.End();
            }

            if (posttype == "street")
            {
                Response.Write(BindStreet(Utils.GetQueryStringValue("selectvalue"), Utils.GetQueryStringValue("areaid")));
                Response.End();
            }
            if (dotype == "edit") initPage(id);

            if (save == "save") pageSave(dotype);

        }
        protected void initPage(string strid)
        {
            var model = new Eyousoft_yhq.BLL.Member().GetModel(strid);

            if (model != null)
            {
                userName.Value = model.UserName;
                ContactName.Value = model.ContactName;
                Option = (int)model.MemberOption;
                ddl_sex.Items.FindByValue(((int)model.ContactSex).ToString());
                remark.Value = model.Remark;
                if (ddl_sex.Items.FindByValue(((int)model.ContactSex).ToString()) != null)
                    ddl_sex.Items.FindByValue(((int)model.ContactSex).ToString()).Selected = true;
                fydecimal.Value = model.CommissonScale.ToString("0.00");
                userPromotionCode.Value = model.PromotionCode;
                zhYuE.Value = model.YuE.ToString("F2");
                ProviceId = (int)model.ProviceId;
                CityId = (int)model.CityId;
                AreaId = (int)model.AreaId;
                StreetId = (int)model.StreetId;
                if (!string.IsNullOrEmpty(model.PollCode))
                {
                    fydecimal.Attributes.Add("readonly", "readonly");
                    userPromotionCode.Attributes.Add("readonly", "readonly");
                }
                if (model.IsZZ) chk_zf.Checked = true;
            }
        }

        protected void pageSave(string doType)
        {
            string id = Utils.GetQueryStringValue("id");
            var model = new Eyousoft_yhq.Model.User();


            model.UserName = Utils.GetFormValue(userName.UniqueID);
            model.ContactSex = (sexType)Utils.GetInt(Utils.GetFormValue(ddl_sex.UniqueID));
            model.UserPwd = Utils.GetFormValue(userPwd.UniqueID);
            model.ContactName = Utils.GetFormValue(ContactName.UniqueID);
            model.Remark = Utils.GetFormValue(remark.UniqueID);
            model.IssueTime = DateTime.Now;
            model.CommissonScale = Utils.GetDecimal(Utils.GetFormValue(fydecimal.UniqueID));
            model.PromotionCode = Utils.GetFormValue(userPromotionCode.UniqueID);
            model.YuE = Utils.GetDecimal(Utils.GetFormValue(zhYuE.UniqueID));
            model.IsZZ = Utils.GetFormValue(chk_zf.UniqueID) == "1" ? true : false;
            model.MemberOption = (MemberOption)Utils.GetInt(Utils.GetFormValue("MemberOption"));
            model.ProviceId = Utils.GetInt(Utils.GetFormValue("MyProvice"));
            model.CityId = Utils.GetInt(Utils.GetFormValue("MyCity"));
            model.AreaId = Utils.GetInt(Utils.GetFormValue("MyArea"));
            model.StreetId = Utils.GetInt(Utils.GetFormValue("MyStreet"));
            if (model.CommissonScale == 0 && string.IsNullOrEmpty(model.PromotionCode))
            {
                model.IsAgent = false;
            }
            else
            {
                model.IsAgent = true;
            }
            #region 提交保存
            bool result = false;
            string msg = "";
            Response.Clear();
            Eyousoft_yhq.BLL.Member BLL = new Eyousoft_yhq.BLL.Member();
            //if (doType == "add")
            //{
            //    result = BLL.Add(model);
            //    msg = result ? "添加成功！" : "添加失败！";
            //    Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            //}
            //else
            //{
            model.UserID = id;
            result = BLL.Update(model);
            msg = result ? "修改成功！" : "修改失败！";
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            //}
            Response.End();
            #endregion
        }
        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindOption(string selectItem)
        {
            string memberoption = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(Eyousoft_yhq.Model.MemberOption)), selectItem.ToString(), false,"","");
            return memberoption;
        }
        #endregion

        #region 绑定省市区县镇乡
        /// <summary>
        /// 绑定省
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <returns></returns>
        public string BindProvice(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 1 });
            query.Append("<option value='0' >-请选择-</option>");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].code.ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                }
            }
            return query.ToString();
        }
        /// <summary>
        /// 绑定城市
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <param name="proviceid">父级id</param>
        /// <returns></returns>
        public string BindCity(string selectItem,string proviceid)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            if (proviceid != "0")
            {
                var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 2, parentId = proviceid });

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].code.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                    }
                }
            }
            return query.ToString();
        }
        /// <summary>
        /// 绑定县区
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <param name="cityid">父级id</param>
        /// <returns></returns>
        public string BindArea(string selectItem, string cityid)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            if (cityid != "0")
            {
                var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 3, parentId = cityid });

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].code.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                    }
                }
            }
            return query.ToString();
        }
        /// <summary>
        /// 绑定乡镇街道
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <param name="areaid">父级id</param>
        /// <returns></returns>
        public string BindStreet(string selectItem, string areaid)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            if (areaid != "0")
            {
                var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 4, parentId = areaid });

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].code.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                    }
                }
            }
            return query.ToString();
        }
        #endregion
    }
}
