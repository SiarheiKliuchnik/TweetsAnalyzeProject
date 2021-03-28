using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        GMapOverlay polyOverlay = new GMapOverlay("POLYGONS");
        GMapOverlay tweetOverlay = new GMapOverlay("TWEETS");
        Dictionary<string, State> mapStates = new Dictionary<string, State>();

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
            checkBox1.Checked = true;
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

        private List<GMapPolygon> paintStates(Dictionary<string, State> states)
        {
            List<GMapPolygon> polys = new List<GMapPolygon>();
            foreach (var item in states.Values)
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


        private GMapOverlay paintTweets(Dictionary<string, State> states)
        {
            GMapOverlay tweets = new GMapOverlay("tweetPoints");
            foreach (var state in states.Values)
            {
                if (state.Postcode == "UNKNOWN" || state.Tweets.Count == 0)
                    continue;
                foreach (var tweet in state.Tweets)
                {
                    if (!float.IsNaN(tweet.Weight))
                    {
                        Bitmap tweetPoint = new Bitmap(6, 6);

                        using (Graphics g = Graphics.FromImage(tweetPoint))
                        {
                            Pen pen = new Pen(Color.Black, 2f);
                            g.DrawEllipse(pen, 0, 0, 4.5f, 4.5f);
                            g.FillEllipse(new SolidBrush(Coloring.SetColors(tweet.Weight)), 0, 0, 4.5f, 4.5f);
                        }
                        Coordinates c = tweet.Location;
                        PointLatLng point = new PointLatLng(tweet.Location.Longtitude, tweet.Location.Latitude);
                        GMapMarker GPoint = new GMarkerGoogle(point, tweetPoint);
                        GPoint.ToolTip = new GMapRoundedToolTip(GPoint);
                        GPoint.ToolTipText = tweet.Text;
                        GPoint.IsHitTestVisible = true;
                        GPoint.ToolTipMode = MarkerTooltipMode.OnMouseOver;
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
            LoadMap(ChooseFileSouceBox.SelectedItem.ToString() + ".txt");
        }

        private void DrawLegend()
        {
            Pen pen = new Pen(Color.Black, 0.002f);
            int grids = 6;
            int widthOfRec = (panel1.Width - 1) / grids;
            Graphics g = panel1.CreateGraphics();
            Rectangle[] recs = new Rectangle[grids];
            Brush[] br = new LinearGradientBrush[grids];
            float min = -1.5f, step = 0.5f;
            float currentValue = min;
            g.DrawString("Emotional weight", new Font("Times", 10), Brushes.Black, (panel1.Width + 36) / 4, 0);
            for (int i = 0; i < grids; i++)
            {
                recs[i] = new Rectangle(widthOfRec * i, 30, widthOfRec, 20);
                br[i] = new LinearGradientBrush(recs[i], Coloring.SetColors(currentValue + 0.0001f), Coloring.SetColors(currentValue + step - 0.0001f), 0f);
                currentValue += step;
                g.FillRectangle(br[i], recs[i]);
                g.DrawRectangle(pen, recs[i]);
                g.DrawString(Convert.ToString(currentValue - step), new Font("Arial", 8), Brushes.Black, (widthOfRec - 2) * i, 18);
            }
            g.DrawString(Convert.ToString(currentValue), new Font("Arial", 8), Brushes.Black, (widthOfRec - 2) * (grids), 18);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawLegend();
        }

        private void LoadMap(string path)
        {
            GMapOverlay polyOverlay = new GMapOverlay("polyOverlay");
            DataBase dataBase = new DataBase();

            dataBase.ParseTweet(@"..\..\Data Layer\Data\" + path);
            dataBase.ParseSentiments();
            dataBase.ParseJSON();
            mapStates = dataBase.AnalyseTweets();
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
            List<GMapPolygon> polys = paintStates(mapStates);
            foreach (var poly in polys)
            {
                polyOverlay.Polygons.Add(poly);
            }
            gMapControl.Overlays.Add(polyOverlay);
            tweetOverlay = paintTweets(mapStates);
            if (checkBox1.Checked)
                tweetOverlay.IsVisibile = true;
            else tweetOverlay.IsVisibile = false;
            gMapControl.Overlays.Add(tweetOverlay);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tweetOverlay.IsVisibile = checkBox1.Checked;
        }

        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            Tweet tweet = new Tweet(item.Position, item.ToolTipText);
            State state = DetermineState(mapStates, tweet);
            foreach (var tw in state.Tweets)
            {
                if (tw.Text == tweet.Text && (tw.Location.Latitude == tweet.Location.Latitude && tw.Location.Longtitude == tweet.Location.Longtitude))
                {
                    label1.Text = "State: " + state.Postcode;
                    label4.Text = tw.Weight.ToString();
                    label4.ForeColor = Coloring.SetColors(tw.Weight);
                    label4.BackColor = Color.Black;
                    label3.Text = "Tweet: " + tw.Text;
                    
                }
            }
        }
        private State DetermineState(Dictionary<string, State> states, Tweet tweet)
        {
            State stateToReturn = new State();
            stateToReturn.Postcode = "UNKNOWN";
            foreach (var st in states.Values)
            {
                foreach (var item in st.Polygons)
                {
                    foreach (var polygons in item)
                    {
                        if (st.IsInside(tweet.Location, polygons))
                        {
                            return st;
                        }
                    }
                }
            }
            return stateToReturn;
        }
    }
}

