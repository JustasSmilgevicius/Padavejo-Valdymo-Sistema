using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Restaurant.Meniu
{
    public class CSV_Reader
    {
        public List<string[]> CSV_Generatorius(string path)
        {
            var reader = new System.IO.StreamReader(path);
            List<string[]> data = new List<string[]>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(':');
                data.Add(values);
            }
            return data;

        }
    } 
}
