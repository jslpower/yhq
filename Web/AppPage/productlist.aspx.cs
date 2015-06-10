using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;
using System.Text;

namespace Eyousoft_yhq.Web
{
    public partial class productlist : System.Web.UI.Page
    {
        protected int pageindex = 1, pagesize = 8, recordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            initList();
        }
        protected void initList()
        {
            Eyousoft_yhq.BLL.Product bll = new Eyousoft_yhq.BLL.Product();
            Eyousoft_yhq.Model.SerProduct serchModel = new Eyousoft_yhq.Model.SerProduct();
            serchModel.PurductName = Utils.GetQueryStringValue("productName");


            if (Utils.GetQueryStringValue("proType") == "-2")
            {
                serchModel.PType = 2;
            }
            else if (Utils.GetQueryStringValue("proType") == "-3")
            {
                serchModel.PType = 3;
            }
            else
            {
                serchModel.PurductType = Utils.GetQueryStringValue("proType");
                serchModel.PType = 1;
            }
            serchModel.isVisable = false;
            var list = bll.GetList(pagesize, pageindex, ref recordCount, serchModel);

            if (list != null && list.Count > 0)
            {
                rpt_list.DataSource = list;
                rpt_list.DataBind();
            }
            else
            {
                PlaceHolder1.Visible = false;
            }
        }

        protected string getCommentNum(object id)
        {
            var i = new Eyousoft_yhq.BLL.Comment().GetCountNum(id.ToString());
            return i.ToString();
        }
        /// <summary>
        /// 返回列表显示
        /// </summary>
        /// <param name="i">出团时间</param>
        /// <param name="j">是否天天发团</param>
        /// <returns></returns>
        protected string getdate(object i, object j)
        {
            bool isEvery = (bool)j;
            if (i == null) i = "";
            DateTime date = Utils.GetDateTime(i.ToString());
            string reString = string.Empty;
            if (isEvery) reString = "天天";
            if (!isEvery) reString = date.ToString("yyyy年MM月dd日");
            return reString;
        }

        protected string getProImg(string id)
        {
            var img = new Eyousoft_yhq.BLL.Product().GetModel(id);
            if (img != null && img.AttachList != null && img.AttachList.Count > 0)
            {
                return img.AttachList[0].FilePath;
            }
            return "/images/pic01.jpg";
        }
        /// <summary>
        /// 初始化产品类型
        /// </summary>
        protected string InitDropDownList(string proType)
        {
            var list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=\"0\" >所有分类</option>");

            sb.Append("<option value=\"-2\" " + (proType == "-2" ? "selected=\"selected\"":"") + ">车票</option>");

            sb.Append("<option value=\"-3\" " + (proType == "-3" ? "selected=\"selected\"":"") + ">门票</option>");
            if (list != null && list.Count > 0)
            {
                var ls = list.Where(i => (i.TpMark == "1")).ToList();


                for (int i = 0; i < ls.Count; i++)
                {
                    if (proType == ls[i].TypeID.ToString())
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
    }
}
