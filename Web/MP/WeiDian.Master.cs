//微店Master 汪奇志 2015-01-16
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.MP
{
    /// <summary>
    /// 微店Master
    /// </summary>
    public partial class WeiDian : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// titile
        /// </summary>
        protected string YeMianTitle = string.Empty;
        protected string WDesc = string.Empty;
        protected string TXImg = string.Empty;
        bool _IsLoadDefaultCss = true;
        public bool IsLoadDefaultCss { get { return _IsLoadDefaultCss; } set { this._IsLoadDefaultCss = value; } }
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
            var WeiDianID = EyouSoft.Common.Utils.GetWeiDianId();
            var weiDianInfo = new Eyousoft_yhq.BLL.BWeiDian().GetInfo(WeiDianID);
            if (weiDianInfo != null)
            {
                WDesc = weiDianInfo.JieShao;
                var info = new Eyousoft_yhq.BLL.Member().GetModel(weiDianInfo.HuiYuanId);
                if (info != null) TXImg = "http://www.4008005216.com" + info.TuXiangFilepath;
            }
        }
        #endregion
    }
}
