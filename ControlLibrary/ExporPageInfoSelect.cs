using System;
using System.Web.UI;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Collections;

namespace Adpost.Common.ExporPage
{
    /// <summary>
    /// 分页自定义控件
    /// </summary>
    [DefaultProperty("Text"),
    ToolboxData("<{0}:ExporPageInfoSelect runat=server></{0}:ExporPageInfoSelect>")]
    public class ExporPageInfoSelect : ExporPaging
    {
        private string _AllPageCssClass = "hong18";
        private Hashtable _EventSelectHt = new Hashtable();  //select控件上的事件
        private Hashtable _EventLinkHt = new Hashtable();  //分页链接上的事件
        private HrefTypeEnum _HrefType = HrefTypeEnum.UrlHref;   //跳转的类型
        private PageStyleTypeEnum _pageStyleType = PageStyleTypeEnum.Select;
        private int _pageLinkCount = 10;
        private bool _isInitCssStyle = true;
        private bool _isInitJs = true;
        private int _startEndPageCount = 2;
        private ButtonColor _buttoncolorstyle = ButtonColor.Blue;

        #region 定义属性
        /// <summary>
        /// 按钮的颜色(适用与PageStyleTypeEnum!=Select的样式) 默认为Blue
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(ButtonColor.Blue)]
        public virtual ButtonColor ButtonColorStyle
        {
            get { return this._buttoncolorstyle; }
            set { this._buttoncolorstyle = value; }
        }
        /// <summary>
        /// 判断是否输出js,默认为输出
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(true)]
        public virtual bool IsInitJs
        {
            get
            {
                return _isInitJs;
            }

            set
            {
                _isInitJs = value;
            }
        }

        /// <summary>
        /// 判断是否输出css样式,默认为输出
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(true)]
        public virtual bool IsInitCssStyle
        {
            get
            {
                return _isInitCssStyle;
            }

            set
            {
                _isInitCssStyle = value;
            }
        }

        /// <summary>
        /// 首尾的分页数字的个数(暂时只对PageStyleType=PageStyleTypeEnum.NewButton类型的设置有作用) 默认为2
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(2)]
        public virtual int PageLinkStartEndCount
        {
            get
            {
                return _startEndPageCount;
            }

            set
            {
                _startEndPageCount = value;
            }
        }

        /// <summary>
        /// 设置分页显示的链接个数(暂时只对PageStyleType=PageStyleTypeEnum.NewButton类型的设置有作用) 默认为10
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(10)]
        public virtual int PageLinkCount
        {
            get
            {
                return _pageLinkCount;
            }

            set
            {
                _pageLinkCount = value;
            }
        }

        /// <summary>
        /// 分页控件的样式,默认为select形式的
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(PageStyleTypeEnum.Select)]
        public virtual PageStyleTypeEnum PageStyleType
        {
            get
            {
                return _pageStyleType;
            }

            set
            {
                _pageStyleType = value;
            }
        }

        /// <summary>
        /// "总的页数" 显示的CSS样式  默认为红色的hong18样式名
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue("hong18")]
        public virtual string AllPageCssClass
        {
            get
            {
                return _AllPageCssClass;
            }

            set
            {
                _AllPageCssClass = value;
            }
        }

        /// <summary>
        /// 链接跳转的类型(0:url页面跳转 1:通过js的ajax来页面跳转) 默认为0
        /// 当为1的时候可以获得当前链接上的value值,value即为当前链接上的page数值
        /// </summary>
        [Bindable(true), Category("Behavior"), DefaultValue(HrefTypeEnum.UrlHref)]
        public virtual HrefTypeEnum HrefType
        {
            get
            {
                return _HrefType;
            }

            set
            {
                _HrefType = value;
            }
        }
        #endregion

        /// <summary>
        /// 设置控件的事件类型和事件函数
        /// </summary>
        /// <param name="keyEventName">事件类型(如:onclick, onchange)</param>
        /// <param name="valueFunctionName">事件调用的函数</param>
        /// <param name="ControlType">要添加事件的控件类型(Type=0:select控件 1:链接上添加事件)</param>
        public void AttributesEventAdd(string keyEventName, string valueFunctionName, int ControlType)
        {
            switch (ControlType)
            {
                case 0:
                    if (!_EventSelectHt.ContainsKey(keyEventName))
                        _EventSelectHt.Add(keyEventName, valueFunctionName);
                    break;
                case 1:
                    if (!_EventLinkHt.ContainsKey(keyEventName))
                        _EventLinkHt.Add(keyEventName, valueFunctionName);
                    break;
            }
        }


        /// <summary>
        /// 注册要生成的js
        /// </summary>
        private string RegisterJs()
        {
            //输出默认的js函数
            StringBuilder strJs = new StringBuilder();
            if (IsInitJs && HrefType == HrefTypeEnum.UrlHref && PageStyleType == PageStyleTypeEnum.Select)  //要初始化js，翻页通过urlhref跳转,并且是select样式的分页
            {   //URL方式跳转
                strJs.Append("<script lanuage='javascript' type='text/javascript'>");
                strJs.Append("function ExporPageInfoSelect_Change(obj){");
                //string url = PageLinkURL + BuildUrlString(UrlParams);
                string url = "";
                if (PageLinkURL == "?")
                    url = "?" + BuildUrlString(UrlParams);
                else
                    url = PageLinkURL;

                strJs.AppendFormat("window.location.href='{0}Page=' + obj.value;", url);
                strJs.Append("}</script>");

                //初始化默认的事件
                //AttributesEventAdd("onchange", "ExporPageInfoSelect_Change(this)", 0);
            }
            else if (IsInitJs && HrefType == HrefTypeEnum.JsHref)
            {
                strJs.Append("<script lanuage='javascript' type='text/javascript'>");
                strJs.Append("var exporpage = { getgotopage : function(obj){var gotopage = $(obj).attr('gotoPage'); if(gotopage==undefined)gotopage = obj.value; return gotopage;} }");
                strJs.Append("</script>");
            }
            return strJs.ToString();
        }

        /// <summary>
        /// 注册要生成的css样式
        /// </summary>
        private string RegisterCssStyle()
        {
            //输出默认的css样式
            StringBuilder strCss = new StringBuilder();
            if (IsInitCssStyle)
            {
                strCss.Append("<style>");
                strCss.Append(".hong18 {color: #bc2931;}");
                strCss.Append("</style>");
                //if (PageStyleType != PageStyleTypeEnum.Select)  //为新的样式
                //{
                //    switch (this._buttoncolorstyle)
                //    {
                //        case ButtonColor.Blue:
                //            cssPath =  "/ExporPageResources/Css/BlueButton.css";
                //            break;
                //        case ButtonColor.Green:
                //            cssPath = "/ExporPageResources/Css/GreenButton.css";
                //            break;
                //    }

                //}
                //strCss.AppendFormat("<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\" />", cssPath);
            }
            return strCss.ToString();
        }

        protected override void OnInit(EventArgs e)
        {
            base.IsInitBaseCssStyle = false;
            base.OnInit(e);
        }

        private bool _selfVisible = true;

        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = true;
                _selfVisible = value;
            }
        }

        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            string recordCountScript = string.Format(@"<script type=""text/javascript"">
//<![CDATA[
var pagingRecordCount={0};//]]>
</script>
", intRecordCount.ToString());

            if (!_selfVisible)
            {
                output.Write(recordCountScript);
                return;
            }

            //InitCssStyle();
            #region 定义变量初始化
            StringBuilder tmpReturnValue = new StringBuilder();
            int intPageCount = 0;   //总的页数            
            StringBuilder strJs = new StringBuilder(); //链接上的事件
            if (HrefType == HrefTypeEnum.JsHref)
            {
                //构造链接上的事件
                if (_EventLinkHt != null && _EventLinkHt.Count > 0)
                {
                    foreach (string key in _EventLinkHt.Keys)
                    {
                        strJs.AppendFormat(" {0}='{1}' ", key, _EventLinkHt[key]);
                    }
                }
            }

            #region 修改后的代码
            //if (intRecordCount == 0)
            //    intRecordCount = 1;
            if (!IsUrlRewrite)
            {
                PageLinkURL = PageLinkURL + BuildUrlString(UrlParams);
            }
            if (intRecordCount > 0)
            {
                if (intRecordCount % intPageSize == 0)
                {
                    intPageCount = Convert.ToInt32(intRecordCount / intPageSize);
                }
                else
                {
                    intPageCount = Convert.ToInt32(intRecordCount / intPageSize) + 1;
                }
            }
            #endregion

            if (intPageCount == 0)
                intPageCount = 1;

            if (CurrencyPage <= 0)  //若当前页面为0或小于0,则默认为在当前页
                CurrencyPage = 1;
            else if (CurrencyPage > intPageCount)
                CurrencyPage = intPageCount;
            #endregion

            //为选择下拉宽的样式
            if (PageStyleType == PageStyleTypeEnum.Select)
            {
                tmpReturnValue.AppendFormat("<span>每页显示{0}条 共{1}条信息，</span>", intPageSize, intRecordCount);
                tmpReturnValue.AppendFormat("第<span class='{0}'><strong>{1}</strong></span>/<span class='{2}'><strong>{3}</strong></span>页&nbsp;&nbsp;|&nbsp;&nbsp;", CurrencyPageCssClass, CurrencyPage, AllPageCssClass, intPageCount);
                #region 构造下拉页数
                tmpReturnValue.Append("<select class='inputselect' onchange='ExporPageInfoSelect_Change(this)'");

                //构造select的事件
                if (_EventSelectHt != null && _EventSelectHt.Count > 0)
                {
                    foreach (string key in _EventSelectHt.Keys)
                    {
                        tmpReturnValue.AppendFormat(" {0}='{1}' ", key, _EventSelectHt[key]);
                    }
                }

                tmpReturnValue.Append(">");
                for (int i = 1; i <= intPageCount; i++)
                {
                    if (CurrencyPage == i)
                        tmpReturnValue.AppendFormat("<option value='{0}' selected='selected'>{0}</option>", i);
                    else
                        tmpReturnValue.AppendFormat("<option value='{0}'>{0}</option>", i);
                }
                tmpReturnValue.Append("</select>&nbsp;&nbsp;");
                #endregion

                #region 构造链接
                if (intPageCount == 1)
                {
                    tmpReturnValue.Append("首页 上一页 下一页 尾页");
                }
                else
                {
                    switch (Convert.ToInt32(HrefType))
                    {
                        case 0: //url的href跳转
                            //首页
                            tmpReturnValue.AppendFormat("<span class='{0}'><a href='{1}Page=1'>首页</a></span>", LinkCssClass, PageLinkURL);

                            //上一页
                            if (CurrencyPage == 1)  //当前页为第1页
                            {
                                if (intPageCount > 1)
                                    tmpReturnValue.AppendFormat("<span class='{0}'> 上一页 <a href='{1}Page=2'>下一页</a> </span>", LinkCssClass, PageLinkURL);
                                else if (intPageCount == 1)
                                    tmpReturnValue.AppendFormat("<span class='{0}'> 上一页 下一页 </span>", LinkCssClass);
                            }
                            else if (CurrencyPage == intPageCount)  //当前页为最后1页
                                tmpReturnValue.AppendFormat("<span class='{0}'> <a href='{1}Page={2}'>上一页</a> 下一页 </span>", LinkCssClass, PageLinkURL, intPageCount - 1);
                            else
                                tmpReturnValue.AppendFormat(" <span class='{0}'><a href='{1}Page={2}'>上一页</a> <a href='{1}Page={3}'>下一页</a></span> ", LinkCssClass, PageLinkURL, CurrencyPage - 1, CurrencyPage + 1);

                            tmpReturnValue.AppendFormat("<span class='{0}'><a href='{1}Page={2}'>尾页</a></span>", LinkCssClass, PageLinkURL, intPageCount);
                            break;
                        case 1:   //通过js中的ajax跳转      
                            //首页
                            tmpReturnValue.AppendFormat("<span class='{0}' gotoPage='1' {1}><a href='javascript:void(0);'>首页</a></span>", LinkCssClass, strJs);

                            //上一页
                            if (CurrencyPage == 1)  //当前页为第1页
                                tmpReturnValue.AppendFormat("<span class='{0}'> 上一页 <span gotoPage='2' {1}><a href='javascript:void(0);'>下一页</a></span> </span>", LinkCssClass, strJs);
                            else if (CurrencyPage == intPageCount)  //当前页为最后1页
                                tmpReturnValue.AppendFormat("<span class='{0}'> <span gotoPage='{2}' {1}><a href='javascript:void(0);'>上一页</a></span> 下一页 </span>", LinkCssClass, strJs, intPageCount - 1);
                            else
                                tmpReturnValue.AppendFormat(" <span class='{0}' gotoPage='{2}' {1}><a href='javascript:void(0);'>上一页</a></span> <span gotoPage={3} {1}><a href='javascript:void(0);'>下一页</a></span> ", LinkCssClass, strJs, CurrencyPage - 1, CurrencyPage + 1);

                            tmpReturnValue.AppendFormat("<span class='{0}' gotoPage='{2}' {1}><a href='javascript:void(0);'>尾页</a></span>", LinkCssClass, strJs, intPageCount);
                            break;
                    }
                }
                #endregion
            }
            else  //为新的样式
            {
                tmpReturnValue.Append("<div class='diggPage'>");

                //为最简单的分页样式
                if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                {
                    //构造页数前面的统计
                    tmpReturnValue.AppendFormat("<span>每页显示{0}条 共{1}条信息，共{2}页</span>", intPageSize, intRecordCount, intPageCount);
                }

                #region 构造每页的链接
                //上一页
                if (CurrencyPage == 1)  //当前页为第1页
                {
                    if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                    {

                        tmpReturnValue.Append("<span class='disabled'> 上一页 </span>"); //上一页
                    }


                    //中间页数的数字---------begin------                    
                    tmpReturnValue.Append(GetPageNumLink(intPageCount, strJs.ToString()));
                    //中间页数的数字----------end-----

                    if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                    {
                        if (intPageCount > 1)
                        {
                            if (HrefType == HrefTypeEnum.UrlHref)
                                tmpReturnValue.AppendFormat("<a href='{0}'> 下一页 </a>", BuildUrlStr(PageLinkURL, "2")); //下一页
                            else if (HrefType == HrefTypeEnum.JsHref)
                                tmpReturnValue.AppendFormat("<span gotoPage='2' {0}><a href='javascript:void(0);'> 下一页 </a></span>", strJs); //下一页
                        }
                        else if (intPageCount == 1)
                            tmpReturnValue.Append("<span class='disabled'> 下一页 </span>"); //下一页
                    }
                }
                else if (CurrencyPage == intPageCount)  //当前页为最后1页
                {
                    if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                    {
                        if (HrefType == HrefTypeEnum.UrlHref)
                            tmpReturnValue.AppendFormat("<a href='{0}'> 上一页 </a>", BuildUrlStr(PageLinkURL, Convert.ToString(CurrencyPage - 1))); //上一页
                        else if (HrefType == HrefTypeEnum.JsHref)
                            tmpReturnValue.AppendFormat("<span gotoPage='{0}' {1}><a href='javascript:void(0);'> 上一页 </a></span>", CurrencyPage - 1, strJs);

                    }

                    //中间页数的数字---------begin------                    
                    tmpReturnValue.Append(GetPageNumLink(intPageCount, strJs.ToString()));
                    //中间页数的数字----------end-----    

                    if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                    {
                        tmpReturnValue.Append("<span class='disabled'> 下一页 </span>"); //下一页
                    }
                }
                else  //当前页为中间页
                {
                    if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                    {
                        if (HrefType == HrefTypeEnum.UrlHref)
                            tmpReturnValue.AppendFormat("<a href='{0}'> 上一页 </a>", BuildUrlStr(PageLinkURL, Convert.ToString(CurrencyPage - 1))); //上一页
                        else if (HrefType == HrefTypeEnum.JsHref)
                            tmpReturnValue.AppendFormat("<span gotoPage='{0}' {1}><a href='javascript:void(0);'> 上一页 </a></span>", CurrencyPage - 1, strJs);

                    }

                    //中间页数的数字---------begin------                    
                    tmpReturnValue.Append(GetPageNumLink(intPageCount, strJs.ToString()));
                    //中间页数的数字----------end-----      

                    if (PageStyleType != PageStyleTypeEnum.MostEasyNewButtonStyle)
                    {
                        if (HrefType == HrefTypeEnum.UrlHref)
                            tmpReturnValue.AppendFormat("<a href='{0}'> 下一页 </a>", BuildUrlStr(PageLinkURL, Convert.ToString(CurrencyPage + 1))); //下一页
                        else if (HrefType == HrefTypeEnum.JsHref)
                            tmpReturnValue.AppendFormat("<span gotoPage='{0}' {1}><a href='javascript:void(0);'> 下一页 </a></span>", CurrencyPage + 1, strJs);
                    }
                }
                #endregion

                tmpReturnValue.Append("</div>");
            }

            string strJsOut = RegisterJs();
            string strCss = RegisterCssStyle();

            output.Write(recordCountScript + strJsOut + strCss + tmpReturnValue.ToString());
        }

        #region 输出中间的分页数字
        /// <summary>
        /// 输出每一个分页的数字
        /// </summary>
        /// <param name="pageIndex">页数索引</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="hrefType">链接跳转的类型</param>
        /// <param name="strJs">通过js分页的时候的js事件</param>
        /// <param name="pageLinkURL">网页url链接</param>
        /// <returns></returns>
        private string GetOnePageNumLink(int pageIndex, int currentPage, HrefTypeEnum hrefType, string strJs, string pageLinkURL)
        {
            StringBuilder tmpReturnValue = new StringBuilder();
            if (pageIndex == currentPage)
            {
                tmpReturnValue.AppendFormat("<span class='current'>{0}</span>", pageIndex);   //当前页
            }
            else
            {
                //输出中间的每一个数字
                if (hrefType == HrefTypeEnum.UrlHref)
                    tmpReturnValue.AppendFormat("<a href='{0}'>{1}</a>", BuildUrlStr(pageLinkURL, Convert.ToString(pageIndex)), pageIndex);
                else if (hrefType == HrefTypeEnum.JsHref)
                    tmpReturnValue.AppendFormat("<span gotoPage='{0}' {1}><a href='javascript:void(0);'>{0}</a></span>", pageIndex, strJs);
            }
            return tmpReturnValue.ToString();
        }
        /// <summary>
        /// txb
        /// </summary>
        /// <param name="url"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        private string BuildUrlStr(string url, string page)
        {
            if (IsUrlRewrite)
            {
                return url.Replace(Placeholder, page);
            }
            else
            {
                return PageLinkURL + "Page=" + Convert.ToString((int.Parse(page)));
            }
        }

        /// <summary>
        /// 输出中间的分页数字
        /// </summary>
        /// <param name="intPageCount">总的分页数</param>
        /// <param name="strJs">通过js分页的时候的js事件</param>
        /// <returns></returns>
        private string GetPageNumLink(int intPageCount, string strJs)
        {
            StringBuilder tmpReturnValue = new StringBuilder();
            int pageIndex = 1;   //页索引
            int startEndPageCount = PageLinkStartEndCount;   //首尾的分页数字的个数
            int middlePageCount = PageLinkCount - PageLinkStartEndCount * 2;  //中间的分页数字的个数(不能小于3)
            if (middlePageCount < 3)
                return "PageLinkCount属性 - PageLinkStartEndCount*2属性不能小于3！";
            if (intPageCount <= PageLinkCount)   //直接输出每页
                for (pageIndex = 1; pageIndex <= intPageCount; pageIndex++)
                    tmpReturnValue.AppendFormat(GetOnePageNumLink(pageIndex, CurrencyPage, HrefType, strJs, PageLinkURL));
            else if (intPageCount > PageLinkCount)
            {
                //判断是否要输出前面的...
                bool isHasStartPoint = false;
                //判断是否要输出后面的...
                bool isHasEndPoint = false;
                if (CurrencyPage >= startEndPageCount + middlePageCount)
                    isHasStartPoint = true;
                if (CurrencyPage <= intPageCount - (startEndPageCount + middlePageCount) + 1)
                    isHasEndPoint = true;
                if (!isHasStartPoint && !isHasEndPoint && intPageCount > PageLinkCount)
                    isHasEndPoint = true;

                //输出开始的页数
                for (pageIndex = 1; pageIndex <= startEndPageCount; pageIndex++)
                    tmpReturnValue.AppendFormat(GetOnePageNumLink(pageIndex, CurrencyPage, HrefType, strJs, PageLinkURL));

                //输出开始的...
                if (isHasStartPoint)   //输出开始的...
                {
                    tmpReturnValue.AppendFormat("...");

                    //判断是否要输出结束的...,并输出中间的分页页数
                    if (isHasEndPoint)  //输出结束的...      
                    {
                        pageIndex = CurrencyPage - middlePageCount / 2;
                        if (middlePageCount % 2 == 0)
                            pageIndex += 1;
                        int end = CurrencyPage + middlePageCount / 2;
                        for (; pageIndex <= end; pageIndex++)
                            tmpReturnValue.AppendFormat(GetOnePageNumLink(pageIndex, CurrencyPage, HrefType, strJs, PageLinkURL));
                    }
                    else  //不输出结束的...
                    {
                        pageIndex = intPageCount - (middlePageCount + startEndPageCount - 1);
                        int end = intPageCount - startEndPageCount;
                        for (; pageIndex <= end; pageIndex++)
                            tmpReturnValue.AppendFormat(GetOnePageNumLink(pageIndex, CurrencyPage, HrefType, strJs, PageLinkURL));
                    }
                }
                else  //不输出开始的...
                {
                    //输出中间的分页页数
                    int end = startEndPageCount + middlePageCount;
                    for (; pageIndex <= end; pageIndex++)
                    {
                        tmpReturnValue.AppendFormat(GetOnePageNumLink(pageIndex, CurrencyPage, HrefType, strJs, PageLinkURL));
                    }
                }

                //输出结束的...
                if (isHasEndPoint)
                {
                    tmpReturnValue.AppendFormat("...");
                }

                //输出最后的页数
                for (pageIndex = intPageCount - (startEndPageCount - 1); pageIndex <= intPageCount; pageIndex++)
                    tmpReturnValue.AppendFormat(GetOnePageNumLink(pageIndex, CurrencyPage, HrefType, strJs, PageLinkURL));
            }

            return tmpReturnValue.ToString();
        }
        #endregion

        #region 构造填写数字并跳转的input

        /// <summary>
        /// 构造填写数字并跳转的input
        /// </summary>
        /// <param name="intPageCount">总页数</param>
        /// <returns></returns>
        private string GetInput(int intPageCount)
        {
            StringBuilder strInput = new StringBuilder();
            StringBuilder strJs = new StringBuilder();

            #region 构造js

            strJs.Append("<script type=\"text/javascript\" >");
            strJs.Append("function GoToPageNum(){");
            strJs.Append("var obj = document.getElementById('txtIndex');");
            strJs.Append("var num = 0;");
            strJs.Append("if(obj != null) num = obj.value;");
            strJs.Append("var r=/^[0-9]*[1-9][0-9]*$/;");
            strJs.Append("if(!r.test(num) || obj.value <= 0) return;");
            strJs.AppendFormat("var pageNumber = {0};", intPageCount);
            strJs.AppendFormat("if(num<=0||num>pageNumber||num=={0})return;", CurrencyPage);
            strJs.AppendFormat("window.location.href=\"{0}Page=\" + num;", PageLinkURL);
            strJs.Append("}");
            strJs.Append("function CheckKeyDown(){if(event.keyCode==13){GoToPageNum();event.returnValue=false;return false;}}</script>");
            strJs.Append("</script>");

            #endregion

            strInput.Append(strJs.ToString());
            strInput.Append("<span>跳转至<input type=\"text\" id=\"txtIndex\" size=\"3\"");
            strInput.Append(" onkeydown='CheckKeyDown();' onchange='GoToPageNum();' style='height:20px; width:35px;'");
            strInput.AppendFormat(" value=\"{0}\" />页</span>", CurrencyPage);

            return strInput.ToString();
        }

        #endregion
    }

    #region 定义枚举型
    /// <summary>
    /// 链接跳转的类型(0:url页面跳转 1:通过js的ajax来页面跳转) 默认为0
    /// 当为1的时候可以获得当前链接上的value值,value即为当前链接上的page数值
    /// </summary>
    public enum HrefTypeEnum
    {
        /// <summary>
        /// 0:url页面跳转
        /// </summary>
        UrlHref = 0,

        /// <summary>
        /// 1:通过js的ajax来页面跳转,为1的时候可以获得当前链接上的value值,value即为当前链接上的page数值
        /// </summary>
        JsHref = 1
    }

    /// <summary>
    /// 分页样式类型枚举
    /// </summary>
    public enum PageStyleTypeEnum
    {
        /// <summary>
        /// 有下拉框的样式
        /// </summary>
        Select,

        /// <summary>
        /// 新的按钮样式
        /// </summary>
        NewButton,

        /// <summary>
        /// 最简单的新按钮样式分页（无上、下页，无每页多少的描述信息）
        /// </summary>
        MostEasyNewButtonStyle,

        /// <summary>
        /// 最原始的分页样式
        /// </summary>
        OldStyle,

        /// <summary>
        /// 最原始的分页中无每个数字分页的样式
        /// </summary>
        OldNoEveryPageStyle,

        /// <summary>
        /// MQ查找好友样式
        /// </summary>
        MQSeachFriendStyle
    }

    /// <summary>
    /// 按钮的颜色枚举(适用与PageStyleTypeEnum!=Select的样式)
    /// </summary>
    public enum ButtonColor
    {
        /// <summary>
        /// 蓝色
        /// </summary>
        Blue,

        /// <summary>
        /// 绿色
        /// </summary>
        Green
    }
    #endregion
}
