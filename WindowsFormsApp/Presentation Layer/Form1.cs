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

            DataBase dataBase = new DataBase();

            dataBase.ParseTweet(@"..\..\Data Layer\Data\cali_tweets2014.txt");
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
            //JsonParser.Parse();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.YandexMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.Position = new GMap.NET.PointLatLng(53.684875692724994, 23.840167167130677);
            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 14;
        }
    }
}
