using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class Tweet
    {
        private Coordinates location;

        private DateTime dateOfTweet;


        private string text;

        public Coordinates Location { get => location; set => location = value; }
        public DateTime DateOfTweet { get => dateOfTweet; set => dateOfTweet = value; }
        public string Text { get => text; set => text = value; }

        public Tweet(string location, string date, string text)
        {
            this.location = new Coordinates(location);
            this.dateOfTweet = Convert.ToDateTime(date);
            this.text = text;
            
        }
    }
}
