using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;

namespace WindowsFormsApp
{
    partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("location", "location");
            dataGridView1.Columns.Add("date", "date");
            dataGridView1.Columns.Add("text", "text");

            GMapOverlay overlayy = new GMapOverlay("over");
            GMapOverlay polyOverlay = new GMapOverlay("polyOverlay");
            DataBase dataBase = new DataBase();

            dataBase.ParseTweet(@"..\..\Data Layer\Data\weekend_tweets2014.txt");
            dataBase.ParseSentiments(); 
            dataBase.ParseJSON();
            List<State> states = dataBase.AnalyseTweets();
            foreach (var tweet in dataBase.tweets)
            {
                string[] mas = new string[]
                {
                    tweet.Location.ToString(),
                    tweet.DateOfTweet.ToString(),
                    tweet.Text
                };
                dataGridView1.Rows.Add(mas);
            }
            gMapControl.MarkersEnabled = true;
            gMapControl.PolygonsEnabled = true;
            GMarkerGoogle mark = new GMarkerGoogle(new GMap.NET.PointLatLng(53.684875692724994, 23.840167167130677), GMarkerGoogleType.black_small);
            mark.ToolTip = new GMapRoundedToolTip(mark);
            mark.ToolTip.Stroke.Color = Color.FromArgb(0, 255, 255, 255);
            overlayy.Markers.Add(mark);
            gMapControl.Overlays.Add(overlayy);
            List<GMapPolygon> polys = paintStates(states);
            foreach (var poly in polys)
            {
                polyOverlay.Polygons.Add(poly);
            }
            gMapControl.Overlays.Add(polyOverlay);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.YandexMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.Position = new GMap.NET.PointLatLng(53.684875692724994, 23.840167167130677);
            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 4;
        }

        private List<GMapPolygon> paintStates(List<State> states)
        {
           List<GMapPolygon> polys = new List<GMapPolygon>();
           foreach(var item in states)
           {
                foreach(var polygons in item.Polygons)
                {
                    foreach (var polygon in polygons)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        foreach (var point in polygon)
                        {
                            PointLatLng pnt = new PointLatLng(point.Latitude, point.Longtitude);
                            points.Add(pnt);
                        }
                        item.centroid = item.Compute2DPolygonCentroid(polygon);
                        GMapPolygon plgn = new GMapPolygon(points, item.Postcode);
                        if (item.Weight > 0)
                        {
                            plgn.Fill = new SolidBrush(Color.YellowGreen);
                        }
                        else if (item.Weight < 0)
                        {
                            plgn.Fill = new SolidBrush(Color.LightSkyBlue);
                        }
                        else
                        {
                            plgn.Fill = new SolidBrush(Color.WhiteSmoke);
                        }
                        plgn.Stroke = new Pen(Color.SeaShell, 0.01F);
                        polys.Add(plgn);
                    }
                }
            }
            return polys;
        }

        private void gMapControl_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            
        }
    }
}
