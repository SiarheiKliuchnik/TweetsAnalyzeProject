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
            Tweets = new List<Tweet>();
            Polygons = new List<List<List<Coordinates>>>();
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

        public Coordinates Compute2DPolygonCentroid(List<Coordinates> vertices)
        {
            Coordinates centroid = new Coordinates(0, 0);
            double signedArea = 0.0;
            double x0 = 0.0;
            double y0 = 0.0;
            double x1 = 0.0;
            double y1 = 0.0;
            double a = 0.0;

            // For all vertices except last
            int i = 0;
            for (i = 0; i < vertices.Count - 1; ++i)
            {
                x0 = vertices[i].Latitude;
                y0 = vertices[i].Longtitude;
                x1 = vertices[i + 1].Latitude;
                y1 = vertices[i + 1].Longtitude;
                a = x0 * y1 - x1 * y0;
                signedArea += a;
                centroid.Latitude += (x0 + x1) * a;
                centroid.Longtitude += (y0 + y1) * a;
            }

            // Do last vertex
            x0 = vertices[i].Latitude;
            y0 = vertices[i].Longtitude;
            x1 = vertices[0].Latitude;
            y1 = vertices[0].Longtitude;
            a = x0 * y1 - x1 * y0;
            signedArea += a;
            centroid.Latitude += (x0 + x1) * a;
            centroid.Longtitude += (y0 + y1) * a;

            signedArea *= 0.5;
            centroid.Latitude /= (6 * signedArea);
            centroid.Longtitude /= (6 * signedArea);

            return centroid;
        }
    }
}
