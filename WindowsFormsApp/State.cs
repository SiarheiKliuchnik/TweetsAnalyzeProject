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
        public float Weight { get; set; }
        public List<Tweet> Tweets {get; set;}
        [JsonProperty("Polygons")]
        public List<List<List<double>>> Polygons { get; set; }
    }
}
