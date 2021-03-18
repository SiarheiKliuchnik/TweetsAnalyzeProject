using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class TweetParser
    {
      
        public static List<Tweet> ParseTweets(string path)
        {
            List<Tweet> tweets = new List<Tweet>();
            Regex location = new Regex(@"[-]?[0-9]+[.][0-9]+[,][\s][-]?[0-9]+[.][0-9]+");
            Regex date = new Regex(@"[0-9]{4}([-][0-9]{2}){2}.([0-9][0-9][:]){2}[0-9][0-9]");
            Regex text = new Regex(@"[\w*\/*\p{Zs}*\p{P}*]+$", RegexOptions.IgnoreCase);
            try
            {
                string[] massString = File.ReadAllLines(path);
                foreach (var str in massString)
                {
                    tweets.Add(GetTweet(location.Match(str), date.Match(str), text.Match(str)));
                }
                return tweets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private static Tweet GetTweet(Match location, Match date, Match str)
        {
            Tweet tweet = new Tweet(location.Value, date.Value, str.Value);

            return tweet;
        }

    }
}
