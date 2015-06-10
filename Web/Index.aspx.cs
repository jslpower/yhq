using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Linq;

namespace Eyousoft_yhq.Web
{
    public partial class Index : System.Web.UI.Page
    {
        #region  分页参数
        protected int pageSize = 6, pageIndex = 1, recordCount = 0;
        protected string tj, xl, zx, jg;
        protected string fuwushang = "0", dingdanliang = "0", chengjiaoe = "0";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RawUrl.ToLower() == "/index.aspx")
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;
            }
            InitList();
            var model = new Eyousoft_yhq.BLL.KV().GetComLianMeng();
            if (model != null)
            {
                fuwushang = model.Agent.ToString();
                dingdanliang = model.OorderCount.ToString();
                chengjiaoe = model.SealMoney.ToString("C0");
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        protected void InitList()
        {
            Eyousoft_yhq.Model.SerProduct serModel = new Eyousoft_yhq.Model.SerProduct();
            serModel.PType = Utils.GetInt(Utils.GetQueryStringValue("tp"));
            serModel.PurductName = Utils.GetQueryStringValue("keys");
            serModel.SFTJ = Utils.GetInt(Utils.GetQueryStringValue("ishot"));
            serModel.DDXL = Utils.GetInt(Utils.GetQueryStringValue("sale"));
            serModel.SJPX = Utils.GetInt(Utils.GetQueryStringValue("issue"));
            serModel.JGPX = Utils.GetInt(Utils.GetQueryStringValue("price"));
            int Productype = Utils.GetInt(Utils.GetQueryStringValue("routype"));
            serModel.PurductType = Productype > 0 ? Productype.ToString() : "";

            #region 输出样式
            //tj = getClass(serModel.SFTJ);
            xl = getClass(serModel.DDXL);
            zx = getClass(serModel.SJPX);
            jg = getClass(serModel.JGPX);
            #endregion


            pageIndex = UtilsCommons.GetPagingIndex("Page");
            IList<Eyousoft_yhq.Model.Product> list = new Eyousoft_yhq.BLL.Product().GetList(pageSize, pageIndex, ref recordCount, serModel);

            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            if (list != null && list.Count > 0)
            {
                rpt_products.DataSource = list;
                rpt_products.DataBind();

            }
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));
        }
        protected void RegisterScript(string script)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
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
                    if (img[i].IsWebImage && !string.IsNullOrEmpty(img[i].FilePath)) return img[i].FilePath;
                }
            }
            return "/images/list_img.gif";
        }
        /// <summary>
        /// 返回剩余有效期时间
        /// </summary>
        /// <param name="mark">是否天天发团</param>
        /// <param name="time">有效期</param>
        /// <returns></returns>
        protected string getOverTime(string mark, string time)
        {
            if (mark.ToLower() == "true") return "天天发团";
            DateTime optTime = Utils.GetDateTime(time);
            if (DateTime.Compare(optTime, DateTime.Now) < 0) return "0天0时0分0秒";
            TimeSpan ts = optTime - DateTime.Now; ;
            return string.Format("{0}天{1}时{2}分{3}秒", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }

        protected string getClass(int i)
        {
            string retStr = string.Empty;
            switch (i)
            {
                case 1:
                    retStr = "class=\"on\"";
                    break;
                case 2:
                    retStr = "class=\"on_up\"";
                    break;
                default:
                    break;
            }
            return retStr;
        }


        /// <summary>
        /// 初始化菜单
        /// </summary>
        protected string Initfenlei(string obj)
        {
            System.Text.StringBuilder strBu = new System.Text.StringBuilder();
            IList<Eyousoft_yhq.Model.ProductType> list = new Eyousoft_yhq.BLL.ProductType().GetList(null);
            if (list != null && list.Count > 0)
            {
                list = list.Where(t => t.TpMark == "1").ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TypeID.ToString() == obj)
                    {
                        strBu.AppendFormat("<li><a  class=\"on\"  href=\"/Index.aspx?routype={0}\">{1}</a></li>", list[i].TypeID, list[i].TypeName);
                    }
                    else
                    {
                        strBu.AppendFormat("<li><a   href=\"/Index.aspx?routype={0}\">{1}</a></li>", list[i].TypeID, list[i].TypeName);
                    }
                }
            }
            return strBu.ToString();
        }


    }
}
