//未找到微店 汪奇志 2015-01-19
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.WeiDian
{
    /// <summary>
    /// 未找到微店
    /// </summary>
    public partial class NotFound : System.Web.UI.Page
    {
        #region attributes
        /// <summary>
        /// 提示消息
        /// </summary>
        protected string XiaoXi = "你查看的微店不存在或已关闭";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string xxlx = Utils.GetQueryStringValue("xxlx");

            switch (xxlx)
            {
                case "1": XiaoXi = "你查看的微店正在审核中，审核通过后将为您开通。"; break;
                case "2": XiaoXi = "你暂未开通微店，不能使用该功能"; break;
                default: XiaoXi = "你查看的微店不存在或已关闭"; break;
            }

            this.Title = XiaoXi;
        }
    }
}
