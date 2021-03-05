using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
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

            dataBase.ParseTweets("cali_tweets.txt");
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

        }

    }
}
