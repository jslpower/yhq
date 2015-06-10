using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using EyouSoft.Common;
using System.Text;
using System.Net;
using System.IO;

namespace Eyousoft_yhq.Web
{
    public partial class testIns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // System.Web.HttpContext.Current.Request.ServerVariables["HTTP_REFERER"]


            StringBuilder strXML = new StringBuilder();
            strXML.Append("<?xml version=\"1.0\" encoding=\"GB2312\" ?>");

            strXML.AppendFormat("<消息 功能=\"投保\" 机构编号=\"4789\" 操作员编号=\"5996\"  流水号=\"BX{0}\" 来源=\"惠旅游\" >", DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            strXML.AppendFormat("<消息内容 姓名=\"刘树超\" ");
            strXML.AppendFormat("证件号=\"0633027\" ");
            strXML.AppendFormat("证件类型=\"其他\" ");
            strXML.AppendFormat("性别=\"男\" ");
            strXML.AppendFormat("航班号=\"MF8053\" ");
            strXML.AppendFormat("移动电话=\"15057103208\" ");
            strXML.AppendFormat("电子邮件=\"601634540@qq.com\" ");
            strXML.AppendFormat("联系电话=\"\" ");
            strXML.AppendFormat("险种编号=\"10604001\" ");
            strXML.AppendFormat("险种名称=\"航空意外伤害保险(15301)\" ");
            strXML.AppendFormat("出生日期=\"{0}\" ", "1990-05-19");
            strXML.AppendFormat("保单生效日=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            strXML.AppendFormat("保险期间=\"7\" ");
            strXML.AppendFormat("保单结束日=\"\" ");
            strXML.AppendFormat("投保时间=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            strXML.AppendFormat("保费=\"20.00\" ");
            strXML.AppendFormat("单证号码=\"\" ");
            strXML.AppendFormat("出访国家=\"\" ");
            strXML.AppendFormat("访问目的=\"\" ");
            strXML.AppendFormat("推荐人=\"\" ");
            strXML.AppendFormat("受益人姓名=\"\" ");
            strXML.AppendFormat("受益人与被保险人关系=\"\" ");
            strXML.AppendFormat("受益人证件类型=\"\" ");
            strXML.AppendFormat("受益人证件号码=\"\" ");
            strXML.AppendFormat("受益人性别=\"\" /> ");

            strXML.Append("</消息>");
            MD5 md5 = new MD5CryptoServiceProvider();
            Encoding encoding = Encoding.GetEncoding("GB2312");
            string md5Code = Utils.Sign("fe355d54714420230689f2889464f323a08405593001011061", strXML.ToString(), "GB2312");

            string postData = md5Code + "|" + strXML.ToString();
            Literal1.Text = postData;
            byte[] data = encoding.GetBytes(postData);

            string sendURL = Utils.GetConfigString("appSettings", "InsSendURL");

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(sendURL);

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();
            Response.Write(content);
        }
    }
}
