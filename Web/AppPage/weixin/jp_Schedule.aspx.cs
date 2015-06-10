using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Eyousoft_yhq.Model;
using System.Xml;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_Schedule : System.Web.UI.Page
    {
        HBModel queryJpModel = new HBModel();
        List<Eyousoft_yhq.Model.Policy> datalist_Policy = new List<Eyousoft_yhq.Model.Policy>();
        EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
            }
            if (userInfo == null) Response.Redirect("/AppPage/weixin/Login.aspx");

            initOrderDetails();
          
        }
      
        void initOrderDetails()
        {
            ///PAT-XML
            StringBuilder querypolicyXML = new StringBuilder();

            //接收航班查询的结果信息
            string questXML = Utils.GetFormValue("HBbox");
            int questInt = Utils.GetInt(Utils.GetFormValue("JCbox"));
            string passerXML = Utils.GetFormValue("Passers");

            queryJpModel = (HBModel)Newtonsoft.Json.JsonConvert.DeserializeObject(questXML, typeof(HBModel));

            OrderFlight orderModel = new OrderFlight();
            StringBuilder queryOrderXML = new StringBuilder();
            //接收订单详情
            //string questXML = Utils.GetFormValue("DDbox");
            orderModel = (OrderFlight)Newtonsoft.Json.JsonConvert.DeserializeObject(questXML, typeof(OrderFlight));
            StringBuilder OrderInfoHTML = new StringBuilder();
            StringBuilder flightInfoHTMl = new StringBuilder();
            StringBuilder passerInfoHTML = new StringBuilder();

            //


            //flightInfoHTMl.Append("<li>");
            //flightInfoHTMl.Append("<div class=\"flight_binfo\">");
            //flightInfoHTMl.Append("<div class=\"flight_binfo_end\">");
            //flightInfoHTMl.AppendFormat("<p>{0}</p>", 0);
            //flightInfoHTMl.AppendFormat("<p class=\"flight_time\">{0}{1}</p>", queryJpModel.DepartureDate.ToString("MM-dd")
            //                , Utils.ConvertWeekDayToChinese(queryJpModel.DepartureDate));
            //flightInfoHTMl.Append("<div class=\"flight_binfo\">");
            //flightInfoHTMl.Append("</div>");
            //flightInfoHTMl.Append("<div class=\"flight_binfo_from\">");
            //flightInfoHTMl.AppendFormat("<p> {0}</p>", orderModel.TicketLimitDt);
            //flightInfoHTMl.AppendFormat("<p class=\"flight_time\">{0}</p>", queryJpModel.DepartureTime.ToString("HH:mm"));
            //flightInfoHTMl.Append("</div>");
            //flightInfoHTMl.Append("<div class=\"flight_binfo_direction\">");
            //flightInfoHTMl.Append("<span>飞行时长：2小时05分</span>");
            //flightInfoHTMl.Append("</div>");
            //flightInfoHTMl.Append("</div>");
            //flightInfoHTMl.Append("</li>");
            //flightInfoHTMl.AppendFormat("<li class=\"botline\">{0}{1}</li>", queryJpModel.CarrierName, queryJpModel.FlightNo);

            //
            //string[] strNames = Utils.GetFormValues("ckName");
            //OrderInfoHTML.Append("<div class=\"shenhe_R\">");
            //OrderInfoHTML.Append("<ul>");
            //OrderInfoHTML.Append("<li class=\"botline pt6\">");
            //OrderInfoHTML.Append("<p>");
            //OrderInfoHTML.AppendFormat("乘客数量：{0} 人<br />",strNames.Length );
            //OrderInfoHTML.AppendFormat("票价：￥{0}<br />", Utils.GetFormValues("sprice"));
            //OrderInfoHTML.AppendFormat("机/油：￥{0}<br />", Utils.GetFormValue("jprice"));
            //OrderInfoHTML.AppendFormat("保险：{0}<br />", 0);
            //OrderInfoHTML.AppendFormat("快递：{0}<br />", 0);
            //OrderInfoHTML.AppendFormat("总计：<span class=\"price\"><dfn>¥</dfn>{0}</span>", Utils.GetFormValues("tprice"));
            //OrderInfoHTML.Append("</p>");
            //OrderInfoHTML.Append("</li>");
            //OrderInfoHTML.Append("</ul>");
            //OrderInfoHTML.Append("</div>");
            
            //
            //if (orderModel != null && orderModel.Passengers.Count > 0)
            //{
            //    foreach (var passer in orderModel.Passengers)
            //    {
            //        passerInfoHTML.Append("<li class=\"botline pt6\">");
            //        passerInfoHTML.Append("<p>");
            //        passerInfoHTML.AppendFormat("姓名：{0}<br />", passer.Name);
            //        passerInfoHTML.AppendFormat("身份证：{0}</p>", passer.CarrierCard);
            //        passerInfoHTML.Append("</li>");
            //    }

            //}



        }
        string getIdentityXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", "18636128850", "123456");

            return sb.ToString();
        }



    }
}
