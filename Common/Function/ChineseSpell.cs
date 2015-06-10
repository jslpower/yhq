using System;
using System.IO;
using System.Web;
using System.Text;

namespace EyouSoft.Common.Function
{
	/// <summary>
	/// 汉字查拼音类
	/// </summary>
	public class ChineseSpell
	{
		#region 成员方法
		/// <summary>
		/// 汉字查完整拼音
		/// </summary>
		public static string Convert(string ChineseChar)
		{
			StringBuilder sb=new StringBuilder();
			foreach(char str in ChineseChar.ToCharArray())
			{
				sb.Append(GetSingleSpell(str));
			}
			return sb.ToString();
		}

		/// <summary>
		/// 汉字查拼音首字母
		/// </summary>
		public static string ConvertFirst(string ChineseChar)
		{
			StringBuilder sb=new StringBuilder();
			foreach(char str in ChineseChar.ToCharArray())
			{
				sb.Append(GetSingleSpellFirst(str));
			}
			return sb.ToString();
		}

		/// <summary>
		/// 单个汉字查拼音
		/// </summary>
		private static string GetSingleSpell(char ChineseChar)
		{
			StreamReader TextReader = new StreamReader(HttpContext.Current.Server.MapPath("/DefaultSetting/winpy.txt"), true);
			string text = TextReader.ReadLine();
			while(text!=null&&text.ToCharArray()[0]!=ChineseChar)
			{
				TextReader.Peek();
				text = TextReader.ReadLine();
			}
			TextReader.Close();
			if(text!=null)
			{
				string[] tmpArr = text.Replace(ChineseChar.ToString(),"").Split(' ' );
				text = tmpArr[tmpArr.Length-1];				
			}
			else
			{
				text = "";
			}
			return text;	
		}

		/// <summary>
		/// 单个汉字查拼音首字母
		/// </summary>
		protected static string GetSingleSpellFirst(char ChineseChar)
		{
			StreamReader TextReader = new StreamReader(HttpContext.Current.Server.MapPath("/DefaultSetting/winpy.txt"), true);
			string text = TextReader.ReadLine();
			while(text!=null&&text.ToCharArray()[0]!=ChineseChar)
			{
				TextReader.Peek();
				text = TextReader.ReadLine();
			}
			TextReader.Close();
			if(text!=null)
			{
				string[] tmpArr = text.Replace(ChineseChar.ToString(),"").Split(' ' );
				text = tmpArr[tmpArr.Length-1].Substring(0,1);				
			}
			else
			{
				text = "";
			}
			return text;	
		}
		#endregion
	}
}
