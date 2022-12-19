using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Meniu
{
    public class MaistoMeniu : BendraInformacija
    {
        
        public MaistoMeniu() { }
        public MaistoMeniu(int id, string pavadinimas, decimal kaina)
        {
            ID = id;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
        }
    }
}
