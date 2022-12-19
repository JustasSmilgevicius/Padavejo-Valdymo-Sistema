using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Entities;
using Restaurant.Interfaces;
using Restaurant.Meniu;

namespace Restaurant.Repozitorijos
{
    public class StaliukoRepozitorija : IRepozitorija<Staliukas>
    {
        public List<Staliukas> Staliukai { get; set; }
        public StaliukoRepozitorija()
        {
            Staliukai = new List<Staliukas>();
            CSV_Reader csv = new CSV_Reader();
            var data = csv.CSV_Generatorius(@"C:\C#egzaminas\Restaurant\Restaurant\ListCSV\Staliukas.csv");
            foreach (var item in data)
            {
                Staliukai.Add(new Staliukas
                {
                    StaliukoID = Int32.Parse(item[0]),
                    SedimuVietuSkaicius = Int32.Parse(item[1]),
                    ArLaisvas = Boolean.Parse(item[2])
                });
            }
        }
        public void RodykVisus()
        {
            foreach (var item in Staliukai)
            {
                string arLaisvas = item.ArLaisvas ? "laisvas" : "uzimtas";
                Console.WriteLine($"Staliuko ID: {item.StaliukoID}, Sedimu vietu skaicius {item.SedimuVietuSkaicius} Staliukas yra {arLaisvas}");
            }
            Console.ReadLine();
        }
        public Staliukas RetriveByID(int id)
        {
            return Staliukai.SingleOrDefault(x => x.StaliukoID == id);
        }
        public void RodykPasirinkta(bool arLaisvas)
        {
            foreach (var item in Staliukai.Where(x => x.ArLaisvas == arLaisvas))
            {
                Console.WriteLine($"Staliuko ID: {item.StaliukoID}, Sedimu vietu skaicius {item.SedimuVietuSkaicius}");
            }
        }
        public void PakeiskStaliukoStatusa(int staliukoID, bool arLaisvas)
        {
            Staliukai.SingleOrDefault(x => x.StaliukoID == staliukoID).ArLaisvas = arLaisvas;
        }
    }
}

