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
        public static List<State> Parse(string path = "..\\..\\..\\Data\\states.json")
        {
            string jsonString = new StreamReader(path).ReadToEnd();
            JObject jsonStates = JObject.Parse(jsonString);

            List<State> states = new List<State>();

            foreach(var s in jsonStates)
            {
                State state = new State();
                state.Postcode = s.Key;
                foreach(var polygons in s.Value)
                {
                    List<List<Coordinates>> list1 = new List<List<Coordinates>>();
                    foreach (var p in polygons)
                    {
                        List<Coordinates> list2 = new List<Coordinates>();
                        foreach(var pair in p)
                        {
                            double x = Double.Parse(pair.First.ToString());
                            double y = Double.Parse(pair.Last.ToString());
                            Coordinates c = new Coordinates(x, y);
                            list2.Add(c);
                            list1.Add(list2);
                        }
                    }
                    state.Polygons.Add(list1);
                }
                states.Add(state);
            }
            return states;
        }
    }
}
