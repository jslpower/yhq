using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;
using System.Collections.Generic;

namespace Eyousoft_yhq.Web
{
    public partial class Jporderlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //getPayHtml();
            //inintPages();

        }
        void inintPages()
        {   //获得要查询订单支付状态参数
            string s = Utils.GetQueryStringValue("pay");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<Eyousoft_yhq.Model.MJiPiaoBaoCun> plists = new List<Eyousoft_yhq.Model.MJiPiaoBaoCun>();
            Eyousoft_yhq.BLL.BJiPiaoBaoCun jservice = new Eyousoft_yhq.BLL.BJiPiaoBaoCun();

            if (s == "y")
            {
                //获取没付款的订单
                //plists=jservice.GetModel();
                foreach (var item in plists)
                {
                    sb.Append("<li>");
                    sb.Append("<div class=\"dindan_R\">");
                    sb.AppendFormat("<p><span class=\"price\"><dfn>¥</dfn>299</span></p>", 0);
                    sb.AppendFormat("<p><a href={0} class=\"fukuan_btn\">付款</a></p>", 0);
                    sb.Append("</div>");
                    sb.Append("<div class=\"dindan_L\">");
                    sb.AppendFormat("<p>南方航空CZ6412    2014-08-21 周四</p>", 0);
                    sb.AppendFormat("<p class=\"font_gray\">首都-虹桥</p>", 0);
                    sb.Append("</div>");
                    sb.Append("</li>");
                }

            }
            else
            {
                //获取已经付款的订单
                //plists = jservice.GetModel();
                foreach (var item in plists)
                {
                  
                    sb.Append("<li><div class=\"dindan_R\">");
                    sb.AppendFormat("<p><span class=\"price\"><dfn>¥</dfn>299</span></p>", 0);
                    sb.AppendFormat("<p> class=\"font_green\">已付款</p>", 0);
                    sb.Append("</div>");
                    sb.Append("<div class=\"dindan_L\">");
                    sb.AppendFormat("<p>南方航空CZ6412    2014-08-21 周四</p>", 0);
                    sb.AppendFormat("<p class=\"font_gray\">首都-虹桥</p>", 0);
                    sb.Append("</div></li>");
                  
                }

            }



            this.litJiPlist.Text = sb.ToString();

        }
        /// <summary>
        /// 初始化页面头部操作
        /// </summary>
        void getPayHtml()
        {
            //<li class="current"><a href="jipiao_book5.html">未付款</a></li>
            // <li><a href="jipiao_book4.html">已付款</a></li>
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<li class=\"current\"><a href=\"Jporderlist.aspx?pay=n\">未付款</a></li>");
            sb.Append("<li><a href=\"Jporderlist.aspx?pay=y\">已付款</a></li>");
            this.litPay.Text = sb.ToString();
        }
    }
}
