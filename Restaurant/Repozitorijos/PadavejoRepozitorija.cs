using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Entities;
using Restaurant.Interfaces;
using Restaurant.Meniu;

namespace Restaurant.Repozitorijos
{
    public class PadavejoRepozitorija : IRepozitorija <Padavejas>
    {
        public List<Padavejas> Padavejo { get; set; }
        public PadavejoRepozitorija()
        {
            Padavejo = new List<Padavejas>();
            CSV_Reader csv = new CSV_Reader();
            var data = csv.CSV_Generatorius(@"C:\C#egzaminas\Restaurant\Restaurant\ListCSV\Padavejas.csv");
            foreach (var item in data)
            {
                Padavejo.Add(new Padavejas
                {
                    PadavejoID = Int32.Parse(item[0]),
                    PadavejoVardas = item[1]
                });
            }
        }
        public void RodykVisus()
        {
            foreach (var item in Padavejo)
            {
                Console.WriteLine($"Padavejo ID: {item.PadavejoID}, padavejo vardas: {item.PadavejoVardas}");
            }
        }
        public Padavejas RetriveByID(int id)
        {
            return Padavejo.SingleOrDefault(x=>x.PadavejoID==id);
        }
    }
}

    
    
        
            