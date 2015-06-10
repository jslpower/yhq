using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using EyouSoft.Common;
using System.Linq;
using System.Collections;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class jp_SearchList : System.Web.UI.Page
    {
        protected string isLogin = "0";
        Hashtable hash = new Hashtable();
        Hashtable gzhashs = new Hashtable();
        protected string WeiDianId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SSOStructure.MUserInfo userInfo = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (userInfo != null) isLogin = "1";
            getHeadHtml();
            initFlights();

            WeiDianId = Utils.GetWeiDianId();
        }
        /// <summary>
        /// 查询航班信息
        /// </summary>
        void initFlights()
        {
            StringBuilder searchXML = new StringBuilder();
            string s = Utils.GetQueryStringValue("s");//出发城市
            string d = Utils.GetQueryStringValue("d");//到达城市
            if (s.Split('-').Length > 1)//获取城市三字码
            {
                s = s.Split('-')[1];
            }
            if (d.Split('-').Length > 1)
            {
                d = d.Split('-')[1];
            }
            if (string.IsNullOrEmpty(s)
                || string.IsNullOrEmpty(d))
            {
                Utils.RCWE("<a href='/AppPage/weixin/jp_Search.aspx?weidianid=" + WeiDianId + "'>没有相关航班，返回修改出发地或日期</a>");
            }
            searchXML.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            searchXML.Append("<QueryWebFlights_1_1>");
            searchXML.AppendFormat("<From>{0}</From>", s);
            searchXML.AppendFormat("<Arrive>{0}</Arrive>", d);
            searchXML.AppendFormat("<Date>{0}</Date>", Utils.GetQueryStringValue("t"));
            searchXML.Append("<Carrier/>");
            searchXML.AppendFormat("<Time>0000</Time>");
            searchXML.Append("<StopType>D</StopType>");
            searchXML.Append("<CmdShare>0</CmdShare>");
            searchXML.Append("<BeTolerateTimes>60</BeTolerateTimes>");
            searchXML.Append("</QueryWebFlights_1_1>");

            var list = new com._8222666.fxb2b.Service().XmlSubmit(getIdentityXMLString(), searchXML.ToString(), "");

            XmlDocument dom = new XmlDocument();

            dom.LoadXml(list);

            if (dom.SelectSingleNode("ErrorInfo_1_0") != null)
            {
                return;
            }
            XmlNode nodeHash = dom.SelectSingleNode("QueryWebFlights_1_1").SelectSingleNode("Yeesky.AOIS.AV.ClassDescription");

            foreach (XmlNode item in nodeHash.ChildNodes)
            {
                hash.Add(item.Attributes["Key"].Value, item.Attributes["T"].Value);
            }
            if (hash != null)
            {
                Session["codes"] = hash;
            }

            XmlNode gzHash = dom.SelectSingleNode("QueryWebFlights_1_1").SelectSingleNode("Yeesky.AOIS.AV.TicketRules");

            foreach (XmlNode item in gzHash.ChildNodes)
            {
                List<string> lists = new List<string>();
                lists.Add(item.SelectSingleNode("Refund").InnerText);
                lists.Add(item.SelectSingleNode("Endorsement").InnerText);
                lists.Add(item.SelectSingleNode("Change").InnerText);
                //list.AddRange({item.SelectSingleNode("Refund").InnerText; item.SelectSingleNode("Endorsement").InnerText; item.SelectSingleNode("Change").InnerText});
                //gzhashs.Add(item.SelectSingleNode("TRID").InnerText, item.SelectSingleNode("Refund").InnerText);
                //gzhashs.Add(item.SelectSingleNode("TRID").InnerText, item.SelectSingleNode("Refund").InnerText);
                gzhashs.Add(item.SelectSingleNode("TRID").InnerText, lists);
            }



            List<Eyousoft_yhq.Model.HBModel> datalist = new List<Eyousoft_yhq.Model.HBModel>();
            XmlNodeList nodes = dom.SelectSingleNode("QueryWebFlights_1_1").SelectSingleNode("Yeesky.AOIS.AV.Results").SelectNodes("AV.Result");
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    var model = new Eyousoft_yhq.Model.HBModel();
                    model.ID = nodes[i].SelectSingleNode("ID").InnerText;
                    model.FlightID = nodes[i].SelectSingleNode("FlightID").InnerText;
                    model.ElementNo = nodes[i].SelectSingleNode("ElementNo").InnerText;
                    model.Carrier = nodes[i].SelectSingleNode("Carrier").InnerText;
                    model.CarrierName = nodes[i].SelectSingleNode("CarrierName").InnerText;
                    model.FlightNo = nodes[i].SelectSingleNode("FlightNo").InnerText;
                    model.ShareCarrier = nodes[i].SelectSingleNode("ShareCarrier").InnerText;
                    model.ShareCarrierName = nodes[i].SelectSingleNode("ShareCarrierName").InnerText;
                    model.ShareFlight = nodes[i].SelectSingleNode("ShareFlight").InnerText;
                    model.BoardPoint = nodes[i].SelectSingleNode("BoardPoint").InnerText;
                    model.BoardPointName = nodes[i].SelectSingleNode("BoardPointName").InnerText;
                    model.OffPoint = nodes[i].SelectSingleNode("OffPoint").InnerText;
                    model.OffPointName = nodes[i].SelectSingleNode("OffPointName").InnerText;
                    model.DepartureDate = Utils.GetDateTime(nodes[i].SelectSingleNode("DepartureDate").InnerText);
                    model.DepartureTime = Utils.GetDateTime(nodes[i].SelectSingleNode("DepartureTime").InnerText);
                    model.ArrivalDate = Utils.GetDateTime(nodes[i].SelectSingleNode("ArrivalDate").InnerText);
                    model.ArrivalTime = Utils.GetDateTime(nodes[i].SelectSingleNode("ArrivalTime").InnerText);
                    model.Aircraft = nodes[i].SelectSingleNode("Aircraft").InnerText;
                    model.AircraftName = nodes[i].SelectSingleNode("AircraftName").InnerText;
                    model.Meal = nodes[i].SelectSingleNode("Meal").InnerText;
                    model.MealName = nodes[i].SelectSingleNode("MealName").InnerText;
                    model.ViaPort = Utils.GetInt(nodes[i].SelectSingleNode("ViaPort").InnerText);
                    model.ETicket = nodes[i].SelectSingleNode("ETicket").InnerText;
                    model.ASR = nodes[i].SelectSingleNode("ASR").InnerText;
                    model.LinkLevel = nodes[i].SelectSingleNode("LinkLevel").InnerText;
                    model.AirportTax = Utils.GetDecimal(nodes[i].SelectSingleNode("AirportTax").InnerText);
                    model.FuelSurTax = Utils.GetDecimal(nodes[i].SelectSingleNode("FuelSurTax").InnerText);
                    model.Mileage = Utils.GetInt(nodes[i].SelectSingleNode("Mileage").InnerText);
                    //model.Flightx = nodes[i].SelectSingleNode("Flightx").InnerText;
                    //model.BoardTimex = nodes[i].SelectSingleNode("BoardTimex").InnerText;
                    //model.OffTimex = nodes[i].SelectSingleNode("OffTimex").InnerText;
                    model.BoardPointAT = nodes[i].SelectSingleNode("BoardPointAT").InnerText;
                    model.OffPointAT = nodes[i].SelectSingleNode("OffPointAT").InnerText;
                    model.YPrice = Utils.GetDecimal(nodes[i].SelectSingleNode("YPrice").InnerText);
                    model.Class = new List<Eyousoft_yhq.Model.webFlightInfo>();
                    XmlNode node = nodes[i].SelectSingleNode("Class");
                    int identyty = 0;
                    foreach (XmlNode item in node.ChildNodes)
                    {
                        Eyousoft_yhq.Model.webFlightInfo classModel = new Eyousoft_yhq.Model.webFlightInfo();
                        classModel.Seat = item.SelectSingleNode("Seat").InnerText;
                        classModel.Code = item.SelectSingleNode("Code").InnerText;
                        classModel.TradeId = item.SelectSingleNode("TradeId").InnerText;
                        classModel.TRID = Utils.GetInt(item.SelectSingleNode("TRID").InnerText);
                        classModel.Type_class = item.SelectSingleNode("Type").InnerText;
                        classModel.F = Utils.GetDecimal(item.SelectSingleNode("F").InnerText);
                        classModel.R = Utils.GetDecimal(item.SelectSingleNode("R").InnerText);
                        classModel.X = Utils.GetDecimal(item.SelectSingleNode("X").InnerText);
                        classModel.A = Utils.GetDecimal(item.SelectSingleNode("A").InnerText);
                        classModel.C = Utils.GetDecimal(item.SelectSingleNode("C").InnerText);
                        classModel.M = Utils.GetDecimal(item.SelectSingleNode("M").InnerText);
                        classModel.S = Utils.GetDecimal(item.SelectSingleNode("S").InnerText);
                        classModel.PriceSource = Utils.GetDecimal(item.SelectSingleNode("PriceSource").InnerText);
                        classModel.XmlNodeName = item.Name;
                        classModel.Identity = identyty;
                        if (classModel.F > 0)
                        {
                            identyty++;
                            model.Class.Add(classModel);
                        }
                    }
                    datalist.Add(model);

                }
            }
            int count = datalist.Count;
            StringBuilder strHTML = new StringBuilder();
            foreach (var item in datalist)
            {
                if (item.Class.Count == 0)
                    continue;
                strHTML.Append("<li>");
                strHTML.Append("<div class=\"jp-item\">");
                strHTML.Append("<a href=\"javascript:;\" target=\"_self\">");
                strHTML.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                strHTML.Append("<tr>");
                strHTML.AppendFormat("<td class=\"leftside\">{0}</td>", item.DepartureTime.ToString("HH:mm"));
                strHTML.AppendFormat("<td class=\"midside\">{0}{1}</td>", item.CarrierName, item.FlightNo);
                var f = item.Class.Count > 0 ? item.Class.Select(x => x.F).Min() : 0;
                var t = (from c in item.Class
                         where c.F == f
                         select c).First();
                strHTML.AppendFormat("<td class=\"rightside\"><span class=\"price\"><dfn>¥</dfn>{0}</span></td>", f.ToString().TrimEnd('0').TrimEnd('.'));
                strHTML.Append("</tr>");
                strHTML.Append("<tr class=\"font-color\">");
                strHTML.AppendFormat("<td class=\"leftside\">{0}</td>", item.ArrivalTime.ToString("HH:mm"));
                strHTML.AppendFormat("<td class=\"midside\">{0}-{1}</td>", item.BoardPointName, item.OffPointName);
                strHTML.AppendFormat("<td class=\"rightside\"><a href=\"javascript:void(0):;\" onclick=\"showflightinfo($(this),'{0}')\" class=\"fontblue\">退改签</a></td>", Server.HtmlEncode(GetGZHtml(t.TRID.ToString())));

                strHTML.Append("</tr>");
                strHTML.Append("</table>");
                strHTML.Append("</a>");

                strHTML.Append("</div>");//拼接航班信息
                strHTML.Append("<div class=\"down\"></div>");
                if (item.Class != null && item.Class.Count > 0)
                {
                    strHTML.Append("<div class=\"jp_more\" style=\"display:none;\">");
                    strHTML.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                    for (int k = 0; k < item.Class.Count; k++)
                    {
                        strHTML.Append("<tr>");
                        strHTML.AppendFormat("<td class=\"leftside\">{0}</td>", getCM(item.Carrier, item.Class[k].Code));
                        strHTML.AppendFormat("<td class=\"font_yellow\">{0}</td>", getZK(item.Class[k].XmlNodeName));
                        if (getYW(item.Class[k].Seat) == "0")
                        {
                            strHTML.Append("<td>已满</td>");
                            //strHTML.Append("<td></td>");
                        }
                        else
                        {
                            strHTML.AppendFormat("<td>余：{0}</td>", getYW(item.Class[k].Seat));
                            //<a href="javascript:void(0);" onmouseover="showflightinfo($(this),'CZ8465');" class="flightselectdetail">详细</a>

                        }
                        //如果没有退签
                        if (string.IsNullOrEmpty(gzhashs[item.Class[k].TRID.ToString()].ToString()) || item.Class[k].TRID.ToString() == "0")
                        {

                            strHTML.AppendFormat("<td align=\"center\"><a href=\"javascript:void(0);\" onclick=\"showflightinfo($(this),'{0}');\" class=\"fontblue\"></a></td>", "暂无");
                        }
                        else
                        {

                            strHTML.AppendFormat("<td align=\"center\"><a href=\"javascript:void(0);\" onclick=\"showflightinfo($(this),'{0}');\" class=\"fontblue\">退改签</a></td>", Server.HtmlEncode(GetGZHtml(item.Class[k].TRID.ToString())));
                        }
                        //如果座位没有显示为已满
                        if (getYW(item.Class[k].Seat) == "0")
                        {
                            strHTML.AppendFormat("<td class=\"rightside\"><a data-Id=\"{2}\" href=\"javascript:;\" class=\"price-btn\">{0}</a><div style=\"display:none;\">{1}</div></td>", "已满", Newtonsoft.Json.JsonConvert.SerializeObject(item), item.Class[k].Identity);

                        }
                        else
                        {
                            strHTML.AppendFormat("<td class=\"rightside\"><a data-Id=\"{2}\" href=\"javascript:;\" class=\"price-btn selectHB\"><dfn>¥</dfn>{0}</a><div style=\"display:none;\">{1}</div></td>", item.Class[k].F.ToString().TrimEnd('0').TrimEnd('.'), Newtonsoft.Json.JsonConvert.SerializeObject(item), item.Class[k].Identity);

                        }
                        //strHTML.Append("<a herf=\"javascript:;\" onclick=\"$('.gz').show()\">退签</a>");
                        //strHTML.AppendFormat("<input class=\"gz\" type=\"hidden\" value={0}/>", gzhashs[item.Class[k].TRID]);
                        strHTML.Append("</tr>");
                    }

                    strHTML.Append("</table>");
                    strHTML.Append("</div>");
                }
                strHTML.Append("</li>");
            }
            litHTML.Text = strHTML.ToString();

        }


        #region 私有方法
        /// <summary>
        /// 获取identity字符串
        /// </summary>
        /// <returns></returns>
        // string getIdentityXMLString(string username, string userPwd)
        string getIdentityXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", "18636128850", "123456");

            return sb.ToString();
        }
        /// <summary>
        /// 初始化页面头部操作
        /// </summary>
        void getHeadHtml()
        {
            DateTime? dt = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("t"));
            if (dt.HasValue)
            {
                lblDate.Text = string.Format("{0} {1}", dt.Value.ToString("yyyy-MM-dd"), Utils.ConvertWeekDayToChinese(dt.Value));
                if (DateTime.Now.ToString("yyyy-MM-dd") == dt.Value.ToString("yyyy-MM-dd"))
                {
                    litPrev.Text = "<td class=\"prev a_disable\"><a href=\"javascript:;\">前一天</a></td>";
                }
                else
                {
                    litPrev.Text = string.Format("<td class=\"prev\"><a href=\"/AppPage/weixin/jp_SearchList.aspx?s={0}&d={1}&t={2}\">前一天</a></td>", Utils.GetQueryStringValue("s"), Utils.GetQueryStringValue("d"), dt.Value.ToString("yyyy-MM-dd"));
                }
                litNext.Text = string.Format("<td class=\"next\"><a href=\"/AppPage/weixin/jp_SearchList.aspx?s={0}&d={1}&t={2}\">后一天</a></td>", Utils.GetQueryStringValue("s"), Utils.GetQueryStringValue("d"), dt.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            else
            {
                Utils.RCWE("<a href='/AppPage/weixin/jp_Search.aspx'>没有相关航班，返回修改出发地或日期</aspx>");
            }
        }
        /// <summary>
        /// 获取机舱名称
        /// </summary>
        /// <param name="code">节点名称</param>
        /// <returns></returns>
        string getCM(string carrie, string code)
        {
            if (string.IsNullOrEmpty(code)) return "舱位待定";

            string cw = hash[carrie + code] as string;
            return cw;
        }
        /// <summary>
        /// 获取折扣
        /// </summary>
        /// <param name="code">节点名称</param>
        /// <returns></returns>
        string getZK(string code)
        {
            if (string.IsNullOrEmpty(code)) return "舱位待定";
            string cCode = code.Substring(1);
            if (Utils.GetInt(cCode) > 1)
            {
                return Utils.GetInt(cCode).ToString() + "折";
            }
            else
            {
                return "原价";
            }
        }
        /// <summary>
        /// 获取机舱余位
        /// </summary>
        /// <param name="code">seat</param>
        /// <returns></returns>
        string getYW(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length < 1) return "已满";
            if (code == "NA" || code == "SA") return "9个以上";
            string cCode = code.Substring(1);
            int returnStr = Utils.GetInt(cCode);
            return returnStr.ToString(); ;
        }

        #endregion


        public string GetGZHtml(string trid)
        {
            List<string> lists = gzhashs[trid] as List<string>;

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"header\">");
            sb.Append("<h1>退改签说明</h1>");
            sb.Append("<a href=\"javascript:window.history.go(-1);\"  class=\"returnico\"></a>");
            sb.Append("<a href=\"tel:4008005216\" class=\"icon_phone\"></a>");
            sb.Append("</div>");

            sb.Append("<div class=\"mainbox\">");

            sb.Append("<div class=\"rili_box\">");
            sb.Append("<div class=\"rili_T\">退票条件</div>");
            sb.AppendFormat("<div class=\"gaiqian_txt\">{0}</div>", string.IsNullOrEmpty(lists[0]) ? "暂无" : lists[0]);
            sb.Append("</div>");
            sb.Append("<div class=\"rili_box\">");
            sb.Append("<div class=\"rili_T\">改签条件</div>");
            sb.AppendFormat("<div class=\"gaiqian_txt\">{0}</div>", string.IsNullOrEmpty(lists[0]) ? "暂无" : lists[1]);
            sb.Append("</div>");
            if (!string.IsNullOrEmpty(lists[2]))
            {
                sb.Append("<div class=\"rili_box\">");
                sb.Append("<div class=\"rili_T\">改期说明</div>");
                sb.AppendFormat("<div class=\"gaiqian_txt\">{0}</div>", lists[2]);
                sb.Append("</div>");
            }


            sb.Append("</div>");
            return sb.ToString();
        }
    }
}
