using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class RegUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("type");
            if (type == "anget")
            {
                Response.Redirect(getYskURL());
            }
        }
        /// <summary>
        /// 获取注册用户XML
        /// </summary>
        /// <returns></returns>
        private string getCreateCustomerXML()
        {
            StringBuilder sb = new StringBuilder();
            var model = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (model != null)
            {
                sb.Append("<CreateCustomer_1_0>");
                sb.AppendFormat("<CustomerName>{0}</CustomerName>", model.ContactName);
                sb.AppendFormat("<Linker>{0}</Linker>", model.ContactName);
                sb.AppendFormat("<Phone>{0}</Phone>", model.UserName);
                sb.AppendFormat("<LoginName>{0}</LoginName>", model.UserName);
                sb.AppendFormat("<Password>{0}</Password>", model.UserPwd);
                sb.Append("</CreateCustomer_1_0>");
            }
            return sb.ToString();
        }


        protected string getYskURL()
        {

            var MemberModel = EyouSoft.Common.Page.HuiyuanPage.GetUserInfo();
            if (MemberModel == null) return string.Empty;
            string str = new com._8222666.fxs.Service().XmlSubmit(getIdentityXMLString(MemberModel.UserName, MemberModel.UserPwd), getRequestXMLString(MemberModel.UserName), "");
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(str);
            string scode = dom.DocumentElement.FirstChild.InnerText;
            string u = MemberModel.UserName;
            string p = GetMD5Hash(MemberModel.UserPwd);
            string key = GetMD5Hash(MemberModel.UserName + MemberModel.UserPwd + scode);
            string url = string.Format("{4}/urllogin.aspx?u={0}&p={1}&scode={2}&key={3}&url=/Framework/Frame.aspx", u, p, scode, key, Utils.GetConfigString("appSettings", "JPURL"));
            return url;

        }
        /// <summary>
        /// 获取加密后的密码
        /// </summary>
        /// <param name="strPwd">密码</param>
        /// <returns></returns>
        private string GetMD5Hash(string strPwd)
        {
            StringBuilder sb = new StringBuilder(32);
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            for (int i = 0; i < md5data.Length; i++)
            {
                sb.Append(md5data[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString().ToUpper();
        }
        /// <summary>
        /// 获取identity字符串
        /// </summary>
        /// <returns></returns>
        private string getIdentityXMLString(string username, string userPwd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Identity_1_0><Operator>{0}</Operator><Pwd>{1}</Pwd><UserType>Distributor</UserType> </Identity_1_0> ", username, userPwd);

            return sb.ToString();
        }
        /// <summary>
        /// 获取request字符串
        /// </summary>
        /// <returns></returns>
        private string getRequestXMLString(string userName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<GetAutoLoginKey_1_0> <LoginID>{0}</LoginID> </GetAutoLoginKey_1_0> ", userName);

            return sb.ToString();
        }
    }
}
