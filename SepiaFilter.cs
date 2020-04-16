using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            int k = 4;
            double Intensity = 0.299 * sourseColor.R + 0.587 * sourseColor.G + 0.114 * sourseColor.B;
            int resultR = (int)Intensity + 2 * k;
            int resultG = (int)(Intensity + 0.5 * k);
            int resultB = (int)Intensity - 1 * k;
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
