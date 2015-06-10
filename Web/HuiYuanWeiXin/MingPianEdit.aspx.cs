//会员名片编辑 汪奇志 2015-01-21
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 会员名片编辑
    /// </summary>
    public partial class MingPianEdit : HuiYuanWeiXinYeMian
    {
        #region attributes
        protected string TuXiangFilepath = string.Empty;
        protected string weixin_jsapi_config = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            YanZhengLogin();

            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitInfo();

            var weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("chooseImage");
            weixin_jsApiList.Add("uploadImage");
            weixin_jsApiList.Add("downloadImage");

            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);

            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (info == null) Utils.RCWE("异常请求");

            txtWeiXinHao.Value = info.WeiXinHao;
            txtXingMing.Value = info.ContactName;
            txtGongSiName.Value = info.GongSiName;
            txtZhiWei.Value = info.ZhiWei;
            txtShouJi.Value = info.ShouJi;

            txtQQ.Value = info.QQ;
            txtYouXiang.Value = info.YouXiang;
            txtDiZhi.Value = info.DiZhi;
            TuXiangFilepath = info.TuXiangFilepath;

            txtTuXiangFilepath.Value = info.TuXiangFilepath;

            if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        void BaoCun()
        {
            var info = new Eyousoft_yhq.BLL.Member().GetModel(HuiYuanInfo.UserID);
            if (info == null) Utils.RCWE("异常请求");

            info.WeiXinHao = Utils.GetFormValue(txtWeiXinHao.UniqueID);
            info.ContactName = Utils.GetFormValue(txtXingMing.UniqueID);
            info.GongSiName = Utils.GetFormValue(txtGongSiName.UniqueID);
            info.ZhiWei = Utils.GetFormValue(txtZhiWei.UniqueID);
            info.ShouJi = Utils.GetFormValue(txtShouJi.UniqueID);
            info.QQ = Utils.GetFormValue(txtQQ.UniqueID);
            info.YouXiang = Utils.GetFormValue(txtYouXiang.UniqueID);
            info.DiZhi = Utils.GetFormValue(txtDiZhi.UniqueID);
            info.TuXiangFilepath = Utils.GetFormValue(txtTuXiangFilepath.UniqueID);

            //从微信服务器下载图像
            string txtTuXiangMediaId = Utils.GetFormValue("txtTuXiangMediaId");
            if (!string.IsNullOrEmpty(txtTuXiangMediaId))
            {
                string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", Utils.get_weixin_access_token(), txtTuXiangMediaId);

                string tuxiang_filename = string.Empty;

                bool xiaZaiRetCode = EyouSoft.Toolkit.request.weixin_media_xiazai(url, "/ufiles/weixin/", out tuxiang_filename);

                if (xiaZaiRetCode) info.TuXiangFilepath = tuxiang_filename;
            }

            int bllRetCode = new Eyousoft_yhq.BLL.Member().HuiYuan_U(info);

            if (bllRetCode == 1)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else
            {
                Utils.RCWE_AJAX("1", "操作失败，请重试");
            }
        }
        #endregion
    }
}
