using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace HRManagerClient.Utility
{
    public static class ImageExtension
    {
        /// <summary>  
        /// 剪裁 -- 用GDI+   
        /// </summary>  
        /// <param name="b">原始Bitmap</param>  
        /// <param name="StartX">开始坐标X</param>  
        /// <param name="StartY">开始坐标Y</param>  
        /// <param name="iWidth">宽度</param>  
        /// <param name="iHeight">高度</param>  
        /// <returns>剪裁后的Bitmap</returns>  
        public static Image Cut(this Image b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null) {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h) {
                return null;
            }
            if (StartX + iWidth > w) {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h) {
                iHeight = h - StartY;
            }
            try {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(
                    b,
                    new System.Drawing.Rectangle(0, 0, iWidth, iHeight),
                    new System.Drawing.Rectangle(StartX, StartY, iWidth, iHeight),
                    GraphicsUnit.Pixel
                    );
                g.Dispose();
                return bmpOut;
            } catch {
                return null;
            }
        }

        public static ImageSource ToImageSource(this Image img)
        {
            MemoryStream memory = new MemoryStream();
            img.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            ImageSourceConverter converter = new ImageSourceConverter();
            ImageSource source = (ImageSource)converter.ConvertFrom(memory);
            return source;
        }

        public static string ToBase64String(this Image img)
        {
            MemoryStream memory = new MemoryStream();
            img.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(memory.GetBuffer());
        }

        public static Image ToImage(this string imgStr)
        {
            MemoryStream memory = new MemoryStream(Convert.FromBase64String(imgStr));
            return new Bitmap(memory);
        }
    }
}
