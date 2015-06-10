//会员微信Master 汪奇志 2015-01-16
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.MP
{
    /// <summary>
    /// 会员微信Master
    /// </summary>
    public partial class HuiYuanWeiXin : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// titile
        /// </summary>
        protected string YeMianTitle = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            YeMianTitle = Page.Title;
        }
        #endregion
    }
}
