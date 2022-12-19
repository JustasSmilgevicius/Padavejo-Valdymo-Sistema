using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Meniu
{
    public abstract class BendraInformacija
    {
        public int ID { get; set; }
        public string Pavadinimas { get; set; }
        public decimal Kaina { get; set; }
        public BendraInformacija() { }
        public BendraInformacija(int id, string pavadinimas, decimal kaina)
        {
            ID = id;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
        }
    }
}
