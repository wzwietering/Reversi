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
        public unsafe Bitmap ColorImage(Image image, Color color)
        {
            float h = color.GetHue() / 360f;
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
                    byte* data = address + y * bmd.Stride + x * 3;

                    Color currentC = Color.FromArgb(data[x + 3], data[x + 2], data[x + 1], data[x]);
                    float s = 1.0f;
                    float l = currentC.GetBrightness();
                    float r, g, b;

                    if(s == 0)
                    {
                        r = g = b = l;
                    }
                    else
                    {
                        float d, e;
                        if(l < 0.5f)
                        {
                            d = l * (1f + s);
                        }
                        else
                        {
                            d = l + s - l * s;
                        }
                        e = 2 * l - d;
                        r = HueToRGB(e, d, (h + 1f / 3f));
                        g = HueToRGB(e, d, h);
                        b = HueToRGB(e, d, (h - 1f / 3f));
                    }

                    data[x] = (byte)Math.Round(b * 255);
                    data[x + 1] = (byte)Math.Round(g * 255);
                    data[x + 2] = (byte)Math.Round(r * 255);
                });
            });
            bitmap.UnlockBits(bmd);
            return bitmap;
        }

        /// <summary>
        /// Calculates the RGB from the hue.
        /// </summary>
        /// <returns></returns>
        public float HueToRGB(float a, float b, float c)
        {
            if (c < 0) c++;
            if (c > 1f) c--;
            if (c < 1f / 6f) return a + (b - a) * 6f * c;
            if (c < 0.5f) return b;
            if (c < 2f / 3f) return a + (b - a) * (2f / 3f - c) * 6f;
            return a;
        }
    }
}
