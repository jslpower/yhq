//旅游顾问 汪奇志 2015-01-21
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 旅游顾问
    /// </summary>
    public partial class LvYouGuWen : HuiYuanWeiXinYeMian
    {
        protected int ProviceId = 0;//省份
        protected int CityId = 0;//城市
        protected int AreaId = 0;//区县
        protected int StreetId = 0;//街道
        protected string Level = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            InitRpt();
        }

        //public string BindList()
        //{
            
        //}


        #region private members
        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var chaXun = new Eyousoft_yhq.Model.MSearchUser();
            chaXun.IsLvYouGuWen = true;

            int pageSize = 10000;
            int pageIndex = 1;
            int recordCount = 0;

            string MemberOption = Utils.GetQueryStringValue("MemberOption");
            if (!string.IsNullOrEmpty(MemberOption) && MemberOption != "-1")
            {
                chaXun.MemberOption = (Eyousoft_yhq.Model.MemberOption)Utils.GetInt(MemberOption);
            }
            ProviceId = Utils.GetInt(Utils.GetQueryStringValue("MyProvice"));
            CityId = Utils.GetInt(Utils.GetQueryStringValue("MyCity"));
            AreaId = Utils.GetInt(Utils.GetQueryStringValue("MyArea"));
            StreetId = Utils.GetInt(Utils.GetQueryStringValue("MyStreet"));
            Level = Utils.GetQueryStringValue("Level");
            switch (Level)
            {
                case "1":
                    chaXun.ProviceId = ProviceId;
                    break;
                case "2":
                    chaXun.CityId = CityId;
                    break;
                case "3":
                    chaXun.AreaId = AreaId;
                    break;
                case "4":
                    chaXun.StreetId = StreetId;
                    break;
            }
            var items = new Eyousoft_yhq.BLL.Member().GetList(pageSize, pageIndex, ref recordCount, chaXun, 0);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            } 
            //var chaXun = new Eyousoft_yhq.Model.MSearchUser();
            //chaXun.IsLvYouGuWen = true;

            //int pageSize = 10000;
            //int pageIndex = 1;
            //int recordCount = 0;

            //string MemberOption = Utils.GetQueryStringValue("MemberOption");
            //if (!string.IsNullOrEmpty(MemberOption) && MemberOption != "-1")
            //{
            //    chaXun.MemberOption = (Eyousoft_yhq.Model.MemberOption)Utils.GetInt(MemberOption);
            //}
                      

            //var items = new Eyousoft_yhq.BLL.Member().GetList(pageSize, pageIndex, ref recordCount, chaXun,0);

            //if (items != null && items.Count > 0)
            //{
            //    rpt.DataSource = items;
            //    rpt.DataBind();
            //}
            
        }
        #endregion

        #region protected members
        /// <summary>
        /// get tuxiang
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetTuXiang(object filepath)
        {
            string defaultfFlepath = "/images/weixin/head_no.png";
            if (filepath == null) return defaultfFlepath;
            string _filepath = filepath.ToString();
            if (string.IsNullOrEmpty(_filepath)) return defaultfFlepath;

            return _filepath;
        }
        #endregion

        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindOption(string selectItem)
        {
            string memberoption = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(Eyousoft_yhq.Model.MemberOption)), selectItem.ToString(), false,"","");
            return memberoption;
        }
        #endregion
        #region 绑定省市区县镇乡
        /// <summary>
        /// 绑定省
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <returns></returns>
        public string BindProvice(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 1 });
            query.Append("<option value='0' >-请选择-</option>");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].code.ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                }
            }
            return query.ToString();
        }
        /// <summary>
        /// 绑定城市
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <param name="proviceid">父级id</param>
        /// <returns></returns>
        public string BindCity(string selectItem, string proviceid)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            if (proviceid != "0")
            {
                var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 2, parentId = proviceid });

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].code.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                    }
                }
            }
            return query.ToString();
        }
        /// <summary>
        /// 绑定县区
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <param name="cityid">父级id</param>
        /// <returns></returns>
        public string BindArea(string selectItem, string cityid)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            if (cityid != "0")
            {
                var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 3, parentId = cityid });

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].code.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                    }
                }
            }
            return query.ToString();
        }
        /// <summary>
        /// 绑定乡镇街道
        /// </summary>
        /// <param name="selectItem">选中项</param>
        /// <param name="areaid">父级id</param>
        /// <returns></returns>
        public string BindStreet(string selectItem, string areaid)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            if (areaid != "0")
            {
                var list = new Eyousoft_yhq.BLL.User().GetProList(new Eyousoft_yhq.Model.Pro_City_Area_StreetSer { level = 4, parentId = areaid });

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].code.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].code, list[i].name);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", list[i].code, list[i].name);

                    }
                }
            }
            return query.ToString();
        }
        #endregion
    }
}
