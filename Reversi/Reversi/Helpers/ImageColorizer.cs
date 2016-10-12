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
        /// <summary>
        /// Changes the color of the image
        /// </summary>
        /// <param name="image">The image to color</param>
        /// <param name="h">The desired hue</param>
        /// <returns></returns>
        public unsafe Bitmap ColorImage(Image image, float h)
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
                    Color color;
                    float s = currentC.GetSaturation();
                    float l = currentC.GetBrightness();
                    float r, g, b;

                    if(s == 0)
                    {
                        r = g = b = l;
                    }
                    else
                    {
                        float d, e;
                        if(l < 0.5)
                        {
                            d = l * (1 + s);
                        }
                        else
                        {
                            d = l + s - l * s;
                        }
                        e = 2 * l - d;
                        r = HueToRGB(e, d, h + 1 / 3);
                        g = HueToRGB(e, d, h);
                        b = HueToRGB(e, d, h - 1 / 3);
                    }

                    data[x] = (byte)Math.Round(b * 255);
                    data[x + 1] = (byte)Math.Round(g * 255);
                    data[x + 2] = (byte)Math.Round(r * 255);
                });
            });
            return bitmap;
        }

        /// <summary>
        /// Calculates the RGB from the hue.
        /// </summary>
        /// <returns></returns>
        public float HueToRGB(float a, float b, float c)
        {
            if (c < 0) c++;
            if (c > 1) c--;
            if (c < 1 / 6) return a + (b - a) * 6 * c;
            if (c < 0.5) return b;
            if (c < 2 / 3) return a + (b - a) * (2 / 3 - c) * 6;
            return a;
        }
    }
}
