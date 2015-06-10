using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing.QrCode;
using ZXing;
using System.Drawing;


namespace Eyousoft_yhq.Web.CommonPage
{
    public partial class zxingcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 200,
                Height = 200
            };

            var data = Request.QueryString["code"];

            BarcodeWriter writer = null;
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            Bitmap bitmap = writer.Write(data);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawImage(bitmap, 200, 200);
            bitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            graphics.Dispose();
            Response.ContentType = "Image/jpeg";
            Response.Flush();
            Response.End(); 
        }
    }
}
