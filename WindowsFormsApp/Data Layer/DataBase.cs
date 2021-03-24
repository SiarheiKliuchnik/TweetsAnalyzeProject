using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;

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
        public void ParseJSON(string path = @"..\\..\\..\\Data\\states.json")
        {
            this.states = JsonParser.Parse(path);
        }

        public List<State> AnalyseTweets()
        {
            List<State> newStates = new List<State>();
            this.tweets[0].Analyse(this.wordValues, this.anyValuableWords);
            for (int i = 1; i<tweets.Count; i++)
            {
                if (this.tweets[i].Text.Equals(this.tweets[i - 1].Text))
                    continue;
                else
                {
                    this.tweets[i].Analyse(this.wordValues, this.anyValuableWords);
                    State state = DetermineState(this.states, this.tweets[i]);
                    if (!newStates.Exists(x => x.Postcode.Contains(state.Postcode)))
                    {
                        state.Tweets.Add(this.tweets[i]);
                        state.Weight += this.tweets[i].Weight;
                        newStates.Add(state);
                    }
                    else
                    {
                        int index = newStates.FindIndex(x => x.Postcode.Contains(state.Postcode));
                        State newState = newStates[index];
                        newStates.RemoveAt(index);
                        newState.Weight = ((newState.Weight * newState.Tweets.Count) + this.tweets[i].Weight) / (newState.Tweets.Count + 1);
                        newState.Tweets.Add(this.tweets[i]);
                        newStates.Add(newState);
                    }
                }
            }
            return newStates;
        }

        public State DetermineState(List<State> states, Tweet tweet)
        {
            State stateToReturn = new State();
            stateToReturn.Postcode = "UNKNOWN";
            foreach (var st in states)
            {
                foreach (var item in st.Polygons)
                {
                    foreach (var polygons in item)
                    {
                        if(st.IsInside(tweet.Location, polygons))
                        {
                            return st;
                        }
                    }
                }
            }
            return stateToReturn;
        }
    }
}
