using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp
{
    static class SentimentsParser
    {
        public static Hashtable Parse(out HashSet<string> anyValuableWords, string path = @"..\..\Data Layer\Data\sentiments.csv")
        {
            Hashtable htFin = new Hashtable();
            StreamReader sr = new StreamReader(path);
            anyValuableWords = new HashSet<string>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] lineData = line.Split(',');
                string stringValue = lineData[0];
                double doubleValue = Double.Parse(lineData[1], CultureInfo.InvariantCulture);
                htFin.Add(stringValue, doubleValue);
                string[] words = stringValue.Split(' ');
                foreach (var word in words)
                {
                    anyValuableWords.Add(word);
                }
            }
            return htFin;
        }
    }
}
