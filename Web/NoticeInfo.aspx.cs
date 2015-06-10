using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web
{
    public partial class NoticeInfo : System.Web.UI.Page
    {
        #region  分页参数
        protected int pageSize = 6, pageIndex = 1, recordCount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = EyouSoft.Common.Utils.GetQueryStringValue("NotIceId");
            var model = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetModel(id);
            InitBind();
            if (model != null)
            {
                lbl_menu.Text = lbl_title.Text = model.ArticleTitle;
                lbl_time.Text = model.IssueTime.ToString("yyyy年MM月dd日 HH:MM");
                lit_text.Text = model.ArticleText;
                if (!string.IsNullOrEmpty(model.ImgPath))
                {
                    lit_file.Text = string.Format(" 点击查看：<a href=\"{0}\"><font class=\"font_f60\">[附件]</font></a>", model.ImgPath);
                }

            }


        }

        /// <summary>
        /// 页面加载
        /// </summary>
        protected void InitBind()
        {
            Eyousoft_yhq.BLL.Product PBll = new Eyousoft_yhq.BLL.Product();
            Eyousoft_yhq.Model.SerProduct PModel = new Eyousoft_yhq.Model.SerProduct();
            PModel.SFTJ = 1;


            IList<Eyousoft_yhq.Model.Product> list = PBll.GetList(pageSize, pageIndex, ref recordCount, PModel);
            if (list != null && list.Count > 0)
            {
                rpList.DataSource = list;
                rpList.DataBind();
            }
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string getImg(string id)
        {
            var model = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (model != null)
            {
                if (model.AttachList != null)
                {
                    for (int i = 0; i < model.AttachList.Count; i++)
                    {
                        if (model.AttachList[i].IsWebImage) return string.Format("<img src=\"{0}\" style=\"width:455px;height:280px\" />", model.AttachList[i].FilePath);
                    }
                }
                else
                {
                    return " <img src=\"/images/img00.jpg\">";
                }
            }
            return " <img src=\"/images/img00.jpg\">";
        }
    }
}
