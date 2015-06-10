using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class ajaxProduct : System.Web.UI.Page
    {
        protected int pageindex = 1, pagesize = 8, recordCount = 0;
        protected string prodectName = "", productType = "", tuijian = "", xianlu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            prodectName = Utils.GetQueryStringValue("productName");
            pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            productType = Utils.GetQueryStringValue("proType");
            tuijian = Utils.GetQueryStringValue("tuijian");
            xianlu = Utils.GetQueryStringValue("xianlu");
            string isGet = Utils.GetQueryStringValue("isGet");
            if (isGet == "1")
            {
                initList();
            }
        }
        /// <summary>
        /// 返回列表
        /// </summary>
        protected void initList()
        {
            Eyousoft_yhq.BLL.Product bll = new Eyousoft_yhq.BLL.Product();
            Eyousoft_yhq.Model.SerProduct serchModel = new Eyousoft_yhq.Model.SerProduct();
            serchModel.PurductName = prodectName;
            serchModel.PurductType = productType;
            serchModel.isVisable = false;
            serchModel.isHot = Utils.GetIntNull(tuijian);
            serchModel.WeiDianId = Utils.GetQueryStringValue("weidianid");
            if (!string.IsNullOrEmpty(xianlu)) serchModel.xianlu = (Eyousoft_yhq.Model.XianLu)Utils.GetInt(xianlu);
            var list = bll.GetList(pagesize, pageindex, ref recordCount, serchModel);
            int isPage = 0;
            if (recordCount % pagesize != 0)
            {
                isPage = recordCount / pagesize + 1;
            }
            else
            {
                isPage = recordCount / pagesize;
            }
            if (list != null && list.Count > 0)
            {

                if (isPage >= pageindex)
                {
                    rpt_list.DataSource = list;
                    rpt_list.DataBind();
                }

            }
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getProImg(string id)
        {
            var img = new Eyousoft_yhq.BLL.Product().GetModel(id).AttachList;
            if (img != null && img.Count > 0)
            {
                for (int i = 0; i < img.Count; i++)
                {
                    if (!img[i].IsWebImage && !string.IsNullOrEmpty(img[i].FilePath)) return img[i].FilePath;
                }
            }
            return "/images/pic01.jpg";
        }
        /// <summary>
        /// 获取留言数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getCommentNum(object id)
        {
            var i = new Eyousoft_yhq.BLL.Comment().GetCountNum(id.ToString());
            return i.ToString();
        }
    }
}
