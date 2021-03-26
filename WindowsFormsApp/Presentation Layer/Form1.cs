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

using WindowsFormsApp.Presentation_Layer;
using System.IO;

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
            LoadListFileNames();
            dataGridView1.Columns.Add("location", "location");
            dataGridView1.Columns.Add("date", "date");
            dataGridView1.Columns.Add("text", "text");

            GMapOverlay overlayy = new GMapOverlay("over");
            GMapOverlay polyOverlay = new GMapOverlay("polyOverlay");
            DataBase dataBase = new DataBase();

            dataBase.ParseTweet(@"..\..\Data Layer\Data\cali_tweets2014.txt");
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
            gMapControl.Overlays.Add(paintTweets(states));
        }
        private void LoadListFileNames()
        {
            Directory.GetFiles(@"..\..\Data Layer\Data", "*.txt").ToList().ForEach(x => ChooseFileSouceBox.Items.Add(Path.GetFileNameWithoutExtension(x)));
            if (ChooseFileSouceBox.Items.Count != 0)
                ChooseFileSouceBox.SelectedIndex = 0;
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
            foreach (var item in states)
            {
                foreach (var polygons in item.Polygons)
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
                        if (!float.IsNaN(item.Weight))
                            plgn.Fill = new SolidBrush(Coloring.SetColors(item.Weight));
                        else plgn.Fill = new SolidBrush(Color.Gray);
                        plgn.Stroke = new Pen(Color.Black, 0.005F);
                        polys.Add(plgn);
                    }
                }
            }
            return polys;
        }

        private GMapOverlay paintTweets(List<State> states)
        {
            GMapOverlay tweets = new GMapOverlay("tweetPoints");
            foreach(var state in states)
            {
                if (state.Postcode == "UNKNOWN" || state.Tweets.Count==0)
                    continue;
                foreach (var tweet in state.Tweets)
                {
                    if (!float.IsNaN(tweet.Weight))
                     {
                        Coordinates c = tweet.Location;
                        PointLatLng point = new PointLatLng(tweet.Location.Longtitude, tweet.Location.Latitude);
                        GMapPoint GPoint = new GMapPoint(point, 5, tweet.Weight);
                        //GPoint.ToolTipText = tweet.Text;
                        //GPoint.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        tweets.Markers.Add(GPoint);

                    }
                }
            }
            return tweets;
        }

        private void gMapControl_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            
        }

        private void Uploadbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
