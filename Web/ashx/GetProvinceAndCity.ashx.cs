using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EyouSoft.Common;
using System.Text;

namespace Web.Ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    /// <summary>
    /// 页面：DOM
    /// </summary>
    /// 创建人：刘飞
    /// 创建时间：2012-11-20
    /// 说明：处理国家，省份，城市，县区
    public class GetProvinceAndCity : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string getType = Utils.GetQueryStringValue("get");
            StringBuilder sb = new StringBuilder();
            int pID = Utils.GetInt(Utils.GetQueryStringValue("pid"));
            int cID = Utils.GetInt(Utils.GetQueryStringValue("cid"));
            switch (getType)
            {
                case "p":
                    Eyousoft_yhq.BLL.AreaInfo bllAreaInfo = new Eyousoft_yhq.BLL.AreaInfo();
                    IList<Eyousoft_yhq.Model.MSysProvince> pList = bllAreaInfo.GetSysProvinceList(0, new Eyousoft_yhq.Model.MSysProvince { });

                    if (pList != null && pList.Count > 0)
                    {
                        sb.Append("{\"list\":[");
                        for (int i = 0; i < pList.Count; i++)
                        {
                            sb.Append("{\"id\":\"" + pList[i].ID.ToString() + "\",\"name\":\"" + pList[i].Name + "\"},");
                        }
                        if (sb.Length > 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append("]}");
                    }
                    else
                    {
                        sb.Append("{\"list\":[]}");
                    }

                    break;
                case "c":
                    Eyousoft_yhq.BLL.AreaInfo bll = new Eyousoft_yhq.BLL.AreaInfo();
                    IList<Eyousoft_yhq.Model.MSysCity> cList = bll.GetSysCityList(0, new Eyousoft_yhq.Model.MSysCity { ProvinceId = pID });
                    if (cList != null && cList.Count > 0)
                    {
                        sb.Append("{\"list\":[");
                        for (int i = 0; i < cList.Count; i++)
                        {
                            sb.Append("{\"id\":\"" + cList[i].Id.ToString() + "\",\"name\":\"" + cList[i].Name + "\"},");
                        }
                        if (sb.Length > 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append("]}");
                    }
                    else
                    {
                        sb.Append("{\"list\":[]}");
                    }
                    break;
                case "x":
                    Eyousoft_yhq.BLL.AreaInfo bllarea = new Eyousoft_yhq.BLL.AreaInfo();
                    IList<Eyousoft_yhq.Model.MSysDistrict> xlist = bllarea.GetSysDistrictList(0, new Eyousoft_yhq.Model.MSysDistrict { CityId = cID });
                    if (xlist != null && xlist.Count > 0)
                    {
                        sb.Append("{\"list\":[");
                        for (int i = 0; i < xlist.Count; i++)
                        {
                            sb.Append("{\"id\":\"" + xlist[i].Id.ToString() + "\",\"name\":\"" + xlist[i].Name + "\"},");
                        }
                        if (sb.Length > 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.Append("]}");
                    }
                    else
                    {
                        sb.Append("{\"list\":[]}");
                    }
                    break;
            }

            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
