using System;
using System.IO;

namespace EyouSoft.Common.Function
{
	/// <summary>
	/// 文件目录操作类
	/// </summary>
	public class FileDirectory
	{
		public FileDirectory()
		{
		}
		#region 目录操作
		/// <summary>
		/// 判断目录是否存在
		/// </summary>
		/// <param name="DirectoryName">目录路径</param>
		/// <returns>true：存在，false：不存在</returns>
		public bool DirectoryExists(string DirectoryName)
		{
			return Directory.Exists(DirectoryName);
		}
		/// <summary>
		/// 建立目录
		/// </summary>
		/// <param name="DirectoryName">目录名</param>
		/// <returns>返回boolean,true:目录建立成功, false:目录建立失败</returns>
		public bool MakeDirectory(string DirectoryName)
		{
			try
			{
				if(!Directory.Exists(DirectoryName))
				{
					Directory.CreateDirectory(DirectoryName);
					return true;
				}
				else
				{
					
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// 删除指定的目录
		/// </summary>
		/// <param name="DirectoryName">目录名</param>
		/// <returns>true：删除成功，false：删除失败</returns>
		public bool RMDIR(string DirectoryName)
		{
			DirectoryInfo di = new DirectoryInfo(DirectoryName);
			if (di.Exists == false)
			{
				return false;
			}
			else
			{
				di.Delete(true);
				return true;
			}

		}
		/// <summary>
		/// 删除目录并删除其下的子目录及其文件
		/// </summary>
		/// <param name="DirectoryName">目录名</param>
		/// <returns>true:删除成功,false:删除失败</returns>
		public bool DelTree(string DirectoryName)
		{
			if(DirectoryExists(DirectoryName))
			{
				Directory.Delete(DirectoryName,true);
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
		#region 文件操作
		/// <summary>
		/// 建立一个文件
		/// </summary>
		/// <param name="FilePathName">目录名</param>
		/// <returns>true:建立成功,false:建立失败</returns>
		public bool CreateTextFile(string FilePathName)
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
		/// <summary> 
		/// 在文件里追加内容 
		/// </summary> 
		/// <param name="FilePathName">文件名</param> 
		/// <param name="WriteWord">追加内容</param>
		public void AppendText(string FilePathName, string WriteWord)
		{
			try
			{
				//建立文件 
				CreateTextFile(FilePathName);
				//得到原来文件的内容 
				FileStream FileRead = new FileStream(FilePathName, FileMode.Open, FileAccess.ReadWrite);
				using(StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default))
				{
					string OldString = FileReadWord.ReadToEnd().ToString();
					OldString = OldString + WriteWord;
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

		/// <summary> 
		/// 读取文件里内容 
		/// </summary> 
		/// <param name="FilePathName">文件名</param>
		/// <returns>文件内容</returns>
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
		/// <param name="AbsoluteFilePath">文件绝对地址</param>
		/// <returns>true:删除文件成功,false:删除文件失败</returns>
		public bool FileDelete(string AbsoluteFilePath)
		{
			try 
			{
				FileInfo objFile = new FileInfo(AbsoluteFilePath);
				if(objFile.Exists)//如果存在
				{
					//删除文件.
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
        /// 批量删除二手车群组相册图片
        /// </summary>
        /// <param name="FilePaths"></param>
        /// <returns></returns>
        public void BatchFileDelete(string FilePaths)
        {
            foreach (string path in FilePaths.Split('$'))
            {
                if (path != string.Empty)
                {
                    FileDelete(path);
                }
            }
        }
		#endregion
	}
}
