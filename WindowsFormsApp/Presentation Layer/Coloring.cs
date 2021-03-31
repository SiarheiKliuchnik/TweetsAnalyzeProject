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
            if (float.IsNaN(value))
                return Color.Gray;
            if (value > 0)
            {
                if (value < 0.5)
                {
                    red = 255;
                    green = 255;
                    blue = Convert.ToInt32(255 - 255*value*2);
                }
                else if (value >= 0.5)
                {
                    red = 255;
                    blue = 0;
                    green = Convert.ToInt32(255-255 *(value-0.5f));
                }
            }
            else if (value < 0)
            {
                if (value > -0.5)
                {
                    blue = 255;
                    green = 255;
                    red = Convert.ToInt32(255 - 255*Math.Abs(value*2));

                }
                else if (value <= -0.5)
                {
                    blue = 255;
                    red = 0;
                    green = Convert.ToInt32(255 -255 * Math.Abs((value+0.5f)));
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
