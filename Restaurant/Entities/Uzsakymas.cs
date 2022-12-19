using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Meniu;

namespace Restaurant.Entities
{
    public class Uzsakymas
    {
        public List<BendraInformacija> Informacija { get; set; }
        public Padavejas Padevejas { get; set; }
        public int StaliukoID { get; set; }
        public decimal BendraSuma { get; set; }
        public DateTime Laikas { get; set; }

        public Uzsakymas() { }
    }
}
