using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{

    class MedianFilter
    {

        public MedianFilter(Bitmap sourceImage)
        {
            int rad = 3, Threshold = 30;
            double R, G, B;
            int Red, Green, Blue, count_red, count_green, count_blue;
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap res = new Bitmap(sourceImage);

            for (int i = rad; i < width - rad; ++i)
            {
                for (int j = rad; j < height - rad; ++j)
                {
                    Color c = sourceImage.GetPixel(i, j);

                    Red = Green = Blue = 0;
                    count_red = count_green = count_blue = 0;

                    for (int l = i - rad; l <= i + rad; l++)
                    {
                        for (int k = j - rad; k <= j + rad; k++)
                        {
                            Color tmp = sourceImage.GetPixel(l, k);

                            if (Math.Abs(tmp.R - c.R) < Threshold)
                            {
                                Red += tmp.R;
                                count_red++;
                            }

                            if (Math.Abs(tmp.G - c.G) < Threshold)
                            {
                                Green += tmp.G;
                                count_green++;
                            }

                            if (Math.Abs(tmp.B - c.B) < Threshold)
                            {
                                Blue += tmp.B;
                                count_blue++;
                            }
                        }
                    }

                    R = (double)Red / (double)count_red;
                    G = (double)Green / (double)count_green;
                    B = (double)Blue / (double)count_blue;

                    sourceImage.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                }
            }

        }





        //private void quicksort(int[] a, int p, int r)
        //{
        //    if (p < r)
        //    {
        //        int q = partition(a, p, r);
        //        quicksort(a, p, q - 1);
        //        quicksort(a, q + 1, r);
        //    }
        //}

        //private int partition(int[] a, int p, int r)
        //{
        //    int x = a[r];
        //    int i = p - 1;
        //    int tmp;
        //    for (int j = p; j < r; j++)
        //    {

        //        if (a[j] <= x)
        //        {
        //            i++;
        //            tmp = a[i];
        //            a[i] = a[j];
        //            a[j] = tmp;

        //        }
        //    }
        //    tmp = a[r];
        //    a[r] = a[i + 1];
        //    a[i + 1] = tmp;
        //    return (i + 1);

        //}

        //protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        //{


        //    int n;
        //    int cR_, cB_, cG_;


        //    n = (2 * 2 + 1) * (2 * 2 + 1);



        //    int[] cR = new int[n + 1];
        //    int[] cB = new int[n + 1];
        //    int[] cG = new int[n + 1];

        //    for (int s = 0; s < n + 1; s++)
        //    {
        //        cR[s] = 0;
        //        cG[s] = 0;
        //        cB[s] = 0;
        //    }
        //    int i = 0;
        //    int w_b = sourceImage.Width;
        //    int h_b = sourceImage.Height;

        //    for (int l = -2; l <= 2; l++)
        //    {
        //        for (int k = -2; k <= 2; k++)
        //        {
        //            int idX = Clamp(x + k, 0, w_b - 1);
        //            int idY = Clamp(y + l, 0, h_b - 1);
        //            Color Color1 = sourceImage.GetPixel(idX, idY);

        //            cR[i] = Color1.R;
        //            cG[i] = Color1.G;
        //            cB[i] = Color1.B;
        //            i++;
        //        }
        //    }



        //    quicksort(cR, 0, n - 1);
        //    quicksort(cG, 0, n - 1);
        //    quicksort(cB, 0, n - 1);

        //    int n_ = (int)(n / 2) + 1;

        //    cR_ = cR[n_];
        //    cG_ = cG[n_];
        //    cB_ = cB[n_];

        //    return Color.FromArgb(cR_, cG_, cB_);
        //}

    }
}
