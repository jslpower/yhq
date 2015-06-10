using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;

namespace Eyousoft_yhq.Web.Huiyuan
{
    public partial class PlanTicketManage : EyouSoft.Common.Page.HuiyuanPage
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string del = Utils.GetQueryStringValue("del");
            string aid = Utils.GetQueryStringValue("id");


            if (del == "1")
            {
                Response.Clear();
                Response.Write(deleteAddressById(aid));
                Response.End();
            }


            initList();
        }

        #region 初始化页面
        /// <summary>
        /// 初始化地址列表
        /// </summary>
        protected void initList()
        {
            Eyousoft_yhq.BLL.GYSticket bll = new Eyousoft_yhq.BLL.GYSticket();

            #region 查询实体
            Eyousoft_yhq.Model.GysTicketSer serchModel = new Eyousoft_yhq.Model.GysTicketSer();
            serchModel.OpertorID = HuiYuanInfo.UserID;
            serchModel.cusName = Utils.GetQueryStringValue("cusName");
            serchModel.cusMob = Utils.GetQueryStringValue("cusMob");
            serchModel.tickNO = Utils.GetQueryStringValue("GysTicket");
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            #endregion

            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);

            if (list != null && list.Count > 0)
            {
                rpTicket.DataSource = list;
                rpTicket.DataBind();
                BindPage();
                NoMsg.Visible = false;
            }
            else
            {
                
                rpTicket.Visible = false;
                NoMsg.Text = "<tr><td align=\"center\" colspan=\"7\">没有相关数据!</td></tr>";

            }
        }
        #endregion






        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string deleteAddressById(string id)
        {
            string msg = "";
            msg = new Eyousoft_yhq.BLL.GYSticket().Delete(id) ? Utils.AjaxReturnJson("1", "删除成功!") : Utils.AjaxReturnJson("0", "删除失败!");
            return msg;
        }
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }

    }
}
