using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class MemberList : EyouSoft.Common.Page.webmasterPage
    {
        #region  页面参数
        protected int pageIndex = 1, pageSize = 10, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string ids = Utils.GetQueryStringValue("ids");
            rpt_list.Visible = litMsg.Visible = true;
            if (dotype == "delete")
            {
                //string[] strArr = ids.Split(',');
                delByIds(ids);
            }

            if (dotype == "lvyouguwenrenzheng") LvYouGuWenRenZheng();

            initList();

            PlaceHolder1.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.会员充值);
        }

        protected void initList()
        {
            Eyousoft_yhq.BLL.Member bll = new Eyousoft_yhq.BLL.Member();
            Eyousoft_yhq.Model.MSearchUser serchModel = new Eyousoft_yhq.Model.MSearchUser();
            serchModel.ContactName = Utils.GetQueryStringValue("contactName");
            serchModel.UserName = Utils.GetQueryStringValue("userName");
            if (Utils.GetQueryStringValue("txtIsLvYouGuWen") == "1")
            {
                serchModel.IsLvYouGuWen = true;
            }
            if (Utils.GetQueryStringValue("txtIsLvYouGuWen") == "0")
            {
                serchModel.IsLvYouGuWen = false;
            }
            
            pageIndex = UtilsCommons.GetPagingIndex("Page");
            var list = bll.GetList(pageSize, pageIndex, ref recordCount, serchModel, 0);
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
        protected void delByIds(string strArr)
        {
            int result = new BLL.Member().Delete(strArr);
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result > 0 ? "1" : "0", result > 0 ? "删除成功" : "删除失败"));
            Response.End();
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

        #region 获取推广次数
        protected int getTGCS(string Code)
        {
            if (string.IsNullOrEmpty(Code)) return 0;
            return new Eyousoft_yhq.BLL.Member().CountTGCS(Code);

        }
        #endregion
        #region 获取返佣次数
        protected int getFYCS(string id, string PollCode)
        {
            if (string.IsNullOrEmpty(id)) return 0;
            return new Eyousoft_yhq.BLL.Member().CountFYCS(id, PollCode);

        }
        #endregion


        /// <summary>
        /// 旅游顾问
        /// </summary>
        /// <param name="isLvYouGuWen"></param>
        /// <param name="lvYouGuWenRenZhengTime"></param>
        /// <returns></returns>
        protected string GetLvYuGuWen(object isLvYouGuWen, object lvYouGuWenRenZhengTime)
        {
            var _isLvYouGuWen = (bool)isLvYouGuWen;
            var _lvYouGuWenRenZhengTime = (DateTime)lvYouGuWenRenZhengTime;

            if (_isLvYouGuWen)
            {
                return string.Format("已认证（{0:yyyy-MM-dd}）<a href=\"javascript:void(0)\" data-renzhen=\""+isLvYouGuWen+"\" data-class=\"lvyouguwen_renzheng\">取消认证</a>", _lvYouGuWenRenZhengTime);
            }

            return "<a href=\"javascript:void(0)\" data-renzhen=\"" + isLvYouGuWen + "\" data-class=\"lvyouguwen_renzheng\">未认证</a>";
        }

        /// <summary>
        /// 旅游顾问认证
        /// </summary>
        void LvYouGuWenRenZheng()
        {
            string txtHuiYuanId = Utils.GetFormValue("txtHuiYuanId");
            if (string.IsNullOrEmpty(txtHuiYuanId)) Utils.RCWE_AJAX("0", "请选择需要认证为旅游顾问的会员");

            string isGuWen = Utils.GetFormValue("txtRenZheng");
            int bllRetCode = new Eyousoft_yhq.BLL.Member().LvYouGuWen_RenZheng(txtHuiYuanId,Convert.ToBoolean(isGuWen));

            if (bllRetCode == 1||bllRetCode==-2)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else
            {
                Utils.RCWE_AJAX("0", "操作失败");
            }

        }
    }
}
