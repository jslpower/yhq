using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
namespace EyouSoft.Common.Function
{
	/// <summary>
	/// 生成缩略图
	/// </summary>
	public class Thumbnail
	{
		/// <summary>
		/// 
		/// </summary>
		public Thumbnail(){}
		/// <summary>
		/// 生成缩略图
		/// </summary>
		/// <param name="originalImagePath">源图路径（物理路径）</param>
		/// <param name="thumbnailPath">缩略图路径（物理路径）</param>
		/// <param name="width">缩略图宽度</param>
		/// <param name="height">缩略图高度</param>
		/// <param name="mode">生成缩略图的方式</param>    
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
		{
            MakeThumbnail(System.Drawing.Image.FromFile(originalImagePath), thumbnailPath, width, height, mode);
		}

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImage">源图</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(System.IO.Stream originalImage, string thumbnailPath, int width, int height, string mode)
        {
            MakeThumbnail(System.Drawing.Image.FromStream(originalImage), thumbnailPath, width, height, mode);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImage">源图</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(System.Drawing.Image originalImage, string thumbnailPath, int width, int height, string mode)
        {
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch { }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 以指定的分辨率压缩图片，并以指定的路径保存。
        /// 注：如果源图的分辨率小于指定的分辨率，则不将其拉伸
        /// </summary>
        /// <param name="stream">源图</param>
        /// <param name="desImagePath">压缩后的图片的保存路径（物理路径）</param>
        /// <param name="width">压缩后图片的宽度</param>
        /// <param name="height">压缩后图片的高度</param>
        public static void CompressionImage(System.IO.Stream stream, string desImagePath, int width, int height)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(stream);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if (ow < towidth)
            {
                towidth = ow;
            }
            if (oh < toheight)
            {
                toheight = oh;
            }


            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight, PixelFormat.Format32bppArgb);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            try
            {
                //以jpeg格式保存缩略图
                FileInfo f = new FileInfo(desImagePath);
                if (!Directory.Exists(f.DirectoryName))
                {
                    Directory.CreateDirectory(f.DirectoryName);
                }
                
                //bitmap.Save(desImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                CompressAsJPG((Bitmap)bitmap, desImagePath, 80);
            }
            catch { }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        private static ImageCodecInfo GetImageCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo ici in CodecInfo)
            {

                if (ici.MimeType == mimeType) return ici;

            }

            return null;

        }

        private static Bitmap GetBitmapFromStream(Stream inputStream)
        {

            Bitmap bitmap = new Bitmap(inputStream);

            return bitmap;

        }

        public static void CompressAsJPG(Bitmap bmp, string saveFilePath, int quality)
        {

            EncoderParameter p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality); ;

            EncoderParameters ps = new EncoderParameters(1);

            ps.Param[0] = p;

            bmp.Save(saveFilePath, GetImageCodecInfo("image/jpeg"), ps);

            bmp.Dispose();

        }
	}
}
