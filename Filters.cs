using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Lab1
{
   abstract class Filters
    {
        
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        
        public Bitmap processImage(Bitmap sourceImage)
        {
            
          Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for(int i=0; i < sourceImage.Width; i ++)
            {
               // worker.ReportProgress((int)((float)i/ resultImage.Width * 100));
                for(int j=0; j<sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            
            return  resultImage;
        }
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

       
    }
}
