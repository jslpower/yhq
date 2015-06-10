using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class ProductList : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        protected System.Text.StringBuilder strBU = new System.Text.StringBuilder();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string ids = Utils.GetQueryStringValue("ids");
            rpt_list.Visible = litMsg.Visible = true;
            if (dotype == "delete")
            {
                string[] strArr = ids.Split(',');
                delByIds(strArr);
            }
            if (dotype == "xiajia")
            {
                string[] strArr = ids.Split(',');
                xiajia(strArr);
            }

            if (dotype == "shenhe") ShenHe();

            initList();
            InitDropDownList();

            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                phShenHe.Visible = false;
            }
        }

        protected void initList()
        {
            Eyousoft_yhq.BLL.Product bll = new Eyousoft_yhq.BLL.Product();
            Eyousoft_yhq.Model.SerProduct serchModel = new Eyousoft_yhq.Model.SerProduct();
            serchModel.AdminName = HuiYuanInfo.UserId;
            serchModel.PType = 1;
            serchModel.PurductName = Utils.GetQueryStringValue("productName");
            serchModel.FavourCode = Utils.GetQueryStringValue("FavourCode");
            serchModel.PurductState = Utils.GetQueryStringValue("pstate");
            serchModel.Stime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("stime"));
            serchModel.Etime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("etime"));
            serchModel.isVisable = true;
            serchModel.IsAdmin = HuiYuanInfo.IsAdmin?"1":"0";
            serchModel.isHot = Utils.GetIntNull(Utils.GetQueryStringValue("isHot"));
            serchModel.PurductType = Utils.GetInt(Utils.GetQueryStringValue("ptype")).ToString();
            serchModel.ShenHeStatus = (Eyousoft_yhq.Model.ChanPinShenHeStatus?)Utils.GetEnumValueNull(typeof(Eyousoft_yhq.Model.ChanPinShenHeStatus), Utils.GetQueryStringValue("txtShenHeStatus")); 

            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                serchModel.FaBuRenId = HuiYuanInfo.UserId;
            }

            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel);
            if (list != null && list.Count > 0)
            {
                rpt_list.DataSource = list;
                rpt_list.DataBind();
                BindPage();
                litMsg.Visible = false;

            }
            else
            {
                rpt_list.Visible = false;
            }
        }
        protected void delByIds(string[] strArr)
        {
            string result = new BLL.Product().Delete(strArr).ToString();
            Response.Clear();
            if (result == "0") Response.Write(UtilsCommons.AjaxReturnJson("0", "删除失败"));
            if (result == "1") Response.Write(UtilsCommons.AjaxReturnJson("1", "删除成功"));
            if (result == "-1") Response.Write(UtilsCommons.AjaxReturnJson("0", "产品下有订单存在，删除失败"));


            Response.End();
        }

        protected void xiajia(string[] strArr)
        {
            bool result = new BLL.Product().UpdateProduteState(strArr);
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", result ? "下架成功" : "下架失败"));
            Response.End();
        }


        protected string getProductCount(string pid)
        {

            int i = new Eyousoft_yhq.BLL.SendMsg().countNum(pid);
            return i.ToString();
        }
        /// <summary>
        /// 初始化产品类型
        /// </summary>
        protected string InitDropDownList()
        {
            strBU.Append("<option>请选择</option>");
            var list = new Eyousoft_yhq.BLL.ProductType().GetList(new Eyousoft_yhq.Model.serProductType() { AdminID = HuiYuanInfo.UserId, IsAdmin = HuiYuanInfo.IsAdmin });
            if (list != null && list.Count > 0)
            {
                var ls = list.Where(i => (i.TpMark == "1")).ToList();
                for (int i = 0; i < ls.Count; i++)
                {
                    strBU.AppendFormat("<option value=\"{0}\" >{1}</option>", ls[i].TypeID, ls[i].TypeName);
                }
            }
            return strBU.ToString();
        }
        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion

        protected string GetShenHeStatus(object shenHeStatus)
        {
            var _shenHeStatus = (Eyousoft_yhq.Model.ChanPinShenHeStatus)shenHeStatus;

            if (_shenHeStatus == Eyousoft_yhq.Model.ChanPinShenHeStatus.未审核)
            {
                return string.Format("<span style=\"color:#ff0000\">{0}</span>", "未审核");
            }

            return "已审核";
        }

        /// <summary>
        /// 产品审核
        /// </summary>
        void ShenHe()
        {
            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商) Utils.RCWE_AJAX("0", "你没有审核权限");

            var txtChanPinId = Utils.GetFormValues("txtChanPinId[]");
            if (txtChanPinId == null || txtChanPinId.Length == 0) Utils.RCWE_AJAX("0", "请选择需要审核的产品");

            var items = new List<string>();
            foreach (var item in txtChanPinId)
            {
                items.Add(item);
            }

            int bllRetCode = new Eyousoft_yhq.BLL.Product().ChanPinShenHe(items);

            if (bllRetCode == 1) Utils.RCWE_AJAX("1", "操作成功");
            else Utils.RCWE_AJAX("0", "操作失败");
        }
    }
}
