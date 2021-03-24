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

        private double weight; 

        public List<Sentence> sentences = new List<Sentence>();


        public Coordinates Location { get => location; set => location = value; }
        public DateTime DateOfTweet { get => dateOfTweet; set => dateOfTweet = value; }
        public string Text { get => text; set => text = value; }
        public double Weight { get => weight; set => weight = value; }

        public Tweet(string location, string date, string text)
        {
            this.location = new Coordinates(location);
            this.dateOfTweet = Convert.ToDateTime(date);
            this.text = text;
        }

        public override string ToString()
        {
            return text.ToString();
        }

        private void CalculateTweetWeight(Dictionary<char, Dictionary<string, double>> sentiments)
        {
            foreach (var s in this.sentences)
            {
                for (int i = 0; i < s.Words_.Count; i++)
                {
                    Dictionary<string, double> dict = new Dictionary<string, double>();
                    double val = 0;

                    if (sentiments.TryGetValue(s.Words_[i].Content[0], out dict))
                    {

                    }
                }
            }
        }
    }
}
