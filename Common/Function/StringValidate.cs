using System;
using System.Text;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Collections;

namespace EyouSoft.Common.Function
{
	/// <summary>
	/// StringValidate 的摘要说明。
	/// </summary>
	public class StringValidate
	{
		private string _UploadFileExt = "txt,gif,bmp,png,jpg,jpeg,doc,pdf,xls,rar,zip,tif";
		private static Regex RegInteger = new Regex("^[0-9]+$");
		private static Regex RegNumber = new Regex("^\\d+$");
		private static Regex RegNumberSign = new Regex("^[+-]?\\d+$");
		private static Regex RegIntegerSign = new Regex("^[+-]?[0-9]+$");
		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]*$");
		private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]*$"); //等价于^[+-]?\d+[.]?\d+$
		private static Regex RegEmail = new Regex("^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
		private static Regex RegChinese = new Regex("[\u4e00-\u9fa5]");
		private static Regex RegPhone = new Regex("^((\\(\\d{2,3}\\))|(\\d{3}\\-))?(\\(0\\d{2,3}\\)|0\\d{2,3}-)?[1-9]\\d{6,7}(\\-\\d{1,4})?$");
		private static Regex RegURL = new Regex("^http:\\/\\/[A-Za-z0-9]+\\.[A-Za-z0-9]+[\\/=\\?%\\-&_~`@[\\]\\':+!]*([^<>\\\"\\\"])*$");
		private static Regex RegHtml = new Regex("<\\/*[^<>]*>");
		private static Regex RegLink = new Regex("<\\/a*[^<>]*>");
		private static Regex RegGUID = new Regex(@"^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$", RegexOptions.IgnoreCase);
        private static Regex RegIP = new Regex("^(\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3})$");
        /// <summary>
        /// 小灵通号码
        /// </summary>
        private static Regex RegPHSNo = new Regex(@"^0(([1-9]\d)|([3-9]\d{2}))\d{8}$");
        private static Regex RegMobileNo = new Regex(@"^(13|15|18|14)\d{9}$"); 
		private static readonly string DigitText = "零壹贰叁肆伍陆柒捌玖";
		private static readonly string PositionText = "圆拾佰仟萬億兆京垓秭穰";
		private static readonly string OtherText = "分角整负";
		public StringValidate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region model
		/// <summary>
		/// 上传文件允许的格式
		/// </summary>
		public string UploadFileExt
		{
			set{_UploadFileExt = value;}
			get{return _UploadFileExt;}
		}
		#endregion
		#region 人民币大写金额转换
		/// <summary>
		/// 分角处理
		/// </summary>
		/// <param name="num"></param>
		/// <param name="stack"></param>
		private static void GetFractionStack(int num, Stack stack)
		{
			int fen, jiao = Math.DivRem(num, 10, out fen);
			if (fen != 0)
			{
				stack.Push(OtherText[0]);
				stack.Push(DigitText[fen]);
			}
			if (jiao != 0)
			{
				stack.Push(OtherText[1]);
				stack.Push(DigitText[jiao]);
			}
		}
		/// <summary>
		/// 整数金额部分处理
		/// </summary>
		/// <param name="num"></param>
		/// <param name="position"></param>
		/// <param name="stack"></param>
		private static void GetIntegerStack(decimal num, int position, Stack stack)
		{
			if (num < 10000M)
			{
				int _num = Decimal.ToInt32(num);
				for (int i = 0, mod_10 = 0; i < 4; i++)
				{
					bool behindZero = mod_10 == 0;
					_num = Math.DivRem(_num, 10, out mod_10);
					if (mod_10 == 0)
					{
						if (behindZero)
							if (_num == 0)
								break;
							else
								continue;
					}
					else if (i > 0)
						stack.Push(PositionText[i]);
					stack.Push(DigitText[mod_10]);
				}
			}
			else
			{
				GetIntegerStack(Decimal.Remainder(num, 10000M), position, stack);

				int mask = -1, offset = 4;
				while ((position & (0x1 << ++mask)) == 0) ;
				mask += offset;
				while ((char)stack.Peek() == PositionText[offset++])
					stack.Pop();
				stack.Push(PositionText[mask]);

				GetIntegerStack(Decimal.Divide(num, 10000M), position + 1, stack);
			}
		}
		/// <summary>
		/// 金额转换
		/// </summary>
		/// <param name="input">输入金额</param>
		/// <returns></returns>
		public static string MoneyFormatter(Decimal input)
		{
			Stack stack = new Stack(60);

			bool isNegate = input < Decimal.Zero;
			input = Decimal.Add(isNegate ? Decimal.Negate(input) : input, 0.005M);
			decimal integer = Decimal.Truncate(input);
			int fraction = Decimal.ToInt32(Decimal.Multiply(Decimal.Subtract(input, integer), 100M));
			if (fraction == 0)
				stack.Push(OtherText[2]);
			else
				GetFractionStack(fraction, stack);
			if (integer != Decimal.Zero)
			{
				stack.Push(PositionText[0]);
				GetIntegerStack(integer, 1, stack);
				if ((char)stack.Peek() == DigitText[0])
					stack.Pop();
			}
			else if (fraction == 0)
			{
				stack.Push(PositionText[0]);
				stack.Push(DigitText[0]);
			}
			if (isNegate)
				stack.Push(OtherText[3]);
			System.Text.StringBuilder sb=new System.Text.StringBuilder();
			foreach (object _s in stack)
				sb.Append(_s.ToString());
			return sb.ToString();
		}
		#endregion
		#region 文件处理函数
		/// <summary>
		/// 按时间加随机数生成文件名
		/// </summary>
		/// <param name="FileExt">文件后缀名</param>
		/// <returns>文件名</returns>
		public static string CreateFileName(string FileExt)
		{
			//int RandNum;
			string PhotoName;
//			Random rnd = new Random();
//			RandNum = rnd.Next(1,10000);//生成一个10000以内的随机数
			PhotoName = DateTime.Now.ToString("yyyyMMddhhmmss") + Guid.NewGuid().ToString().Replace("-","") + "." + FileExt;
			return PhotoName;
		}
		/// <summary>
		/// 返回当日的日期名称
		/// </summary>
		/// <returns></returns>
		public static string TodayUploadDirectory()
		{
			string FolderName;
			FolderName = DateTime.Now.ToString("yyMMdd");
			return FolderName;
		}
		/// <summary>
		/// 检查文件后缀名
		/// </summary>
		/// <param name="FileExt"></param>
		public bool CheckFileExt(string FileExt)
		{
			string tmpFileExt = _UploadFileExt;
			string[] strFileExt = tmpFileExt.Split(',');
			foreach(string fFileExt in strFileExt)
			{
				if(FileExt.ToLower().Trim() == fFileExt.Trim())
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 建立一个文件
		/// </summary>
		/// <param name="FilePathName"></param>
		public bool CreateFile(string FilePathName)
		{
			try
			{
				FileInfo CreateFile = new FileInfo(FilePathName); //创建文件 
				if (!CreateFile.Exists)
				{
					FileStream FS = CreateFile.Create();
					FS.Close();
					CreateFile = null;
					return true;
				}
				else
				{
					CreateFile = null;
					return false;
				}				
			}
			catch
			{
				return false;
			}
		}
		/**/
		/// <summary> 
		/// 删除整个文件夹及其字文件夹和文件 
		/// </summary> 
		/// <param name="FolderPathName"></param> 
		public void DeleParentFolder(string FolderPathName)
		{
			try
			{
				DirectoryInfo DelFolder = new DirectoryInfo(FolderPathName);
				if (DelFolder.Exists)
				{
					DelFolder.Delete();
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// 保存文本到文件
		/// </summary>
		/// <param name="FilePathName"></param>
		/// <param name="WriteWord"></param>
		public void WriteTextToFile(string FilePathName, string WriteWord)
		{
			try
			{
				//建立文件 
				CreateFile(FilePathName);
				//得到原来文件的内容 
				FileStream FileRead = new FileStream(FilePathName, FileMode.Open, FileAccess.ReadWrite);
				using(StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default))
				{
					using(StreamWriter FileWrite = new StreamWriter(FileRead, System.Text.Encoding.Default))
					{
						FileWrite.Write(WriteWord);
					}
				}
				FileRead.Close();
			}
			catch
			{
				// throw; 
			}
		}
		/// <summary> 
		/// 在文件里追加内容 
		/// </summary> 
		/// <param name="FilePathName"></param> 
		public void AppendText(string FilePathName, string WriteWord)
		{
			try
			{
				//建立文件 
				CreateFile(FilePathName);
				//得到原来文件的内容 
				FileStream FileRead = new FileStream(FilePathName, FileMode.Open, FileAccess.ReadWrite);
				using(StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default))
				{
					string OldString = FileReadWord.ReadToEnd().ToString();
					WriteWord = OldString + WriteWord;
					//把新的内容重新写入 
					using(StreamWriter FileWrite = new StreamWriter(FileRead, System.Text.Encoding.Default))
					{
						FileWrite.Write(WriteWord);
					}
				}
				FileRead.Close();
			}
			catch
			{
				// throw; 
			}
		}

		/**/
		/// <summary> 
		/// 读取文件里内容 
		/// </summary> 
		/// <param name="FilePathName"></param> 
		public string ReadFileData(string FilePathName)
		{
			string TxtString = "";
			try
			{

				FileStream FileRead = new FileStream(System.Web.HttpContext.Current.Server.MapPath(FilePathName).ToString(), FileMode.Open, FileAccess.Read);
				using(StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default))
				{
					TxtString = FileReadWord.ReadToEnd().ToString();
				}
				FileRead.Close();
				return TxtString;
			}
			catch
			{
				throw;
			}
		}
		/// <summary>
		/// 删除文件
		/// </summary>
		/// <param name="FilePath"></param>
		/// <returns></returns>
		public void FileDel(string FilePath)
		{
			try 
			{
				FileInfo objFile = new FileInfo(FilePath);
				if(objFile.Exists)//如果存在
				{
					//删除新创建的文件.
					objFile.Delete();
				}

			} 
			catch 
			{
			}
		}
		/// <summary>
		/// 删除文件
		/// </summary>
		/// <param name="FilePath"></param>
		/// <returns></returns>
		public static bool FileDelete(string FilePath)
		{
			try 
			{
				FileInfo objFile = new FileInfo(FilePath);
				if(objFile.Exists)//如果存在
				{
					//删除新创建的文件.
					objFile.Delete();
					return true;
				}

			} 
			catch 
			{
				return false;
			}
			return false;
		}
		/// <summary>
		/// 建立目录
		/// </summary>
		/// <param name="DirectoryName">目录名</param>
		/// <returns>返回数字, 1:目录已存在,2:目录建立失败,0:目录建立成功</returns>
		public static int CreateDirectory(string DirectoryName)
		{
			try
			{
				if(Directory.Exists(DirectoryName))
				{
					return 1;
				}//目录是否存在
				DirectoryInfo di = Directory.CreateDirectory(DirectoryName);
				return 0;
			}
			catch
			{
				return 2;
			}
		}

		#endregion
		#region 常用函数
		/// <summary>
		/// 取得时间间隔
		/// </summary>
		/// <param name="D1"></param>
		/// <param name="D2"></param>
		/// <param name="DateFormat"></param>
		/// <returns></returns>
		public static double DateDiff(DateTime StartDate,DateTime EndDate,string DateFormat)
		{
			double intDateDiff = 0;
			TimeSpan tmpSpan = EndDate - StartDate;
			switch(DateFormat.ToLower())
			{
				case "yyyy":
				case "yy":
				case "year":
					intDateDiff = EndDate.Year - StartDate.Year;
					break;
				case "m":
				case "mm":
				case "month":
					intDateDiff = (EndDate.Year - StartDate.Year)*12 + (EndDate.Month - StartDate.Month);
					break;
				case "h":
				case "hh":
				case "hour":
					intDateDiff = tmpSpan.TotalHours;
					break;
				case "n":
				case "mi":
				case "minute":					
					intDateDiff = tmpSpan.TotalMinutes;
					break;
				case "s":
				case "ss":
				case "second":
					intDateDiff = tmpSpan.TotalSeconds;
					break;
				case "ms":
				case "millisecond":
					intDateDiff = tmpSpan.TotalMilliseconds;
					break;
				default:
				case "d":
				case "dd":
				case "day":
					intDateDiff = tmpSpan.TotalDays;
					break;
			}
			return intDateDiff;
		}
		/// <summary>
		/// 自定义SPLIT
		/// </summary>
		/// <param name="Content"></param>
		/// <param name="SplitString"></param>
		/// <returns></returns>
		public static string[] Split(string Content,string SplitString)
		{
			if(Content != null && Content != String.Empty)
			{
				string[] ResultString = Regex.Split(Content,SplitString,RegexOptions.IgnoreCase);
				return ResultString;
			}
			else{
				string[] ResultString = {null};
				return ResultString;
			}			
		}
		/// <summary>
		/// 过滤HTML代码
		/// </summary>
		/// <param name="HtmlCode"></param>
		/// <returns></returns>
		public static string LoseHtml(string HtmlCode){
			string tmpStr = "";
			if(null != HtmlCode && String.Empty != HtmlCode){
				tmpStr = RegHtml.Replace(HtmlCode,"");
			}
			return tmpStr;
		}
		/// <summary>
		/// 过滤链接代码
		/// </summary>
		/// <param name="HtmlCode"></param>
		/// <returns></returns>
		public static string LoseLink(string HtmlCode)
		{
			string tmpStr = "";
			if(null != HtmlCode && String.Empty != HtmlCode)
			{				
				tmpStr = RegLink.Replace(HtmlCode,"");
			}
			return tmpStr;
		}
		
		/// <summary>
		/// 转换金额为大写
		/// </summary>
		/// <param name="numVal"></param>
		/// <returns></returns>
		public static string ConvertNumAmtToChinese(decimal numVal)
		{
			decimal org = Math.Round(numVal,2);
			string orgData = org.ToString();
			int length = orgData.Length;
			int j = 0;
			string ret = string.Empty;
			string temp = string.Empty;
			//9,123,456,789,123.12
			for (int i=length-1;i>=0;i--)
			{
				temp = "";
				j++;
				switch (orgData[i])
				{
					case '.' : temp = "元";
						break;
					case '0' : temp = "零";
						break;
					case '1' : temp = "壹";
						break;
					case '2' : temp = "贰";
						break;
					case '3' : temp = "叁";
						break;
					case '4' : temp = "肆";
						break;
					case '5' : temp = "伍";
						break;
					case '6' : temp = "陆";
						break;
					case '7' : temp = "柒";
						break;
					case '8' : temp = "捌";
						break;
					case '9' : temp = "玖";
						break;
					default : break;
				}
				switch(j)
				{
					case 1  : temp = temp + "分";
						break;
					case 2  : temp = temp + "角";
						break;
					case 3  : temp = temp + "";
						break;
					case 4  : temp = temp + "";
						break;
					case 5  : temp = temp + "拾";
						break;
					case 6  : temp = temp + "佰";
						break;
					case 7  : temp = temp + "仟";
						break;
					case 8  : temp = temp + "万";
						break;
					case 9  : temp = temp + "拾";
						break;
					case 10 : temp = temp + "佰";
						break;
					case 11 : temp = temp + "仟";
						break;
					case 12 : temp = temp + "亿";
						break;
					case 13 : temp = temp + "拾";
						break;
					case 14 : temp = temp + "佰";
						break;
					case 15 : temp = temp + "仟";
						break;
					case 16 : temp = temp + "万";
						break;
					default: break;
				}    
				ret = temp + ret;
			}
   
			ret = ret.Replace("零拾","零");
			ret = ret.Replace("零佰","零");
			ret = ret.Replace("零仟","零");
			ret = ret.Replace("零零零","零");
			ret = ret.Replace("零零","零");
			ret = ret.Replace("零角零分","整");
			ret = ret.Replace("零分","整");
			ret = ret.Replace("零分","整");
			ret = ret.Replace("零亿零万零元","亿元");
			ret = ret.Replace("亿零万零元","亿元");
			ret = ret.Replace("零亿零万","亿");
			ret = ret.Replace("零万零元","万元");
			ret = ret.Replace("万零元","万元");
			ret = ret.Replace("零亿","亿");
			ret = ret.Replace("零万","万");
			ret = ret.Replace("零元","元");
			ret = ret.Replace("零零","零");
			return ret;
		}

		/// <summary>
		/// 检测字符串是否是数组中的一项
		/// </summary>
		/// <param name="inputData"></param>
		/// <param name="arrData"></param>
		/// <returns></returns>
		public static bool IsStringExists(string inputData,string[] arrData)
		{
			if(null == inputData || string.Empty == inputData)
			{
				return false;
			}
			foreach(string tmpStr in arrData)
			{
				if(inputData == tmpStr)
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 取得客户的IP数据
		/// </summary>
		/// <returns>客户的IP</returns>
		public static string GetRemoteIP()
		{
			string Remote_IP = "";
			try
			{
				if(HttpContext.Current.Request.ServerVariables["HTTP_VIA"]!=null)
				{ 
					Remote_IP=HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); 
				}
				else
				{ 
					Remote_IP=HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); 
				} 
			}
			catch
			{
			}
			return Remote_IP;
		}
		/// <summary>
		/// 对字符串进行HTML编码
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static string HtmlEncode(string inputData)
		{
			return HttpUtility.HtmlEncode(inputData);
		}
		/// <summary>
		/// 格式化显示HTML
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string SafeHtmlEndcode(string str)
		{
			if(str != null && str != string.Empty)
			{
				str = str.Replace("\"","&quot;");
				str = str.Replace("\n","\\n");
				str = str.Replace("\r","\\r");
			}
			else
			{
				str = "";
			}
			return str;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string TextToHtml(string str)
		{
			if(str != null && str != string.Empty)
			{
				str = str.Replace("\n","<br>").Replace(" ","&nbsp;").Replace("&quot;","\"");
			}
			else
			{
				str = "";
			}
			return str;
		}
		/// <summary>
		/// 格式化 ' 号
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static string CheckSql(string str)
		{
			if(str != null && str != string.Empty)
			{
				str = str.Replace("'", "&#39");
			}
			else
			{
				str = "";
			}
			return str;
		}
		/// <summary>
		/// 取得的数据安全项
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string SafeRequest(string str)
		{
			if(str != null && str != string.Empty)
			{
				str = str.Replace("'", "&#39");
				str = str.Replace("<", "&lt;");
				str = str.Replace(">", "&gt;");
			}
			else
			{
				str = "";
			}
			return str;
		}
		/// <summary>
		/// 格式化字符
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string Encode(string str)
		{
			if(str != null && str != string.Empty)
			{
				str = str.Replace("&", "&amp;");
				str = str.Replace("'", "&#39");
				str = str.Replace("\"", "&quot;");
				str = str.Replace(" ", "&nbsp;");
				str = str.Replace("<", "&lt;");
				str = str.Replace(">", "&gt;");
				str = str.Replace("\n", "<br>");
				str = str.Replace("\r", "</p><p>");
			}
			else
			{
				str = "";
			}
			return str;
		}
		/// <summary>
		/// 反格式化字符
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string Decode(string str)
		{
			if(str != null && str != string.Empty)
			{
				str = str.Replace("<br>", "\n");
				str = str.Replace("&gt;", ">");
				str = str.Replace("&lt;", "<");
				str = str.Replace("&nbsp;", " ");
				str = str.Replace("&quot;", "\"");
				str = str.Replace("&#39", "'");
				str = str.Replace("&amp;", "&");
				str = str.Replace("</p><p>", "\r");
			}
			else
			{
				str = "";
			}
			return str;
		}
		/// <summary>
		/// 转换字符为 bit 型
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		private static int ConvertStringToBit(string inputData)
		{
			if(null == inputData || "" == inputData)
			{
				return 0;
			}
			if("1" == inputData)
			{
				return 1;
			}
			return 0;
		}
		/// <summary>
		/// 取得固定长度的字符串
		/// </summary>
		/// <param name="sqlInput"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static string StringTrimMid(string sqlInput, int maxLength)
		{
			if ((sqlInput != null) && (sqlInput != string.Empty))
			{
				sqlInput = sqlInput.Trim();
				if (sqlInput.Length > maxLength)
				{
					sqlInput = sqlInput.Substring(0, maxLength) + "...";
				}
			}
			return sqlInput;
		}
		/// <summary>
		/// label 赋值
		/// </summary>
		/// <param name="lbl"></param>
		/// <param name="txtInput"></param>
		public static void SetLabel(System.Web.UI.WebControls.Label lbl, string txtInput)
		{
			lbl.Text = HtmlEncode(txtInput);
		}
		/// <summary>
		/// label 赋值 重载,对象
		/// </summary>
		/// <param name="lbl"></param>
		/// <param name="inputObj"></param>
		public static void SetLabel(System.Web.UI.WebControls.Label lbl, object inputObj)
		{
			SetLabel(lbl, inputObj.ToString());
		}		
		/// <summary>
		/// 构造月份对象表
		/// </summary>
		/// <param name="ArrayMonthList"></param>
		/// <returns></returns>
		public static System.Data.DataTable CreateMonthTable(string[] ArrayMonthList)
		{
			System.Data.DataTable dt=new System.Data.DataTable();
			System.Data.DataRow dr;
			dt.Columns.Add(new System.Data.DataColumn("ReportMonth", typeof(DateTime)));
			foreach(string monthStr in ArrayMonthList)
			{
				dr = dt.NewRow();
				dr[0]=DateTime.Parse(DateTime.Now.Year + "-" + monthStr + "-1");
				dt.Rows.Add(dr);
			}
			return dt;
		}
		/// <summary>
		/// 构造月份对象表
		/// </summary>
		/// <param name="YearStr"></param>
		/// <param name="ArrayMonthList"></param>
		/// <returns></returns>
		public static System.Data.DataTable CreateMonthTable(string YearStr,string[] ArrayMonthList)
		{
			System.Data.DataTable dt=new System.Data.DataTable();
			System.Data.DataRow dr;
			dt.Columns.Add(new System.Data.DataColumn("ReportMonth", typeof(DateTime)));
			foreach(string monthStr in ArrayMonthList)
			{
				dr = dt.NewRow();
				dr[0]=DateTime.Parse(YearStr + "-" + monthStr + "-1");
				dt.Rows.Add(dr);
			}
			return dt;
		}
		/// <summary>
		/// 构造年份对象表
		/// </summary>
		/// <param name="ArrayYearList"></param>
		/// <returns></returns>
		public static System.Data.DataTable CreateYearTable(string[] ArrayYearList)
		{
			System.Data.DataTable dt=new System.Data.DataTable();
			System.Data.DataRow dr;
			dt.Columns.Add(new System.Data.DataColumn("ReportYear", typeof(DateTime)));
			foreach(string YearStr in ArrayYearList)
			{
				dr = dt.NewRow();
				dr[0]=DateTime.Parse(YearStr + "-1-1");
				dt.Rows.Add(dr);
			}
			return dt;
		}
		/// <summary>
		/// SELECT选项判断
		/// </summary>
		/// <param name="str1"></param>
		/// <param name="str2"></param>
		/// <returns></returns>
		public static string ItemIsEqual(string str1,string str2)
		{
			if(str1==str2)
			{
				return " selected";
			}
			else
			{
				return "";
			}
		}
		
		/// <summary>
		/// 删除地址参数
		/// </summary>
		/// <param name="urlParams">地址参数</param>
		/// <param name="UrlString">需要删除参数</param>
		/// <returns></returns>
		public static string DeleteUrlString(NameValueCollection urlParams,string UrlString)
		{
			NameValueCollection newCol = new NameValueCollection(urlParams);
			NameValueCollection col = new NameValueCollection();
			string[] newColKeys = newCol.AllKeys;	
			StringBuilder sb = new StringBuilder();
			int i;
			for (i = 0; i < newColKeys.Length; i++)
			{
				if (newColKeys[i] != null)
				{
					newColKeys[i] = newColKeys[i].ToLower();					
				}			
			}
			for (i = 0; i < newCol.Count; i++)
			{
				if (newColKeys[i] != UrlString.ToLower() )
				{					
					sb.Append(newColKeys[i]);
					sb.Append("=");				
					sb.Append(System.Web.HttpContext.Current.Server.UrlEncode(newCol[i]));
					sb.Append("&");
				}
			}
			return sb.ToString();
		}
		#endregion
		#region 常用判断函数
		/// <summary>
		/// 正则判断
		/// </summary>
		/// <param name="inputData"></param>
		/// <param name="strRegex"></param>
		/// <returns></returns>
		public static bool IsRegexMatch(string inputData,string strRegex)
		{
			Regex strTmp = new Regex(strRegex);
			Match match1 = strTmp.Match(inputData);
			return match1.Success;
		}

        /// <summary>
        /// 判断是否IP
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static bool IsIP(string IP)
        {
            if (!string.IsNullOrEmpty(IP))
            {
                Match match1 = RegIP.Match(IP);
                return match1.Success;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 判断是否为数字
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsNumber(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegNumber.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 判断是否为带符号数字
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsNumberSign(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegNumberSign.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}			
		}
		/// <summary>
		/// 判断是否是无符号整数
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsInteger(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegInteger.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 判断是否是 有符号整数
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsIntegerSign(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegIntegerSign.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}			
		}
		/// <summary>
		/// 判断是否为无符号浮点数
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsDecimal(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegDecimal.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}
		}
		//判断是否为有符号浮点数
		public static bool IsDecimalSign(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegDecimalSign.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}			
		}
		/// <summary>
		/// 判断是否是电话号码
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsPhone(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegPhone.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}				
		}

        /// <summary>
        /// 判断是否是手机号码或小灵通号码
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsMobileOrPHS(string inputData)
        {
            return IsMobilePhone(inputData) || IsPHS(inputData);
        }

		/// <summary>
		/// 判断是否是手机号码
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsMobilePhone(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegMobileNo.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}
        }
        /// <summary>
        /// 判断是否是小灵通号码
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsPHS(string inputData)
        {
            if (inputData != null)
            {
                Match match = RegPHSNo.Match(inputData);
                return match.Success;
            }
            else
            {
                return false;
            }
        }
		/// <summary>
		/// 非断是否为中文
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsChineseExist(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegChinese.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}				
		}
		/// <summary>
		/// 判断是否为EMAIL格式
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsEmail(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegEmail.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}	
			
		}
		/// <summary>
		/// 判断是否是URL格式
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsUrl(string inputData)
		{
			if(inputData != null)
			{
				Match match1 = RegURL.Match(inputData);
				return match1.Success;
			}
			else
			{
				return false;
			}	
			
		}
		/// <summary>
		/// 判断是否是日期
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsDateTime(string inputData){
			try
			{
				System.DateTime tmpDate = System.DateTime.Parse(inputData);
				return true;
			}
			catch{
				return false;
			}
		}
		/// <summary>
		/// 判断是否数字数组
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsIntegerArray(string inputData)
		{
			try
			{
				string[] tmpList = inputData.Split(',');
				foreach(string _str in tmpList)
				{
					if(!IsInteger(_str))
						return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// 判断是否GUID
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsGUID(string inputData)
		{
			try
			{
				Match m = RegGUID.Match(inputData);
				if(m.Success)
				{
					//可以转换
					//Guid guid = new Guid(str);
					return true;
				}
				else
				{
					//不可转换
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
		public static string BuildUrlString(NameValueCollection urlParams,string Params)
		{
			NameValueCollection newCol = new NameValueCollection(urlParams);
			NameValueCollection col = new NameValueCollection();
			string[] newColKeys = newCol.AllKeys;			
			int i;
			for (i = 0; i < newColKeys.Length; i++)
			{
				if (newColKeys[i] != null)
				{
					newColKeys[i] = newColKeys[i].ToLower();					
				}			
			}
			StringBuilder sb = new StringBuilder();
			for (i = 0; i < newCol.Count; i++)
			{
				if (newColKeys[i] != Params.ToLower() )
				{					
					sb.Append(newColKeys[i]);
					sb.Append("=");				
					sb.Append(System.Web.HttpContext.Current.Server.UrlEncode(newCol[i]));
					sb.Append("&");
				}
			}
			return sb.ToString();
		}

		public static string BuildUrlString(NameValueCollection urlParams,string[] Params) {
			NameValueCollection newCol = new NameValueCollection(urlParams);
			string[] newColKeys = newCol.AllKeys;			
			int i;
			for (i = 0; i < newColKeys.Length; i++) {
				if(newColKeys[i]!=null && newColKeys[i]!=string.Empty){
					newColKeys[i] = newColKeys[i].ToLower();		
				}
			}
			bool isEqual = false;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for (i = 0; i < newColKeys.Length; i++) {
				if(newColKeys[i]==string.Empty || newColKeys[i]==null){
					continue;
				}
				for(int j=0;j<Params.Length;j++){
					if(newColKeys[i]==Params[j].ToLower()){
						isEqual = true;
						break;
					}
				}
				if (isEqual==false ) {					
					sb.Append(newColKeys[i]);
					sb.Append("=");				
					sb.Append(System.Web.HttpContext.Current.Server.UrlEncode(newCol[newColKeys[i]]));
					sb.Append("&");
				}
				isEqual = false;
			}
			return sb.ToString();
		}
		#endregion

        /// <summary>
        /// 取得客户的IP数据
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static string RemoteIP(System.Web.HttpRequest Request)
        {
            string Remote_IP = "";
            try
            {
                if (Request.ServerVariables["HTTP_VIA"] != null)
                {
                    Remote_IP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    Remote_IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                }
            }
            catch { }
            return Remote_IP;
        }

        /// <summary>
        /// 获得进行int有效性验证(可以为负数)后的值,若为非有效数值,则返回0
        /// </summary>
        /// <param name="strValue">要进行验证的字符数值</param>
        public static int GetIntValue(string strValue)
        {
            return GetIntValue(strValue, 0);
        }

        /// <summary>
        /// 将字符串转化为数字 若值不是数字将返回指定值
        /// </summary>
        /// <param name="s">要转化成数字的字符串</param>
        /// <param name="defaultValue">指定值</param>
        public static int GetIntValue(string s, int defaultValue)
        {
            if (!String.IsNullOrEmpty(s) && StringValidate.IsIntegerSign(s))
            {
                return Convert.ToInt32(s.Trim());
            }
            else
            {
                return defaultValue;
            }
        }

	}
}
