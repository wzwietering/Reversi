using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Reversi.Helpers
{
    static class ImageColorizer
    {
        /// <summary>
        /// Changes the color of the image
        /// </summary>
        /// <param name="image">The image to color</param>
        /// <param name="color">The desired color</param>
        /// <returns></returns>
        //The RGB to HSL conversion is based on this code: https://gist.github.com/mjackson/5311256. We thank the author for his work.
        public static unsafe Bitmap ColorImage(Image image, Color color)
        {
            //The hue is given in a [0,360] range, it is converted to a [0,1] range
            float h = color.GetHue() / 360f;

            //This part reserves memory for the image and creates some useful variables
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
                    //data is the pointer to the ARGB values of a pixel of the image
                    byte* data = address + y * bmd.Stride + x * 3;

                    //The currentC variable holds the color of the image. The luminosity of the texture is multiplied to look nicer.
                    Color currentC = Color.FromArgb(data[x + 3], data[x + 2], data[x + 1], data[x]);
                    float s = color.GetSaturation();
                    float l;

                    //When choosing black, the luminosity becomes zero. This makes the stone a black disc, which looks terrible. The following code prevents this.
                    if (currentC.GetBrightness() * color.GetBrightness() == 0)
                    {
                        l = (currentC.GetBrightness() + 0.15f) * (color.GetBrightness() + 0.15f) * 2.1f;
                    }
                    else
                    {
                        l = currentC.GetBrightness() * color.GetBrightness() * 2.1f;
                    }

                    //Due to the multiplications it is possible that l becomes greater than 1
                    if (l > 1.0f) l = 1.0f;

                    //This part calculates the right rgb values, d and e are temporary values.
                    float r, g, b, d, e;
                    
                    if (l < 0.5f)
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

                    //The new RGB values are written to the memory here. The alpha doesn't change, so we don't need to modify that value.
                    data[x] = (byte)Math.Round(b * 255);
                    data[x + 1] = (byte)Math.Round(g * 255);
                    data[x + 2] = (byte)Math.Round(r * 255);
                });
            });
            //Makes the memory available
            bitmap.UnlockBits(bmd);
            return bitmap;
        }

        /// <summary>
        /// Calculates the RGB from the hue.
        /// </summary>
        /// <returns></returns>
        public static float HueToRGB(float a, float b, float c)
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
