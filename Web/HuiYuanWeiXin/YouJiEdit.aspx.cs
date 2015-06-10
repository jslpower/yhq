using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class YouJiEdit : HuiYuanWeiXinYeMian
    {
        protected string weixin_jsapi_config = string.Empty, yjTitle = string.Empty, wxma= string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();
            if (!IsPostBack)
            {
                var weixin_jsApiList = new List<string>();
                weixin_jsApiList.Add("chooseImage");
                weixin_jsApiList.Add("uploadImage");
                weixin_jsApiList.Add("downloadImage");
                var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
                weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
                init();
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void init()
        {
            string youjiid = Utils.GetQueryStringValue("yid");
            var list = new Eyousoft_yhq.BLL.BYouJi().GetModel(youjiid);
            if (list != null && list.YouJiType == Eyousoft_yhq.Model.YouJiLeiXing.图文游记)
            {
                yjTitle = list.YouJiTitle;
                wxma = list.WeiXinMa;
                rptYouJis.DataSource = list.YouJiContent;
                rptYouJis.DataBind();
            }
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        void BaoCun()
        {
            var info = new Eyousoft_yhq.Model.MYouJi();
            if (info == null) Utils.RCWE("异常请求");
            info.YouJiId = Utils.GetFormValue("hidyid");
            info.YouJiTitle = Utils.GetFormValue("txtTitle");
            info.WeiXinMa = Utils.GetFormValue("txtHma");
            info.HuiYuanId = HuiYuanInfo.UserID;
            info.IssueTime = DateTime.Now;

            //从微信服务器下载图像
            string[] txtTuXiangMediaId = Utils.GetFormValues("txtTuXiangMediaId");
            string[] txtTuXiangContent = Utils.GetFormValues("MiaoShu");
            IList<Eyousoft_yhq.Model.XingCheng> items = new List<Eyousoft_yhq.Model.XingCheng>();
            if (txtTuXiangMediaId.Length > 0)
            {
                for (int i = 0; i < txtTuXiangMediaId.Length; i++)
                {
                    var XCModel = new Eyousoft_yhq.Model.XingCheng();
                    if (txtTuXiangMediaId[i].StartsWith("/ufiles/"))
                    {
                        XCModel.ImgFile = txtTuXiangMediaId[i];
                    }
                    else
                    {
                        string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", Utils.get_weixin_access_token(), txtTuXiangMediaId[i]);
                        string tuxiang_filename = string.Empty;
                        bool xiaZaiRetCode = EyouSoft.Toolkit.request.weixin_media_xiazai(url, "/ufiles/weixin/", out tuxiang_filename);
                        if (xiaZaiRetCode) XCModel.ImgFile = tuxiang_filename;
                    }
                    XCModel.XingChengContent = txtTuXiangContent[i];
                    items.Add(XCModel);
                }
            }
            info.YouJiContent = items;
            bool bllRetCode = new Eyousoft_yhq.BLL.BYouJi().UpdateModel(info);

            if (bllRetCode == true)
            {
                Utils.RCWE_AJAX("1", "操作成功");
            }
            else
            {
                Utils.RCWE_AJAX("1", "操作失败，请重试");
            }
        }
    }
}
