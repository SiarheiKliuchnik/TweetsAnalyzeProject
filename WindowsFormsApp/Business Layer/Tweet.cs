using System;
using System.Collections;
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

        private float weight;

       

        public Coordinates Location { get => location; set => location = value; }
        public DateTime DateOfTweet { get => dateOfTweet; set => dateOfTweet = value; }
        public string Text { get => text; set => text = value; }
        public float Weight { get => weight; set => weight = value; }

        public List<string> valueableWords = new List<string>();

        public Tweet(string location, string date, string text)
        {
            this.location = new Coordinates(location);
            this.dateOfTweet = Convert.ToDateTime(date);
            this.text = text;
            
        }

        public void Analyse(Hashtable wordValues, HashSet<string> anyValuableWords)
        {
            float value = 0;
            string[] phrases = this.Text.ToLower().Split(',', '.', '?', '!', ':', ';', '"', '=', '+', '(', ')');
            foreach (string phrase in phrases)
            {
                string[] words = phrase.Trim().Split(' ');
                int index = 0;
                while (index < words.Length)
                {
                    string newRow = words[index];
                    if (anyValuableWords.Contains(newRow))
                    {
                            value += AnalysePhrase(newRow, words, index, out index, anyValuableWords, wordValues);
                    }
                    else
                        index++;
                }
            }
            if (this.valueableWords.Count != 0)
                this.Weight = value;
            else this.weight = float.NaN;
        }

        public float AnalysePhrase(string newRow, string[] words, int curInd, out int nextInd, HashSet<string> anyValuableWords, Hashtable wordValues)
        {
            string toReturn = newRow;
            nextInd = curInd + 1;
            while (curInd < words.Length)
            {
                if (wordValues.ContainsKey(newRow))
                {
                    toReturn = newRow;
                    nextInd = curInd + 1;
                }
                if (++curInd < words.Length && anyValuableWords.Contains(words[curInd]))
                {
                    newRow += ' ' + words[curInd];
                }
                else
                    break;
            }
            if (wordValues.ContainsKey(toReturn))
            {
                valueableWords.Add(toReturn);
            }
            return Convert.ToSingle(wordValues[toReturn]);
        }
        public override string ToString()
        {
            return text.ToString();
        }

    }
}
