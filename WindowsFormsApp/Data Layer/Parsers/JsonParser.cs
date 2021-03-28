using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WindowsFormsApp
{
    static class JsonParser
    {
        public static Dictionary<string, State> Parse(string path = "..\\..\\..\\Data\\states.json")
        {
            string jsonString = new StreamReader(path).ReadToEnd();
            JObject jsonStates = JObject.Parse(jsonString);

            Dictionary<string, State> states = new Dictionary<string, State>();

            foreach(var s in jsonStates)
            {
                State state = new State();
                state.Postcode = s.Key;
                foreach(var polygons in s.Value)
                {
                    List<List<Coordinates>> polygon = new List<List<Coordinates>>();
                    foreach (var p in polygons)
                    {
                        List<Coordinates> point = new List<Coordinates>();
                        foreach(var pair in p)
                        {
                            double x = Double.Parse(pair.First.ToString());
                            double y = Double.Parse(pair.Last.ToString());
                            if(x>state.max_long)
                            {
                                state.max_long = x;
                            }
                            if(x<state.min_long)
                            {
                                state.min_long = x;
                            }

                            if(y>state.max_lat)
                            {
                                state.max_lat = y;
                            }
                            if (y< state.min_lat)
                            {
                                state.min_lat = y;
                            }
                            
                            Coordinates c = new Coordinates(x, y);
                            point.Add(c);
                            polygon.Add(point);
                        }
                    }
                    state.Polygons.Add(polygon);
                }
                states.Add(s.Key, state);
            }
            return states;
        }
    }
}
