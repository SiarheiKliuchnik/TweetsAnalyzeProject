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
            string[] massString = File.ReadAllLines(path);
            foreach (var str in massString)
            {
                Tweet tweet = GetTweet(str);
                if (tweet!=null)
                tweets.Add(tweet);
            }

            foreach (var tweet in tweets)
            {
                TextParse(tweet);

                foreach (var sentence in tweet.sentences)
                {
                    SentenceParser(sentence);
                }
            }
            return tweets;

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return null;
            //}
        }

        private static Tweet GetTweet(string line)
        {
            string[] sentences = line.Split('\t');
            if (sentences.Length < 3) return null;
            else 
                return new Tweet(sentences[0].Trim('[', ']'), sentences[2], sentences[3]);
        }

    }
}
