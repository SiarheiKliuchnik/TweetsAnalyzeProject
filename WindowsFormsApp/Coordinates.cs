using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class Coordinates
    {
        private string latitude { get; set; }

        private string longtitude { get; set; }

        public Coordinates(string coordinate)
        {
            coordinate.Trim((char[])(new char[] { '[', ']' }));
            string[] latlong = coordinate.Split(',');
            longtitude = latlong[0];
            latitude = latlong[1];
        }

        public override string ToString()
        {
            return longtitude + " " + latitude;
        }
    }
}
