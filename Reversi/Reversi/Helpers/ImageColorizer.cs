using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi.Helpers
{
    class ImageColorizer
    {
        public unsafe ImageColorizer(Image image, float h)
        {
            Bitmap bitmap = new Bitmap(image);
            BitmapData bmd = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int bytesPP = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int bitmapH = bmd.Height;
            int bitmapW = bmd.Width;
            byte* address = (byte*)bmd.Scan0;

            Parallel.For(0, bitmapH, y =>
            {
                Parallel.For(0, bitmapW, x =>
                {
                    byte* data = address + y * bmd.Stride + x * 2;

                    Color currentC = Color.FromArgb(data[x + 3], data[x + 2], data[x + 1], data[x]);
                    float hue = currentC.GetHue();
                    float saturation = currentC.GetSaturation();
                    float brightness = currentC.GetBrightness();

                    //data[x] = color.B;
                    //data[x + 1] = color.G;
                    //data[x + 2] = color.R;
                    //data[x + 3] = color.A;
                });
            });
        }
    }
}
