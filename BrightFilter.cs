using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class BrightFilter : Filters
    {
        int value = 0;
        
        public BrightFilter(int _value)
        {
            value = _value;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            double k = 1;
            switch (value)
            {
                case 20:
                    {
                        k = 20;
                        break;
                    }
                case 40:
                    {
                        k = 40;
                        break;
                    }
                case 60:
                    {
                        k = 60;
                        break;
                    }
                case 80: 
                    {
                        k = 90;
                        break;
                    }
                case 100:
                    {
                        k = 255;
                        break;
                    }
            }
            int resultR = (int)(sourseColor.R + k);
            int resultG = (int)(sourseColor.G + k);
            int resultB = (int)(sourseColor.B + k);
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
