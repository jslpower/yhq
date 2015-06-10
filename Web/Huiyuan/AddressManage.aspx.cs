using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class AddressManage : EyouSoft.Common.Page.HuiyuanPage
    {
        protected int xSelect, xCityId, xProvinceId, mark;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string mark = Utils.GetQueryStringValue("save");
            string isetDefault = Utils.GetQueryStringValue("setDefault");
            string aid = Utils.GetQueryStringValue("id");

            if (mark == "save")
            {
                Response.Clear();
                Response.Write(save(dotype, aid));
                Response.End();
            }
            if (isetDefault == "1")
            {
                Response.Clear();
                Response.Write(setDefault(aid));
                Response.End();
            }
            if (isetDefault == "3")
            {
                Response.Clear();
                Response.Write(deleteAddressById(aid));
                Response.End();
            }
            initPage(aid);
            initList();
        }

        #region 初始化页面
        /// <summary>
        /// 初始化地址列表
        /// </summary>
        protected void initList()
        {
            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();
            var list = bll.GetAddressList(0, HuiYuanInfo.UserID);
            if (list != null && list.Count > 0)
            {
                rpt_address.DataSource = list;
                rpt_address.DataBind();
                NoMsg.Visible = false;
            }
            else
            {
                rpt_address.Visible = false;
                NoMsg.Text = "<tr><td align=\"center\" colspan=\"7\">没有相关数据!</td></tr>";

            }
        }
        /// <summary>
        /// 初始化编辑地址信息
        /// </summary>
        /// <param name="id"></param>
        protected void initPage(string id)
        {

            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();

            var model = bll.GetAddress(id);
            if (model != null)
            {
                contactname.Value = model.ContactName;
                xSelect = model.AddressCountry;
                xCityId = model.AddressCity;
                xProvinceId = model.AddressProvince;
                addressinfo.Value = model.AddressInfo;
                zpcode.Value = model.ZpCode;
                mobileNum.Value = model.MobileNum;
                telNum.Value = model.TelNum;
                isdefault.Checked = model.IsDefault;
                mark = model.IsDefault ? 1 : 0;
            }

        }
        #endregion

        #region 保存操作
        protected string save(string dotype, string aid)
        {
            Eyousoft_yhq.Model.UserAddress model = new Eyousoft_yhq.Model.UserAddress();
            model.ContactName = Utils.GetFormValue(contactname.UniqueID);
            model.AddressCountry = Utils.GetInt(Utils.GetFormValue("ddlCountry"));
            model.AddressCity = Utils.GetInt(Utils.GetFormValue("ddlCity"));
            model.AddressProvince = Utils.GetInt(Utils.GetFormValue("ddlProvince"));
            model.AddressInfo = Utils.GetFormValue(addressinfo.UniqueID);
            model.ZpCode = Utils.GetFormValue(zpcode.UniqueID);
            model.MobileNum = Utils.GetFormValue(mobileNum.UniqueID);
            model.TelNum = Utils.GetFormValue(telNum.UniqueID);
            model.IsDefault = Utils.GetFormValue("hidefault") == "1" ? true : false;
            model.UserID = HuiYuanInfo.UserID;
            string msg = "";
            if (dotype == "add")
            {
                msg = new Eyousoft_yhq.BLL.Member().UserAddressAdd(model) > 0 ? Utils.AjaxReturnJson("1", "新增成功!") : Utils.AjaxReturnJson("0", "新增失败!");
            }
            else
            {
                model.AddressID = aid;
                msg = new Eyousoft_yhq.BLL.Member().UserAddressUpdate(model) > 0 ? Utils.AjaxReturnJson("1", "修改成功!") : Utils.AjaxReturnJson("0", "修改失败!");
            }
            return msg;
        }
        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string setDefault(string id)
        {
            Eyousoft_yhq.Model.UserAddress model = new Eyousoft_yhq.Model.UserAddress();
            model.AddressID = id;
            model.UserID = HuiYuanInfo.UserID;
            model.IsDefault = true;
            string msg = "";
            msg = new Eyousoft_yhq.BLL.Member().UserAddressDefaultUpdate(model) > 0 ? Utils.AjaxReturnJson("1", "设置成功!") : Utils.AjaxReturnJson("0", "设置失败!");
            return msg;
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string deleteAddressById(string id)
        {
            string msg = "";
            msg = new Eyousoft_yhq.BLL.Member().UserAddressDelete(id) > 0 ? Utils.AjaxReturnJson("1", "删除成功!") : Utils.AjaxReturnJson("0", "删除失败!");
            return msg;
        }
        #endregion
    }
}
