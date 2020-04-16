using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class GrayWorld : Filters
    {
        int countPixel1;
       public  GrayWorld(Bitmap scr)
        {
            countPixel1 = scr.Width * scr.Height;
            Color sourseColor;
            for (int i = 0; i < scr.Width; i++)
            {
                for (int j = 0; j < scr.Height; j++)
                {
                    sourseColor = scr.GetPixel(i, j);
                    R += sourseColor.R;
                    B += sourseColor.B;
                    G += sourseColor.G;
                }

            }
            R1 = (double)(R / countPixel1);
            G1 = (double)(G / countPixel1);
            B1 = (double)(B / countPixel1);
            AVG = (R1 + G1 + B1)/3;
        }

        int R, G, B;
        double R1, G1, B1;
        double AVG;

        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor=sourceImage.GetPixel(x, y);
            int resultR = (int)(sourseColor.R * AVG / R1);
            int resultG = (int)(sourseColor.G * AVG / G1);
            int resultB = (int)(sourseColor.B * AVG / B1);

            return Color.FromArgb(
                 Clamp((int)resultR, 0, 255),
                 Clamp((int)resultG, 0, 255),
                 Clamp((int)resultB, 0, 255)
                 );
        }
    }
}
