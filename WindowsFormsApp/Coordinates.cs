using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class Coordinates
    {
        private double latitude { get; set; }

        private double longtitude { get; set; }
        public Coordinates(double x, double y)
        {
            this.latitude = x;
            this.longtitude = y;
        }
        public Coordinates(string coordinate)
        {
            coordinate.Trim((char[])(new char[] { '[', ']' }));
            string[] latlong = coordinate.Split(',');
            longtitude = Convert.ToDouble(latlong[0].Replace('.',','));
            latitude = Convert.ToDouble(latlong[1].Replace('.', ','));
        }

        public override string ToString()
        {
            return longtitude.ToString() + " " + latitude.ToString();
        }
    }
}
