using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Interfaces;

namespace Restaurant.Meniu
{
    public class GerimuRepozitorija : IRepozitorija <GerimuMeniu>
    {
        public List<GerimuMeniu> Gerimai { get; set; }
        public GerimuRepozitorija()
        {
            Gerimai = new List<GerimuMeniu>();
            CSV_Reader csv = new CSV_Reader();
            var data = csv.CSV_Generatorius(@"C:\C#egzaminas\Restaurant\Restaurant\ListCSV\Gerimai.csv");
            foreach (var item in data)
            {
                Gerimai.Add(new GerimuMeniu 
                {
                    ID = Int32.Parse(item[0]),
                    Pavadinimas = item[1],
                    Kaina = decimal.Parse(item[2])
                });
            }
        }
        public void RodykVisus()
        {
            foreach (var item in Gerimai)
            {
                Console.WriteLine($"ID: {item.ID}, Patiekalo pavadinimas: {item.Pavadinimas}, kaina: {item.Kaina} euru");
            }
        }
        public GerimuMeniu RetriveByID(int id)
        {
            return Gerimai.SingleOrDefault(x => x.ID == id);
        }
    }
}
