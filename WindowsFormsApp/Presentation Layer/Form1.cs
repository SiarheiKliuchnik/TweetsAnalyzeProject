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
using System.Runtime.InteropServices;

namespace WindowsFormsApp
{
    partial class Form1 : Form
    {
        GMapOverlay polyOverlay = new GMapOverlay("POLYGONS");
        GMapOverlay tweetOverlay = new GMapOverlay("TWEETS");
        Dictionary<string, State> mapStates = new Dictionary<string, State>();
        DataBase dataBase = new DataBase();

        public Form1()
        {
            ParseSettings();
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Data.CurrentCultureName);

            InitializeComponent();
            LoadingScreenOnOff(false);
         
            chooseFile.Visible = false;
            screenshotButton.Visible = false;
            getInfoButton.Visible = false;
            settingsButton.Visible = false;
            chooseFileListView.Visible = false;

            SetMaximumWindowsSize();

            this.menuButton.Image = (Image)(new Bitmap(menuButton.Image, new Size(18, 18)));

            dataBase.ParseSentiments();
            dataBase.ParseJSON();

            EmotionPanelCheckBoxChecked();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_SIZEBOX = 0x40000;

                var cp = base.CreateParams;
                cp.Style |= WS_SIZEBOX;

                return cp;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            gMapControl.ShowCenter = false;

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
                        GPoint.ToolTipMode = MarkerTooltipMode.Never;
                        tweets.Markers.Add(GPoint);
                    }
                }
            }
            return tweets;
        }

        private void gMapControl_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            
        }


        private void LoadingScreenOnOff(bool active)
        {
            loadScreen.Visible = active;
            logoPictureBox.Visible = active;
        }

        private void DrawLegend()
        {
            Pen pen = new Pen(Color.Black, 0.002f);
            int grids = 6;
            int widthOfRec = (EmotionPanel.Width - 1) / grids;
            Graphics g = EmotionPanel.CreateGraphics();
            Rectangle[] recs = new Rectangle[grids];
            Brush[] br = new LinearGradientBrush[grids];
            float min = -1.5f, step = 0.5f;
            float currentValue = min;
            g.DrawString(LocalizationStrings.EmoWeight, new Font("HelvLight", 10), Brushes.White, (EmotionPanel.Width + 36) / 4, 0);
            for (int i = 0; i < grids; i++)
            {
                recs[i] = new Rectangle(widthOfRec * i, 30, widthOfRec, 20);
                br[i] = new LinearGradientBrush(recs[i], Coloring.SetColors(currentValue + 0.0001f), Coloring.SetColors(currentValue + step - 0.0001f), 0f);
                currentValue += step;
                g.FillRectangle(br[i], recs[i]);
                g.DrawRectangle(pen, recs[i]);
                g.DrawString(Convert.ToString(currentValue - step), new Font("Arial", 8), Brushes.White, (widthOfRec - 2) * i, 18);
            }
            g.DrawString(Convert.ToString(currentValue) + "+", new Font("Arial", 8), Brushes.White, (widthOfRec - 3) * (grids), 18);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawLegend();
        }

        private void LoadMap(string path)
        {
            LoadingScreenOnOff(true);
            this.Refresh();
            GMapOverlay polysOverlay = new GMapOverlay("polysOverlay");


            tweetOverlay.Markers.Clear();
            polyOverlay.Polygons.Clear();
            mapStates.Clear();
            dataBase.ClearStates();
            dataBase.ParseJSON();
            dataBase.ClearTweets();
            gMapControl.Overlays.Clear();


            dataBase.ParseTweet(@"..\..\Data Layer\Data\" + path);
            mapStates = dataBase.AnalyseTweets();
            
            gMapControl.MarkersEnabled = true;
            gMapControl.PolygonsEnabled = true;
            List<GMapPolygon> polys = paintStates(mapStates);
            foreach (var poly in polys)
            {
                polysOverlay.Polygons.Add(poly);
            }
            gMapControl.Overlays.Add(polysOverlay);
            tweetOverlay = paintTweets(mapStates);
            
            gMapControl.Overlays.Add(tweetOverlay);
            RefreshMap();
            LoadingScreenOnOff(false);
        }


        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            
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

        private void logoAkhmat_Click(object sender, EventArgs e)
        {

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            if (!chooseFile.Visible)
            {
                menuButton.Image = Image.FromFile("../../Presentation Layer/Interface/menuToo2.png");
                this.menuButton.Image = (Image)(new Bitmap(menuButton.Image, new Size(18, 18)));
            }
            else
            {
                menuButton.Image = Image.FromFile("../../Presentation Layer/Interface/menuToo1.png");
                this.menuButton.Image = (Image)(new Bitmap(menuButton.Image, new Size(18, 18)));
            }
            chooseFileListView.Visible = false;
            chooseFile.Visible = !chooseFile.Visible;
            screenshotButton.Visible = !screenshotButton.Visible;
            getInfoButton.Visible = !getInfoButton.Visible;
            settingsButton.Visible = !settingsButton.Visible;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fullScreenButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Black;

        }

        private void fullScreenButton_MouseHover(object sender, EventArgs e)
        {
            fullScreenButton.BackColor = Color.DarkGray;

        }

        private void fullScreenButton_MouseLeave(object sender, EventArgs e)
        {
            fullScreenButton.BackColor = Color.Black;
        }

        private void minimizeButton_MouseHover(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Color.DarkGray;
        }

        private void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Color.Black;
        }

        private void RotateMenuTool()
        {

        }

        private void SetMaximumWindowsSize()
        {
            Rectangle rec = new Rectangle();
            rec.Width = Screen.PrimaryScreen.WorkingArea.Size.Width + 14;
            rec.Height = Screen.PrimaryScreen.WorkingArea.Size.Height + 14;
            this.MaximumSize = rec.Size;
        }

        private void screenshotButton_Click(object sender, EventArgs e)
        {
            using (var bmp = new Bitmap(gMapControl.Width, gMapControl.Height))
            {
                 gMapControl.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                 bmp.Save(@"c:\temp\screnshot.png");
            }
            menuButton_Click(sender, e);
        }

        private void tweetInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void header_Click(object sender, EventArgs e)
        {

        }

        private void logoAkhmat_Click_1(object sender, EventArgs e)
        {

        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            if (chooseFile.Visible)
            {
                chooseFileListView.Items.Clear();
                chooseFileListView.Visible = !chooseFileListView.Visible;
                Directory.GetFiles(@"..\..\Data Layer\Data", "*.txt").ToList().ForEach(x =>
                chooseFileListView.Items.Add(Path.GetFileNameWithoutExtension(x)));
            }
            else { return; }
        }

        private void getInfoButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"c:\temp\info.txt", FileMode.Create);
            StreamWriter w = new StreamWriter(fs, Encoding.Default);
            foreach (var state in mapStates.Values)
            {
                if (state.Postcode.Equals("UNKNOWN")) continue;
                if (!float.IsNaN(state.Weight))
                {
                    w.WriteLine($"{state.Postcode} ({state.Weight.ToString()}):");
                }
                else w.WriteLine($"{state.Postcode} (No data):");
                foreach (var tweet in state.Tweets)
                    {
                        if (!float.IsNaN(tweet.Weight))
                        {
                            w.WriteLine(tweet.Weight.ToString() + " | " + tweet.Text);
                            w.Write("Valuable words or phrases: ");
                            for (int i = 0; i < tweet.valueableWords.Count - 1; i++)
                            {
                                w.Write(tweet.valueableWords[i] + ", ");
                            }
                            w.WriteLine(tweet.valueableWords[tweet.valueableWords.Count - 1] + ".");
                        }
                    }
                w.WriteLine();
            }
            menuButton_Click(sender, e);
        }

        private void gMapControl_OnPolygonEnter(GMapPolygon item)
        {
            //if(!float.IsNaN(mapStates[item.Name].Weight))
            //gmapToolTip.SetToolTip(gMapControl, $"{item.Name}\nTweets: {mapStates[item.Name].Tweets.Count}\nWeight: {mapStates[item.Name].Weight.ToString()}");
            //else gmapToolTip.SetToolTip(gMapControl, $"{item.Name}\nTweets: {mapStates[item.Name].Tweets.Count}\nWeight: No data");
        }

        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            Tweet tweet = new Tweet(item.Position, item.ToolTipText);
            State state = DetermineState(mapStates, tweet);
            foreach (var tw in state.Tweets)
            {
                if (tw.Text == tweet.Text && (tw.Location.Latitude == tweet.Location.Latitude && tw.Location.Longtitude == tweet.Location.Longtitude))
                {
                    gmapToolTip.SetToolTip(gMapControl, $"{LocalizationStrings.StateTitle}: {state.Postcode}\n{LocalizationStrings.TextTitle}: {tw.Text}\n{LocalizationStrings.WeightTitle}: {tw.Weight}");
                }
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            menuButton_Click(sender, e);
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
            EmotionPanelCheckBoxChecked();
            TweetPointCheckBoxChecked();
        }

        private void EmotionPanelCheckBoxChecked()
        {
            EmotionPanel.Visible = Data.EmotionPanelCheckBoxChecked;
        }
        private void TweetPointCheckBoxChecked()
        {
            tweetOverlay.IsVisibile = Data.TweetPointsCheckBoxChecked;
        }

        private void chooseFileListView_ItemActivate(object sender, EventArgs e)
        {
            //LoadMap(chooseFileListView.SelectedItems[0].Text.ToString() + ".txt");
            //menuButton_Click(sender, e);
        }

        private void chooseFileListView_MouseClick(object sender, MouseEventArgs e)
        {
            string path = chooseFileListView.SelectedItems[0].Text.ToString() + ".txt";
            menuButton_Click(sender, e);
            LoadMap(path);
            EmotionPanelCheckBoxChecked();
            TweetPointCheckBoxChecked();
        }

        private void RefreshMap()
        {
            double curZoom = gMapControl.Zoom;
            gMapControl.Zoom += 0.001;
            gMapControl.Zoom -= 0.001;
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void gmapToolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void chooseFileListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadScreen_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {
            gmapToolTip.Hide(gMapControl);
        }

        private void ParseSettings(string path = @"..\\..\\..\\Data\\settings.cfg")
        {
            StreamReader sr = new StreamReader(path);
            while(!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] lines = s.Split(',');
                Data.EmotionPanelCheckBoxChecked = Convert.ToBoolean(lines[0]);
                Data.TweetPointsCheckBoxChecked= Convert.ToBoolean(lines[1]);
                Data.Directory = lines[2];
                Data.CurrentCultureName = lines[3].Trim();
            }
            sr.Close();
            sr.Dispose();
        }
    }
}


