using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;

namespace WindowsFormsApp
{
    internal class State
    {
        public State()
        {
            this.Tweets = new List<Tweet>();
            this.Polygons = new List<List<List<Coordinates>>>();
            this.Weight = float.NaN;
        }
        public string Postcode { get; set; }
        public float Weight { get; set; }
        public List<Tweet> Tweets { get; set; }
        public List<List<List<Coordinates>>> Polygons { get; set; }

        public double min_long = 180;
        public double max_long = -180;
        public double min_lat = 180;
        public double max_lat = -180;
        public Coordinates centroid;
        public bool IsInside(Coordinates p, List<Coordinates> polygonPoints)
        {
            if (p.Latitude > max_long || p.Latitude < min_long || p.Longtitude > max_lat || p.Longtitude < min_lat)
            {
                return false;
            }

            int count = polygonPoints.Count;

            if (count < 3)
            {
                return false;
            }

            bool result = false;

            for (int i = 0, j = count - 1; i < count; i++)
            {
                var p1 = polygonPoints[i];
                var p2 = polygonPoints[j];

                if (p1.Latitude < p.Longtitude && p2.Latitude >= p.Longtitude || p2.Latitude < p.Longtitude && p1.Latitude >= p.Longtitude)
                {
                    if (p1.Longtitude + (p.Longtitude - p1.Latitude) / (p2.Latitude - p1.Latitude) * (p2.Longtitude - p1.Longtitude) < p.Latitude)
                    {
                        result = !result;
                    }
                }

                j = i;
            }

            return result;
        }

    }
}
