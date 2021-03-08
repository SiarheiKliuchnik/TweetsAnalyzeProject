using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    static class JsonParser
    {
        public static Dictionary<string, State> Parse(string path = "states.json")
        {
            string JsonString = new StreamReader(path).ReadToEnd();
            return JsonConvert.DeserializeObject<Dictionary<string, State>>(JsonString);
        }
    }
}
