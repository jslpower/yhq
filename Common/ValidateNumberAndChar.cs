using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace EyouSoft.Common
{
    /// <summary>
    /// 验证码生成类
    /// </summary>
    public class ValidateNumberAndChar
    {
        /// <summary>
        /// 生成验证码的类
        /// </summary>
        public ValidateNumberAndChar() { }

        /// <summary>
        /// 验证码的最大长度
        /// </summary>
        public static int MaxLength
        {
            get { return 10; }
        }
        /// <summary>
        /// 验证码的最小长度
        /// </summary>
        public static int MinLength
        {
            get { return 1; }
        }
        /// <summary>
        /// 验证码的前缀
        /// </summary>
        public static string BaseString
        {
            get
            {
                return "VegnetValidNumber";
            }
        }
        /// <summary>
        /// 当前字符串长度，主要是为了更换图片时用
        /// </summary>
        private static int _currentLength = 5;

        /// <summary>
        /// 
        /// </summary>
        public static int CurrentLength
        {
            get
            {
                return _currentLength;
            }
            set
            {
                _currentLength = value;
            }
        }
        /// <summary>
        /// 当前字符串，主要是为了更换图片时用
        /// </summary>
        private static string _currentNumber = "";
        /// <summary>
        /// 
        /// </summary>
        public static string CurrentNumber
        {
            get
            {
                if (_currentNumber != "")
                {
                    return _currentNumber;
                }
                else
                {
                    return CreateValidateNumber(CurrentLength);
                }
            }
            set
            {
                _currentNumber = value;
            }
        }
        /// <summary>
        /// 合法字符列表
        /// </summary>
        private static string strLetters
        {
            get
            {
                return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            }
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public static string CreateValidateNumber(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }

        /// <summary>
        /// 生成验证码（依据合法字符列表随机生成)
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CreateValidateChar(int length)
        {

            StringBuilder s = new StringBuilder();
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //将随机生成的字符串绘制到图片上
            for (int i = 0; i < length; i++)
            {
                Random r = new Random(seeks[i]);
                s.Append(strLetters.Substring(r.Next(0, strLetters.Length - 1), 1));
            }
            return s.ToString();
        }

        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public static void CreateValidateGraphic(HttpContext containsPage, string validateNum)
        {
            double imageN = double.Parse((validateNum.Length * 15).ToString());
            Bitmap image = new Bitmap((int)Math.Ceiling(imageN), 25);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.GhostWhite), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 16, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                    Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片
                containsPage.Response.Clear();
                containsPage.Response.ContentType = "image/jpeg";
                containsPage.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        /// <summary>
        /// 得到验证码图片的长度
        /// </summary>
        /// <param name="validateNumLength">验证码的长度</param>
        /// <returns></returns>
        public static int GetImageWidth(int validateNumLength)
        {
            return (int)(validateNumLength * 15);
        }
        /// <summary>
        /// 得到验证码的高度
        /// </summary>
        /// <returns></returns>
        public static double GetImageHeight()
        {
            return 25;
        }
        /// <summary>
        /// 生成不重复的字条串#region 生成不重复的字条串
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string RandomKey(int b, int e)
        {
            return DateTime.Now.ToString("yyyyMMdd-HHmmss-fff-") + this.getRandomID(b, e);
        }

        private int getRandomID(int minValue, int maxValue)
        {
            Random ri = new Random(unchecked((int)DateTime.Now.Ticks));
            int k = ri.Next(minValue, maxValue);
            return k;
        }
        /// <summary>
        /// 
        /// </summary>
        private string GuidString
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
    }
}
