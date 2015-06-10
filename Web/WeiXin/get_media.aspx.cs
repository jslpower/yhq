//下载微信多媒体文件 汪奇志 2015-01-23
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiXin
{
    /// <summary>
    /// 下载微信多媒体文件
    /// </summary>
    public partial class get_media : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string media_id = Utils.GetFormValue("media_id");

            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", Utils.get_weixin_access_token(), media_id);

            string filename = string.Empty;

            bool xiaZaiRetCode=EyouSoft.Toolkit.request.weixin_media_xiazai(url, "/ufiles/weixin/", out filename);

            if (xiaZaiRetCode)
            {
                Utils.RCWE_AJAX("1", "", filename);
            }

            Utils.RCWE_AJAX("0", "图片上传失败");
        }
    }
}
