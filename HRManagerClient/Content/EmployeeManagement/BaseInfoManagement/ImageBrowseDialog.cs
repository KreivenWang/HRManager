using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using HRManagerClient.Utility;

namespace HRManagerClient
{
    class ImageBrowseDialog
    {
        OpenFileDialog dialog;
        public ImageBrowseDialog()
        {
            dialog = new OpenFileDialog();
            dialog.DefaultExt = ".jpg";
            dialog.Filter = "图像文件|*.jpg;*.png";
            dialog.Multiselect = false;
            Console.WriteLine(@"ImageBrowseDialog Constructed.");
        }

        public bool ShowDialog(out Image img)
        {
            img = null;
            Console.WriteLine(@"ImageBrowseDialog before show.");
            bool? result = dialog.ShowDialog();
            Console.WriteLine(@"ImageBrowseDialog after show.");
            if (result == true) {
                img = Image.FromFile(dialog.FileName);
                img = CutImage(img);
                return true;
            }
            return false;
        }

        private static Image CutImage(Image img)
        {
            if (img != null) {
                double r = Convert.ToDouble(295) / Convert.ToDouble(413);
                if (img.Width > img.Height) {
                    var newW = r * img.Height;
                    var newX = (img.Width - newW) / 2;
                    img = img.Cut(Convert.ToInt32(newX), 0, Convert.ToInt32(newW), img.Height);
                } else {
                    var newH = img.Width / r;
                    var newY = (img.Height - newH) / 2;
                    img = img.Cut(0, Convert.ToInt32(newY), img.Width, Convert.ToInt32(newH));
                }
            }
            return img;
        }
    }

    
}
