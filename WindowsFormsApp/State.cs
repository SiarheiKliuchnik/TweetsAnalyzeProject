using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class State
    {
        public List<Tweet> Tweets
        { get; set; }
        public float Weigth
        { get; set; }
        public List<List<List<Coordinates>>> Polygons
        { get; set; }
    }
}
