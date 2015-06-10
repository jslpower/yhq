using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eyousoft_yhq.Model;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class PersonalInfo : EyouSoft.Common.Page.HuiyuanPage
    {
        Eyousoft_yhq.BLL.Member Mem = new Eyousoft_yhq.BLL.Member();
        protected int Option = -1;//服务项目类别
        protected int ProviceId = 0;//省份
        protected int CityId = 0;//城市
        protected int AreaId = 0;//区县
        protected int StreetId = 0;//街道
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string AjaxPwd = Utils.GetQueryStringValue("doType");
            if (AjaxPwd == "AjaxPwd")
            {
                Response.Clear();
                Response.Write(UpdateUserInfo()); ;
                Response.End();

            }
            if (!Page.IsPostBack)
            {
                PageInit();
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void PageInit()
        {
            dlSexBind();
            var MInfo = Mem.GetModel(HuiYuanInfo.UserID);
            if (MInfo.valiUser)
            {
                Plabtn.Visible = PlaLi.Visible = false;
                NoViaLi.Visible = false;
                plaViaOK.Visible = true;
            }
            else
            {
                Plabtn.Visible = true;
                NoViaLi.Visible = true;
            }
            this.txtName.Text = MInfo.ContactName;
            this.txtPhone.Text = MInfo.UserName;
            ProviceId = (int)MInfo.ProviceId;
            CityId = (int)MInfo.CityId;
            AreaId = (int)MInfo.AreaId;
            StreetId = (int)MInfo.StreetId;
            Option = (int)MInfo.MemberOption;
            this.dl_sex.Items.FindByText(MInfo.ContactSex.ToString()).Selected = true;
        }
        /// <summary>
        /// 性别
        /// </summary>
        protected void dlSexBind()
        {
            dl_sex.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(sexType)))
            {
                int value = (int)Enum.Parse(typeof(sexType), item.ToString());
                string text = Enum.GetName(typeof(sexType), item);
                dl_sex.Items.Add(new ListItem(text, value.ToString()));
            }
        }

        protected string UpdateUserInfo()
        {
            string Phone = Utils.GetFormValue(txtPhone.UniqueID);
            string Name = Utils.GetFormValue(txtName.UniqueID);
            string Pwd = Utils.GetFormValue(txtPassOld.UniqueID);
            string NewPwd = Utils.GetFormValue(txtPassNew.UniqueID);
            string SurePwd = Utils.GetFormValue(txtPassSure.UniqueID);
            string sex = Utils.GetFormValue(dl_sex.UniqueID);
            Eyousoft_yhq.Model.User UserInfo = new Eyousoft_yhq.Model.User();
            UserInfo = Mem.GetModel(HuiYuanInfo.UserID);
            UserInfo.ProviceId = Utils.GetInt(Utils.GetFormValue("MyProvice"));
            UserInfo.CityId = Utils.GetInt(Utils.GetFormValue("MyCity"));
            UserInfo.AreaId = Utils.GetInt(Utils.GetFormValue("MyArea"));
            UserInfo.StreetId = Utils.GetInt(Utils.GetFormValue("MyStreet"));
            UserInfo.MemberOption = (MemberOption)Utils.GetInt(Utils.GetFormValue("MemberOption"));
            #region  验证码

            string ViaCode = Utils.GetFormValue("userViaCode");
            List<string[]> list = new List<string[]>();
            list = Session[Phone] as List<string[]>;
            string msg = string.Empty;
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!string.IsNullOrEmpty(ViaCode) && ViaCode == list[i][1] && DateTime.Compare(Convert.ToDateTime(list[i][2]).AddMinutes(5), DateTime.Now) > 0)
                    {
                        msg = list[i][1];
                        UserInfo.valiUser = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(ViaCode) && !UserInfo.valiUser)
            {
                return UtilsCommons.AjaxReturnJson("0", "请填写正确的验证码！");
            }
            #endregion

            if (!string.IsNullOrEmpty(Pwd))
            {

                if (Pwd != UserInfo.UserPwd)
                {
                    return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "原始密码不正确");
                }
                else if (NewPwd != SurePwd)
                    return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "两次密码输入不一致");
            }

            if (!string.IsNullOrEmpty(SurePwd) && !string.IsNullOrEmpty(Pwd))
            {
                UserInfo.UserPwd = SurePwd;
            }
            if (!string.IsNullOrEmpty(sex))
            {
                UserInfo.ContactSex = (sexType)Utils.GetInt(sex);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                UserInfo.ContactName = Name;
            }
            if (Mem.Update(UserInfo))
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功");
            }
            else
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "修改失败,查看原始密码是否正确");
            }



        }
        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindOption(string selectItem)
        {
            string memberoption = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(Eyousoft_yhq.Model.MemberOption)), selectItem.ToString(), false, "", "");
            return memberoption;
        }

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
        public string BindCity(string selectItem, string proviceid)
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
        #endregion
    }
}
