using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class YouJiXX : HuiYuanWeiXinYeMian
    {
        protected string yjtitle = string.Empty;
        protected string yjdesc = string.Empty;
        protected string yjimg = "/images/chanpin_moren.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            string youjiid = Utils.GetQueryStringValue("YouJiId");
            var list = new Eyousoft_yhq.BLL.BYouJi().GetModel(youjiid);
            if (list != null)
            {
                #region 获取会员头像和名称
                var info = new Eyousoft_yhq.BLL.Member().GetModel(list.HuiYuanId);
                if (info != null)
                {
                    string TuXiangFilepath = info.TuXiangFilepath;
                    if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";
                    string FenXiangLianJie = string.Format("<a href=\"http://{0}/huiyuanweixin/mingpian.aspx?mingpianid={1}&eventkey=qrscene_01\"><img  src=\"{2}\"></a>", HOST, info.MingPianId, TuXiangFilepath);
                    ltrTouXiang.Text = FenXiangLianJie;
                    ltrMingCheng.Text = info.ContactName;

                }
                #endregion

                LtrTitle.Text = yjtitle = list.YouJiTitle;
                int rowsCount=0;
                var item = new Eyousoft_yhq.BLL.Product().GetList(1, 1, ref rowsCount, new Eyousoft_yhq.Model.SerProduct() { FavourCode = string.IsNullOrEmpty(list.WeiXinMa) ? "-999" : list.WeiXinMa });
                if(item!=null && item.Count>0)
                {
                    ChanPinLink.Text = "<div style=\"text-align:center; font-size:14px;\"><a href=\"/AppPage/weixin/ProductInfo.aspx?id=" + item[0].ProductID + "&weidianid=" + new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianId(list.HuiYuanId) + "\">[查看相关产品及预定]</a></div>";
                }
                if (list.YouJiContent[0].XingChengContent.Length > 30)
                {
                    yjdesc = list.YouJiContent[0].XingChengContent.Substring(0, 30);
                }
                else
                {
                    yjdesc = list.YouJiContent[0].XingChengContent;
                }
                if (!string.IsNullOrEmpty(list.YouJiContent[0].ImgFile))
                {
                    yjimg = list.YouJiContent[0].ImgFile;
                }
                
                rptList.DataSource = list.YouJiContent;
                rptList.DataBind();

            }

        }
    }
}
