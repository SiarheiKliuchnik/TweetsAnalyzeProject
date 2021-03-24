using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class Coordinates
    {
        private double latitude;
        public double Latitude
        { get => latitude; set => latitude = value; }

        private double longtitude { get; set; }

        public double Longtitude
        { get => longtitude; set => longtitude = value; }
        public Coordinates(double x, double y)
        {
            Longtitude = x;
            Latitude = y;
        }
        public Coordinates(string coordinate)
        {
            coordinate.Trim((char[])(new char[] { '[', ']' }));
            string[] latlong = coordinate.Split(',');
            Longtitude = Convert.ToDouble(latlong[0].Replace('.',','));
            Latitude = Convert.ToDouble(latlong[1].Replace('.', ','));
        }

        public override string ToString()
        {
            return Longtitude.ToString() + " " + Latitude.ToString();
        }
    }
}
