using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WxEpg.Cropper.Models
{
    public static class ImageHelper
    {
        public static byte[] CutImage(string fileSource, int x, int y, int width, int height)
        {
            byte[] bytes = null;
            BitmapSource bitmapImg = new BitmapImage(new Uri(fileSource, UriKind.RelativeOrAbsolute));
            Int32Rect rect = new Int32Rect(x, y, width, height);
            int stride = (int)(bitmapImg.Format.BitsPerPixel * width / 8);
            //int offset = (int)(bitmapImg.Format.BitsPerPixel * x / 8);
            int offset = 0;
            bytes = new byte[(int)(height * stride)];
            bitmapImg.CopyPixels(rect, bytes, stride, offset);
            return bytes;
        }

        public static byte[] CutImage(string fileSource, int x, int y, int width, int height, string fileCut)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            using (BinaryReader binReader = new BinaryReader(File.Open(fileSource, FileMode.Open)))
            {
                FileInfo fileInfo = new FileInfo(fileSource);
                byte[] temp = binReader.ReadBytes((int)fileInfo.Length);
                binReader.Close();
                bitmap.StreamSource = new MemoryStream(temp);
                bitmap.EndInit();
            }
            BitmapSource bitmapImg = bitmap;
            Int32Rect rect = new Int32Rect(x, y, width, height);
            int stride = (int)(bitmapImg.Format.BitsPerPixel * width / 8);
            int offset = 0;
            byte[] bytes = new byte[(int)(height * stride)];
            bitmapImg.CopyPixels(rect, bytes, stride, offset);
            BitmapSource bitsrc = BitmapImage.Create((int)width, (int)height, bitmapImg.DpiX, bitmapImg.DpiY, PixelFormats.Bgr32, null, bytes.ToArray(), stride);

            double rx = 0, ry = 0;
            if (width / height >= 1)
            {
                rx = 400.0 / width;
                ry = 300.0 / height;
            }
            else if (width / height < 1)
            {
                rx = 300.0 / width;
                ry = 400.0 / height;
            }
            TransformedBitmap tfsrc = new TransformedBitmap(bitsrc, new ScaleTransform(rx, ry));
            return SaveToJpgFile(tfsrc);
        }

        public static void SaveToJpgFile(BitmapSource bsrc, string filename)
        {
            JpegBitmapEncoder jpgE = new JpegBitmapEncoder();
            jpgE.Frames.Add(BitmapFrame.Create(bsrc));
            using (Stream stream = File.Create(filename))
            {
                jpgE.QualityLevel = 30;
                jpgE.Save(stream);
                stream.Close();
            }
        }

        public static byte[] SaveToJpgFile(BitmapSource bsrc)
        {
            MemoryStream ms = new MemoryStream();
            JpegBitmapEncoder jpgE = new JpegBitmapEncoder();
            jpgE.Frames.Add(BitmapFrame.Create(bsrc));
            jpgE.QualityLevel = 30;
            jpgE.Save(ms);
            ms.Close();
            return ms.ToArray();
        }
    }
}