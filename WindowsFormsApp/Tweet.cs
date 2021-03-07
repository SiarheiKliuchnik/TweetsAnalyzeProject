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

        public static void TextParse(string text)
        {
            char[] EndOfSentences = { '.', '?', '!' };
            Sentence sentence = new Sentence();
            text.Content = text.Content.Trim();
            text.Content = System.Text.RegularExpressions.Regex.Replace(text.Content, @" +", " ").Replace("\r", "");
            foreach (char symbol in text.Content)
            {
                if (symbol == '\r' || symbol == '\n') continue;
                if (Array.Exists(EndOfSentences, element => element == symbol))
                {
                    sentence.Content += symbol;
                    text.Sentences_.Add(new Sentence(sentence));
                    sentence = new Sentence();
                }
                else
                {
                    sentence.Content += symbol;
                }
            }
            foreach (var Tsentence in text.Sentences_)
            {
                Tsentence.Content = Tsentence.Content.Trim();
                Tsentence.Content = System.Text.RegularExpressions.Regex.Replace(Tsentence.Content, @" +", " ");
                SentenceParser(Tsentence);
            }
            return text;
        }
    }
}
