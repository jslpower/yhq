using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_RiLi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initRiLi();
        }

        void initRiLi()
        {
            ///当前月
            StringBuilder strMonth = new StringBuilder();
            strMonth.Append("<div class=\"rili_box\">");
            strMonth.AppendFormat("<div class=\"rili_T\"> {0}</div>", DateTime.Now.ToString("yyyy年MM月"));
            strMonth.Append("<div class=\"rili_head\"><ul class=\"fixed\"><li>日</li><li>一</li><li>二</li><li>三</li><li>四</li><li>五</li><li>六</li></ul></div>");
            strMonth.Append("<div class=\"rili_num\"><ul class=\"fixed\">");
            int firstLi = (int)DateTime.Now.AddDays(1 - DateTime.Now.Day).DayOfWeek;
            for (int i = 0; i < firstLi; i++)
            {
                strMonth.Append("<li></li>");//补全空白
            }
            for (int i = 0; i < DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1).Day; i++)
            {
                #region 输出日历
                if (DateTime.Now.Day == i + 2)
                {
                    strMonth.AppendFormat("<li class=\"past\"><a data-rili=\"{1}\"  href=\"javascript:;\">{0}</a></li>", "昨天",
                       DateTime.Now.AddDays(1 - DateTime.Now.Day + i).ToString("yyyy-MM-dd"));
                }
                else if (DateTime.Now.Day == i + 1)
                {
                    strMonth.AppendFormat("<li class=\"now\"><a data-rili=\"{1}\"  class=\"selectDate\" href=\"javascript:;\">{0}</a></li>", "今天",
                       DateTime.Now.AddDays(1 - DateTime.Now.Day + i).ToString("yyyy-MM-dd"));
                }

                else if (DateTime.Now.Day == i)
                {
                    strMonth.AppendFormat("<li class=\"now\"><a data-rili=\"{1}\"  class=\"selectDate\" href=\"javascript:;\">{0}</a></li>", "明天",
                       DateTime.Now.AddDays(1 - DateTime.Now.Day + i).ToString("yyyy-MM-dd"));
                }
                else
                {
                    if (DateTime.Now.Day < i + 1)
                    {
                        strMonth.AppendFormat("<li ><a  data-rili=\"{1}\"  class=\"selectDate\"  href=\"javascript:;\">{0}</a></li>", i + 1, DateTime.Now.AddDays(1 - DateTime.Now.Day + i).ToString("yyyy-MM-dd"));//输出日期
                    }
                    else
                    {
                        strMonth.AppendFormat("<li class=\"past\"><a  data-rili=\"{1}\"   href=\"javascript:;\">{0}</a></li>", i + 1, DateTime.Now.AddDays(1 - DateTime.Now.Day + i).ToString("yyyy-MM-dd"));//输出日期
                    }
                }
                #endregion
            }

            strMonth.Append("</ul></div></div>");

            litMonth.Text = strMonth.ToString();


            ///下个月
            StringBuilder strNextMonth = new StringBuilder();
            strNextMonth.Append("<div class=\"rili_box\">");
            strNextMonth.AppendFormat("<div class=\"rili_T\"> {0}</div>", DateTime.Now.AddMonths(1).ToString("yyyy年MM月"));
            strNextMonth.Append("<div class=\"rili_head\"><ul class=\"fixed\"><li>日</li><li>一</li><li>二</li><li>三</li><li>四</li><li>五</li><li>六</li></ul></div>");
            strNextMonth.Append("<div class=\"rili_num\"><ul class=\"fixed\">");
            int firstLiNextMonth = (int)DateTime.Now.AddMonths(1).AddDays(1 - DateTime.Now.Day).DayOfWeek;
            for (int i = 0; i < firstLiNextMonth; i++)
            {
                strNextMonth.Append("<li></li>");//补全空白
            }
            for (int i = 0; i < DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(2).AddDays(-1).Day; i++)
            {
                strNextMonth.AppendFormat("<li ><a  data-rili=\"{1}\"  class=\"selectDate\"  href=\"javascript:;\">{0}</a></li>", i + 1, DateTime.Now.AddMonths(1).AddDays(1 - DateTime.Now.Day + i).ToString("yyyy-MM-dd"));//输出日期
            }

            strNextMonth.Append("</ul></div></div>");

            litNextMonth.Text = strNextMonth.ToString();


        }
    }
}
