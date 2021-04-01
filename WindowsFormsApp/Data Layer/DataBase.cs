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
    internal class DataBase
    {
        public List<Tweet> tweets = new List<Tweet>();
        public Dictionary<string, State> states = new Dictionary<string, State>();
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

        public Dictionary<string, State> AnalyseTweets()
        {
            Dictionary<string, State> newStates = new Dictionary<string, State>(this.states);
            List<State> states = new List<State>(newStates.Values);
            this.tweets[0].Analyse(this.wordValues, this.anyValuableWords);
            for (int i = 1; i<tweets.Count; i++)
            {
                if (this.tweets[i].Text.Equals(this.tweets[i - 1].Text))
                    continue;
                else
                {
                    this.tweets[i].Analyse(this.wordValues, this.anyValuableWords);
                    State state = DetermineState(states, this.tweets[i]);
                    if (!newStates.ContainsKey(state.Postcode))
                    {
                        state.Tweets.Add(this.tweets[i]);
                        if (!float.IsNaN(this.tweets[i].Weight))
                        {
                            state.Weight = 0;
                            state.Weight += this.tweets[i].Weight;
                        }
                        newStates.Add(state.Postcode, state);
                    }
                    else
                    {
                        State newState = newStates[state.Postcode];
                        newStates.Remove(state.Postcode);
                        if (!float.IsNaN(this.tweets[i].Weight))
                        {
                            if (!float.IsNaN(newState.Weight))
                            {
                                newState.Weight = ((newState.Weight * newState.Tweets.Count) + this.tweets[i].Weight) / (newState.Tweets.Count + 1);
                            }
                            else 
                            {
                                newState.Weight = 0;
                                newState.Weight += this.tweets[i].Weight;
                            }
                        }
                        newState.Tweets.Add(this.tweets[i]);
                        newStates.Add(newState.Postcode, newState);
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

        public void ClearTweets()
        {
            this.tweets.Clear();
        }
        public void ClearStates()
        {
            this.states.Clear();
        }
    }
}
