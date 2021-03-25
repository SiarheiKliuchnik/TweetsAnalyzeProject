using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp.Presentation_Layer
{
   public static class Coloring
    {
        public static Color SetColors(float value)
        {
            int green = 255, red = 255, blue = 255;
            float coef = 0;
            if (float.IsNaN(value))
                return Color.Gray;
            if (value > 0)
            {
                if (value < 0.5)
                {
                    red = 255;
                    green = 255;
                    coef = 0.5F / 255F;
                    blue = 255 - Convert.ToInt32(value / coef);
                }
                else if (value > 0.5)
                {
                    red = 255;
                    blue = 0;
                    coef = 0.5F / 128F;
                    green = 255 - Convert.ToInt32(value / coef);
                }
            }
            else if (value < 0)
            {
                if (value > -0.5)
                {
                    blue = 255;
                    green = 255;
                    coef = 0.5F / 255F;
                    red = 255 - Math.Abs(Convert.ToInt32(value / coef));

                }
                else if (value < -0.5)
                {
                    blue = 255;
                    red = 0;
                    coef = 0.5F / 128F;
                    green = 255 - Math.Abs(Convert.ToInt32(value / coef));
                }
            }
            return Color.FromArgb(IsOutOfByte(red), IsOutOfByte(green), IsOutOfByte(blue));
        }
        private static int IsOutOfByte(int value)
        {
            if (value < 0)
                return 0;
            if (value > 255)
                return 255;
            return value;
        }
    }
}
