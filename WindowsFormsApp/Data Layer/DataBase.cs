using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp
{
    class DataBase
    {
        public List<Tweet> tweets = new List<Tweet>();
        public List<State> states = new List<State>();
        public Hashtable wordValues = new Hashtable();
        public HashSet<string> anyValuableWords = new HashSet<string>();

        public DataBase()
        {
            
        }
        public void ParseTweet(string path)
        {
            this.tweets = TweetParser.ParseTweets(path);
        }
        public void ParseSentiments(string path = @"..\..\Data Layer\Data\sentiments.csv")
        {
            this.wordValues = SentimentsParser.Parse(out this.anyValuableWords, path);
        }
        public void ParseJSON(string path)
        {
            this.states = JsonParser.Parse(path);
        }

        public void AnalyseTweets()
        {
            this.tweets[0].Analyse(this.wordValues, this.anyValuableWords);
            for (int i = 1; i<tweets.Count; i++)
            {
                if (this.tweets[i].Text.Equals(this.tweets[i - 1].Text))
                    continue;
                else
                    this.tweets[i].Analyse(this.wordValues, this.anyValuableWords);
            }
        }
    }
}
