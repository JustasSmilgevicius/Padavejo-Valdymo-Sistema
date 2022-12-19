using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Interfaces;

namespace Restaurant.Meniu
{
    public class MaistoRepozitorija : IRepozitorija <MaistoMeniu>
    {
        public List<MaistoMeniu> Maistas { get; set; }
        public MaistoRepozitorija()
        {
            Maistas = new List<MaistoMeniu>();
            CSV_Reader csv = new CSV_Reader();
            var data = csv.CSV_Generatorius(@"C:\C#egzaminas\Restaurant\Restaurant\ListCSV\Maistas.csv");
            foreach (var item in data)
            {
                Maistas.Add(new MaistoMeniu
                {
                    ID = Int32.Parse(item[0]),
                    Pavadinimas = item[1],
                    Kaina = decimal.Parse(item[2])
                });
            }
        }
        public void RodykVisus()
        {
            foreach (var item in Maistas)
            {
                Console.WriteLine($"ID: {item.ID}, Patiekalo pavadinimas: {item.Pavadinimas}, kaina: {item.Kaina} euru");
            }
        }
        public MaistoMeniu RetriveByID(int id)
        {
            return Maistas.SingleOrDefault(x => x.ID == id);
        }
    }
}
