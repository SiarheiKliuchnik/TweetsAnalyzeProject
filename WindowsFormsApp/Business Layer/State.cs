using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class State
    {
        public State()
        {
           Tweets = new List<Tweet>();
            Polygons = new List<List<List<Coordinates>>>();
        }
        public string Postcode { get; set; }
        public float Weight { get; set; }
        public List<Tweet> Tweets { get; set; }
        public List<List<List<Coordinates>>> Polygons { get; set; }
    }
}
