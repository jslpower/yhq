using System;
using System.Text;
namespace EyouSoft.Common.Function
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class MessageBox
	{
		public MessageBox()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 函数 过程
		/// <summary>
		/// 打开模式窗体有返回值变量
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="VarName">返回变量名</param>
		/// <param name="OpenUrl">打开窗体的地址</param>
		/// <param name="WindowName">窗体命名</param>
		/// <param name="WindowArg">窗体参数</param>
		public static void showModalDialog(System.Web.UI.Page page,string FunctionName,string VarName,string OpenUrl,string WindowArg)
		{
			StringBuilder str = new StringBuilder();
			str.Append("<script language=\"javascript\">\n");
			str.Append("///<!--	弹出模式窗口	-->\n");
			str.Append("function " + FunctionName + "(){\n");
			str.Append("var " + VarName + " = window.showModalDialog(\"" + OpenUrl + "\",window,\"" + WindowArg + "\");\n");
			str.Append("}\n");
			str.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ModalDialog")){
				page.ClientScript.RegisterStartupScript(typeof(string),"ModalDialog",str.ToString());
			}
		}
		/// <summary>
		/// 打开模式窗体有返回值变量
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="FunctionName">过程名称</param>
		/// <param name="OpenUrl">打开窗体地址</param>
		/// <param name="WindowArg">窗体参数</param>
		public static void showNoNameModalDialog(System.Web.UI.Page page,string FunctionName,string OpenUrl,string WindowArg)
		{
			StringBuilder str = new StringBuilder();
			str.Append("<script language=\"javascript\">\n");
			str.Append("///<!--	弹出模式窗口	-->\n");
			str.Append("function " + FunctionName + "(){\n");
			str.Append("window.showModalDialog(\"" + OpenUrl + "\",window,\"" + WindowArg + "\");\n");
			str.Append("}\n");
			str.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("NoNameModalDialog"))
			{
				page.ClientScript.RegisterStartupScript(typeof(string),"NoNameModalDialog",str.ToString());
			}
		}
		/// <summary>
		/// 打开模式窗体
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="FunctionName">过程名称</param>
		public static void showNoNameModalDialog(System.Web.UI.Page page,string FunctionName)
		{
			StringBuilder str = new StringBuilder();
			str.Append("<script language=\"javascript\">\n");
			str.Append("///<!--	弹出模式窗口	-->\n");
			str.Append("function " + FunctionName + "(OpenUrl,WindowArg){\n");
			str.Append("var OpenUrl=OpenUrl;\nvar WindowArg = WindowArg;\n");
			str.Append("window.showModalDialog(OpenUrl,window,WindowArg);\n");
			str.Append("}\n");
			str.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("NoNameModalDialog"))
			{
				page.ClientScript.RegisterStartupScript(typeof(string),"NoNameModalDialog",str.ToString());
			}
		}
		/// <summary>
		/// 打开新窗口
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="FunctionName">过程名称</param>
		public static void ShowOpenWindowJS(System.Web.UI.Page page,string FunctionName)
		{
			StringBuilder str = new StringBuilder();
			str.Append("<script language=\"javascript\">\n");
			if(FunctionName != "")
			{
				str.Append("function " + FunctionName + "(theURL,winName,features,iWidth,iHeight){\n");
			}
			else
			{
				str.Append("function OpenNewWindow(theURL,winName,features,iWidth,iHeight){\n");
			}
			str.Append("var  iTop=(window.screen.height-iHeight)/2;\nvar  iLeft=(window.screen.width-iWidth)/2;\n");
			str.Append("if(features != \"\"){\n");
			str.Append("window.open(theURL,winName,features + \",width=\" + iWidth + \",height=\" + iHeight + \",top=\" + iTop + \",left=\" + iLeft + \"\");\n");
			str.Append("}else{\n");
			str.Append("window.open(theURL,winName,\"width=\" + iWidth + \",height=\" + iHeight + \",top=\" + iTop + \",left=\" + iLeft + \"\");\n");
			str.Append("}\n");
			str.Append("}\n");
			str.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("NewWindowOpenJS"))
			{
				page.ClientScript.RegisterStartupScript(typeof(string),"NewWindowOpenJS",str.ToString());
			}
		}
//		/// <summary>
//		/// 写javascript 代码
//		/// </summary>
//		/// <param name="page">页面一般是 this</param>
//		/// <param name="script">javascript 代码</param>
//		public static void ResponseScript(System.Web.UI.Page page, string script)
//		{
//			Random rnd = new Random();
//			int intEndRndNumber = rnd.Next(1,60);
//			string tmpStr = DateTime.Now.ToString("yyyyMMddHHmmssffff");
//			if(!page.ClientScript.IsStartupScriptRegistered("script" + tmpStr + "Block" + intEndRndNumber.ToString()))
//			{
//				page.ClientScript.RegisterStartupScript(typeof(string),"script" + tmpStr.ToString() + "Block" + intEndRndNumber.ToString(), "<script language='javascript'>" + script + "</script>");
//			}
//			page.ClientScript.RegisterStartupScript(typeof(string),ScriptName, "<script language='javascript'>" + script + "</script>");
//		}
		/// <summary>
		/// 写javascript 代码
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="script">javascript 代码</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
				Random rnd = new Random();
				int intEndRndNumber = rnd.Next(60);
