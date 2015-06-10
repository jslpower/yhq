using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class PlanTicketAdd : EyouSoft.Common.Page.HuiyuanPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string mark = Utils.GetQueryStringValue("save");
            string aid = Utils.GetQueryStringValue("id");

            if (mark == "save")
            {
                Response.Clear();
                Response.Write(save(dotype, aid));
                Response.End();
            }
            dlSexBind();
            initPage(aid);
        }
        /// <summary>
        /// 初始化编辑地址信息
        /// </summary>
        /// <param name="id"></param>
        protected void initPage(string id)
        {

            Eyousoft_yhq.BLL.GYSticket bll = new Eyousoft_yhq.BLL.GYSticket();

            var model = bll.GetModel(id);
            if (model != null)
            {
                contactname.Value = model.CusName;
                if (dl_sex.Items.FindByText(model.CusSex.ToString()) != null)
                    this.dl_sex.Items.FindByText(model.CusSex.ToString()).Selected = true;
                contactmob.Value = model.CusMob;
                contacticket.Value = model.PlaneTicket;
                remark.Value = model.Remark;
            }

        }
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="dotype"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        protected string save(string dotype, string aid)
        {
            Eyousoft_yhq.Model.GYSticket model = new Eyousoft_yhq.Model.GYSticket();
            model.CusName = Utils.GetFormValue(contactname.UniqueID);
            model.CusSex = (sexType)Utils.GetInt(Utils.GetFormValue(dl_sex.UniqueID));
            model.CusMob = Utils.GetFormValue(contactmob.UniqueID);
            model.PlaneTicket = Utils.GetFormValue(contacticket.UniqueID);
            model.Remark = Utils.GetFormValue(remark.UniqueID);
            model.OpertorID = HuiYuanInfo.UserID;
            string msg = "";
            if (dotype == "add")
            {
                msg = new Eyousoft_yhq.BLL.GYSticket().Add(model) ? Utils.AjaxReturnJson("1", "新增成功!") : Utils.AjaxReturnJson("0", "新增失败!");
            }
            else
            {
                model.ID = aid;
                var Tmodel = new Eyousoft_yhq.BLL.GYSticket().GetModel(model.ID);
                if (Tmodel != null)
                {
                    model.payState = Tmodel.payState;
                    model.orderState = Tmodel.orderState;
                }
                msg = new Eyousoft_yhq.BLL.GYSticket().Update(model) ? Utils.AjaxReturnJson("1", "修改成功!") : Utils.AjaxReturnJson("0", "修改失败!");
            }
            return msg;
        }
        /// <summary>
        /// 性别
        /// </summary>
        void dlSexBind()
        {
            dl_sex.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(sexType)))
            {
                int value = (int)Enum.Parse(typeof(sexType), item.ToString());
                string text = Enum.GetName(typeof(sexType), item);
                dl_sex.Items.Add(new ListItem(text, value.ToString()));
            }
        }


    }
}
