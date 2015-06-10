using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.IO;
using System.Text;

namespace Eyousoft_yhq.Web.printPage
{
    public partial class RoutePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DownWord();
        }



        #region Word 下载

        protected void DownWord()
        {
            string wordTemplate = "";
            var model = new Eyousoft_yhq.BLL.Product().GetModel(Utils.GetQueryStringValue("routeid"));
            if (model != null)
            {
                #region 文本内容
                wordTemplate = @"
                <html>
                <head>
                    <title>打印预览</title>
                    <style type=""text/css"">
                    body {{color:#000000;font-size:12px;font-family:""宋体"";background:#fff; margin:0px;}}
                    img {{border: thin none;}}
                    table {{border-collapse:collapse;width:790px;}}
                    td {{font-size: 12px; line-height:18px;color: #000000;  }}	
                    .headertitle {{font-family:""黑体""; font-size:25px; line-height:120%; font-weight:bold;}}
                    </style>
                </head>
                <body>
                    <div id=""divAllHtml"" style=""width: 760px; margin: 0 auto;"">
        <div id=""divContent"">
            <table width=""696"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"">
                <tr>
                    <td height=""40"" align=""center"">
                        <b class=""font24"">
                            {0}</b>
                    </td>
                </tr>
            </table>
            <table width=""696"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" runat=""server""
                id=""TPlanFeature"" class=""borderline_2"">
                <tr>
                    <td height=""30"" class=""small_title"">
                        <b class=""font16"">产品介绍</b>
                    </td>
                </tr>
                <tr>
                    <td class=""td_text"">
                        {1}
                    </td>
                </tr>
            </table>
            <table width=""696"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center"" id=""TAll""
                runat=""server"" class=""borderline_2"">
                <tbody>
                    <tr>
                        <td height=""30"" class=""small_title"">
                            <b class=""font16"">参考行程</b>
                        </td>
                    </tr>
                    <tr>
                        <td class=""td_text"">
                            {2}
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id=""TOption"" runat=""server"">
                <table width=""696"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center"" class=""list_2"">
                    <tbody>
                        <tr>
                            <td height=""30"" class=""small_title"">
                                <b class=""font16"">出团须知</b>
                            </td>
                        </tr>
                        <tr>
                            <td class=""td_text"">
                               {3}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div runat=""server"" id=""TPlanService"">
                <table width=""696"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" runat=""server""
                    id=""TService"" class=""borderline_2"">
                    <tr>
                        <td height=""30"" class=""small_title"">
                            <b class=""font16"">价格标准</b>
                        </td>
                    </tr>
                    <tr>
                        <td class=""td_text borderline_2"">
                           市场价格：{4}，会员价格：{5}
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
                </body>
                </html>";
                #endregion

                HttpContext.Current.Response.Clear();
                string saveFileName = HttpUtility.UrlEncode(DateTime.Now.ToString("yyyyMMddhhssffff") + ".doc", System.Text.Encoding.Default);
                System.IO.StringWriter tw = new System.IO.StringWriter();
               
                tw.Write(string.Format(wordTemplate, model.ProductName, model.ProductDis, model.TourDis, model.SendTourKnow, model.MarketPrice.ToString("C0"), model.AppPrice.ToString("C0")).ToString());
                WriteFile(tw.ToString(), saveFileName);
                FileInfo Inf = new FileInfo(Server.MapPath(@"TemFile/" + saveFileName));
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + saveFileName);
                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
                HttpContext.Current.Response.ContentType = "application/ms-word ";
                Page.EnableViewState = false;

                HttpContext.Current.Response.WriteFile(Inf.FullName);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
                
            }
        }

        /// <summary>
        /// 文件创建
        /// </summary>
        /// <param name="strMemo"></param>
        /// <param name="FileName"></param>
        private void WriteFile(string strMemo, string FileName)
        {
            if (!Directory.Exists(Server.MapPath(@"TemFile\")))
            {
                Directory.CreateDirectory(Server.MapPath(@"TemFile\"));
            }

            string filenameUrl = Server.MapPath(@"TemFile/" + FileName);
            StreamWriter sr = null;
            try
            {
                if (!File.Exists(filenameUrl))
                {
                   sr= File.CreateText(filenameUrl);
                   if (sr != null)
                   { sr.Close(); }
                    sr =new StreamWriter(filenameUrl,false,System.Text.Encoding.GetEncoding("GB2312"));
                    
                }
                else
                {
                   sr= File.AppendText(filenameUrl);
                   if (sr != null)
                   { sr.Close(); }
                    sr = new StreamWriter(filenameUrl, false, System.Text.Encoding.GetEncoding("GB2312"));
                }
                sr.WriteLine(strMemo);
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        #endregion


    }
}
