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
        public void ParseSentiments(string path)
        {
        }
        public void ParseJSON(string path)
        {
        }
    }
}
