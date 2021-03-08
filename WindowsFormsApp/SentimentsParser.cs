using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp
{
    static class SentimentsParser
    {
            public static Dictionary<char, Dictionary<string, double>> Parse(string path = "sentiments.csv")
            {
                StreamReader sr = new StreamReader(path);
                Dictionary<char, Dictionary<string, double>> dictFin = new Dictionary<char, Dictionary<string, double>>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] lineData = line.Split(',');
                    Dictionary<string, double> dict = new Dictionary<string, double>();
                    string stringValue = lineData[0];
                    double doubleValue = Double.Parse(lineData[1], CultureInfo.InvariantCulture);
                    dict.Add(stringValue, doubleValue);
                    if (!dictFin.ContainsKey(lineData[0][0]))
                    {
                        dictFin.Add(lineData[0][0], dict);
                    }
                    else
                    {
                        Dictionary<string, double> newDict = new Dictionary<string, double>();
                        dictFin.TryGetValue(lineData[0][0], out newDict);
                        newDict.Add(lineData[0], Double.Parse(lineData[1], CultureInfo.InvariantCulture));
                        dictFin[lineData[0][0]] = newDict;
                    }
                }
                return dictFin;
            }
    }
}