//				string tmpStr = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
				string tmpStr = Guid.NewGuid().ToString();
				string strScriptName = "script" + tmpStr + "Block" + intEndRndNumber.ToString();
				if(!page.ClientScript.IsStartupScriptRegistered(strScriptName))
					page.ClientScript.RegisterStartupScript(typeof(string),strScriptName, "<script language='javascript'>" + script + "</script>");
				else
					ResponseScript(page,script);
		}
		/// <summary>
		/// javascript 提示
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		public static void Show(System.Web.UI.Page page, string msg)
		{
			if(!page.ClientScript.IsStartupScriptRegistered("ShowJS"))
			page.ClientScript.RegisterStartupScript(typeof(string),"ShowJS", "<script language='javascript'>alert('" + msg.ToString() + "');</script>");
		}
		/// <summary>
		/// 显示提示并后退
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		/// <param name="backNumber">后退次数</param>
		public static void ShowAndReturnBack(System.Web.UI.Page page, string msg,int backNumber)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("history.back({0})", backNumber);
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowRBack"))
			page.ClientScript.RegisterStartupScript(typeof(string),"ShowRBack", builder1.ToString());
		}
		/// <summary>
		///	提示并转向
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		/// <param name="url">转向地址</param>
		public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("window.location.href='{0}'", url);
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("Redirect"))
			page.ClientScript.RegisterStartupScript(typeof(string),"Redirect", builder1.ToString());
		}
		/// <summary>
		///	提示并转向
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		/// <param name="url">转向地址</param>
		/// <param name="windowName">要转向的窗体名</param>
		public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url,string windowName)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat(windowName + ".location.href='{0}'", url);
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowAndRedirect"))
				page.ClientScript.RegisterStartupScript(typeof(string),"ShowAndRedirect", builder1.ToString());
		}
		/// <summary>
		/// 提示并关闭窗体
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		public static void ShowAndClose(System.Web.UI.Page page, string msg)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("window.close();");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowClose"))
			page.ClientScript.RegisterStartupScript(typeof(string),"ShowClose", builder1.ToString());
		}
		/// <summary>
		/// 提示并关闭窗体(Ext窗体)
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		public static void ShowAndCloseExt(System.Web.UI.Page page, string msg)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("parent.Ext.Win().close();");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowClose"))
				page.ClientScript.RegisterStartupScript(typeof(string),"ShowClose", builder1.ToString());
		}
		/// <summary>
		/// 提示并关闭窗体，并且刷新父窗体
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		public static void ShowAndCloseReload(System.Web.UI.Page page, string msg)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("opener.location.reload();");
			builder1.AppendFormat("window.close();");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowClose"))
				page.ClientScript.RegisterStartupScript(typeof(string),"ShowClose", builder1.ToString());
		}
		/// <summary>
		/// 提示并关闭窗体，并且刷新父窗体(Ext窗体)
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		public static void ShowAndCloseReloadExt(System.Web.UI.Page page, string msg)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("parent.location.reload();");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowClose"))
				page.ClientScript.RegisterStartupScript(typeof(string),"ShowClose", builder1.ToString());
		}
		/// <summary>
		/// 提示并关闭窗体
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="msg">提示内容</param>
		public static void ShowAndSelfClose(System.Web.UI.Page page, string msg)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.AppendFormat("alert('{0}');", msg);
			builder1.AppendFormat("self.close();");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("ShowClose"))
				page.ClientScript.RegisterStartupScript(typeof(string),"ShowClose", builder1.ToString());
		}
		/// <summary>
		/// 提醒
		/// </summary>
		/// <param name="Control">控件</param>
		/// <param name="msg">提示内容</param>
		public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
		{
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
		}
		/// <summary>
		/// 网址转向 不带窗体名
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="Url">转向地址</param>		
		public static void LocationUrl(System.Web.UI.Page page,string Url)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.Append("window.location.href='" + Url + "';");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("Location"))
				page.ClientScript.RegisterStartupScript(typeof(string),"Location", builder1.ToString());
		}

		/// <summary>
		/// 网址转向 带窗体名
		/// </summary>
		/// <param name="page">页面 page 对象</param>
		/// <param name="Url">转向地址</param>
		/// <param name="windowName">要转向的窗体名</param>
		public static void LocationUrl(System.Web.UI.Page page,string Url,string windowName)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language='javascript'>");
			builder1.Append(windowName + ".location.href='" + Url + "';");
			builder1.Append("</script>");
			if(!page.ClientScript.IsStartupScriptRegistered("Location"))
				page.ClientScript.RegisterStartupScript(typeof(string),"Location", builder1.ToString());
		}
		#endregion
	}
}
