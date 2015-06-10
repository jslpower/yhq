using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiXin
{
    /// <summary>
    /// 微信测试
    /// </summary>
    public partial class ___ceshi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("FFFF<br/>");
            string url = string.Format("/weixin/bangding_huiyuan.aspx?yonghuid={0}&openid={1}", "ca818ba8-c0bb-4908-8ede-8c763f76b410", "ouCeqjjx3W2kVBwNbtsI5hAVMVyk");
            Response.Clear();
            Server.Transfer(url);
            Response.End();
            //GuanZhu();
        }

        void YongHu_U()
        {
            var info = new Eyousoft_yhq.Model.MWeiXinYongHuInfo();

            info.YongHuId = "3fd570da-e677-4287-8b51-0b81db3916ae";
            info.openid = "A";
            info.subscribe = "1";

            int bllRetCode=new Eyousoft_yhq.BLL.BWeiXin().YongHu_U(info);

            Utils.RCWE(bllRetCode.ToString());
        }

        void GuanZhu()
        {
            int bllRetCode = new Eyousoft_yhq.BLL.BWeiXin().GuanZhu("A","0");
            bllRetCode = new Eyousoft_yhq.BLL.BWeiXin().GuanZhu("B","1");
            bllRetCode = new Eyousoft_yhq.BLL.BWeiXin().GuanZhu("C", "1");

            Utils.RCWE(bllRetCode.ToString());
        }
    }
}
