using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yhq.webMaster
{
    public partial class LeftMenuList : EyouSoft.Common.Page.webmasterPage
    {
        private EyouSoft.Model.SSOStructure.MWebmasterInfo _userInfo = EyouSoft.Common.Page.webmasterPage.GetUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_userInfo == null) Response.Redirect("login.aspx");

            if (_userInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.系统)
            {
                phXiTongYongHu.Visible = true;

                PlaceHolder0.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.用户注册信息管理);
                PlaceHolder4.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.产品展示管理);
                PlaceHolder5.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.优惠券使用管理);
                PlaceHolder8.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.评论管理);
                PlaceHolder11.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.管理列表);
                PlaceHolder12.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.产品类别管理);
                PlaceHolder23.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.公司信息);
                PlaceHolder1.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.轮换图片);
                PlaceHolder2.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.订单管理);
                PlaceHolder7.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.车票管理);
                PlaceHolder10.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.门票管理);
                PlaceHolder9.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.机票管理);
                PlaceHolder13.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.微信管理);
                divWeiDian.Visible = CheckGrantMenu2(Eyousoft_yhq.Model.Privs.微店管理);
            }

            if (_userInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                phGysYongHu.Visible = true;
            }
        }
    }
}
