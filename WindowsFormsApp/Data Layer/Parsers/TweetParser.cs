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

        public static void TextParse(Tweet tweet)
        {
            char[] EndOfSentences = { '.', '?', '!', '\r', '\n' };

            tweet.Text = tweet.Text.Trim();
            tweet.Text = System.Text.RegularExpressions.Regex.Replace(tweet.Text, @" +", " ");
            Regex rx = new Regex(@"(?<=[\.!\? ])\s+");
            string[] sentences = rx.Split(tweet.Text);
            foreach (var item in sentences)
            {
                Sentence sentence = new Sentence();
                sentence.Content = item;
                tweet.sentences.Add(sentence);
            }
        }
        public static void SentenceParser(Sentence sentence)
        {
            char[] EndOfWords = { '.', '!', '?', ' ', ':', ';', ',' };
            Word word = new Word();
            foreach (char symbol in sentence.Content)
            {
                if (Array.Exists(EndOfWords, element => element == symbol))
                {
                    if (word.Content == null) continue;
                    word.PunctuationMark_ = symbol;
                    sentence.Words_.Add(new Word(word));
                    word = new Word();
                }
                else
                {
                    word.Content += symbol;
                }
            }
        }
    }
}
