using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Linq;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiDian
{
    /// <summary>
    /// 微店-我的产品管理
    /// </summary>
    public partial class WoDeChanPin : Eyousoft_yhq.Web.HuiYuanWeiXin.HuiYuanWeiXinYeMian
    {
        #region attributes
        /// <summary>
        /// 微店编号
        /// </summary>
        protected string WeiDianId = string.Empty;

        int PageSize = 5;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "chanpinxiajia") ChanPinXiaJia();
            if (Utils.GetQueryStringValue("jiazaigengduo") == "1" || Utils.GetQueryStringValue("chaxun") == "1") JiaZaiGengDuo();

            Master.IsLoadDefaultCss = false;
            YanZhengLogin();

            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(HuiYuanInfo.WeiDianId)) Response.Redirect("notfound.aspx?xxlx=2");

            WeiDianId = HuiYuanInfo.WeiDianId;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            int recordCount = 0;
            var items = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianChanPins(HuiYuanInfo.WeiDianId, PageSize, 1, ref recordCount, null);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phShangLaJiaZai.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// chanpin xiajia
        /// </summary>
        void ChanPinXiaJia()
        {
            string txtChanPinId = Utils.GetFormValue("txtChanPinId");
            int txtGuanXiId = Utils.GetInt(Utils.GetFormValue("txtGuanXiId"));

            if (!IsLogin) Utils.RCWE_AJAX("0", "下架失败，请登录后再操作");
            if (string.IsNullOrEmpty(txtChanPinId) || txtGuanXiId < 1) Utils.RCWE_AJAX("0", "下架失败，请选择需要下架的产品");

            var bllRetCode = new Eyousoft_yhq.BLL.BWeiDian().WeiDianChanPin_D(HuiYuanInfo.WeiDianId,HuiYuanInfo.UserID, txtGuanXiId, txtChanPinId);

            if (bllRetCode == 1) Utils.RCWE_AJAX("1", "下架成功");
            else { Utils.RCWE_AJAX("0", "下架失败，请重试"); }
        }

        /// <summary>
        /// jiazai gengduo
        /// </summary>
        void JiaZaiGengDuo()
        {
            int pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            var items = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianChanPins(HuiYuanInfo.WeiDianId, PageSize, pageIndex, ref recordCount, chaXun);

            string html = string.Empty;

            int pageCount = 0;
            if (recordCount % PageSize == 0) pageCount = recordCount / PageSize;
            else pageCount = recordCount / PageSize + 1;

            if (pageIndex > pageCount)
            {
                Utils.RCWE_AJAX("-1");
            }

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                System.IO.StringWriter sw=new System.IO.StringWriter();
                HtmlTextWriter htw=new HtmlTextWriter(sw);
                rpt.RenderControl(htw);

                var obj = new { html = htw.InnerWriter.ToString() };

                Utils.RCWE_AJAX("1", "", obj);
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        Eyousoft_yhq.Model.MWeiDianChanPinChaXunInfo GetChaXunInfo()
        {
            var info = new Eyousoft_yhq.Model.MWeiDianChanPinChaXunInfo();

            info.ChanPinLeiXing = Utils.GetIntNull(Utils.GetQueryStringValue("txtChanPinLeiXing"));
            info.ChanPinName = Utils.GetQueryStringValue("txtChanPinName");

            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取产品类型
        /// </summary>
        protected string GetChanPinLeiXing(string leiXingId)
        {
            var list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=\"\" >所有分类</option>");

            if (list != null && list.Count > 0)
            {
                var ls = list.Where(i => (i.TpMark == "1")).ToList();

                for (int i = 0; i < ls.Count; i++)
                {
                    if (leiXingId == ls[i].TypeID.ToString())
                    {
                        sb.Append("<option value=\"" + ls[i].TypeID + "\" selected=\"selected\">" + ls[i].TypeName + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + ls[i].TypeID + "\" >" + ls[i].TypeName + "</option>");
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// get chutuanriqi
        /// </summary>
        /// <param name="chuTuanRiQi"></param>
        /// <param name="isTianTianFaTuan"></param>
        /// <returns></returns>
        protected string GetChuTuanRiQi(object chuTuanRiQi, object isTianTianFaTuan)
        {
            bool _isTianTianFaTuan = (bool)isTianTianFaTuan;
            if (_isTianTianFaTuan) return "天天";

            DateTime? _chuTuanRiQi = (DateTime)chuTuanRiQi;

            if (_chuTuanRiQi.HasValue)
            {
                return _chuTuanRiQi.Value.ToString("yyyy-MM-dd");
            }

            return string.Empty;
        }

        /// <summary>
        /// get tupian filepath
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetTuPianFilepath(object filepath)
        {
            var _filepath = (string)filepath;

            if (string.IsNullOrEmpty(_filepath)) return "/images/chanpin_moren.png";

            return _filepath;
        }
        #endregion
    }
}
